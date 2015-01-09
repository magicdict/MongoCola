namespace MongoGUICtl
{
    partial class ctlMatchItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MatchValue = new ctlBsonValue();
            this.cmbComparisonfunction = new System.Windows.Forms.ComboBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ctlBsonValue1
            // 
            this.MatchValue.Location = new System.Drawing.Point(281, 3);
            this.MatchValue.Name = "ctlBsonValue1";
            this.MatchValue.Size = new System.Drawing.Size(211, 28);
            this.MatchValue.TabIndex = 0;
            // 
            // cmbGroupfunction
            // 
            this.cmbComparisonfunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComparisonfunction.FormattingEnabled = true;
            this.cmbComparisonfunction.Location = new System.Drawing.Point(154, 6);
            this.cmbComparisonfunction.Name = "cmbGroupfunction";
            this.cmbComparisonfunction.Size = new System.Drawing.Size(121, 21);
            this.cmbComparisonfunction.TabIndex = 1;
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(17, 6);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(121, 21);
            this.cmbField.TabIndex = 2;
            // 
            // ctlMatchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.cmbComparisonfunction);
            this.Controls.Add(this.MatchValue);
            this.Name = "ctlMatchItem";
            this.Size = new System.Drawing.Size(496, 31);
            this.Load += new System.EventHandler(this.ctlMatchItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlBsonValue MatchValue;
        private System.Windows.Forms.ComboBox cmbComparisonfunction;
        private System.Windows.Forms.ComboBox cmbField;
    }
}
