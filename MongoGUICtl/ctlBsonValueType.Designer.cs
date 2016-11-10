using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class ctlBsonValueType
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
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.ctlBsonValue1 = new MongoGUICtl.ctlBsonValue();
            this.SuspendLayout();
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(0, 4);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(91, 20);
            this.cmbDataType.TabIndex = 15;
            // 
            // ctlBsonValue1
            // 
            this.ctlBsonValue1.BackColor = System.Drawing.Color.Transparent;
            this.ctlBsonValue1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlBsonValue1.Location = new System.Drawing.Point(100, 1);
            this.ctlBsonValue1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlBsonValue1.Name = "ctlBsonValue1";
            this.ctlBsonValue1.Size = new System.Drawing.Size(197, 31);
            this.ctlBsonValue1.TabIndex = 0;
            this.ctlBsonValue1.Load += new System.EventHandler(this.ctlBsonValue1_Load);
            // 
            // ctlBsonValueType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.ctlBsonValue1);
            this.Name = "ctlBsonValueType";
            this.Size = new System.Drawing.Size(302, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlBsonValue ctlBsonValue1;
        private ComboBox cmbDataType;
    }
}
