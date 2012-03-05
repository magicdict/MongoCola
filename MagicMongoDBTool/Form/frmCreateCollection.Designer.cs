namespace MagicMongoDBTool
{
    partial class frmCreateCollection
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.chkIsCapped = new System.Windows.Forms.CheckBox();
            this.chkIsAutoIndexId = new System.Windows.Forms.CheckBox();
            this.numMaxSize = new System.Windows.Forms.NumericUpDown();
            this.numMaxDocument = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.lblMaxDocument = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(76, 169);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(208, 169);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(148, 35);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(154, 20);
            this.txtCollectionName.TabIndex = 2;
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(52, 38);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(81, 13);
            this.lblCollectionName.TabIndex = 3;
            this.lblCollectionName.Text = "CollectionName";
            // 
            // chkIsCapped
            // 
            this.chkIsCapped.AutoSize = true;
            this.chkIsCapped.Location = new System.Drawing.Point(58, 78);
            this.chkIsCapped.Name = "chkIsCapped";
            this.chkIsCapped.Size = new System.Drawing.Size(71, 17);
            this.chkIsCapped.TabIndex = 4;
            this.chkIsCapped.Text = "IsCapped";
            this.chkIsCapped.UseVisualStyleBackColor = true;
            // 
            // chkIsAutoIndexId
            // 
            this.chkIsAutoIndexId.AutoSize = true;
            this.chkIsAutoIndexId.Location = new System.Drawing.Point(148, 78);
            this.chkIsAutoIndexId.Name = "chkIsAutoIndexId";
            this.chkIsAutoIndexId.Size = new System.Drawing.Size(91, 17);
            this.chkIsAutoIndexId.TabIndex = 5;
            this.chkIsAutoIndexId.Text = "IsAutoIndexId";
            this.chkIsAutoIndexId.UseVisualStyleBackColor = true;
            // 
            // numMaxSize
            // 
            this.numMaxSize.Location = new System.Drawing.Point(148, 108);
            this.numMaxSize.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxSize.Name = "numMaxSize";
            this.numMaxSize.Size = new System.Drawing.Size(120, 20);
            this.numMaxSize.TabIndex = 6;
            this.numMaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numMaxDocument
            // 
            this.numMaxDocument.Location = new System.Drawing.Point(148, 132);
            this.numMaxDocument.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxDocument.Name = "numMaxDocument";
            this.numMaxDocument.Size = new System.Drawing.Size(120, 20);
            this.numMaxDocument.TabIndex = 7;
            this.numMaxDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(55, 115);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(47, 13);
            this.lblMaxSize.TabIndex = 8;
            this.lblMaxSize.Text = "MaxSize";
            // 
            // lblMaxDocument
            // 
            this.lblMaxDocument.AutoSize = true;
            this.lblMaxDocument.Location = new System.Drawing.Point(55, 140);
            this.lblMaxDocument.Name = "lblMaxDocument";
            this.lblMaxDocument.Size = new System.Drawing.Size(76, 13);
            this.lblMaxDocument.TabIndex = 9;
            this.lblMaxDocument.Text = "MaxDocument";
            // 
            // frmCreateCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 204);
            this.Controls.Add(this.lblMaxDocument);
            this.Controls.Add(this.lblMaxSize);
            this.Controls.Add(this.numMaxDocument);
            this.Controls.Add(this.numMaxSize);
            this.Controls.Add(this.chkIsAutoIndexId);
            this.Controls.Add(this.chkIsCapped);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmCreateCollection";
            this.Text = "frmCreateCollection";
            this.Load += new System.EventHandler(this.frmCreateCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.Label lblCollectionName;
        private System.Windows.Forms.CheckBox chkIsCapped;
        private System.Windows.Forms.CheckBox chkIsAutoIndexId;
        private System.Windows.Forms.NumericUpDown numMaxSize;
        private System.Windows.Forms.NumericUpDown numMaxDocument;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.Label lblMaxDocument;
    }
}