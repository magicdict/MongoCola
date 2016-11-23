using System.ComponentModel;
using System.Windows.Forms;

namespace ResourceLib.UI
{
    partial class frmPasswordInputBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswordInputBox));
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.imgInfo = new System.Windows.Forms.PictureBox();
            this.btnSwithPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(74, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(262, 33);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "lblMessage";
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(35, 65);
            this.txtResult.Name = "txtResult";
            this.txtResult.PasswordChar = '*';
            this.txtResult.Size = new System.Drawing.Size(258, 23);
            this.txtResult.TabIndex = 6;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(78, 92);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 25);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(194, 92);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(86, 25);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // imgInfo
            // 
            this.imgInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgInfo.Image = ((System.Drawing.Image)(resources.GetObject("imgInfo.Image")));
            this.imgInfo.Location = new System.Drawing.Point(35, 20);
            this.imgInfo.Name = "imgInfo";
            this.imgInfo.Size = new System.Drawing.Size(32, 32);
            this.imgInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgInfo.TabIndex = 7;
            this.imgInfo.TabStop = false;
            // 
            // btnSwithPassword
            // 
            this.btnSwithPassword.Location = new System.Drawing.Point(300, 64);
            this.btnSwithPassword.Name = "btnSwithPassword";
            this.btnSwithPassword.Size = new System.Drawing.Size(36, 23);
            this.btnSwithPassword.TabIndex = 8;
            this.btnSwithPassword.Text = "S";
            this.btnSwithPassword.UseVisualStyleBackColor = true;
            this.btnSwithPassword.Click += new System.EventHandler(this.btnSwithPassword_Click);
            // 
            // frmPasswordInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 134);
            this.Controls.Add(this.btnSwithPassword);
            this.Controls.Add(this.imgInfo);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPasswordInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInputBox";
            ((System.ComponentModel.ISupportInitialize)(this.imgInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtResult;
        private Label lblMessage;
        private Button cmdCancel;
        private Button cmdOK;
        private PictureBox imgInfo;
        private Button btnSwithPassword;
    }
}