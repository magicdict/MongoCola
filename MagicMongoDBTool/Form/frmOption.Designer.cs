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
            this.numRefreshForStatus = new System.Windows.Forms.NumericUpDown();
            this.lblRefreshIntervalForStatus = new System.Windows.Forms.Label();
            this.numLimitCnt = new System.Windows.Forms.NumericUpDown();
            this.lblLimitCnt = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.ctlFilePickerMongoBinPath = new MagicMongoDBTool.ctlFilePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // numRefreshForStatus
            // 
            this.numRefreshForStatus.Location = new System.Drawing.Point(154, 104);
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
            this.numRefreshForStatus.Size = new System.Drawing.Size(77, 21);
            this.numRefreshForStatus.TabIndex = 2;
            this.numRefreshForStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRefreshForStatus.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblRefreshIntervalForStatus
            // 
            this.lblRefreshIntervalForStatus.AutoSize = true;
            this.lblRefreshIntervalForStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRefreshIntervalForStatus.Location = new System.Drawing.Point(14, 108);
            this.lblRefreshIntervalForStatus.Name = "lblRefreshIntervalForStatus";
            this.lblRefreshIntervalForStatus.Size = new System.Drawing.Size(123, 15);
            this.lblRefreshIntervalForStatus.TabIndex = 15;
            this.lblRefreshIntervalForStatus.Text = "Refresh Interval（sec）";
            // 
            // numLimitCnt
            // 
            this.numLimitCnt.Location = new System.Drawing.Point(154, 66);
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
            this.numLimitCnt.Size = new System.Drawing.Size(77, 21);
            this.numLimitCnt.TabIndex = 1;
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
            this.lblLimitCnt.Location = new System.Drawing.Point(13, 70);
            this.lblLimitCnt.Name = "lblLimitCnt";
            this.lblLimitCnt.Size = new System.Drawing.Size(104, 15);
            this.lblLimitCnt.TabIndex = 13;
            this.lblLimitCnt.Text = "Records PerPage";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(343, 151);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 35);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(182, 151);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 35);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Location = new System.Drawing.Point(273, 70);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(63, 15);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Text = "Language";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(343, 66);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(140, 23);
            this.cmbLanguage.TabIndex = 3;
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerMongoBinPath.FileFilter = "";
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(13, 17);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickerType = MagicMongoDBTool.ctlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.SelectedPath = "";
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(659, 36);
            this.ctlFilePickerMongoBinPath.TabIndex = 0;
            this.ctlFilePickerMongoBinPath.Title = "Exectable Path ";
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 203);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.numRefreshForStatus);
            this.Controls.Add(this.lblRefreshIntervalForStatus);
            this.Controls.Add(this.numLimitCnt);
            this.Controls.Add(this.lblLimitCnt);
            this.Controls.Add(this.ctlFilePickerMongoBinPath);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRefreshForStatus;
        private System.Windows.Forms.Label lblRefreshIntervalForStatus;
        private System.Windows.Forms.NumericUpDown numLimitCnt;
        private System.Windows.Forms.Label lblLimitCnt;
        private ctlFilePicker ctlFilePickerMongoBinPath;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;

    }
}