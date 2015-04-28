using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    partial class GroupItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

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
            this.cmbGroupFunction = new ComboBox();
            this.txtProject = new TextBox();
            this.cmbGroupValue = new ComboBox();
            this.SuspendLayout();
            // 
            // cmbGroupFunction
            // 
            this.cmbGroupFunction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGroupFunction.FormattingEnabled = true;
            this.cmbGroupFunction.Location = new Point(152, 5);
            this.cmbGroupFunction.Name = "cmbGroupFunction";
            this.cmbGroupFunction.Size = new Size(121, 21);
            this.cmbGroupFunction.TabIndex = 0;
            // 
            // txtProject
            // 
            this.txtProject.Location = new Point(17, 5);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new Size(129, 20);
            this.txtProject.TabIndex = 1;
            // 
            // cmbGroupValue
            // 
            this.cmbGroupValue.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGroupValue.FormattingEnabled = true;
            this.cmbGroupValue.Location = new Point(290, 5);
            this.cmbGroupValue.Name = "cmbGroupValue";
            this.cmbGroupValue.Size = new Size(121, 21);
            this.cmbGroupValue.TabIndex = 2;
            // 
            // GroupItem
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.cmbGroupValue);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.cmbGroupFunction);
            this.Name = "GroupItem";
            this.Size = new Size(439, 29);
            this.Load += new EventHandler(this.GroupItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbGroupFunction;
        private TextBox txtProject;
        private ComboBox cmbGroupValue;
    }
}
