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
            this.tabConnectionS = new System.Windows.Forms.TabPage();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumWTimeoutMS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkJournal = new System.Windows.Forms.CheckBox();
            this.chkFsync = new System.Windows.Forms.CheckBox();
            this.chkSlaveOk = new System.Windows.Forms.CheckBox();
            this.NumW = new System.Windows.Forms.NumericUpDown();
            this.NumConnectTimeOut = new System.Windows.Forms.NumericUpDown();
            this.NumSocketTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.chkSafeMode = new System.Windows.Forms.CheckBox();
            this.tabreplicaSet = new System.Windows.Forms.TabPage();
            this.lstHost = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMainReplsetName = new System.Windows.Forms.Label();
            this.txtReplsetName = new System.Windows.Forms.TextBox();
            this.cmdAddHost = new System.Windows.Forms.Button();
            this.NumReplPort = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReplHost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabConnection.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabConnectionS.SuspendLayout();
            this.tabOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).BeginInit();
            this.tabreplicaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(421, 237);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(98, 31);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdd.Location = new System.Drawing.Point(162, 237);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(98, 31);
            this.cmdAdd.TabIndex = 1;
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
            this.lblConnectionName.Text = "Connection";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.BackColor = System.Drawing.Color.Transparent;
            this.lblHost.Location = new System.Drawing.Point(228, 27);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 15);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(102, 25);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(119, 21);
            this.txtConnectionName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(294, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(119, 21);
            this.txtUsername.TabIndex = 7;
            // 
            // txtHost
            // 
            this.txtHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHost.Location = new System.Drawing.Point(294, 21);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(119, 21);
            this.txtHost.TabIndex = 3;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(423, 64);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.Size = new System.Drawing.Size(60, 15);
            this.lblDataBaseName.TabIndex = 10;
            this.lblDataBaseName.Text = "Database";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(502, 56);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(119, 21);
            this.txtDataBaseName.TabIndex = 11;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(9, 31);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(639, 135);
            this.txtConnectionString.TabIndex = 17;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(6, 13);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(172, 15);
            this.lblConnectionString.TabIndex = 16;
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
            this.numPort.TabIndex = 5;
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
            this.lblAttentionPassword.Text = "Password is saved in config file without Encryption";
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(297, 237);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(98, 31);
            this.cmdTest.TabIndex = 3;
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
            this.tabConnection.Location = new System.Drawing.Point(12, 12);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.SelectedIndex = 0;
            this.tabConnection.Size = new System.Drawing.Size(673, 219);
            this.tabConnection.TabIndex = 12;
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
            this.tabBasic.Location = new System.Drawing.Point(4, 24);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(665, 191);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(385, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "If you try to connect to a replica Set please don\'t fill any thing at this tab";
            // 
            // tabConnectionS
            // 
            this.tabConnectionS.Controls.Add(this.lblConnectionString);
            this.tabConnectionS.Controls.Add(this.txtConnectionString);
            this.tabConnectionS.Location = new System.Drawing.Point(4, 24);
            this.tabConnectionS.Name = "tabConnectionS";
            this.tabConnectionS.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectionS.Size = new System.Drawing.Size(665, 191);
            this.tabConnectionS.TabIndex = 1;
            this.tabConnectionS.Text = "Connection String";
            this.tabConnectionS.UseVisualStyleBackColor = true;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.label5);
            this.tabOption.Controls.Add(this.label4);
            this.tabOption.Controls.Add(this.NumWTimeoutMS);
            this.tabOption.Controls.Add(this.label3);
            this.tabOption.Controls.Add(this.label1);
            this.tabOption.Controls.Add(this.chkJournal);
            this.tabOption.Controls.Add(this.chkFsync);
            this.tabOption.Controls.Add(this.chkSlaveOk);
            this.tabOption.Controls.Add(this.NumW);
            this.tabOption.Controls.Add(this.NumConnectTimeOut);
            this.tabOption.Controls.Add(this.NumSocketTimeOut);
            this.tabOption.Controls.Add(this.label2);
            this.tabOption.Controls.Add(this.lblTimeOut);
            this.tabOption.Controls.Add(this.chkSafeMode);
            this.tabOption.Location = new System.Drawing.Point(4, 24);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(665, 191);
            this.tabOption.TabIndex = 2;
            this.tabOption.Text = "Option";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(444, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(398, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "The driver adds { w : n } to the getLastError command. Implies safe=true.";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(118, 77);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(76, 21);
            this.NumWTimeoutMS.TabIndex = 31;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumWTimeoutMS.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "w";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "wtimeout(MS)";
            // 
            // chkJournal
            // 
            this.chkJournal.AutoSize = true;
            this.chkJournal.Location = new System.Drawing.Point(203, 46);
            this.chkJournal.Name = "chkJournal";
            this.chkJournal.Size = new System.Drawing.Size(64, 19);
            this.chkJournal.TabIndex = 29;
            this.chkJournal.Text = "journal";
            this.chkJournal.UseVisualStyleBackColor = true;
            // 
            // chkFsync
            // 
            this.chkFsync.AutoSize = true;
            this.chkFsync.Location = new System.Drawing.Point(128, 46);
            this.chkFsync.Name = "chkFsync";
            this.chkFsync.Size = new System.Drawing.Size(53, 19);
            this.chkFsync.TabIndex = 28;
            this.chkFsync.Text = "fsync";
            this.chkFsync.UseVisualStyleBackColor = true;
            // 
            // chkSlaveOk
            // 
            this.chkSlaveOk.AutoSize = true;
            this.chkSlaveOk.BackColor = System.Drawing.Color.Transparent;
            this.chkSlaveOk.Location = new System.Drawing.Point(273, 46);
            this.chkSlaveOk.Name = "chkSlaveOk";
            this.chkSlaveOk.Size = new System.Drawing.Size(73, 19);
            this.chkSlaveOk.TabIndex = 21;
            this.chkSlaveOk.Text = "SlaveOK";
            this.chkSlaveOk.UseVisualStyleBackColor = false;
            // 
            // NumW
            // 
            this.NumW.Location = new System.Drawing.Point(118, 104);
            this.NumW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumW.Name = "NumW";
            this.NumW.Size = new System.Drawing.Size(76, 21);
            this.NumW.TabIndex = 23;
            this.NumW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumW.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumConnectTimeOut
            // 
            this.NumConnectTimeOut.Location = new System.Drawing.Point(389, 15);
            this.NumConnectTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumConnectTimeOut.Name = "NumConnectTimeOut";
            this.NumConnectTimeOut.Size = new System.Drawing.Size(76, 21);
            this.NumConnectTimeOut.TabIndex = 23;
            this.NumConnectTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumConnectTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumSocketTimeOut
            // 
            this.NumSocketTimeOut.Location = new System.Drawing.Point(160, 13);
            this.NumSocketTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumSocketTimeOut.Name = "NumSocketTimeOut";
            this.NumSocketTimeOut.Size = new System.Drawing.Size(76, 21);
            this.NumSocketTimeOut.TabIndex = 23;
            this.NumSocketTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumSocketTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "connectTimeout(MS)";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(26, 18);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(114, 15);
            this.lblTimeOut.TabIndex = 22;
            this.lblTimeOut.Text = "socketTimeout(MS)";
            // 
            // chkSafeMode
            // 
            this.chkSafeMode.AutoSize = true;
            this.chkSafeMode.Location = new System.Drawing.Point(29, 46);
            this.chkSafeMode.Name = "chkSafeMode";
            this.chkSafeMode.Size = new System.Drawing.Size(83, 19);
            this.chkSafeMode.TabIndex = 20;
            this.chkSafeMode.Text = "SafeMode";
            this.chkSafeMode.UseVisualStyleBackColor = true;
            // 
            // tabreplicaSet
            // 
            this.tabreplicaSet.Controls.Add(this.NumReplPort);
            this.tabreplicaSet.Controls.Add(this.label8);
            this.tabreplicaSet.Controls.Add(this.txtReplHost);
            this.tabreplicaSet.Controls.Add(this.label9);
            this.tabreplicaSet.Controls.Add(this.cmdAddHost);
            this.tabreplicaSet.Controls.Add(this.lstHost);
            this.tabreplicaSet.Controls.Add(this.label6);
            this.tabreplicaSet.Controls.Add(this.lblMainReplsetName);
            this.tabreplicaSet.Controls.Add(this.txtReplsetName);
            this.tabreplicaSet.Location = new System.Drawing.Point(4, 24);
            this.tabreplicaSet.Name = "tabreplicaSet";
            this.tabreplicaSet.Size = new System.Drawing.Size(665, 191);
            this.tabreplicaSet.TabIndex = 3;
            this.tabreplicaSet.Text = "replicaSet";
            this.tabreplicaSet.UseVisualStyleBackColor = true;
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 15;
            this.lstHost.Location = new System.Drawing.Point(218, 86);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(414, 94);
            this.lstHost.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(27, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(619, 38);
            this.label6.TabIndex = 30;
            this.label6.Text = "The driver verifies that the name of the replica set it connects to matches this " +
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
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(122, 23);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(149, 21);
            this.txtReplsetName.TabIndex = 29;
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(94, 151);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(118, 29);
            this.cmdAddHost.TabIndex = 32;
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
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
            this.NumReplPort.TabIndex = 36;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(27, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(93, 86);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(119, 21);
            this.txtReplHost.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(27, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Host";
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
            this.Name = "frmAddConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Connection";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabConnection.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabConnectionS.ResumeLayout(false);
            this.tabConnectionS.PerformLayout();
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumConnectTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSocketTimeOut)).EndInit();
            this.tabreplicaSet.ResumeLayout(false);
            this.tabreplicaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
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
        private Label lblTimeOut;
        private CheckBox chkSafeMode;
        private Label label2;
        private NumericUpDown NumConnectTimeOut;
        private CheckBox chkFsync;
        private CheckBox chkJournal;
        private NumericUpDown NumWTimeoutMS;
        private Label label1;
        private Label label3;
        private NumericUpDown NumW;
        private Label label4;
        private TabPage tabreplicaSet;
        private Label lblMainReplsetName;
        private TextBox txtReplsetName;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListBox lstHost;
        private Button cmdAddHost;
        private NumericUpDown NumReplPort;
        private Label label8;
        private TextBox txtReplHost;
        private Label label9;
    }
}