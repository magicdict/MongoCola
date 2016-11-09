using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    partial class ctlMatchPanel
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
            this.btnClearMatch = new System.Windows.Forms.Button();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClearMatch
            // 
            this.btnClearMatch.Location = new System.Drawing.Point(570, 4);
            this.btnClearMatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearMatch.Name = "btnClearMatch";
            this.btnClearMatch.Size = new System.Drawing.Size(87, 30);
            this.btnClearMatch.TabIndex = 3;
            this.btnClearMatch.Text = "Clear";
            this.btnClearMatch.UseVisualStyleBackColor = true;
            this.btnClearMatch.Click += new System.EventHandler(this.btnClearMatch_Click);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Location = new System.Drawing.Point(476, 4);
            this.btnAddMatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(87, 30);
            this.btnAddMatch.TabIndex = 2;
            this.btnAddMatch.Text = "Add";
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // ctlMatchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnClearMatch);
            this.Controls.Add(this.btnAddMatch);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ctlMatchPanel";
            this.Size = new System.Drawing.Size(658, 455);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnClearMatch;
        private Button btnAddMatch;
    }
}
