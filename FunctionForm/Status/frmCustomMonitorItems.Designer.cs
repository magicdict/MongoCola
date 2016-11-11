namespace FunctionForm.Status
{
    partial class frmCustomMonitorItems
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
            this.chklstStatus = new System.Windows.Forms.CheckedListBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklstStatus
            // 
            this.chklstStatus.FormattingEnabled = true;
            this.chklstStatus.Location = new System.Drawing.Point(22, 23);
            this.chklstStatus.Name = "chklstStatus";
            this.chklstStatus.Size = new System.Drawing.Size(389, 324);
            this.chklstStatus.TabIndex = 0;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(140, 363);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(125, 36);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmCustomMonitorItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 421);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chklstStatus);
            this.Name = "frmCustomMonitorItems";
            this.Text = "Custom Monitor Items";
            this.Load += new System.EventHandler(this.frmCustomMonitorItems_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstStatus;
        private System.Windows.Forms.Button cmdOK;
    }
}