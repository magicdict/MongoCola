namespace FunctionForm.MachineLearning
{
    partial class frmRegression
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
            this.components = new System.ComponentModel.Container();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOutputField = new System.Windows.Forms.ComboBox();
            this.cmbInputField = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(29, 140);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(895, 325);
            this.zedGraph.TabIndex = 0;
            this.zedGraph.UseExtendedPrintDialog = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "input Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "output Field";
            // 
            // cmbOutputField
            // 
            this.cmbOutputField.FormattingEnabled = true;
            this.cmbOutputField.Location = new System.Drawing.Point(150, 62);
            this.cmbOutputField.Name = "cmbOutputField";
            this.cmbOutputField.Size = new System.Drawing.Size(121, 20);
            this.cmbOutputField.TabIndex = 3;
            // 
            // cmbInputField
            // 
            this.cmbInputField.FormattingEnabled = true;
            this.cmbInputField.Location = new System.Drawing.Point(150, 27);
            this.cmbInputField.Name = "cmbInputField";
            this.cmbInputField.Size = new System.Drawing.Size(121, 20);
            this.cmbInputField.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(150, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 34);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmRegression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(953, 477);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbInputField);
            this.Controls.Add(this.cmbOutputField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraph);
            this.Name = "frmRegression";
            this.Text = "Regression";
            this.Load += new System.EventHandler(this.frmRegression_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOutputField;
        private System.Windows.Forms.ComboBox cmbInputField;
        private System.Windows.Forms.Button btnOK;
    }
}