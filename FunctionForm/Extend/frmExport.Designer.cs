using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace FunctionForm.Extend
{
    partial class FrmExport
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
            this.ctlExportFilePicker = new ResourceLib.UI.CtlFilePicker();
            this.grpExportType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Tag = "Common.Save";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpExportType
            // 
            this.grpExportType.Controls.Add(this.optXML);
            this.grpExportType.Controls.Add(this.optText);
            this.grpExportType.Controls.Add(this.optExcel);
            this.grpExportType.Location = new System.Drawing.Point(12, 56);
            this.grpExportType.Name = "grpExportType";
            this.grpExportType.Size = new System.Drawing.Size(275, 60);
            this.grpExportType.TabIndex = 2;
            this.grpExportType.TabStop = false;
            this.grpExportType.Text = "ExportImport File Type";
            // 
            // optXML
            // 
            this.optXML.AutoSize = true;
            this.optXML.Enabled = false;
            this.optXML.Location = new System.Drawing.Point(188, 28);
            this.optXML.Name = "optXML";
            this.optXML.Size = new System.Drawing.Size(41, 16);
            this.optXML.TabIndex = 3;
            this.optXML.TabStop = true;
            this.optXML.Text = "XML";
            this.optXML.UseVisualStyleBackColor = true;
            // 
            // optText
            // 
            this.optText.AutoSize = true;
            this.optText.Location = new System.Drawing.Point(96, 28);
            this.optText.Name = "optText";
            this.optText.Size = new System.Drawing.Size(95, 16);
            this.optText.TabIndex = 3;
            this.optText.TabStop = true;
            this.optText.Text = "Text（JSON）";
            this.optText.UseVisualStyleBackColor = true;
            // 
            // optExcel
            // 
            this.optExcel.AutoSize = true;
            this.optExcel.Checked = true;
            this.optExcel.Location = new System.Drawing.Point(24, 28);
            this.optExcel.Name = "optExcel";
            this.optExcel.Size = new System.Drawing.Size(53, 16);
            this.optExcel.TabIndex = 3;
            this.optExcel.TabStop = true;
            this.optExcel.Text = "Excel";
            this.optExcel.UseVisualStyleBackColor = true;
            // 
            // ctlExportFilePicker
            // 
            this.ctlExportFilePicker.AutoSize = true;
            this.ctlExportFilePicker.BackColor = System.Drawing.Color.Transparent;
            this.ctlExportFilePicker.Browse = "Browse...";
            this.ctlExportFilePicker.Clear = "Clear";
            this.ctlExportFilePicker.FileFilter = "";
            this.ctlExportFilePicker.InitFileName = "";
            this.ctlExportFilePicker.Location = new System.Drawing.Point(12, 8);
            this.ctlExportFilePicker.Name = "ctlExportFilePicker";
            this.ctlExportFilePicker.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            this.ctlExportFilePicker.SelectedPathOrFileName = "";
            this.ctlExportFilePicker.Size = new System.Drawing.Size(596, 38);
            this.ctlExportFilePicker.TabIndex = 0;
            this.ctlExportFilePicker.Title = "FileName";
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 147);
            this.Controls.Add(this.grpExportType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctlExportFilePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Main_Menu_Operation_DataCollection_ExportToFile";
            this.Text = "ExportImport To File";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.grpExportType.ResumeLayout(false);
            this.grpExportType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlFilePicker ctlExportFilePicker;
        private Button btnSave;
        private GroupBox grpExportType;
        private RadioButton optXML;
        private RadioButton optText;
        private RadioButton optExcel;
    }
}