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
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).BeginInit();
            this.grpAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(56, 191);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(210, 191);
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
            this.grpAdvanced.Controls.Add(this.lnkCappedCollections);
            this.grpAdvanced.Controls.Add(this.chkIsAutoIndexId);
            this.grpAdvanced.Controls.Add(this.lblMaxDocument);
            this.grpAdvanced.Controls.Add(this.chkIsCapped);
            this.grpAdvanced.Controls.Add(this.lblMaxSize);
            this.grpAdvanced.Controls.Add(this.numMaxSize);
            this.grpAdvanced.Controls.Add(this.numMaxDocument);
            this.grpAdvanced.Location = new System.Drawing.Point(30, 45);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(297, 140);
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
            // frmCreateCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 224);
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
    }
}