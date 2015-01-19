using System.Windows.Forms;

namespace MongoCola.Connection
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblConnectionName = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblAttentionPassword = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.tabConnection = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.chkVerifySslCertificate = new System.Windows.Forms.CheckBox();
            this.chkUseSsl = new System.Windows.Forms.CheckBox();
            this.chkJournal = new System.Windows.Forms.CheckBox();
            this.chkFsync = new System.Windows.Forms.CheckBox();
            this.NumConnectTimeOut = new System.Windows.Forms.NumericUpDown();
            this.NumSocketTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblConnectTimeout = new System.Windows.Forms.Label();
            this.lblsocketTimeout = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabReplicaSet = new System.Windows.Forms.TabPage();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.NumReplPort = new System.Windows.Forms.NumericUpDown();
            this.lblReplPort = new System.Windows.Forms.Label();
            this.txtReplHost = new System.Windows.Forms.TextBox();
            this.lblReplHost = new System.Windows.Forms.Label();
            this.cmdAddHost = new System.Windows.Forms.Button();
            this.lstHost = new System.Windows.Forms.ListBox();
            this.lblReplsetNameDescription = new System.Windows.Forms.Label();
            this.lblMainReplsetName = new System.Windows.Forms.Label();
            this.txtReplsetName = new System.Windows.Forms.TextBox();
            this.tabConnString = new System.Windows.Forms.TabPage();
            this.tabReadWrite = new System.Windows.Forms.TabPage();
            this.chkUseDefault = new System.Windows.Forms.CheckBox();
            this.lnkWriteConcern = new System.Windows.Forms.LinkLabel();
            this.lnkReadPreference = new System.Windows.Forms.LinkLabel();
            this.cmbWriteConcern = new System.Windows.Forms.ComboBox();
            this.lblWriteConcern = new System.Windows.Forms.Label();
            this.cmbReadPreference = new System.Windows.Forms.ComboBox();
            this.lblReadPreference = new System.Windows.Forms.Label();
            this.lblWtimeoutDescript = new System.Windows.Forms.Label();
            this.NumWTimeoutMS = new System.Windows.Forms.NumericUpDown();
            this.lblQueueSize = new System.Windows.Forms.Label();
            this.lblWTimeout = new System.Windows.Forms.Label();
            this.NumWaitQueueSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabConnection.SuspendLayout();
            this.tabBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).BeginInit();
            this.tabReplicaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            this.tabConnString.SuspendLayout();
            this.tabReadWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(633, 253);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(112, 33);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(515, 253);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(112, 33);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(261, 67);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 16);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(25, 70);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(74, 16);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "UserName";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(482, 32);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 16);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port";
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.AutoSize = true;
            this.lblConnectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionName.Location = new System.Drawing.Point(23, 33);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(75, 16);
            this.lblConnectionName.TabIndex = 0;
            this.lblConnectionName.Text = "Connection";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Location = new System.Drawing.Point(261, 29);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(36, 16);
            this.lblHost.TabIndex = 1;
            this.lblHost.Text = "Host";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(117, 27);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(135, 22);
            this.txtConnectionName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(336, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(135, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(117, 61);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(135, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHost.Location = new System.Drawing.Point(336, 22);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(135, 22);
            this.txtHost.TabIndex = 1;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(483, 68);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(68, 16);
            this.lblDataBaseName.TabIndex = 10;
            this.lblDataBaseName.Text = "Database";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(574, 60);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(135, 22);
            this.txtDataBaseName.TabIndex = 5;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(10, 33);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(730, 144);
            this.txtConnectionString.TabIndex = 0;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(7, 14);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(188, 16);
            this.lblConnectionString.TabIndex = 16;
            this.lblConnectionString.Text = "Use ConnectionString Directly:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(573, 21);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(135, 22);
            this.numPort.TabIndex = 2;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAttentionPassword
            // 
            this.lblAttentionPassword.AutoSize = true;
            this.lblAttentionPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttentionPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAttentionPassword.Location = new System.Drawing.Point(25, 103);
            this.lblAttentionPassword.Name = "lblAttentionPassword";
            this.lblAttentionPassword.Size = new System.Drawing.Size(295, 13);
            this.lblAttentionPassword.TabIndex = 18;
            this.lblAttentionPassword.Text = "Password is saved in config file without Encryption";
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(73, 253);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(213, 33);
            this.cmdTest.TabIndex = 2;
            this.cmdTest.Text = "Test Connection";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.tabBasic);
            this.tabConnection.Controls.Add(this.tabReplicaSet);
            this.tabConnection.Controls.Add(this.tabConnString);
            this.tabConnection.Controls.Add(this.tabReadWrite);
            this.tabConnection.Location = new System.Drawing.Point(14, 13);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.SelectedIndex = 0;
            this.tabConnection.Size = new System.Drawing.Size(769, 234);
            this.tabConnection.TabIndex = 0;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.chkVerifySslCertificate);
            this.tabBasic.Controls.Add(this.chkUseSsl);
            this.tabBasic.Controls.Add(this.chkJournal);
            this.tabBasic.Controls.Add(this.chkFsync);
            this.tabBasic.Controls.Add(this.NumConnectTimeOut);
            this.tabBasic.Controls.Add(this.NumSocketTimeOut);
            this.tabBasic.Controls.Add(this.lblConnectTimeout);
            this.tabBasic.Controls.Add(this.lblsocketTimeout);
            this.tabBasic.Controls.Add(this.label7);
            this.tabBasic.Controls.Add(this.numPort);
            this.tabBasic.Controls.Add(this.lblAttentionPassword);
            this.tabBasic.Controls.Add(this.lblConnectionName);
            this.tabBasic.Controls.Add(this.txtDataBaseName);
            this.tabBasic.Controls.Add(this.lblPort);
            this.tabBasic.Controls.Add(this.lblDataBaseName);
            this.tabBasic.Controls.Add(this.lblUsername);
            this.tabBasic.Controls.Add(this.txtHost);
            this.tabBasic.Controls.Add(this.lblPassword);
            this.tabBasic.Controls.Add(this.txtUsername);
            this.tabBasic.Controls.Add(this.lblHost);
            this.tabBasic.Controls.Add(this.txtPassword);
            this.tabBasic.Controls.Add(this.txtConnectionName);
            this.tabBasic.Location = new System.Drawing.Point(4, 25);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(761, 205);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // chkVerifySslCertificate
            // 
            this.chkVerifySslCertificate.AutoSize = true;
            this.chkVerifySslCertificate.Location = new System.Drawing.Point(440, 173);
            this.chkVerifySslCertificate.Name = "chkVerifySslCertificate";
            this.chkVerifySslCertificate.Size = new System.Drawing.Size(139, 20);
            this.chkVerifySslCertificate.TabIndex = 43;
            this.chkVerifySslCertificate.Text = "VerifySslCertificate";
            this.chkVerifySslCertificate.UseVisualStyleBackColor = true;
            // 
            // chkUseSsl
            // 
            this.chkUseSsl.AutoSize = true;
            this.chkUseSsl.Location = new System.Drawing.Point(290, 173);
            this.chkUseSsl.Name = "chkUseSsl";
            this.chkUseSsl.Size = new System.Drawing.Size(71, 20);
            this.chkUseSsl.TabIndex = 42;
            this.chkUseSsl.Text = "UseSsl";
            this.chkUseSsl.UseVisualStyleBackColor = true;
            // 
            // chkJournal
            // 
            this.chkJournal.AutoSize = true;
            this.chkJournal.Location = new System.Drawing.Point(178, 173);
            this.chkJournal.Name = "chkJournal";
            this.chkJournal.Size = new System.Drawing.Size(67, 20);
            this.chkJournal.TabIndex = 39;
            this.chkJournal.Text = "journal";
            this.chkJournal.UseVisualStyleBackColor = true;
            // 
            // chkFsync
            // 
            this.chkFsync.AutoSize = true;
            this.chkFsync.Location = new System.Drawing.Point(29, 173);
            this.chkFsync.Name = "chkFsync";
            this.chkFsync.Size = new System.Drawing.Size(58, 20);
            this.chkFsync.TabIndex = 38;
            this.chkFsync.Text = "fsync";
            this.chkFsync.UseVisualStyleBackColor = true;
            // 
            // NumConnectTimeOut
            // 
            this.NumConnectTimeOut.Location = new System.Drawing.Point(440, 142);
            this.NumConnectTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumConnectTimeOut.Name = "NumConnectTimeOut";
            this.NumConnectTimeOut.Size = new System.Drawing.Size(87, 22);
            this.NumConnectTimeOut.TabIndex = 37;
            this.NumConnectTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumSocketTimeOut
            // 
            this.NumSocketTimeOut.Location = new System.Drawing.Point(178, 140);
            this.NumSocketTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumSocketTimeOut.Name = "NumSocketTimeOut";
            this.NumSocketTimeOut.Size = new System.Drawing.Size(87, 22);
            this.NumSocketTimeOut.TabIndex = 36;
            this.NumSocketTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblConnectTimeout
            // 
            this.lblConnectTimeout.AutoSize = true;
            this.lblConnectTimeout.Location = new System.Drawing.Point(283, 142);
            this.lblConnectTimeout.Name = "lblConnectTimeout";
            this.lblConnectTimeout.Size = new System.Drawing.Size(132, 16);
            this.lblConnectTimeout.TabIndex = 40;
            this.lblConnectTimeout.Text = "connectTimeout(MS)";
            // 
            // lblsocketTimeout
            // 
            this.lblsocketTimeout.AutoSize = true;
            this.lblsocketTimeout.Location = new System.Drawing.Point(25, 145);
            this.lblsocketTimeout.Name = "lblsocketTimeout";
            this.lblsocketTimeout.Size = new System.Drawing.Size(125, 16);
            this.lblsocketTimeout.TabIndex = 41;
            this.lblsocketTimeout.Text = "socketTimeout(MS)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(468, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "If you want to connect to a replSet please  fill  replset information at  replset" +
    " tab.";
            // 
            // tabReplicaSet
            // 
            this.tabReplicaSet.Controls.Add(this.cmdRemoveHost);
            this.tabReplicaSet.Controls.Add(this.NumReplPort);
            this.tabReplicaSet.Controls.Add(this.lblReplPort);
            this.tabReplicaSet.Controls.Add(this.txtReplHost);
            this.tabReplicaSet.Controls.Add(this.lblReplHost);
            this.tabReplicaSet.Controls.Add(this.cmdAddHost);
            this.tabReplicaSet.Controls.Add(this.lstHost);
            this.tabReplicaSet.Controls.Add(this.lblReplsetNameDescription);
            this.tabReplicaSet.Controls.Add(this.lblMainReplsetName);
            this.tabReplicaSet.Controls.Add(this.txtReplsetName);
            this.tabReplicaSet.Location = new System.Drawing.Point(4, 25);
            this.tabReplicaSet.Name = "tabReplicaSet";
            this.tabReplicaSet.Size = new System.Drawing.Size(761, 205);
            this.tabReplicaSet.TabIndex = 3;
            this.tabReplicaSet.Text = "ReplicaSet";
            this.tabReplicaSet.UseVisualStyleBackColor = true;
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(133, 163);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(108, 27);
            this.cmdRemoveHost.TabIndex = 4;
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(107, 119);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(135, 22);
            this.NumReplPort.TabIndex = 2;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(31, 122);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(32, 16);
            this.lblReplPort.TabIndex = 35;
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(106, 92);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(135, 22);
            this.txtReplHost.TabIndex = 1;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(31, 92);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(36, 16);
            this.lblReplHost.TabIndex = 33;
            this.lblReplHost.Text = "Host";
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(34, 161);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(93, 31);
            this.cmdAddHost.TabIndex = 3;
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 16;
            this.lstHost.Location = new System.Drawing.Point(249, 92);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(473, 100);
            this.lstHost.TabIndex = 5;
            // 
            // lblReplsetNameDescription
            // 
            this.lblReplsetNameDescription.Location = new System.Drawing.Point(31, 48);
            this.lblReplsetNameDescription.Name = "lblReplsetNameDescription";
            this.lblReplsetNameDescription.Size = new System.Drawing.Size(707, 41);
            this.lblReplsetNameDescription.TabIndex = 30;
            this.lblReplsetNameDescription.Text = "The driver verifies that the name of the replica set it connects to matches this " +
    "name. Implies that the hosts given are a seed list, and the driver will attempt " +
    "to find all members of the set.";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(31, 27);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(92, 16);
            this.lblMainReplsetName.TabIndex = 28;
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(139, 25);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(170, 22);
            this.txtReplsetName.TabIndex = 0;
            // 
            // tabConnString
            // 
            this.tabConnString.Controls.Add(this.lblConnectionString);
            this.tabConnString.Controls.Add(this.txtConnectionString);
            this.tabConnString.Location = new System.Drawing.Point(4, 25);
            this.tabConnString.Name = "tabConnString";
            this.tabConnString.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnString.Size = new System.Drawing.Size(761, 205);
            this.tabConnString.TabIndex = 1;
            this.tabConnString.Text = "Connection String";
            this.tabConnString.UseVisualStyleBackColor = true;
            // 
            // tabReadWrite
            // 
            this.tabReadWrite.Controls.Add(this.chkUseDefault);
            this.tabReadWrite.Controls.Add(this.lnkWriteConcern);
            this.tabReadWrite.Controls.Add(this.lnkReadPreference);
            this.tabReadWrite.Controls.Add(this.cmbWriteConcern);
            this.tabReadWrite.Controls.Add(this.lblWriteConcern);
            this.tabReadWrite.Controls.Add(this.cmbReadPreference);
            this.tabReadWrite.Controls.Add(this.lblReadPreference);
            this.tabReadWrite.Controls.Add(this.lblWtimeoutDescript);
            this.tabReadWrite.Controls.Add(this.NumWTimeoutMS);
            this.tabReadWrite.Controls.Add(this.lblQueueSize);
            this.tabReadWrite.Controls.Add(this.lblWTimeout);
            this.tabReadWrite.Controls.Add(this.NumWaitQueueSize);
            this.tabReadWrite.Location = new System.Drawing.Point(4, 25);
            this.tabReadWrite.Name = "tabReadWrite";
            this.tabReadWrite.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadWrite.Size = new System.Drawing.Size(761, 205);
            this.tabReadWrite.TabIndex = 4;
            this.tabReadWrite.Text = "Read Write";
            this.tabReadWrite.UseVisualStyleBackColor = true;
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Location = new System.Drawing.Point(43, 24);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new System.Drawing.Size(172, 20);
            this.chkUseDefault.TabIndex = 64;
            this.chkUseDefault.Text = "Use Tool Default Setting";
            this.chkUseDefault.UseVisualStyleBackColor = true;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new System.Drawing.Point(360, 163);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new System.Drawing.Size(127, 16);
            this.lnkWriteConcern.TabIndex = 63;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "About WriteConcern";
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new System.Drawing.Point(361, 139);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new System.Drawing.Size(146, 16);
            this.lnkReadPreference.TabIndex = 62;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "About ReadPreference";
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new System.Drawing.Point(164, 163);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new System.Drawing.Size(170, 24);
            this.cmbWriteConcern.TabIndex = 61;
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new System.Drawing.Point(42, 163);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new System.Drawing.Size(89, 16);
            this.lblWriteConcern.TabIndex = 60;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new System.Drawing.Point(164, 136);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new System.Drawing.Size(170, 24);
            this.cmbReadPreference.TabIndex = 59;
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new System.Drawing.Point(42, 136);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new System.Drawing.Size(108, 16);
            this.lblReadPreference.TabIndex = 58;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(167, 86);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(480, 16);
            this.lblWtimeoutDescript.TabIndex = 57;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(164, 56);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(87, 22);
            this.NumWTimeoutMS.TabIndex = 53;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(40, 108);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(101, 16);
            this.lblQueueSize.TabIndex = 55;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(42, 59);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(88, 16);
            this.lblWTimeout.TabIndex = 56;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(164, 106);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(87, 22);
            this.NumWaitQueueSize.TabIndex = 54;
            this.NumWaitQueueSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 304);
            this.Controls.Add(this.tabConnection);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Connection";
            this.Load += new System.EventHandler(this.frmAddConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabConnection.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).EndInit();
            this.tabReplicaSet.ResumeLayout(false);
            this.tabReplicaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            this.tabConnString.ResumeLayout(false);
            this.tabConnString.PerformLayout();
            this.tabReadWrite.ResumeLayout(false);
            this.tabReadWrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblConnectionName;
        private System.Windows.Forms.Label lblHost;
        private TextBox txtConnectionName;
        private TextBox txtHost;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtDataBaseName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private Label lblAttentionPassword;
        private NumericUpDown numPort;
        private Button cmdTest;
        private TabControl tabConnection;
        private TabPage tabBasic;
        private TabPage tabConnString;
        private TabPage tabReplicaSet;
        private Label lblMainReplsetName;
        private TextBox txtReplsetName;
        private Label lblReplsetNameDescription;
        private Label label7;
        private ListBox lstHost;
        private Button cmdAddHost;
        private NumericUpDown NumReplPort;
        private Label lblReplPort;
        private TextBox txtReplHost;
        private Label lblReplHost;
        private Button cmdRemoveHost;
        private CheckBox chkVerifySslCertificate;
        private CheckBox chkUseSsl;
        private CheckBox chkJournal;
        private CheckBox chkFsync;
        private NumericUpDown NumConnectTimeOut;
        private NumericUpDown NumSocketTimeOut;
        private Label lblConnectTimeout;
        private Label lblsocketTimeout;
        private TabPage tabReadWrite;
        private CheckBox chkUseDefault;
        private LinkLabel lnkWriteConcern;
        private LinkLabel lnkReadPreference;
        private ComboBox cmbWriteConcern;
        private Label lblWriteConcern;
        private ComboBox cmbReadPreference;
        private Label lblReadPreference;
        private Label lblWtimeoutDescript;
        private NumericUpDown NumWTimeoutMS;
        private Label lblQueueSize;
        private Label lblWTimeout;
        private NumericUpDown NumWaitQueueSize;
    }
}