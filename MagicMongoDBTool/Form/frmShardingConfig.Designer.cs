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
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.cmdEnableSharding = new System.Windows.Forms.Button();
            this.cmdCollectionSharding = new System.Windows.Forms.Button();
            this.cmbKeyList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(132, 33);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(353, 21);
            this.cmbDataBase.TabIndex = 13;
            this.cmbDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbDataBase_SelectedIndexChanged);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.Location = new System.Drawing.Point(81, 76);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(67, 13);
            this.lblCollection.TabIndex = 12;
            this.lblCollection.Text = "数据集名称";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(48, 36);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(67, 13);
            this.lblDBName.TabIndex = 11;
            this.lblDBName.Text = "数据库名称";
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(171, 72);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(314, 21);
            this.cmbCollection.TabIndex = 14;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // cmdEnableSharding
            // 
            this.cmdEnableSharding.Location = new System.Drawing.Point(511, 33);
            this.cmdEnableSharding.Name = "cmdEnableSharding";
            this.cmdEnableSharding.Size = new System.Drawing.Size(85, 23);
            this.cmdEnableSharding.TabIndex = 15;
            this.cmdEnableSharding.Text = "数据库分片";
            this.cmdEnableSharding.UseVisualStyleBackColor = true;
            this.cmdEnableSharding.Click += new System.EventHandler(this.cmdEnableSharding_Click);
            // 
            // cmdCollectionSharding
            // 
            this.cmdCollectionSharding.Location = new System.Drawing.Point(511, 72);
            this.cmdCollectionSharding.Name = "cmdCollectionSharding";
            this.cmdCollectionSharding.Size = new System.Drawing.Size(85, 21);
            this.cmdCollectionSharding.TabIndex = 16;
            this.cmdCollectionSharding.Text = "数据集分片";
            this.cmdCollectionSharding.UseVisualStyleBackColor = true;
            this.cmdCollectionSharding.Click += new System.EventHandler(this.cmdCollectionSharding_Click);
            // 
            // cmbKeyList
            // 
            this.cmbKeyList.FormattingEnabled = true;
            this.cmbKeyList.Location = new System.Drawing.Point(199, 108);
            this.cmbKeyList.Name = "cmbKeyList";
            this.cmbKeyList.Size = new System.Drawing.Size(286, 21);
            this.cmbKeyList.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "索引名称";
            // 
            // frmShardingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 191);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKeyList);
            this.Controls.Add(this.cmdCollectionSharding);
            this.Controls.Add(this.cmdEnableSharding);
            this.Controls.Add(this.cmbCollection);
            this.Controls.Add(this.cmbDataBase);
            this.Controls.Add(this.lblCollection);
            this.Controls.Add(this.lblDBName);
            this.Name = "frmShardingConfig";
            this.Text = "frmShardingConfig";
            this.Load += new System.EventHandler(this.frmShardingConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.Button cmdEnableSharding;
        private System.Windows.Forms.Button cmdCollectionSharding;
        private System.Windows.Forms.ComboBox cmbKeyList;
        private System.Windows.Forms.Label label1;
    }
}