namespace MagicMongoDBTool
{
    partial class ctlFilePicker
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
            this.cmdClearLogPath = new System.Windows.Forms.VistaButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.cmdLogPath = new System.Windows.Forms.VistaButton();
            this.SuspendLayout();
            // 
            // cmdClearLogPath
            // 
            this.cmdClearLogPath.BackColor = System.Drawing.Color.Transparent;
            this.cmdClearLogPath.Location = new System.Drawing.Point(649, 0);
            this.cmdClearLogPath.Name = "cmdClearLogPath";
            this.cmdClearLogPath.Size = new System.Drawing.Size(75, 31);
            this.cmdClearLogPath.TabIndex = 10;
            this.cmdClearLogPath.Text = "清除";
            this.cmdClearLogPath.Click += new System.EventHandler(this.cmdClearLogPath_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(3, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "日志路径";
            // 
            // txtLogPath
            // 
            this.txtLogPath.BackColor = System.Drawing.Color.White;
            this.txtLogPath.Location = new System.Drawing.Point(120, 5);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(439, 20);
            this.txtLogPath.TabIndex = 8;
            // 
            // cmdLogPath
            // 
            this.cmdLogPath.BackColor = System.Drawing.Color.Transparent;
            this.cmdLogPath.Location = new System.Drawing.Point(568, 1);
            this.cmdLogPath.Name = "cmdLogPath";
            this.cmdLogPath.Size = new System.Drawing.Size(75, 30);
            this.cmdLogPath.TabIndex = 7;
            this.cmdLogPath.Text = "浏览...";
            this.cmdLogPath.Click += new System.EventHandler(this.cmdLogPath_Click);
            // 
            // ctlFilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmdClearLogPath);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.cmdLogPath);
            this.Name = "ctlFilePicker";
            this.Size = new System.Drawing.Size(739, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdClearLogPath;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.VistaButton cmdLogPath;
    }
}
