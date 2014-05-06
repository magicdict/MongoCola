namespace CardHelper
{
    partial class CardUnit
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
            this.btnCreate狼骑兵 = new System.Windows.Forms.Button();
            this.btnCreate角斗士的长弓 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate奥术飞弹
            // 
            this.btnCreate奥术飞弹.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreate奥术飞弹.Location = new System.Drawing.Point(39, 21);
            this.btnCreate奥术飞弹.Name = "btnCreate奥术飞弹";
            this.btnCreate奥术飞弹.Size = new System.Drawing.Size(302, 23);
            this.btnCreate奥术飞弹.TabIndex = 0;
            this.btnCreate奥术飞弹.Text = "新建卡牌-奥术飞弹";
            this.btnCreate奥术飞弹.UseVisualStyleBackColor = false;
            this.btnCreate奥术飞弹.Click += new System.EventHandler(this.btnCreate奥术飞弹_Click);
            // 
            // btnCreate狼骑兵
            // 
            this.btnCreate狼骑兵.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreate狼骑兵.Location = new System.Drawing.Point(39, 50);
            this.btnCreate狼骑兵.Name = "btnCreate狼骑兵";
            this.btnCreate狼骑兵.Size = new System.Drawing.Size(302, 23);
            this.btnCreate狼骑兵.TabIndex = 1;
            this.btnCreate狼骑兵.Text = "新建卡牌-狼骑兵";
            this.btnCreate狼骑兵.UseVisualStyleBackColor = false;
            this.btnCreate狼骑兵.Click += new System.EventHandler(this.btnCreate狼骑兵_Click);
            // 
            // btnCreate角斗士的长弓
            // 
            this.btnCreate角斗士的长弓.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreate角斗士的长弓.Location = new System.Drawing.Point(39, 79);
            this.btnCreate角斗士的长弓.Name = "btnCreate角斗士的长弓";
            this.btnCreate角斗士的长弓.Size = new System.Drawing.Size(302, 23);
            this.btnCreate角斗士的长弓.TabIndex = 1;
            this.btnCreate角斗士的长弓.Text = "新建卡牌-角斗士的长弓";
            this.btnCreate角斗士的长弓.UseVisualStyleBackColor = false;
            this.btnCreate角斗士的长弓.Click += new System.EventHandler(this.btnCreate角斗士的长弓_Click);
            // 
            // CardUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 262);
            this.Controls.Add(this.btnCreate角斗士的长弓);
            this.Controls.Add(this.btnCreate狼骑兵);
            this.Controls.Add(this.btnCreate奥术飞弹);
            this.Name = "CardUnit";
            this.Text = "CardUnit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate奥术飞弹;
        private System.Windows.Forms.Button btnCreate狼骑兵;
        private System.Windows.Forms.Button btnCreate角斗士的长弓;
    }
}