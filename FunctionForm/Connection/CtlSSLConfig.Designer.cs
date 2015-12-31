namespace FunctionForm.Connection
{
    partial class CtlSslConfig
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkUseSsl = new System.Windows.Forms.CheckBox();
            this.fileSslCertificateFile = new ResourceLib.UI.CtlFilePicker();
            this.SuspendLayout();
            // 
            // chkUseSsl
            // 
            this.chkUseSsl.AutoSize = true;
            this.chkUseSsl.Location = new System.Drawing.Point(15, 13);
            this.chkUseSsl.Name = "chkUseSsl";
            this.chkUseSsl.Size = new System.Drawing.Size(120, 16);
            this.chkUseSsl.TabIndex = 0;
            this.chkUseSsl.Text = "Use SSL protocol";
            this.chkUseSsl.UseVisualStyleBackColor = true;
            // 
            // fileSslCertificateFile
            // 
            this.fileSslCertificateFile.AutoSize = true;
            this.fileSslCertificateFile.BackColor = System.Drawing.Color.Transparent;
            this.fileSslCertificateFile.FileFilter = "SSL Certificate File|*.pem";
            this.fileSslCertificateFile.InitFileName = "";
            this.fileSslCertificateFile.Location = new System.Drawing.Point(15, 47);
            this.fileSslCertificateFile.Name = "fileSslCertificateFile";
            this.fileSslCertificateFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.OpenFile;
            this.fileSslCertificateFile.SelectedPathOrFileName = "";
            this.fileSslCertificateFile.Size = new System.Drawing.Size(552, 38);
            this.fileSslCertificateFile.TabIndex = 1;
            this.fileSslCertificateFile.Title = "SSL Certificate:";
            // 
            // CtlSSLConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.fileSslCertificateFile);
            this.Controls.Add(this.chkUseSsl);
            this.Name = "CtlSslConfig";
            this.Size = new System.Drawing.Size(579, 112);
            this.Load += new System.EventHandler(this.CtlSSLConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUseSsl;
        private ResourceLib.UI.CtlFilePicker fileSslCertificateFile;
    }
}
