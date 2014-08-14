using System;

namespace HRSystem
{
    partial class frmHiringTracking
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
            this.lstHiringTracking = new System.Windows.Forms.ListView();
            this.cmbFinalStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditor = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHiringTracking
            // 
            this.lstHiringTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHiringTracking.FullRowSelect = true;
            this.lstHiringTracking.GridLines = true;
            this.lstHiringTracking.Location = new System.Drawing.Point(12, 62);
            this.lstHiringTracking.Name = "lstHiringTracking";
            this.lstHiringTracking.Size = new System.Drawing.Size(899, 330);
            this.lstHiringTracking.TabIndex = 2;
            this.lstHiringTracking.UseCompatibleStateImageBehavior = false;
            this.lstHiringTracking.View = System.Windows.Forms.View.Details;
            this.lstHiringTracking.DoubleClick += new System.EventHandler(this.lstHiringTracking_DoubleClick);
            // 
            // cmbFinalStatus
            // 
            this.cmbFinalStatus.FormattingEnabled = true;
            this.cmbFinalStatus.Location = new System.Drawing.Point(95, 17);
            this.cmbFinalStatus.Name = "cmbFinalStatus";
            this.cmbFinalStatus.Size = new System.Drawing.Size(148, 21);
            this.cmbFinalStatus.TabIndex = 3;
            this.cmbFinalStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFinalStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Final Status";
            // 
            // btnEditor
            // 
            this.btnEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditor.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditor.Location = new System.Drawing.Point(641, 17);
            this.btnEditor.Name = "btnEditor";
            this.btnEditor.Size = new System.Drawing.Size(117, 28);
            this.btnEditor.TabIndex = 4;
            this.btnEditor.Text = "Edit";
            this.btnEditor.UseVisualStyleBackColor = false;
            this.btnEditor.Click += new System.EventHandler(this.btnEditor_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(777, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmHiringTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 404);
            this.Controls.Add(this.lstHiringTracking);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFinalStatus);
            this.Name = "frmHiringTracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmHiringTracking";
            this.Load += new System.EventHandler(this.frmHiringTracking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstHiringTracking;
        private System.Windows.Forms.ComboBox cmbFinalStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditor;
        private System.Windows.Forms.Button btnDelete;
    }
}