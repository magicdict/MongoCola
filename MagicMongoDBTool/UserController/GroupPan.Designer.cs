namespace MagicMongoDBTool
{
    partial class GroupPan
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
            this.groupItem1 = new MagicMongoDBTool.GroupItem();
            this.SuspendLayout();
            // 
            // groupItem1
            // 
            this.groupItem1.Location = new System.Drawing.Point(25, 3);
            this.groupItem1.Name = "groupItem1";
            this.groupItem1.Size = new System.Drawing.Size(439, 29);
            this.groupItem1.TabIndex = 0;
            // 
            // GroupPan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupItem1);
            this.Name = "GroupPan";
            this.Size = new System.Drawing.Size(524, 134);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupItem groupItem1;
    }
}
