using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
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
            this.cmdYes = new System.Windows.Forms.Button();
            this.cmdNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(99, 35);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 15);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "Message";
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
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.Location = new System.Drawing.Point(102, 96);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 32);
            this.cmdYes.TabIndex = 0;
            this.cmdYes.Text = "Yes";
            this.cmdYes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.UseVisualStyleBackColor = false;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.BackColor = System.Drawing.Color.Transparent;
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.Location = new System.Drawing.Point(249, 96);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 32);
            this.cmdNo.TabIndex = 1;
            this.cmdNo.Text = "No";
            this.cmdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.UseVisualStyleBackColor = false;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // frmConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 152);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picImage);
            this.Name = "frmConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmconfirm";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdNo;
        private System.Windows.Forms.Button cmdYes;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox picImage;
    }
}