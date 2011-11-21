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
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.txtElName = new QLFUI.TextBoxEx();
            this.txtElValue = new QLFUI.TextBoxEx();
            this.SuspendLayout();
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(215, 4);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(147, 21);
            this.cmbDataType.TabIndex = 1;
            // 
            // txtElName
            // 
            this.txtElName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtElName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtElName.BackColor = System.Drawing.Color.Transparent;
            this.txtElName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtElName.ForeImage = null;
            this.txtElName.Location = new System.Drawing.Point(0, 0);
            this.txtElName.Multiline = false;
            this.txtElName.Name = "txtElName";
            this.txtElName.Radius = 3;
            this.txtElName.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtElName.Size = new System.Drawing.Size(105, 29);
            this.txtElName.TabIndex = 2;
            this.txtElName.UseSystemPasswordChar = false;
            this.txtElName.WaterMark = "元素名称";
            this.txtElName.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // txtElValue
            // 
            this.txtElValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtElValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtElValue.BackColor = System.Drawing.Color.Transparent;
            this.txtElValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtElValue.ForeImage = null;
            this.txtElValue.Location = new System.Drawing.Point(104, -1);
            this.txtElValue.Multiline = false;
            this.txtElValue.Name = "txtElValue";
            this.txtElValue.Radius = 3;
            this.txtElValue.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtElValue.Size = new System.Drawing.Size(105, 29);
            this.txtElValue.TabIndex = 3;
            this.txtElValue.UseSystemPasswordChar = false;
            this.txtElValue.WaterMark = "元素值";
            this.txtElValue.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // ctlAddBsonEl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtElValue);
            this.Controls.Add(this.txtElName);
            this.Controls.Add(this.cmbDataType);
            this.Name = "ctlAddBsonEl";
            this.Size = new System.Drawing.Size(362, 30);
            this.Load += new System.EventHandler(this.ctlAddBsonEl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDataType;
        private QLFUI.TextBoxEx txtElName;
        private QLFUI.TextBoxEx txtElValue;
    }
}
