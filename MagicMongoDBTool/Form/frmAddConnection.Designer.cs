namespace MagicMongoDBTool
{
    partial class frmAddConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddConnection));
            this.txtReplSet = new System.Windows.Forms.TextBox();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.radRouteSrv = new System.Windows.Forms.RadioButton();
            this.radConfigSrv = new System.Windows.Forms.RadioButton();
            this.radDataSrv = new System.Windows.Forms.RadioButton();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblIpAddr = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lblIpAddr);
            this.contentPanel.Controls.Add(this.txtReplSet);
            this.contentPanel.Controls.Add(this.lblReplsetName);
            this.contentPanel.Controls.Add(this.radRouteSrv);
            this.contentPanel.Controls.Add(this.radConfigSrv);
            this.contentPanel.Controls.Add(this.radDataSrv);
            this.contentPanel.Controls.Add(this.chkSlaveOk);
            this.contentPanel.Controls.Add(this.txtPort);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdAdd);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.lblUsername);
            this.contentPanel.Controls.Add(this.lblPort);
            this.contentPanel.Controls.Add(this.txtIpAddr);
            this.contentPanel.Controls.Add(this.txtHostName);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.txtUsername);
            this.contentPanel.Controls.Add(this.lblHostName);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(572, 214);
            // 
            // txtReplSet
            // 
            this.txtReplSet.Location = new System.Drawing.Point(110, 105);
            this.txtReplSet.Name = "txtReplSet";
            this.txtReplSet.Size = new System.Drawing.Size(100, 20);
            this.txtReplSet.TabIndex = 30;
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetName.Location = new System.Drawing.Point(49, 108);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 29;
            this.lblReplsetName.Text = "副本名称";
            // 
            // radRouteSrv
            // 
            this.radRouteSrv.AutoSize = true;
            this.radRouteSrv.BackColor = System.Drawing.Color.Transparent;
            this.radRouteSrv.Location = new System.Drawing.Point(273, 76);
            this.radRouteSrv.Name = "radRouteSrv";
            this.radRouteSrv.Size = new System.Drawing.Size(85, 17);
            this.radRouteSrv.TabIndex = 28;
            this.radRouteSrv.TabStop = true;
            this.radRouteSrv.Text = "路由服务器";
            this.radRouteSrv.UseVisualStyleBackColor = false;
            // 
            // radConfigSrv
            // 
            this.radConfigSrv.AutoSize = true;
            this.radConfigSrv.BackColor = System.Drawing.Color.Transparent;
            this.radConfigSrv.Location = new System.Drawing.Point(155, 76);
            this.radConfigSrv.Name = "radConfigSrv";
            this.radConfigSrv.Size = new System.Drawing.Size(85, 17);
            this.radConfigSrv.TabIndex = 27;
            this.radConfigSrv.TabStop = true;
            this.radConfigSrv.Text = "配置服务器";
            this.radConfigSrv.UseVisualStyleBackColor = false;
            // 
            // radDataSrv
            // 
            this.radDataSrv.AutoSize = true;
            this.radDataSrv.BackColor = System.Drawing.Color.Transparent;
            this.radDataSrv.Location = new System.Drawing.Point(52, 77);
            this.radDataSrv.Name = "radDataSrv";
            this.radDataSrv.Size = new System.Drawing.Size(85, 17);
            this.radDataSrv.TabIndex = 26;
            this.radDataSrv.TabStop = true;
            this.radDataSrv.Text = "数据服务器";
            this.radDataSrv.UseVisualStyleBackColor = false;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.BackColor = System.Drawing.Color.Transparent;
            this.chkSlaveOk.Location = new System.Drawing.Point(382, 78);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(152, 17);
            this.chkSlaveOk.TabIndex = 25;
            this.chkSlaveOk.Text = "主从模式[GFS 操作限制]";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(434, 26);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 18;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(243, 164);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 24;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(146, 164);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 23;
            this.cmdAdd.Text = "添加";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(224, 54);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "密码";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(49, 54);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 19;
            this.lblUsername.Text = "用户名";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(379, 23);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 13);
            this.lblPort.TabIndex = 22;
            this.lblPort.Text = "端口号";
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(273, 23);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(100, 20);
            this.txtIpAddr.TabIndex = 17;
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(110, 23);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(100, 20);
            this.txtHostName.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(273, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 16;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(110, 51);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 14;
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.BackColor = System.Drawing.Color.Transparent;
            this.lblHostName.Location = new System.Drawing.Point(49, 26);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(31, 13);
            this.lblHostName.TabIndex = 20;
            this.lblHostName.Text = "名称";
            // 
            // lblIpAddr
            // 
            this.lblIpAddr.AutoSize = true;
            this.lblIpAddr.BackColor = System.Drawing.Color.Transparent;
            this.lblIpAddr.Location = new System.Drawing.Point(224, 26);
            this.lblIpAddr.Name = "lblIpAddr";
            this.lblIpAddr.Size = new System.Drawing.Size(31, 13);
            this.lblIpAddr.TabIndex = 31;
            this.lblIpAddr.Text = "地址";
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 277);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAddConnection";
            this.Text = "frmAddConnection";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtReplSet;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.RadioButton radRouteSrv;
        private System.Windows.Forms.RadioButton radConfigSrv;
        private System.Windows.Forms.RadioButton radDataSrv;
        private System.Windows.Forms.CheckBox chkSlaveOk;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblIpAddr;
    }
}