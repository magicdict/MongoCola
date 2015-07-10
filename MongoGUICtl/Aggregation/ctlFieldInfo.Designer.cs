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
            this.radNoSort = new System.Windows.Forms.RadioButton();
            this.radSortAcs = new System.Windows.Forms.RadioButton();
            this.radSortDes = new System.Windows.Forms.RadioButton();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.NumIndexOrder = new System.Windows.Forms.NumericUpDown();
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
            this.chkIsShow.Location = new System.Drawing.Point(72, 4);
            this.chkIsShow.Name = "chkIsShow";
            this.chkIsShow.Size = new System.Drawing.Size(66, 16);
            this.chkIsShow.TabIndex = 1;
            this.chkIsShow.Text = "Display";
            this.chkIsShow.UseVisualStyleBackColor = true;
            // 
            // radNoSort
            // 
            this.radNoSort.AutoSize = true;
            this.radNoSort.Location = new System.Drawing.Point(260, 4);
            this.radNoSort.Name = "radNoSort";
            this.radNoSort.Size = new System.Drawing.Size(35, 16);
            this.radNoSort.TabIndex = 2;
            this.radNoSort.TabStop = true;
            this.radNoSort.Text = "No";
            this.radNoSort.UseVisualStyleBackColor = true;
            // 
            // radSortAcs
            // 
            this.radSortAcs.AutoSize = true;
            this.radSortAcs.Location = new System.Drawing.Point(315, 5);
            this.radSortAcs.Name = "radSortAcs";
            this.radSortAcs.Size = new System.Drawing.Size(41, 16);
            this.radSortAcs.TabIndex = 3;
            this.radSortAcs.TabStop = true;
            this.radSortAcs.Text = "Asc";
            this.radSortAcs.UseVisualStyleBackColor = true;
            // 
            // radSortDes
            // 
            this.radSortDes.AutoSize = true;
            this.radSortDes.Location = new System.Drawing.Point(366, 5);
            this.radSortDes.Name = "radSortDes";
            this.radSortDes.Size = new System.Drawing.Size(41, 16);
            this.radSortDes.TabIndex = 4;
            this.radSortDes.TabStop = true;
            this.radSortDes.Text = "Des";
            this.radSortDes.UseVisualStyleBackColor = true;
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(144, 1);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(100, 21);
            this.txtProject.TabIndex = 5;
            // 
            // NumIndexOrder
            // 
            this.NumIndexOrder.Location = new System.Drawing.Point(413, 2);
            this.NumIndexOrder.Name = "NumIndexOrder";
            this.NumIndexOrder.Size = new System.Drawing.Size(35, 21);
            this.NumIndexOrder.TabIndex = 6;
            this.NumIndexOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CtlFieldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumIndexOrder);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.radSortDes);
            this.Controls.Add(this.radSortAcs);
            this.Controls.Add(this.radNoSort);
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
        private RadioButton radNoSort;
        private RadioButton radSortAcs;
        private RadioButton radSortDes;
        private TextBox txtProject;
        private NumericUpDown NumIndexOrder;
    }
}
