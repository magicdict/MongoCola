namespace HTTPServer
{
    partial class Console
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
            this.lnkWebFormEntry = new System.Windows.Forms.LinkLabel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lnkWebFormEntry
            // 
            this.lnkWebFormEntry.AutoSize = true;
            this.lnkWebFormEntry.Location = new System.Drawing.Point(391, 39);
            this.lnkWebFormEntry.Name = "lnkWebFormEntry";
            this.lnkWebFormEntry.Size = new System.Drawing.Size(138, 13);
            this.lnkWebFormEntry.TabIndex = 12;
            this.lnkWebFormEntry.TabStop = true;
            this.lnkWebFormEntry.Text = "MongoCola WebForm(Beta)";
            this.lnkWebFormEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebFormEntry_LinkClicked);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(21, 97);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(508, 153);
            this.txtInfo.TabIndex = 13;
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 262);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lnkWebFormEntry);
            this.Name = "Console";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Console_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkWebFormEntry;
        private System.Windows.Forms.TextBox txtInfo;
    }
}