using Common;
namespace MongoCola
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
            this.btnSave = new System.Windows.Forms.Button();
            this.grpExportType = new System.Windows.Forms.GroupBox();
            this.optXML = new System.Windows.Forms.RadioButton();
            this.optText = new System.Windows.Forms.RadioButton();
            this.optExcel = new System.Windows.Forms.RadioButton();
            this.ctlExportFilePicker = new ctlFilePicker();
            this.grpExportType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(585, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpExportType
            // 
            this.grpExportType.Controls.Add(this.optXML);
            this.grpExportType.Controls.Add(this.optText);
            this.grpExportType.Controls.Add(this.optExcel);
            this.grpExportType.Location = new System.Drawing.Point(12, 61);
            this.grpExportType.Name = "grpExportType";
            this.grpExportType.Size = new System.Drawing.Size(258, 65);
            this.grpExportType.TabIndex = 2;
            this.grpExportType.TabStop = false;
            this.grpExportType.Text = "Export File Type";
            // 
            // optXML
            // 
            this.optXML.AutoSize = true;
            this.optXML.Enabled = false;
            this.optXML.Location = new System.Drawing.Point(188, 30);
            this.optXML.Name = "optXML";
            this.optXML.Size = new System.Drawing.Size(47, 17);
            this.optXML.TabIndex = 3;
            this.optXML.TabStop = true;
            this.optXML.Text = "XML";
            this.optXML.UseVisualStyleBackColor = true;
            // 
            // optText
            // 
            this.optText.AutoSize = true;
            this.optText.Location = new System.Drawing.Point(96, 30);
            this.optText.Name = "optText";
            this.optText.Size = new System.Drawing.Size(86, 17);
            this.optText.TabIndex = 3;
            this.optText.TabStop = true;
            this.optText.Text = "Text（JSON）";
            this.optText.UseVisualStyleBackColor = true;
            // 
            // optExcel
            // 
            this.optExcel.AutoSize = true;
            this.optExcel.Checked = true;
            this.optExcel.Location = new System.Drawing.Point(24, 30);
            this.optExcel.Name = "optExcel";
            this.optExcel.Size = new System.Drawing.Size(51, 17);
            this.optExcel.TabIndex = 3;
            this.optExcel.TabStop = true;
            this.optExcel.Text = "Excel";
            this.optExcel.UseVisualStyleBackColor = true;
            // 
            // ctlExportFilePicker
            // 
            this.ctlExportFilePicker.BackColor = System.Drawing.Color.Transparent;
            this.ctlExportFilePicker.FileFilter = "";
            this.ctlExportFilePicker.FileName = "";
            this.ctlExportFilePicker.Location = new System.Drawing.Point(12, 22);
            this.ctlExportFilePicker.Name = "ctlExportFilePicker";
            this.ctlExportFilePicker.PickerType = ctlFilePicker.DialogType.SaveFile;
            this.ctlExportFilePicker.SelectedPathOrFileName = "";
            this.ctlExportFilePicker.Size = new System.Drawing.Size(739, 33);
            this.ctlExportFilePicker.TabIndex = 0;
            this.ctlExportFilePicker.Title = "FileName";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 159);
            this.Controls.Add(this.grpExportType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctlExportFilePicker);
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To File";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.grpExportType.ResumeLayout(false);
            this.grpExportType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctlFilePicker ctlExportFilePicker;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpExportType;
        private System.Windows.Forms.RadioButton optXML;
        private System.Windows.Forms.RadioButton optText;
        private System.Windows.Forms.RadioButton optExcel;
    }
}