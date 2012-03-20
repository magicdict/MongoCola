namespace MagicMongoDBTool
{
    partial class frmGFSOption
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radFilename = new System.Windows.Forms.RadioButton();
            this.radFullPath = new System.Windows.Forms.RadioButton();
            this.radRenameIt = new System.Windows.Forms.RadioButton();
            this.radAddIt = new System.Windows.Forms.RadioButton();
            this.radSkipIt = new System.Windows.Forms.RadioButton();
            this.radOverwrite = new System.Windows.Forms.RadioButton();
            this.radStopIt = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radFullPath);
            this.groupBox1.Controls.Add(this.radFilename);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For MongoDB filename ,use";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radStopIt);
            this.groupBox2.Controls.Add(this.radOverwrite);
            this.groupBox2.Controls.Add(this.radSkipIt);
            this.groupBox2.Controls.Add(this.radAddIt);
            this.groupBox2.Controls.Add(this.radRenameIt);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "if file already exist";
            // 
            // radFilename
            // 
            this.radFilename.AutoSize = true;
            this.radFilename.Checked = true;
            this.radFilename.Location = new System.Drawing.Point(22, 27);
            this.radFilename.Name = "radFilename";
            this.radFilename.Size = new System.Drawing.Size(177, 17);
            this.radFilename.TabIndex = 0;
            this.radFilename.TabStop = true;
            this.radFilename.Text = "only the filename (eg.readme.txt)";
            this.radFilename.UseVisualStyleBackColor = true;
            // 
            // radFullPath
            // 
            this.radFullPath.AutoSize = true;
            this.radFullPath.Location = new System.Drawing.Point(22, 56);
            this.radFullPath.Name = "radFullPath";
            this.radFullPath.Size = new System.Drawing.Size(204, 17);
            this.radFullPath.TabIndex = 1;
            this.radFullPath.Text = "fullpath (eg.C:\\mongocola\\readme.txt)";
            this.radFullPath.UseVisualStyleBackColor = true;
            // 
            // radRenameIt
            // 
            this.radRenameIt.AutoSize = true;
            this.radRenameIt.Location = new System.Drawing.Point(22, 53);
            this.radRenameIt.Name = "radRenameIt";
            this.radRenameIt.Size = new System.Drawing.Size(150, 17);
            this.radRenameIt.TabIndex = 1;
            this.radRenameIt.Text = "Rename It(eg.readme1.txt)";
            this.radRenameIt.UseVisualStyleBackColor = true;
            // 
            // radAddIt
            // 
            this.radAddIt.AutoSize = true;
            this.radAddIt.Checked = true;
            this.radAddIt.Location = new System.Drawing.Point(22, 30);
            this.radAddIt.Name = "radAddIt";
            this.radAddIt.Size = new System.Drawing.Size(75, 17);
            this.radAddIt.TabIndex = 0;
            this.radAddIt.TabStop = true;
            this.radAddIt.Text = "Just Add It";
            this.radAddIt.UseVisualStyleBackColor = true;
            // 
            // radSkipIt
            // 
            this.radSkipIt.AutoSize = true;
            this.radSkipIt.Location = new System.Drawing.Point(22, 76);
            this.radSkipIt.Name = "radSkipIt";
            this.radSkipIt.Size = new System.Drawing.Size(55, 17);
            this.radSkipIt.TabIndex = 2;
            this.radSkipIt.Text = "Skip It";
            this.radSkipIt.UseVisualStyleBackColor = true;
            // 
            // radOverwrite
            // 
            this.radOverwrite.AutoSize = true;
            this.radOverwrite.Location = new System.Drawing.Point(22, 99);
            this.radOverwrite.Name = "radOverwrite";
            this.radOverwrite.Size = new System.Drawing.Size(82, 17);
            this.radOverwrite.TabIndex = 3;
            this.radOverwrite.Text = "OverWrite It";
            this.radOverwrite.UseVisualStyleBackColor = true;
            // 
            // radStopIt
            // 
            this.radStopIt.AutoSize = true;
            this.radStopIt.Location = new System.Drawing.Point(22, 122);
            this.radStopIt.Name = "radStopIt";
            this.radStopIt.Size = new System.Drawing.Size(47, 17);
            this.radStopIt.TabIndex = 4;
            this.radStopIt.Text = "Stop";
            this.radStopIt.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(108, 270);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(89, 31);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmGFSOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 313);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGFSOption";
            this.Text = "frmGFSOption";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radFullPath;
        private System.Windows.Forms.RadioButton radFilename;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radStopIt;
        private System.Windows.Forms.RadioButton radOverwrite;
        private System.Windows.Forms.RadioButton radSkipIt;
        private System.Windows.Forms.RadioButton radAddIt;
        private System.Windows.Forms.RadioButton radRenameIt;
        private System.Windows.Forms.Button cmdOK;
    }
}