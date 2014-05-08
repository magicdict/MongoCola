namespace CardHelper
{
    partial class CardDeckTest
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
            this.btn洗牌测试 = new System.Windows.Forms.Button();
            this.btn洗牌测试2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn洗牌测试
            // 
            this.btn洗牌测试.Location = new System.Drawing.Point(53, 26);
            this.btn洗牌测试.Name = "btn洗牌测试";
            this.btn洗牌测试.Size = new System.Drawing.Size(105, 23);
            this.btn洗牌测试.TabIndex = 0;
            this.btn洗牌测试.Text = "洗牌测试";
            this.btn洗牌测试.UseVisualStyleBackColor = true;
            this.btn洗牌测试.Click += new System.EventHandler(this.btn洗牌测试_Click);
            // 
            // btn洗牌测试2
            // 
            this.btn洗牌测试2.Location = new System.Drawing.Point(53, 55);
            this.btn洗牌测试2.Name = "btn洗牌测试2";
            this.btn洗牌测试2.Size = new System.Drawing.Size(105, 23);
            this.btn洗牌测试2.TabIndex = 1;
            this.btn洗牌测试2.Text = "洗牌测试2";
            this.btn洗牌测试2.UseVisualStyleBackColor = true;
            this.btn洗牌测试2.Click += new System.EventHandler(this.btn洗牌测试2_Click);
            // 
            // CardDeckTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 262);
            this.Controls.Add(this.btn洗牌测试2);
            this.Controls.Add(this.btn洗牌测试);
            this.Name = "CardDeckTest";
            this.Text = "CardDeckTest";
            this.Load += new System.EventHandler(this.CardDeckTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn洗牌测试;
        private System.Windows.Forms.Button btn洗牌测试2;
    }
}