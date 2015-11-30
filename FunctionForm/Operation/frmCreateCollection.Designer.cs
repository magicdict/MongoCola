using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    partial class FrmCreateCollection
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
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.lnkCappedCollections = new System.Windows.Forms.LinkLabel();
            this.chkAdvance = new System.Windows.Forms.CheckBox();
            this.chkValidation = new System.Windows.Forms.CheckBox();
            this.txtValidation = new System.Windows.Forms.TextBox();
            this.radLevel_off = new System.Windows.Forms.RadioButton();
            this.radLevel_strict = new System.Windows.Forms.RadioButton();
            this.radLevel_moderate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAction_error = new System.Windows.Forms.RadioButton();
            this.radAction_warn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).BeginInit();
            this.grpAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(130, 436);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(284, 436);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 27);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(161, 15);
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
            this.chkIsCapped.Checked = true;
            this.chkIsCapped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsCapped.Location = new System.Drawing.Point(23, 32);
            this.chkIsCapped.Name = "chkIsCapped";
            this.chkIsCapped.Size = new System.Drawing.Size(78, 19);
            this.chkIsCapped.TabIndex = 0;
            this.chkIsCapped.Text = "IsCapped";
            this.chkIsCapped.UseVisualStyleBackColor = true;
            // 
            // chkIsAutoIndexId
            // 
            this.chkIsAutoIndexId.AutoSize = true;
            this.chkIsAutoIndexId.Checked = true;
            this.chkIsAutoIndexId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAutoIndexId.Location = new System.Drawing.Point(131, 32);
            this.chkIsAutoIndexId.Name = "chkIsAutoIndexId";
            this.chkIsAutoIndexId.Size = new System.Drawing.Size(99, 19);
            this.chkIsAutoIndexId.TabIndex = 1;
            this.chkIsAutoIndexId.Text = "IsAutoIndexId";
            this.chkIsAutoIndexId.UseVisualStyleBackColor = true;
            // 
            // numMaxSize
            // 
            this.numMaxSize.Location = new System.Drawing.Point(131, 57);
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
            this.numMaxDocument.Location = new System.Drawing.Point(131, 85);
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
            this.lblMaxSize.Location = new System.Drawing.Point(23, 60);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(55, 15);
            this.lblMaxSize.TabIndex = 2;
            this.lblMaxSize.Text = "MaxSize";
            // 
            // lblMaxDocument
            // 
            this.lblMaxDocument.AutoSize = true;
            this.lblMaxDocument.Location = new System.Drawing.Point(23, 87);
            this.lblMaxDocument.Name = "lblMaxDocument";
            this.lblMaxDocument.Size = new System.Drawing.Size(88, 15);
            this.lblMaxDocument.TabIndex = 4;
            this.lblMaxDocument.Text = "MaxDocument";
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.groupBox2);
            this.grpAdvanced.Controls.Add(this.groupBox1);
            this.grpAdvanced.Controls.Add(this.txtValidation);
            this.grpAdvanced.Controls.Add(this.chkValidation);
            this.grpAdvanced.Controls.Add(this.lnkCappedCollections);
            this.grpAdvanced.Controls.Add(this.chkIsAutoIndexId);
            this.grpAdvanced.Controls.Add(this.lblMaxDocument);
            this.grpAdvanced.Controls.Add(this.chkIsCapped);
            this.grpAdvanced.Controls.Add(this.lblMaxSize);
            this.grpAdvanced.Controls.Add(this.numMaxSize);
            this.grpAdvanced.Controls.Add(this.numMaxDocument);
            this.grpAdvanced.Location = new System.Drawing.Point(30, 45);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(453, 385);
            this.grpAdvanced.TabIndex = 3;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced";
            // 
            // lnkCappedCollections
            // 
            this.lnkCappedCollections.AutoSize = true;
            this.lnkCappedCollections.Location = new System.Drawing.Point(21, 111);
            this.lnkCappedCollections.Name = "lnkCappedCollections";
            this.lnkCappedCollections.Size = new System.Drawing.Size(141, 15);
            this.lnkCappedCollections.TabIndex = 6;
            this.lnkCappedCollections.TabStop = true;
            this.lnkCappedCollections.Text = "About Capped Collection";
            this.lnkCappedCollections.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCappedCollections_LinkClicked);
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(-2, -2);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(118, 19);
            this.chkAdvance.TabIndex = 2;
            this.chkAdvance.Text = "Advanced Option";
            this.chkAdvance.UseVisualStyleBackColor = true;
            this.chkAdvance.CheckedChanged += new System.EventHandler(this.chkAdvance_CheckedChanged);
            // 
            // chkValidation
            // 
            this.chkValidation.AutoSize = true;
            this.chkValidation.Location = new System.Drawing.Point(21, 141);
            this.chkValidation.Name = "chkValidation";
            this.chkValidation.Size = new System.Drawing.Size(80, 19);
            this.chkValidation.TabIndex = 6;
            this.chkValidation.Text = "Validation";
            this.chkValidation.UseVisualStyleBackColor = true;
            // 
            // txtValidation
            // 
            this.txtValidation.Location = new System.Drawing.Point(21, 218);
            this.txtValidation.Multiline = true;
            this.txtValidation.Name = "txtValidation";
            this.txtValidation.Size = new System.Drawing.Size(414, 161);
            this.txtValidation.TabIndex = 24;
            this.txtValidation.Text = "Validation Express";
            // 
            // radLevel_off
            // 
            this.radLevel_off.AutoSize = true;
            this.radLevel_off.Checked = true;
            this.radLevel_off.Location = new System.Drawing.Point(4, 20);
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
            this.radLevel_strict.Location = new System.Drawing.Point(48, 19);
            this.radLevel_strict.Name = "radLevel_strict";
            this.radLevel_strict.Size = new System.Drawing.Size(50, 19);
            this.radLevel_strict.TabIndex = 26;
            this.radLevel_strict.TabStop = true;
            this.radLevel_strict.Text = "strict";
            this.radLevel_strict.UseVisualStyleBackColor = true;
            // 
            // radLevel_moderate
            // 
            this.radLevel_moderate.AutoSize = true;
            this.radLevel_moderate.Location = new System.Drawing.Point(104, 20);
            this.radLevel_moderate.Name = "radLevel_moderate";
            this.radLevel_moderate.Size = new System.Drawing.Size(78, 19);
            this.radLevel_moderate.TabIndex = 27;
            this.radLevel_moderate.TabStop = true;
            this.radLevel_moderate.Text = "moderate";
            this.radLevel_moderate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLevel_moderate);
            this.groupBox1.Controls.Add(this.radLevel_off);
            this.groupBox1.Controls.Add(this.radLevel_strict);
            this.groupBox1.Location = new System.Drawing.Point(21, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 45);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radAction_error);
            this.groupBox2.Controls.Add(this.radAction_warn);
            this.groupBox2.Location = new System.Drawing.Point(235, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 38);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // radAction_error
            // 
            this.radAction_error.AutoSize = true;
            this.radAction_error.Checked = true;
            this.radAction_error.Location = new System.Drawing.Point(12, 14);
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
            this.radAction_warn.Location = new System.Drawing.Point(69, 13);
            this.radAction_warn.Name = "radAction_warn";
            this.radAction_warn.Size = new System.Drawing.Size(52, 19);
            this.radAction_warn.TabIndex = 28;
            this.radAction_warn.TabStop = true;
            this.radAction_warn.Text = "warn";
            this.radAction_warn.UseVisualStyleBackColor = true;
            // 
            // FrmCreateCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 475);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpAdvanced);
            this.Controls.Add(this.chkAdvance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCreateCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Collection";
            this.Load += new System.EventHandler(this.frmCreateCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).EndInit();
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private GroupBox grpAdvanced;
        private CheckBox chkAdvance;
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
    }
}