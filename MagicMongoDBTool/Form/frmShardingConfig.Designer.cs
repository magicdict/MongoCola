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
            this.cmbReplsetName.Location = new System.Drawing.Point(81, 20);
            this.cmbReplsetName.Name = "cmbReplsetName";
            this.cmbReplsetName.Size = new System.Drawing.Size(186, 21);
            this.cmbReplsetName.TabIndex = 0;
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.BackColor = System.Drawing.Color.Transparent;
            this.lblReplsetName.Location = new System.Drawing.Point(20, 23);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 14;
            this.lblReplsetName.Text = "副本名称";
            // 
            // cmdAddSharding
            // 
            this.cmdAddSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSharding.Location = new System.Drawing.Point(273, 17);
            this.cmdAddSharding.Name = "cmdAddSharding";
            this.cmdAddSharding.Size = new System.Drawing.Size(119, 29);
            this.cmdAddSharding.TabIndex = 2;
            this.cmdAddSharding.Text = "添加分片";
            this.cmdAddSharding.UseVisualStyleBackColor = false;
            this.cmdAddSharding.Click += new System.EventHandler(this.cmdAddSharding_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(24, 53);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(368, 82);
            this.lstShard.TabIndex = 1;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.BackColor = System.Drawing.Color.Transparent;
            this.lblField.Location = new System.Drawing.Point(21, 98);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(55, 13);
            this.lblField.TabIndex = 34;
            this.lblField.Text = "索引名称";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(105, 95);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(220, 21);
            this.cmbKeyList.TabIndex = 30;
            // 
            // cmdEnableCollectionSharding
            // 
            this.cmdEnableCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableCollectionSharding.Location = new System.Drawing.Point(331, 64);
            this.cmdEnableCollectionSharding.Name = "cmdEnableCollectionSharding";
            this.cmdEnableCollectionSharding.Size = new System.Drawing.Size(85, 30);
            this.cmdEnableCollectionSharding.TabIndex = 31;
            this.cmdEnableCollectionSharding.Text = "数据集分片";
            this.cmdEnableCollectionSharding.UseVisualStyleBackColor = false;
            this.cmdEnableCollectionSharding.Click += new System.EventHandler(this.cmdEnableCollectionSharding_Click);
            // 
            // cmdEnableDBSharding
            // 
            this.cmdEnableDBSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableDBSharding.Location = new System.Drawing.Point(331, 23);
            this.cmdEnableDBSharding.Name = "cmdEnableDBSharding";
            this.cmdEnableDBSharding.Size = new System.Drawing.Size(85, 33);
            this.cmdEnableDBSharding.TabIndex = 28;
            this.cmdEnableDBSharding.Text = "数据库分片";
            this.cmdEnableDBSharding.UseVisualStyleBackColor = false;
            this.cmdEnableDBSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(105, 67);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(220, 21);
            this.cmbCollection.TabIndex = 29;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(105, 28);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(220, 21);
            this.cmbDataBase.TabIndex = 27;
            this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.BackColor = System.Drawing.Color.Transparent;
            this.lblCollection.Location = new System.Drawing.Point(21, 67);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(67, 13);
            this.lblCollection.TabIndex = 33;
            this.lblCollection.Text = "数据集名称";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.BackColor = System.Drawing.Color.Transparent;
            this.lblDBName.Location = new System.Drawing.Point(21, 31);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(67, 13);
            this.lblDBName.TabIndex = 32;
            this.lblDBName.Text = "数据库名称";
            // 
            // tabSharding
            // 
            this.tabSharding.Controls.Add(this.tabAddSharding);
            this.tabSharding.Controls.Add(this.tabShardingConfig);
            this.tabSharding.Location = new System.Drawing.Point(11, 18);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(450, 185);
            this.tabSharding.TabIndex = 35;
            // 
            // tabAddSharding
            // 
            this.tabAddSharding.Controls.Add(this.lblReplsetName);
            this.tabAddSharding.Controls.Add(this.lstShard);
            this.tabAddSharding.Controls.Add(this.cmdAddSharding);
            this.tabAddSharding.Controls.Add(this.cmbReplsetName);
            this.tabAddSharding.Location = new System.Drawing.Point(4, 22);
            this.tabAddSharding.Name = "tabAddSharding";
            this.tabAddSharding.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSharding.Size = new System.Drawing.Size(442, 159);
            this.tabAddSharding.TabIndex = 0;
            this.tabAddSharding.Text = "添加分片";
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
            this.tabShardingConfig.Size = new System.Drawing.Size(442, 159);
            this.tabShardingConfig.TabIndex = 1;
            this.tabShardingConfig.Text = "分片设置";
            this.tabShardingConfig.UseVisualStyleBackColor = true;
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 216);
            this.Controls.Add(this.tabSharding);
            this.Name = "frmShardingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分片管理";
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