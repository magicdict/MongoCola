namespace MagicMongoDBTool
{
    partial class frmExport
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
            this.btnSaveAsExcel = new System.Windows.Forms.Button();
            this.ctlExcelFilePicker = new MagicMongoDBTool.ctlFilePicker();
            this.SuspendLayout();
            // 
            // btnSaveAsExcel
            // 
            this.btnSaveAsExcel.Location = new System.Drawing.Point(581, 59);
            this.btnSaveAsExcel.Name = "btnSaveAsExcel";
            this.btnSaveAsExcel.Size = new System.Drawing.Size(91, 26);
            this.btnSaveAsExcel.TabIndex = 1;
            this.btnSaveAsExcel.Text = "Save As Excel";
            this.btnSaveAsExcel.UseVisualStyleBackColor = true;
            this.btnSaveAsExcel.Click += new System.EventHandler(this.btnSaveAsExcel_Click);
            // 
            // ctlExcelFilePicker
            // 
            this.ctlExcelFilePicker.BackColor = System.Drawing.Color.Transparent;
            this.ctlExcelFilePicker.FileFilter = "";
            this.ctlExcelFilePicker.Location = new System.Drawing.Point(12, 12);
            this.ctlExcelFilePicker.Name = "ctlExcelFilePicker";
            this.ctlExcelFilePicker.PickerType = MagicMongoDBTool.ctlFilePicker.DialogType.SaveFile;
            this.ctlExcelFilePicker.SelectedPathOrFileName = "";
            this.ctlExcelFilePicker.Size = new System.Drawing.Size(739, 33);
            this.ctlExcelFilePicker.TabIndex = 0;
            this.ctlExcelFilePicker.Title = "Excel FileName";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 97);
            this.Controls.Add(this.btnSaveAsExcel);
            this.Controls.Add(this.ctlExcelFilePicker);
            this.Name = "frmExport";
            this.Text = "frmExport";
            this.ResumeLayout(false);

        }

        #endregion

        private ctlFilePicker ctlExcelFilePicker;
        private System.Windows.Forms.Button btnSaveAsExcel;
    }
}