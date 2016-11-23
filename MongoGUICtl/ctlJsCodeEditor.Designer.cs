using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class ctlJsCodeEditor
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
            this.cmdSaveLocal = new System.Windows.Forms.Button();
            this.cmbJsList = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdLoadLocal = new System.Windows.Forms.Button();
            this.txtEditJavaScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // cmdSaveLocal
            // 
            this.cmdSaveLocal.Location = new System.Drawing.Point(129, 30);
            this.cmdSaveLocal.Name = "cmdSaveLocal";
            this.cmdSaveLocal.Size = new System.Drawing.Size(117, 27);
            this.cmdSaveLocal.TabIndex = 23;
            this.cmdSaveLocal.Tag = "Common.SaveLocal";
            this.cmdSaveLocal.Text = "Save[Local] ";
            this.cmdSaveLocal.UseVisualStyleBackColor = true;
            this.cmdSaveLocal.Click += new System.EventHandler(this.cmdSaveLocal_Click);
            // 
            // cmbJsList
            // 
            this.cmbJsList.FormattingEnabled = true;
            this.cmbJsList.Location = new System.Drawing.Point(129, 2);
            this.cmbJsList.Name = "cmbJsList";
            this.cmbJsList.Size = new System.Drawing.Size(233, 23);
            this.cmbJsList.TabIndex = 19;
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Location = new System.Drawing.Point(9, 30);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 27);
            this.cmdSave.TabIndex = 20;
            this.cmdSave.Tag = "Common.Save";
            this.cmdSave.Text = "Save[Remote]";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(15, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 15);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Title";
            // 
            // cmdLoadLocal
            // 
            this.cmdLoadLocal.Location = new System.Drawing.Point(252, 30);
            this.cmdLoadLocal.Name = "cmdLoadLocal";
            this.cmdLoadLocal.Size = new System.Drawing.Size(117, 27);
            this.cmdLoadLocal.TabIndex = 24;
            this.cmdLoadLocal.Tag = "Common.Load";
            this.cmdLoadLocal.Text = "Load[Local]";
            this.cmdLoadLocal.UseVisualStyleBackColor = true;
            this.cmdLoadLocal.Click += new System.EventHandler(this.cmdLoadLocal_Click);
            // 
            // txtEditJavaScript
            // 
            this.txtEditJavaScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditJavaScript.IsReadOnly = false;
            this.txtEditJavaScript.Location = new System.Drawing.Point(9, 72);
            this.txtEditJavaScript.Name = "txtEditJavaScript";
            this.txtEditJavaScript.Size = new System.Drawing.Size(353, 204);
            this.txtEditJavaScript.TabIndex = 25;
            // 
            // ctlJsCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEditJavaScript);
            this.Controls.Add(this.cmdLoadLocal);
            this.Controls.Add(this.cmdSaveLocal);
            this.Controls.Add(this.cmbJsList);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctlJsCodeEditor";
            this.Size = new System.Drawing.Size(369, 276);
            this.Load += new System.EventHandler(this.ctlJsCodeEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdSaveLocal;
        private ComboBox cmbJsList;
        private Button cmdSave;
        private Label lblTitle;
        private Button cmdLoadLocal;
        private ICSharpCode.TextEditor.TextEditorControl txtEditJavaScript;
    }
}
