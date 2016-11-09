namespace MongoGUICtl.Aggregation
{
    partial class ctlSortItem
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbField
            // 
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(7, 8);
            this.cmbField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(299, 25);
            this.cmbField.TabIndex = 0;
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(312, 8);
            this.cmbSort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(137, 25);
            this.cmbSort.TabIndex = 8;
            // 
            // ctlSortItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbField);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ctlSortItem";
            this.Size = new System.Drawing.Size(471, 36);
            this.Load += new System.EventHandler(this.ctlSortItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbSort;
    }
}
