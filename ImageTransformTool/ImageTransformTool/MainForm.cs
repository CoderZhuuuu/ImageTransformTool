using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTransformTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            mainProgressBar.Minimum = 0;
            mainProgressBar.Step = 1;
            foreach (string suffix in ImageUtil.getSupportedSuffixs())
            {
                formatComboBox.Items.Add(suffix);
            }
        }

        private void btnInputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "choose the input directory";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                inputDirTextBox.Text = new DirectoryInfo(dialog.SelectedPath).ToString();
            }
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "choose the output directory";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputDirTextBox.Text = new DirectoryInfo(dialog.SelectedPath).ToString();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputDirTextBox.Text))
            {
                MessageBox.Show("Input directory cannot be none!");
                return;
            }
            if (string.IsNullOrEmpty(outputDirTextBox.Text))
            {
                MessageBox.Show("Output directory cannot be none!");
                return;
            }
            if (string.IsNullOrEmpty(formatComboBox.Text))
            {
                MessageBox.Show("You must choose a format");
                return;
            }
            int searchDepth = TransformSettings.getSearchDepth();
            FileFilter fileFilter = getFileFilter();
            if (TransformSettings.isKeepOriginDirs())
            {
                transformFilesKeepDirs(inputDirTextBox.Text, outputDirTextBox.Text, fileFilter, 0, searchDepth);
            }
            else
            {
                transformFilesNotKeepDirs(inputDirTextBox.Text, outputDirTextBox.Text, fileFilter, 0, searchDepth);
            }
            MessageBox.Show("Transform Complete!");
        }

        private FileFilter getFileFilter()
        {
            FileFilter fileFilter = new FileFilter();
            fileFilter.addFilters(ImageUtil.getSupportedSuffixs());
            return fileFilter;
        }

        private void transformFilesNotKeepDirs(string inputPath, string outputPath, FileFilter fileFilter, int curDepth, int maxDepth)
        {
            IList<FileInfo> fileInfoList = new List<FileInfo>();
            Queue<DirectoryInfo> dirInfoQueue = new Queue<DirectoryInfo>();
            dirInfoQueue.Enqueue(new DirectoryInfo(inputPath));
            while (dirInfoQueue.Count > 0)
            {
                DirectoryInfo directoryInfo = dirInfoQueue.Dequeue();
                DirectoryInfo[] childDirectoryInfos = directoryInfo.GetDirectories();
                foreach (DirectoryInfo childDirectoryInfo in childDirectoryInfos)
                {
                    dirInfoQueue.Enqueue(childDirectoryInfo);
                }
                fileInfoList = fileInfoList.Concat<FileInfo>(FileUtil.getSubFileInfos(directoryInfo.FullName, fileFilter)).ToList<FileInfo>();
            }
            FileInfo[] fileInfos = fileInfoList.ToArray<FileInfo>();
            int length = fileInfos.Length;
            mainProgressBar.Maximum = length;
            mainProgressBar.Value = 0;
            for (int i = 0; i < length; ++i)
            {
                string name;
                if (TransformSettings.isKeepOriginName())
                {
                    name = FileUtil.getName(fileInfos[i].FullName);
                }
                else
                {
                    name = i.ToString();
                }
                ImageUtil.transform(fileInfos[i], string.Format("{0}\\{1}.{2}", outputPath, name, formatComboBox.Text));
                mainProgressBar.PerformStep();
            }
        }

        private void transformFilesKeepDirs(string inputPath, string outputPath, FileFilter fileFilter, int curDepth, int maxDepth)
        {
            // if current search depth > max search depth, then quit.
            if (curDepth >= maxDepth)
            {
                return;
            }
            // first, check the directory in the output path is exists, if not exists, then create one.
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            // second, get all the sub-directories and traserse it.
            DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);
            DirectoryInfo[] childDirectoryInfos = directoryInfo.GetDirectories();
            foreach (DirectoryInfo childDirectoryInfo in childDirectoryInfos)
            {
                string path = childDirectoryInfo.FullName;
                string curDir = FileUtil.getCurDir(path);
                transformFilesKeepDirs(path, outputPath + "\\" + curDir, fileFilter, curDepth + 1, maxDepth);
            }
            // third, get all the sub-files and use file filter to get image files.
            FileInfo[] fileInfos = FileUtil.getSubFileInfos(inputPath, fileFilter).ToArray<FileInfo>();
            // forth, accroding to the settings to transform all the files.
            int length = fileInfos.Length;
            mainProgressBar.Maximum = length;
            mainProgressBar.Value = 0;
            for (int i = 0; i < length; ++i)
            {
                string name;
                if (TransformSettings.isKeepOriginName())
                {
                    name = FileUtil.getName(fileInfos[i].FullName);
                }
                else
                {
                    name = i.ToString();
                }
                ImageUtil.transform(fileInfos[i], string.Format("{0}\\{1}.{2}", outputPath, name, formatComboBox.Text));
                mainProgressBar.PerformStep();
            }
        }

        private void inputDirTextBox_DragEnter(object sender, DragEventArgs e)
        {
            // if file, then link
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void inputDirTextBox_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            string path = files.GetValue(0).ToString();
            if (0 != (new System.IO.FileInfo(path).Attributes & System.IO.FileAttributes.Directory))
            {
                inputDirTextBox.Text = path;
            }
            else
            {
                MessageBox.Show("You must drag a directory");
            }
        }

        private void outputDirTextBox_DragEnter(object sender, DragEventArgs e)
        {
            // if file, then link
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void outputDirTextBox_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            string path = files.GetValue(0).ToString();
            if (0 != (new System.IO.FileInfo(path).Attributes & System.IO.FileAttributes.Directory))
            {
                outputDirTextBox.Text = path;
            }
            else
            {
                MessageBox.Show("You must drag a directory");
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new SettingDialog().ShowDialog();
        }
    }
}
