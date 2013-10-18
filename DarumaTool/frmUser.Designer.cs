namespace DarumaTool
{
    partial class frmUser
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
            this.btnSourcePick = new System.Windows.Forms.Button();
            this.btnAnlyze = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSourcePick
            // 
            this.btnSourcePick.Location = new System.Drawing.Point(12, 12);
            this.btnSourcePick.Name = "btnSourcePick";
            this.btnSourcePick.Size = new System.Drawing.Size(170, 23);
            this.btnSourcePick.TabIndex = 0;
            this.btnSourcePick.Text = "ソースを選ぶ";
            this.btnSourcePick.UseVisualStyleBackColor = true;
            this.btnSourcePick.Click += new System.EventHandler(this.btnSourcePick_Click);
            // 
            // btnAnlyze
            // 
            this.btnAnlyze.Location = new System.Drawing.Point(12, 41);
            this.btnAnlyze.Name = "btnAnlyze";
            this.btnAnlyze.Size = new System.Drawing.Size(82, 23);
            this.btnAnlyze.TabIndex = 1;
            this.btnAnlyze.Text = "文法解析";
            this.btnAnlyze.UseVisualStyleBackColor = true;
            this.btnAnlyze.Click += new System.EventHandler(this.btnAnlyze_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(100, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(197, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "ＩＤＬソース：未選択";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "必ず「閉じる」ボタンをクリックし、プログラムを中止させてください！（EXCELのプロセスをKILLのため）";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 99);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAnlyze);
            this.Controls.Add(this.btnSourcePick);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分岐点解析";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSourcePick;
        private System.Windows.Forms.Button btnAnlyze;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
    }
}