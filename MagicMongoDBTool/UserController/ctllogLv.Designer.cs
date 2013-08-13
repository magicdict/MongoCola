namespace MagicMongoDBTool.Module
{
    partial class ctllogLv
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
            this.lblLogLv = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblLogLv
            // 
            this.lblLogLv.AutoSize = true;
            this.lblLogLv.Location = new System.Drawing.Point(-2, 3);
            this.lblLogLv.Name = "lblLogLv";
            this.lblLogLv.Size = new System.Drawing.Size(43, 13);
            this.lblLogLv.TabIndex = 4;
            this.lblLogLv.Text = "LogLv：";
            // 
            // cmbLogLevel
            // 
            this.cmbLogLevel.FormattingEnabled = true;
            this.cmbLogLevel.Location = new System.Drawing.Point(62, 0);
            this.cmbLogLevel.Name = "cmbLogLevel";
            this.cmbLogLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbLogLevel.TabIndex = 5;
            this.cmbLogLevel.SelectedIndexChanged += new System.EventHandler(this.cmbLogLevel_SelectedIndexChanged);
            // 
            // ctllogLv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbLogLevel);
            this.Controls.Add(this.lblLogLv);
            this.Name = "ctllogLv";
            this.Size = new System.Drawing.Size(187, 23);
            this.Load += new System.EventHandler(this.ctllogLv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogLv;
        private System.Windows.Forms.ComboBox cmbLogLevel;
    }
}
