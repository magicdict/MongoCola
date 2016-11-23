using System.ComponentModel;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace MongoGUIView
{
    partial class CtlJsEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlJsEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditDocStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveStripButton = new System.Windows.Forms.ToolStripButton();
            this.CloseStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupEvalJavaScript = new System.Windows.Forms.GroupBox();
            this.txtEvalJavaScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butEval = new System.Windows.Forms.Button();
            this.butOpenFile = new System.Windows.Forms.Button();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupEditJavaScript = new System.Windows.Forms.GroupBox();
            this.txtEditJavaScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1.SuspendLayout();
            this.groupEvalJavaScript.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupEditJavaScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditDocStripButton,
            this.SaveStripButton,
            this.CloseStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(696, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditDocStripButton
            // 
            this.EditDocStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditDocStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditDocStripButton.Image")));
            this.EditDocStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditDocStripButton.Name = "EditDocStripButton";
            this.EditDocStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditDocStripButton.Tag = "Common.Edit";
            this.EditDocStripButton.Text = "Editor";
            this.EditDocStripButton.Click += new System.EventHandler(this.EditDocStripButton_Click);
            // 
            // SaveStripButton
            // 
            this.SaveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveStripButton.Image")));
            this.SaveStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveStripButton.Name = "SaveStripButton";
            this.SaveStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveStripButton.Tag = "Common.Save";
            this.SaveStripButton.Text = "Save";
            this.SaveStripButton.Click += new System.EventHandler(this.SaveStripButton_Click);
            // 
            // CloseStripButton
            // 
            this.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseStripButton.Image")));
            this.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseStripButton.Name = "CloseStripButton";
            this.CloseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CloseStripButton.Tag = "Common.Close";
            this.CloseStripButton.Text = "Close";
            this.CloseStripButton.Click += new System.EventHandler(this.CloseStripButton_Click);
            // 
            // groupEvalJavaScript
            // 
            this.groupEvalJavaScript.Controls.Add(this.txtEvalJavaScript);
            this.groupEvalJavaScript.Controls.Add(this.panel1);
            this.groupEvalJavaScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEvalJavaScript.Location = new System.Drawing.Point(0, 210);
            this.groupEvalJavaScript.Name = "groupEvalJavaScript";
            this.groupEvalJavaScript.Size = new System.Drawing.Size(696, 147);
            this.groupEvalJavaScript.TabIndex = 3;
            this.groupEvalJavaScript.TabStop = false;
            this.groupEvalJavaScript.Text = "执行Javascript";
            // 
            // txtEvalJavaScript
            // 
            this.txtEvalJavaScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEvalJavaScript.Location = new System.Drawing.Point(3, 83);
            this.txtEvalJavaScript.Name = "txtEvalJavaScript";
            this.txtEvalJavaScript.Size = new System.Drawing.Size(690, 61);
            this.txtEvalJavaScript.TabIndex = 3;
            this.txtEvalJavaScript.Text = "";
            this.txtEvalJavaScript.Encoding = System.Text.Encoding.Default;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butEval);
            this.panel1.Controls.Add(this.butOpenFile);
            this.panel1.Controls.Add(this.txtParameter);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 66);
            this.panel1.TabIndex = 2;
            // 
            // butEval
            // 
            this.butEval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEval.Location = new System.Drawing.Point(647, 31);
            this.butEval.Name = "butEval";
            this.butEval.Size = new System.Drawing.Size(40, 23);
            this.butEval.TabIndex = 6;
            this.butEval.Text = "执行";
            this.butEval.UseVisualStyleBackColor = true;
            this.butEval.Click += new System.EventHandler(this.butEval_Click);
            // 
            // butOpenFile
            // 
            this.butOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpenFile.Location = new System.Drawing.Point(647, 6);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(40, 23);
            this.butOpenFile.TabIndex = 5;
            this.butOpenFile.Text = "文件";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // txtParameter
            // 
            this.txtParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameter.Location = new System.Drawing.Point(68, 33);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(550, 21);
            this.txtParameter.TabIndex = 4;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(68, 6);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(550, 21);
            this.txtFile.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "\")";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "db.Eval(\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径:";
            // 
            // groupEditJavaScript
            // 
            this.groupEditJavaScript.Controls.Add(this.txtEditJavaScript);
            this.groupEditJavaScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupEditJavaScript.Location = new System.Drawing.Point(0, 25);
            this.groupEditJavaScript.Name = "groupEditJavaScript";
            this.groupEditJavaScript.Size = new System.Drawing.Size(696, 185);
            this.groupEditJavaScript.TabIndex = 4;
            this.groupEditJavaScript.TabStop = false;
            this.groupEditJavaScript.Text = "编辑Javascript";
            // 
            // txtEditJavaScript
            // 
            this.txtEditJavaScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditJavaScript.IsReadOnly = false;
            this.txtEditJavaScript.Location = new System.Drawing.Point(3, 17);
            this.txtEditJavaScript.Name = "txtEditJavaScript";
            this.txtEditJavaScript.Size = new System.Drawing.Size(690, 165);
            this.txtEditJavaScript.TabIndex = 0;
            this.txtEditJavaScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtlJsEditor_KeyDown);
            this.txtEditJavaScript.Encoding = System.Text.Encoding.Default;
            // 
            // CtlJsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupEvalJavaScript);
            this.Controls.Add(this.groupEditJavaScript);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtlJsEditor";
            this.Size = new System.Drawing.Size(696, 357);
            this.Load += new System.EventHandler(this.JsEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtlJsEditor_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CtlJsEditor_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupEvalJavaScript.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupEditJavaScript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton CloseStripButton;
        private ToolStripButton SaveStripButton;
        private ToolStripButton EditDocStripButton;
        private GroupBox groupEvalJavaScript;
        private GroupBox groupEditJavaScript;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtFile;
        private TextBox txtParameter;
        private Button butOpenFile;
        private Button butEval;
        private TextEditorControl txtEvalJavaScript;
        private TextEditorControl txtEditJavaScript;
    }
}
