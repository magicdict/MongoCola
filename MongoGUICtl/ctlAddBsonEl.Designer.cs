using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlAddBsonEl
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
            this.txtElName = new System.Windows.Forms.TextBox();
            this.ElBsonValue = new CtlBsonValue();
            this.lblElement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtElName
            // 
            this.txtElName.Location = new System.Drawing.Point(0, 5);
            this.txtElName.Name = "txtElName";
            this.txtElName.Size = new System.Drawing.Size(96, 20);
            this.txtElName.TabIndex = 2;
            // 
            // ElBsonValue
            // 
            this.ElBsonValue.Location = new System.Drawing.Point(102, 0);
            this.ElBsonValue.Name = "ElBsonValue";
            this.ElBsonValue.Size = new System.Drawing.Size(218, 27);
            this.ElBsonValue.TabIndex = 3;
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(5, 8);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(73, 13);
            this.lblElement.TabIndex = 4;
            this.lblElement.Text = "ElementName";
            // 
            // ctlAddBsonEl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblElement);
            this.Controls.Add(this.ElBsonValue);
            this.Controls.Add(this.txtElName);
            this.Name = "CtlAddBsonEl";
            this.Size = new System.Drawing.Size(315, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtElName;
        private CtlBsonValue ElBsonValue;
        private Label lblElement;
    }
}
