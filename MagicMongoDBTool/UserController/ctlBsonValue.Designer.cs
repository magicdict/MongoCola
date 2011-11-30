namespace MagicMongoDBTool
{
    partial class ctlBsonValue
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
            this.txtBsonValue = new QLFUI.TextBoxEx();
            this.SuspendLayout();
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(107, 4);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(97, 21);
            this.cmbDataType.TabIndex = 4;
            // 
            // txtBsonValue
            // 
            this.txtBsonValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBsonValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBsonValue.BackColor = System.Drawing.Color.Transparent;
            this.txtBsonValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtBsonValue.ForeImage = null;
            this.txtBsonValue.Location = new System.Drawing.Point(0, -1);
            this.txtBsonValue.Multiline = false;
            this.txtBsonValue.Name = "txtBsonValue";
            this.txtBsonValue.Radius = 3;
            this.txtBsonValue.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtBsonValue.Size = new System.Drawing.Size(105, 29);
            this.txtBsonValue.TabIndex = 5;
            this.txtBsonValue.UseSystemPasswordChar = false;
            this.txtBsonValue.WaterMark = "元素值";
            this.txtBsonValue.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // ctlBsonValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBsonValue);
            this.Controls.Add(this.cmbDataType);
            this.Name = "ctlBsonValue";
            this.Size = new System.Drawing.Size(211, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private QLFUI.TextBoxEx txtBsonValue;
        private System.Windows.Forms.ComboBox cmbDataType;

    }
}
