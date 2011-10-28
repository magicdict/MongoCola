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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCollectionIndex));
            this.chkAsc = new System.Windows.Forms.CheckBox();
            this.txtIndexKey = new System.Windows.Forms.TextBox();
            this.lblIndexKey = new System.Windows.Forms.Label();
            this.cmdAddIndex = new System.Windows.Forms.VistaButton();
            this.cmdDelIndex = new System.Windows.Forms.VistaButton();
            this.lstIndex = new System.Windows.Forms.ListView();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.chkAsc);
            this.contentPanel.Controls.Add(this.txtIndexKey);
            this.contentPanel.Controls.Add(this.lblIndexKey);
            this.contentPanel.Controls.Add(this.cmdAddIndex);
            this.contentPanel.Controls.Add(this.cmdDelIndex);
            this.contentPanel.Controls.Add(this.lstIndex);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(465, 294);
            // 
            // chkAsc
            // 
            this.chkAsc.AutoSize = true;
            this.chkAsc.BackColor = System.Drawing.Color.Transparent;
            this.chkAsc.Checked = true;
            this.chkAsc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsc.Location = new System.Drawing.Point(179, 223);
            this.chkAsc.Name = "chkAsc";
            this.chkAsc.Size = new System.Drawing.Size(50, 17);
            this.chkAsc.TabIndex = 11;
            this.chkAsc.Text = "升序";
            this.chkAsc.UseVisualStyleBackColor = false;
            // 
            // txtIndexKey
            // 
            this.txtIndexKey.Location = new System.Drawing.Point(73, 221);
            this.txtIndexKey.Name = "txtIndexKey";
            this.txtIndexKey.Size = new System.Drawing.Size(100, 20);
            this.txtIndexKey.TabIndex = 10;
            // 
            // lblIndexKey
            // 
            this.lblIndexKey.AutoSize = true;
            this.lblIndexKey.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexKey.Location = new System.Drawing.Point(21, 224);
            this.lblIndexKey.Name = "lblIndexKey";
            this.lblIndexKey.Size = new System.Drawing.Size(43, 13);
            this.lblIndexKey.TabIndex = 9;
            this.lblIndexKey.Text = "索引键";
            // 
            // cmdAddIndex
            // 
            this.cmdAddIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddIndex.Location = new System.Drawing.Point(245, 221);
            this.cmdAddIndex.Name = "cmdAddIndex";
            this.cmdAddIndex.Size = new System.Drawing.Size(75, 35);
            this.cmdAddIndex.TabIndex = 8;
            this.cmdAddIndex.Text = "添加索引";
            this.cmdAddIndex.Click += new System.EventHandler(this.cmdAddIndex_Click);
            // 
            // cmdDelIndex
            // 
            this.cmdDelIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelIndex.Location = new System.Drawing.Point(326, 221);
            this.cmdDelIndex.Name = "cmdDelIndex";
            this.cmdDelIndex.Size = new System.Drawing.Size(75, 35);
            this.cmdDelIndex.TabIndex = 7;
            this.cmdDelIndex.Text = "删除索引";
            this.cmdDelIndex.Click += new System.EventHandler(this.cmdDelIndex_Click);
            // 
            // lstIndex
            // 
            this.lstIndex.Location = new System.Drawing.Point(11, 25);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(429, 180);
            this.lstIndex.TabIndex = 6;
            this.lstIndex.UseCompatibleStateImageBehavior = false;
            this.lstIndex.View = System.Windows.Forms.View.Details;
            // 
            // frmCollectionIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 357);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCollectionIndex";
            this.ShowSelectSkinButton = false;
            this.Text = "数据集索引";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAsc;
        private System.Windows.Forms.TextBox txtIndexKey;
        private System.Windows.Forms.Label lblIndexKey;
        private System.Windows.Forms.VistaButton cmdAddIndex;
        private System.Windows.Forms.VistaButton cmdDelIndex;
        private System.Windows.Forms.ListView lstIndex;
    }
}