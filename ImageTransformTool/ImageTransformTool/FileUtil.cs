using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTransformTool
{
    class FileUtil
    {

        public static string getCurDir(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        public static IList<FileInfo> getSubFileInfos(string path, FileFilter fileFilter)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            IList<FileInfo> subFileInfoList = new List<FileInfo>();
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                if (fileFilter.check(fileInfo))
                {
                    subFileInfoList.Add(fileInfo);
                }
            }
            return subFileInfoList;
        }

        public static string getName(string filePath)
        {
            return System.IO.Path.GetFileNameWithoutExtension(filePath);
        }


        public static string getSuffix(string fileName)
        {
            return fileName.Substring(fileName.IndexOf('.') + 1);
        }

    }
}
