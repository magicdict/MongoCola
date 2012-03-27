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
            this.label7 = new System.Windows.Forms.Label();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.lblWtimeoutDescript = new System.Windows.Forms.Label();
            this.NumWTimeoutMS = new System.Windows.Forms.NumericUpDown();
            this.lblQueueSize = new System.Windows.Forms.Label();
            this.lblWTimeout = new System.Windows.Forms.Label();
            this.chkJournal = new System.Windows.Forms.CheckBox();
            this.chkFsync = new System.Windows.Forms.CheckBox();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.NumWaitQueueSize = new System.Windows.Forms.NumericUpDown();
            this.NumConnectTimeOut = new System.Windows.Forms.NumericUpDown();
            this.NumSocketTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblConnectTimeout = new System.Windows.Forms.Label();
            this.lblsocketTimeout = new System.Windows.Forms.Label();
            this.chkSafeMode = new System.Windows.Forms.CheckBox();
            this.tabreplicaSet = new System.Windows.Forms.TabPage();
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
            this.tabConnectionS = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabConnection.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).BeginInit();
            this.tabreplicaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            this.tabConnectionS.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(481, 253);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(112, 33);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(185, 253);
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
            this.cmdTest.Location = new System.Drawing.Point(339, 253);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(112, 33);
            this.cmdTest.TabIndex = 2;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.tabBasic);
            this.tabConnection.Controls.Add(this.tabOption);
            this.tabConnection.Controls.Add(this.tabreplicaSet);
            this.tabConnection.Controls.Add(this.tabConnectionS);
            this.tabConnection.Location = new System.Drawing.Point(14, 13);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.SelectedIndex = 0;
            this.tabConnection.Size = new System.Drawing.Size(769, 234);
            this.tabConnection.TabIndex = 0;
            // 
            // tabBasic
            // 
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(588, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "If you try to connect to a replica Set please don\'t fill any thing at this tab ex" +
    "cept the connectionName";
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.lblWtimeoutDescript);
            this.tabOption.Controls.Add(this.NumWTimeoutMS);
            this.tabOption.Controls.Add(this.lblQueueSize);
            this.tabOption.Controls.Add(this.lblWTimeout);
            this.tabOption.Controls.Add(this.chkJournal);
            this.tabOption.Controls.Add(this.chkFsync);
            this.tabOption.Controls.Add(this.chkSlaveOk);
            this.tabOption.Controls.Add(this.NumWaitQueueSize);
            this.tabOption.Controls.Add(this.NumConnectTimeOut);
            this.tabOption.Controls.Add(this.NumSocketTimeOut);
            this.tabOption.Controls.Add(this.lblConnectTimeout);
            this.tabOption.Controls.Add(this.lblsocketTimeout);
            this.tabOption.Controls.Add(this.chkSafeMode);
            this.tabOption.Location = new System.Drawing.Point(4, 25);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(761, 205);
            this.tabOption.TabIndex = 2;
            this.tabOption.Text = "Option";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(242, 85);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(480, 16);
            this.lblWtimeoutDescript.TabIndex = 33;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(154, 82);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(87, 22);
            this.NumWTimeoutMS.TabIndex = 6;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(30, 113);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(101, 16);
            this.lblQueueSize.TabIndex = 30;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(32, 85);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(88, 16);
            this.lblWTimeout.TabIndex = 30;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // chkJournal
            // 
            this.chkJournal.AutoSize = true;
            this.chkJournal.Location = new System.Drawing.Point(232, 49);
            this.chkJournal.Name = "chkJournal";
            this.chkJournal.Size = new System.Drawing.Size(67, 20);
            this.chkJournal.TabIndex = 4;
            this.chkJournal.Text = "journal";
            this.chkJournal.UseVisualStyleBackColor = true;
            // 
            // chkFsync
            // 
            this.chkFsync.AutoSize = true;
            this.chkFsync.Location = new System.Drawing.Point(146, 49);
            this.chkFsync.Name = "chkFsync";
            this.chkFsync.Size = new System.Drawing.Size(58, 20);
            this.chkFsync.TabIndex = 3;
            this.chkFsync.Text = "fsync";
            this.chkFsync.UseVisualStyleBackColor = true;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.BackColor = System.Drawing.Color.Transparent;
            this.chkSlaveOk.Location = new System.Drawing.Point(312, 49);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(80, 20);
            this.chkSlaveOk.TabIndex = 5;
            this.chkSlaveOk.Text = "SlaveOK";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(154, 111);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(87, 22);
            this.NumWaitQueueSize.TabIndex = 7;
            this.NumWaitQueueSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumConnectTimeOut
            // 
            this.NumConnectTimeOut.Location = new System.Drawing.Point(445, 16);
            this.NumConnectTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumConnectTimeOut.Name = "NumConnectTimeOut";
            this.NumConnectTimeOut.Size = new System.Drawing.Size(87, 22);
            this.NumConnectTimeOut.TabIndex = 1;
            this.NumConnectTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumSocketTimeOut
            // 
            this.NumSocketTimeOut.Location = new System.Drawing.Point(183, 14);
            this.NumSocketTimeOut.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumSocketTimeOut.Name = "NumSocketTimeOut";
            this.NumSocketTimeOut.Size = new System.Drawing.Size(87, 22);
            this.NumSocketTimeOut.TabIndex = 0;
            this.NumSocketTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblConnectTimeout
            // 
            this.lblConnectTimeout.AutoSize = true;
            this.lblConnectTimeout.Location = new System.Drawing.Point(288, 16);
            this.lblConnectTimeout.Name = "lblConnectTimeout";
            this.lblConnectTimeout.Size = new System.Drawing.Size(132, 16);
            this.lblConnectTimeout.TabIndex = 22;
            this.lblConnectTimeout.Text = "connectTimeout(MS)";
            // 
            // lblsocketTimeout
            // 
            this.lblsocketTimeout.AutoSize = true;
            this.lblsocketTimeout.Location = new System.Drawing.Point(30, 19);
            this.lblsocketTimeout.Name = "lblsocketTimeout";
            this.lblsocketTimeout.Size = new System.Drawing.Size(125, 16);
            this.lblsocketTimeout.TabIndex = 22;
            this.lblsocketTimeout.Text = "socketTimeout(MS)";
            // 
            // chkSafeMode
            // 
            this.chkSafeMode.AutoSize = true;
            this.chkSafeMode.Location = new System.Drawing.Point(33, 49);
            this.chkSafeMode.Name = "chkSafeMode";
            this.chkSafeMode.Size = new System.Drawing.Size(90, 20);
            this.chkSafeMode.TabIndex = 2;
            this.chkSafeMode.Text = "SafeMode";
            this.chkSafeMode.UseVisualStyleBackColor = true;
            // 
            // tabreplicaSet
            // 
            this.tabreplicaSet.Controls.Add(this.cmdRemoveHost);
            this.tabreplicaSet.Controls.Add(this.NumReplPort);
            this.tabreplicaSet.Controls.Add(this.lblReplPort);
            this.tabreplicaSet.Controls.Add(this.txtReplHost);
            this.tabreplicaSet.Controls.Add(this.lblReplHost);
            this.tabreplicaSet.Controls.Add(this.cmdAddHost);
            this.tabreplicaSet.Controls.Add(this.lstHost);
            this.tabreplicaSet.Controls.Add(this.lblReplsetNameDescription);
            this.tabreplicaSet.Controls.Add(this.lblMainReplsetName);
            this.tabreplicaSet.Controls.Add(this.txtReplsetName);
            this.tabreplicaSet.Location = new System.Drawing.Point(4, 25);
            this.tabreplicaSet.Name = "tabreplicaSet";
            this.tabreplicaSet.Size = new System.Drawing.Size(761, 205);
            this.tabreplicaSet.TabIndex = 3;
            this.tabreplicaSet.Text = "replicaSet";
            this.tabreplicaSet.UseVisualStyleBackColor = true;
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
            // tabConnectionS
            // 
            this.tabConnectionS.Controls.Add(this.lblConnectionString);
            this.tabConnectionS.Controls.Add(this.txtConnectionString);
            this.tabConnectionS.Location = new System.Drawing.Point(4, 25);
            this.tabConnectionS.Name = "tabConnectionS";
            this.tabConnectionS.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectionS.Size = new System.Drawing.Size(761, 205);
            this.tabConnectionS.TabIndex = 1;
            this.tabConnectionS.Text = "Connection String";
            this.tabConnectionS.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabConnection.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).EndInit();
            this.tabreplicaSet.ResumeLayout(false);
            this.tabreplicaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            this.tabConnectionS.ResumeLayout(false);
            this.tabConnectionS.PerformLayout();
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
        private TabPage tabConnectionS;
        private TabPage tabOption;
        private CheckBox chkSlaveOk;
        private NumericUpDown NumSocketTimeOut;
        private Label lblsocketTimeout;
        private CheckBox chkSafeMode;
        private Label lblConnectTimeout;
        private NumericUpDown NumConnectTimeOut;
        private CheckBox chkFsync;
        private CheckBox chkJournal;
        private NumericUpDown NumWTimeoutMS;
        private Label lblWTimeout;
        private Label lblQueueSize;
        private NumericUpDown NumWaitQueueSize;
        private TabPage tabreplicaSet;
        private Label lblMainReplsetName;
        private TextBox txtReplsetName;
        private Label lblWtimeoutDescript;
        private Label lblReplsetNameDescription;
        private Label label7;
        private ListBox lstHost;
        private Button cmdAddHost;
        private NumericUpDown NumReplPort;
        private Label lblReplPort;
        private TextBox txtReplHost;
        private Label lblReplHost;
        private Button cmdRemoveHost;
    }
}