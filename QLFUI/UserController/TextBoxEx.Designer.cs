namespace QLFUI
{
    partial class TextBoxEx
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt = new System.Windows.Forms.TextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(3, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(100, 20);
            this.txt.TabIndex = 0;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(3, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(100, 22);
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            // 
            // TextBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt);
            this.Controls.Add(this.pic);
            this.Name = "TextBoxEx";
            this.Size = new System.Drawing.Size(105, 24);
            this.Load += new System.EventHandler(this.TextBoxEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.PictureBox pic;
        
    }
}
