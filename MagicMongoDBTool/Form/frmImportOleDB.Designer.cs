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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportOleDB));
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.ctlFilePickerDBName = new MagicMongoDBTool.ctlFilePicker();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Controls.Add(this.ctlFilePickerDBName);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(849, 109);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(607, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(78, 29);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ctlFilePickerDBName
            // 
            this.ctlFilePickerDBName.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerDBName.Location = new System.Drawing.Point(38, 27);
            this.ctlFilePickerDBName.Name = "ctlFilePickerDBName";
            this.ctlFilePickerDBName.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.OpenFile;
            this.ctlFilePickerDBName.SelectedPath = "";
            this.ctlFilePickerDBName.Size = new System.Drawing.Size(739, 33);
            this.ctlFilePickerDBName.TabIndex = 2;
            this.ctlFilePickerDBName.Title = "数据库文件";
            // 
            // frmImportOleDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 172);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportOleDB";
            this.ShowSelectSkinButton = false;
            this.Text = "frnImportOleDB";
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdOK;
        private ctlFilePicker ctlFilePickerDBName;
    }
}