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
            this.SuspendLayout();
            // 
            // lstHiringTracking
            // 
            this.lstHiringTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHiringTracking.FullRowSelect = true;
            this.lstHiringTracking.GridLines = true;
            this.lstHiringTracking.Location = new System.Drawing.Point(6, 56);
            this.lstHiringTracking.Name = "lstHiringTracking";
            this.lstHiringTracking.Size = new System.Drawing.Size(677, 246);
            this.lstHiringTracking.TabIndex = 2;
            this.lstHiringTracking.UseCompatibleStateImageBehavior = false;
            this.lstHiringTracking.View = System.Windows.Forms.View.Details;
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
            // frmHiringTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFinalStatus);
            this.Controls.Add(this.lstHiringTracking);
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
    }
}