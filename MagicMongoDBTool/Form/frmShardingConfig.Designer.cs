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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShardingConfig));
            this.cmbReplsetName = new System.Windows.Forms.ComboBox();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.cmdAddSharding = new System.Windows.Forms.VistaButton();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKeyList = new System.Windows.Forms.ComboBox();
            this.cmdCollectionSharding = new System.Windows.Forms.VistaButton();
            this.cmdEnableSharding = new System.Windows.Forms.VistaButton();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tabSharding = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contentPanel.SuspendLayout();
            this.tabSharding.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.tabSharding);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(474, 232);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "索引名称";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(105, 95);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(220, 21);
            this.cmbKeyList.TabIndex = 30;
            // 
            // cmdCollectionSharding
            // 
            this.cmdCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdCollectionSharding.Location = new System.Drawing.Point(331, 64);
            this.cmdCollectionSharding.Name = "cmdCollectionSharding";
            this.cmdCollectionSharding.Size = new System.Drawing.Size(85, 30);
            this.cmdCollectionSharding.TabIndex = 31;
            this.cmdCollectionSharding.Text = "数据集分片";
            this.cmdCollectionSharding.Click += new System.EventHandler(this.cmdCollectionSharding_Click);
            // 
            // cmdEnableSharding
            // 
            this.cmdEnableSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableSharding.Location = new System.Drawing.Point(331, 23);
            this.cmdEnableSharding.Name = "cmdEnableSharding";
            this.cmdEnableSharding.Size = new System.Drawing.Size(85, 33);
            this.cmdEnableSharding.TabIndex = 28;
            this.cmdEnableSharding.Text = "数据库分片";
            this.cmdEnableSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
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
            this.tabSharding.Controls.Add(this.tabPage1);
            this.tabSharding.Controls.Add(this.tabPage2);
            this.tabSharding.Location = new System.Drawing.Point(11, 18);
            this.tabSharding.Name = "tabSharding";
            this.tabSharding.SelectedIndex = 0;
            this.tabSharding.Size = new System.Drawing.Size(450, 185);
            this.tabSharding.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblReplsetName);
            this.tabPage1.Controls.Add(this.lstShard);
            this.tabPage1.Controls.Add(this.cmdAddSharding);
            this.tabPage1.Controls.Add(this.cmbReplsetName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(442, 159);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "添加分片";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblDBName);
            this.tabPage2.Controls.Add(this.cmbKeyList);
            this.tabPage2.Controls.Add(this.lblCollection);
            this.tabPage2.Controls.Add(this.cmdCollectionSharding);
            this.tabPage2.Controls.Add(this.cmbDataBase);
            this.tabPage2.Controls.Add(this.cmdEnableSharding);
            this.tabPage2.Controls.Add(this.cmbCollection);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 159);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分片设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 295);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmShardingConfig";
            this.ShowSelectSkinButton = false;
            this.Text = "分片管理";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabSharding.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReplsetName;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.VistaButton cmdAddSharding;
        private System.Windows.Forms.ListBox lstShard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKeyList;
        private System.Windows.Forms.VistaButton cmdCollectionSharding;
        private System.Windows.Forms.VistaButton cmdEnableSharding;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TabControl tabSharding;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}