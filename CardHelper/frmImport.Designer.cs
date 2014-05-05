namespace CardHelper
{
    partial class frmImport
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
            this.btnImport = new System.Windows.Forms.Button();
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(570, 49);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 82);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.ExcelPicker);
            this.Name = "frmImport";
            this.Text = "资料导入";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.ctlFilePicker ExcelPicker;
        private System.Windows.Forms.Button btnImport;
    }
}

