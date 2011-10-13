namespace MagicMongoDBTool
{
    partial class frmCollectionIndex
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
            this.lstIndex = new System.Windows.Forms.ListView();
            this.cmdDelIndex = new System.Windows.Forms.Button();
            this.cmdAddIndex = new System.Windows.Forms.Button();
            this.lblIndexKey = new System.Windows.Forms.Label();
            this.txtIndexKey = new System.Windows.Forms.TextBox();
            this.chkAsc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstIndex
            // 
            this.lstIndex.Location = new System.Drawing.Point(24, 24);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(429, 180);
            this.lstIndex.TabIndex = 0;
            this.lstIndex.UseCompatibleStateImageBehavior = false;
            this.lstIndex.View = System.Windows.Forms.View.Details;
            // 
            // cmdDelIndex
            // 
            this.cmdDelIndex.Location = new System.Drawing.Point(364, 218);
            this.cmdDelIndex.Name = "cmdDelIndex";
            this.cmdDelIndex.Size = new System.Drawing.Size(75, 23);
            this.cmdDelIndex.TabIndex = 1;
            this.cmdDelIndex.Text = "删除索引";
            this.cmdDelIndex.UseVisualStyleBackColor = true;
            this.cmdDelIndex.Click += new System.EventHandler(this.cmdDelIndex_Click);
            // 
            // cmdAddIndex
            // 
            this.cmdAddIndex.Location = new System.Drawing.Point(270, 218);
            this.cmdAddIndex.Name = "cmdAddIndex";
            this.cmdAddIndex.Size = new System.Drawing.Size(75, 23);
            this.cmdAddIndex.TabIndex = 2;
            this.cmdAddIndex.Text = "添加索引";
            this.cmdAddIndex.UseVisualStyleBackColor = true;
            this.cmdAddIndex.Click += new System.EventHandler(this.cmdAddIndex_Click);
            // 
            // lblIndexKey
            // 
            this.lblIndexKey.AutoSize = true;
            this.lblIndexKey.Location = new System.Drawing.Point(34, 223);
            this.lblIndexKey.Name = "lblIndexKey";
            this.lblIndexKey.Size = new System.Drawing.Size(43, 13);
            this.lblIndexKey.TabIndex = 3;
            this.lblIndexKey.Text = "索引键";
            // 
            // txtIndexKey
            // 
            this.txtIndexKey.Location = new System.Drawing.Point(86, 220);
            this.txtIndexKey.Name = "txtIndexKey";
            this.txtIndexKey.Size = new System.Drawing.Size(100, 20);
            this.txtIndexKey.TabIndex = 4;
            // 
            // chkAsc
            // 
            this.chkAsc.AutoSize = true;
            this.chkAsc.Checked = true;
            this.chkAsc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsc.Location = new System.Drawing.Point(192, 222);
            this.chkAsc.Name = "chkAsc";
            this.chkAsc.Size = new System.Drawing.Size(50, 17);
            this.chkAsc.TabIndex = 5;
            this.chkAsc.Text = "升序";
            this.chkAsc.UseVisualStyleBackColor = true;
            // 
            // frmCollectionIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 269);
            this.Controls.Add(this.chkAsc);
            this.Controls.Add(this.txtIndexKey);
            this.Controls.Add(this.lblIndexKey);
            this.Controls.Add(this.cmdAddIndex);
            this.Controls.Add(this.cmdDelIndex);
            this.Controls.Add(this.lstIndex);
            this.Name = "frmCollectionIndex";
            this.Text = "索引管理";
            this.Load += new System.EventHandler(this.frmCollectionIndex_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstIndex;
        private System.Windows.Forms.Button cmdDelIndex;
        private System.Windows.Forms.Button cmdAddIndex;
        private System.Windows.Forms.Label lblIndexKey;
        private System.Windows.Forms.TextBox txtIndexKey;
        private System.Windows.Forms.CheckBox chkAsc;
    }
}