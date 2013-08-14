namespace MagicMongoDBTool
{
    partial class frmValidate
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
            this.trvResult = new TreeViewColumnsProject.TreeViewColumns();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvResult.Location = new System.Drawing.Point(9, 49);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(487, 290);
            this.trvResult.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(350, 358);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(114, 27);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(398, 20);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(75, 23);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.Text = "Validate";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(323, 24);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(42, 17);
            this.chkFull.TabIndex = 3;
            this.chkFull.Text = "Full";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(230, 358);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(105, 27);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(508, 412);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.chkFull);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.trvResult);
            this.Name = "frmValidate";
            this.Text = "Validate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewColumnsProject.TreeViewColumns trvResult;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.CheckBox chkFull;
        private System.Windows.Forms.Button cmdSave;
    }
}