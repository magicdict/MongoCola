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
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.txtReplsetName = new System.Windows.Forms.TextBox();
            this.lblDesr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.Location = new System.Drawing.Point(30, 22);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 0;
            this.lblReplsetName.Text = "副本名称";
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(33, 85);
            this.lstShard.Name = "lstShard";
            this.lstShard.Size = new System.Drawing.Size(335, 95);
            this.lstShard.TabIndex = 1;
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.Location = new System.Drawing.Point(91, 186);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(187, 23);
            this.cmdInitReplset.TabIndex = 3;
            this.cmdInitReplset.Text = "初始化副本";
            this.cmdInitReplset.UseVisualStyleBackColor = true;
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(91, 19);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(277, 20);
            this.txtReplsetName.TabIndex = 4;
            // 
            // lblDesr
            // 
            this.lblDesr.Location = new System.Drawing.Point(30, 53);
            this.lblDesr.Name = "lblDesr";
            this.lblDesr.Size = new System.Drawing.Size(338, 29);
            this.lblDesr.TabIndex = 5;
            this.lblDesr.Text = "选中需要加入到这个副本组的Shard，这些Shard将被作为候补Shard。[当前服务器将默认为首选Shard]";
            // 
            // frmReplset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 222);
            this.Controls.Add(this.lblDesr);
            this.Controls.Add(this.txtReplsetName);
            this.Controls.Add(this.cmdInitReplset);
            this.Controls.Add(this.lstShard);
            this.Controls.Add(this.lblReplsetName);
            this.Name = "frmReplset";
            this.Text = "初始化副本组";
            this.Load += new System.EventHandler(this.frmReplset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.ListBox lstShard;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.TextBox txtReplsetName;
        private System.Windows.Forms.Label lblDesr;
    }
}