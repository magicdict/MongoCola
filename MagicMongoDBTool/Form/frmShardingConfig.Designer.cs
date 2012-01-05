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
            this.cmbReplsetName = new System.Windows.Forms.ComboBox();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.cmdAddSharding = new System.Windows.Forms.Button();
            this.lstShard = new System.Windows.Forms.ListBox();
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
            this.tabShardingConfig = new System.Windows.Forms.TabPage();
            this.tabSharding.SuspendLayout();
            this.tabAddSharding.SuspendLayout();
            this.tabShardingConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbReplsetName
            // 
            this.cmbReplsetName.FormattingEnabled = true;
            this.cmbReplsetName.Location = new System.Drawing.Point(94, 23);
            this.cmbReplsetName.Name = "cmbReplsetName";
            this.cmbReplsetName.Size = new System.Drawing.Size(216, 23);
            this.cmbReplsetName.TabIndex = 0;
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetName.Location = new System.Drawing.Point(23, 27);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(49, 15);
            this.lblReplsetName.TabIndex = 14;
            this.lblReplsetName.Text = "Replset";
            // 
            // cmdAddSharding
            // 
            this.cmdAddSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSharding.Location = new System.Drawing.Point(351, 21);
            this.cmdAddSharding.Name = "cmdAddSharding";
            this.cmdAddSharding.Size = new System.Drawing.Size(139, 33);
            this.cmdAddSharding.TabIndex = 2;
            this.cmdAddSharding.Text = "Add Sharding";
            this.cmdAddSharding.UseVisualStyleBackColor = false;
            this.cmdAddSharding.Click += new System.EventHandler(this.cmdAddSharding_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.ItemHeight = 15;
            this.lstShard.Location = new System.Drawing.Point(28, 61);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(461, 94);
            this.lstShard.TabIndex = 1;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.BackColor = System.Drawing.Color.Transparent;
            this.lblField.Location = new System.Drawing.Point(26, 126);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(71, 15);
            this.lblField.TabIndex = 34;
            this.lblField.Text = "IndexName";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(124, 122);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(256, 23);
            this.cmbKeyList.TabIndex = 30;
            // 
            // cmdEnableCollectionSharding
            // 
            this.cmdEnableCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableCollectionSharding.Location = new System.Drawing.Point(386, 74);
            this.cmdEnableCollectionSharding.Name = "cmdEnableCollectionSharding";
            this.cmdEnableCollectionSharding.Size = new System.Drawing.Size(99, 35);
            this.cmdEnableCollectionSharding.TabIndex = 31;
            this.cmdEnableCollectionSharding.Text = "Collection";
            this.cmdEnableCollectionSharding.UseVisualStyleBackColor = false;
            this.cmdEnableCollectionSharding.Click += new System.EventHandler(this.cmdEnableCollectionSharding_Click);
            // 
            // cmdEnableDBSharding
            // 
            this.cmdEnableDBSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableDBSharding.Location = new System.Drawing.Point(386, 27);
            this.cmdEnableDBSharding.Name = "cmdEnableDBSharding";
            this.cmdEnableDBSharding.Size = new System.Drawing.Size(99, 38);
            this.cmdEnableDBSharding.TabIndex = 28;
            this.cmdEnableDBSharding.Text = "DataBase";
            this.cmdEnableDBSharding.UseVisualStyleBackColor = false;
            this.cmdEnableDBSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(122, 77);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(256, 23);
            this.cmbCollection.TabIndex = 29;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(122, 32);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(256, 23);
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
            this.tabSharding.Location = new System.Drawing.Point(13, 21);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(525, 213);
            this.tabSharding.TabIndex = 35;
            // 
            // tabAddSharding
            // 
            this.tabAddSharding.Controls.Add(this.lblReplsetName);
            this.tabAddSharding.Controls.Add(this.lstShard);
            this.tabAddSharding.Controls.Add(this.cmdAddSharding);
            this.tabAddSharding.Controls.Add(this.cmbReplsetName);
            this.tabAddSharding.Location = new System.Drawing.Point(4, 24);
            this.tabAddSharding.Name = "tabAddSharding";
            this.tabAddSharding.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSharding.Size = new System.Drawing.Size(517, 185);
            this.tabAddSharding.TabIndex = 0;
            this.tabAddSharding.Text = "Add Sharding";
            this.tabAddSharding.UseVisualStyleBackColor = true;
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
            this.tabShardingConfig.Location = new System.Drawing.Point(4, 22);
            this.tabShardingConfig.Name = "tabShardingConfig";
            this.tabShardingConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabShardingConfig.Size = new System.Drawing.Size(517, 187);
            this.tabShardingConfig.TabIndex = 1;
            this.tabShardingConfig.Text = "Sharding Setting";
            this.tabShardingConfig.UseVisualStyleBackColor = true;
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 249);
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
            this.tabShardingConfig.ResumeLayout(false);
            this.tabShardingConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReplsetName;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.Button cmdAddSharding;
        private System.Windows.Forms.ListBox lstShard;
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
    }
}