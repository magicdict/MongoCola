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
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.lstShard = new System.Windows.Forms.ListBox();
            this.cmbReplsetName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblReplsetName
            // 
            this.lblReplsetName.AutoSize = true;
            this.lblReplsetName.Location = new System.Drawing.Point(15, 9);
            this.lblReplsetName.Name = "lblReplsetName";
            this.lblReplsetName.Size = new System.Drawing.Size(55, 13);
            this.lblReplsetName.TabIndex = 5;
            this.lblReplsetName.Text = "副本名称";
            // 
            // cmdInitReplset
            // 
            this.cmdInitReplset.Location = new System.Drawing.Point(90, 145);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(187, 23);
            this.cmdInitReplset.TabIndex = 4;
            this.cmdInitReplset.Text = "添加Sharding";
            this.cmdInitReplset.UseVisualStyleBackColor = true;
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // lstShard
            // 
            this.lstShard.FormattingEnabled = true;
            this.lstShard.Location = new System.Drawing.Point(12, 32);
            this.lstShard.Name = "lstShard";
            this.lstShard.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstShard.Size = new System.Drawing.Size(335, 95);
            this.lstShard.TabIndex = 2;
            // 
            // cmbReplsetName
            // 
            this.cmbReplsetName.FormattingEnabled = true;
            this.cmbReplsetName.Location = new System.Drawing.Point(101, 6);
            this.cmbReplsetName.Name = "cmbReplsetName";
            this.cmbReplsetName.Size = new System.Drawing.Size(246, 21);
            this.cmbReplsetName.TabIndex = 11;
            this.cmbReplsetName.SelectedIndexChanged += new System.EventHandler(this.cmbReplsetName_SelectedIndexChanged);
            // 
            // frmAddSharding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 181);
            this.Controls.Add(this.cmbReplsetName);
            this.Controls.Add(this.lblReplsetName);
            this.Controls.Add(this.cmdInitReplset);
            this.Controls.Add(this.lstShard);
            this.Name = "frmAddSharding";
            this.Text = "添加分片";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstShard;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.ComboBox cmbReplsetName;
    }
}