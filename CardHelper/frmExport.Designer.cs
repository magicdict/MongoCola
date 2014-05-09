namespace CardHelper
{
    partial class frmExport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ExcelPicker = new GUI.ctlFilePicker();
            this.btnExportMongoDB = new System.Windows.Forms.Button();
            this.btnExportXml = new System.Windows.Forms.Button();
            this.XmlFolderPicker = new GUI.ctlFilePicker();
            this.btnImportXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExcelPicker
            // 
            this.ExcelPicker.BackColor = System.Drawing.Color.Transparent;
            this.ExcelPicker.FileFilter = "";
            this.ExcelPicker.FileName = "";
            this.ExcelPicker.Location = new System.Drawing.Point(28, 12);
            this.ExcelPicker.Name = "ExcelPicker";
            this.ExcelPicker.PickerType = GUI.ctlFilePicker.DialogType.OpenFile;
            this.ExcelPicker.SelectedPathOrFileName = "";
            this.ExcelPicker.Size = new System.Drawing.Size(629, 31);
            this.ExcelPicker.TabIndex = 0;
            this.ExcelPicker.Title = "炉石资料文件";
            // 
            // btnExportMongoDB
            // 
            this.btnExportMongoDB.Location = new System.Drawing.Point(488, 49);
            this.btnExportMongoDB.Name = "btnExportMongoDB";
            this.btnExportMongoDB.Size = new System.Drawing.Size(157, 23);
            this.btnExportMongoDB.TabIndex = 1;
            this.btnExportMongoDB.Text = "导出到MongoDB";
            this.btnExportMongoDB.UseVisualStyleBackColor = true;
            this.btnExportMongoDB.Click += new System.EventHandler(this.btnExportMongoDB_Click);
            // 
            // btnExportXml
            // 
            this.btnExportXml.Location = new System.Drawing.Point(488, 115);
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Size = new System.Drawing.Size(157, 23);
            this.btnExportXml.TabIndex = 2;
            this.btnExportXml.Text = "导出到Xml";
            this.btnExportXml.UseVisualStyleBackColor = true;
            this.btnExportXml.Click += new System.EventHandler(this.btnExportXml_Click);
            // 
            // XmlFolderPicker
            // 
            this.XmlFolderPicker.BackColor = System.Drawing.Color.Transparent;
            this.XmlFolderPicker.FileFilter = "";
            this.XmlFolderPicker.FileName = "";
            this.XmlFolderPicker.Location = new System.Drawing.Point(28, 78);
            this.XmlFolderPicker.Name = "XmlFolderPicker";
            this.XmlFolderPicker.PickerType = GUI.ctlFilePicker.DialogType.Directory;
            this.XmlFolderPicker.SelectedPathOrFileName = "";
            this.XmlFolderPicker.Size = new System.Drawing.Size(629, 31);
            this.XmlFolderPicker.TabIndex = 3;
            this.XmlFolderPicker.Title = "XML文件夹";
            // 
            // btnImportXML
            // 
            this.btnImportXML.Location = new System.Drawing.Point(280, 115);
            this.btnImportXML.Name = "btnImportXML";
            this.btnImportXML.Size = new System.Drawing.Size(157, 23);
            this.btnImportXML.TabIndex = 4;
            this.btnImportXML.Text = "导入XML";
            this.btnImportXML.UseVisualStyleBackColor = true;
            this.btnImportXML.Click += new System.EventHandler(this.btnImportXML_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 179);
            this.Controls.Add(this.btnImportXML);
            this.Controls.Add(this.XmlFolderPicker);
            this.Controls.Add(this.btnExportXml);
            this.Controls.Add(this.btnExportMongoDB);
            this.Controls.Add(this.ExcelPicker);
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资料导入导出";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.ctlFilePicker ExcelPicker;
        private System.Windows.Forms.Button btnExportMongoDB;
        private System.Windows.Forms.Button btnExportXml;
        private GUI.ctlFilePicker XmlFolderPicker;
        private System.Windows.Forms.Button btnImportXML;
    }
}

