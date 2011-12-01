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
            this.txtReplSetName = new QLFUI.TextBoxEx();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.txtDataBaseName = new QLFUI.TextBoxEx();
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.lblReplsetList = new System.Windows.Forms.Label();
            this.chkSafeMode = new System.Windows.Forms.CheckBox();
            this.grpReplset = new System.Windows.Forms.GroupBox();
            this.cmdInitReplset = new System.Windows.Forms.VistaButton();
            this.grpShardingSvrType = new System.Windows.Forms.GroupBox();
            this.radArbiters = new System.Windows.Forms.RadioButton();
            this.lblMainReplsetName = new System.Windows.Forms.Label();
            this.txtMainReplsetName = new QLFUI.TextBoxEx();
            this.lblAttention = new System.Windows.Forms.Label();
            this.lblpriority = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.numTimeOut = new System.Windows.Forms.NumericUpDown();
            this.contentPanel.SuspendLayout();
            this.grpReplset.SuspendLayout();
            this.grpShardingSvrType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.numTimeOut);
            this.contentPanel.Controls.Add(this.lblTimeOut);
            this.contentPanel.Controls.Add(this.numPriority);
            this.contentPanel.Controls.Add(this.lblpriority);
            this.contentPanel.Controls.Add(this.lblAttention);
            this.contentPanel.Controls.Add(this.txtMainReplsetName);
            this.contentPanel.Controls.Add(this.lblMainReplsetName);
            this.contentPanel.Controls.Add(this.grpShardingSvrType);
            this.contentPanel.Controls.Add(this.grpReplset);
            this.contentPanel.Controls.Add(this.chkSafeMode);
            this.contentPanel.Controls.Add(this.txtDataBaseName);
            this.contentPanel.Controls.Add(this.lblDataBaseName);
            this.contentPanel.Controls.Add(this.txtPort);
            this.contentPanel.Controls.Add(this.txtIpAddr);
            this.contentPanel.Controls.Add(this.txtUsername);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.txtHostName);
            this.contentPanel.Controls.Add(this.lblIpAddr);
            this.contentPanel.Controls.Add(this.chkSlaveOk);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdAdd);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.lblUsername);
            this.contentPanel.Controls.Add(this.lblPort);
            this.contentPanel.Controls.Add(this.lblHostName);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(537, 441);
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetName.Location = new System.Drawing.Point(15, 29);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 29;
            this.lblReplsetName.Text = "副本名称";
            // 
            // radRouteSrv
            // 
            this.radRouteSrv.AutoSize = true;
            this.radRouteSrv.BackColor = System.Drawing.Color.Transparent;
            this.radRouteSrv.Location = new System.Drawing.Point(215, 21);
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
            this.radConfigSrv.Location = new System.Drawing.Point(122, 22);
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
            this.radDataSrv.Location = new System.Drawing.Point(20, 22);
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
            this.chkSlaveOk.Location = new System.Drawing.Point(22, 103);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(424, 17);
            this.chkSlaveOk.TabIndex = 9;
            this.chkSlaveOk.Text = "主从模式[GFS 操作限制，集群的非Route，Config服务器；Slave服务器，请选择]";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(419, 401);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 27);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "取消";
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(322, 401);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 27);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "添加";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(193, 52);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "密码";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(19, 52);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 19;
            this.lblUsername.Text = "用户名";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(351, 26);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 13);
            this.lblPort.TabIndex = 22;
            this.lblPort.Text = "端口号";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.BackColor = System.Drawing.Color.Transparent;
            this.lblHostName.Location = new System.Drawing.Point(19, 26);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(55, 13);
            this.lblHostName.TabIndex = 20;
            this.lblHostName.Text = "连接名称";
            // 
            // lblIpAddr
            // 
            this.lblIpAddr.AutoSize = true;
            this.lblIpAddr.BackColor = System.Drawing.Color.Transparent;
            this.lblIpAddr.Location = new System.Drawing.Point(193, 26);
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
            this.txtHostName.Location = new System.Drawing.Point(85, 17);
            this.txtHostName.Multiline = false;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Radius = 3;
            this.txtHostName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtHostName.Size = new System.Drawing.Size(103, 29);
            this.txtHostName.TabIndex = 1;
            this.txtHostName.UseSystemPasswordChar = false;
            this.txtHostName.WaterMark = "连接表示名称";
            this.txtHostName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtPassword.ForeImage = null;
            this.txtPassword.Location = new System.Drawing.Point(242, 42);
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
            this.txtUsername.Location = new System.Drawing.Point(85, 42);
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
            this.txtIpAddr.Location = new System.Drawing.Point(243, 17);
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
            this.txtPort.Location = new System.Drawing.Point(419, 17);
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
            // txtReplSetName
            // 
            this.txtReplSetName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtReplSetName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtReplSetName.BackColor = System.Drawing.Color.Transparent;
            this.txtReplSetName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtReplSetName.ForeImage = null;
            this.txtReplSetName.Location = new System.Drawing.Point(116, 19);
            this.txtReplSetName.Multiline = false;
            this.txtReplSetName.Name = "txtReplSetName";
            this.txtReplSetName.Radius = 3;
            this.txtReplSetName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtReplSetName.Size = new System.Drawing.Size(153, 29);
            this.txtReplSetName.TabIndex = 7;
            this.txtReplSetName.UseSystemPasswordChar = false;
            this.txtReplSetName.WaterMark = "副本名称（可选项）";
            this.txtReplSetName.WaterMarkColor = System.Drawing.Color.Silver;
            this.txtReplSetName.TextChanged += new QLFUI.TextBoxEx.TextChangedHandler(this.txtReplSet_TextChanged);
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(351, 51);
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
            this.txtDataBaseName.Location = new System.Drawing.Point(419, 42);
            this.txtDataBaseName.Multiline = false;
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Radius = 3;
            this.txtDataBaseName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtDataBaseName.Size = new System.Drawing.Size(103, 29);
            this.txtDataBaseName.TabIndex = 6;
            this.txtDataBaseName.UseSystemPasswordChar = false;
            this.txtDataBaseName.WaterMark = "数据库名（可选）";
            this.txtDataBaseName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(117, 54);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(377, 95);
            this.lstServerce.TabIndex = 35;
            // 
            // lblReplsetList
            // 
            this.lblReplsetList.AutoSize = true;
            this.lblReplsetList.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetList.Location = new System.Drawing.Point(14, 56);
            this.lblReplsetList.Name = "lblReplsetList";
            this.lblReplsetList.Size = new System.Drawing.Size(67, 13);
            this.lblReplsetList.TabIndex = 36;
            this.lblReplsetList.Text = "服务器列表";
            // 
            // chkSafeMode
            // 
            this.chkSafeMode.AutoSize = true;
            this.chkSafeMode.Location = new System.Drawing.Point(22, 126);
            this.chkSafeMode.Name = "chkSafeMode";
            this.chkSafeMode.Size = new System.Drawing.Size(220, 17);
            this.chkSafeMode.TabIndex = 37;
            this.chkSafeMode.Text = "安全模式[保证数据安全，性能有损失]";
            this.chkSafeMode.UseVisualStyleBackColor = true;
            // 
            // grpReplset
            // 
            this.grpReplset.BackColor = System.Drawing.Color.Transparent;
            this.grpReplset.Controls.Add(this.lstServerce);
            this.grpReplset.Controls.Add(this.cmdInitReplset);
            this.grpReplset.Controls.Add(this.txtReplSetName);
            this.grpReplset.Controls.Add(this.lblReplsetName);
            this.grpReplset.Controls.Add(this.lblReplsetList);
            this.grpReplset.Location = new System.Drawing.Point(20, 205);
            this.grpReplset.Name = "grpReplset";
            this.grpReplset.Size = new System.Drawing.Size(500, 162);
            this.grpReplset.TabIndex = 38;
            this.grpReplset.TabStop = false;
            this.grpReplset.Text = "副本服务器";
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.BackColor = System.Drawing.Color.Transparent;
            this.cmdInitReplset.Location = new System.Drawing.Point(275, 20);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(102, 28);
            this.cmdInitReplset.TabIndex = 37;
            this.cmdInitReplset.Text = "初始化副本";
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // grpShardingSvrType
            // 
            this.grpShardingSvrType.BackColor = System.Drawing.Color.Transparent;
            this.grpShardingSvrType.Controls.Add(this.radArbiters);
            this.grpShardingSvrType.Controls.Add(this.radDataSrv);
            this.grpShardingSvrType.Controls.Add(this.radConfigSrv);
            this.grpShardingSvrType.Controls.Add(this.radRouteSrv);
            this.grpShardingSvrType.Location = new System.Drawing.Point(20, 149);
            this.grpShardingSvrType.Name = "grpShardingSvrType";
            this.grpShardingSvrType.Size = new System.Drawing.Size(502, 50);
            this.grpShardingSvrType.TabIndex = 39;
            this.grpShardingSvrType.TabStop = false;
            this.grpShardingSvrType.Text = "分片系统/副本 服务器类型 ";
            // 
            // radArbiters
            // 
            this.radArbiters.AutoSize = true;
            this.radArbiters.Location = new System.Drawing.Point(310, 21);
            this.radArbiters.Name = "radArbiters";
            this.radArbiters.Size = new System.Drawing.Size(85, 17);
            this.radArbiters.TabIndex = 37;
            this.radArbiters.TabStop = true;
            this.radArbiters.Text = "仲裁服务器";
            this.radArbiters.UseVisualStyleBackColor = true;
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(19, 77);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblMainReplsetName.TabIndex = 40;
            this.lblMainReplsetName.Text = "副本名称";
            // 
            // txtMainReplsetName
            // 
            this.txtMainReplsetName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtMainReplsetName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtMainReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.txtMainReplsetName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtMainReplsetName.ForeImage = null;
            this.txtMainReplsetName.Location = new System.Drawing.Point(85, 68);
            this.txtMainReplsetName.Multiline = false;
            this.txtMainReplsetName.Name = "txtMainReplsetName";
            this.txtMainReplsetName.Radius = 3;
            this.txtMainReplsetName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtMainReplsetName.Size = new System.Drawing.Size(103, 29);
            this.txtMainReplsetName.TabIndex = 41;
            this.txtMainReplsetName.UseSystemPasswordChar = false;
            this.txtMainReplsetName.WaterMark = "副本名称(可选项)";
            this.txtMainReplsetName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // lblAttention
            // 
            this.lblAttention.AutoSize = true;
            this.lblAttention.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttention.ForeColor = System.Drawing.Color.Red;
            this.lblAttention.Location = new System.Drawing.Point(25, 374);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(253, 26);
            this.lblAttention.TabIndex = 42;
            this.lblAttention.Text = "[注意]密码将以明文形式保存于配置文件中.\r\n优先度为 0 时,无法成为副本主服务器";
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.Location = new System.Drawing.Point(193, 77);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(43, 13);
            this.lblpriority.TabIndex = 43;
            this.lblpriority.Text = "优先度";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(245, 73);
            this.numPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(103, 20);
            this.numPriority.TabIndex = 44;
            this.numPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(351, 76);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(55, 13);
            this.lblTimeOut.TabIndex = 45;
            this.lblTimeOut.Text = "延时（秒）";
            // 
            // numTimeOut
            // 
            this.numTimeOut.Location = new System.Drawing.Point(419, 73);
            this.numTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numTimeOut.Name = "numTimeOut";
            this.numTimeOut.Size = new System.Drawing.Size(103, 20);
            this.numTimeOut.TabIndex = 46;
            this.numTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 504);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAddConnection";
            this.Text = "数据连接";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.grpReplset.ResumeLayout(false);
            this.grpReplset.PerformLayout();
            this.grpShardingSvrType.ResumeLayout(false);
            this.grpShardingSvrType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).EndInit();
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
        private QLFUI.TextBoxEx txtReplSetName;
        private QLFUI.TextBoxEx txtDataBaseName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.Label lblReplsetList;
        private System.Windows.Forms.ListBox lstServerce;
        private System.Windows.Forms.CheckBox chkSafeMode;
        private System.Windows.Forms.GroupBox grpShardingSvrType;
        private System.Windows.Forms.GroupBox grpReplset;
        private System.Windows.Forms.Label lblMainReplsetName;
        private QLFUI.TextBoxEx txtMainReplsetName;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.RadioButton radArbiters;
        private System.Windows.Forms.VistaButton cmdInitReplset;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label lblpriority;
        private System.Windows.Forms.NumericUpDown numTimeOut;
        private System.Windows.Forms.Label lblTimeOut;
    }
}