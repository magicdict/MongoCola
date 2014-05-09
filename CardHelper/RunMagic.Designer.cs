namespace CardHelper
{
    partial class RunAbility
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
            this.btnUserAbility奥术飞弹 = new System.Windows.Forms.Button();
            this.btnUserAbility变羊术 = new System.Windows.Forms.Button();
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
            // btnUserAbility奥术飞弹
            // 
            this.btnUserAbility奥术飞弹.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUserAbility奥术飞弹.Location = new System.Drawing.Point(12, 70);
            this.btnUserAbility奥术飞弹.Name = "btnUserAbility奥术飞弹";
            this.btnUserAbility奥术飞弹.Size = new System.Drawing.Size(302, 23);
            this.btnUserAbility奥术飞弹.TabIndex = 3;
            this.btnUserAbility奥术飞弹.Text = "使用-奥术飞弹（魔法）";
            this.btnUserAbility奥术飞弹.UseVisualStyleBackColor = false;
            this.btnUserAbility奥术飞弹.Click += new System.EventHandler(this.btnUserAbility_Click);
            // 
            // btnUserAbility变羊术
            // 
            this.btnUserAbility变羊术.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnUserAbility变羊术.Location = new System.Drawing.Point(11, 99);
            this.btnUserAbility变羊术.Name = "btnUserAbility变羊术";
            this.btnUserAbility变羊术.Size = new System.Drawing.Size(302, 23);
            this.btnUserAbility变羊术.TabIndex = 4;
            this.btnUserAbility变羊术.Text = "使用-变羊术（魔法）";
            this.btnUserAbility变羊术.UseVisualStyleBackColor = false;
            this.btnUserAbility变羊术.Click += new System.EventHandler(this.btnUserAbility变羊术_Click);
            // 
            // RunAbility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 173);
            this.Controls.Add(this.btnUserAbility变羊术);
            this.Controls.Add(this.btnUserAbility奥术飞弹);
            this.Controls.Add(this.btnResetEenmey);
            this.Controls.Add(this.btnCreate奥术飞弹);
            this.Name = "RunAbility";
            this.Text = "RunAbility";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate奥术飞弹;
        private System.Windows.Forms.Button btnResetEenmey;
        private System.Windows.Forms.Button btnUserAbility奥术飞弹;
        private System.Windows.Forms.Button btnUserAbility变羊术;
    }
}