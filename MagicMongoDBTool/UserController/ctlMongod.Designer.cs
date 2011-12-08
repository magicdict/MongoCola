using System.Windows.Forms;
namespace MagicMongoDBTool
{
    partial class ctlMongod
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.ctllogLvT = new MagicMongoDBTool.Module.ctllogLv();
            this.chkIsAppend = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.ctlFilePickerDBPath = new MagicMongoDBTool.ctlFilePicker();
            this.ctlFilePickerLogPath = new MagicMongoDBTool.ctlFilePicker();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radMaster = new System.Windows.Forms.RadioButton();
            this.radSlave = new System.Windows.Forms.RadioButton();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.ctllogLvT);
            this.grpLog.Controls.Add(this.chkIsAppend);
            this.grpLog.Location = new System.Drawing.Point(19, 123);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(730, 70);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // ctllogLvT
            // 
            this.ctllogLvT.Location = new System.Drawing.Point(256, 13);
            this.ctllogLvT.Name = "ctllogLvT";
            this.ctllogLvT.Size = new System.Drawing.Size(312, 51);
            this.ctllogLvT.TabIndex = 14;
            // 
            // chkIsAppend
            // 
            this.chkIsAppend.AutoSize = true;
            this.chkIsAppend.Location = new System.Drawing.Point(43, 25);
            this.chkIsAppend.Name = "chkIsAppend";
            this.chkIsAppend.Size = new System.Drawing.Size(206, 17);
            this.chkIsAppend.TabIndex = 0;
            this.chkIsAppend.Text = "追加模式（默认的日志是覆盖模式）";
            this.chkIsAppend.UseVisualStyleBackColor = true;
            this.chkIsAppend.CheckedChanged += new System.EventHandler(this.chkIsAppend_CheckedChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(32, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(49, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "端口号：";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(97, 28);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(67, 20);
            this.numPort.TabIndex = 8;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPort.Value = new decimal(new int[] {
            27017,
            0,
            0,
            0});
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(651, 26);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(98, 17);
            this.chkAuth.TabIndex = 16;
            this.chkAuth.Text = "启用认证模式";
            this.chkAuth.UseVisualStyleBackColor = true;
            this.chkAuth.CheckedChanged += new System.EventHandler(this.chkAuth_CheckedChanged);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(397, 26);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(58, 13);
            this.lblSource.TabIndex = 17;
            this.lblSource.Text = "Slave源头";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(482, 23);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(105, 20);
            this.txtSource.TabIndex = 18;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // ctlFilePickerDBPath
            // 
            this.ctlFilePickerDBPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerDBPath.FileFilter = "";
            this.ctlFilePickerDBPath.Location = new System.Drawing.Point(26, 52);
            this.ctlFilePickerDBPath.Name = "ctlFilePickerDBPath";
            this.ctlFilePickerDBPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.Directory;
            this.ctlFilePickerDBPath.SelectedPath = "";
            this.ctlFilePickerDBPath.Size = new System.Drawing.Size(739, 35);
            this.ctlFilePickerDBPath.TabIndex = 15;
            this.ctlFilePickerDBPath.Title = "数据库路径";
            // 
            // ctlFilePickerLogPath
            // 
            this.ctlFilePickerLogPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerLogPath.FileFilter = "";
            this.ctlFilePickerLogPath.Location = new System.Drawing.Point(26, 87);
            this.ctlFilePickerLogPath.Name = "ctlFilePickerLogPath";
            this.ctlFilePickerLogPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.SaveFile;
            this.ctlFilePickerLogPath.SelectedPath = "";
            this.ctlFilePickerLogPath.Size = new System.Drawing.Size(739, 37);
            this.ctlFilePickerLogPath.TabIndex = 14;
            this.ctlFilePickerLogPath.Title = "日志路径";
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(193, 26);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(58, 17);
            this.radNormal.TabIndex = 19;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            this.radNormal.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // radMaster
            // 
            this.radMaster.AutoSize = true;
            this.radMaster.Location = new System.Drawing.Point(257, 26);
            this.radMaster.Name = "radMaster";
            this.radMaster.Size = new System.Drawing.Size(57, 17);
            this.radMaster.TabIndex = 20;
            this.radMaster.Text = "Master";
            this.radMaster.UseVisualStyleBackColor = true;
            this.radMaster.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // radSlave
            // 
            this.radSlave.AutoSize = true;
            this.radSlave.Location = new System.Drawing.Point(320, 27);
            this.radSlave.Name = "radSlave";
            this.radSlave.Size = new System.Drawing.Size(52, 17);
            this.radSlave.TabIndex = 21;
            this.radSlave.Text = "Slave";
            this.radSlave.UseVisualStyleBackColor = true;
            this.radSlave.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // ctlMongod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.radSlave);
            this.Controls.Add(this.radMaster);
            this.Controls.Add(this.radNormal);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.chkAuth);
            this.Controls.Add(this.ctlFilePickerDBPath);
            this.Controls.Add(this.ctlFilePickerLogPath);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.grpLog);
            this.Name = "ctlMongod";
            this.Size = new System.Drawing.Size(800, 200);
            this.Load += new System.EventHandler(this.ctlMongod_Load);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.CheckBox chkIsAppend;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private Module.ctllogLv ctllogLvT;
        private ctlFilePicker ctlFilePickerLogPath;
        private ctlFilePicker ctlFilePickerDBPath;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.Label lblSource;
        private TextBox txtSource;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radMaster;
        private System.Windows.Forms.RadioButton radSlave;
    }
}
