namespace ImageTransformTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInputDir = new System.Windows.Forms.Button();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.inputDirTextBox = new System.Windows.Forms.TextBox();
            this.outputDirTextBox = new System.Windows.Forms.TextBox();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInputDir
            // 
            this.btnInputDir.Location = new System.Drawing.Point(269, 20);
            this.btnInputDir.Name = "btnInputDir";
            this.btnInputDir.Size = new System.Drawing.Size(75, 23);
            this.btnInputDir.TabIndex = 0;
            this.btnInputDir.Text = "输入文件夹";
            this.btnInputDir.UseVisualStyleBackColor = true;
            this.btnInputDir.Click += new System.EventHandler(this.btnInputDir_Click);
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(269, 18);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(75, 23);
            this.btnOutputDir.TabIndex = 1;
            this.btnOutputDir.Text = "输出文件夹";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // inputDirTextBox
            // 
            this.inputDirTextBox.AllowDrop = true;
            this.inputDirTextBox.Location = new System.Drawing.Point(6, 20);
            this.inputDirTextBox.Name = "inputDirTextBox";
            this.inputDirTextBox.ReadOnly = true;
            this.inputDirTextBox.Size = new System.Drawing.Size(257, 21);
            this.inputDirTextBox.TabIndex = 2;
            this.inputDirTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.inputDirTextBox_DragDrop);
            this.inputDirTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.inputDirTextBox_DragEnter);
            // 
            // outputDirTextBox
            // 
            this.outputDirTextBox.AllowDrop = true;
            this.outputDirTextBox.Location = new System.Drawing.Point(6, 20);
            this.outputDirTextBox.Name = "outputDirTextBox";
            this.outputDirTextBox.ReadOnly = true;
            this.outputDirTextBox.Size = new System.Drawing.Size(257, 21);
            this.outputDirTextBox.TabIndex = 3;
            this.outputDirTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.outputDirTextBox_DragDrop);
            this.outputDirTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.outputDirTextBox_DragEnter);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.btnSetting);
            this.groupBoxInput.Controls.Add(this.inputDirTextBox);
            this.groupBoxInput.Controls.Add(this.btnInputDir);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(428, 60);
            this.groupBoxInput.TabIndex = 4;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "输入";
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.formatComboBox);
            this.groupBoxOutput.Controls.Add(this.outputDirTextBox);
            this.groupBoxOutput.Controls.Add(this.btnOutputDir);
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 78);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(428, 60);
            this.groupBoxOutput.TabIndex = 5;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "输出";
            // 
            // formatComboBox
            // 
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(351, 21);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(71, 20);
            this.formatComboBox.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 144);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(428, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始转换";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Location = new System.Drawing.Point(12, 174);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(428, 23);
            this.mainProgressBar.TabIndex = 7;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(350, 20);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 201);
            this.Controls.Add(this.mainProgressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "Form1";
            this.Text = "图片转换器";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInputDir;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox inputDirTextBox;
        private System.Windows.Forms.TextBox outputDirTextBox;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar mainProgressBar;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Button btnSetting;
    }
}

