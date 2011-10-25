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
            this.trbLogLv = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbLogLv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogLv
            // 
            this.lblLogLv.AutoSize = true;
            this.lblLogLv.Location = new System.Drawing.Point(3, 13);
            this.lblLogLv.Name = "lblLogLv";
            this.lblLogLv.Size = new System.Drawing.Size(85, 13);
            this.lblLogLv.TabIndex = 4;
            this.lblLogLv.Text = "日志等级：最少";
            // 
            // trbLogLv
            // 
            this.trbLogLv.BackColor = System.Drawing.Color.White;
            this.trbLogLv.LargeChange = 1;
            this.trbLogLv.Location = new System.Drawing.Point(109, 3);
            this.trbLogLv.Name = "trbLogLv";
            this.trbLogLv.Size = new System.Drawing.Size(198, 45);
            this.trbLogLv.TabIndex = 3;
            this.trbLogLv.Scroll += new System.EventHandler(this.trbLogLv_Scroll);
            // 
            // ctllogLv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLogLv);
            this.Controls.Add(this.trbLogLv);
            this.Name = "ctllogLv";
            this.Size = new System.Drawing.Size(312, 51);
            this.Load += new System.EventHandler(this.ctllogLv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbLogLv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogLv;
        private System.Windows.Forms.TrackBar trbLogLv;
    }
}
