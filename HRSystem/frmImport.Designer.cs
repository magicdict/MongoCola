namespace HRSystem
{
    partial class frmImport
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
            this.ExcelPicker = new HRSystem.ctlFilePicker();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImport.Location = new System.Drawing.Point(468, 48);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ExcelPicker
            // 
            this.ExcelPicker.BackColor = System.Drawing.Color.Transparent;
            this.ExcelPicker.FileFilter = "(*.xls)|*.xls";
            this.ExcelPicker.FileName = "";
            this.ExcelPicker.Location = new System.Drawing.Point(11, 11);
            this.ExcelPicker.Name = "ExcelPicker";
            this.ExcelPicker.PickerType = HRSystem.ctlFilePicker.DialogType.OpenFile;
            this.ExcelPicker.SelectedPathOrFileName = "";
            this.ExcelPicker.Size = new System.Drawing.Size(546, 31);
            this.ExcelPicker.TabIndex = 0;
            this.ExcelPicker.Title = "Candidate Excel File";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 83);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ExcelPicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private ctlFilePicker ExcelPicker;
        private System.Windows.Forms.Button btnImport;
    }
}