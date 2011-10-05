namespace MagicMongoDBTool
{
    partial class frmOption
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
            this.lblMongoBinPath = new System.Windows.Forms.Label();
            this.txtMongoBinPath = new System.Windows.Forms.TextBox();
            this.cmdMongoBinPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMongoBinPath
            // 
            this.lblMongoBinPath.AutoSize = true;
            this.lblMongoBinPath.Location = new System.Drawing.Point(66, 35);
            this.lblMongoBinPath.Name = "lblMongoBinPath";
            this.lblMongoBinPath.Size = new System.Drawing.Size(124, 13);
            this.lblMongoBinPath.TabIndex = 0;
            this.lblMongoBinPath.Text = "Mongo可执行文件目录";
            // 
            // txtMongoBinPath
            // 
            this.txtMongoBinPath.Location = new System.Drawing.Point(205, 28);
            this.txtMongoBinPath.Name = "txtMongoBinPath";
            this.txtMongoBinPath.ReadOnly = true;
            this.txtMongoBinPath.Size = new System.Drawing.Size(386, 20);
            this.txtMongoBinPath.TabIndex = 1;
            // 
            // cmdMongoBinPath
            // 
            this.cmdMongoBinPath.Location = new System.Drawing.Point(597, 25);
            this.cmdMongoBinPath.Name = "cmdMongoBinPath";
            this.cmdMongoBinPath.Size = new System.Drawing.Size(75, 23);
            this.cmdMongoBinPath.TabIndex = 2;
            this.cmdMongoBinPath.Text = "浏览...";
            this.cmdMongoBinPath.UseVisualStyleBackColor = true;
            this.cmdMongoBinPath.Click += new System.EventHandler(this.cmdMongoBinPath_Click);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 273);
            this.Controls.Add(this.cmdMongoBinPath);
            this.Controls.Add(this.txtMongoBinPath);
            this.Controls.Add(this.lblMongoBinPath);
            this.Name = "frmOption";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMongoBinPath;
        private System.Windows.Forms.TextBox txtMongoBinPath;
        private System.Windows.Forms.Button cmdMongoBinPath;
    }
}