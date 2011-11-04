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
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.radRouteSrv = new System.Windows.Forms.RadioButton();
            this.radConfigSrv = new System.Windows.Forms.RadioButton();
            this.radDataSrv = new System.Windows.Forms.RadioButton();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.VistaButton();
            this.cmdAdd = new System.Windows.Forms.VistaButton();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblIpAddr = new System.Windows.Forms.Label();
            this.txtHostName = new QLFUI.TextBoxEx();
            this.txtPassword = new QLFUI.TextBoxEx();
            this.txtUsername = new QLFUI.TextBoxEx();
            this.txtIpAddr = new QLFUI.TextBoxEx();
            this.txtPort = new QLFUI.TextBoxEx();
            this.txtReplSet = new QLFUI.TextBoxEx();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.txtDataBaseName = new QLFUI.TextBoxEx();
            this.chkLoginAsAdmin = new System.Windows.Forms.CheckBox();
            this.radReplSet = new System.Windows.Forms.RadioButton();
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.lblReplsetList = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lblReplsetList);
            this.contentPanel.Controls.Add(this.lstServerce);
            this.contentPanel.Controls.Add(this.chkLoginAsAdmin);
            this.contentPanel.Controls.Add(this.txtDataBaseName);
            this.contentPanel.Controls.Add(this.lblDataBaseName);
            this.contentPanel.Controls.Add(this.txtReplSet);
            this.contentPanel.Controls.Add(this.txtPort);
            this.contentPanel.Controls.Add(this.txtIpAddr);
            this.contentPanel.Controls.Add(this.txtUsername);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.txtHostName);
            this.contentPanel.Controls.Add(this.lblIpAddr);
            this.contentPanel.Controls.Add(this.lblReplsetName);
            this.contentPanel.Controls.Add(this.radReplSet);
            this.contentPanel.Controls.Add(this.radRouteSrv);
            this.contentPanel.Controls.Add(this.radConfigSrv);
            this.contentPanel.Controls.Add(this.radDataSrv);
            this.contentPanel.Controls.Add(this.chkSlaveOk);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdAdd);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.lblUsername);
            this.contentPanel.Controls.Add(this.lblPort);
            this.contentPanel.Controls.Add(this.lblHostName);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(572, 333);
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetName.Location = new System.Drawing.Point(49, 88);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 29;
            this.lblReplsetName.Text = "副本名称";
            // 
            // radRouteSrv
            // 
            this.radRouteSrv.AutoSize = true;
            this.radRouteSrv.BackColor = System.Drawing.Color.Transparent;
            this.radRouteSrv.Location = new System.Drawing.Point(52, 149);
            this.radRouteSrv.Name = "radRouteSrv";
            this.radRouteSrv.Size = new System.Drawing.Size(85, 17);
            this.radRouteSrv.TabIndex = 8;
            this.radRouteSrv.Text = "路由服务器";
            this.radRouteSrv.UseVisualStyleBackColor = false;
            // 
            // radConfigSrv
            // 
            this.radConfigSrv.AutoSize = true;
            this.radConfigSrv.BackColor = System.Drawing.Color.Transparent;
            this.radConfigSrv.Location = new System.Drawing.Point(154, 126);
            this.radConfigSrv.Name = "radConfigSrv";
            this.radConfigSrv.Size = new System.Drawing.Size(85, 17);
            this.radConfigSrv.TabIndex = 7;
            this.radConfigSrv.Text = "配置服务器";
            this.radConfigSrv.UseVisualStyleBackColor = false;
            // 
            // radDataSrv
            // 
            this.radDataSrv.AutoSize = true;
            this.radDataSrv.BackColor = System.Drawing.Color.Transparent;
            this.radDataSrv.Checked = true;
            this.radDataSrv.Location = new System.Drawing.Point(52, 126);
            this.radDataSrv.Name = "radDataSrv";
            this.radDataSrv.Size = new System.Drawing.Size(85, 17);
            this.radDataSrv.TabIndex = 6;
            this.radDataSrv.TabStop = true;
            this.radDataSrv.Text = "数据服务器";
            this.radDataSrv.UseVisualStyleBackColor = false;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.BackColor = System.Drawing.Color.Transparent;
            this.chkSlaveOk.Location = new System.Drawing.Point(52, 198);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(424, 17);
            this.chkSlaveOk.TabIndex = 9;
            this.chkSlaveOk.Text = "主从模式[GFS 操作限制，集群的非Route，Config服务器；Slave服务器，请选择]";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(286, 258);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 37);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "取消";
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(197, 258);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 37);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "添加";
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
            this.lblPort.Location = new System.Drawing.Point(381, 26);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 13);
            this.lblPort.TabIndex = 22;
            this.lblPort.Text = "端口号";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.BackColor = System.Drawing.Color.Transparent;
            this.lblHostName.Location = new System.Drawing.Point(49, 26);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(67, 13);
            this.lblHostName.TabIndex = 20;
            this.lblHostName.Text = "服务器名称";
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
            // txtHostName
            // 
            this.txtHostName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtHostName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtHostName.BackColor = System.Drawing.Color.Transparent;
            this.txtHostName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtHostName.ForeImage = null;
            this.txtHostName.Location = new System.Drawing.Point(115, 17);
            this.txtHostName.Multiline = false;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Radius = 3;
            this.txtHostName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtHostName.Size = new System.Drawing.Size(103, 29);
            this.txtHostName.TabIndex = 1;
            this.txtHostName.UseSystemPasswordChar = false;
            this.txtHostName.WaterMark = "服务器表示名称";
            this.txtHostName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtPassword.ForeImage = null;
            this.txtPassword.Location = new System.Drawing.Point(272, 48);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Radius = 3;
            this.txtPassword.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtPassword.Size = new System.Drawing.Size(103, 29);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "密码（可选项）";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtUsername.ForeImage = null;
            this.txtUsername.Location = new System.Drawing.Point(115, 48);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Radius = 3;
            this.txtUsername.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtUsername.Size = new System.Drawing.Size(103, 29);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.UseSystemPasswordChar = false;
            this.txtUsername.WaterMark = "用户名（可选项）";
            this.txtUsername.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIpAddr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIpAddr.BackColor = System.Drawing.Color.Transparent;
            this.txtIpAddr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtIpAddr.ForeImage = null;
            this.txtIpAddr.Location = new System.Drawing.Point(273, 17);
            this.txtIpAddr.Multiline = false;
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Radius = 3;
            this.txtIpAddr.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtIpAddr.Size = new System.Drawing.Size(103, 29);
            this.txtIpAddr.TabIndex = 2;
            this.txtIpAddr.UseSystemPasswordChar = false;
            this.txtIpAddr.WaterMark = "服务器IP地址";
            this.txtIpAddr.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtPort
            // 
            this.txtPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtPort.ForeImage = null;
            this.txtPort.Location = new System.Drawing.Point(449, 17);
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.Radius = 3;
            this.txtPort.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtPort.Size = new System.Drawing.Size(103, 29);
            this.txtPort.TabIndex = 3;
            this.txtPort.UseSystemPasswordChar = false;
            this.txtPort.WaterMark = "服务器端口号";
            this.txtPort.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtReplSet
            // 
            this.txtReplSet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtReplSet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtReplSet.BackColor = System.Drawing.Color.Transparent;
            this.txtReplSet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtReplSet.ForeImage = null;
            this.txtReplSet.Location = new System.Drawing.Point(116, 78);
            this.txtReplSet.Multiline = false;
            this.txtReplSet.Name = "txtReplSet";
            this.txtReplSet.Radius = 3;
            this.txtReplSet.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtReplSet.Size = new System.Drawing.Size(103, 29);
            this.txtReplSet.TabIndex = 7;
            this.txtReplSet.UseSystemPasswordChar = false;
            this.txtReplSet.WaterMark = "副本名称（可选项）";
            this.txtReplSet.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(379, 57);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(67, 13);
            this.lblDataBaseName.TabIndex = 32;
            this.lblDataBaseName.Text = "数据库名称";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDataBaseName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDataBaseName.BackColor = System.Drawing.Color.Transparent;
            this.txtDataBaseName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtDataBaseName.ForeImage = null;
            this.txtDataBaseName.Location = new System.Drawing.Point(449, 48);
            this.txtDataBaseName.Multiline = false;
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Radius = 3;
            this.txtDataBaseName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtDataBaseName.Size = new System.Drawing.Size(105, 29);
            this.txtDataBaseName.TabIndex = 6;
            this.txtDataBaseName.UseSystemPasswordChar = false;
            this.txtDataBaseName.WaterMark = "数据库名（可选）";
            this.txtDataBaseName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // chkLoginAsAdmin
            // 
            this.chkLoginAsAdmin.AutoSize = true;
            this.chkLoginAsAdmin.Enabled = false;
            this.chkLoginAsAdmin.Location = new System.Drawing.Point(52, 221);
            this.chkLoginAsAdmin.Name = "chkLoginAsAdmin";
            this.chkLoginAsAdmin.Size = new System.Drawing.Size(421, 17);
            this.chkLoginAsAdmin.TabIndex = 34;
            this.chkLoginAsAdmin.Text = "作为Admin登陆[系统自动配置，只有在数据库名称，用户名，密码填写时无效]";
            this.chkLoginAsAdmin.UseVisualStyleBackColor = true;
            // 
            // radReplSet
            // 
            this.radReplSet.AutoSize = true;
            this.radReplSet.BackColor = System.Drawing.Color.Transparent;
            this.radReplSet.Location = new System.Drawing.Point(154, 149);
            this.radReplSet.Name = "radReplSet";
            this.radReplSet.Size = new System.Drawing.Size(85, 17);
            this.radReplSet.TabIndex = 8;
            this.radReplSet.Text = "副本服务器";
            this.radReplSet.UseVisualStyleBackColor = false;
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(324, 88);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(228, 95);
            this.lstServerce.TabIndex = 35;
            // 
            // lblReplsetList
            // 
            this.lblReplsetList.AutoSize = true;
            this.lblReplsetList.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetList.Location = new System.Drawing.Point(227, 88);
            this.lblReplsetList.Name = "lblReplsetList";
            this.lblReplsetList.Size = new System.Drawing.Size(91, 13);
            this.lblReplsetList.TabIndex = 36;
            this.lblReplsetList.Text = "副本服务器列表";
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 396);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAddConnection";
            this.ShowSelectSkinButton = false;
            this.Text = "数据连接";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.RadioButton radRouteSrv;
        private System.Windows.Forms.RadioButton radConfigSrv;
        private System.Windows.Forms.RadioButton radDataSrv;
        private System.Windows.Forms.CheckBox chkSlaveOk;
        private System.Windows.Forms.VistaButton cmdCancel;
        private System.Windows.Forms.VistaButton cmdAdd;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblIpAddr;
        private QLFUI.TextBoxEx txtHostName;
        private QLFUI.TextBoxEx txtPort;
        private QLFUI.TextBoxEx txtIpAddr;
        private QLFUI.TextBoxEx txtUsername;
        private QLFUI.TextBoxEx txtPassword;
        private QLFUI.TextBoxEx txtReplSet;
        private QLFUI.TextBoxEx txtDataBaseName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.CheckBox chkLoginAsAdmin;
        private System.Windows.Forms.Label lblReplsetList;
        private System.Windows.Forms.ListBox lstServerce;
        private System.Windows.Forms.RadioButton radReplSet;
    }
}