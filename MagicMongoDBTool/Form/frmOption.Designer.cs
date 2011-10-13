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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ctlFilePickerMongoBinPath = new MagicMongoDBTool.ctlFilePicker();
            this.lblLimitCnt = new System.Windows.Forms.Label();
            this.numLimitCnt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(530, 224);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "确认";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(627, 224);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(12, 12);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.SelectedPath = "";
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(739, 27);
            this.ctlFilePickerMongoBinPath.TabIndex = 5;
            this.ctlFilePickerMongoBinPath.Title = "Mongodb的Bin路径";
            // 
            // lblLimitCnt
            // 
            this.lblLimitCnt.AutoSize = true;
            this.lblLimitCnt.Location = new System.Drawing.Point(12, 42);
            this.lblLimitCnt.Name = "lblLimitCnt";
            this.lblLimitCnt.Size = new System.Drawing.Size(91, 13);
            this.lblLimitCnt.TabIndex = 6;
            this.lblLimitCnt.Text = "每页显示数据数";
            // 
            // numLimitCnt
            // 
            this.numLimitCnt.Location = new System.Drawing.Point(131, 40);
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
            this.numLimitCnt.Size = new System.Drawing.Size(74, 20);
            this.numLimitCnt.TabIndex = 7;
            this.numLimitCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLimitCnt.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 273);
            this.Controls.Add(this.numLimitCnt);
            this.Controls.Add(this.lblLimitCnt);
            this.Controls.Add(this.ctlFilePickerMongoBinPath);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmOption";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLimitCnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private ctlFilePicker ctlFilePickerMongoBinPath;
        private System.Windows.Forms.Label lblLimitCnt;
        private System.Windows.Forms.NumericUpDown numLimitCnt;
    }
}