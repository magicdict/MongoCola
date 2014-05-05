namespace UnitTest
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
            this.btnCreateNewCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateNewCard
            // 
            this.btnCreateNewCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreateNewCard.Location = new System.Drawing.Point(39, 21);
            this.btnCreateNewCard.Name = "btnCreateNewCard";
            this.btnCreateNewCard.Size = new System.Drawing.Size(164, 23);
            this.btnCreateNewCard.TabIndex = 0;
            this.btnCreateNewCard.Text = "新建卡牌-奥术飞弹";
            this.btnCreateNewCard.UseVisualStyleBackColor = false;
            this.btnCreateNewCard.Click += new System.EventHandler(this.btnCreateNewCard_Click);
            // 
            // CardUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 262);
            this.Controls.Add(this.btnCreateNewCard);
            this.Name = "CardUnit";
            this.Text = "CardUnit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateNewCard;
    }
}