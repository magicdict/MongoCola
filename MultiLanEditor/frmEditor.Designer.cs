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
            this.ctlMultiLanFolder = new ResourceLib.UI.CtlFilePicker();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(35, 71);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(74, 22);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(127, 71);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(77, 22);
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
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 460);
            this.Controls.Add(this.lstMultiLan);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ctlMultiLanFolder);
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
    }
}

