namespace MagicMongoDBTool
{
    partial class frmNewDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewDocument));
            this.txtDocument = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.treeViewColumns1 = new TreeViewColumnsProject.TreeViewColumns();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDocument
            // 
            this.txtDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocument.Location = new System.Drawing.Point(16, 44);
            this.txtDocument.Multiline = true;
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(421, 206);
            this.txtDocument.TabIndex = 0;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(467, 276);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(104, 34);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(694, 276);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(110, 34);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // treeViewColumns1
            // 
            this.treeViewColumns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.treeViewColumns1.Location = new System.Drawing.Point(444, 13);
            this.treeViewColumns1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewColumns1.Name = "treeViewColumns1";
            this.treeViewColumns1.Padding = new System.Windows.Forms.Padding(1);
            this.treeViewColumns1.Size = new System.Drawing.Size(360, 237);
            this.treeViewColumns1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type your JSON document below";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(586, 276);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(102, 34);
            this.cmdPreview.TabIndex = 5;
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // frmNewDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 322);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewColumns1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtDocument);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewDocument";
            this.Text = "New Document";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocument;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdClose;
        private TreeViewColumnsProject.TreeViewColumns treeViewColumns1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdPreview;
    }
}