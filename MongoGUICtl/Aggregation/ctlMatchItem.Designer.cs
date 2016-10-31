using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    partial class CtlMatchItem
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
            this.cmbComparisonfunction = new System.Windows.Forms.ComboBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.MatchValue = new MongoGUICtl.ctlBsonValueType();
            this.SuspendLayout();
            // 
            // cmbComparisonfunction
            // 
            this.cmbComparisonfunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComparisonfunction.FormattingEnabled = true;
            this.cmbComparisonfunction.Location = new System.Drawing.Point(119, 6);
            this.cmbComparisonfunction.Name = "cmbComparisonfunction";
            this.cmbComparisonfunction.Size = new System.Drawing.Size(84, 20);
            this.cmbComparisonfunction.TabIndex = 1;
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(17, 6);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(96, 20);
            this.cmbField.TabIndex = 2;
            // 
            // MatchValue
            // 
            this.MatchValue.Location = new System.Drawing.Point(207, 3);
            this.MatchValue.Name = "MatchValue";
            this.MatchValue.Size = new System.Drawing.Size(328, 27);
            this.MatchValue.TabIndex = 3;
            // 
            // CtlMatchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MatchValue);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.cmbComparisonfunction);
            this.Name = "CtlMatchItem";
            this.Size = new System.Drawing.Size(538, 29);
            this.Load += new System.EventHandler(this.ctlMatchItem_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox cmbComparisonfunction;
        private ComboBox cmbField;
        private ctlBsonValueType MatchValue;
    }
}
