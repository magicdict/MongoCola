namespace ConfigurationFile
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlConfFile = new ResourceLib.UI.CtlFilePicker();
            this.configEditor = new ConfigurationFile.ctlConfigItem();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(286, 257);
            this.treeView1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ctlConfFile
            // 
            this.ctlConfFile.AutoSize = true;
            this.ctlConfFile.BackColor = System.Drawing.Color.Transparent;
            this.ctlConfFile.Browse = "浏览";
            this.ctlConfFile.Clear = "清空";
            this.ctlConfFile.FileFilter = "";
            this.ctlConfFile.FileName = "";
            this.ctlConfFile.Location = new System.Drawing.Point(12, 320);
            this.ctlConfFile.Name = "ctlConfFile";
            this.ctlConfFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            this.ctlConfFile.SelectedPathOrFileName = "";
            this.ctlConfFile.Size = new System.Drawing.Size(543, 38);
            this.ctlConfFile.TabIndex = 4;
            this.ctlConfFile.Title = "服务配置文件";
            // 
            // configEditor
            // 
            this.configEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.configEditor.Location = new System.Drawing.Point(304, 12);
            this.configEditor.Name = "configEditor";
            this.configEditor.Size = new System.Drawing.Size(380, 257);
            this.configEditor.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 381);
            this.Controls.Add(this.ctlConfFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.configEditor);
            this.Controls.Add(this.treeView1);
            this.Name = "Main";
            this.Text = "Configuration File ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private ctlConfigItem configEditor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private ResourceLib.UI.CtlFilePicker ctlConfFile;
    }
}

