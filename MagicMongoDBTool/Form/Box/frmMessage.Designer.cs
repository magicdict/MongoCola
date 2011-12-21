namespace MagicMongoDBTool
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
            this.txtException = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdDetails = new System.Windows.Forms.Button();
            this.panForBgcolor = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.panForBgcolor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
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
            this.txtException.Size = new System.Drawing.Size(453, 137);
            this.txtException.TabIndex = 5;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(42, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(67, 15);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Summary";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(350, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDetails
            // 
            this.cmdDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDetails.BackColor = System.Drawing.Color.Transparent;
            this.cmdDetails.Location = new System.Drawing.Point(31, 8);
            this.cmdDetails.Name = "cmdDetails";
            this.cmdDetails.Size = new System.Drawing.Size(100, 32);
            this.cmdDetails.TabIndex = 8;
            this.cmdDetails.Text = "details";
            this.cmdDetails.UseVisualStyleBackColor = false;
            this.cmdDetails.Click += new System.EventHandler(this.cmdDetails_Click);
            // 
            // panForBgcolor
            // 
            this.panForBgcolor.Controls.Add(this.cmdOK);
            this.panForBgcolor.Controls.Add(this.cmdDetails);
            this.panForBgcolor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panForBgcolor.Location = new System.Drawing.Point(0, 199);
            this.panForBgcolor.Name = "panForBgcolor";
            this.panForBgcolor.Size = new System.Drawing.Size(477, 43);
            this.panForBgcolor.TabIndex = 9;
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Location = new System.Drawing.Point(12, 12);
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
            this.ClientSize = new System.Drawing.Size(477, 242);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtException);
            this.Controls.Add(this.panForBgcolor);
            this.Controls.Add(this.picImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMesssage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result";
            this.panForBgcolor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdDetails;
        private System.Windows.Forms.Panel panForBgcolor;
        private System.Windows.Forms.PictureBox picImage;
    }
}