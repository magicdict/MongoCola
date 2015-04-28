using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    partial class FieldPicker
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
            this.btnSelectAll = new Button();
            this.btnUnSelectAll = new Button();
            this.SuspendLayout();
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new Point(37, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(75, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Location = new Point(118, 3);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new Size(75, 23);
            this.btnUnSelectAll.TabIndex = 1;
            this.btnUnSelectAll.Text = "UnSelect All";
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new EventHandler(this.btnUnSelectAll_Click);
            // 
            // FieldPicker
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Name = "FieldPicker";
            this.Size = new Size(552, 375);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSelectAll;
        private Button btnUnSelectAll;
    }
}
