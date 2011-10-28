namespace MagicMongoDBTool
{
    partial class frmServiceStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceStatus));
            this.lstSrvOpr = new System.Windows.Forms.ListView();
            this.lstSrvStatus = new System.Windows.Forms.ListView();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lstSrvOpr);
            this.contentPanel.Controls.Add(this.lstSrvStatus);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(806, 404);
            // 
            // lstSrvOpr
            // 
            this.lstSrvOpr.FullRowSelect = true;
            this.lstSrvOpr.GridLines = true;
            this.lstSrvOpr.Location = new System.Drawing.Point(16, 264);
            this.lstSrvOpr.Name = "lstSrvOpr";
            this.lstSrvOpr.Size = new System.Drawing.Size(771, 118);
            this.lstSrvOpr.TabIndex = 3;
            this.lstSrvOpr.UseCompatibleStateImageBehavior = false;
            this.lstSrvOpr.View = System.Windows.Forms.View.Details;
            // 
            // lstSrvStatus
            // 
            this.lstSrvStatus.FullRowSelect = true;
            this.lstSrvStatus.GridLines = true;
            this.lstSrvStatus.Location = new System.Drawing.Point(16, 24);
            this.lstSrvStatus.Name = "lstSrvStatus";
            this.lstSrvStatus.Size = new System.Drawing.Size(771, 222);
            this.lstSrvStatus.TabIndex = 2;
            this.lstSrvStatus.UseCompatibleStateImageBehavior = false;
            this.lstSrvStatus.View = System.Windows.Forms.View.Details;
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 467);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServiceStatus";
            this.ShowSelectSkinButton = false;
            this.Text = "服务器状态";
            this.Load += new System.EventHandler(this.frmServiceStatus_Load);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSrvOpr;
        private System.Windows.Forms.ListView lstSrvStatus;
    }
}