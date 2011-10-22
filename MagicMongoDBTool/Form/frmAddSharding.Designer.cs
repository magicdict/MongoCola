namespace MagicMongoDBTool
{
    partial class frmAddSharding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSharding));
            this.cmbReplsetName = new System.Windows.Forms.ComboBox();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmbReplsetName);
            this.contentPanel.Controls.Add(this.lblReplsetName);
            this.contentPanel.Controls.Add(this.cmdInitReplset);
            this.contentPanel.Controls.Add(this.lstShard);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(426, 260);
            // 
            // cmbReplsetName
            // 
            this.cmbReplsetName.FormattingEnabled = true;
            this.cmbReplsetName.Location = new System.Drawing.Point(135, 49);
            this.cmbReplsetName.Name = "cmbReplsetName";
            this.cmbReplsetName.Size = new System.Drawing.Size(246, 21);
            this.cmbReplsetName.TabIndex = 15;
            this.cmbReplsetName.SelectedIndexChanged += new System.EventHandler(this.cmbReplsetName_SelectedIndexChanged);
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.Location = new System.Drawing.Point(49, 52);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 14;
            this.lblReplsetName.Text = "副本名称";
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.Location = new System.Drawing.Point(124, 188);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(187, 23);
            this.cmdInitReplset.TabIndex = 13;
            this.cmdInitReplset.Text = "添加Sharding";
            this.cmdInitReplset.UseVisualStyleBackColor = true;
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(46, 75);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(335, 95);
            this.lstShard.TabIndex = 12;
            // 
            // frmAddSharding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 323);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAddSharding";
            this.Text = "frmAddSharding";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReplsetName;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.ListBox lstShard;
    }
}