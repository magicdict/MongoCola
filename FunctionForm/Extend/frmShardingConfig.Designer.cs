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
            this.cmdEnableCollectionSharding = new System.Windows.Forms.Button();
            this.cmdEnableDBSharding = new System.Windows.Forms.Button();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tabSharding = new System.Windows.Forms.TabControl();
            this.tabAddSharding = new System.Windows.Forms.TabPage();
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
            this.tabShardingConfig = new System.Windows.Forms.TabPage();
            this.lstExistShardTag = new System.Windows.Forms.ListView();
            this.lblExistShardTag = new System.Windows.Forms.Label();
            this.tabAddShardTag = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShardKeyDB = new System.Windows.Forms.ComboBox();
            this.cmbShardKeyCol = new System.Windows.Forms.ComboBox();
            this.lblShardTag = new System.Windows.Forms.Label();
            this.cmbTagList = new System.Windows.Forms.ComboBox();
            this.lblShardKeyTo = new System.Windows.Forms.Label();
            this.lblShardKeyFrom = new System.Windows.Forms.Label();
            this.cmdaddTagRange = new System.Windows.Forms.Button();
            this.btnAddShardTag = new System.Windows.Forms.Button();
            this.txtTagShard = new System.Windows.Forms.TextBox();
            this.txtShardName = new System.Windows.Forms.TextBox();
            this.lblTagShard = new System.Windows.Forms.Label();
            this.lblShardName = new System.Windows.Forms.Label();
            this.ctlBsonValueShardKeyTo = new MongoGUICtl.CtlBsonValue();
            this.ctlBsonValueShardKeyFrom = new MongoGUICtl.CtlBsonValue();
            this.tabRemoveSharding = new System.Windows.Forms.TabPage();
            this.lstSharding = new System.Windows.Forms.ListBox();
            this.cmdRemoveSharding = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tabSharding.SuspendLayout();
            this.tabAddSharding.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            this.tabShardingConfig.SuspendLayout();
            this.tabAddShardTag.SuspendLayout();
            this.tabRemoveSharding.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddSharding
            // 
            this.cmdAddSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSharding.Enabled = false;
            this.cmdAddSharding.Location = new System.Drawing.Point(277, 159);
            this.cmdAddSharding.Name = "cmdAddSharding";
            this.cmdAddSharding.Size = new System.Drawing.Size(223, 33);
            this.cmdAddSharding.TabIndex = 11;
            this.cmdAddSharding.Text = "Add Sharding";
            this.cmdAddSharding.UseVisualStyleBackColor = false;
            this.cmdAddSharding.Click += new System.EventHandler(this.cmdAddSharding_Click);
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexName.Location = new System.Drawing.Point(27, 89);
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
            this.cmbIndexList.Location = new System.Drawing.Point(137, 86);
            this.cmbIndexList.Name = "cmbIndexList";
            this.cmbIndexList.Size = new System.Drawing.Size(162, 23);
            this.cmbIndexList.TabIndex = 7;
            // 
            // cmdEnableCollectionSharding
            // 
            this.cmdEnableCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableCollectionSharding.Location = new System.Drawing.Point(316, 50);
            this.cmdEnableCollectionSharding.Name = "cmdEnableCollectionSharding";
            this.cmdEnableCollectionSharding.Size = new System.Drawing.Size(172, 30);
            this.cmdEnableCollectionSharding.TabIndex = 5;
            this.cmdEnableCollectionSharding.Tag = "ShardingConfig_Action_CollectionSharding";
            this.cmdEnableCollectionSharding.Text = "Sharding Collection";
            this.cmdEnableCollectionSharding.UseVisualStyleBackColor = false;
            this.cmdEnableCollectionSharding.Click += new System.EventHandler(this.cmdEnableCollectionSharding_Click);
            // 
            // cmdEnableDBSharding
            // 
            this.cmdEnableDBSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableDBSharding.Location = new System.Drawing.Point(316, 18);
            this.cmdEnableDBSharding.Name = "cmdEnableDBSharding";
            this.cmdEnableDBSharding.Size = new System.Drawing.Size(172, 29);
            this.cmdEnableDBSharding.TabIndex = 2;
            this.cmdEnableDBSharding.Tag = "ShardingConfig_Action_DBSharding";
            this.cmdEnableDBSharding.Text = "Sharding DataBase";
            this.cmdEnableDBSharding.UseVisualStyleBackColor = false;
            this.cmdEnableDBSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(137, 53);
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
            this.lblCollection.Location = new System.Drawing.Point(27, 56);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(95, 15);
            this.lblCollection.TabIndex = 3;
            this.lblCollection.Tag = "ShardingConfig_CollectionName";
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
            this.lblDBName.Tag = "ShardingConfig_DBName";
            this.lblDBName.Text = "DataBaseName";
            // 
            // tabSharding
            // 
            this.tabSharding.Controls.Add(this.tabAddSharding);
            this.tabSharding.Controls.Add(this.tabShardingConfig);
            this.tabSharding.Controls.Add(this.tabAddShardTag);
            this.tabSharding.Controls.Add(this.tabRemoveSharding);
            this.tabSharding.Location = new System.Drawing.Point(13, 12);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(525, 314);
            this.tabSharding.TabIndex = 0;
            this.tabSharding.Tag = "";
            // 
            // tabAddSharding
            // 
            this.tabAddSharding.Controls.Add(this.chkAdvance);
            this.tabAddSharding.Controls.Add(this.grpAdvanced);
            this.tabAddSharding.Controls.Add(this.cmdRemoveHost);
            this.tabAddSharding.Controls.Add(this.cmdAddHost);
            this.tabAddSharding.Controls.Add(this.lstHost);
            this.tabAddSharding.Controls.Add(this.NumReplPort);
            this.tabAddSharding.Controls.Add(this.lblReplPort);
            this.tabAddSharding.Controls.Add(this.txtReplHost);
            this.tabAddSharding.Controls.Add(this.lblReplHost);
            this.tabAddSharding.Controls.Add(this.lblMainReplsetName);
            this.tabAddSharding.Controls.Add(this.txtReplsetName);
            this.tabAddSharding.Controls.Add(this.cmdAddSharding);
            this.tabAddSharding.Location = new System.Drawing.Point(4, 24);
            this.tabAddSharding.Name = "tabAddSharding";
            this.tabAddSharding.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSharding.Size = new System.Drawing.Size(517, 286);
            this.tabAddSharding.TabIndex = 0;
            this.tabAddSharding.Tag = "ShardingConfig_AddSharding";
            this.tabAddSharding.Text = "Add Sharding";
            this.tabAddSharding.UseVisualStyleBackColor = true;
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(36, 159);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(118, 19);
            this.chkAdvance.TabIndex = 9;
            this.chkAdvance.Tag = "Common_Advance_Option";
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
            this.grpAdvanced.Location = new System.Drawing.Point(27, 163);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(222, 73);
            this.grpAdvanced.TabIndex = 10;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "grpAdvanced";
            // 
            // NumMaxSize
            // 
            this.NumMaxSize.Location = new System.Drawing.Point(101, 40);
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
            this.txtName.Location = new System.Drawing.Point(101, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // lblShardingName
            // 
            this.lblShardingName.AutoSize = true;
            this.lblShardingName.Location = new System.Drawing.Point(16, 18);
            this.lblShardingName.Name = "lblShardingName";
            this.lblShardingName.Size = new System.Drawing.Size(41, 15);
            this.lblShardingName.TabIndex = 1;
            this.lblShardingName.Text = "Name";
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(16, 40);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(82, 15);
            this.lblMaxSize.TabIndex = 2;
            this.lblMaxSize.Text = "MaxSize(MB)";
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(392, 120);
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
            this.cmdAddHost.Location = new System.Drawing.Point(277, 119);
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
            this.lstHost.Location = new System.Drawing.Point(277, 23);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(223, 79);
            this.lstHost.TabIndex = 6;
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(113, 80);
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
            this.lblReplPort.Location = new System.Drawing.Point(24, 80);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(29, 15);
            this.lblReplPort.TabIndex = 4;
            this.lblReplPort.Tag = "Common_Port";
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(113, 52);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(135, 21);
            this.txtReplHost.TabIndex = 3;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(24, 50);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(32, 15);
            this.lblReplHost.TabIndex = 2;
            this.lblReplHost.Tag = "Common_Host";
            this.lblReplHost.Text = "Host";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(24, 23);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(83, 15);
            this.lblMainReplsetName.TabIndex = 0;
            this.lblMainReplsetName.Tag = "ShardingConfig_ReplsetName";
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(113, 23);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(135, 21);
            this.txtReplsetName.TabIndex = 1;
            // 
            // tabShardingConfig
            // 
            this.tabShardingConfig.Controls.Add(this.lstExistShardTag);
            this.tabShardingConfig.Controls.Add(this.lblExistShardTag);
            this.tabShardingConfig.Controls.Add(this.lblIndexName);
            this.tabShardingConfig.Controls.Add(this.lblDBName);
            this.tabShardingConfig.Controls.Add(this.cmbIndexList);
            this.tabShardingConfig.Controls.Add(this.lblCollection);
            this.tabShardingConfig.Controls.Add(this.cmdEnableCollectionSharding);
            this.tabShardingConfig.Controls.Add(this.cmbDataBase);
            this.tabShardingConfig.Controls.Add(this.cmdEnableDBSharding);
            this.tabShardingConfig.Controls.Add(this.cmbCollection);
            this.tabShardingConfig.Location = new System.Drawing.Point(4, 24);
            this.tabShardingConfig.Name = "tabShardingConfig";
            this.tabShardingConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabShardingConfig.Size = new System.Drawing.Size(517, 286);
            this.tabShardingConfig.TabIndex = 1;
            this.tabShardingConfig.Tag = "ShardingConfig_EnableSharding";
            this.tabShardingConfig.Text = "Sharding Setting";
            this.tabShardingConfig.UseVisualStyleBackColor = true;
            // 
            // lstExistShardTag
            // 
            this.lstExistShardTag.Location = new System.Drawing.Point(32, 150);
            this.lstExistShardTag.Name = "lstExistShardTag";
            this.lstExistShardTag.Size = new System.Drawing.Size(456, 97);
            this.lstExistShardTag.TabIndex = 9;
            this.lstExistShardTag.UseCompatibleStateImageBehavior = false;
            this.lstExistShardTag.View = System.Windows.Forms.View.Details;
            // 
            // lblExistShardTag
            // 
            this.lblExistShardTag.AutoSize = true;
            this.lblExistShardTag.Location = new System.Drawing.Point(27, 120);
            this.lblExistShardTag.Name = "lblExistShardTag";
            this.lblExistShardTag.Size = new System.Drawing.Size(205, 15);
            this.lblExistShardTag.TabIndex = 8;
            this.lblExistShardTag.Text = "Collection already Used Shard Tags:";
            // 
            // tabAddShardTag
            // 
            this.tabAddShardTag.Controls.Add(this.label1);
            this.tabAddShardTag.Controls.Add(this.label2);
            this.tabAddShardTag.Controls.Add(this.cmbShardKeyDB);
            this.tabAddShardTag.Controls.Add(this.cmbShardKeyCol);
            this.tabAddShardTag.Controls.Add(this.lblShardTag);
            this.tabAddShardTag.Controls.Add(this.cmbTagList);
            this.tabAddShardTag.Controls.Add(this.lblShardKeyTo);
            this.tabAddShardTag.Controls.Add(this.lblShardKeyFrom);
            this.tabAddShardTag.Controls.Add(this.cmdaddTagRange);
            this.tabAddShardTag.Controls.Add(this.btnAddShardTag);
            this.tabAddShardTag.Controls.Add(this.txtTagShard);
            this.tabAddShardTag.Controls.Add(this.txtShardName);
            this.tabAddShardTag.Controls.Add(this.lblTagShard);
            this.tabAddShardTag.Controls.Add(this.lblShardName);
            this.tabAddShardTag.Controls.Add(this.ctlBsonValueShardKeyTo);
            this.tabAddShardTag.Controls.Add(this.ctlBsonValueShardKeyFrom);
            this.tabAddShardTag.Location = new System.Drawing.Point(4, 24);
            this.tabAddShardTag.Name = "tabAddShardTag";
            this.tabAddShardTag.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddShardTag.Size = new System.Drawing.Size(517, 286);
            this.tabAddShardTag.TabIndex = 3;
            this.tabAddShardTag.Text = "Add Shard Tag";
            this.tabAddShardTag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "DataBaseName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "CollectionName";
            // 
            // cmbShardKeyDB
            // 
            this.cmbShardKeyDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShardKeyDB.FormattingEnabled = true;
            this.cmbShardKeyDB.Location = new System.Drawing.Point(135, 66);
            this.cmbShardKeyDB.Name = "cmbShardKeyDB";
            this.cmbShardKeyDB.Size = new System.Drawing.Size(162, 23);
            this.cmbShardKeyDB.TabIndex = 24;
            this.cmbShardKeyDB.SelectedIndexChanged += new System.EventHandler(this.cmbShardKeyDB_SelectedIndexChanged);
            // 
            // cmbShardKeyCol
            // 
            this.cmbShardKeyCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShardKeyCol.FormattingEnabled = true;
            this.cmbShardKeyCol.Location = new System.Drawing.Point(135, 98);
            this.cmbShardKeyCol.Name = "cmbShardKeyCol";
            this.cmbShardKeyCol.Size = new System.Drawing.Size(162, 23);
            this.cmbShardKeyCol.TabIndex = 26;
            // 
            // lblShardTag
            // 
            this.lblShardTag.AutoSize = true;
            this.lblShardTag.Location = new System.Drawing.Point(25, 134);
            this.lblShardTag.Name = "lblShardTag";
            this.lblShardTag.Size = new System.Drawing.Size(64, 15);
            this.lblShardTag.TabIndex = 22;
            this.lblShardTag.Text = "Shard Tag";
            // 
            // cmbTagList
            // 
            this.cmbTagList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagList.FormattingEnabled = true;
            this.cmbTagList.Location = new System.Drawing.Point(135, 128);
            this.cmbTagList.Name = "cmbTagList";
            this.cmbTagList.Size = new System.Drawing.Size(162, 23);
            this.cmbTagList.TabIndex = 21;
            // 
            // lblShardKeyTo
            // 
            this.lblShardKeyTo.AutoSize = true;
            this.lblShardKeyTo.Location = new System.Drawing.Point(25, 196);
            this.lblShardKeyTo.Name = "lblShardKeyTo";
            this.lblShardKeyTo.Size = new System.Drawing.Size(77, 15);
            this.lblShardKeyTo.TabIndex = 18;
            this.lblShardKeyTo.Text = "ShardKeyTo:";
            // 
            // lblShardKeyFrom
            // 
            this.lblShardKeyFrom.AutoSize = true;
            this.lblShardKeyFrom.Location = new System.Drawing.Point(25, 165);
            this.lblShardKeyFrom.Name = "lblShardKeyFrom";
            this.lblShardKeyFrom.Size = new System.Drawing.Size(92, 15);
            this.lblShardKeyFrom.TabIndex = 17;
            this.lblShardKeyFrom.Text = "ShardKeyFrom:";
            // 
            // cmdaddTagRange
            // 
            this.cmdaddTagRange.BackColor = System.Drawing.Color.Transparent;
            this.cmdaddTagRange.Location = new System.Drawing.Point(327, 66);
            this.cmdaddTagRange.Name = "cmdaddTagRange";
            this.cmdaddTagRange.Size = new System.Drawing.Size(169, 30);
            this.cmdaddTagRange.TabIndex = 16;
            this.cmdaddTagRange.Text = "Add Tag Range";
            this.cmdaddTagRange.UseVisualStyleBackColor = false;
            this.cmdaddTagRange.Click += new System.EventHandler(this.cmdaddTagRange_Click);
            // 
            // btnAddShardTag
            // 
            this.btnAddShardTag.Location = new System.Drawing.Point(327, 16);
            this.btnAddShardTag.Name = "btnAddShardTag";
            this.btnAddShardTag.Size = new System.Drawing.Size(169, 33);
            this.btnAddShardTag.TabIndex = 4;
            this.btnAddShardTag.Tag = "Common_Add";
            this.btnAddShardTag.Text = "Add Shard Tag";
            this.btnAddShardTag.UseVisualStyleBackColor = true;
            this.btnAddShardTag.Click += new System.EventHandler(this.btnAddShardTag_Click);
            // 
            // txtTagShard
            // 
            this.txtTagShard.Location = new System.Drawing.Point(135, 44);
            this.txtTagShard.Name = "txtTagShard";
            this.txtTagShard.Size = new System.Drawing.Size(182, 21);
            this.txtTagShard.TabIndex = 3;
            // 
            // txtShardName
            // 
            this.txtShardName.Location = new System.Drawing.Point(135, 16);
            this.txtShardName.Name = "txtShardName";
            this.txtShardName.Size = new System.Drawing.Size(182, 21);
            this.txtShardName.TabIndex = 2;
            // 
            // lblTagShard
            // 
            this.lblTagShard.AutoSize = true;
            this.lblTagShard.Location = new System.Drawing.Point(25, 44);
            this.lblTagShard.Name = "lblTagShard";
            this.lblTagShard.Size = new System.Drawing.Size(85, 15);
            this.lblTagShard.TabIndex = 1;
            this.lblTagShard.Text = "Tag For Shard";
            // 
            // lblShardName
            // 
            this.lblShardName.AutoSize = true;
            this.lblShardName.Location = new System.Drawing.Point(25, 16);
            this.lblShardName.Name = "lblShardName";
            this.lblShardName.Size = new System.Drawing.Size(77, 15);
            this.lblShardName.TabIndex = 0;
            this.lblShardName.Text = "Shard Name";
            // 
            // ctlBsonValueShardKeyTo
            // 
            this.ctlBsonValueShardKeyTo.Location = new System.Drawing.Point(135, 191);
            this.ctlBsonValueShardKeyTo.Name = "ctlBsonValueShardKeyTo";
            this.ctlBsonValueShardKeyTo.Size = new System.Drawing.Size(295, 32);
            this.ctlBsonValueShardKeyTo.TabIndex = 20;
            // 
            // ctlBsonValueShardKeyFrom
            // 
            this.ctlBsonValueShardKeyFrom.Location = new System.Drawing.Point(135, 155);
            this.ctlBsonValueShardKeyFrom.Name = "ctlBsonValueShardKeyFrom";
            this.ctlBsonValueShardKeyFrom.Size = new System.Drawing.Size(295, 32);
            this.ctlBsonValueShardKeyFrom.TabIndex = 19;
            // 
            // tabRemoveSharding
            // 
            this.tabRemoveSharding.Controls.Add(this.lstSharding);
            this.tabRemoveSharding.Controls.Add(this.cmdRemoveSharding);
            this.tabRemoveSharding.Location = new System.Drawing.Point(4, 24);
            this.tabRemoveSharding.Name = "tabRemoveSharding";
            this.tabRemoveSharding.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemoveSharding.Size = new System.Drawing.Size(517, 286);
            this.tabRemoveSharding.TabIndex = 2;
            this.tabRemoveSharding.Text = "Remove Sharding";
            this.tabRemoveSharding.UseVisualStyleBackColor = true;
            // 
            // lstSharding
            // 
            this.lstSharding.FormattingEnabled = true;
            this.lstSharding.ItemHeight = 15;
            this.lstSharding.Location = new System.Drawing.Point(34, 23);
            this.lstSharding.Name = "lstSharding";
            this.lstSharding.Size = new System.Drawing.Size(465, 184);
            this.lstSharding.TabIndex = 0;
            // 
            // cmdRemoveSharding
            // 
            this.cmdRemoveSharding.Location = new System.Drawing.Point(192, 223);
            this.cmdRemoveSharding.Name = "cmdRemoveSharding";
            this.cmdRemoveSharding.Size = new System.Drawing.Size(124, 34);
            this.cmdRemoveSharding.TabIndex = 1;
            this.cmdRemoveSharding.Text = "Remove Sharding";
            this.cmdRemoveSharding.UseVisualStyleBackColor = true;
            this.cmdRemoveSharding.Click += new System.EventHandler(this.cmdRemoveSharding_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(212, 345);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(121, 32);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(552, 389);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabSharding);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShardingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "ShardingConfig_Title";
            this.Text = "Sharding Config";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.tabSharding.ResumeLayout(false);
            this.tabAddSharding.ResumeLayout(false);
            this.tabAddSharding.PerformLayout();
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            this.tabShardingConfig.ResumeLayout(false);
            this.tabShardingConfig.PerformLayout();
            this.tabAddShardTag.ResumeLayout(false);
            this.tabAddShardTag.PerformLayout();
            this.tabRemoveSharding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdAddSharding;
        private Label lblIndexName;
        private ComboBox cmbIndexList;
        private Button cmdEnableCollectionSharding;
        private Button cmdEnableDBSharding;
        private ComboBox cmbCollection;
        private ComboBox cmbDataBase;
        private Label lblCollection;
        private Label lblDBName;
        private TabControl tabSharding;
        private TabPage tabAddSharding;
        private TabPage tabShardingConfig;
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
        private TabPage tabRemoveSharding;
        private ListBox lstSharding;
        private Button cmdRemoveSharding;
        private TabPage tabAddShardTag;
        private Label lblTagShard;
        private Label lblShardName;
        private TextBox txtTagShard;
        private TextBox txtShardName;
        private Button btnAddShardTag;
        private Label lblExistShardTag;
        private ListView lstExistShardTag;
        private Label lblShardTag;
        private ComboBox cmbTagList;
        private CtlBsonValue ctlBsonValueShardKeyTo;
        private CtlBsonValue ctlBsonValueShardKeyFrom;
        private Label lblShardKeyTo;
        private Label lblShardKeyFrom;
        private Button cmdaddTagRange;
        private Label label1;
        private Label label2;
        private ComboBox cmbShardKeyDB;
        private ComboBox cmbShardKeyCol;
    }
}