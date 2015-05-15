using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace FunctionForm.Connection
{
    partial class CtlSshConfig
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

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
            this.chkUserSSHTrunel = new System.Windows.Forms.CheckBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpAuthMethod = new System.Windows.Forms.GroupBox();
            this.radPrivateKey = new System.Windows.Forms.RadioButton();
            this.radPassword = new System.Windows.Forms.RadioButton();
            this.ctlFilePicker1 = new ResourceLib.UI.CtlFilePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpAuthMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkUserSSHTrunel
            // 
            this.chkUserSSHTrunel.AutoSize = true;
            this.chkUserSSHTrunel.Location = new System.Drawing.Point(27, 18);
            this.chkUserSSHTrunel.Name = "chkUserSSHTrunel";
            this.chkUserSSHTrunel.Size = new System.Drawing.Size(108, 16);
            this.chkUserSSHTrunel.TabIndex = 0;
            this.chkUserSSHTrunel.Text = "Use SSH tunnel";
            this.chkUserSSHTrunel.UseVisualStyleBackColor = true;
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(288, 41);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(118, 21);
            this.numPort.TabIndex = 7;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(240, 46);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 12);
            this.lblPort.TabIndex = 8;
            this.lblPort.Tag = "Common_Port";
            this.lblPort.Text = "Port";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(107, 40);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(119, 21);
            this.txtHost.TabIndex = 5;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Location = new System.Drawing.Point(25, 46);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(29, 12);
            this.lblHost.TabIndex = 6;
            this.lblHost.Tag = "Common_Host";
            this.lblHost.Text = "Host";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(433, 43);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(53, 12);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Tag = "Common_Username";
            this.lblUsername.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(433, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 12);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Tag = "Common_Password";
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(499, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(499, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // grpAuthMethod
            // 
            this.grpAuthMethod.Controls.Add(this.radPrivateKey);
            this.grpAuthMethod.Controls.Add(this.radPassword);
            this.grpAuthMethod.Location = new System.Drawing.Point(27, 81);
            this.grpAuthMethod.Name = "grpAuthMethod";
            this.grpAuthMethod.Size = new System.Drawing.Size(220, 46);
            this.grpAuthMethod.TabIndex = 13;
            this.grpAuthMethod.TabStop = false;
            this.grpAuthMethod.Text = "Auth Method";
            // 
            // radPrivateKey
            // 
            this.radPrivateKey.AutoSize = true;
            this.radPrivateKey.Location = new System.Drawing.Point(110, 20);
            this.radPrivateKey.Name = "radPrivateKey";
            this.radPrivateKey.Size = new System.Drawing.Size(89, 16);
            this.radPrivateKey.TabIndex = 1;
            this.radPrivateKey.TabStop = true;
            this.radPrivateKey.Text = "private Key";
            this.radPrivateKey.UseVisualStyleBackColor = true;
            // 
            // radPassword
            // 
            this.radPassword.AutoSize = true;
            this.radPassword.Location = new System.Drawing.Point(18, 20);
            this.radPassword.Name = "radPassword";
            this.radPassword.Size = new System.Drawing.Size(71, 16);
            this.radPassword.TabIndex = 0;
            this.radPassword.TabStop = true;
            this.radPassword.Tag = "Common_Password";
            this.radPassword.Text = "Password";
            this.radPassword.UseVisualStyleBackColor = true;
            // 
            // ctlFilePicker1
            // 
            this.ctlFilePicker1.AutoSize = true;
            this.ctlFilePicker1.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePicker1.FileFilter = "private key file|*.ppk";
            this.ctlFilePicker1.FileName = "";
            this.ctlFilePicker1.Location = new System.Drawing.Point(27, 133);
            this.ctlFilePicker1.Name = "ctlFilePicker1";
            this.ctlFilePicker1.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.OpenFile;
            this.ctlFilePicker1.SelectedPathOrFileName = "";
            this.ctlFilePicker1.Size = new System.Drawing.Size(588, 38);
            this.ctlFilePicker1.TabIndex = 14;
            this.ctlFilePicker1.Title = "Private Key";
            // 
            // CtlSshConfig
            // 
            this.Controls.Add(this.ctlFilePicker1);
            this.Controls.Add(this.grpAuthMethod);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.chkUserSSHTrunel);
            this.Name = "CtlSshConfig";
            this.Size = new System.Drawing.Size(634, 184);
            this.Load += new System.EventHandler(this.CtlSshConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpAuthMethod.ResumeLayout(false);
            this.grpAuthMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chkUserSSHTrunel;
        private NumericUpDown numPort;
        private Label lblPort;
        private TextBox txtHost;
        private Label lblHost;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private GroupBox grpAuthMethod;
        private RadioButton radPrivateKey;
        private RadioButton radPassword;
        private CtlFilePicker ctlFilePicker1;
    }
}
