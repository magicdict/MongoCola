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
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.lblPrmInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.Location = new System.Drawing.Point(98, 153);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(187, 23);
            this.cmdInitReplset.TabIndex = 3;
            this.cmdInitReplset.Text = "初始化副本";
            this.cmdInitReplset.UseVisualStyleBackColor = true;
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(33, 34);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(335, 95);
            this.lstShard.TabIndex = 1;
            // 
            // lblPrmInfo
            // 
            this.lblPrmInfo.AutoSize = true;
            this.lblPrmInfo.Location = new System.Drawing.Point(30, 9);
            this.lblPrmInfo.Name = "lblPrmInfo";
            this.lblPrmInfo.Size = new System.Drawing.Size(53, 13);
            this.lblPrmInfo.TabIndex = 5;
            this.lblPrmInfo.Text = "lblPrmInfo";
            // 
            // frmReplset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 212);
            this.Controls.Add(this.lblPrmInfo);
            this.Controls.Add(this.cmdInitReplset);
            this.Controls.Add(this.lstShard);
            this.Name = "frmReplset";
            this.Text = "初始化副本组";
            this.Load += new System.EventHandler(this.frmReplset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstShard;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.Label lblPrmInfo;
    }
}