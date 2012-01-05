using System.Windows.Forms;
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
            this.cmdAddIndex = new System.Windows.Forms.Button();
            this.cmdDelIndex = new System.Windows.Forms.Button();
            this.lstIndex = new System.Windows.Forms.ListView();
            this.tabIndexMgr = new System.Windows.Forms.TabControl();
            this.tabCurrentIndex = new System.Windows.Forms.TabPage();
            this.tabIndexManager = new System.Windows.Forms.TabPage();
            this.txtIndexName = new System.Windows.Forms.TextBox();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.chkIsUnique = new System.Windows.Forms.CheckBox();
            this.chkIsSparse = new System.Windows.Forms.CheckBox();
            this.chkIsDroppedDups = new System.Windows.Forms.CheckBox();
            this.chkIsBackground = new System.Windows.Forms.CheckBox();
            this.ctlIndexCreate5 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate4 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate3 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate2 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate1 = new MagicMongoDBTool.ctlIndexCreate();
            this.tabIndexMgr.SuspendLayout();
            this.tabCurrentIndex.SuspendLayout();
            this.tabIndexManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddIndex
            // 
            this.cmdAddIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddIndex.Location = new System.Drawing.Point(437, 214);
            this.cmdAddIndex.Name = "cmdAddIndex";
            this.cmdAddIndex.Size = new System.Drawing.Size(108, 35);
            this.cmdAddIndex.TabIndex = 8;
            this.cmdAddIndex.Text = "Create Index";
            this.cmdAddIndex.UseVisualStyleBackColor = false;
            this.cmdAddIndex.Click += new System.EventHandler(this.cmdAddIndex_Click);
            // 
            // cmdDelIndex
            // 
            this.cmdDelIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelIndex.Location = new System.Drawing.Point(432, 214);
            this.cmdDelIndex.Name = "cmdDelIndex";
            this.cmdDelIndex.Size = new System.Drawing.Size(113, 35);
            this.cmdDelIndex.TabIndex = 7;
            this.cmdDelIndex.Text = "Delect Index";
            this.cmdDelIndex.UseVisualStyleBackColor = false;
            this.cmdDelIndex.Click += new System.EventHandler(this.cmdDelIndex_Click);
            // 
            // lstIndex
            // 
            this.lstIndex.CheckBoxes = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 6);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(539, 202);
            this.lstIndex.TabIndex = 6;
            this.lstIndex.UseCompatibleStateImageBehavior = false;
            this.lstIndex.View = System.Windows.Forms.View.Details;
            // 
            // tabIndexMgr
            // 
            this.tabIndexMgr.Controls.Add(this.tabCurrentIndex);
            this.tabIndexMgr.Controls.Add(this.tabIndexManager);
            this.tabIndexMgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIndexMgr.Location = new System.Drawing.Point(0, 0);
            this.tabIndexMgr.Name = "tabIndexMgr";
            this.tabIndexMgr.SelectedIndex = 0;
            this.tabIndexMgr.Size = new System.Drawing.Size(561, 283);
            this.tabIndexMgr.TabIndex = 12;
            // 
            // tabCurrentIndex
            // 
            this.tabCurrentIndex.Controls.Add(this.cmdDelIndex);
            this.tabCurrentIndex.Controls.Add(this.lstIndex);
            this.tabCurrentIndex.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentIndex.Name = "tabCurrentIndex";
            this.tabCurrentIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentIndex.Size = new System.Drawing.Size(553, 257);
            this.tabCurrentIndex.TabIndex = 0;
            this.tabCurrentIndex.Text = "Current Index";
            this.tabCurrentIndex.UseVisualStyleBackColor = true;
            // 
            // tabIndexManager
            // 
            this.tabIndexManager.BackColor = System.Drawing.Color.White;
            this.tabIndexManager.Controls.Add(this.txtIndexName);
            this.tabIndexManager.Controls.Add(this.lblIndexName);
            this.tabIndexManager.Controls.Add(this.chkIsUnique);
            this.tabIndexManager.Controls.Add(this.chkIsSparse);
            this.tabIndexManager.Controls.Add(this.chkIsDroppedDups);
            this.tabIndexManager.Controls.Add(this.chkIsBackground);
            this.tabIndexManager.Controls.Add(this.cmdAddIndex);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate5);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate4);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate3);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate2);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate1);
            this.tabIndexManager.Location = new System.Drawing.Point(4, 22);
            this.tabIndexManager.Name = "tabIndexManager";
            this.tabIndexManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndexManager.Size = new System.Drawing.Size(553, 257);
            this.tabIndexManager.TabIndex = 1;
            this.tabIndexManager.Text = "Create Index";
            // 
            // txtIndexName
            // 
            this.txtIndexName.Location = new System.Drawing.Point(102, 222);
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Size = new System.Drawing.Size(329, 20);
            this.txtIndexName.TabIndex = 19;
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.Location = new System.Drawing.Point(20, 225);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(61, 13);
            this.lblIndexName.TabIndex = 18;
            this.lblIndexName.Text = "IndexName";
            // 
            // chkIsUnique
            // 
            this.chkIsUnique.AutoSize = true;
            this.chkIsUnique.Location = new System.Drawing.Point(402, 190);
            this.chkIsUnique.Name = "chkIsUnique";
            this.chkIsUnique.Size = new System.Drawing.Size(89, 17);
            this.chkIsUnique.TabIndex = 16;
            this.chkIsUnique.Text = "Unique Index";
            this.chkIsUnique.UseVisualStyleBackColor = true;
            // 
            // chkIsSparse
            // 
            this.chkIsSparse.AutoSize = true;
            this.chkIsSparse.Location = new System.Drawing.Point(296, 190);
            this.chkIsSparse.Name = "chkIsSparse";
            this.chkIsSparse.Size = new System.Drawing.Size(88, 17);
            this.chkIsSparse.TabIndex = 15;
            this.chkIsSparse.Text = "Sparse Index";
            this.chkIsSparse.UseVisualStyleBackColor = true;
            // 
            // chkIsDroppedDups
            // 
            this.chkIsDroppedDups.AutoSize = true;
            this.chkIsDroppedDups.Location = new System.Drawing.Point(169, 191);
            this.chkIsDroppedDups.Name = "chkIsDroppedDups";
            this.chkIsDroppedDups.Size = new System.Drawing.Size(121, 17);
            this.chkIsDroppedDups.TabIndex = 14;
            this.chkIsDroppedDups.Text = "DroppedDups Index";
            this.chkIsDroppedDups.UseVisualStyleBackColor = true;
            // 
            // chkIsBackground
            // 
            this.chkIsBackground.AutoSize = true;
            this.chkIsBackground.Location = new System.Drawing.Point(48, 190);
            this.chkIsBackground.Name = "chkIsBackground";
            this.chkIsBackground.Size = new System.Drawing.Size(115, 17);
            this.chkIsBackground.TabIndex = 13;
            this.chkIsBackground.Text = "BackGround Index";
            this.chkIsBackground.UseVisualStyleBackColor = true;
            // 
            // ctlIndexCreate5
            // 
            this.ctlIndexCreate5.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate5.Location = new System.Drawing.Point(25, 150);
            this.ctlIndexCreate5.Name = "ctlIndexCreate5";
            this.ctlIndexCreate5.Size = new System.Drawing.Size(492, 32);
            this.ctlIndexCreate5.TabIndex = 13;
            // 
            // ctlIndexCreate4
            // 
            this.ctlIndexCreate4.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate4.Location = new System.Drawing.Point(25, 118);
            this.ctlIndexCreate4.Name = "ctlIndexCreate4";
            this.ctlIndexCreate4.Size = new System.Drawing.Size(492, 32);
            this.ctlIndexCreate4.TabIndex = 13;
            // 
            // ctlIndexCreate3
            // 
            this.ctlIndexCreate3.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate3.Location = new System.Drawing.Point(25, 86);
            this.ctlIndexCreate3.Name = "ctlIndexCreate3";
            this.ctlIndexCreate3.Size = new System.Drawing.Size(492, 32);
            this.ctlIndexCreate3.TabIndex = 13;
            // 
            // ctlIndexCreate2
            // 
            this.ctlIndexCreate2.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate2.Location = new System.Drawing.Point(25, 54);
            this.ctlIndexCreate2.Name = "ctlIndexCreate2";
            this.ctlIndexCreate2.Size = new System.Drawing.Size(492, 32);
            this.ctlIndexCreate2.TabIndex = 13;
            // 
            // ctlIndexCreate1
            // 
            this.ctlIndexCreate1.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate1.Location = new System.Drawing.Point(25, 22);
            this.ctlIndexCreate1.Name = "ctlIndexCreate1";
            this.ctlIndexCreate1.Size = new System.Drawing.Size(492, 32);
            this.ctlIndexCreate1.TabIndex = 13;
            // 
            // frmCollectionIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 283);
            this.Controls.Add(this.tabIndexMgr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCollectionIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Index Management";
            this.Load += new System.EventHandler(this.frmCollectionIndex_Load);
            this.tabIndexMgr.ResumeLayout(false);
            this.tabCurrentIndex.ResumeLayout(false);
            this.tabIndexManager.ResumeLayout(false);
            this.tabIndexManager.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddIndex;
        private System.Windows.Forms.Button cmdDelIndex;
        private System.Windows.Forms.ListView lstIndex;
        private System.Windows.Forms.TabControl tabIndexMgr;
        private System.Windows.Forms.TabPage tabCurrentIndex;
        private System.Windows.Forms.TabPage tabIndexManager;
        private System.Windows.Forms.CheckBox chkIsDroppedDups;
        private System.Windows.Forms.CheckBox chkIsBackground;
        private System.Windows.Forms.CheckBox chkIsSparse;
        private System.Windows.Forms.CheckBox chkIsUnique;
        private ctlIndexCreate ctlIndexCreate1;
        private ctlIndexCreate ctlIndexCreate5;
        private ctlIndexCreate ctlIndexCreate4;
        private ctlIndexCreate ctlIndexCreate3;
        private ctlIndexCreate ctlIndexCreate2;
        private TextBox txtIndexName;
        private System.Windows.Forms.Label lblIndexName;
    }
}