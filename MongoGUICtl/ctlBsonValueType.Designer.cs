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
            this.ctlBsonValue1 = new MongoGUICtl.ctlBsonValue();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ctlBsonValue1
            // 
            this.ctlBsonValue1.Location = new System.Drawing.Point(100, 1);
            this.ctlBsonValue1.Name = "ctlBsonValue1";
            this.ctlBsonValue1.Size = new System.Drawing.Size(225, 26);
            this.ctlBsonValue1.TabIndex = 0;
            this.ctlBsonValue1.Load += new System.EventHandler(this.ctlBsonValue1_Load);
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(3, 3);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(91, 20);
            this.cmbDataType.TabIndex = 15;
            // 
            // ctlBsonValueType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.ctlBsonValue1);
            this.Name = "ctlBsonValueType";
            this.Size = new System.Drawing.Size(328, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlBsonValue ctlBsonValue1;
        private ComboBox cmbDataType;
    }
}
