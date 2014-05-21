namespace 炉边传说
{
    partial class EffectSelect
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
            this.btnEffect1 = new System.Windows.Forms.Button();
            this.btnEffect2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEffect1
            // 
            this.btnEffect1.Location = new System.Drawing.Point(79, 38);
            this.btnEffect1.Name = "btnEffect1";
            this.btnEffect1.Size = new System.Drawing.Size(291, 42);
            this.btnEffect1.TabIndex = 0;
            this.btnEffect1.Text = "效果1";
            this.btnEffect1.UseVisualStyleBackColor = true;
            this.btnEffect1.Click += new System.EventHandler(this.btnEffect1_Click);
            // 
            // btnEffect2
            // 
            this.btnEffect2.Location = new System.Drawing.Point(79, 117);
            this.btnEffect2.Name = "btnEffect2";
            this.btnEffect2.Size = new System.Drawing.Size(291, 42);
            this.btnEffect2.TabIndex = 1;
            this.btnEffect2.Text = "效果2";
            this.btnEffect2.UseVisualStyleBackColor = true;
            this.btnEffect2.Click += new System.EventHandler(this.btnEffect2_Click);
            // 
            // EffectSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 213);
            this.Controls.Add(this.btnEffect2);
            this.Controls.Add(this.btnEffect1);
            this.Name = "EffectSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EffectSelect";
            this.Load += new System.EventHandler(this.EffectSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEffect1;
        private System.Windows.Forms.Button btnEffect2;
    }
}