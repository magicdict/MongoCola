namespace HRSystem
{
    partial class frmReclye
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
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHiringTracking
            // 
            this.lstHiringTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHiringTracking.FullRowSelect = true;
            this.lstHiringTracking.GridLines = true;
            this.lstHiringTracking.Location = new System.Drawing.Point(25, 81);
            this.lstHiringTracking.Name = "lstHiringTracking";
            this.lstHiringTracking.Size = new System.Drawing.Size(714, 281);
            this.lstHiringTracking.TabIndex = 3;
            this.lstHiringTracking.UseCompatibleStateImageBehavior = false;
            this.lstHiringTracking.View = System.Windows.Forms.View.Details;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRestore.Location = new System.Drawing.Point(642, 42);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(85, 23);
            this.btnRestore.TabIndex = 43;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // frmReclye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 391);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lstHiringTracking);
            this.Name = "frmReclye";
            this.Text = "Reclye";
            this.Load += new System.EventHandler(this.frmReclye_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstHiringTracking;
        private System.Windows.Forms.Button btnRestore;
    }
}