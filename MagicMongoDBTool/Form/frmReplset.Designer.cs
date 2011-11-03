namespace MagicMongoDBTool
{
    partial class frmReplset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplset));
            this.lblPrmInfo = new System.Windows.Forms.Label();
            this.cmdInitReplset = new System.Windows.Forms.VistaButton();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lblPrmInfo);
            this.contentPanel.Controls.Add(this.cmdInitReplset);
            this.contentPanel.Controls.Add(this.lstShard);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(383, 186);
            // 
            // lblPrmInfo
            // 
            this.lblPrmInfo.AutoSize = true;
            this.lblPrmInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPrmInfo.Location = new System.Drawing.Point(22, 12);
            this.lblPrmInfo.Name = "lblPrmInfo";
            this.lblPrmInfo.Size = new System.Drawing.Size(53, 13);
            this.lblPrmInfo.TabIndex = 8;
            this.lblPrmInfo.Text = "lblPrmInfo";
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.BackColor = System.Drawing.Color.Transparent;
            this.cmdInitReplset.Location = new System.Drawing.Point(134, 140);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(102, 28);
            this.cmdInitReplset.TabIndex = 7;
            this.cmdInitReplset.Text = "初始化副本";
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(25, 39);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(335, 95);
            this.lstShard.TabIndex = 6;
            // 
            // frmReplset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 249);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReplset";
            this.ShowSelectSkinButton = false;
            this.Text = "初始化副本";
            this.Load += new System.EventHandler(this.frmReplset_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrmInfo;
        private System.Windows.Forms.VistaButton cmdInitReplset;
        private System.Windows.Forms.ListBox lstShard;
    }
}