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
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblIpAddr = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.radDataSrv = new System.Windows.Forms.RadioButton();
            this.radConfigSrv = new System.Windows.Forms.RadioButton();
            this.radRouteSrv = new System.Windows.Forms.RadioButton();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.txtReplSet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(97, 18);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(100, 20);
            this.txtHostName.TabIndex = 0;
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(260, 18);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(100, 20);
            this.txtIpAddr.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(418, 18);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 2;
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Location = new System.Drawing.Point(36, 21);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(31, 13);
            this.lblHostName.TabIndex = 3;
            this.lblHostName.Text = "名称";
            // 
            // lblIpAddr
            // 
            this.lblIpAddr.AutoSize = true;
            this.lblIpAddr.Location = new System.Drawing.Point(211, 21);
            this.lblIpAddr.Name = "lblIpAddr";
            this.lblIpAddr.Size = new System.Drawing.Size(39, 13);
            this.lblIpAddr.TabIndex = 4;
            this.lblIpAddr.Text = "ip地址";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(366, 21);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "端口号";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(142, 184);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "添加";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(239, 184);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.Location = new System.Drawing.Point(369, 106);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(74, 17);
            this.chkSlaveOk.TabIndex = 8;
            this.chkSlaveOk.Text = "主从模式";
            this.chkSlaveOk.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(97, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(260, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(36, 59);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "用户名";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(211, 59);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "密码";
            // 
            // radDataSrv
            // 
            this.radDataSrv.AutoSize = true;
            this.radDataSrv.Location = new System.Drawing.Point(39, 105);
            this.radDataSrv.Name = "radDataSrv";
            this.radDataSrv.Size = new System.Drawing.Size(85, 17);
            this.radDataSrv.TabIndex = 9;
            this.radDataSrv.TabStop = true;
            this.radDataSrv.Text = "数据服务器";
            this.radDataSrv.UseVisualStyleBackColor = true;
            // 
            // radConfigSrv
            // 
            this.radConfigSrv.AutoSize = true;
            this.radConfigSrv.Location = new System.Drawing.Point(142, 104);
            this.radConfigSrv.Name = "radConfigSrv";
            this.radConfigSrv.Size = new System.Drawing.Size(85, 17);
            this.radConfigSrv.TabIndex = 10;
            this.radConfigSrv.TabStop = true;
            this.radConfigSrv.Text = "配置服务器";
            this.radConfigSrv.UseVisualStyleBackColor = true;
            // 
            // radRouteSrv
            // 
            this.radRouteSrv.AutoSize = true;
            this.radRouteSrv.Location = new System.Drawing.Point(260, 104);
            this.radRouteSrv.Name = "radRouteSrv";
            this.radRouteSrv.Size = new System.Drawing.Size(85, 17);
            this.radRouteSrv.TabIndex = 11;
            this.radRouteSrv.TabStop = true;
            this.radRouteSrv.Text = "路由服务器";
            this.radRouteSrv.UseVisualStyleBackColor = true;
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.Location = new System.Drawing.Point(36, 143);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 12;
            this.lblReplsetName.Text = "副本名称";
            // 
            // txtReplSet
            // 
            this.txtReplSet.Location = new System.Drawing.Point(97, 140);
            this.txtReplSet.Name = "txtReplSet";
            this.txtReplSet.Size = new System.Drawing.Size(100, 20);
            this.txtReplSet.TabIndex = 13;
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 230);
            this.Controls.Add(this.txtReplSet);
            this.Controls.Add(this.lblReplsetName);
            this.Controls.Add(this.radRouteSrv);
            this.Controls.Add(this.radConfigSrv);
            this.Controls.Add(this.radDataSrv);
            this.Controls.Add(this.chkSlaveOk);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblIpAddr);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtIpAddr);
            this.Controls.Add(this.txtHostName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddConnection";
            this.Text = "添加链接";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblIpAddr;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkSlaveOk;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.RadioButton radDataSrv;
        private System.Windows.Forms.RadioButton radConfigSrv;
        private System.Windows.Forms.RadioButton radRouteSrv;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.TextBox txtReplSet;
    }
}