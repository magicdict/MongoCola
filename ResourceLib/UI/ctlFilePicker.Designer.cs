using System.ComponentModel;
using System.Windows.Forms;

namespace ResourceLib.UI
{
    partial class CtlFilePicker
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
            this.cmdClear = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.BackColor = System.Drawing.Color.Transparent;
            this.cmdClear.Location = new System.Drawing.Point(450, 4);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(87, 24);
            this.cmdClear.TabIndex = 10;
            this.cmdClear.Tag = "Common.Clear";
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = false;
            this.cmdClear.Click += new System.EventHandler(this.cmdClearPath_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 17);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Title";
            this.lblTitle.Resize += new System.EventHandler(this.ResizeControl);
            // 
            // txtPathName
            // 
            this.txtPathName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathName.BackColor = System.Drawing.Color.White;
            this.txtPathName.Location = new System.Drawing.Point(65, 5);
            this.txtPathName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.Size = new System.Drawing.Size(277, 23);
            this.txtPathName.TabIndex = 8;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.BackColor = System.Drawing.Color.Transparent;
            this.cmdBrowse.Location = new System.Drawing.Point(357, 4);
            this.cmdBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(87, 24);
            this.cmdBrowse.TabIndex = 7;
            this.cmdBrowse.Tag = "Common.Browse";
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = false;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // CtlFilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPathName);
            this.Controls.Add(this.cmdBrowse);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CtlFilePicker";
            this.Size = new System.Drawing.Size(540, 32);
            this.Load += new System.EventHandler(this.ctlFilePicker_Load);
            this.Resize += new System.EventHandler(this.ResizeControl);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdClear;
        private Label lblTitle;
        private TextBox txtPathName;
        private Button cmdBrowse;
    }
}
