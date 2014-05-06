namespace CardHelper
{
    partial class RunMagic
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
            this.btnCreate奥术飞弹 = new System.Windows.Forms.Button();
            this.btnResetEenmey = new System.Windows.Forms.Button();
            this.btnUserMagic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate奥术飞弹
            // 
            this.btnCreate奥术飞弹.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreate奥术飞弹.Location = new System.Drawing.Point(12, 12);
            this.btnCreate奥术飞弹.Name = "btnCreate奥术飞弹";
            this.btnCreate奥术飞弹.Size = new System.Drawing.Size(302, 23);
            this.btnCreate奥术飞弹.TabIndex = 1;
            this.btnCreate奥术飞弹.Text = "新建卡牌-奥术飞弹（魔法）";
            this.btnCreate奥术飞弹.UseVisualStyleBackColor = false;
            this.btnCreate奥术飞弹.Click += new System.EventHandler(this.btnCreate奥术飞弹_Click);
            // 
            // btnResetEenmey
            // 
            this.btnResetEenmey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnResetEenmey.Location = new System.Drawing.Point(12, 41);
            this.btnResetEenmey.Name = "btnResetEenmey";
            this.btnResetEenmey.Size = new System.Drawing.Size(302, 23);
            this.btnResetEenmey.TabIndex = 2;
            this.btnResetEenmey.Text = "重置对手战场";
            this.btnResetEenmey.UseVisualStyleBackColor = false;
            this.btnResetEenmey.Click += new System.EventHandler(this.btnResetEenmey_Click);
            // 
            // btnUserMagic
            // 
            this.btnUserMagic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUserMagic.Location = new System.Drawing.Point(12, 70);
            this.btnUserMagic.Name = "btnUserMagic";
            this.btnUserMagic.Size = new System.Drawing.Size(302, 23);
            this.btnUserMagic.TabIndex = 3;
            this.btnUserMagic.Text = "使用-奥术飞弹（魔法）";
            this.btnUserMagic.UseVisualStyleBackColor = false;
            this.btnUserMagic.Click += new System.EventHandler(this.btnUserMagic_Click);
            // 
            // RunMagic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 111);
            this.Controls.Add(this.btnUserMagic);
            this.Controls.Add(this.btnResetEenmey);
            this.Controls.Add(this.btnCreate奥术飞弹);
            this.Name = "RunMagic";
            this.Text = "RunMagic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate奥术飞弹;
        private System.Windows.Forms.Button btnResetEenmey;
        private System.Windows.Forms.Button btnUserMagic;
    }
}