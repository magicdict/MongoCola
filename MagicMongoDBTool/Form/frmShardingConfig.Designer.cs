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
            this.cmdCollectionSharding = new System.Windows.Forms.Button();
            this.cmdEnableSharding = new System.Windows.Forms.Button();
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
            this.contentPanel.Size = new System.Drawing.Size(723, 316);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "索引名称";
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(173, 106);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(286, 21);
            this.cmbKeyList.TabIndex = 25;
            // 
            // cmdCollectionSharding
            // 
            this.cmdCollectionSharding.Location = new System.Drawing.Point(485, 70);
            this.cmdCollectionSharding.Name = "cmdCollectionSharding";
            this.cmdCollectionSharding.Size = new System.Drawing.Size(85, 21);
            this.cmdCollectionSharding.TabIndex = 24;
            this.cmdCollectionSharding.Text = "数据集分片";
            this.cmdCollectionSharding.UseVisualStyleBackColor = true;
            this.cmdCollectionSharding.Click += new System.EventHandler(this.cmdCollectionSharding_Click);
            // 
            // cmdEnableSharding
            // 
            this.cmdEnableSharding.Location = new System.Drawing.Point(485, 31);
            this.cmdEnableSharding.Name = "cmdEnableSharding";
            this.cmdEnableSharding.Size = new System.Drawing.Size(85, 23);
            this.cmdEnableSharding.TabIndex = 23;
            this.cmdEnableSharding.Text = "数据库分片";
            this.cmdEnableSharding.UseVisualStyleBackColor = true;
            this.cmdEnableSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(145, 70);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(314, 21);
            this.cmbCollection.TabIndex = 22;
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(106, 31);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(353, 21);
            this.cmbDataBase.TabIndex = 21;
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.Location = new System.Drawing.Point(55, 74);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(67, 13);
            this.lblCollection.TabIndex = 20;
            this.lblCollection.Text = "数据集名称";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
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
            this.ClientSize = new System.Drawing.Size(725, 379);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmShardingConfig";
            this.Text = "frmShardingConfig";
            this.Load += new System.EventHandler(this.frmShardingConfig_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKeyList;
        private System.Windows.Forms.Button cmdCollectionSharding;
        private System.Windows.Forms.Button cmdEnableSharding;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblDBName;
    }
}