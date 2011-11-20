using GUIResource;
namespace QLFUI
{
    partial class frmConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirm));
            this.lblMessage = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.cmdYes = new System.Windows.Forms.VistaButton();
            this.cmdNo = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdNo);
            this.contentPanel.Controls.Add(this.cmdYes);
            this.contentPanel.Controls.Add(this.lblMessage);
            this.contentPanel.Controls.Add(this.picImage);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(436, 166);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(87, 35);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(33, 15);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "信息";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Location = new System.Drawing.Point(50, 35);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(24, 24);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 7;
            this.picImage.TabStop = false;
            // 
            // cmdYes
            // 
            this.cmdYes.BackColor = System.Drawing.Color.Transparent;
            this.cmdYes.BaseColor = System.Drawing.Color.Transparent;
            this.cmdYes.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(40)))));
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.Location = new System.Drawing.Point(90, 107);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 32);
            this.cmdYes.TabIndex = 0;
            this.cmdYes.Text = "是";
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.BackColor = System.Drawing.Color.Transparent;
            this.cmdNo.BaseColor = System.Drawing.Color.Transparent;
            this.cmdNo.ButtonColor = System.Drawing.Color.Coral;
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.Location = new System.Drawing.Point(237, 107);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 32);
            this.cmdNo.TabIndex = 1;
            this.cmdNo.Text = "否";
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // frmconfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 229);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmconfirm";
            this.ShowSelectSkinButton = false;
            this.Text = "frmconfirm";
            this.Load += new System.EventHandler(this.frmconfirm_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdNo;
        private System.Windows.Forms.VistaButton cmdYes;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox picImage;
    }
}