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
            this.trbLogLv = new System.Windows.Forms.TrackBar();
            this.lblLogLv = new System.Windows.Forms.Label();
            this.cmdLogPath = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.cmdClearLogPath = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblDBPath = new System.Windows.Forms.Label();
            this.txtDBPath = new System.Windows.Forms.TextBox();
            this.cmdDBPath = new System.Windows.Forms.Button();
            this.chkIsMaster = new System.Windows.Forms.CheckBox();
            this.chkIsSlave = new System.Windows.Forms.CheckBox();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogLv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.lblLogLv);
            this.grpLog.Controls.Add(this.trbLogLv);
            this.grpLog.Controls.Add(this.chkIsAppend);
            this.grpLog.Location = new System.Drawing.Point(19, 127);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(730, 70);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // chkIsAppend
            // 
            this.chkIsAppend.AutoSize = true;
            this.chkIsAppend.Location = new System.Drawing.Point(44, 19);
            this.chkIsAppend.Name = "chkIsAppend";
            this.chkIsAppend.Size = new System.Drawing.Size(206, 17);
            this.chkIsAppend.TabIndex = 0;
            this.chkIsAppend.Text = "追加模式（默认的日志是覆盖模式）";
            this.chkIsAppend.UseVisualStyleBackColor = true;
            this.chkIsAppend.CheckedChanged += new System.EventHandler(this.chkIsAppend_CheckedChanged);
            // 
            // trbLogLv
            // 
            this.trbLogLv.LargeChange = 1;
            this.trbLogLv.Location = new System.Drawing.Point(377, 20);
            this.trbLogLv.Name = "trbLogLv";
            this.trbLogLv.Size = new System.Drawing.Size(198, 45);
            this.trbLogLv.TabIndex = 1;
            this.trbLogLv.Scroll += new System.EventHandler(this.trbLogLv_Scroll);
            // 
            // lblLogLv
            // 
            this.lblLogLv.AutoSize = true;
            this.lblLogLv.Location = new System.Drawing.Point(271, 20);
            this.lblLogLv.Name = "lblLogLv";
            this.lblLogLv.Size = new System.Drawing.Size(85, 13);
            this.lblLogLv.TabIndex = 2;
            this.lblLogLv.Text = "日志等级：最少";
            // 
            // cmdLogPath
            // 
            this.cmdLogPath.Location = new System.Drawing.Point(590, 98);
            this.cmdLogPath.Name = "cmdLogPath";
            this.cmdLogPath.Size = new System.Drawing.Size(75, 23);
            this.cmdLogPath.TabIndex = 3;
            this.cmdLogPath.Text = "浏览...";
            this.cmdLogPath.UseVisualStyleBackColor = true;
            this.cmdLogPath.Click += new System.EventHandler(this.cmdLogPath_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(99, 98);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(485, 20);
            this.txtLogPath.TabIndex = 4;
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point(28, 101);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(55, 13);
            this.lblLogPath.TabIndex = 5;
            this.lblLogPath.Text = "日志路径";
            // 
            // cmdClearLogPath
            // 
            this.cmdClearLogPath.Location = new System.Drawing.Point(674, 98);
            this.cmdClearLogPath.Name = "cmdClearLogPath";
            this.cmdClearLogPath.Size = new System.Drawing.Size(75, 23);
            this.cmdClearLogPath.TabIndex = 6;
            this.cmdClearLogPath.Text = "清除";
            this.cmdClearLogPath.UseVisualStyleBackColor = true;
            this.cmdClearLogPath.Click += new System.EventHandler(this.cmdClearLogPath_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(32, 35);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(49, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "端口号：";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(97, 33);
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
            // 
            // lblDBPath
            // 
            this.lblDBPath.AutoSize = true;
            this.lblDBPath.Location = new System.Drawing.Point(28, 71);
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(67, 13);
            this.lblDBPath.TabIndex = 9;
            this.lblDBPath.Text = "数据库路径";
            // 
            // txtDBPath
            // 
            this.txtDBPath.Location = new System.Drawing.Point(101, 64);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.ReadOnly = true;
            this.txtDBPath.Size = new System.Drawing.Size(483, 20);
            this.txtDBPath.TabIndex = 10;
            // 
            // cmdDBPath
            // 
            this.cmdDBPath.Location = new System.Drawing.Point(590, 67);
            this.cmdDBPath.Name = "cmdDBPath";
            this.cmdDBPath.Size = new System.Drawing.Size(72, 21);
            this.cmdDBPath.TabIndex = 11;
            this.cmdDBPath.Text = "浏览";
            this.cmdDBPath.UseVisualStyleBackColor = true;
            this.cmdDBPath.Click += new System.EventHandler(this.cmdDBPath_Click);
            // 
            // chkIsMaster
            // 
            this.chkIsMaster.AutoSize = true;
            this.chkIsMaster.Location = new System.Drawing.Point(175, 36);
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
            this.chkIsSlave.Location = new System.Drawing.Point(275, 36);
            this.chkIsSlave.Name = "chkIsSlave";
            this.chkIsSlave.Size = new System.Drawing.Size(89, 17);
            this.chkIsSlave.TabIndex = 13;
            this.chkIsSlave.Text = "Slave数据库";
            this.chkIsSlave.UseVisualStyleBackColor = true;
            // 
            // ctlMongod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIsSlave);
            this.Controls.Add(this.chkIsMaster);
            this.Controls.Add(this.cmdDBPath);
            this.Controls.Add(this.txtDBPath);
            this.Controls.Add(this.lblDBPath);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cmdClearLogPath);
            this.Controls.Add(this.lblLogPath);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.cmdLogPath);
            this.Controls.Add(this.grpLog);
            this.Name = "ctlMongod";
            this.Size = new System.Drawing.Size(774, 211);
            this.Load += new System.EventHandler(this.ctlMongod_Load);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogLv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.CheckBox chkIsAppend;
        private System.Windows.Forms.TrackBar trbLogLv;
        private System.Windows.Forms.Label lblLogLv;
        private System.Windows.Forms.Button cmdLogPath;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.Button cmdClearLogPath;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblDBPath;
        private System.Windows.Forms.TextBox txtDBPath;
        private System.Windows.Forms.Button cmdDBPath;
        private System.Windows.Forms.CheckBox chkIsMaster;
        private System.Windows.Forms.CheckBox chkIsSlave;
    }
}
