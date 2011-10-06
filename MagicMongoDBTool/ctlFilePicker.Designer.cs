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
            this.cmdClearLogPath = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.cmdLogPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClearLogPath
            // 
            this.cmdClearLogPath.Location = new System.Drawing.Point(649, 2);
            this.cmdClearLogPath.Name = "cmdClearLogPath";
            this.cmdClearLogPath.Size = new System.Drawing.Size(75, 23);
            this.cmdClearLogPath.TabIndex = 10;
            this.cmdClearLogPath.Text = "清除";
            this.cmdClearLogPath.UseVisualStyleBackColor = true;
            this.cmdClearLogPath.Click += new System.EventHandler(this.cmdClearLogPath_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "日志路径";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(74, 2);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(485, 20);
            this.txtLogPath.TabIndex = 8;
            // 
            // cmdLogPath
            // 
            this.cmdLogPath.Location = new System.Drawing.Point(565, 2);
            this.cmdLogPath.Name = "cmdLogPath";
            this.cmdLogPath.Size = new System.Drawing.Size(75, 23);
            this.cmdLogPath.TabIndex = 7;
            this.cmdLogPath.Text = "浏览...";
            this.cmdLogPath.UseVisualStyleBackColor = true;
            this.cmdLogPath.Click += new System.EventHandler(this.cmdLogPath_Click);
            // 
            // ctlFilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClearLogPath);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.cmdLogPath);
            this.Name = "ctlFilePicker";
            this.Size = new System.Drawing.Size(739, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClearLogPath;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Button cmdLogPath;
    }
}
