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
            this.lstSrvStatus = new System.Windows.Forms.ListView();
            this.lstSrvOpr = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstSrvStatus
            // 
            this.lstSrvStatus.FullRowSelect = true;
            this.lstSrvStatus.GridLines = true;
            this.lstSrvStatus.Location = new System.Drawing.Point(26, 12);
            this.lstSrvStatus.Name = "lstSrvStatus";
            this.lstSrvStatus.Size = new System.Drawing.Size(825, 222);
            this.lstSrvStatus.TabIndex = 0;
            this.lstSrvStatus.UseCompatibleStateImageBehavior = false;
            this.lstSrvStatus.View = System.Windows.Forms.View.Details;
            // 
            // lstSrvOpr
            // 
            this.lstSrvOpr.FullRowSelect = true;
            this.lstSrvOpr.GridLines = true;
            this.lstSrvOpr.Location = new System.Drawing.Point(28, 252);
            this.lstSrvOpr.Name = "lstSrvOpr";
            this.lstSrvOpr.Size = new System.Drawing.Size(825, 118);
            this.lstSrvOpr.TabIndex = 1;
            this.lstSrvOpr.UseCompatibleStateImageBehavior = false;
            this.lstSrvOpr.View = System.Windows.Forms.View.Details;
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 412);
            this.Controls.Add(this.lstSrvOpr);
            this.Controls.Add(this.lstSrvStatus);
            this.Name = "frmServiceStatus";
            this.Text = "服务器状态";
            this.Load += new System.EventHandler(this.frmServiceStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSrvStatus;
        private System.Windows.Forms.ListView lstSrvOpr;
    }
}