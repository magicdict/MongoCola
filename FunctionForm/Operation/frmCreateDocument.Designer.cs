using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Operation
{
    partial class frmCreateDocument
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.trvNewDocument = new MongoGUICtl.CtlTreeViewColumns();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.cmdSaveAggregate = new System.Windows.Forms.Button();
            this.txtDocument = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(735, 333);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 33);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(838, 333);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(96, 33);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Tag = "Common.Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // trvNewDocument
            // 
            this.trvNewDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvNewDocument.Location = new System.Drawing.Point(503, 12);
            this.trvNewDocument.Margin = new System.Windows.Forms.Padding(4);
            this.trvNewDocument.Name = "trvNewDocument";
            this.trvNewDocument.Padding = new System.Windows.Forms.Padding(1);
            this.trvNewDocument.Size = new System.Drawing.Size(477, 298);
            this.trvNewDocument.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type your JSON document below";
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(634, 333);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(96, 33);
            this.cmdPreview.TabIndex = 4;
            this.cmdPreview.Tag = "Common.Preview";
            this.cmdPreview.Text = "Preview";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // cmdSaveAggregate
            // 
            this.cmdSaveAggregate.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveAggregate.Location = new System.Drawing.Point(528, 333);
            this.cmdSaveAggregate.Name = "cmdSaveAggregate";
            this.cmdSaveAggregate.Size = new System.Drawing.Size(96, 33);
            this.cmdSaveAggregate.TabIndex = 3;
            this.cmdSaveAggregate.Tag = "Common.Save";
            this.cmdSaveAggregate.Text = "Save";
            this.cmdSaveAggregate.UseVisualStyleBackColor = false;
            this.cmdSaveAggregate.Click += new System.EventHandler(this.cmdSaveDocument_Click);
            // 
            // txtDocument
            // 
            this.txtDocument.AutoScroll = true;
            this.txtDocument.IsReadOnly = false;
            this.txtDocument.Location = new System.Drawing.Point(14, 42);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(464, 268);
            this.txtDocument.TabIndex = 1;
            // 
            // frmCreateDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 378);
            this.Controls.Add(this.txtDocument);
            this.Controls.Add(this.cmdSaveAggregate);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trvNewDocument);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCreateDocument";
            this.Tag = "Create_New_Document";
            this.Text = "New Document";
            this.Load += new System.EventHandler(this.frmNewDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cmdOK;
        private Button cmdClose;
        private CtlTreeViewColumns trvNewDocument;
        private Label label1;
        private Button cmdPreview;
        private Button cmdSaveAggregate;
        private ICSharpCode.TextEditor.TextEditorControl txtDocument;
    }
}