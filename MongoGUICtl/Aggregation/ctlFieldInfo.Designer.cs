using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    partial class CtlFieldInfo
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
            this.lblFieldName = new System.Windows.Forms.Label();
            this.chkIsShow = new System.Windows.Forms.CheckBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.NumIndexOrder = new System.Windows.Forms.NumericUpDown();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumIndexOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(7, 4);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(59, 12);
            this.lblFieldName.TabIndex = 0;
            this.lblFieldName.Text = "FieldName";
            // 
            // chkIsShow
            // 
            this.chkIsShow.AutoSize = true;
            this.chkIsShow.Location = new System.Drawing.Point(141, 3);
            this.chkIsShow.Name = "chkIsShow";
            this.chkIsShow.Size = new System.Drawing.Size(66, 16);
            this.chkIsShow.TabIndex = 1;
            this.chkIsShow.Text = "Display";
            this.chkIsShow.UseVisualStyleBackColor = true;
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(213, 2);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(100, 21);
            this.txtProject.TabIndex = 5;
            // 
            // NumIndexOrder
            // 
            this.NumIndexOrder.Location = new System.Drawing.Point(380, 2);
            this.NumIndexOrder.Name = "NumIndexOrder";
            this.NumIndexOrder.Size = new System.Drawing.Size(68, 21);
            this.NumIndexOrder.TabIndex = 6;
            this.NumIndexOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(319, 1);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(55, 20);
            this.cmbSort.TabIndex = 7;
            // 
            // CtlFieldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.NumIndexOrder);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.chkIsShow);
            this.Controls.Add(this.lblFieldName);
            this.Name = "CtlFieldInfo";
            this.Size = new System.Drawing.Size(451, 24);
            ((System.ComponentModel.ISupportInitialize)(this.NumIndexOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFieldName;
        private CheckBox chkIsShow;
        private TextBox txtProject;
        private NumericUpDown NumIndexOrder;
        private ComboBox cmbSort;
    }
}
