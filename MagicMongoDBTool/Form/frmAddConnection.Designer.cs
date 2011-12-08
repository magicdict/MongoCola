using System.Windows.Forms;
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHostName = new TextBox();
            this.txtPassword = new TextBox();
            this.txtUsername = new TextBox();
            this.txtHost = new TextBox();
            this.txtPort = new TextBox();
            this.txtReplSetName = new TextBox();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.txtDataBaseName = new TextBox();
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.lblReplsetList = new System.Windows.Forms.Label();
            this.grpReplset = new System.Windows.Forms.GroupBox();
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.grpShardingSvrType = new System.Windows.Forms.GroupBox();
            this.radArbiters = new System.Windows.Forms.RadioButton();
            this.lblAttention = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasicInfo = new System.Windows.Forms.TabPage();
            this.Replset = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkSafeMode = new System.Windows.Forms.CheckBox();
            this.numTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblMainReplsetName = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.lblpriority = new System.Windows.Forms.Label();
            this.txtMainReplsetName = new TextBox();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.radMaster = new System.Windows.Forms.RadioButton();
            this.radSlave = new System.Windows.Forms.RadioButton();
            
            this.grpReplset.SuspendLayout();
            this.grpShardingSvrType.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabBasicInfo.SuspendLayout();
            this.Replset.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAttention);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Location = new System.Drawing.Point(1, 38);
            this.Size = new System.Drawing.Size(629, 353);
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
            this.radRouteSrv.TabIndex = 2;
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
            this.radConfigSrv.TabIndex = 1;
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
            this.radDataSrv.TabIndex = 0;
            this.radDataSrv.TabStop = true;
            this.radDataSrv.Text = "数据服务器";
            this.radDataSrv.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(450, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 27);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "取消";
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(353, 309);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 27);
            this.cmdAdd.TabIndex = 11;
            this.cmdAdd.Text = "添加";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(209, 54);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(31, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "密码";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(35, 54);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(43, 13);
            this.lblUsername.TabIndex = 19;
            this.lblUsername.Text = "用户名";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(367, 28);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(43, 13);
            this.lblPort.TabIndex = 22;
            this.lblPort.Text = "端口号";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.BackColor = System.Drawing.Color.Transparent;
            this.lblHostName.Location = new System.Drawing.Point(35, 28);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(55, 13);
            this.lblHostName.TabIndex = 20;
            this.lblHostName.Text = "连接名称";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Location = new System.Drawing.Point(209, 28);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(31, 13);
            this.lblHost.TabIndex = 31;
            this.lblHost.Text = "地址";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(101, 19);
            this.txtHostName.Multiline = false;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(103, 29);
            this.txtHostName.TabIndex = 0;
            this.txtHostName.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(258, 44);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(103, 29);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(101, 44);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(103, 29);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(259, 19);
            this.txtHost.Multiline = false;
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(103, 29);
            this.txtHost.TabIndex = 1;
            this.txtHost.UseSystemPasswordChar = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(435, 19);
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(103, 29);
            this.txtPort.TabIndex = 2;
            this.txtPort.UseSystemPasswordChar = false;
            // 
            // txtReplSetName
            // 
            this.txtReplSetName.Location = new System.Drawing.Point(116, 19);
            this.txtReplSetName.Multiline = false;
            this.txtReplSetName.Name = "txtReplSetName";
            this.txtReplSetName.Size = new System.Drawing.Size(153, 29);
            this.txtReplSetName.TabIndex = 0;
            this.txtReplSetName.UseSystemPasswordChar = false;
            this.txtReplSetName.TextChanged += new System.EventHandler(txtReplSetName_TextChanged);
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(367, 53);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(67, 13);
            this.lblDataBaseName.TabIndex = 32;
            this.lblDataBaseName.Text = "数据库名称";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(435, 44);
            this.txtDataBaseName.Multiline = false;
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(103, 29);
            this.txtDataBaseName.TabIndex = 5;
            this.txtDataBaseName.UseSystemPasswordChar = false;
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(117, 54);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(377, 95);
            this.lstServerce.TabIndex = 2;
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
            // grpReplset
            // 
            this.grpReplset.BackColor = System.Drawing.Color.Transparent;
            this.grpReplset.Controls.Add(this.lstServerce);
            this.grpReplset.Controls.Add(this.cmdInitReplset);
            this.grpReplset.Controls.Add(this.txtReplSetName);
            this.grpReplset.Controls.Add(this.lblReplsetName);
            this.grpReplset.Controls.Add(this.lblReplsetList);
            this.grpReplset.Location = new System.Drawing.Point(17, 57);
            this.grpReplset.Name = "grpReplset";
            this.grpReplset.Size = new System.Drawing.Size(544, 161);
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
            this.cmdInitReplset.TabIndex = 1;
            this.cmdInitReplset.Text = "初始化副本";
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // grpShardingSvrType
            // 
            this.grpShardingSvrType.BackColor = System.Drawing.Color.Transparent;
            this.grpShardingSvrType.Controls.Add(this.radMaster);
            this.grpShardingSvrType.Controls.Add(this.radSlave);
            this.grpShardingSvrType.Controls.Add(this.radArbiters);
            this.grpShardingSvrType.Controls.Add(this.radDataSrv);
            this.grpShardingSvrType.Controls.Add(this.radConfigSrv);
            this.grpShardingSvrType.Controls.Add(this.radRouteSrv);
            this.grpShardingSvrType.Location = new System.Drawing.Point(27, 20);
            this.grpShardingSvrType.Name = "grpShardingSvrType";
            this.grpShardingSvrType.Size = new System.Drawing.Size(545, 89);
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
            this.radArbiters.TabIndex = 3;
            this.radArbiters.TabStop = true;
            this.radArbiters.Text = "仲裁服务器";
            this.radArbiters.UseVisualStyleBackColor = true;
            // 
            // lblAttention
            // 
            this.lblAttention.AutoSize = true;
            this.lblAttention.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttention.ForeColor = System.Drawing.Color.Red;
            this.lblAttention.Location = new System.Drawing.Point(50, 309);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(253, 26);
            this.lblAttention.TabIndex = 42;
            this.lblAttention.Text = "[注意]密码将以明文形式保存于配置文件中.\r\n优先度为 0 时,无法成为副本主服务器";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(32, 102);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(489, 50);
            this.txtConnectionString.TabIndex = 46;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(35, 85);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(115, 13);
            this.lblConnectionString.TabIndex = 47;
            this.lblConnectionString.Text = "直接使用连接字符串";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasicInfo);
            this.tabControl1.Controls.Add(this.Replset);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 281);
            this.tabControl1.TabIndex = 5;
            // 
            // tabBasicInfo
            // 
            this.tabBasicInfo.Controls.Add(this.chkSlaveOk);
            this.tabBasicInfo.Controls.Add(this.numTimeOut);
            this.tabBasicInfo.Controls.Add(this.lblTimeOut);
            this.tabBasicInfo.Controls.Add(this.chkSafeMode);
            this.tabBasicInfo.Controls.Add(this.lblConnectionString);
            this.tabBasicInfo.Controls.Add(this.txtConnectionString);
            this.tabBasicInfo.Controls.Add(this.lblHostName);
            this.tabBasicInfo.Controls.Add(this.lblPort);
            this.tabBasicInfo.Controls.Add(this.lblUsername);
            this.tabBasicInfo.Controls.Add(this.lblPassword);
            this.tabBasicInfo.Controls.Add(this.lblHost);
            this.tabBasicInfo.Controls.Add(this.txtHostName);
            this.tabBasicInfo.Controls.Add(this.txtPassword);
            this.tabBasicInfo.Controls.Add(this.txtUsername);
            this.tabBasicInfo.Controls.Add(this.txtHost);
            this.tabBasicInfo.Controls.Add(this.txtPort);
            this.tabBasicInfo.Controls.Add(this.lblDataBaseName);
            this.tabBasicInfo.Controls.Add(this.txtDataBaseName);
            this.tabBasicInfo.Location = new System.Drawing.Point(4, 22);
            this.tabBasicInfo.Name = "tabBasicInfo";
            this.tabBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasicInfo.Size = new System.Drawing.Size(590, 255);
            this.tabBasicInfo.TabIndex = 0;
            this.tabBasicInfo.Text = "BasicInfo";
            this.tabBasicInfo.UseVisualStyleBackColor = true;
            // 
            // Replset
            // 
            this.Replset.Controls.Add(this.lblMainReplsetName);
            this.Replset.Controls.Add(this.numPriority);
            this.Replset.Controls.Add(this.lblpriority);
            this.Replset.Controls.Add(this.txtMainReplsetName);
            this.Replset.Controls.Add(this.grpReplset);
            this.Replset.Location = new System.Drawing.Point(4, 22);
            this.Replset.Name = "Replset";
            this.Replset.Padding = new System.Windows.Forms.Padding(3);
            this.Replset.Size = new System.Drawing.Size(590, 255);
            this.Replset.TabIndex = 1;
            this.Replset.Text = "Replset";
            this.Replset.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpShardingSvrType);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(590, 255);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ServerRole";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkSafeMode
            // 
            this.chkSafeMode.AutoSize = true;
            this.chkSafeMode.Location = new System.Drawing.Point(38, 158);
            this.chkSafeMode.Name = "chkSafeMode";
            this.chkSafeMode.Size = new System.Drawing.Size(220, 17);
            this.chkSafeMode.TabIndex = 48;
            this.chkSafeMode.Text = "安全模式[保证数据安全，性能有损失]";
            this.chkSafeMode.UseVisualStyleBackColor = true;
            // 
            // numTimeOut
            // 
            this.numTimeOut.Location = new System.Drawing.Point(374, 159);
            this.numTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numTimeOut.Name = "numTimeOut";
            this.numTimeOut.Size = new System.Drawing.Size(103, 20);
            this.numTimeOut.TabIndex = 49;
            this.numTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(306, 162);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(55, 13);
            this.lblTimeOut.TabIndex = 50;
            this.lblTimeOut.Text = "延时（秒）";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(20, 31);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblMainReplsetName.TabIndex = 46;
            this.lblMainReplsetName.Text = "副本名称";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(304, 27);
            this.numPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(103, 20);
            this.numPriority.TabIndex = 45;
            this.numPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.Location = new System.Drawing.Point(252, 31);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(43, 13);
            this.lblpriority.TabIndex = 47;
            this.lblpriority.Text = "优先度";
            // 
            // txtMainReplsetName
            // 
            this.txtMainReplsetName.Location = new System.Drawing.Point(106, 22);
            this.txtMainReplsetName.Multiline = false;
            this.txtMainReplsetName.Name = "txtMainReplsetName";
            this.txtMainReplsetName.Size = new System.Drawing.Size(128, 29);
            this.txtMainReplsetName.TabIndex = 44;
            this.txtMainReplsetName.UseSystemPasswordChar = false;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.BackColor = System.Drawing.Color.Transparent;
            this.chkSlaveOk.Location = new System.Drawing.Point(38, 185);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(424, 17);
            this.chkSlaveOk.TabIndex = 51;
            this.chkSlaveOk.Text = "主从模式[GFS 操作限制，集群的非Route，Config服务器；Slave服务器，请选择]";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // radMaster
            // 
            this.radMaster.AutoSize = true;
            this.radMaster.Location = new System.Drawing.Point(20, 55);
            this.radMaster.Name = "radMaster";
            this.radMaster.Size = new System.Drawing.Size(57, 17);
            this.radMaster.TabIndex = 41;
            this.radMaster.TabStop = true;
            this.radMaster.Text = "Master";
            this.radMaster.UseVisualStyleBackColor = true;
            // 
            // radSlave
            // 
            this.radSlave.AutoSize = true;
            this.radSlave.Location = new System.Drawing.Point(122, 55);
            this.radSlave.Name = "radSlave";
            this.radSlave.Size = new System.Drawing.Size(52, 17);
            this.radSlave.TabIndex = 42;
            this.radSlave.TabStop = true;
            this.radSlave.Text = "Slave";
            this.radSlave.UseVisualStyleBackColor = true;
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 416);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAddConnection";
            this.Text = "数据连接";
            this.grpReplset.ResumeLayout(false);
            this.grpReplset.PerformLayout();
            this.grpShardingSvrType.ResumeLayout(false);
            this.grpShardingSvrType.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabBasicInfo.ResumeLayout(false);
            this.tabBasicInfo.PerformLayout();
            this.Replset.ResumeLayout(false);
            this.Replset.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.RadioButton radRouteSrv;
        private System.Windows.Forms.RadioButton radConfigSrv;
        private System.Windows.Forms.RadioButton radDataSrv;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblHost;
        private TextBox txtHostName;
        private TextBox txtPort;
        private TextBox txtHost;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtReplSetName;
        private TextBox txtDataBaseName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.Label lblReplsetList;
        private System.Windows.Forms.ListBox lstServerce;
        private System.Windows.Forms.GroupBox grpShardingSvrType;
        private System.Windows.Forms.GroupBox grpReplset;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.RadioButton radArbiters;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasicInfo;
        private System.Windows.Forms.CheckBox chkSafeMode;
        private System.Windows.Forms.TabPage Replset;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown numTimeOut;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Label lblMainReplsetName;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label lblpriority;
        private TextBox txtMainReplsetName;
        private System.Windows.Forms.CheckBox chkSlaveOk;
        private System.Windows.Forms.RadioButton radMaster;
        private System.Windows.Forms.RadioButton radSlave;
    }
}