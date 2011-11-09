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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbCompareOpr = new System.Windows.Forms.ComboBox();
            this.cmbColName = new System.Windows.Forms.ComboBox();
            this.cmbEndMark = new System.Windows.Forms.ComboBox();
            this.cmbStartMark = new System.Windows.Forms.ComboBox();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(202, 1);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(120, 20);
            this.txtValue.TabIndex = 3;
            // 
            // cmbCompareOpr
            // 
            this.cmbCompareOpr.FormattingEnabled = true;
            this.cmbCompareOpr.Location = new System.Drawing.Point(142, 1);
            this.cmbCompareOpr.Name = "cmbCompareOpr";
            this.cmbCompareOpr.Size = new System.Drawing.Size(54, 21);
            this.cmbCompareOpr.TabIndex = 2;
            // 
            // cmbColName
            // 
            this.cmbColName.FormattingEnabled = true;
            this.cmbColName.Location = new System.Drawing.Point(45, 1);
            this.cmbColName.Name = "cmbColName";
            this.cmbColName.Size = new System.Drawing.Size(91, 21);
            this.cmbColName.TabIndex = 1;
            // 
            // cmbEndMark
            // 
            this.cmbEndMark.FormattingEnabled = true;
            this.cmbEndMark.Location = new System.Drawing.Point(399, 0);
            this.cmbEndMark.Name = "cmbEndMark";
            this.cmbEndMark.Size = new System.Drawing.Size(45, 21);
            this.cmbEndMark.TabIndex = 5;
            // 
            // cmbStartMark
            // 
            this.cmbStartMark.FormattingEnabled = true;
            this.cmbStartMark.Location = new System.Drawing.Point(2, 1);
            this.cmbStartMark.Name = "cmbStartMark";
            this.cmbStartMark.Size = new System.Drawing.Size(39, 21);
            this.cmbStartMark.TabIndex = 0;
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(328, 1);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(65, 21);
            this.cmbDataType.TabIndex = 4;
            // 
            // ctlQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.cmbStartMark);
            this.Controls.Add(this.cmbEndMark);
            this.Controls.Add(this.cmbColName);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbCompareOpr);
            this.Name = "ctlQueryCondition";
            this.Size = new System.Drawing.Size(454, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cmbCompareOpr;
        private System.Windows.Forms.ComboBox cmbColName;
        private System.Windows.Forms.ComboBox cmbEndMark;
        private System.Windows.Forms.ComboBox cmbStartMark;
        private System.Windows.Forms.ComboBox cmbDataType;

    }
}
