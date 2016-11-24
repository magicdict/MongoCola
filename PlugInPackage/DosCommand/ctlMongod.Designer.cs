using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace PlugInPackage.DosCommand
{
    partial class CtlMongod
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.chkSmallfiles = new System.Windows.Forms.CheckBox();
            this.ctllogLvT = new PlugInPackage.DosCommand.CtllogLv();
            this.chkIsAppend = new System.Windows.Forms.CheckBox();
            this.ctlFilePickerLogPath = new ResourceLib.UI.CtlFilePicker();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radMaster = new System.Windows.Forms.RadioButton();
            this.radSlave = new System.Windows.Forms.RadioButton();
            this.lblWarning = new System.Windows.Forms.Label();
            this.ctlFilePickerDBPath = new ResourceLib.UI.CtlFilePicker();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.chkSmallfiles);
            this.grpLog.Controls.Add(this.ctllogLvT);
            this.grpLog.Controls.Add(this.chkIsAppend);
            this.grpLog.Controls.Add(this.ctlFilePickerLogPath);
            this.grpLog.Location = new System.Drawing.Point(22, 98);
            this.grpLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLog.Size = new System.Drawing.Size(882, 125);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log";
            // 
            // chkSmallfiles
            // 
            this.chkSmallfiles.AutoSize = true;
            this.chkSmallfiles.Location = new System.Drawing.Point(190, 81);
            this.chkSmallfiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSmallfiles.Name = "chkSmallfiles";
            this.chkSmallfiles.Size = new System.Drawing.Size(81, 21);
            this.chkSmallfiles.TabIndex = 23;
            this.chkSmallfiles.Text = "Smallfiles";
            this.chkSmallfiles.UseVisualStyleBackColor = true;
            // 
            // ctllogLvT
            // 
            this.ctllogLvT.BackColor = System.Drawing.Color.Transparent;
            this.ctllogLvT.Location = new System.Drawing.Point(301, 78);
            this.ctllogLvT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctllogLvT.Name = "ctllogLvT";
            this.ctllogLvT.Size = new System.Drawing.Size(232, 25);
            this.ctllogLvT.TabIndex = 14;
            // 
            // chkIsAppend
            // 
            this.chkIsAppend.AutoSize = true;
            this.chkIsAppend.Location = new System.Drawing.Point(75, 81);
            this.chkIsAppend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIsAppend.Name = "chkIsAppend";
            this.chkIsAppend.Size = new System.Drawing.Size(112, 21);
            this.chkIsAppend.TabIndex = 0;
            this.chkIsAppend.Text = "Append Mode";
            this.chkIsAppend.UseVisualStyleBackColor = true;
            this.chkIsAppend.CheckedChanged += new System.EventHandler(this.chkIsAppend_CheckedChanged);
            // 
            // ctlFilePickerLogPath
            // 
            this.ctlFilePickerLogPath.AutoSize = true;
            this.ctlFilePickerLogPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerLogPath.Browse = "Browse...";
            this.ctlFilePickerLogPath.Clear = "Clear";
            this.ctlFilePickerLogPath.FileFilter = "";
            this.ctlFilePickerLogPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlFilePickerLogPath.InitFileName = "";
            this.ctlFilePickerLogPath.Location = new System.Drawing.Point(8, 23);
            this.ctlFilePickerLogPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ctlFilePickerLogPath.Name = "ctlFilePickerLogPath";
            this.ctlFilePickerLogPath.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            this.ctlFilePickerLogPath.SelectedPathOrFileName = "";
            this.ctlFilePickerLogPath.Size = new System.Drawing.Size(862, 54);
            this.ctlFilePickerLogPath.TabIndex = 14;
            this.ctlFilePickerLogPath.Title = "LogPath";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(42, 21);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(44, 17);
            this.lblPort.TabIndex = 7;
            this.lblPort.Tag = "Common.Port";
            this.lblPort.Text = "Port：";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(97, 17);
            this.numPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.numPort.Size = new System.Drawing.Size(78, 23);
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
            this.chkAuth.Location = new System.Drawing.Point(692, 20);
            this.chkAuth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(92, 21);
            this.chkAuth.TabIndex = 16;
            this.chkAuth.Text = "Auth Mode";
            this.chkAuth.UseVisualStyleBackColor = true;
            this.chkAuth.CheckedChanged += new System.EventHandler(this.chkAuth_CheckedChanged);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(465, 20);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(94, 17);
            this.lblSource.TabIndex = 17;
            this.lblSource.Tag = "DosCommand.TabDeploySlaveSource";
            this.lblSource.Text = "Slave Source：";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(562, 17);
            this.txtSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(122, 23);
            this.txtSource.TabIndex = 18;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(190, 17);
            this.radNormal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(70, 21);
            this.radNormal.TabIndex = 19;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal";
            this.radNormal.UseVisualStyleBackColor = true;
            this.radNormal.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // radMaster
            // 
            this.radMaster.AutoSize = true;
            this.radMaster.Location = new System.Drawing.Point(266, 17);
            this.radMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radMaster.Name = "radMaster";
            this.radMaster.Size = new System.Drawing.Size(67, 21);
            this.radMaster.TabIndex = 20;
            this.radMaster.Text = "Master";
            this.radMaster.UseVisualStyleBackColor = true;
            this.radMaster.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // radSlave
            // 
            this.radSlave.AutoSize = true;
            this.radSlave.Location = new System.Drawing.Point(356, 17);
            this.radSlave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSlave.Name = "radSlave";
            this.radSlave.Size = new System.Drawing.Size(56, 21);
            this.radSlave.TabIndex = 21;
            this.radSlave.Text = "Slave";
            this.radSlave.UseVisualStyleBackColor = true;
            this.radSlave.CheckedChanged += new System.EventHandler(this.MongodType_CheckedChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(19, 227);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(873, 42);
            this.lblWarning.TabIndex = 22;
            this.lblWarning.Text = "Deprecated since version 1.6: Replica sets replace master-slave replication. Use " +
    "replica sets rather than master-slave replication for all new production deploym" +
    "ents.";
            // 
            // ctlFilePickerDBPath
            // 
            this.ctlFilePickerDBPath.AutoSize = true;
            this.ctlFilePickerDBPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerDBPath.Browse = "Browse...";
            this.ctlFilePickerDBPath.Clear = "Clear";
            this.ctlFilePickerDBPath.FileFilter = "";
            this.ctlFilePickerDBPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlFilePickerDBPath.InitFileName = "";
            this.ctlFilePickerDBPath.Location = new System.Drawing.Point(23, 42);
            this.ctlFilePickerDBPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ctlFilePickerDBPath.Name = "ctlFilePickerDBPath";
            this.ctlFilePickerDBPath.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.ctlFilePickerDBPath.SelectedPathOrFileName = "";
            this.ctlFilePickerDBPath.Size = new System.Drawing.Size(862, 54);
            this.ctlFilePickerDBPath.TabIndex = 15;
            this.ctlFilePickerDBPath.Title = "DataBase Path";
            // 
            // CtlMongod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.radSlave);
            this.Controls.Add(this.radMaster);
            this.Controls.Add(this.radNormal);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.chkAuth);
            this.Controls.Add(this.ctlFilePickerDBPath);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.grpLog);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CtlMongod";
            this.Size = new System.Drawing.Size(895, 273);
            this.Load += new System.EventHandler(this.ctlMongod_Load);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private GroupBox grpLog;
        private CheckBox chkIsAppend;
        private Label lblPort;
        private NumericUpDown numPort;
        private CtllogLv ctllogLvT;
        private CtlFilePicker ctlFilePickerLogPath;
        private CtlFilePicker ctlFilePickerDBPath;
        private CheckBox chkAuth;
        private Label lblSource;
        private TextBox txtSource;
        private RadioButton radNormal;
        private RadioButton radMaster;
        private RadioButton radSlave;
        private Label lblWarning;
        private CheckBox chkSmallfiles;
    }
}
