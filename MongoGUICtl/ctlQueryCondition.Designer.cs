using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlQueryCondition
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
            this.cmbCompareOpr = new System.Windows.Forms.ComboBox();
            this.cmbColName = new System.Windows.Forms.ComboBox();
            this.cmbEndMark = new System.Windows.Forms.ComboBox();
            this.cmbStartMark = new System.Windows.Forms.ComboBox();
            this.ElBsonValue = new CtlBsonValue();
            this.SuspendLayout();
            // 
            // cmbCompareOpr
            // 
            this.cmbCompareOpr.FormattingEnabled = true;
            this.cmbCompareOpr.Location = new System.Drawing.Point(142, 1);
            this.cmbCompareOpr.Name = "cmbCompareOpr";
            this.cmbCompareOpr.Size = new System.Drawing.Size(54, 21);
            this.cmbCompareOpr.TabIndex = 2;
            // 
            // cmbColName
            // 
            this.cmbColName.FormattingEnabled = true;
            this.cmbColName.Location = new System.Drawing.Point(45, 1);
            this.cmbColName.Name = "cmbColName";
            this.cmbColName.Size = new System.Drawing.Size(91, 21);
            this.cmbColName.TabIndex = 1;
            // 
            // cmbEndMark
            // 
            this.cmbEndMark.FormattingEnabled = true;
            this.cmbEndMark.Location = new System.Drawing.Point(420, 2);
            this.cmbEndMark.Name = "cmbEndMark";
            this.cmbEndMark.Size = new System.Drawing.Size(52, 21);
            this.cmbEndMark.TabIndex = 5;
            // 
            // cmbStartMark
            // 
            this.cmbStartMark.FormattingEnabled = true;
            this.cmbStartMark.Location = new System.Drawing.Point(2, 1);
            this.cmbStartMark.Name = "cmbStartMark";
            this.cmbStartMark.Size = new System.Drawing.Size(39, 21);
            this.cmbStartMark.TabIndex = 0;
            // 
            // ElBsonValue
            // 
            this.ElBsonValue.Location = new System.Drawing.Point(202, -2);
            this.ElBsonValue.Name = "ElBsonValue";
            this.ElBsonValue.Size = new System.Drawing.Size(214, 28);
            this.ElBsonValue.TabIndex = 6;
            // 
            // ctlQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ElBsonValue);
            this.Controls.Add(this.cmbStartMark);
            this.Controls.Add(this.cmbEndMark);
            this.Controls.Add(this.cmbColName);
            this.Controls.Add(this.cmbCompareOpr);
            this.Name = "CtlQueryCondition";
            this.Size = new System.Drawing.Size(484, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbCompareOpr;
        private ComboBox cmbColName;
        private ComboBox cmbEndMark;
        private ComboBox cmbStartMark;
        private CtlBsonValue ElBsonValue;

    }
}
