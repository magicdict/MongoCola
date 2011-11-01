namespace QLFUI
{
    partial class BaseButton
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
            this.SuspendLayout();
            // 
            // BaseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "BaseButton";
            this.Size = new System.Drawing.Size(164, 141);
            this.MouseLeave += new System.EventHandler(this.buttonControl_MouseLeave);
            this.Click += new System.EventHandler(this.buttonControl_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BaseButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.BaseButton_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
