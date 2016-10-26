using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlIndexCreate
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
            this.lblKeyName = new System.Windows.Forms.Label();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.cmbIndexKeyType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblKeyName
            // 
            this.lblKeyName.AutoSize = true;
            this.lblKeyName.Location = new System.Drawing.Point(8, 6);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(65, 12);
            this.lblKeyName.TabIndex = 3;
            this.lblKeyName.Tag = "ctlIndexCreate_Index";
            this.lblKeyName.Text = "IndexFiled";
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(82, 2);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(213, 20);
            this.cmbKeyName.TabIndex = 6;
            // 
            // cmbIndexKeyType
            // 
            this.cmbIndexKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIndexKeyType.FormattingEnabled = true;
            this.cmbIndexKeyType.Location = new System.Drawing.Point(310, 3);
            this.cmbIndexKeyType.Name = "cmbIndexKeyType";
            this.cmbIndexKeyType.Size = new System.Drawing.Size(150, 20);
            this.cmbIndexKeyType.TabIndex = 7;
            // 
            // CtlIndexCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbIndexKeyType);
            this.Controls.Add(this.cmbKeyName);
            this.Controls.Add(this.lblKeyName);
            this.Name = "CtlIndexCreate";
            this.Size = new System.Drawing.Size(524, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblKeyName;
        private ComboBox cmbKeyName;
        private ComboBox cmbIndexKeyType;
    }
}
