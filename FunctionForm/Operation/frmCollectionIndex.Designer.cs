using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Operation
{
    partial class FrmCollectionIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.chkPartialIndexes = new System.Windows.Forms.CheckBox();
            this.numTTL = new System.Windows.Forms.NumericUpDown();
            this.chkExpireData = new System.Windows.Forms.CheckBox();
            this.txtIndexName = new System.Windows.Forms.TextBox();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.chkIsUnique = new System.Windows.Forms.CheckBox();
            this.chkIsSparse = new System.Windows.Forms.CheckBox();
            this.chkIsDroppedDups = new System.Windows.Forms.CheckBox();
            this.chkIsBackground = new System.Windows.Forms.CheckBox();
            this.ctlIndexCreate5 = new MongoGUICtl.CtlIndexCreate();
            this.ctlIndexCreate4 = new MongoGUICtl.CtlIndexCreate();
            this.ctlIndexCreate3 = new MongoGUICtl.CtlIndexCreate();
            this.ctlIndexCreate2 = new MongoGUICtl.CtlIndexCreate();
            this.ctlIndexCreate1 = new MongoGUICtl.CtlIndexCreate();
            this.txtPartialIndexes = new System.Windows.Forms.TextBox();
            this.tabIndexMgr.SuspendLayout();
            this.tabCurrentIndex.SuspendLayout();
            this.tabIndexManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTTL)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAddIndex
            // 
            this.cmdAddIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddIndex.Location = new System.Drawing.Point(514, 411);
            this.cmdAddIndex.Name = "cmdAddIndex";
            this.cmdAddIndex.Size = new System.Drawing.Size(126, 23);
            this.cmdAddIndex.TabIndex = 8;
            this.cmdAddIndex.Tag = "Common_Add";
            this.cmdAddIndex.Text = "Create Index";
            this.cmdAddIndex.UseVisualStyleBackColor = false;
            this.cmdAddIndex.Click += new System.EventHandler(this.cmdAddIndex_Click);
            // 
            // cmdDelIndex
            // 
            this.cmdDelIndex.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelIndex.Location = new System.Drawing.Point(503, 394);
            this.cmdDelIndex.Name = "cmdDelIndex";
            this.cmdDelIndex.Size = new System.Drawing.Size(132, 40);
            this.cmdDelIndex.TabIndex = 7;
            this.cmdDelIndex.Tag = "DelIndex";
            this.cmdDelIndex.Text = "Delect Index";
            this.cmdDelIndex.UseVisualStyleBackColor = false;
            this.cmdDelIndex.Click += new System.EventHandler(this.cmdDelIndex_Click);
            // 
            // lstIndex
            // 
            this.lstIndex.CheckBoxes = true;
            this.lstIndex.Location = new System.Drawing.Point(7, 7);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(628, 381);
            this.lstIndex.TabIndex = 6;
            this.lstIndex.UseCompatibleStateImageBehavior = false;
            this.lstIndex.View = System.Windows.Forms.View.Details;
            // 
            // tabIndexMgr
            // 
            this.tabIndexMgr.Controls.Add(this.tabCurrentIndex);
            this.tabIndexMgr.Controls.Add(this.tabIndexManager);
            this.tabIndexMgr.Location = new System.Drawing.Point(15, 6);
            this.tabIndexMgr.Name = "tabIndexMgr";
            this.tabIndexMgr.SelectedIndex = 0;
            this.tabIndexMgr.Size = new System.Drawing.Size(654, 468);
            this.tabIndexMgr.TabIndex = 12;
            // 
            // tabCurrentIndex
            // 
            this.tabCurrentIndex.Controls.Add(this.cmdDelIndex);
            this.tabCurrentIndex.Controls.Add(this.lstIndex);
            this.tabCurrentIndex.Location = new System.Drawing.Point(4, 24);
            this.tabCurrentIndex.Name = "tabCurrentIndex";
            this.tabCurrentIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentIndex.Size = new System.Drawing.Size(646, 440);
            this.tabCurrentIndex.TabIndex = 0;
            this.tabCurrentIndex.Tag = "CollectionIndexTabCurrent";
            this.tabCurrentIndex.Text = "Current Index";
            this.tabCurrentIndex.UseVisualStyleBackColor = true;
            // 
            // tabIndexManager
            // 
            this.tabIndexManager.BackColor = System.Drawing.Color.White;
            this.tabIndexManager.Controls.Add(this.txtPartialIndexes);
            this.tabIndexManager.Controls.Add(this.chkPartialIndexes);
            this.tabIndexManager.Controls.Add(this.numTTL);
            this.tabIndexManager.Controls.Add(this.chkExpireData);
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
            this.tabIndexManager.Location = new System.Drawing.Point(4, 24);
            this.tabIndexManager.Name = "tabIndexManager";
            this.tabIndexManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndexManager.Size = new System.Drawing.Size(646, 440);
            this.tabIndexManager.TabIndex = 1;
            this.tabIndexManager.Tag = "CollectionIndexTabManager";
            this.tabIndexManager.Text = "Create Index";
            // 
            // chkPartialIndexes
            // 
            this.chkPartialIndexes.AutoSize = true;
            this.chkPartialIndexes.Location = new System.Drawing.Point(23, 255);
            this.chkPartialIndexes.Name = "chkPartialIndexes";
            this.chkPartialIndexes.Size = new System.Drawing.Size(107, 19);
            this.chkPartialIndexes.TabIndex = 22;
            this.chkPartialIndexes.Text = "Partial Indexes";
            this.chkPartialIndexes.UseVisualStyleBackColor = true;
            // 
            // numTTL
            // 
            this.numTTL.Enabled = false;
            this.numTTL.Location = new System.Drawing.Point(167, 230);
            this.numTTL.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numTTL.Name = "numTTL";
            this.numTTL.Size = new System.Drawing.Size(110, 21);
            this.numTTL.TabIndex = 21;
            this.numTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkExpireData
            // 
            this.chkExpireData.AutoSize = true;
            this.chkExpireData.Location = new System.Drawing.Point(23, 230);
            this.chkExpireData.Name = "chkExpireData";
            this.chkExpireData.Size = new System.Drawing.Size(117, 19);
            this.chkExpireData.TabIndex = 20;
            this.chkExpireData.Tag = "IndexExpireData";
            this.chkExpireData.Text = "Expire Data(sec)";
            this.chkExpireData.UseVisualStyleBackColor = true;
            this.chkExpireData.CheckedChanged += new System.EventHandler(this.chkTTL_CheckedChanged);
            // 
            // txtIndexName
            // 
            this.txtIndexName.Location = new System.Drawing.Point(167, 413);
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Size = new System.Drawing.Size(335, 21);
            this.txtIndexName.TabIndex = 19;
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.Location = new System.Drawing.Point(23, 417);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(71, 15);
            this.lblIndexName.TabIndex = 18;
            this.lblIndexName.Tag = "IndexName";
            this.lblIndexName.Text = "IndexName";
            // 
            // chkIsUnique
            // 
            this.chkIsUnique.AutoSize = true;
            this.chkIsUnique.Location = new System.Drawing.Point(439, 205);
            this.chkIsUnique.Name = "chkIsUnique";
            this.chkIsUnique.Size = new System.Drawing.Size(99, 19);
            this.chkIsUnique.TabIndex = 16;
            this.chkIsUnique.Tag = "IndexUnify";
            this.chkIsUnique.Text = "Unique Index";
            this.chkIsUnique.UseVisualStyleBackColor = true;
            // 
            // chkIsSparse
            // 
            this.chkIsSparse.AutoSize = true;
            this.chkIsSparse.Location = new System.Drawing.Point(315, 205);
            this.chkIsSparse.Name = "chkIsSparse";
            this.chkIsSparse.Size = new System.Drawing.Size(98, 19);
            this.chkIsSparse.TabIndex = 15;
            this.chkIsSparse.Tag = "IndexSparse";
            this.chkIsSparse.Text = "Sparse Index";
            this.chkIsSparse.UseVisualStyleBackColor = true;
            // 
            // chkIsDroppedDups
            // 
            this.chkIsDroppedDups.AutoSize = true;
            this.chkIsDroppedDups.Location = new System.Drawing.Point(167, 206);
            this.chkIsDroppedDups.Name = "chkIsDroppedDups";
            this.chkIsDroppedDups.Size = new System.Drawing.Size(136, 19);
            this.chkIsDroppedDups.TabIndex = 14;
            this.chkIsDroppedDups.Tag = "IndexRepeatDel";
            this.chkIsDroppedDups.Text = "DroppedDups Index";
            this.chkIsDroppedDups.UseVisualStyleBackColor = true;
            // 
            // chkIsBackground
            // 
            this.chkIsBackground.AutoSize = true;
            this.chkIsBackground.Location = new System.Drawing.Point(23, 205);
            this.chkIsBackground.Name = "chkIsBackground";
            this.chkIsBackground.Size = new System.Drawing.Size(127, 19);
            this.chkIsBackground.TabIndex = 13;
            this.chkIsBackground.Tag = "IndexBackground";
            this.chkIsBackground.Text = "BackGround Index";
            this.chkIsBackground.UseVisualStyleBackColor = true;
            // 
            // ctlIndexCreate5
            // 
            this.ctlIndexCreate5.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate5.Location = new System.Drawing.Point(23, 157);
            this.ctlIndexCreate5.Name = "ctlIndexCreate5";
            this.ctlIndexCreate5.Size = new System.Drawing.Size(592, 37);
            this.ctlIndexCreate5.TabIndex = 13;
            // 
            // ctlIndexCreate4
            // 
            this.ctlIndexCreate4.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate4.Location = new System.Drawing.Point(23, 120);
            this.ctlIndexCreate4.Name = "ctlIndexCreate4";
            this.ctlIndexCreate4.Size = new System.Drawing.Size(592, 37);
            this.ctlIndexCreate4.TabIndex = 13;
            // 
            // ctlIndexCreate3
            // 
            this.ctlIndexCreate3.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate3.Location = new System.Drawing.Point(23, 83);
            this.ctlIndexCreate3.Name = "ctlIndexCreate3";
            this.ctlIndexCreate3.Size = new System.Drawing.Size(592, 37);
            this.ctlIndexCreate3.TabIndex = 13;
            // 
            // ctlIndexCreate2
            // 
            this.ctlIndexCreate2.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate2.Location = new System.Drawing.Point(23, 46);
            this.ctlIndexCreate2.Name = "ctlIndexCreate2";
            this.ctlIndexCreate2.Size = new System.Drawing.Size(592, 37);
            this.ctlIndexCreate2.TabIndex = 13;
            // 
            // ctlIndexCreate1
            // 
            this.ctlIndexCreate1.BackColor = System.Drawing.Color.Transparent;
            this.ctlIndexCreate1.Location = new System.Drawing.Point(23, 9);
            this.ctlIndexCreate1.Name = "ctlIndexCreate1";
            this.ctlIndexCreate1.Size = new System.Drawing.Size(592, 37);
            this.ctlIndexCreate1.TabIndex = 13;
            // 
            // txtPartialIndexes
            // 
            this.txtPartialIndexes.Location = new System.Drawing.Point(167, 257);
            this.txtPartialIndexes.Multiline = true;
            this.txtPartialIndexes.Name = "txtPartialIndexes";
            this.txtPartialIndexes.Size = new System.Drawing.Size(473, 148);
            this.txtPartialIndexes.TabIndex = 23;
            this.txtPartialIndexes.Text = "Partial Filter Expression";
            // 
            // FrmCollectionIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 486);
            this.Controls.Add(this.tabIndexMgr);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCollectionIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "CollectionIndexTitle";
            this.Text = "Index Management";
            this.Load += new System.EventHandler(this.frmCollectionIndex_Load);
            this.tabIndexMgr.ResumeLayout(false);
            this.tabCurrentIndex.ResumeLayout(false);
            this.tabIndexManager.ResumeLayout(false);
            this.tabIndexManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTTL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdAddIndex;
        private Button cmdDelIndex;
        private ListView lstIndex;
        private TabControl tabIndexMgr;
        private TabPage tabCurrentIndex;
        private TabPage tabIndexManager;
        private CheckBox chkIsDroppedDups;
        private CheckBox chkIsBackground;
        private CheckBox chkIsSparse;
        private CheckBox chkIsUnique;
        private CtlIndexCreate ctlIndexCreate1;
        private CtlIndexCreate ctlIndexCreate5;
        private CtlIndexCreate ctlIndexCreate4;
        private CtlIndexCreate ctlIndexCreate3;
        private CtlIndexCreate ctlIndexCreate2;
        private TextBox txtIndexName;
        private Label lblIndexName;
        private CheckBox chkExpireData;
        private NumericUpDown numTTL;
        private CheckBox chkPartialIndexes;
        private TextBox txtPartialIndexes;
    }
}