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
            this.numMaxSize = new System.Windows.Forms.NumericUpDown();
            this.numMaxDocument = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.lblMaxDocument = new System.Windows.Forms.Label();
            this.cmdCreateValidation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAction_error = new System.Windows.Forms.RadioButton();
            this.radAction_warn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLevel_moderate = new System.Windows.Forms.RadioButton();
            this.radLevel_off = new System.Windows.Forms.RadioButton();
            this.radLevel_strict = new System.Windows.Forms.RadioButton();
            this.chkValidation = new System.Windows.Forms.CheckBox();
            this.lnkCappedCollections = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCollation = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClearCollation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trvCollation = new MongoGUICtl.CtlTreeViewColumns();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdClearValidation = new System.Windows.Forms.Button();
            this.trvValidationDoc = new MongoGUICtl.CtlTreeViewColumns();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(265, 420);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(377, 420);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 27);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(144, 32);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(139, 23);
            this.txtCollectionName.TabIndex = 1;
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(29, 38);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(99, 15);
            this.lblCollectionName.TabIndex = 0;
            this.lblCollectionName.Tag = "Common.CollectionName";
            this.lblCollectionName.Text = "CollectionName";
            // 
            // chkIsCapped
            // 
            this.chkIsCapped.AutoSize = true;
            this.chkIsCapped.Location = new System.Drawing.Point(29, 75);
            this.chkIsCapped.Name = "chkIsCapped";
            this.chkIsCapped.Size = new System.Drawing.Size(82, 19);
            this.chkIsCapped.TabIndex = 0;
            this.chkIsCapped.Tag = "CollectionStatusIsCapped";
            this.chkIsCapped.Text = "IsCapped";
            this.chkIsCapped.UseVisualStyleBackColor = true;
            // 
            // numMaxSize
            // 
            this.numMaxSize.Location = new System.Drawing.Point(211, 72);
            this.numMaxSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxSize.Name = "numMaxSize";
            this.numMaxSize.Size = new System.Drawing.Size(105, 23);
            this.numMaxSize.TabIndex = 3;
            this.numMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numMaxDocument
            // 
            this.numMaxDocument.Location = new System.Drawing.Point(418, 72);
            this.numMaxDocument.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxDocument.Name = "numMaxDocument";
            this.numMaxDocument.Size = new System.Drawing.Size(140, 23);
            this.numMaxDocument.TabIndex = 5;
            this.numMaxDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(117, 76);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(88, 15);
            this.lblMaxSize.TabIndex = 2;
            this.lblMaxSize.Tag = "MaxSize_Byte";
            this.lblMaxSize.Text = "MaxSize(Byte)";
            // 
            // lblMaxDocument
            // 
            this.lblMaxDocument.AutoSize = true;
            this.lblMaxDocument.Location = new System.Drawing.Point(321, 74);
            this.lblMaxDocument.Name = "lblMaxDocument";
            this.lblMaxDocument.Size = new System.Drawing.Size(91, 15);
            this.lblMaxDocument.TabIndex = 4;
            this.lblMaxDocument.Tag = "CollectionStatusMaxDocuments";
            this.lblMaxDocument.Text = "MaxDocument";
            // 
            // cmdCreateValidation
            // 
            this.cmdCreateValidation.Location = new System.Drawing.Point(150, 86);
            this.cmdCreateValidation.Name = "cmdCreateValidation";
            this.cmdCreateValidation.Size = new System.Drawing.Size(105, 25);
            this.cmdCreateValidation.TabIndex = 31;
            this.cmdCreateValidation.Tag = "Common.Create";
            this.cmdCreateValidation.Text = "Create";
            this.cmdCreateValidation.UseVisualStyleBackColor = true;
            this.cmdCreateValidation.Click += new System.EventHandler(this.cmdCreateValidation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAction_error);
            this.groupBox2.Controls.Add(this.radAction_warn);
            this.groupBox2.Location = new System.Drawing.Point(396, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 55);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "Common.Action";
            this.groupBox2.Text = "Action";
            // 
            // radAction_error
            // 
            this.radAction_error.AutoSize = true;
            this.radAction_error.Checked = true;
            this.radAction_error.Location = new System.Drawing.Point(34, 18);
            this.radAction_error.Name = "radAction_error";
            this.radAction_error.Size = new System.Drawing.Size(55, 19);
            this.radAction_error.TabIndex = 27;
            this.radAction_error.TabStop = true;
            this.radAction_error.Tag = "Common.Error";
            this.radAction_error.Text = "error";
            this.radAction_error.UseVisualStyleBackColor = true;
            // 
            // radAction_warn
            // 
            this.radAction_warn.AutoSize = true;
            this.radAction_warn.Location = new System.Drawing.Point(102, 18);
            this.radAction_warn.Name = "radAction_warn";
            this.radAction_warn.Size = new System.Drawing.Size(53, 19);
            this.radAction_warn.TabIndex = 28;
            this.radAction_warn.TabStop = true;
            this.radAction_warn.Tag = "Common.Warning";
            this.radAction_warn.Text = "warn";
            this.radAction_warn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLevel_moderate);
            this.groupBox1.Controls.Add(this.radLevel_off);
            this.groupBox1.Controls.Add(this.radLevel_strict);
            this.groupBox1.Location = new System.Drawing.Point(123, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 55);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Common.Level";
            this.groupBox1.Text = "Level";
            // 
            // radLevel_moderate
            // 
            this.radLevel_moderate.AutoSize = true;
            this.radLevel_moderate.Location = new System.Drawing.Point(140, 20);
            this.radLevel_moderate.Name = "radLevel_moderate";
            this.radLevel_moderate.Size = new System.Drawing.Size(82, 19);
            this.radLevel_moderate.TabIndex = 27;
            this.radLevel_moderate.Text = "moderate";
            this.radLevel_moderate.UseVisualStyleBackColor = true;
            // 
            // radLevel_off
            // 
            this.radLevel_off.AutoSize = true;
            this.radLevel_off.Location = new System.Drawing.Point(27, 20);
            this.radLevel_off.Name = "radLevel_off";
            this.radLevel_off.Size = new System.Drawing.Size(41, 19);
            this.radLevel_off.TabIndex = 25;
            this.radLevel_off.Text = "off";
            this.radLevel_off.UseVisualStyleBackColor = true;
            // 
            // radLevel_strict
            // 
            this.radLevel_strict.AutoSize = true;
            this.radLevel_strict.Checked = true;
            this.radLevel_strict.Location = new System.Drawing.Point(79, 20);
            this.radLevel_strict.Name = "radLevel_strict";
            this.radLevel_strict.Size = new System.Drawing.Size(53, 19);
            this.radLevel_strict.TabIndex = 26;
            this.radLevel_strict.TabStop = true;
            this.radLevel_strict.Text = "strict";
            this.radLevel_strict.UseVisualStyleBackColor = true;
            // 
            // chkValidation
            // 
            this.chkValidation.AutoSize = true;
            this.chkValidation.Location = new System.Drawing.Point(24, 42);
            this.chkValidation.Name = "chkValidation";
            this.chkValidation.Size = new System.Drawing.Size(84, 19);
            this.chkValidation.TabIndex = 6;
            this.chkValidation.Tag = "Common.Validate";
            this.chkValidation.Text = "Validation";
            this.chkValidation.UseVisualStyleBackColor = true;
            // 
            // lnkCappedCollections
            // 
            this.lnkCappedCollections.AutoSize = true;
            this.lnkCappedCollections.Location = new System.Drawing.Point(493, 115);
            this.lnkCappedCollections.Name = "lnkCappedCollections";
            this.lnkCappedCollections.Size = new System.Drawing.Size(153, 15);
            this.lnkCappedCollections.TabIndex = 6;
            this.lnkCappedCollections.TabStop = true;
            this.lnkCappedCollections.Text = "About Capped Collection";
            this.lnkCappedCollections.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCappedCollections_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "WhiteSpace at start or end of collectionname will be trimed!";
            // 
            // btnCollation
            // 
            this.btnCollation.Location = new System.Drawing.Point(97, 109);
            this.btnCollation.Name = "btnCollation";
            this.btnCollation.Size = new System.Drawing.Size(96, 27);
            this.btnCollation.TabIndex = 36;
            this.btnCollation.Tag = "Common.Create";
            this.btnCollation.Text = "Create";
            this.btnCollation.UseVisualStyleBackColor = true;
            this.btnCollation.Click += new System.EventHandler(this.btnCollation_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 380);
            this.tabControl1.TabIndex = 38;
            this.tabControl1.Tag = "Common.Basic";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnClearCollation);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.trvCollation);
            this.tabPage3.Controls.Add(this.lnkCappedCollections);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.btnCollation);
            this.tabPage3.Controls.Add(this.chkIsCapped);
            this.tabPage3.Controls.Add(this.lblCollectionName);
            this.tabPage3.Controls.Add(this.lblMaxDocument);
            this.tabPage3.Controls.Add(this.txtCollectionName);
            this.tabPage3.Controls.Add(this.lblMaxSize);
            this.tabPage3.Controls.Add(this.numMaxSize);
            this.tabPage3.Controls.Add(this.numMaxDocument);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(710, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "Common.Basic";
            this.tabPage3.Text = "Basic";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnClearCollation
            // 
            this.btnClearCollation.Location = new System.Drawing.Point(210, 111);
            this.btnClearCollation.Name = "btnClearCollation";
            this.btnClearCollation.Size = new System.Drawing.Size(105, 25);
            this.btnClearCollation.TabIndex = 39;
            this.btnClearCollation.Tag = "Common.Clear";
            this.btnClearCollation.Text = "Clear";
            this.btnClearCollation.UseVisualStyleBackColor = true;
            this.btnClearCollation.Click += new System.EventHandler(this.btnClearCollation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 38;
            this.label3.Tag = "Common.Collation";
            this.label3.Text = "Collation";
            // 
            // trvCollation
            // 
            this.trvCollation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCollation.Location = new System.Drawing.Point(29, 146);
            this.trvCollation.Margin = new System.Windows.Forms.Padding(5);
            this.trvCollation.Name = "trvCollation";
            this.trvCollation.Padding = new System.Windows.Forms.Padding(1);
            this.trvCollation.Size = new System.Drawing.Size(664, 178);
            this.trvCollation.TabIndex = 37;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.chkValidation);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cmdClearValidation);
            this.tabPage2.Controls.Add(this.cmdCreateValidation);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.trvValidationDoc);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(710, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Common.Validate";
            this.tabPage2.Text = "Validation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 32;
            this.label2.Tag = "Common.ValidateExpress";
            this.label2.Text = "Validation Express";
            // 
            // cmdClearValidation
            // 
            this.cmdClearValidation.Location = new System.Drawing.Point(264, 86);
            this.cmdClearValidation.Name = "cmdClearValidation";
            this.cmdClearValidation.Size = new System.Drawing.Size(105, 25);
            this.cmdClearValidation.TabIndex = 31;
            this.cmdClearValidation.Tag = "Common.Clear";
            this.cmdClearValidation.Text = "Clear";
            this.cmdClearValidation.UseVisualStyleBackColor = true;
            this.cmdClearValidation.Click += new System.EventHandler(this.cmdClearValidation_Click);
            // 
            // trvValidationDoc
            // 
            this.trvValidationDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvValidationDoc.Location = new System.Drawing.Point(24, 126);
            this.trvValidationDoc.Margin = new System.Windows.Forms.Padding(5);
            this.trvValidationDoc.Name = "trvValidationDoc";
            this.trvValidationDoc.Padding = new System.Windows.Forms.Padding(1);
            this.trvValidationDoc.Size = new System.Drawing.Size(651, 211);
            this.trvValidationDoc.TabIndex = 30;
            // 
            // frmCreateCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCreateCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "CreateNewCollection";
            this.Text = "Create Collection";
            this.Load += new System.EventHandler(this.frmCreateCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdOK;
        private Button cmdCancel;
        private TextBox txtCollectionName;
        private Label lblCollectionName;
        private CheckBox chkIsCapped;
        private NumericUpDown numMaxSize;
        private NumericUpDown numMaxDocument;
        private Label lblMaxSize;
        private Label lblMaxDocument;
        private LinkLabel lnkCappedCollections;
        private CheckBox chkValidation;
        private GroupBox groupBox1;
        private RadioButton radLevel_moderate;
        private RadioButton radLevel_off;
        private RadioButton radLevel_strict;
        private GroupBox groupBox2;
        private RadioButton radAction_error;
        private RadioButton radAction_warn;
        private MongoGUICtl.CtlTreeViewColumns trvValidationDoc;
        private Button cmdCreateValidation;
        private Label label1;
        private MongoGUICtl.CtlTreeViewColumns trvCollation;
        private Button btnCollation;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage2;
        private Label label2;
        private Label label3;
        private Button cmdClearValidation;
        private Button btnClearCollation;
    }
}