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
            this.trvConfig = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.trvSelectConfig = new System.Windows.Forms.TreeView();
            this.ctlConfFile = new ResourceLib.UI.CtlFilePicker();
            this.configEditor = new ConfigurationFile.ctlConfigItem();
            this.SuspendLayout();
            // 
            // trvConfig
            // 
            this.trvConfig.Location = new System.Drawing.Point(12, 12);
            this.trvConfig.Name = "trvConfig";
            this.trvConfig.Size = new System.Drawing.Size(286, 539);
            this.trvConfig.TabIndex = 0;
            this.trvConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvConfig_AfterSelect);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(888, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(540, 296);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // trvSelectConfig
            // 
            this.trvSelectConfig.Location = new System.Drawing.Point(699, 12);
            this.trvSelectConfig.Name = "trvSelectConfig";
            this.trvSelectConfig.Size = new System.Drawing.Size(286, 426);
            this.trvSelectConfig.TabIndex = 5;
            // 
            // ctlConfFile
            // 
            this.ctlConfFile.AutoSize = true;
            this.ctlConfFile.BackColor = System.Drawing.Color.Transparent;
            this.ctlConfFile.Browse = "浏览";
            this.ctlConfFile.Clear = "清空";
            this.ctlConfFile.FileFilter = "";
            this.ctlConfFile.FileName = "";
            this.ctlConfFile.Location = new System.Drawing.Point(442, 470);
            this.ctlConfFile.Name = "ctlConfFile";
            this.ctlConfFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            this.ctlConfFile.SelectedPathOrFileName = "";
            this.ctlConfFile.Size = new System.Drawing.Size(543, 38);
            this.ctlConfFile.TabIndex = 4;
            this.ctlConfFile.Title = "服务配置文件";
            // 
            // configEditor
            // 
            this.configEditor.Location = new System.Drawing.Point(318, 12);
            this.configEditor.Name = "configEditor";
            this.configEditor.Size = new System.Drawing.Size(346, 264);
            this.configEditor.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 563);
            this.Controls.Add(this.configEditor);
            this.Controls.Add(this.trvSelectConfig);
            this.Controls.Add(this.ctlConfFile);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.trvConfig);
            this.Name = "Main";
            this.Text = "Configuration File ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvConfig;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private ResourceLib.UI.CtlFilePicker ctlConfFile;
        private System.Windows.Forms.TreeView trvSelectConfig;
        private ctlConfigItem configEditor;
    }
}

