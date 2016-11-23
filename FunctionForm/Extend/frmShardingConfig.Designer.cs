using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Extend
{
    partial class FrmShardingConfig
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
            this.cmdAddSharding = new System.Windows.Forms.Button();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.cmbIndexList = new System.Windows.Forms.ComboBox();
            this.cmdShardCollectionSharding = new System.Windows.Forms.Button();
            this.cmdEnableDBSharding = new System.Windows.Forms.Button();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tabSharding = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdRemoveSharding = new System.Windows.Forms.Button();
            this.lstSharding = new System.Windows.Forms.ListBox();
            this.chkAdvance = new System.Windows.Forms.CheckBox();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.NumMaxSize = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblShardingName = new System.Windows.Forms.Label();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.cmdAddHost = new System.Windows.Forms.Button();
            this.lstHost = new System.Windows.Forms.ListBox();
            this.NumReplPort = new System.Windows.Forms.NumericUpDown();
            this.lblReplPort = new System.Windows.Forms.Label();
            this.txtReplHost = new System.Windows.Forms.TextBox();
            this.lblReplHost = new System.Windows.Forms.Label();
            this.lblMainReplsetName = new System.Windows.Forms.Label();
            this.txtReplsetName = new System.Windows.Forms.TextBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.lblnumInitialChunks = new System.Windows.Forms.Label();
            this.numInitialChunks = new System.Windows.Forms.NumericUpDown();
            this.chkUnique = new System.Windows.Forms.CheckBox();
            this.tabZone = new System.Windows.Forms.TabPage();
            this.lstExistShardZone = new System.Windows.Forms.ListView();
            this.lblExistShardTag = new System.Windows.Forms.Label();
            this.cmbShard = new System.Windows.Forms.ComboBox();
            this.btnAddShardZone = new System.Windows.Forms.Button();
            this.txtShardZone = new System.Windows.Forms.TextBox();
            this.lblShardZone = new System.Windows.Forms.Label();
            this.lblShardName = new System.Windows.Forms.Label();
            this.tabZoneRange = new System.Windows.Forms.TabPage();
            this.lstExistShardRange = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShardKeyDB = new System.Windows.Forms.ComboBox();
            this.cmbShardKeyCol = new System.Windows.Forms.ComboBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.lblShardTag = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbTagList = new System.Windows.Forms.ComboBox();
            this.lblShardKeyTo = new System.Windows.Forms.Label();
            this.lblShardKeyFrom = new System.Windows.Forms.Label();
            this.cmdaddZoneRange = new System.Windows.Forms.Button();
            this.ctlBsonValueShardKeyTo = new MongoGUICtl.ctlBsonValueType();
            this.ctlBsonValueShardKeyFrom = new MongoGUICtl.ctlBsonValueType();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tabSharding.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialChunks)).BeginInit();
            this.tabZone.SuspendLayout();
            this.tabZoneRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddSharding
            // 
            this.cmdAddSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSharding.Enabled = false;
            this.cmdAddSharding.Location = new System.Drawing.Point(267, 42);
            this.cmdAddSharding.Name = "cmdAddSharding";
            this.cmdAddSharding.Size = new System.Drawing.Size(223, 33);
            this.cmdAddSharding.TabIndex = 11;
            this.cmdAddSharding.Tag = "ShardingConfig_AddSharding";
            this.cmdAddSharding.Text = "Add Sharding";
            this.cmdAddSharding.UseVisualStyleBackColor = false;
            this.cmdAddSharding.Click += new System.EventHandler(this.cmdAddSharding_Click);
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexName.Location = new System.Drawing.Point(27, 110);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(71, 15);
            this.lblIndexName.TabIndex = 6;
            this.lblIndexName.Tag = "ShardingConfig_FieldName";
            this.lblIndexName.Text = "IndexName";
            // 
            // cmbIndexList
            // 
            this.cmbIndexList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIndexList.FormattingEnabled = true;
            this.cmbIndexList.Location = new System.Drawing.Point(137, 107);
            this.cmbIndexList.Name = "cmbIndexList";
            this.cmbIndexList.Size = new System.Drawing.Size(162, 23);
            this.cmbIndexList.TabIndex = 7;
            // 
            // cmdShardCollectionSharding
            // 
            this.cmdShardCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdShardCollectionSharding.Location = new System.Drawing.Point(316, 71);
            this.cmdShardCollectionSharding.Name = "cmdShardCollectionSharding";
            this.cmdShardCollectionSharding.Size = new System.Drawing.Size(172, 30);
            this.cmdShardCollectionSharding.TabIndex = 5;
            this.cmdShardCollectionSharding.Tag = "ShardingConfig_Action_CollectionSharding";
            this.cmdShardCollectionSharding.Text = "Sharding Collection";
            this.cmdShardCollectionSharding.UseVisualStyleBackColor = false;
            this.cmdShardCollectionSharding.Click += new System.EventHandler(this.cmdShardCollectionSharding_Click);
            // 
            // cmdEnableDBSharding
            // 
            this.cmdEnableDBSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableDBSharding.Location = new System.Drawing.Point(316, 18);
            this.cmdEnableDBSharding.Name = "cmdEnableDBSharding";
            this.cmdEnableDBSharding.Size = new System.Drawing.Size(172, 29);
            this.cmdEnableDBSharding.TabIndex = 2;
            this.cmdEnableDBSharding.Tag = "ShardingConfig_Action_DBSharding";
            this.cmdEnableDBSharding.Text = "Enable Sharding";
            this.cmdEnableDBSharding.UseVisualStyleBackColor = false;
            this.cmdEnableDBSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(137, 74);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(162, 23);
            this.cmbCollection.TabIndex = 4;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(137, 21);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(162, 23);
            this.cmbDataBase.TabIndex = 1;
            this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.BackColor = System.Drawing.Color.Transparent;
            this.lblCollection.Location = new System.Drawing.Point(27, 77);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(95, 15);
            this.lblCollection.TabIndex = 3;
            this.lblCollection.Tag = "Common.Collection";
            this.lblCollection.Text = "CollectionName";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.BackColor = System.Drawing.Color.Transparent;
            this.lblDBName.Location = new System.Drawing.Point(27, 25);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(95, 15);
            this.lblDBName.TabIndex = 0;
            this.lblDBName.Tag = "Common.DataBase";
            this.lblDBName.Text = "DataBaseName";
            // 
            // tabSharding
            // 
            this.tabSharding.Controls.Add(this.tabBasic);
            this.tabSharding.Controls.Add(this.tabConfig);
            this.tabSharding.Controls.Add(this.tabZone);
            this.tabSharding.Controls.Add(this.tabZoneRange);
            this.tabSharding.Location = new System.Drawing.Point(13, 12);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(537, 400);
            this.tabSharding.TabIndex = 0;
            this.tabSharding.Tag = "";
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.label4);
            this.tabBasic.Controls.Add(this.cmdRemoveSharding);
            this.tabBasic.Controls.Add(this.lstSharding);
            this.tabBasic.Controls.Add(this.chkAdvance);
            this.tabBasic.Controls.Add(this.grpAdvanced);
            this.tabBasic.Controls.Add(this.cmdRemoveHost);
            this.tabBasic.Controls.Add(this.cmdAddHost);
            this.tabBasic.Controls.Add(this.lstHost);
            this.tabBasic.Controls.Add(this.NumReplPort);
            this.tabBasic.Controls.Add(this.lblReplPort);
            this.tabBasic.Controls.Add(this.txtReplHost);
            this.tabBasic.Controls.Add(this.lblReplHost);
            this.tabBasic.Controls.Add(this.lblMainReplsetName);
            this.tabBasic.Controls.Add(this.txtReplsetName);
            this.tabBasic.Controls.Add(this.cmdAddSharding);
            this.tabBasic.Location = new System.Drawing.Point(4, 24);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(529, 372);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Tag = "ShardingConfig_AddSharding";
            this.tabBasic.Text = "Add Remove";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Exist Sharding";
            // 
            // cmdRemoveSharding
            // 
            this.cmdRemoveSharding.Location = new System.Drawing.Point(273, 318);
            this.cmdRemoveSharding.Name = "cmdRemoveSharding";
            this.cmdRemoveSharding.Size = new System.Drawing.Size(215, 34);
            this.cmdRemoveSharding.TabIndex = 13;
            this.cmdRemoveSharding.Tag = "ShardingConfig_RemoveSharding";
            this.cmdRemoveSharding.Text = "Remove Sharding";
            this.cmdRemoveSharding.UseVisualStyleBackColor = true;
            this.cmdRemoveSharding.Click += new System.EventHandler(this.cmdRemoveSharding_Click);
            // 
            // lstSharding
            // 
            this.lstSharding.FormattingEnabled = true;
            this.lstSharding.ItemHeight = 15;
            this.lstSharding.Location = new System.Drawing.Point(16, 243);
            this.lstSharding.Name = "lstSharding";
            this.lstSharding.Size = new System.Drawing.Size(236, 109);
            this.lstSharding.TabIndex = 12;
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(275, 91);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(118, 19);
            this.chkAdvance.TabIndex = 9;
            this.chkAdvance.Tag = "Common.Advance_Option";
            this.chkAdvance.Text = "Advanced Option";
            this.chkAdvance.UseVisualStyleBackColor = true;
            this.chkAdvance.CheckedChanged += new System.EventHandler(this.chkAdvance_CheckedChanged);
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.NumMaxSize);
            this.grpAdvanced.Controls.Add(this.txtName);
            this.grpAdvanced.Controls.Add(this.lblShardingName);
            this.grpAdvanced.Controls.Add(this.lblMaxSize);
            this.grpAdvanced.Enabled = false;
            this.grpAdvanced.Location = new System.Drawing.Point(266, 95);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(222, 108);
            this.grpAdvanced.TabIndex = 10;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "grpAdvanced";
            // 
            // NumMaxSize
            // 
            this.NumMaxSize.Location = new System.Drawing.Point(106, 65);
            this.NumMaxSize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.NumMaxSize.Name = "NumMaxSize";
            this.NumMaxSize.Size = new System.Drawing.Size(100, 21);
            this.NumMaxSize.TabIndex = 3;
            this.NumMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblShardingName
            // 
            this.lblShardingName.AutoSize = true;
            this.lblShardingName.Location = new System.Drawing.Point(18, 34);
            this.lblShardingName.Name = "lblShardingName";
            this.lblShardingName.Size = new System.Drawing.Size(41, 15);
            this.lblShardingName.TabIndex = 1;
            this.lblShardingName.Tag = "Common.Name";
            this.lblShardingName.Text = "Name";
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(18, 67);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(82, 15);
            this.lblMaxSize.TabIndex = 2;
            this.lblMaxSize.Tag = "MaxSize_MB";
            this.lblMaxSize.Text = "MaxSize(MB)";
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(129, 170);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(108, 33);
            this.cmdRemoveHost.TabIndex = 8;
            this.cmdRemoveHost.Tag = "AddConnection_Region_RemoveHost";
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(16, 172);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(93, 31);
            this.cmdAddHost.TabIndex = 7;
            this.cmdAddHost.Tag = "AddConnection_Region_AddHost";
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 15;
            this.lstHost.Location = new System.Drawing.Point(16, 72);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(223, 79);
            this.lstHost.TabIndex = 6;
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(102, 45);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(135, 21);
            this.NumReplPort.TabIndex = 5;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(13, 45);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(29, 15);
            this.lblReplPort.TabIndex = 4;
            this.lblReplPort.Tag = "Common.Port";
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(102, 17);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(135, 21);
            this.txtReplHost.TabIndex = 3;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(13, 15);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(32, 15);
            this.lblReplHost.TabIndex = 2;
            this.lblReplHost.Tag = "Common.Host";
            this.lblReplHost.Text = "Host";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(264, 15);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(83, 15);
            this.lblMainReplsetName.TabIndex = 0;
            this.lblMainReplsetName.Tag = "ShardingConfig_ReplsetName";
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(353, 15);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(135, 21);
            this.txtReplsetName.TabIndex = 1;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.lblnumInitialChunks);
            this.tabConfig.Controls.Add(this.numInitialChunks);
            this.tabConfig.Controls.Add(this.chkUnique);
            this.tabConfig.Controls.Add(this.lblIndexName);
            this.tabConfig.Controls.Add(this.lblDBName);
            this.tabConfig.Controls.Add(this.cmbIndexList);
            this.tabConfig.Controls.Add(this.lblCollection);
            this.tabConfig.Controls.Add(this.cmdShardCollectionSharding);
            this.tabConfig.Controls.Add(this.cmbDataBase);
            this.tabConfig.Controls.Add(this.cmdEnableDBSharding);
            this.tabConfig.Controls.Add(this.cmbCollection);
            this.tabConfig.Location = new System.Drawing.Point(4, 24);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(529, 372);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Tag = "ShardingConfig_EnableSharding";
            this.tabConfig.Text = "Enable Sharding";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // lblnumInitialChunks
            // 
            this.lblnumInitialChunks.AutoSize = true;
            this.lblnumInitialChunks.Location = new System.Drawing.Point(27, 174);
            this.lblnumInitialChunks.Name = "lblnumInitialChunks";
            this.lblnumInitialChunks.Size = new System.Drawing.Size(102, 15);
            this.lblnumInitialChunks.TabIndex = 10;
            this.lblnumInitialChunks.Text = "numInitialChunks";
            // 
            // numInitialChunks
            // 
            this.numInitialChunks.Location = new System.Drawing.Point(137, 172);
            this.numInitialChunks.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numInitialChunks.Name = "numInitialChunks";
            this.numInitialChunks.Size = new System.Drawing.Size(162, 21);
            this.numInitialChunks.TabIndex = 9;
            this.numInitialChunks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkUnique
            // 
            this.chkUnique.AutoSize = true;
            this.chkUnique.Location = new System.Drawing.Point(30, 143);
            this.chkUnique.Name = "chkUnique";
            this.chkUnique.Size = new System.Drawing.Size(64, 19);
            this.chkUnique.TabIndex = 8;
            this.chkUnique.Text = "unique";
            this.chkUnique.UseVisualStyleBackColor = true;
            // 
            // tabZone
            // 
            this.tabZone.Controls.Add(this.lstExistShardZone);
            this.tabZone.Controls.Add(this.lblExistShardTag);
            this.tabZone.Controls.Add(this.cmbShard);
            this.tabZone.Controls.Add(this.btnAddShardZone);
            this.tabZone.Controls.Add(this.txtShardZone);
            this.tabZone.Controls.Add(this.lblShardZone);
            this.tabZone.Controls.Add(this.lblShardName);
            this.tabZone.Location = new System.Drawing.Point(4, 24);
            this.tabZone.Name = "tabZone";
            this.tabZone.Padding = new System.Windows.Forms.Padding(3);
            this.tabZone.Size = new System.Drawing.Size(529, 372);
            this.tabZone.TabIndex = 4;
            this.tabZone.Text = "Zone";
            this.tabZone.UseVisualStyleBackColor = true;
            // 
            // lstExistShardZone
            // 
            this.lstExistShardZone.FullRowSelect = true;
            this.lstExistShardZone.GridLines = true;
            this.lstExistShardZone.Location = new System.Drawing.Point(35, 113);
            this.lstExistShardZone.Name = "lstExistShardZone";
            this.lstExistShardZone.Size = new System.Drawing.Size(453, 215);
            this.lstExistShardZone.TabIndex = 42;
            this.lstExistShardZone.UseCompatibleStateImageBehavior = false;
            this.lstExistShardZone.View = System.Windows.Forms.View.Details;
            // 
            // lblExistShardTag
            // 
            this.lblExistShardTag.AutoSize = true;
            this.lblExistShardTag.Location = new System.Drawing.Point(35, 88);
            this.lblExistShardTag.Name = "lblExistShardTag";
            this.lblExistShardTag.Size = new System.Drawing.Size(100, 15);
            this.lblExistShardTag.TabIndex = 41;
            this.lblExistShardTag.Text = "Exist Shard Zone";
            // 
            // cmbShard
            // 
            this.cmbShard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShard.FormattingEnabled = true;
            this.cmbShard.Location = new System.Drawing.Point(141, 25);
            this.cmbShard.Name = "cmbShard";
            this.cmbShard.Size = new System.Drawing.Size(162, 23);
            this.cmbShard.TabIndex = 40;
            // 
            // btnAddShardZone
            // 
            this.btnAddShardZone.Location = new System.Drawing.Point(319, 47);
            this.btnAddShardZone.Name = "btnAddShardZone";
            this.btnAddShardZone.Size = new System.Drawing.Size(169, 33);
            this.btnAddShardZone.TabIndex = 39;
            this.btnAddShardZone.Tag = "Common.Add";
            this.btnAddShardZone.Text = "Add Shard Zone";
            this.btnAddShardZone.UseVisualStyleBackColor = true;
            this.btnAddShardZone.Click += new System.EventHandler(this.btnAddShardZone_Click);
            // 
            // txtShardZone
            // 
            this.txtShardZone.Location = new System.Drawing.Point(141, 53);
            this.txtShardZone.Name = "txtShardZone";
            this.txtShardZone.Size = new System.Drawing.Size(162, 21);
            this.txtShardZone.TabIndex = 38;
            // 
            // lblShardZone
            // 
            this.lblShardZone.AutoSize = true;
            this.lblShardZone.Location = new System.Drawing.Point(35, 56);
            this.lblShardZone.Name = "lblShardZone";
            this.lblShardZone.Size = new System.Drawing.Size(71, 15);
            this.lblShardZone.TabIndex = 37;
            this.lblShardZone.Text = "Shard Zone";
            // 
            // lblShardName
            // 
            this.lblShardName.AutoSize = true;
            this.lblShardName.Location = new System.Drawing.Point(35, 28);
            this.lblShardName.Name = "lblShardName";
            this.lblShardName.Size = new System.Drawing.Size(77, 15);
            this.lblShardName.TabIndex = 36;
            this.lblShardName.Text = "Shard Name";
            // 
            // tabZoneRange
            // 
            this.tabZoneRange.Controls.Add(this.lstExistShardRange);
            this.tabZoneRange.Controls.Add(this.label1);
            this.tabZoneRange.Controls.Add(this.label2);
            this.tabZoneRange.Controls.Add(this.cmbShardKeyDB);
            this.tabZoneRange.Controls.Add(this.cmbShardKeyCol);
            this.tabZoneRange.Controls.Add(this.lblFieldName);
            this.tabZoneRange.Controls.Add(this.lblShardTag);
            this.tabZoneRange.Controls.Add(this.cmbField);
            this.tabZoneRange.Controls.Add(this.cmbTagList);
            this.tabZoneRange.Controls.Add(this.lblShardKeyTo);
            this.tabZoneRange.Controls.Add(this.lblShardKeyFrom);
            this.tabZoneRange.Controls.Add(this.cmdaddZoneRange);
            this.tabZoneRange.Controls.Add(this.ctlBsonValueShardKeyTo);
            this.tabZoneRange.Controls.Add(this.ctlBsonValueShardKeyFrom);
            this.tabZoneRange.Location = new System.Drawing.Point(4, 24);
            this.tabZoneRange.Name = "tabZoneRange";
            this.tabZoneRange.Padding = new System.Windows.Forms.Padding(3);
            this.tabZoneRange.Size = new System.Drawing.Size(529, 372);
            this.tabZoneRange.TabIndex = 3;
            this.tabZoneRange.Text = "Zone Range";
            this.tabZoneRange.UseVisualStyleBackColor = true;
            // 
            // lstExistShardRange
            // 
            this.lstExistShardRange.FullRowSelect = true;
            this.lstExistShardRange.GridLines = true;
            this.lstExistShardRange.Location = new System.Drawing.Point(46, 225);
            this.lstExistShardRange.Name = "lstExistShardRange";
            this.lstExistShardRange.Size = new System.Drawing.Size(421, 130);
            this.lstExistShardRange.TabIndex = 43;
            this.lstExistShardRange.UseCompatibleStateImageBehavior = false;
            this.lstExistShardRange.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 23;
            this.label1.Tag = "Common.DataBase";
            this.label1.Text = "DataBaseName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(43, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 25;
            this.label2.Tag = "Common.Collection";
            this.label2.Text = "CollectionName";
            // 
            // cmbShardKeyDB
            // 
            this.cmbShardKeyDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShardKeyDB.FormattingEnabled = true;
            this.cmbShardKeyDB.Location = new System.Drawing.Point(152, 21);
            this.cmbShardKeyDB.Name = "cmbShardKeyDB";
            this.cmbShardKeyDB.Size = new System.Drawing.Size(162, 23);
            this.cmbShardKeyDB.TabIndex = 24;
            this.cmbShardKeyDB.SelectedIndexChanged += new System.EventHandler(this.cmbShardKeyDB_SelectedIndexChanged);
            // 
            // cmbShardKeyCol
            // 
            this.cmbShardKeyCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShardKeyCol.FormattingEnabled = true;
            this.cmbShardKeyCol.Location = new System.Drawing.Point(152, 53);
            this.cmbShardKeyCol.Name = "cmbShardKeyCol";
            this.cmbShardKeyCol.Size = new System.Drawing.Size(162, 23);
            this.cmbShardKeyCol.TabIndex = 26;
            this.cmbShardKeyCol.SelectedIndexChanged += new System.EventHandler(this.cmbShardKeyCol_SelectedIndexChanged);
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(43, 118);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(34, 15);
            this.lblFieldName.TabIndex = 22;
            this.lblFieldName.Tag = "Common.FieldName";
            this.lblFieldName.Text = "Field";
            // 
            // lblShardTag
            // 
            this.lblShardTag.AutoSize = true;
            this.lblShardTag.Location = new System.Drawing.Point(43, 86);
            this.lblShardTag.Name = "lblShardTag";
            this.lblShardTag.Size = new System.Drawing.Size(35, 15);
            this.lblShardTag.TabIndex = 22;
            this.lblShardTag.Text = "Zone";
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(152, 115);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(162, 23);
            this.cmbField.TabIndex = 21;
            // 
            // cmbTagList
            // 
            this.cmbTagList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagList.FormattingEnabled = true;
            this.cmbTagList.Location = new System.Drawing.Point(152, 83);
            this.cmbTagList.Name = "cmbTagList";
            this.cmbTagList.Size = new System.Drawing.Size(162, 23);
            this.cmbTagList.TabIndex = 21;
            // 
            // lblShardKeyTo
            // 
            this.lblShardKeyTo.AutoSize = true;
            this.lblShardKeyTo.Location = new System.Drawing.Point(43, 184);
            this.lblShardKeyTo.Name = "lblShardKeyTo";
            this.lblShardKeyTo.Size = new System.Drawing.Size(77, 15);
            this.lblShardKeyTo.TabIndex = 18;
            this.lblShardKeyTo.Text = "ShardKeyTo:";
            // 
            // lblShardKeyFrom
            // 
            this.lblShardKeyFrom.AutoSize = true;
            this.lblShardKeyFrom.Location = new System.Drawing.Point(43, 158);
            this.lblShardKeyFrom.Name = "lblShardKeyFrom";
            this.lblShardKeyFrom.Size = new System.Drawing.Size(92, 15);
            this.lblShardKeyFrom.TabIndex = 17;
            this.lblShardKeyFrom.Text = "ShardKeyFrom:";
            // 
            // cmdaddZoneRange
            // 
            this.cmdaddZoneRange.BackColor = System.Drawing.Color.Transparent;
            this.cmdaddZoneRange.Location = new System.Drawing.Point(344, 110);
            this.cmdaddZoneRange.Name = "cmdaddZoneRange";
            this.cmdaddZoneRange.Size = new System.Drawing.Size(123, 30);
            this.cmdaddZoneRange.TabIndex = 16;
            this.cmdaddZoneRange.Tag = "Common.Add";
            this.cmdaddZoneRange.Text = "Add Zone Range";
            this.cmdaddZoneRange.UseVisualStyleBackColor = false;
            this.cmdaddZoneRange.Click += new System.EventHandler(this.cmdaddZoneRange_Click);
            // 
            // ctlBsonValueShardKeyTo
            // 
            this.ctlBsonValueShardKeyTo.BackColor = System.Drawing.Color.Transparent;
            this.ctlBsonValueShardKeyTo.Location = new System.Drawing.Point(152, 183);
            this.ctlBsonValueShardKeyTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctlBsonValueShardKeyTo.Name = "ctlBsonValueShardKeyTo";
            this.ctlBsonValueShardKeyTo.Size = new System.Drawing.Size(383, 34);
            this.ctlBsonValueShardKeyTo.TabIndex = 27;
            // 
            // ctlBsonValueShardKeyFrom
            // 
            this.ctlBsonValueShardKeyFrom.BackColor = System.Drawing.Color.Transparent;
            this.ctlBsonValueShardKeyFrom.Location = new System.Drawing.Point(152, 148);
            this.ctlBsonValueShardKeyFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlBsonValueShardKeyFrom.Name = "ctlBsonValueShardKeyFrom";
            this.ctlBsonValueShardKeyFrom.Size = new System.Drawing.Size(376, 36);
            this.ctlBsonValueShardKeyFrom.TabIndex = 27;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(220, 422);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(121, 32);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Tag = "Common.Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // FrmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 471);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabSharding);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShardingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "ShardingConfig_Title";
            this.Text = "Sharding";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.tabSharding.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialChunks)).EndInit();
            this.tabZone.ResumeLayout(false);
            this.tabZone.PerformLayout();
            this.tabZoneRange.ResumeLayout(false);
            this.tabZoneRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdAddSharding;
        private Label lblIndexName;
        private ComboBox cmbIndexList;
        private Button cmdShardCollectionSharding;
        private Button cmdEnableDBSharding;
        private ComboBox cmbCollection;
        private ComboBox cmbDataBase;
        private Label lblCollection;
        private Label lblDBName;
        private TabControl tabSharding;
        private TabPage tabBasic;
        private TabPage tabConfig;
        private NumericUpDown NumReplPort;
        private Label lblReplPort;
        private TextBox txtReplHost;
        private Label lblReplHost;
        private Label lblMainReplsetName;
        private TextBox txtReplsetName;
        private ListBox lstHost;
        private Button cmdAddHost;
        private Button cmdRemoveHost;
        private Button cmdClose;
        private GroupBox grpAdvanced;
        private CheckBox chkAdvance;
        private NumericUpDown NumMaxSize;
        private TextBox txtName;
        private Label lblShardingName;
        private Label lblMaxSize;
        private TabPage tabZoneRange;
        private Label lblShardTag;
        private ComboBox cmbTagList;
        private Label lblShardKeyTo;
        private Label lblShardKeyFrom;
        private Button cmdaddZoneRange;
        private Label label1;
        private Label label2;
        private ComboBox cmbShardKeyDB;
        private ComboBox cmbShardKeyCol;
        private ctlBsonValueType ctlBsonValueShardKeyTo;
        private ctlBsonValueType ctlBsonValueShardKeyFrom;
        private Label lblFieldName;
        private ComboBox cmbField;
        private Button cmdRemoveSharding;
        private ListBox lstSharding;
        private Label lblnumInitialChunks;
        private NumericUpDown numInitialChunks;
        private CheckBox chkUnique;
        private TabPage tabZone;
        private Label lblExistShardTag;
        private ComboBox cmbShard;
        private Button btnAddShardZone;
        private TextBox txtShardZone;
        private Label lblShardZone;
        private Label lblShardName;
        private ListView lstExistShardRange;
        private ListView lstExistShardZone;
        private Label label4;
    }
}