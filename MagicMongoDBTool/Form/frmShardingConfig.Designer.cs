namespace MagicMongoDBTool
{
    partial class frmShardingConfig
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
            this.cmdAddSharding = new System.Windows.Forms.Button();
            this.lblField = new System.Windows.Forms.Label();
            this.cmbKeyList = new System.Windows.Forms.ComboBox();
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
            this.label2 = new System.Windows.Forms.Label();
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
            this.tabRemoveSharding.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddSharding
            // 
            this.cmdAddSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSharding.Enabled = false;
            this.cmdAddSharding.Location = new System.Drawing.Point(288, 159);
            this.cmdAddSharding.Name = "cmdAddSharding";
            this.cmdAddSharding.Size = new System.Drawing.Size(212, 33);
            this.cmdAddSharding.TabIndex = 2;
            this.cmdAddSharding.Text = "Add Sharding";
            this.cmdAddSharding.UseVisualStyleBackColor = false;
            this.cmdAddSharding.Click += new System.EventHandler(this.cmdAddSharding_Click);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.BackColor = System.Drawing.Color.Transparent;
            this.lblField.Location = new System.Drawing.Point(26, 119);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(71, 15);
            this.lblField.TabIndex = 34;
            this.lblField.Text = "IndexName";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(124, 115);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(196, 23);
            this.cmbKeyList.TabIndex = 30;
            // 
            // cmdEnableCollectionSharding
            // 
            this.cmdEnableCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableCollectionSharding.Location = new System.Drawing.Point(346, 74);
            this.cmdEnableCollectionSharding.Name = "cmdEnableCollectionSharding";
            this.cmdEnableCollectionSharding.Size = new System.Drawing.Size(139, 35);
            this.cmdEnableCollectionSharding.TabIndex = 31;
            this.cmdEnableCollectionSharding.Text = "Sharding Collection";
            this.cmdEnableCollectionSharding.UseVisualStyleBackColor = false;
            this.cmdEnableCollectionSharding.Click += new System.EventHandler(this.cmdEnableCollectionSharding_Click);
            // 
            // cmdEnableDBSharding
            // 
            this.cmdEnableDBSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableDBSharding.Location = new System.Drawing.Point(346, 27);
            this.cmdEnableDBSharding.Name = "cmdEnableDBSharding";
            this.cmdEnableDBSharding.Size = new System.Drawing.Size(139, 38);
            this.cmdEnableDBSharding.TabIndex = 28;
            this.cmdEnableDBSharding.Text = "Sharding DataBase";
            this.cmdEnableDBSharding.UseVisualStyleBackColor = false;
            this.cmdEnableDBSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(122, 77);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(196, 23);
            this.cmbCollection.TabIndex = 29;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(122, 32);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(196, 23);
            this.cmbDataBase.TabIndex = 27;
            this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.BackColor = System.Drawing.Color.Transparent;
            this.lblCollection.Location = new System.Drawing.Point(24, 77);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(95, 15);
            this.lblCollection.TabIndex = 33;
            this.lblCollection.Text = "CollectionName";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.BackColor = System.Drawing.Color.Transparent;
            this.lblDBName.Location = new System.Drawing.Point(24, 36);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(95, 15);
            this.lblDBName.TabIndex = 32;
            this.lblDBName.Text = "DataBaseName";
            // 
            // tabSharding
            // 
            this.tabSharding.Controls.Add(this.tabAddSharding);
            this.tabSharding.Controls.Add(this.tabShardingConfig);
            this.tabSharding.Controls.Add(this.tabRemoveSharding);
            this.tabSharding.Location = new System.Drawing.Point(13, 12);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(525, 257);
            this.tabSharding.TabIndex = 35;
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
            this.tabAddSharding.Size = new System.Drawing.Size(517, 229);
            this.tabAddSharding.TabIndex = 0;
            this.tabAddSharding.Text = "Add Sharding";
            this.tabAddSharding.UseVisualStyleBackColor = true;
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(36, 115);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(118, 19);
            this.chkAdvance.TabIndex = 37;
            this.chkAdvance.Text = "Advanced Option";
            this.chkAdvance.UseVisualStyleBackColor = true;
            this.chkAdvance.CheckedChanged += new System.EventHandler(this.chkAdvance_CheckedChanged);
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.NumMaxSize);
            this.grpAdvanced.Controls.Add(this.txtName);
            this.grpAdvanced.Controls.Add(this.lblShardingName);
            this.grpAdvanced.Controls.Add(this.label2);
            this.grpAdvanced.Location = new System.Drawing.Point(27, 119);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(222, 73);
            this.grpAdvanced.TabIndex = 46;
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
            this.NumMaxSize.TabIndex = 50;
            this.NumMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 49;
            // 
            // lblShardingName
            // 
            this.lblShardingName.AutoSize = true;
            this.lblShardingName.Location = new System.Drawing.Point(16, 18);
            this.lblShardingName.Name = "lblShardingName";
            this.lblShardingName.Size = new System.Drawing.Size(41, 15);
            this.lblShardingName.TabIndex = 47;
            this.lblShardingName.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "MaxSize(MB)";
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(403, 119);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(108, 33);
            this.cmdRemoveHost.TabIndex = 45;
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(288, 119);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(93, 31);
            this.cmdAddHost.TabIndex = 44;
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
            this.lstHost.TabIndex = 43;
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
            this.NumReplPort.TabIndex = 38;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(24, 80);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(29, 15);
            this.lblReplPort.TabIndex = 42;
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(113, 52);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(135, 21);
            this.txtReplHost.TabIndex = 37;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(24, 50);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(32, 15);
            this.lblReplHost.TabIndex = 41;
            this.lblReplHost.Text = "Host";
            // 
            // lblMainReplsetName
            // 
            this.lblMainReplsetName.AutoSize = true;
            this.lblMainReplsetName.Location = new System.Drawing.Point(24, 23);
            this.lblMainReplsetName.Name = "lblMainReplsetName";
            this.lblMainReplsetName.Size = new System.Drawing.Size(83, 15);
            this.lblMainReplsetName.TabIndex = 40;
            this.lblMainReplsetName.Text = "ReplsetName";
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(113, 23);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(135, 21);
            this.txtReplsetName.TabIndex = 36;
            // 
            // tabShardingConfig
            // 
            this.tabShardingConfig.Controls.Add(this.lblField);
            this.tabShardingConfig.Controls.Add(this.lblDBName);
            this.tabShardingConfig.Controls.Add(this.cmbKeyList);
            this.tabShardingConfig.Controls.Add(this.lblCollection);
            this.tabShardingConfig.Controls.Add(this.cmdEnableCollectionSharding);
            this.tabShardingConfig.Controls.Add(this.cmbDataBase);
            this.tabShardingConfig.Controls.Add(this.cmdEnableDBSharding);
            this.tabShardingConfig.Controls.Add(this.cmbCollection);
            this.tabShardingConfig.Location = new System.Drawing.Point(4, 24);
            this.tabShardingConfig.Name = "tabShardingConfig";
            this.tabShardingConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabShardingConfig.Size = new System.Drawing.Size(517, 229);
            this.tabShardingConfig.TabIndex = 1;
            this.tabShardingConfig.Text = "Sharding Setting";
            this.tabShardingConfig.UseVisualStyleBackColor = true;
            // 
            // tabRemoveSharding
            // 
            this.tabRemoveSharding.Controls.Add(this.lstSharding);
            this.tabRemoveSharding.Controls.Add(this.cmdRemoveSharding);
            this.tabRemoveSharding.Location = new System.Drawing.Point(4, 24);
            this.tabRemoveSharding.Name = "tabRemoveSharding";
            this.tabRemoveSharding.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemoveSharding.Size = new System.Drawing.Size(517, 229);
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
            this.lstSharding.Size = new System.Drawing.Size(191, 139);
            this.lstSharding.TabIndex = 37;
            // 
            // cmdRemoveSharding
            // 
            this.cmdRemoveSharding.Location = new System.Drawing.Point(64, 172);
            this.cmdRemoveSharding.Name = "cmdRemoveSharding";
            this.cmdRemoveSharding.Size = new System.Drawing.Size(124, 34);
            this.cmdRemoveSharding.TabIndex = 36;
            this.cmdRemoveSharding.Text = "Remove Sharding";
            this.cmdRemoveSharding.UseVisualStyleBackColor = true;
            this.cmdRemoveSharding.Click += new System.EventHandler(this.cmdRemoveSharding_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(216, 275);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(121, 32);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 319);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabSharding);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShardingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
            this.tabRemoveSharding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddSharding;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cmbKeyList;
        private System.Windows.Forms.Button cmdEnableCollectionSharding;
        private System.Windows.Forms.Button cmdEnableDBSharding;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TabControl tabSharding;
        private System.Windows.Forms.TabPage tabAddSharding;
        private System.Windows.Forms.TabPage tabShardingConfig;
        private System.Windows.Forms.NumericUpDown NumReplPort;
        private System.Windows.Forms.Label lblReplPort;
        private System.Windows.Forms.TextBox txtReplHost;
        private System.Windows.Forms.Label lblReplHost;
        private System.Windows.Forms.Label lblMainReplsetName;
        private System.Windows.Forms.TextBox txtReplsetName;
        private System.Windows.Forms.ListBox lstHost;
        private System.Windows.Forms.Button cmdAddHost;
        private System.Windows.Forms.Button cmdRemoveHost;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private System.Windows.Forms.CheckBox chkAdvance;
        private System.Windows.Forms.NumericUpDown NumMaxSize;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblShardingName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabRemoveSharding;
        private System.Windows.Forms.ListBox lstSharding;
        private System.Windows.Forms.Button cmdRemoveSharding;
    }
}