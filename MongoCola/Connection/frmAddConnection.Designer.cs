using System.ComponentModel;
using System.Windows.Forms;

namespace MongoCola.Connection
{
    partial class FrmAddConnection
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
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblAttentionPassword = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.tabConnection = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.cmbStorageEngine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.cmdCancel.Location = new System.Drawing.Point(554, 237);
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
            this.cmdAdd.Location = new System.Drawing.Point(451, 237);
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
            this.lblPassword.Location = new System.Drawing.Point(228, 63);
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
            this.lblUsername.Location = new System.Drawing.Point(22, 66);
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
            this.lblPort.Location = new System.Drawing.Point(422, 30);
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
            this.lblConnectionName.Location = new System.Drawing.Point(20, 31);
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
            this.lblHost.Location = new System.Drawing.Point(228, 27);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 15);
            this.lblHost.TabIndex = 1;
            this.lblHost.Tag = "Common_Host";
            this.lblHost.Text = "Host";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(102, 25);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(119, 21);
            this.txtConnectionName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(294, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHost.Location = new System.Drawing.Point(294, 21);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(119, 21);
            this.txtHost.TabIndex = 1;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(423, 64);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(60, 15);
            this.lblDataBaseName.TabIndex = 10;
            this.lblDataBaseName.Tag = "AddConnection_DBName";
            this.lblDataBaseName.Text = "Database";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(502, 56);
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
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(501, 20);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(118, 21);
            this.numPort.TabIndex = 2;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAttentionPassword
            // 
            this.lblAttentionPassword.AutoSize = true;
            this.lblAttentionPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttentionPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAttentionPassword.Location = new System.Drawing.Point(22, 97);
            this.lblAttentionPassword.Name = "lblAttentionPassword";
            this.lblAttentionPassword.Size = new System.Drawing.Size(295, 13);
            this.lblAttentionPassword.TabIndex = 18;
            this.lblAttentionPassword.Tag = "AddConnection_Password_Description";
            this.lblAttentionPassword.Text = "Password is saved in config file without Encryption";
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(64, 237);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(186, 31);
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
            this.tabConnection.Location = new System.Drawing.Point(12, 12);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.SelectedIndex = 0;
            this.tabConnection.Size = new System.Drawing.Size(673, 219);
            this.tabConnection.TabIndex = 0;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.cmbStorageEngine);
            this.tabBasic.Controls.Add(this.label1);
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
            this.tabBasic.Location = new System.Drawing.Point(4, 24);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(665, 191);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // cmbStorageEngine
            // 
            this.cmbStorageEngine.FormattingEnabled = true;
            this.cmbStorageEngine.Location = new System.Drawing.Point(502, 157);
            this.cmbStorageEngine.Name = "cmbStorageEngine";
            this.cmbStorageEngine.Size = new System.Drawing.Size(121, 23);
            this.cmbStorageEngine.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "StorageEngine";
            // 
            // chkVerifySslCertificate
            // 
            this.chkVerifySslCertificate.AutoSize = true;
            this.chkVerifySslCertificate.Location = new System.Drawing.Point(251, 162);
            this.chkVerifySslCertificate.Name = "chkVerifySslCertificate";
            this.chkVerifySslCertificate.Size = new System.Drawing.Size(126, 19);
            this.chkVerifySslCertificate.TabIndex = 43;
            this.chkVerifySslCertificate.Text = "VerifySslCertificate";
            this.chkVerifySslCertificate.UseVisualStyleBackColor = true;
            // 
            // chkUseSsl
            // 
            this.chkUseSsl.AutoSize = true;
            this.chkUseSsl.Location = new System.Drawing.Point(172, 162);
            this.chkUseSsl.Name = "chkUseSsl";
            this.chkUseSsl.Size = new System.Drawing.Size(65, 19);
            this.chkUseSsl.TabIndex = 42;
            this.chkUseSsl.Text = "UseSsl";
            this.chkUseSsl.UseVisualStyleBackColor = true;
            // 
            // chkJournal
            // 
            this.chkJournal.AutoSize = true;
            this.chkJournal.Location = new System.Drawing.Point(102, 162);
            this.chkJournal.Name = "chkJournal";
            this.chkJournal.Size = new System.Drawing.Size(64, 19);
            this.chkJournal.TabIndex = 39;
            this.chkJournal.Text = "journal";
            this.chkJournal.UseVisualStyleBackColor = true;
            // 
            // chkFsync
            // 
            this.chkFsync.AutoSize = true;
            this.chkFsync.Location = new System.Drawing.Point(25, 162);
            this.chkFsync.Name = "chkFsync";
            this.chkFsync.Size = new System.Drawing.Size(53, 19);
            this.chkFsync.TabIndex = 38;
            this.chkFsync.Text = "fsync";
            this.chkFsync.UseVisualStyleBackColor = true;
            // 
            // NumConnectTimeOut
            // 
            this.NumConnectTimeOut.Location = new System.Drawing.Point(385, 133);
            this.NumConnectTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumConnectTimeOut.Name = "NumConnectTimeOut";
            this.NumConnectTimeOut.Size = new System.Drawing.Size(76, 21);
            this.NumConnectTimeOut.TabIndex = 37;
            this.NumConnectTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumSocketTimeOut
            // 
            this.NumSocketTimeOut.Location = new System.Drawing.Point(156, 131);
            this.NumSocketTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumSocketTimeOut.Name = "NumSocketTimeOut";
            this.NumSocketTimeOut.Size = new System.Drawing.Size(76, 21);
            this.NumSocketTimeOut.TabIndex = 36;
            this.NumSocketTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblConnectTimeout
            // 
            this.lblConnectTimeout.AutoSize = true;
            this.lblConnectTimeout.Location = new System.Drawing.Point(248, 133);
            this.lblConnectTimeout.Name = "lblConnectTimeout";
            this.lblConnectTimeout.Size = new System.Drawing.Size(122, 15);
            this.lblConnectTimeout.TabIndex = 40;
            this.lblConnectTimeout.Tag = "AddConnection_ConnectionTimeOut";
            this.lblConnectTimeout.Text = "connectTimeout(MS)";
            // 
            // lblsocketTimeout
            // 
            this.lblsocketTimeout.AutoSize = true;
            this.lblsocketTimeout.Location = new System.Drawing.Point(22, 136);
            this.lblsocketTimeout.Name = "lblsocketTimeout";
            this.lblsocketTimeout.Size = new System.Drawing.Size(114, 15);
            this.lblsocketTimeout.TabIndex = 41;
            this.lblsocketTimeout.Tag = "AddConnection_SocketTimeOut";
            this.lblsocketTimeout.Text = "socketTimeout(MS)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(433, 15);
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
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(94, 112);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(118, 21);
            this.NumReplPort.TabIndex = 2;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.tabReadWrite.Location = new System.Drawing.Point(4, 24);
            this.tabReadWrite.Name = "tabReadWrite";
            this.tabReadWrite.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadWrite.Size = new System.Drawing.Size(665, 191);
            this.tabReadWrite.TabIndex = 4;
            this.tabReadWrite.Text = "Read Write";
            this.tabReadWrite.UseVisualStyleBackColor = true;
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Location = new System.Drawing.Point(38, 22);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new System.Drawing.Size(158, 19);
            this.chkUseDefault.TabIndex = 64;
            this.chkUseDefault.Text = "Use Tool Default Setting";
            this.chkUseDefault.UseVisualStyleBackColor = true;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new System.Drawing.Point(315, 153);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new System.Drawing.Size(115, 15);
            this.lnkWriteConcern.TabIndex = 63;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "About WriteConcern";
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new System.Drawing.Point(316, 130);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new System.Drawing.Size(131, 15);
            this.lnkReadPreference.TabIndex = 62;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "About ReadPreference";
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new System.Drawing.Point(144, 153);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new System.Drawing.Size(149, 23);
            this.cmbWriteConcern.TabIndex = 61;
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new System.Drawing.Point(37, 153);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new System.Drawing.Size(81, 15);
            this.lblWriteConcern.TabIndex = 60;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new System.Drawing.Point(144, 128);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new System.Drawing.Size(149, 23);
            this.cmbReadPreference.TabIndex = 59;
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new System.Drawing.Point(37, 128);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new System.Drawing.Size(97, 15);
            this.lblReadPreference.TabIndex = 58;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(146, 81);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(444, 15);
            this.lblWtimeoutDescript.TabIndex = 57;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(144, 52);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(76, 21);
            this.NumWTimeoutMS.TabIndex = 53;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(35, 101);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(92, 15);
            this.lblQueueSize.TabIndex = 55;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(37, 55);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(84, 15);
            this.lblWTimeout.TabIndex = 56;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(144, 99);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(76, 21);
            this.NumWaitQueueSize.TabIndex = 54;
            this.NumWaitQueueSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmAddConnection
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
            this.Name = "FrmAddConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "AddConnection_Title";
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
        private Label label1;
        private ComboBox cmbStorageEngine;
    }
}