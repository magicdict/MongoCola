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
            this.cmdAddIndex = new System.Windows.Forms.VistaButton();
            this.cmdDelIndex = new System.Windows.Forms.VistaButton();
            this.lstIndex = new System.Windows.Forms.ListView();
            this.tabIndexMgr = new System.Windows.Forms.TabControl();
            this.tabCurrentIndex = new System.Windows.Forms.TabPage();
            this.tabIndexManager = new System.Windows.Forms.TabPage();
            this.txtIndexName = new QLFUI.TextBoxEx();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.ctlIndexCreate5 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate4 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate3 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate2 = new MagicMongoDBTool.ctlIndexCreate();
            this.ctlIndexCreate1 = new MagicMongoDBTool.ctlIndexCreate();
            this.chkIsUnique = new System.Windows.Forms.CheckBox();
            this.chkIsSparse = new System.Windows.Forms.CheckBox();
            this.chkDroppedDups = new System.Windows.Forms.CheckBox();
            this.chkIsBackground = new System.Windows.Forms.CheckBox();
            this.contentPanel.SuspendLayout();
            this.tabIndexMgr.SuspendLayout();
            this.tabCurrentIndex.SuspendLayout();
            this.tabIndexManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.tabIndexMgr);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(559, 280);
            // 
            // cmdAddIndex
            // 
            this.cmdAddIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddIndex.Location = new System.Drawing.Point(407, 192);
            this.cmdAddIndex.Name = "cmdAddIndex";
            this.cmdAddIndex.Size = new System.Drawing.Size(108, 35);
            this.cmdAddIndex.TabIndex = 8;
            this.cmdAddIndex.Text = "添加索引";
            this.cmdAddIndex.Click += new System.EventHandler(this.cmdAddIndex_Click);
            // 
            // cmdDelIndex
            // 
            this.cmdDelIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelIndex.Location = new System.Drawing.Point(413, 185);
            this.cmdDelIndex.Name = "cmdDelIndex";
            this.cmdDelIndex.Size = new System.Drawing.Size(113, 35);
            this.cmdDelIndex.TabIndex = 7;
            this.cmdDelIndex.Text = "删除选中索引";
            this.cmdDelIndex.Click += new System.EventHandler(this.cmdDelIndex_Click);
            // 
            // lstIndex
            // 
            this.lstIndex.CheckBoxes = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 6);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(520, 173);
            this.lstIndex.TabIndex = 6;
            this.lstIndex.UseCompatibleStateImageBehavior = false;
            this.lstIndex.View = System.Windows.Forms.View.Details;
            // 
            // tabIndexMgr
            // 
            this.tabIndexMgr.Controls.Add(this.tabCurrentIndex);
            this.tabIndexMgr.Controls.Add(this.tabIndexManager);
            this.tabIndexMgr.Location = new System.Drawing.Point(11, 13);
            this.tabIndexMgr.Name = "tabIndexMgr";
            this.tabIndexMgr.SelectedIndex = 0;
            this.tabIndexMgr.Size = new System.Drawing.Size(540, 259);
            this.tabIndexMgr.TabIndex = 12;
            // 
            // tabCurrentIndex
            // 
            this.tabCurrentIndex.Controls.Add(this.cmdDelIndex);
            this.tabCurrentIndex.Controls.Add(this.lstIndex);
            this.tabCurrentIndex.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentIndex.Name = "tabCurrentIndex";
            this.tabCurrentIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentIndex.Size = new System.Drawing.Size(532, 233);
            this.tabCurrentIndex.TabIndex = 0;
            this.tabCurrentIndex.Text = "现有索引";
            this.tabCurrentIndex.UseVisualStyleBackColor = true;
            // 
            // tabIndexManager
            // 
            this.tabIndexManager.BackColor = System.Drawing.Color.White;
            this.tabIndexManager.Controls.Add(this.txtIndexName);
            this.tabIndexManager.Controls.Add(this.lblIndexName);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate5);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate4);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate3);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate2);
            this.tabIndexManager.Controls.Add(this.ctlIndexCreate1);
            this.tabIndexManager.Controls.Add(this.chkIsUnique);
            this.tabIndexManager.Controls.Add(this.chkIsSparse);
            this.tabIndexManager.Controls.Add(this.chkDroppedDups);
            this.tabIndexManager.Controls.Add(this.chkIsBackground);
            this.tabIndexManager.Controls.Add(this.cmdAddIndex);
            this.tabIndexManager.Location = new System.Drawing.Point(4, 22);
            this.tabIndexManager.Name = "tabIndexManager";
            this.tabIndexManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndexManager.Size = new System.Drawing.Size(532, 233);
            this.tabIndexManager.TabIndex = 1;
            this.tabIndexManager.Text = "管理索引";
            // 
            // txtIndexName
            // 
            this.txtIndexName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIndexName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIndexName.BackColor = System.Drawing.Color.Transparent;
            this.txtIndexName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtIndexName.ForeImage = null;
            this.txtIndexName.Location = new System.Drawing.Point(81, 195);
            this.txtIndexName.Multiline = false;
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Radius = 3;
            this.txtIndexName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtIndexName.Size = new System.Drawing.Size(197, 29);
            this.txtIndexName.TabIndex = 19;
            this.txtIndexName.UseSystemPasswordChar = false;
            this.txtIndexName.WaterMark = "索引名称(可选参数)";
            this.txtIndexName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.Location = new System.Drawing.Point(20, 204);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(55, 13);
            this.lblIndexName.TabIndex = 18;
            this.lblIndexName.Text = "索引名称";
            // 
            // ctlIndexCreate5
            // 
            this.ctlIndexCreate5.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate5.Location = new System.Drawing.Point(23, 135);
            this.ctlIndexCreate5.Name = "ctlIndexCreate5";
            this.ctlIndexCreate5.Size = new System.Drawing.Size(405, 32);
            this.ctlIndexCreate5.TabIndex = 13;
            // 
            // ctlIndexCreate4
            // 
            this.ctlIndexCreate4.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate4.Location = new System.Drawing.Point(23, 103);
            this.ctlIndexCreate4.Name = "ctlIndexCreate4";
            this.ctlIndexCreate4.Size = new System.Drawing.Size(405, 32);
            this.ctlIndexCreate4.TabIndex = 13;
            // 
            // ctlIndexCreate3
            // 
            this.ctlIndexCreate3.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate3.Location = new System.Drawing.Point(23, 71);
            this.ctlIndexCreate3.Name = "ctlIndexCreate3";
            this.ctlIndexCreate3.Size = new System.Drawing.Size(405, 32);
            this.ctlIndexCreate3.TabIndex = 13;
            // 
            // ctlIndexCreate2
            // 
            this.ctlIndexCreate2.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate2.Location = new System.Drawing.Point(23, 39);
            this.ctlIndexCreate2.Name = "ctlIndexCreate2";
            this.ctlIndexCreate2.Size = new System.Drawing.Size(405, 32);
            this.ctlIndexCreate2.TabIndex = 13;
            // 
            // ctlIndexCreate1
            // 
            this.ctlIndexCreate1.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate1.Location = new System.Drawing.Point(23, 7);
            this.ctlIndexCreate1.Name = "ctlIndexCreate1";
            this.ctlIndexCreate1.Size = new System.Drawing.Size(405, 32);
            this.ctlIndexCreate1.TabIndex = 13;
            // 
            // chkIsUnique
            // 
            this.chkIsUnique.AutoSize = true;
            this.chkIsUnique.Location = new System.Drawing.Point(284, 172);
            this.chkIsUnique.Name = "chkIsUnique";
            this.chkIsUnique.Size = new System.Drawing.Size(74, 17);
            this.chkIsUnique.TabIndex = 16;
            this.chkIsUnique.Text = "统一索引";
            this.chkIsUnique.UseVisualStyleBackColor = true;
            // 
            // chkIsSparse
            // 
            this.chkIsSparse.AutoSize = true;
            this.chkIsSparse.Location = new System.Drawing.Point(204, 172);
            this.chkIsSparse.Name = "chkIsSparse";
            this.chkIsSparse.Size = new System.Drawing.Size(74, 17);
            this.chkIsSparse.TabIndex = 15;
            this.chkIsSparse.Text = "稀疏索引";
            this.chkIsSparse.UseVisualStyleBackColor = true;
            // 
            // chkDroppedDups
            // 
            this.chkDroppedDups.AutoSize = true;
            this.chkDroppedDups.Location = new System.Drawing.Point(100, 172);
            this.chkDroppedDups.Name = "chkDroppedDups";
            this.chkDroppedDups.Size = new System.Drawing.Size(98, 17);
            this.chkDroppedDups.TabIndex = 14;
            this.chkDroppedDups.Text = "重复删除索引";
            this.chkDroppedDups.UseVisualStyleBackColor = true;
            // 
            // chkIsBackground
            // 
            this.chkIsBackground.AutoSize = true;
            this.chkIsBackground.Location = new System.Drawing.Point(20, 172);
            this.chkIsBackground.Name = "chkIsBackground";
            this.chkIsBackground.Size = new System.Drawing.Size(74, 17);
            this.chkIsBackground.TabIndex = 13;
            this.chkIsBackground.Text = "背景索引";
            this.chkIsBackground.UseVisualStyleBackColor = true;
            // 
            // frmCollectionIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 343);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCollectionIndex";
            this.Text = "数据集索引";
            this.Load += new System.EventHandler(this.frmCollectionIndex_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabIndexMgr.ResumeLayout(false);
            this.tabCurrentIndex.ResumeLayout(false);
            this.tabIndexManager.ResumeLayout(false);
            this.tabIndexManager.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdAddIndex;
        private System.Windows.Forms.VistaButton cmdDelIndex;
        private System.Windows.Forms.ListView lstIndex;
        private System.Windows.Forms.TabControl tabIndexMgr;
        private System.Windows.Forms.TabPage tabCurrentIndex;
        private System.Windows.Forms.TabPage tabIndexManager;
        private System.Windows.Forms.CheckBox chkDroppedDups;
        private System.Windows.Forms.CheckBox chkIsBackground;
        private System.Windows.Forms.CheckBox chkIsSparse;
        private System.Windows.Forms.CheckBox chkIsUnique;
        private ctlIndexCreate ctlIndexCreate1;
        private ctlIndexCreate ctlIndexCreate5;
        private ctlIndexCreate ctlIndexCreate4;
        private ctlIndexCreate ctlIndexCreate3;
        private ctlIndexCreate ctlIndexCreate2;
        private QLFUI.TextBoxEx txtIndexName;
        private System.Windows.Forms.Label lblIndexName;
    }
}