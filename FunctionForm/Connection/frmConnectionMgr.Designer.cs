using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Connection
{
    partial class FrmConnectionMgr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.intPort = new System.Windows.Forms.NumericUpDown();
            this.cmdTest = new System.Windows.Forms.Button();
            this.tabConnection = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.lblAttentionPassword = new System.Windows.Forms.Label();
            this.tabReplicaSet = new System.Windows.Forms.TabPage();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.intReplPort = new System.Windows.Forms.NumericUpDown();
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
            this.ConnectionReadWrite = new FunctionForm.Connection.CtlReadWriteConfig();
            this.tabOptional = new System.Windows.Forms.TabPage();
            this.cmbStorageEngine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVerifySslCertificate = new System.Windows.Forms.CheckBox();
            this.chkUseSsl = new System.Windows.Forms.CheckBox();
            this.chkJournal = new System.Windows.Forms.CheckBox();
            this.chkFsync = new System.Windows.Forms.CheckBox();
            this.dblConnectTimeOut = new System.Windows.Forms.NumericUpDown();
            this.dblSocketTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblConnectTimeout = new System.Windows.Forms.Label();
            this.lblsocketTimeout = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabSSH = new System.Windows.Forms.TabPage();
            this.ctlSSHConfig1 = new FunctionForm.Connection.CtlSshConfig();
            this.tabSSL = new System.Windows.Forms.TabPage();
            this.ctlSSLConfig1 = new FunctionForm.Connection.CtlSslConfig();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radMONGODB_X509 = new System.Windows.Forms.RadioButton();
            this.radMONGODB_CR = new System.Windows.Forms.RadioButton();
            this.radSCRAM_SHA_1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.intPort)).BeginInit();
            this.tabConnection.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabReplicaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intReplPort)).BeginInit();
            this.tabConnString.SuspendLayout();
            this.tabReadWrite.SuspendLayout();
            this.tabOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dblConnectTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblSocketTimeOut)).BeginInit();
            this.tabSSH.SuspendLayout();
            this.tabSSL.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(583, 237);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(98, 31);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Tag = "Common_Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(480, 237);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(98, 31);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Tag = "Common_Add";
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(228, 69);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 15);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Tag = "Common_Password";
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Location = new System.Drawing.Point(22, 69);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(67, 15);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Tag = "Common_Username";
            this.lblUsername.Text = "UserName";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Location = new System.Drawing.Point(422, 37);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 15);
            this.lblPort.TabIndex = 4;
            this.lblPort.Tag = "Common_Port";
            this.lblPort.Text = "Port";
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.AutoSize = true;
            this.lblConnectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionName.Location = new System.Drawing.Point(20, 38);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(69, 15);
            this.lblConnectionName.TabIndex = 0;
            this.lblConnectionName.Tag = "AddConnection_ConnectionName";
            this.lblConnectionName.Text = "Connection";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Location = new System.Drawing.Point(228, 34);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 15);
            this.lblHost.TabIndex = 1;
            this.lblHost.Tag = "Common_Host";
            this.lblHost.Text = "Host";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(102, 32);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(119, 21);
            this.txtConnectionName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(294, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHost.Location = new System.Drawing.Point(294, 28);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(119, 21);
            this.txtHost.TabIndex = 1;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(423, 69);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(60, 15);
            this.lblDataBaseName.TabIndex = 10;
            this.lblDataBaseName.Tag = "AddConnection_DBName";
            this.lblDataBaseName.Text = "Database";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(502, 63);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(119, 21);
            this.txtDataBaseName.TabIndex = 5;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(9, 31);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(639, 135);
            this.txtConnectionString.TabIndex = 0;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(6, 13);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(172, 15);
            this.lblConnectionString.TabIndex = 16;
            this.lblConnectionString.Tag = "AddConnection_ConnectionString";
            this.lblConnectionString.Text = "Use ConnectionString Directly:";
            // 
            // intPort
            // 
            this.intPort.Location = new System.Drawing.Point(501, 27);
            this.intPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.intPort.Name = "intPort";
            this.intPort.Size = new System.Drawing.Size(118, 21);
            this.intPort.TabIndex = 2;
            this.intPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(331, 237);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(143, 31);
            this.cmdTest.TabIndex = 2;
            this.cmdTest.Tag = "Common_Test";
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
            this.tabConnection.Controls.Add(this.tabOptional);
            this.tabConnection.Controls.Add(this.tabSSH);
            this.tabConnection.Controls.Add(this.tabSSL);
            this.tabConnection.Controls.Add(this.tabPage1);
            this.tabConnection.Location = new System.Drawing.Point(12, 12);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.SelectedIndex = 0;
            this.tabConnection.Size = new System.Drawing.Size(673, 219);
            this.tabConnection.TabIndex = 0;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.lblAttentionPassword);
            this.tabBasic.Controls.Add(this.intPort);
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
            this.tabBasic.Location = new System.Drawing.Point(4, 24);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(665, 191);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // lblAttentionPassword
            // 
            this.lblAttentionPassword.AutoSize = true;
            this.lblAttentionPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttentionPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAttentionPassword.Location = new System.Drawing.Point(22, 105);
            this.lblAttentionPassword.Name = "lblAttentionPassword";
            this.lblAttentionPassword.Size = new System.Drawing.Size(295, 13);
            this.lblAttentionPassword.TabIndex = 47;
            this.lblAttentionPassword.Tag = "AddConnection_Password_Description";
            this.lblAttentionPassword.Text = "Password is saved in config file without Encryption";
            // 
            // tabReplicaSet
            // 
            this.tabReplicaSet.Controls.Add(this.cmdRemoveHost);
            this.tabReplicaSet.Controls.Add(this.intReplPort);
            this.tabReplicaSet.Controls.Add(this.lblReplPort);
            this.tabReplicaSet.Controls.Add(this.txtReplHost);
            this.tabReplicaSet.Controls.Add(this.lblReplHost);
            this.tabReplicaSet.Controls.Add(this.cmdAddHost);
            this.tabReplicaSet.Controls.Add(this.lstHost);
            this.tabReplicaSet.Controls.Add(this.lblReplsetNameDescription);
            this.tabReplicaSet.Controls.Add(this.lblMainReplsetName);
            this.tabReplicaSet.Controls.Add(this.txtReplsetName);
            this.tabReplicaSet.Location = new System.Drawing.Point(4, 24);
            this.tabReplicaSet.Name = "tabReplicaSet";
            this.tabReplicaSet.Size = new System.Drawing.Size(665, 191);
            this.tabReplicaSet.TabIndex = 3;
            this.tabReplicaSet.Text = "ReplicaSet";
            this.tabReplicaSet.UseVisualStyleBackColor = true;
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(116, 153);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(94, 25);
            this.cmdRemoveHost.TabIndex = 4;
            this.cmdRemoveHost.Tag = "AddConnection_Region_RemoveHost";
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // intReplPort
            // 
            this.intReplPort.Location = new System.Drawing.Point(94, 112);
            this.intReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.intReplPort.Name = "intReplPort";
            this.intReplPort.Size = new System.Drawing.Size(118, 21);
            this.intReplPort.TabIndex = 2;
            this.intReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(27, 114);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(29, 15);
            this.lblReplPort.TabIndex = 35;
            this.lblReplPort.Tag = "Common_Port";
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(93, 86);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(119, 21);
            this.txtReplHost.TabIndex = 1;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(27, 86);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(32, 15);
            this.lblReplHost.TabIndex = 33;
            this.lblReplHost.Tag = "Common_Host";
            this.lblReplHost.Text = "Host";
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(30, 151);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(81, 29);
            this.cmdAddHost.TabIndex = 3;
            this.cmdAddHost.Tag = "AddConnection_Region_AddHost";
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 15;
            this.lstHost.Location = new System.Drawing.Point(218, 86);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(414, 94);
            this.lstHost.TabIndex = 5;
            // 
            // lblReplsetNameDescription
            // 
            this.lblReplsetNameDescription.Location = new System.Drawing.Point(27, 45);
            this.lblReplsetNameDescription.Name = "lblReplsetNameDescription";
            this.lblReplsetNameDescription.Size = new System.Drawing.Size(619, 38);
            this.lblReplsetNameDescription.TabIndex = 30;
            this.lblReplsetNameDescription.Text = "The driver verifies that the name of the replica set it connects to matches this " +
    "name. Implies that the hosts given are a seed list, and the driver will attempt " +
    "to find all members of the set.";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(27, 25);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(83, 15);
            this.lblMainReplsetName.TabIndex = 28;
            this.lblMainReplsetName.Tag = "AddConnection_MainReplsetName";
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(122, 23);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(149, 21);
            this.txtReplsetName.TabIndex = 0;
            // 
            // tabConnString
            // 
            this.tabConnString.Controls.Add(this.lblConnectionString);
            this.tabConnString.Controls.Add(this.txtConnectionString);
            this.tabConnString.Location = new System.Drawing.Point(4, 24);
            this.tabConnString.Name = "tabConnString";
            this.tabConnString.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnString.Size = new System.Drawing.Size(665, 191);
            this.tabConnString.TabIndex = 1;
            this.tabConnString.Text = "Connection String";
            this.tabConnString.UseVisualStyleBackColor = true;
            // 
            // tabReadWrite
            // 
            this.tabReadWrite.Controls.Add(this.ConnectionReadWrite);
            this.tabReadWrite.Location = new System.Drawing.Point(4, 24);
            this.tabReadWrite.Name = "tabReadWrite";
            this.tabReadWrite.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadWrite.Size = new System.Drawing.Size(665, 191);
            this.tabReadWrite.TabIndex = 4;
            this.tabReadWrite.Text = "Read Write";
            this.tabReadWrite.UseVisualStyleBackColor = true;
            // 
            // ConnectionReadWrite
            // 
            this.ConnectionReadWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectionReadWrite.Location = new System.Drawing.Point(3, 3);
            this.ConnectionReadWrite.Name = "ConnectionReadWrite";
            this.ConnectionReadWrite.Size = new System.Drawing.Size(659, 185);
            this.ConnectionReadWrite.TabIndex = 0;
            // 
            // tabOptional
            // 
            this.tabOptional.Controls.Add(this.cmbStorageEngine);
            this.tabOptional.Controls.Add(this.label1);
            this.tabOptional.Controls.Add(this.chkVerifySslCertificate);
            this.tabOptional.Controls.Add(this.chkUseSsl);
            this.tabOptional.Controls.Add(this.chkJournal);
            this.tabOptional.Controls.Add(this.chkFsync);
            this.tabOptional.Controls.Add(this.dblConnectTimeOut);
            this.tabOptional.Controls.Add(this.dblSocketTimeOut);
            this.tabOptional.Controls.Add(this.lblConnectTimeout);
            this.tabOptional.Controls.Add(this.lblsocketTimeout);
            this.tabOptional.Controls.Add(this.label7);
            this.tabOptional.Location = new System.Drawing.Point(4, 24);
            this.tabOptional.Name = "tabOptional";
            this.tabOptional.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptional.Size = new System.Drawing.Size(665, 191);
            this.tabOptional.TabIndex = 5;
            this.tabOptional.Text = "Optional";
            this.tabOptional.UseVisualStyleBackColor = true;
            // 
            // cmbStorageEngine
            // 
            this.cmbStorageEngine.FormattingEnabled = true;
            this.cmbStorageEngine.Location = new System.Drawing.Point(143, 114);
            this.cmbStorageEngine.Name = "cmbStorageEngine";
            this.cmbStorageEngine.Size = new System.Drawing.Size(121, 23);
            this.cmbStorageEngine.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "StorageEngine";
            // 
            // chkVerifySslCertificate
            // 
            this.chkVerifySslCertificate.AutoSize = true;
            this.chkVerifySslCertificate.Location = new System.Drawing.Point(253, 85);
            this.chkVerifySslCertificate.Name = "chkVerifySslCertificate";
            this.chkVerifySslCertificate.Size = new System.Drawing.Size(126, 19);
            this.chkVerifySslCertificate.TabIndex = 55;
            this.chkVerifySslCertificate.Text = "VerifySslCertificate";
            this.chkVerifySslCertificate.UseVisualStyleBackColor = true;
            // 
            // chkUseSsl
            // 
            this.chkUseSsl.AutoSize = true;
            this.chkUseSsl.Location = new System.Drawing.Point(174, 85);
            this.chkUseSsl.Name = "chkUseSsl";
            this.chkUseSsl.Size = new System.Drawing.Size(65, 19);
            this.chkUseSsl.TabIndex = 54;
            this.chkUseSsl.Text = "UseSsl";
            this.chkUseSsl.UseVisualStyleBackColor = true;
            // 
            // chkJournal
            // 
            this.chkJournal.AutoSize = true;
            this.chkJournal.Location = new System.Drawing.Point(104, 85);
            this.chkJournal.Name = "chkJournal";
            this.chkJournal.Size = new System.Drawing.Size(64, 19);
            this.chkJournal.TabIndex = 51;
            this.chkJournal.Text = "journal";
            this.chkJournal.UseVisualStyleBackColor = true;
            // 
            // chkFsync
            // 
            this.chkFsync.AutoSize = true;
            this.chkFsync.Location = new System.Drawing.Point(27, 85);
            this.chkFsync.Name = "chkFsync";
            this.chkFsync.Size = new System.Drawing.Size(53, 19);
            this.chkFsync.TabIndex = 50;
            this.chkFsync.Text = "fsync";
            this.chkFsync.UseVisualStyleBackColor = true;
            // 
            // dblConnectTimeOut
            // 
            this.dblConnectTimeOut.Location = new System.Drawing.Point(387, 56);
            this.dblConnectTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.dblConnectTimeOut.Name = "dblConnectTimeOut";
            this.dblConnectTimeOut.Size = new System.Drawing.Size(76, 21);
            this.dblConnectTimeOut.TabIndex = 49;
            this.dblConnectTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dblSocketTimeOut
            // 
            this.dblSocketTimeOut.Location = new System.Drawing.Point(158, 54);
            this.dblSocketTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.dblSocketTimeOut.Name = "dblSocketTimeOut";
            this.dblSocketTimeOut.Size = new System.Drawing.Size(76, 21);
            this.dblSocketTimeOut.TabIndex = 48;
            this.dblSocketTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblConnectTimeout
            // 
            this.lblConnectTimeout.AutoSize = true;
            this.lblConnectTimeout.Location = new System.Drawing.Point(250, 56);
            this.lblConnectTimeout.Name = "lblConnectTimeout";
            this.lblConnectTimeout.Size = new System.Drawing.Size(122, 15);
            this.lblConnectTimeout.TabIndex = 52;
            this.lblConnectTimeout.Tag = "AddConnection_ConnectionTimeOut";
            this.lblConnectTimeout.Text = "connectTimeout(MS)";
            // 
            // lblsocketTimeout
            // 
            this.lblsocketTimeout.AutoSize = true;
            this.lblsocketTimeout.Location = new System.Drawing.Point(24, 59);
            this.lblsocketTimeout.Name = "lblsocketTimeout";
            this.lblsocketTimeout.Size = new System.Drawing.Size(114, 15);
            this.lblsocketTimeout.TabIndex = 53;
            this.lblsocketTimeout.Tag = "AddConnection_SocketTimeOut";
            this.lblsocketTimeout.Text = "socketTimeout(MS)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(433, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "If you want to connect to a replSet please  fill  replset information at  replset" +
    " tab.";
            // 
            // tabSSH
            // 
            this.tabSSH.Controls.Add(this.ctlSSHConfig1);
            this.tabSSH.Location = new System.Drawing.Point(4, 24);
            this.tabSSH.Name = "tabSSH";
            this.tabSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tabSSH.Size = new System.Drawing.Size(665, 191);
            this.tabSSH.TabIndex = 6;
            this.tabSSH.Text = "SSH";
            this.tabSSH.UseVisualStyleBackColor = true;
            // 
            // ctlSSHConfig1
            // 
            this.ctlSSHConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSSHConfig1.Location = new System.Drawing.Point(3, 3);
            this.ctlSSHConfig1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlSSHConfig1.Name = "ctlSSHConfig1";
            this.ctlSSHConfig1.Size = new System.Drawing.Size(659, 185);
            this.ctlSSHConfig1.TabIndex = 0;
            // 
            // tabSSL
            // 
            this.tabSSL.Controls.Add(this.ctlSSLConfig1);
            this.tabSSL.Location = new System.Drawing.Point(4, 24);
            this.tabSSL.Name = "tabSSL";
            this.tabSSL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSSL.Size = new System.Drawing.Size(665, 191);
            this.tabSSL.TabIndex = 7;
            this.tabSSL.Text = "SSL";
            this.tabSSL.UseVisualStyleBackColor = true;
            // 
            // ctlSSLConfig1
            // 
            this.ctlSSLConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSSLConfig1.Location = new System.Drawing.Point(3, 3);
            this.ctlSSLConfig1.Name = "ctlSSLConfig1";
            this.ctlSSLConfig1.Size = new System.Drawing.Size(659, 185);
            this.ctlSSLConfig1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radMONGODB_X509);
            this.tabPage1.Controls.Add(this.radMONGODB_CR);
            this.tabPage1.Controls.Add(this.radSCRAM_SHA_1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 191);
            this.tabPage1.TabIndex = 8;
            this.tabPage1.Text = "AuthMechanism";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radMONGODB_X509
            // 
            this.radMONGODB_X509.AutoSize = true;
            this.radMONGODB_X509.Location = new System.Drawing.Point(41, 77);
            this.radMONGODB_X509.Name = "radMONGODB_X509";
            this.radMONGODB_X509.Size = new System.Drawing.Size(122, 19);
            this.radMONGODB_X509.TabIndex = 0;
            this.radMONGODB_X509.Text = "MONGODB-X509";
            this.radMONGODB_X509.UseVisualStyleBackColor = true;
            // 
            // radMONGODB_CR
            // 
            this.radMONGODB_CR.AutoSize = true;
            this.radMONGODB_CR.Location = new System.Drawing.Point(41, 52);
            this.radMONGODB_CR.Name = "radMONGODB_CR";
            this.radMONGODB_CR.Size = new System.Drawing.Size(110, 19);
            this.radMONGODB_CR.TabIndex = 0;
            this.radMONGODB_CR.Text = "MONGODB-CR";
            this.radMONGODB_CR.UseVisualStyleBackColor = true;
            // 
            // radSCRAM_SHA_1
            // 
            this.radSCRAM_SHA_1.AutoSize = true;
            this.radSCRAM_SHA_1.Checked = true;
            this.radSCRAM_SHA_1.Location = new System.Drawing.Point(41, 27);
            this.radSCRAM_SHA_1.Name = "radSCRAM_SHA_1";
            this.radSCRAM_SHA_1.Size = new System.Drawing.Size(154, 19);
            this.radSCRAM_SHA_1.TabIndex = 0;
            this.radSCRAM_SHA_1.TabStop = true;
            this.radSCRAM_SHA_1.Text = "Default(SCRAM-SHA-1)";
            this.radSCRAM_SHA_1.UseVisualStyleBackColor = true;
            // 
            // FrmConnectionMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 285);
            this.Controls.Add(this.tabConnection);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnectionMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "AddConnection_Title";
            this.Text = "Server Connection";
            this.Load += new System.EventHandler(this.frmAddConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intPort)).EndInit();
            this.tabConnection.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabReplicaSet.ResumeLayout(false);
            this.tabReplicaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intReplPort)).EndInit();
            this.tabConnString.ResumeLayout(false);
            this.tabConnString.PerformLayout();
            this.tabReadWrite.ResumeLayout(false);
            this.tabOptional.ResumeLayout(false);
            this.tabOptional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dblConnectTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dblSocketTimeOut)).EndInit();
            this.tabSSH.ResumeLayout(false);
            this.tabSSL.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion

        private Button cmdCancel;
        private Button cmdAdd;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblPort;
        private Label lblConnectionName;
        private Label lblHost;
        private TextBox txtConnectionName;
        private TextBox txtHost;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtDataBaseName;
        private Label lblDataBaseName;
        private Label lblConnectionString;
        private TextBox txtConnectionString;
        private NumericUpDown intPort;
        private Button cmdTest;
        private TabControl tabConnection;
        private TabPage tabBasic;
        private TabPage tabConnString;
        private TabPage tabReplicaSet;
        private Label lblMainReplsetName;
        private TextBox txtReplsetName;
        private Label lblReplsetNameDescription;
        private ListBox lstHost;
        private Button cmdAddHost;
        private NumericUpDown intReplPort;
        private Label lblReplPort;
        private TextBox txtReplHost;
        private Label lblReplHost;
        private Button cmdRemoveHost;
        private TabPage tabReadWrite;
        private TabPage tabOptional;
        private ComboBox cmbStorageEngine;
        private Label label1;
        private CheckBox chkVerifySslCertificate;
        private CheckBox chkUseSsl;
        private CheckBox chkJournal;
        private CheckBox chkFsync;
        private NumericUpDown dblConnectTimeOut;
        private NumericUpDown dblSocketTimeOut;
        private Label lblConnectTimeout;
        private Label lblsocketTimeout;
        private Label label7;
        private CtlReadWriteConfig ConnectionReadWrite;
        private TabPage tabSSH;
        private CtlSshConfig ctlSSHConfig1;
        private TabPage tabSSL;
        private CtlSslConfig ctlSSLConfig1;
        private Label lblAttentionPassword;
        private TabPage tabPage1;
        private RadioButton radMONGODB_CR;
        private RadioButton radSCRAM_SHA_1;
        private RadioButton radMONGODB_X509;
    }
}