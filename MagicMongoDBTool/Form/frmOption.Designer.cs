namespace MagicMongoDBTool
{
    partial class frmOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOption));
            this.numRefreshForStatus = new System.Windows.Forms.NumericUpDown();
            this.lblRefreshForStatus = new System.Windows.Forms.Label();
            this.numLimitCnt = new System.Windows.Forms.NumericUpDown();
            this.lblLimitCnt = new System.Windows.Forms.Label();
            this.ctlFilePickerMongoBinPath = new MagicMongoDBTool.ctlFilePicker();
            this.cmdCancel = new System.Windows.Forms.VistaButton();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.numRefreshForStatus);
            this.contentPanel.Controls.Add(this.lblRefreshForStatus);
            this.contentPanel.Controls.Add(this.numLimitCnt);
            this.contentPanel.Controls.Add(this.lblLimitCnt);
            this.contentPanel.Controls.Add(this.ctlFilePickerMongoBinPath);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(839, 148);
            // 
            // numRefreshForStatus
            // 
            this.numRefreshForStatus.Location = new System.Drawing.Point(481, 47);
            this.numRefreshForStatus.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numRefreshForStatus.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRefreshForStatus.Name = "numRefreshForStatus";
            this.numRefreshForStatus.Size = new System.Drawing.Size(66, 20);
            this.numRefreshForStatus.TabIndex = 16;
            this.numRefreshForStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRefreshForStatus.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblRefreshForStatus
            // 
            this.lblRefreshForStatus.AutoSize = true;
            this.lblRefreshForStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRefreshForStatus.Location = new System.Drawing.Point(298, 49);
            this.lblRefreshForStatus.Name = "lblRefreshForStatus";
            this.lblRefreshForStatus.Size = new System.Drawing.Size(156, 13);
            this.lblRefreshForStatus.TabIndex = 15;
            this.lblRefreshForStatus.Text = "服务器/数据库状态刷新间隔";
            // 
            // numLimitCnt
            // 
            this.numLimitCnt.Location = new System.Drawing.Point(131, 47);
            this.numLimitCnt.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numLimitCnt.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numLimitCnt.Name = "numLimitCnt";
            this.numLimitCnt.Size = new System.Drawing.Size(66, 20);
            this.numLimitCnt.TabIndex = 14;
            this.numLimitCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLimitCnt.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // lblLimitCnt
            // 
            this.lblLimitCnt.AutoSize = true;
            this.lblLimitCnt.BackColor = System.Drawing.Color.Transparent;
            this.lblLimitCnt.Location = new System.Drawing.Point(11, 49);
            this.lblLimitCnt.Name = "lblLimitCnt";
            this.lblLimitCnt.Size = new System.Drawing.Size(91, 13);
            this.lblLimitCnt.TabIndex = 13;
            this.lblLimitCnt.Text = "每页显示数据数";
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(11, 15);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.SelectedPath = "";
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(739, 31);
            this.ctlFilePickerMongoBinPath.TabIndex = 12;
            this.ctlFilePickerMongoBinPath.Title = "Mongodb的Bin路径";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(669, 82);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 30);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(578, 83);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 30);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "确认";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 211);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.ShowSelectSkinButton = false;
            this.Text = "frmOption";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRefreshForStatus;
        private System.Windows.Forms.Label lblRefreshForStatus;
        private System.Windows.Forms.NumericUpDown numLimitCnt;
        private System.Windows.Forms.Label lblLimitCnt;
        private ctlFilePicker ctlFilePickerMongoBinPath;
        private System.Windows.Forms.VistaButton cmdCancel;
        private System.Windows.Forms.VistaButton cmdOK;

    }
}