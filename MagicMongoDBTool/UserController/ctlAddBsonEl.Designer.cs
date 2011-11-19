namespace MagicMongoDBTool
{
    partial class ctlAddBsonEl
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
            this.txtElName = new System.Windows.Forms.TextBox();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.txtElValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtElName
            // 
            this.txtElName.Location = new System.Drawing.Point(3, 4);
            this.txtElName.Name = "txtElName";
            this.txtElName.Size = new System.Drawing.Size(100, 20);
            this.txtElName.TabIndex = 0;
            this.txtElName.Text = "[Name]";
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(215, 3);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(147, 21);
            this.cmbDataType.TabIndex = 1;
            // 
            // txtElValue
            // 
            this.txtElValue.Location = new System.Drawing.Point(109, 4);
            this.txtElValue.Name = "txtElValue";
            this.txtElValue.Size = new System.Drawing.Size(100, 20);
            this.txtElValue.TabIndex = 0;
            this.txtElValue.Text = "[value]";
            // 
            // ctlAddBsonEl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.txtElValue);
            this.Controls.Add(this.txtElName);
            this.Name = "ctlAddBsonEl";
            this.Size = new System.Drawing.Size(362, 30);
            this.Load += new System.EventHandler(this.ctlAddBsonEl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtElName;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.TextBox txtElValue;
    }
}
