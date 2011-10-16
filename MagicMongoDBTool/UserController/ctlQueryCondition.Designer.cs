namespace MagicMongoDBTool
{
    partial class ctlQueryCondition
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbCompareOpr = new System.Windows.Forms.ComboBox();
            this.radString = new System.Windows.Forms.RadioButton();
            this.radInt = new System.Windows.Forms.RadioButton();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.radBoolean = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(12, 6);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(43, 13);
            this.lblCaption.TabIndex = 8;
            this.lblCaption.Text = "条件1：";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(244, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(179, 20);
            this.txtValue.TabIndex = 7;
            // 
            // cmbCompareOpr
            // 
            this.cmbCompareOpr.FormattingEnabled = true;
            this.cmbCompareOpr.Location = new System.Drawing.Point(82, 3);
            this.cmbCompareOpr.Name = "cmbCompareOpr";
            this.cmbCompareOpr.Size = new System.Drawing.Size(153, 21);
            this.cmbCompareOpr.TabIndex = 6;
            // 
            // radString
            // 
            this.radString.AutoSize = true;
            this.radString.Location = new System.Drawing.Point(430, 5);
            this.radString.Name = "radString";
            this.radString.Size = new System.Drawing.Size(49, 17);
            this.radString.TabIndex = 9;
            this.radString.TabStop = true;
            this.radString.Text = "文字";
            this.radString.UseVisualStyleBackColor = true;
            // 
            // radInt
            // 
            this.radInt.AutoSize = true;
            this.radInt.Location = new System.Drawing.Point(484, 5);
            this.radInt.Name = "radInt";
            this.radInt.Size = new System.Drawing.Size(49, 17);
            this.radInt.TabIndex = 10;
            this.radInt.TabStop = true;
            this.radInt.Text = "数字";
            this.radInt.UseVisualStyleBackColor = true;
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.Location = new System.Drawing.Point(539, 5);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(49, 17);
            this.radDate.TabIndex = 11;
            this.radDate.TabStop = true;
            this.radDate.Text = "日期";
            this.radDate.UseVisualStyleBackColor = true;
            // 
            // radBoolean
            // 
            this.radBoolean.AutoSize = true;
            this.radBoolean.Location = new System.Drawing.Point(603, 4);
            this.radBoolean.Name = "radBoolean";
            this.radBoolean.Size = new System.Drawing.Size(61, 17);
            this.radBoolean.TabIndex = 12;
            this.radBoolean.TabStop = true;
            this.radBoolean.Text = "布尔值";
            this.radBoolean.UseVisualStyleBackColor = true;
            // 
            // ctlQueryConditio_n
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radBoolean);
            this.Controls.Add(this.radDate);
            this.Controls.Add(this.radInt);
            this.Controls.Add(this.radString);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbCompareOpr);
            this.Name = "ctlQueryConditio_n";
            this.Size = new System.Drawing.Size(678, 30);
            this.Load += new System.EventHandler(this.ctlQueryCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cmbCompareOpr;
        private System.Windows.Forms.RadioButton radString;
        private System.Windows.Forms.RadioButton radInt;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.RadioButton radBoolean;

    }
}
