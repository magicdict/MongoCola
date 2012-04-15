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
            this.grpFilename = new System.Windows.Forms.GroupBox();
            this.radFullPath = new System.Windows.Forms.RadioButton();
            this.radFilename = new System.Windows.Forms.RadioButton();
            this.grpFileAlreadyExist = new System.Windows.Forms.GroupBox();
            this.radStopIt = new System.Windows.Forms.RadioButton();
            this.radOverwrite = new System.Windows.Forms.RadioButton();
            this.radSkipIt = new System.Windows.Forms.RadioButton();
            this.radAddIt = new System.Windows.Forms.RadioButton();
            this.radRenameIt = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.lblSeperateChar = new System.Windows.Forms.Label();
            this.txtSeperateChar = new System.Windows.Forms.TextBox();
            this.grpFilename.SuspendLayout();
            this.grpFileAlreadyExist.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilename
            // 
            this.grpFilename.Controls.Add(this.txtSeperateChar);
            this.grpFilename.Controls.Add(this.lblSeperateChar);
            this.grpFilename.Controls.Add(this.radFullPath);
            this.grpFilename.Controls.Add(this.radFilename);
            this.grpFilename.Location = new System.Drawing.Point(12, 11);
            this.grpFilename.Name = "grpFilename";
            this.grpFilename.Size = new System.Drawing.Size(278, 101);
            this.grpFilename.TabIndex = 0;
            this.grpFilename.TabStop = false;
            this.grpFilename.Text = "For MongoDB filename ,use";
            // 
            // radFullPath
            // 
            this.radFullPath.AutoSize = true;
            this.radFullPath.Location = new System.Drawing.Point(22, 52);
            this.radFullPath.Name = "radFullPath";
            this.radFullPath.Size = new System.Drawing.Size(225, 16);
            this.radFullPath.TabIndex = 1;
            this.radFullPath.Text = "fullpath (eg.C:\\mongocola\\readme.txt)";
            this.radFullPath.UseVisualStyleBackColor = true;
            // 
            // radFilename
            // 
            this.radFilename.AutoSize = true;
            this.radFilename.Checked = true;
            this.radFilename.Location = new System.Drawing.Point(22, 25);
            this.radFilename.Name = "radFilename";
            this.radFilename.Size = new System.Drawing.Size(205, 16);
            this.radFilename.TabIndex = 0;
            this.radFilename.TabStop = true;
            this.radFilename.Text = "only the filename (eg.readme.txt)";
            this.radFilename.UseVisualStyleBackColor = true;
            // 
            // grpFileAlreadyExist
            // 
            this.grpFileAlreadyExist.Controls.Add(this.radStopIt);
            this.grpFileAlreadyExist.Controls.Add(this.radOverwrite);
            this.grpFileAlreadyExist.Controls.Add(this.radSkipIt);
            this.grpFileAlreadyExist.Controls.Add(this.radAddIt);
            this.grpFileAlreadyExist.Controls.Add(this.radRenameIt);
            this.grpFileAlreadyExist.Location = new System.Drawing.Point(12, 118);
            this.grpFileAlreadyExist.Name = "grpFileAlreadyExist";
            this.grpFileAlreadyExist.Size = new System.Drawing.Size(278, 135);
            this.grpFileAlreadyExist.TabIndex = 1;
            this.grpFileAlreadyExist.TabStop = false;
            this.grpFileAlreadyExist.Text = "if file already exist";
            // 
            // radStopIt
            // 
            this.radStopIt.AutoSize = true;
            this.radStopIt.Location = new System.Drawing.Point(22, 113);
            this.radStopIt.Name = "radStopIt";
            this.radStopIt.Size = new System.Drawing.Size(47, 16);
            this.radStopIt.TabIndex = 4;
            this.radStopIt.Text = "Stop";
            this.radStopIt.UseVisualStyleBackColor = true;
            // 
            // radOverwrite
            // 
            this.radOverwrite.AutoSize = true;
            this.radOverwrite.Location = new System.Drawing.Point(22, 91);
            this.radOverwrite.Name = "radOverwrite";
            this.radOverwrite.Size = new System.Drawing.Size(87, 16);
            this.radOverwrite.TabIndex = 3;
            this.radOverwrite.Text = "OverWrite It";
            this.radOverwrite.UseVisualStyleBackColor = true;
            // 
            // radSkipIt
            // 
            this.radSkipIt.AutoSize = true;
            this.radSkipIt.Location = new System.Drawing.Point(22, 70);
            this.radSkipIt.Name = "radSkipIt";
            this.radSkipIt.Size = new System.Drawing.Size(58, 16);
            this.radSkipIt.TabIndex = 2;
            this.radSkipIt.Text = "Skip It";
            this.radSkipIt.UseVisualStyleBackColor = true;
            // 
            // radAddIt
            // 
            this.radAddIt.AutoSize = true;
            this.radAddIt.Checked = true;
            this.radAddIt.Location = new System.Drawing.Point(22, 28);
            this.radAddIt.Name = "radAddIt";
            this.radAddIt.Size = new System.Drawing.Size(83, 16);
            this.radAddIt.TabIndex = 0;
            this.radAddIt.TabStop = true;
            this.radAddIt.Text = "Just Add It";
            this.radAddIt.UseVisualStyleBackColor = true;
            // 
            // radRenameIt
            // 
            this.radRenameIt.AutoSize = true;
            this.radRenameIt.Location = new System.Drawing.Point(22, 49);
            this.radRenameIt.Name = "radRenameIt";
            this.radRenameIt.Size = new System.Drawing.Size(162, 16);
            this.radRenameIt.TabIndex = 1;
            this.radRenameIt.Text = "Rename It(eg.readme1.txt)";
            this.radRenameIt.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(104, 286);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(89, 29);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Location = new System.Drawing.Point(16, 265);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(319, 16);
            this.chkIgnore.TabIndex = 3;
            this.chkIgnore.Text = "add files form selected folder only(ignore sub-folder)";
            this.chkIgnore.UseVisualStyleBackColor = true;
            // 
            // lblSeperateChar
            // 
            this.lblSeperateChar.AutoSize = true;
            this.lblSeperateChar.Location = new System.Drawing.Point(24, 76);
            this.lblSeperateChar.Name = "lblSeperateChar";
            this.lblSeperateChar.Size = new System.Drawing.Size(76, 12);
            this.lblSeperateChar.TabIndex = 4;
            this.lblSeperateChar.Text = "SeperateChar:";
            // 
            // txtSeperateChar
            // 
            this.txtSeperateChar.Location = new System.Drawing.Point(106, 73);
            this.txtSeperateChar.Name = "txtSeperateChar";
            this.txtSeperateChar.Size = new System.Drawing.Size(57, 21);
            this.txtSeperateChar.TabIndex = 5;
            this.txtSeperateChar.Text = "\\";
            // 
            // frmGFSOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 318);
            this.Controls.Add(this.chkIgnore);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpFileAlreadyExist);
            this.Controls.Add(this.grpFilename);
            this.Name = "frmGFSOption";
            this.Text = "GFS Insert Option";
            this.Load += new System.EventHandler(this.frmGFSOption_Load);
            this.grpFilename.ResumeLayout(false);
            this.grpFilename.PerformLayout();
            this.grpFileAlreadyExist.ResumeLayout(false);
            this.grpFileAlreadyExist.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilename;
        private System.Windows.Forms.RadioButton radFullPath;
        private System.Windows.Forms.RadioButton radFilename;
        private System.Windows.Forms.GroupBox grpFileAlreadyExist;
        private System.Windows.Forms.RadioButton radStopIt;
        private System.Windows.Forms.RadioButton radOverwrite;
        private System.Windows.Forms.RadioButton radSkipIt;
        private System.Windows.Forms.RadioButton radAddIt;
        private System.Windows.Forms.RadioButton radRenameIt;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkIgnore;
        private System.Windows.Forms.TextBox txtSeperateChar;
        private System.Windows.Forms.Label lblSeperateChar;
    }
}