namespace MagicMongoDBTool
{
    partial class frmImportOleDB
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
            this.ctlFilePickerDBName = new MagicMongoDBTool.ctlFilePicker();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlFilePickerDBName
            // 
            this.ctlFilePickerDBName.Location = new System.Drawing.Point(38, 24);
            this.ctlFilePickerDBName.Name = "ctlFilePickerDBName";
            this.ctlFilePickerDBName.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.OpenFile;
            this.ctlFilePickerDBName.Size = new System.Drawing.Size(739, 27);
            this.ctlFilePickerDBName.TabIndex = 0;
            this.ctlFilePickerDBName.Title = "数据库文件";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(601, 57);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(84, 25);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "确定";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmImportOleDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 94);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.ctlFilePickerDBName);
            this.Name = "frmImportOleDB";
            this.Text = "ImportOleDB";
            this.ResumeLayout(false);

        }

        #endregion

        private ctlFilePicker ctlFilePickerDBName;
        private System.Windows.Forms.Button cmdOK;
    }
}