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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKeyList = new System.Windows.Forms.ComboBox();
            this.cmdCollectionSharding = new System.Windows.Forms.VistaButton();
            this.cmdEnableSharding = new System.Windows.Forms.VistaButton();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.label1);
            this.contentPanel.Controls.Add(this.cmbKeyList);
            this.contentPanel.Controls.Add(this.cmdCollectionSharding);
            this.contentPanel.Controls.Add(this.cmdEnableSharding);
            this.contentPanel.Controls.Add(this.cmbCollection);
            this.contentPanel.Controls.Add(this.cmbDataBase);
            this.contentPanel.Controls.Add(this.lblCollection);
            this.contentPanel.Controls.Add(this.lblDBName);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(723, 149);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "索引名称";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(106, 106);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(353, 21);
            this.cmbKeyList.TabIndex = 3;
            // 
            // cmdCollectionSharding
            // 
            this.cmdCollectionSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdCollectionSharding.Location = new System.Drawing.Point(485, 70);
            this.cmdCollectionSharding.Name = "cmdCollectionSharding";
            this.cmdCollectionSharding.Size = new System.Drawing.Size(85, 30);
            this.cmdCollectionSharding.TabIndex = 4;
            this.cmdCollectionSharding.Text = "数据集分片";
            this.cmdCollectionSharding.Click += new System.EventHandler(this.cmdCollectionSharding_Click);
            // 
            // cmdEnableSharding
            // 
            this.cmdEnableSharding.BackColor = System.Drawing.Color.Transparent;
            this.cmdEnableSharding.Location = new System.Drawing.Point(485, 31);
            this.cmdEnableSharding.Name = "cmdEnableSharding";
            this.cmdEnableSharding.Size = new System.Drawing.Size(85, 33);
            this.cmdEnableSharding.TabIndex = 1;
            this.cmdEnableSharding.Text = "数据库分片";
            this.cmdEnableSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(106, 70);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(353, 21);
            this.cmbCollection.TabIndex = 2;
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(106, 31);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(353, 21);
            this.cmbDataBase.TabIndex = 0;
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.BackColor = System.Drawing.Color.Transparent;
            this.lblCollection.Location = new System.Drawing.Point(22, 70);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(67, 13);
            this.lblCollection.TabIndex = 20;
            this.lblCollection.Text = "数据集名称";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.BackColor = System.Drawing.Color.Transparent;
            this.lblDBName.Location = new System.Drawing.Point(22, 34);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(67, 13);
            this.lblDBName.TabIndex = 19;
            this.lblDBName.Text = "数据库名称";
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 212);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShardingConfig";
            this.ShowSelectSkinButton = false;
            this.Text = "数据分片管理";
            this.Load += new System.EventHandler(this.frmShardingConfig_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKeyList;
        private System.Windows.Forms.VistaButton cmdCollectionSharding;
        private System.Windows.Forms.VistaButton cmdEnableSharding;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblDBName;
    }
}