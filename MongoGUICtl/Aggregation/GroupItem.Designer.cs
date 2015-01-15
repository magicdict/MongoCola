namespace MongoGUICtl.Aggregation
{
    partial class GroupItem
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
            this.cmbGroupFunction = new System.Windows.Forms.ComboBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.cmbGroupValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbGroupFunction
            // 
            this.cmbGroupFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupFunction.FormattingEnabled = true;
            this.cmbGroupFunction.Location = new System.Drawing.Point(152, 5);
            this.cmbGroupFunction.Name = "cmbGroupFunction";
            this.cmbGroupFunction.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupFunction.TabIndex = 0;
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(17, 5);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(129, 20);
            this.txtProject.TabIndex = 1;
            // 
            // cmbGroupValue
            // 
            this.cmbGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupValue.FormattingEnabled = true;
            this.cmbGroupValue.Location = new System.Drawing.Point(290, 5);
            this.cmbGroupValue.Name = "cmbGroupValue";
            this.cmbGroupValue.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupValue.TabIndex = 2;
            // 
            // GroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbGroupValue);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.cmbGroupFunction);
            this.Name = "GroupItem";
            this.Size = new System.Drawing.Size(439, 29);
            this.Load += new System.EventHandler(this.GroupItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbGroupFunction;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.ComboBox cmbGroupValue;
    }
}
