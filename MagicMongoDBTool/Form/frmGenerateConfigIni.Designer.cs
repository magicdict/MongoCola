namespace MagicMongoDBTool
{
    partial class frmGenerateConfigIni
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
            this.ctlGenerateMongod = new MagicMongoDBTool.ctlMongod();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlGenerateMongod
            // 
            this.ctlGenerateMongod.BackColor = System.Drawing.Color.Transparent;
            this.ctlGenerateMongod.Location = new System.Drawing.Point(0, 0);
            this.ctlGenerateMongod.Name = "ctlGenerateMongod";
            this.ctlGenerateMongod.Size = new System.Drawing.Size(767, 194);
            this.ctlGenerateMongod.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(148, 191);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 29);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Config INI File";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(362, 192);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGenerateConfigIni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 232);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.ctlGenerateMongod);
            this.Name = "frmGenerateConfigIni";
            this.Text = "Generate Config ";
            this.ResumeLayout(false);

        }

        #endregion

        private ctlMongod ctlGenerateMongod;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
    }
}