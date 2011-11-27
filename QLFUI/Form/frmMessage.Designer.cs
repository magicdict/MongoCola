namespace QLFUI
{
    partial class frmMesssage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesssage));
            this.txtException = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.cmdDetails = new System.Windows.Forms.VistaButton();
            this.panForBgcolor = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.contentPanel.SuspendLayout();
            this.panForBgcolor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lblMessage);
            this.contentPanel.Controls.Add(this.txtException);
            this.contentPanel.Controls.Add(this.panForBgcolor);
            this.contentPanel.Controls.Add(this.picImage);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(475, 273);
            // 
            // txtException
            // 
            this.txtException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtException.BackColor = System.Drawing.Color.White;
            this.txtException.Location = new System.Drawing.Point(11, 56);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtException.Size = new System.Drawing.Size(453, 166);
            this.txtException.TabIndex = 5;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(67, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(33, 15);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "信息";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(349, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDetails
            // 
            this.cmdDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDetails.BackColor = System.Drawing.Color.Transparent;
            this.cmdDetails.Location = new System.Drawing.Point(30, 8);
            this.cmdDetails.Name = "cmdDetails";
            this.cmdDetails.Size = new System.Drawing.Size(100, 32);
            this.cmdDetails.TabIndex = 8;
            this.cmdDetails.Text = "细节";
            this.cmdDetails.Click += new System.EventHandler(this.cmdDetails_Click);
            // 
            // panForBgcolor
            // 
            this.panForBgcolor.Controls.Add(this.cmdOK);
            this.panForBgcolor.Controls.Add(this.cmdDetails);
            this.panForBgcolor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panForBgcolor.Location = new System.Drawing.Point(0, 230);
            this.panForBgcolor.Name = "panForBgcolor";
            this.panForBgcolor.Size = new System.Drawing.Size(475, 43);
            this.panForBgcolor.TabIndex = 9;
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Location = new System.Drawing.Point(30, 10);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(24, 24);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // frmMesssage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 336);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMesssage";
            this.Text = "执行结果";
            this.Load += new System.EventHandler(this.frmMesssage_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.panForBgcolor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.VistaButton cmdDetails;
        private System.Windows.Forms.Panel panForBgcolor;
        private System.Windows.Forms.PictureBox picImage;
    }
}