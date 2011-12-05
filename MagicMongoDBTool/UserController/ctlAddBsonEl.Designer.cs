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
            this.txtElName = new QLFUI.TextBoxEx();
            this.ElBsonValue = new MagicMongoDBTool.ctlBsonValue();
            this.lblElement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtElName
            // 
            //this.txtElName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            //this.txtElName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtElName.BackColor = System.Drawing.Color.Transparent;
            this.txtElName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtElName.ForeImage = null;
            this.txtElName.Location = new System.Drawing.Point(0, -1);
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
            // ElBsonValue
            // 
            this.ElBsonValue.Location = new System.Drawing.Point(102, 0);
            this.ElBsonValue.Name = "ElBsonValue";
            this.ElBsonValue.Size = new System.Drawing.Size(218, 27);
            this.ElBsonValue.TabIndex = 3;
            this.ElBsonValue.Value = null;
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(5, 7);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(55, 13);
            this.lblElement.TabIndex = 4;
            this.lblElement.Text = "元素名称";
            // 
            // ctlAddBsonEl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblElement);
            this.Controls.Add(this.ElBsonValue);
            this.Controls.Add(this.txtElName);
            this.Name = "ctlAddBsonEl";
            this.Size = new System.Drawing.Size(326, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QLFUI.TextBoxEx txtElName;
        private ctlBsonValue ElBsonValue;
        private System.Windows.Forms.Label lblElement;
    }
}
