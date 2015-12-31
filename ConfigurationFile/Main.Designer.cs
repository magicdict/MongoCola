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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.trvConfig = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstConfigValue = new System.Windows.Forms.ListBox();
            this.ctlConfFile = new ResourceLib.UI.CtlFilePicker();
            this.ctlMongoBin = new ResourceLib.UI.CtlFilePicker();
            this.txtServiceCommand = new System.Windows.Forms.TextBox();
            this.btnServiceCommand = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.configEditor = new ConfigurationFile.CtlConfigItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trvConfig
            // 
            this.trvConfig.Location = new System.Drawing.Point(12, 12);
            this.trvConfig.Name = "trvConfig";
            this.trvConfig.Size = new System.Drawing.Size(286, 495);
            this.trvConfig.TabIndex = 0;
            this.trvConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvConfig_AfterSelect);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(741, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstConfigValue
            // 
            this.lstConfigValue.FormattingEnabled = true;
            this.lstConfigValue.ItemHeight = 12;
            this.lstConfigValue.Location = new System.Drawing.Point(332, 325);
            this.lstConfigValue.Name = "lstConfigValue";
            this.lstConfigValue.Size = new System.Drawing.Size(509, 112);
            this.lstConfigValue.TabIndex = 7;
            this.lstConfigValue.SelectedIndexChanged += new System.EventHandler(this.lstConfigValue_SelectedIndexChanged);
            // 
            // ctlConfFile
            // 
            this.ctlConfFile.AutoSize = true;
            this.ctlConfFile.BackColor = System.Drawing.Color.Transparent;
            this.ctlConfFile.Browse = "浏览";
            this.ctlConfFile.Clear = "清空";
            this.ctlConfFile.FileFilter = "";
            this.ctlConfFile.InitFileName = "";
            this.ctlConfFile.Location = new System.Drawing.Point(12, 518);
            this.ctlConfFile.Name = "ctlConfFile";
            this.ctlConfFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            this.ctlConfFile.SelectedPathOrFileName = "";
            this.ctlConfFile.Size = new System.Drawing.Size(543, 38);
            this.ctlConfFile.TabIndex = 4;
            this.ctlConfFile.Title = "服务配置文件";
            // 
            // ctlMongoBin
            // 
            this.ctlMongoBin.AutoSize = true;
            this.ctlMongoBin.BackColor = System.Drawing.Color.Transparent;
            this.ctlMongoBin.Browse = "浏览";
            this.ctlMongoBin.Clear = "清空";
            this.ctlMongoBin.FileFilter = "";
            this.ctlMongoBin.InitFileName = "";
            this.ctlMongoBin.Location = new System.Drawing.Point(12, 562);
            this.ctlMongoBin.Name = "ctlMongoBin";
            this.ctlMongoBin.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.ctlMongoBin.SelectedPathOrFileName = "";
            this.ctlMongoBin.Size = new System.Drawing.Size(543, 38);
            this.ctlMongoBin.TabIndex = 4;
            this.ctlMongoBin.Title = "MongoBin";
            // 
            // txtServiceCommand
            // 
            this.txtServiceCommand.Location = new System.Drawing.Point(12, 625);
            this.txtServiceCommand.Multiline = true;
            this.txtServiceCommand.Name = "txtServiceCommand";
            this.txtServiceCommand.Size = new System.Drawing.Size(764, 94);
            this.txtServiceCommand.TabIndex = 8;
            // 
            // btnServiceCommand
            // 
            this.btnServiceCommand.Location = new System.Drawing.Point(582, 568);
            this.btnServiceCommand.Name = "btnServiceCommand";
            this.btnServiceCommand.Size = new System.Drawing.Size(100, 30);
            this.btnServiceCommand.TabIndex = 9;
            this.btnServiceCommand.Text = "生成服务命令";
            this.btnServiceCommand.UseVisualStyleBackColor = true;
            this.btnServiceCommand.Click += new System.EventHandler(this.btnServiceCommand_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(741, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 27);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // configEditor
            // 
            this.configEditor.Location = new System.Drawing.Point(318, 12);
            this.configEditor.Name = "configEditor";
            this.configEditor.Size = new System.Drawing.Size(523, 264);
            this.configEditor.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "已经选择配置项目";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 603);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "使用该命令启动Windows的Service";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 731);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnServiceCommand);
            this.Controls.Add(this.txtServiceCommand);
            this.Controls.Add(this.lstConfigValue);
            this.Controls.Add(this.configEditor);
            this.Controls.Add(this.ctlMongoBin);
            this.Controls.Add(this.ctlConfFile);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.trvConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private CtlConfigItem configEditor;
        private System.Windows.Forms.ListBox lstConfigValue;
        private ResourceLib.UI.CtlFilePicker ctlMongoBin;
        private System.Windows.Forms.TextBox txtServiceCommand;
        private System.Windows.Forms.Button btnServiceCommand;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

