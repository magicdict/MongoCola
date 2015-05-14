namespace FunctionForm.Connection
{
    partial class CtlSSLConfig
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ctlFilePicker1 = new ResourceLib.UI.CtlFilePicker();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Use SSL protocol";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ctlFilePicker1
            // 
            this.ctlFilePicker1.AutoSize = true;
            this.ctlFilePicker1.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePicker1.FileFilter = "SSL Certificate File|*.pem";
            this.ctlFilePicker1.FileName = "";
            this.ctlFilePicker1.Location = new System.Drawing.Point(15, 47);
            this.ctlFilePicker1.Name = "ctlFilePicker1";
            this.ctlFilePicker1.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.OpenFile;
            this.ctlFilePicker1.SelectedPathOrFileName = "";
            this.ctlFilePicker1.Size = new System.Drawing.Size(552, 38);
            this.ctlFilePicker1.TabIndex = 1;
            this.ctlFilePicker1.Title = "SSL Certificate:";
            // 
            // CtlSSLConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.ctlFilePicker1);
            this.Controls.Add(this.checkBox1);
            this.Name = "CtlSSLConfig";
            this.Size = new System.Drawing.Size(579, 112);
            this.Load += new System.EventHandler(this.CtlSSLConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private ResourceLib.UI.CtlFilePicker ctlFilePicker1;
    }
}
