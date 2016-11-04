using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    partial class frmCreateCollection
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.chkIsCapped = new System.Windows.Forms.CheckBox();
            this.chkIsAutoIndexId = new System.Windows.Forms.CheckBox();
            this.numMaxSize = new System.Windows.Forms.NumericUpDown();
            this.numMaxDocument = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.lblMaxDocument = new System.Windows.Forms.Label();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAction_error = new System.Windows.Forms.RadioButton();
            this.radAction_warn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLevel_moderate = new System.Windows.Forms.RadioButton();
            this.radLevel_off = new System.Windows.Forms.RadioButton();
            this.radLevel_strict = new System.Windows.Forms.RadioButton();
            this.txtValidation = new System.Windows.Forms.TextBox();
            this.chkValidation = new System.Windows.Forms.CheckBox();
            this.lnkCappedCollections = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.trvNewDocument = new MongoGUICtl.CtlTreeViewColumns();
            this.trvCollation = new MongoGUICtl.CtlTreeViewColumns();
            this.btnCollation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(294, 625);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(406, 625);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 27);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(145, 12);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(139, 21);
            this.txtCollectionName.TabIndex = 1;
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(30, 18);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(95, 15);
            this.lblCollectionName.TabIndex = 0;
            this.lblCollectionName.Text = "CollectionName";
            // 
            // chkIsCapped
            // 
            this.chkIsCapped.AutoSize = true;
            this.chkIsCapped.Location = new System.Drawing.Point(33, 74);
            this.chkIsCapped.Name = "chkIsCapped";
            this.chkIsCapped.Size = new System.Drawing.Size(78, 19);
            this.chkIsCapped.TabIndex = 0;
            this.chkIsCapped.Text = "IsCapped";
            this.chkIsCapped.UseVisualStyleBackColor = true;
            // 
            // chkIsAutoIndexId
            // 
            this.chkIsAutoIndexId.AutoSize = true;
            this.chkIsAutoIndexId.Location = new System.Drawing.Point(33, 46);
            this.chkIsAutoIndexId.Name = "chkIsAutoIndexId";
            this.chkIsAutoIndexId.Size = new System.Drawing.Size(99, 19);
            this.chkIsAutoIndexId.TabIndex = 1;
            this.chkIsAutoIndexId.Text = "IsAutoIndexId";
            this.chkIsAutoIndexId.UseVisualStyleBackColor = true;
            // 
            // numMaxSize
            // 
            this.numMaxSize.Location = new System.Drawing.Point(203, 73);
            this.numMaxSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxSize.Name = "numMaxSize";
            this.numMaxSize.Size = new System.Drawing.Size(140, 21);
            this.numMaxSize.TabIndex = 3;
            this.numMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numMaxDocument
            // 
            this.numMaxDocument.Location = new System.Drawing.Point(469, 74);
            this.numMaxDocument.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxDocument.Name = "numMaxDocument";
            this.numMaxDocument.Size = new System.Drawing.Size(140, 21);
            this.numMaxDocument.TabIndex = 5;
            this.numMaxDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(142, 74);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(55, 15);
            this.lblMaxSize.TabIndex = 2;
            this.lblMaxSize.Text = "MaxSize";
            // 
            // lblMaxDocument
            // 
            this.lblMaxDocument.AutoSize = true;
            this.lblMaxDocument.Location = new System.Drawing.Point(361, 76);
            this.lblMaxDocument.Name = "lblMaxDocument";
            this.lblMaxDocument.Size = new System.Drawing.Size(88, 15);
            this.lblMaxDocument.TabIndex = 4;
            this.lblMaxDocument.Text = "MaxDocument";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(457, 380);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(177, 34);
            this.cmdPreview.TabIndex = 31;
            this.cmdPreview.Tag = "Common_Preview";
            this.cmdPreview.Text = "Preview Validation Express";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAction_error);
            this.groupBox2.Controls.Add(this.radAction_warn);
            this.groupBox2.Location = new System.Drawing.Point(386, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 45);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // radAction_error
            // 
            this.radAction_error.AutoSize = true;
            this.radAction_error.Checked = true;
            this.radAction_error.Location = new System.Drawing.Point(34, 18);
            this.radAction_error.Name = "radAction_error";
            this.radAction_error.Size = new System.Drawing.Size(51, 19);
            this.radAction_error.TabIndex = 27;
            this.radAction_error.TabStop = true;
            this.radAction_error.Text = "error";
            this.radAction_error.UseVisualStyleBackColor = true;
            // 
            // radAction_warn
            // 
            this.radAction_warn.AutoSize = true;
            this.radAction_warn.Location = new System.Drawing.Point(102, 18);
            this.radAction_warn.Name = "radAction_warn";
            this.radAction_warn.Size = new System.Drawing.Size(52, 19);
            this.radAction_warn.TabIndex = 28;
            this.radAction_warn.TabStop = true;
            this.radAction_warn.Text = "warn";
            this.radAction_warn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLevel_moderate);
            this.groupBox1.Controls.Add(this.radLevel_off);
            this.groupBox1.Controls.Add(this.radLevel_strict);
            this.groupBox1.Location = new System.Drawing.Point(145, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 45);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // radLevel_moderate
            // 
            this.radLevel_moderate.AutoSize = true;
            this.radLevel_moderate.Location = new System.Drawing.Point(143, 20);
            this.radLevel_moderate.Name = "radLevel_moderate";
            this.radLevel_moderate.Size = new System.Drawing.Size(78, 19);
            this.radLevel_moderate.TabIndex = 27;
            this.radLevel_moderate.TabStop = true;
            this.radLevel_moderate.Text = "moderate";
            this.radLevel_moderate.UseVisualStyleBackColor = true;
            // 
            // radLevel_off
            // 
            this.radLevel_off.AutoSize = true;
            this.radLevel_off.Checked = true;
            this.radLevel_off.Location = new System.Drawing.Point(27, 20);
            this.radLevel_off.Name = "radLevel_off";
            this.radLevel_off.Size = new System.Drawing.Size(38, 19);
            this.radLevel_off.TabIndex = 25;
            this.radLevel_off.TabStop = true;
            this.radLevel_off.Text = "off";
            this.radLevel_off.UseVisualStyleBackColor = true;
            // 
            // radLevel_strict
            // 
            this.radLevel_strict.AutoSize = true;
            this.radLevel_strict.Location = new System.Drawing.Point(79, 20);
            this.radLevel_strict.Name = "radLevel_strict";
            this.radLevel_strict.Size = new System.Drawing.Size(50, 19);
            this.radLevel_strict.TabIndex = 26;
            this.radLevel_strict.TabStop = true;
            this.radLevel_strict.Text = "strict";
            this.radLevel_strict.UseVisualStyleBackColor = true;
            // 
            // txtValidation
            // 
            this.txtValidation.Location = new System.Drawing.Point(54, 159);
            this.txtValidation.Multiline = true;
            this.txtValidation.Name = "txtValidation";
            this.txtValidation.Size = new System.Drawing.Size(310, 213);
            this.txtValidation.TabIndex = 24;
            this.txtValidation.Text = "Validation Express";
            // 
            // chkValidation
            // 
            this.chkValidation.AutoSize = true;
            this.chkValidation.Location = new System.Drawing.Point(33, 108);
            this.chkValidation.Name = "chkValidation";
            this.chkValidation.Size = new System.Drawing.Size(80, 19);
            this.chkValidation.TabIndex = 6;
            this.chkValidation.Text = "Validation";
            this.chkValidation.UseVisualStyleBackColor = true;
            // 
            // lnkCappedCollections
            // 
            this.lnkCappedCollections.AutoSize = true;
            this.lnkCappedCollections.Location = new System.Drawing.Point(634, 73);
            this.lnkCappedCollections.Name = "lnkCappedCollections";
            this.lnkCappedCollections.Size = new System.Drawing.Size(141, 15);
            this.lnkCappedCollections.TabIndex = 6;
            this.lnkCappedCollections.TabStop = true;
            this.lnkCappedCollections.Text = "About Capped Collection";
            this.lnkCappedCollections.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCappedCollections_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "WhiteSpace at start or end of collectionname will be trimed!";
            // 
            // trvNewDocument
            // 
            this.trvNewDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvNewDocument.Location = new System.Drawing.Point(372, 161);
            this.trvNewDocument.Margin = new System.Windows.Forms.Padding(5);
            this.trvNewDocument.Name = "trvNewDocument";
            this.trvNewDocument.Padding = new System.Windows.Forms.Padding(1);
            this.trvNewDocument.Size = new System.Drawing.Size(345, 211);
            this.trvNewDocument.TabIndex = 30;
            // 
            // trvCollation
            // 
            this.trvCollation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCollation.Location = new System.Drawing.Point(224, 424);
            this.trvCollation.Margin = new System.Windows.Forms.Padding(5);
            this.trvCollation.Name = "trvCollation";
            this.trvCollation.Padding = new System.Windows.Forms.Padding(1);
            this.trvCollation.Size = new System.Drawing.Size(353, 178);
            this.trvCollation.TabIndex = 37;
            // 
            // btnCollation
            // 
            this.btnCollation.Location = new System.Drawing.Point(54, 424);
            this.btnCollation.Name = "btnCollation";
            this.btnCollation.Size = new System.Drawing.Size(156, 31);
            this.btnCollation.TabIndex = 36;
            this.btnCollation.Text = "Create Collation";
            this.btnCollation.UseVisualStyleBackColor = true;
            this.btnCollation.Click += new System.EventHandler(this.btnCollation_Click);
            // 
            // frmCreateCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 661);
            this.Controls.Add(this.trvCollation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCollation);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.trvNewDocument);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtValidation);
            this.Controls.Add(this.chkIsAutoIndexId);
            this.Controls.Add(this.chkValidation);
            this.Controls.Add(this.numMaxDocument);
            this.Controls.Add(this.lnkCappedCollections);
            this.Controls.Add(this.numMaxSize);
            this.Controls.Add(this.lblMaxSize);
            this.Controls.Add(this.lblMaxDocument);
            this.Controls.Add(this.chkIsCapped);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCreateCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Collection";
            this.Load += new System.EventHandler(this.frmCreateCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdOK;
        private Button cmdCancel;
        private TextBox txtCollectionName;
        private Label lblCollectionName;
        private CheckBox chkIsCapped;
        private CheckBox chkIsAutoIndexId;
        private NumericUpDown numMaxSize;
        private NumericUpDown numMaxDocument;
        private Label lblMaxSize;
        private Label lblMaxDocument;
        private LinkLabel lnkCappedCollections;
        private CheckBox chkValidation;
        private TextBox txtValidation;
        private GroupBox groupBox1;
        private RadioButton radLevel_moderate;
        private RadioButton radLevel_off;
        private RadioButton radLevel_strict;
        private GroupBox groupBox2;
        private RadioButton radAction_error;
        private RadioButton radAction_warn;
        private MongoGUICtl.CtlTreeViewColumns trvNewDocument;
        private Button cmdPreview;
        private Label label1;
        private MongoGUICtl.CtlTreeViewColumns trvCollation;
        private Button btnCollation;
    }
}