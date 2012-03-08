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
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.ServerStatusCtl = new MagicMongoDBTool.UserController.ctlServerStatus();
            this.SuspendLayout();
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.Location = new System.Drawing.Point(632, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(76, 24);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(714, 0);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(156, 24);
            this.btnSwitch.TabIndex = 7;
            this.btnSwitch.Text = "Stop Auto Refresh";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // ServerStatusCtl
            // 
            this.ServerStatusCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatusCtl.Location = new System.Drawing.Point(0, 0);
            this.ServerStatusCtl.Name = "ServerStatusCtl";
            this.ServerStatusCtl.Size = new System.Drawing.Size(900, 480);
            this.ServerStatusCtl.TabIndex = 6;
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.btnSwitch);
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
        private System.Windows.Forms.Button btnSwitch;
    }
}