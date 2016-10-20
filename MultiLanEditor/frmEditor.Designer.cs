namespace MultiLanEditor
{
    partial class FrmEditor
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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lstMultiLan = new System.Windows.Forms.ListView();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.ctlMultiLanFolder = new ResourceLib.UI.CtlFilePicker();
            this.lblUUID = new System.Windows.Forms.Label();
            this.txtTranslation = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(500, 71);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(87, 32);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(593, 71);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 32);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // lstMultiLan
            // 
            this.lstMultiLan.FullRowSelect = true;
            this.lstMultiLan.GridLines = true;
            this.lstMultiLan.Location = new System.Drawing.Point(35, 126);
            this.lstMultiLan.MultiSelect = false;
            this.lstMultiLan.Name = "lstMultiLan";
            this.lstMultiLan.Size = new System.Drawing.Size(648, 309);
            this.lstMultiLan.TabIndex = 3;
            this.lstMultiLan.UseCompatibleStateImageBehavior = false;
            this.lstMultiLan.View = System.Windows.Forms.View.Details;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(35, 83);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 20);
            this.cmbLanguage.TabIndex = 4;
            // 
            // ctlMultiLanFolder
            // 
            this.ctlMultiLanFolder.AutoSize = true;
            this.ctlMultiLanFolder.BackColor = System.Drawing.Color.Transparent;
            this.ctlMultiLanFolder.Browse = "Browse...";
            this.ctlMultiLanFolder.Clear = "Clear";
            this.ctlMultiLanFolder.FileFilter = "";
            this.ctlMultiLanFolder.InitFileName = "";
            this.ctlMultiLanFolder.Location = new System.Drawing.Point(35, 12);
            this.ctlMultiLanFolder.Name = "ctlMultiLanFolder";
            this.ctlMultiLanFolder.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.ctlMultiLanFolder.SelectedPathOrFileName = "";
            this.ctlMultiLanFolder.Size = new System.Drawing.Size(648, 38);
            this.ctlMultiLanFolder.TabIndex = 0;
            this.ctlMultiLanFolder.Title = "多语言文件目录";
            // 
            // lblUUID
            // 
            this.lblUUID.AutoSize = true;
            this.lblUUID.Location = new System.Drawing.Point(33, 468);
            this.lblUUID.Name = "lblUUID";
            this.lblUUID.Size = new System.Drawing.Size(29, 12);
            this.lblUUID.TabIndex = 5;
            this.lblUUID.Text = "UUID";
            // 
            // txtTranslation
            // 
            this.txtTranslation.Location = new System.Drawing.Point(35, 496);
            this.txtTranslation.Name = "txtTranslation";
            this.txtTranslation.Size = new System.Drawing.Size(266, 21);
            this.txtTranslation.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(328, 495);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 541);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTranslation);
            this.Controls.Add(this.lblUUID);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lstMultiLan);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ctlMultiLanFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditor";
            this.Text = "多语言编辑器";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ResourceLib.UI.CtlFilePicker ctlMultiLanFolder;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListView lstMultiLan;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblUUID;
        private System.Windows.Forms.TextBox txtTranslation;
        private System.Windows.Forms.Button btnOK;
    }
}

