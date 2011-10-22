namespace MagicMongoDBTool
{
    partial class frmDataBaseStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataBaseStatus));
            this.lstDBStatus = new System.Windows.Forms.ListView();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lstDBStatus);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(959, 365);
            // 
            // lstDBStatus
            // 
            this.lstDBStatus.FullRowSelect = true;
            this.lstDBStatus.GridLines = true;
            this.lstDBStatus.Location = new System.Drawing.Point(57, 33);
            this.lstDBStatus.Name = "lstDBStatus";
            this.lstDBStatus.Size = new System.Drawing.Size(787, 265);
            this.lstDBStatus.TabIndex = 1;
            this.lstDBStatus.UseCompatibleStateImageBehavior = false;
            this.lstDBStatus.View = System.Windows.Forms.View.Details;
            // 
            // frmDataBaseStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 428);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDataBaseStatus";
            this.Text = "frmDataBaseStatus";
            this.Load += new System.EventHandler(this.frmDataBaseStatus_Load);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstDBStatus;
    }
}