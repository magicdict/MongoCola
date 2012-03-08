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
            this.ServerStatusCtl = new MagicMongoDBTool.UserController.ctlServerStatus();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlServerStatus1
            // 
            this.ServerStatusCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatusCtl.Location = new System.Drawing.Point(0, 0);
            this.ServerStatusCtl.Name = "ctlServerStatus1";
            this.ServerStatusCtl.Size = new System.Drawing.Size(900, 480);
            this.ServerStatusCtl.TabIndex = 6;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.Location = new System.Drawing.Point(771, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(117, 24);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.ServerStatusCtl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmServiceStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServiceStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmServiceStatus_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private UserController.ctlServerStatus ServerStatusCtl;
        private System.Windows.Forms.Button cmdRefresh;
    }
}