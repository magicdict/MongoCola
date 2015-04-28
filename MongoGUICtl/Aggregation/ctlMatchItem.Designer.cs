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
            this.MatchValue = new CtlBsonValue();
            this.cmbComparisonfunction = new ComboBox();
            this.cmbField = new ComboBox();
            this.SuspendLayout();
            // 
            // ctlBsonValue1
            // 
            this.MatchValue.Location = new Point(281, 3);
            this.MatchValue.Name = "ctlBsonValue1";
            this.MatchValue.Size = new Size(211, 28);
            this.MatchValue.TabIndex = 0;
            // 
            // cmbGroupfunction
            // 
            this.cmbComparisonfunction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbComparisonfunction.FormattingEnabled = true;
            this.cmbComparisonfunction.Location = new Point(154, 6);
            this.cmbComparisonfunction.Name = "cmbGroupfunction";
            this.cmbComparisonfunction.Size = new Size(121, 21);
            this.cmbComparisonfunction.TabIndex = 1;
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new Point(17, 6);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new Size(121, 21);
            this.cmbField.TabIndex = 2;
            // 
            // ctlMatchItem
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.cmbComparisonfunction);
            this.Controls.Add(this.MatchValue);
            this.Name = "CtlMatchItem";
            this.Size = new Size(496, 31);
            this.Load += new EventHandler(this.ctlMatchItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtlBsonValue MatchValue;
        private ComboBox cmbComparisonfunction;
        private ComboBox cmbField;
    }
}
