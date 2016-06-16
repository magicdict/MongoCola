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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ElBsonValue = new MongoGUICtl.CtlBsonValue();
            this.SuspendLayout();
            // 
            // cmbCompareOpr
            // 
            this.cmbCompareOpr.FormattingEnabled = true;
            this.cmbCompareOpr.Location = new System.Drawing.Point(142, 1);
            this.cmbCompareOpr.Name = "cmbCompareOpr";
            this.cmbCompareOpr.Size = new System.Drawing.Size(54, 20);
            this.cmbCompareOpr.TabIndex = 2;
            // 
            // cmbColName
            // 
            this.cmbColName.FormattingEnabled = true;
            this.cmbColName.Location = new System.Drawing.Point(45, 1);
            this.cmbColName.Name = "cmbColName";
            this.cmbColName.Size = new System.Drawing.Size(91, 20);
            this.cmbColName.TabIndex = 1;
            // 
            // cmbEndMark
            // 
            this.cmbEndMark.FormattingEnabled = true;
            this.cmbEndMark.Location = new System.Drawing.Point(416, 2);
            this.cmbEndMark.Name = "cmbEndMark";
            this.cmbEndMark.Size = new System.Drawing.Size(52, 20);
            this.cmbEndMark.TabIndex = 5;
            // 
            // cmbStartMark
            // 
            this.cmbStartMark.FormattingEnabled = true;
            this.cmbStartMark.Location = new System.Drawing.Point(2, 1);
            this.cmbStartMark.Name = "cmbStartMark";
            this.cmbStartMark.Size = new System.Drawing.Size(39, 20);
            this.cmbStartMark.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(528, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(470, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ElBsonValue
            // 
            this.ElBsonValue.Location = new System.Drawing.Point(202, -2);
            this.ElBsonValue.Name = "ElBsonValue";
            this.ElBsonValue.Size = new System.Drawing.Size(214, 26);
            this.ElBsonValue.TabIndex = 6;
            // 
            // CtlQueryCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.ElBsonValue);
            this.Controls.Add(this.cmbStartMark);
            this.Controls.Add(this.cmbEndMark);
            this.Controls.Add(this.cmbColName);
            this.Controls.Add(this.cmbCompareOpr);
            this.Name = "CtlQueryCondition";
            this.Size = new System.Drawing.Size(598, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbCompareOpr;
        private ComboBox cmbColName;
        private ComboBox cmbEndMark;
        private ComboBox cmbStartMark;
        private CtlBsonValue ElBsonValue;
        private Button btnRemove;
        private Button btnAdd;
    }
}
