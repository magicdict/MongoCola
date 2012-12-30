namespace MagicMongoDBTool.UnitTest
{
    partial class frmUnitTest
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
            this.btnFillDataForUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFillDataForUser
            // 
            this.btnFillDataForUser.Location = new System.Drawing.Point(36, 26);
            this.btnFillDataForUser.Name = "btnFillDataForUser";
            this.btnFillDataForUser.Size = new System.Drawing.Size(137, 23);
            this.btnFillDataForUser.TabIndex = 0;
            this.btnFillDataForUser.Text = "FillDataForUser";
            this.btnFillDataForUser.UseVisualStyleBackColor = true;
            this.btnFillDataForUser.Click += new System.EventHandler(this.btnFillDataForUser_Click);
            // 
            // frmUnitTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 80);
            this.Controls.Add(this.btnFillDataForUser);
            this.Name = "frmUnitTest";
            this.Text = "frmUnitTest";
            this.Load += new System.EventHandler(this.frmUnitTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFillDataForUser;
    }
}