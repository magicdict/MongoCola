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
            this.chkIsAppend = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.chkIsMaster = new System.Windows.Forms.CheckBox();
            this.chkIsSlave = new System.Windows.Forms.CheckBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtSource = new QLFUI.TextBoxEx();
            this.ctlFilePickerDBPath = new MagicMongoDBTool.ctlFilePicker();
            this.ctlFilePickerLogPath = new MagicMongoDBTool.ctlFilePicker();
            this.ctllogLvT = new MagicMongoDBTool.Module.ctllogLv();
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
            // chkIsMaster
            // 
            this.chkIsMaster.AutoSize = true;
            this.chkIsMaster.Location = new System.Drawing.Point(175, 31);
            this.chkIsMaster.Name = "chkIsMaster";
            this.chkIsMaster.Size = new System.Drawing.Size(94, 17);
            this.chkIsMaster.TabIndex = 12;
            this.chkIsMaster.Text = "Master数据库";
            this.chkIsMaster.UseVisualStyleBackColor = true;
            this.chkIsMaster.CheckedChanged += new System.EventHandler(this.chkIsMaster_CheckedChanged);
            // 
            // chkIsSlave
            // 
            this.chkIsSlave.AutoSize = true;
            this.chkIsSlave.Location = new System.Drawing.Point(275, 31);
            this.chkIsSlave.Name = "chkIsSlave";
            this.chkIsSlave.Size = new System.Drawing.Size(89, 17);
            this.chkIsSlave.TabIndex = 13;
            this.chkIsSlave.Text = "Slave数据库";
            this.chkIsSlave.UseVisualStyleBackColor = true;
            this.chkIsSlave.CheckedChanged += new System.EventHandler(this.chkIsSlave_CheckedChanged);
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(547, 28);
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
            this.lblSource.Location = new System.Drawing.Point(370, 31);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(58, 13);
            this.lblSource.TabIndex = 17;
            this.lblSource.Text = "Slave源头";
            // 
            // txtSource
            // 
            //this.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            //this.txtSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSource.BackColor = System.Drawing.Color.Transparent;
            this.txtSource.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtSource.ForeImage = null;
            this.txtSource.Location = new System.Drawing.Point(434, 22);
            this.txtSource.Multiline = false;
            this.txtSource.Name = "txtSource";
            this.txtSource.Radius = 3;
            this.txtSource.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtSource.Size = new System.Drawing.Size(105, 29);
            this.txtSource.TabIndex = 18;
            this.txtSource.UseSystemPasswordChar = false;
            this.txtSource.WaterMark = "Master地址";
            this.txtSource.WaterMarkColor = System.Drawing.Color.Silver;
            this.txtSource.TextChanged += new QLFUI.TextBoxEx.TextChangedHandler(this.txtSource_TextChanged);
            // 
            // ctlFilePickerDBPath
            // 
            this.ctlFilePickerDBPath.BackColor = System.Drawing.Color.Transparent;
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
            this.ctlFilePickerLogPath.Location = new System.Drawing.Point(26, 87);
            this.ctlFilePickerLogPath.Name = "ctlFilePickerLogPath";
            this.ctlFilePickerLogPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.SaveFile;
            this.ctlFilePickerLogPath.SelectedPath = "";
            this.ctlFilePickerLogPath.Size = new System.Drawing.Size(739, 37);
            this.ctlFilePickerLogPath.TabIndex = 14;
            this.ctlFilePickerLogPath.Title = "日志路径";
            // 
            // ctllogLvT
            // 
            this.ctllogLvT.Location = new System.Drawing.Point(256, 13);
            this.ctllogLvT.Name = "ctllogLvT";
            this.ctllogLvT.Size = new System.Drawing.Size(312, 51);
            this.ctllogLvT.TabIndex = 14;
            // 
            // ctlMongod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.chkAuth);
            this.Controls.Add(this.ctlFilePickerDBPath);
            this.Controls.Add(this.ctlFilePickerLogPath);
            this.Controls.Add(this.chkIsSlave);
            this.Controls.Add(this.chkIsMaster);
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
        private System.Windows.Forms.CheckBox chkIsMaster;
        private System.Windows.Forms.CheckBox chkIsSlave;
        private Module.ctllogLv ctllogLvT;
        private ctlFilePicker ctlFilePickerLogPath;
        private ctlFilePicker ctlFilePickerDBPath;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.Label lblSource;
        private QLFUI.TextBoxEx txtSource;
    }
}
