namespace UnitTest
{
    partial class frmDataBase
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
            this.btnUser = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnDetailSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(47, 29);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(117, 31);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "用户测试";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(47, 82);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(117, 31);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "行程测试";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnDetailSchedule
            // 
            this.btnDetailSchedule.Location = new System.Drawing.Point(47, 145);
            this.btnDetailSchedule.Name = "btnDetailSchedule";
            this.btnDetailSchedule.Size = new System.Drawing.Size(117, 31);
            this.btnDetailSchedule.TabIndex = 2;
            this.btnDetailSchedule.Text = "详细行程测试";
            this.btnDetailSchedule.UseVisualStyleBackColor = true;
            this.btnDetailSchedule.Click += new System.EventHandler(this.btnDetailSchedule_Click);
            // 
            // frmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 214);
            this.Controls.Add(this.btnDetailSchedule);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnUser);
            this.Name = "frmDataBase";
            this.Text = "数据库测试";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnDetailSchedule;
    }
}