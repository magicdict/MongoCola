using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlTextMgr
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
            this.cmdSaveLocal = new Button();
            this.cmbJsList = new ComboBox();
            this.cmdSave = new Button();
            this.lblTitle = new Label();
            this.txtContext = new TextBox();
            this.cmdLoadLocal = new Button();
            this.SuspendLayout();
            // 
            // cmdSaveLocal
            // 
            this.cmdSaveLocal.Location = new Point(129, 30);
            this.cmdSaveLocal.Name = "cmdSaveLocal";
            this.cmdSaveLocal.Size = new Size(117, 27);
            this.cmdSaveLocal.TabIndex = 23;
            this.cmdSaveLocal.Text = "Save[Local] ";
            this.cmdSaveLocal.UseVisualStyleBackColor = true;
            this.cmdSaveLocal.Click += new EventHandler(this.cmdSaveLocal_Click);
            // 
            // cmbJsList
            // 
            this.cmbJsList.FormattingEnabled = true;
            this.cmbJsList.Location = new Point(129, 2);
            this.cmbJsList.Name = "cmbJsList";
            this.cmbJsList.Size = new Size(233, 23);
            this.cmbJsList.TabIndex = 19;
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = Color.Transparent;
            this.cmdSave.Location = new Point(9, 30);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new Size(114, 29);
            this.cmdSave.TabIndex = 20;
            this.cmdSave.Text = "Save[Remote]";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new EventHandler(this.cmdSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Location = new Point(15, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(30, 15);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Title";
            // 
            // txtContext
            // 
            this.txtContext.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.txtContext.BorderStyle = BorderStyle.FixedSingle;
            this.txtContext.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.txtContext.Location = new Point(0, 60);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ScrollBars = ScrollBars.Both;
            this.txtContext.Size = new Size(392, 198);
            this.txtContext.TabIndex = 21;
            // 
            // cmdLoadLocal
            // 
            this.cmdLoadLocal.Location = new Point(252, 33);
            this.cmdLoadLocal.Name = "cmdLoadLocal";
            this.cmdLoadLocal.Size = new Size(110, 23);
            this.cmdLoadLocal.TabIndex = 24;
            this.cmdLoadLocal.Text = "Load[Local]";
            this.cmdLoadLocal.UseVisualStyleBackColor = true;
            this.cmdLoadLocal.Click += new EventHandler(this.cmdLoadLocal_Click);
            // 
            // ctlTextMgr
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.cmdLoadLocal);
            this.Controls.Add(this.cmdSaveLocal);
            this.Controls.Add(this.cmbJsList);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtContext);
            this.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CtlTextMgr";
            this.Size = new Size(399, 263);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdSaveLocal;
        private ComboBox cmbJsList;
        private Button cmdSave;
        private Label lblTitle;
        private TextBox txtContext;
        private Button cmdLoadLocal;
    }
}
