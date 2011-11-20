namespace MagicMongoDBTool
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.cmdCancel = new System.Windows.Forms.VistaButton();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new QLFUI.TextBoxEx();
            this.txtPassword = new QLFUI.TextBoxEx();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.chkReadOnly);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.txtUserName);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.lblUserName);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(362, 171);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(52, 124);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(218, 125);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 32);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(71, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(43, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "用户名";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(71, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "密码";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtUserName.ForeImage = null;
            this.txtUserName.Location = new System.Drawing.Point(135, 21);
            this.txtUserName.Multiline = false;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Radius = 3;
            this.txtUserName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtUserName.Size = new System.Drawing.Size(146, 29);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.UseSystemPasswordChar = false;
            this.txtUserName.WaterMark = null;
            this.txtUserName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtPassword.ForeImage = null;
            this.txtPassword.Location = new System.Drawing.Point(135, 53);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Radius = 3;
            this.txtPassword.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtPassword.Size = new System.Drawing.Size(146, 29);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = null;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkReadOnly.Location = new System.Drawing.Point(137, 97);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(74, 17);
            this.chkReadOnly.TabIndex = 11;
            this.chkReadOnly.Text = "只读权限";
            this.chkReadOnly.UseVisualStyleBackColor = false;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 234);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUser";
            this.ShowSelectSkinButton = false;
            this.Text = "添加用户";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.VistaButton cmdCancel;
        private QLFUI.TextBoxEx txtPassword;
        private QLFUI.TextBoxEx txtUserName;
        private System.Windows.Forms.CheckBox chkReadOnly;
    }
}