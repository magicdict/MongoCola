namespace DarumaUTGenerator
{
    partial class MacroAnalyze
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
            this.lblIDL2File = new System.Windows.Forms.Label();
            this.btnSourcePick = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIDL2File
            // 
            this.lblIDL2File.AutoSize = true;
            this.lblIDL2File.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDL2File.Location = new System.Drawing.Point(146, 17);
            this.lblIDL2File.Name = "lblIDL2File";
            this.lblIDL2File.Size = new System.Drawing.Size(107, 13);
            this.lblIDL2File.TabIndex = 5;
            this.lblIDL2File.Text = "ＩＤＬソース：未選択";
            // 
            // btnSourcePick
            // 
            this.btnSourcePick.Location = new System.Drawing.Point(12, 12);
            this.btnSourcePick.Name = "btnSourcePick";
            this.btnSourcePick.Size = new System.Drawing.Size(119, 23);
            this.btnSourcePick.TabIndex = 4;
            this.btnSourcePick.Text = "ソースを選ぶ…";
            this.btnSourcePick.UseVisualStyleBackColor = true;
            this.btnSourcePick.Click += new System.EventHandler(this.btnSourcePick_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(656, 48);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "分析";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // MacroAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(743, 73);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblIDL2File);
            this.Controls.Add(this.btnSourcePick);
            this.Name = "MacroAnalyze";
            this.Text = "MacroAnalyze";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDL2File;
        private System.Windows.Forms.Button btnSourcePick;
        private System.Windows.Forms.Button btnRun;
    }
}