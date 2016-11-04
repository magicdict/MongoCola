namespace FunctionForm.Aggregation
{
    partial class frmGeoNear
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.ctlGeoNear1 = new MongoGUICtl.CtlGeoNear();
            this.SuspendLayout();
            // 
            // ctlGeoNear1
            // 
            this.ctlGeoNear1.Location = new System.Drawing.Point(12, 12);
            this.ctlGeoNear1.Name = "ctlGeoNear1";
            this.ctlGeoNear1.Size = new System.Drawing.Size(589, 368);
            this.ctlGeoNear1.TabIndex = 0;
            // 
            // frmGeoNear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 410);
            this.Controls.Add(this.ctlGeoNear1);
            this.Name = "frmGeoNear";
            this.Text = "GeoNear";
            this.ResumeLayout(false);

        }

        #endregion

        private MongoGUICtl.CtlGeoNear ctlGeoNear1;
    }
}