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
            this.lstShard = new System.Windows.Forms.ListBox();
            this.cmdInitReplset = new System.Windows.Forms.Button();
            this.txtReplsetName = new System.Windows.Forms.TextBox();
            this.lblReplsetName = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblCollection = new System.Windows.Forms.Label();
            this.txtDBcollection = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // cmdInitReplset
            // 
            this.cmdInitReplset.Location = new System.Drawing.Point(76, 212);
            this.cmdInitReplset.Name = "cmdInitReplset";
            this.cmdInitReplset.Size = new System.Drawing.Size(187, 23);
            this.cmdInitReplset.TabIndex = 4;
            this.cmdInitReplset.Text = "添加Sharding";
            this.cmdInitReplset.UseVisualStyleBackColor = true;
            this.cmdInitReplset.Click += new System.EventHandler(this.cmdInitReplset_Click);
            // 
            // txtReplsetName
            // 
            this.txtReplsetName.Location = new System.Drawing.Point(76, 6);
            this.txtReplsetName.Name = "txtReplsetName";
            this.txtReplsetName.Size = new System.Drawing.Size(277, 20);
            this.txtReplsetName.TabIndex = 6;
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
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(15, 145);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(67, 13);
            this.lblDBName.TabIndex = 7;
            this.lblDBName.Text = "数据库名称";
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.Location = new System.Drawing.Point(15, 169);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(67, 13);
            this.lblCollection.TabIndex = 8;
            this.lblCollection.Text = "数据集名称";
            // 
            // txtDBcollection
            // 
            this.txtDBcollection.Location = new System.Drawing.Point(101, 164);
            this.txtDBcollection.Name = "txtDBcollection";
            this.txtDBcollection.Size = new System.Drawing.Size(246, 20);
            this.txtDBcollection.TabIndex = 9;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(101, 142);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(246, 20);
            this.txtDBName.TabIndex = 10;
            // 
            // frmAddSharding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 247);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtDBcollection);
            this.Controls.Add(this.lblCollection);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.txtReplsetName);
            this.Controls.Add(this.lblReplsetName);
            this.Controls.Add(this.cmdInitReplset);
            this.Controls.Add(this.lstShard);
            this.Name = "frmAddSharding";
            this.Text = "frmAddSharding";
            this.Load += new System.EventHandler(this.frmAddSharding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstShard;
        private System.Windows.Forms.Button cmdInitReplset;
        private System.Windows.Forms.TextBox txtReplsetName;
        private System.Windows.Forms.Label lblReplsetName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.TextBox txtDBcollection;
        private System.Windows.Forms.TextBox txtDBName;
    }
}