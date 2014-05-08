namespace CardHelper
{
    partial class Menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnRunMagic = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "牌堆测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRunMagic
            // 
            this.btnRunMagic.Location = new System.Drawing.Point(39, 71);
            this.btnRunMagic.Name = "btnRunMagic";
            this.btnRunMagic.Size = new System.Drawing.Size(147, 23);
            this.btnRunMagic.TabIndex = 1;
            this.btnRunMagic.Text = "魔法测试";
            this.btnRunMagic.UseVisualStyleBackColor = true;
            this.btnRunMagic.Click += new System.EventHandler(this.btnRunMagic_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "游戏流程";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(227, 233);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRunMagic);
            this.Controls.Add(this.button1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRunMagic;
        private System.Windows.Forms.Button button2;
    }
}