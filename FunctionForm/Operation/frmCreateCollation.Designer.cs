namespace FunctionForm.Operation
{
    partial class frmCreateCollation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLocale = new System.Windows.Forms.TextBox();
            this.chkCaseLevel = new System.Windows.Forms.CheckBox();
            this.chkNumbericOrdering = new System.Windows.Forms.CheckBox();
            this.chkBackwards = new System.Windows.Forms.CheckBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmbStrength = new System.Windows.Forms.ComboBox();
            this.cmbAlternate = new System.Windows.Forms.ComboBox();
            this.cmbMaxVariable = new System.Windows.Forms.ComboBox();
            this.cmbCaseFirst = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "locale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "caseFirst";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "strength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "alternate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "maxVariable";
            // 
            // txtLocale
            // 
            this.txtLocale.Location = new System.Drawing.Point(120, 18);
            this.txtLocale.Name = "txtLocale";
            this.txtLocale.Size = new System.Drawing.Size(121, 21);
            this.txtLocale.TabIndex = 6;
            // 
            // chkCaseLevel
            // 
            this.chkCaseLevel.AutoSize = true;
            this.chkCaseLevel.Location = new System.Drawing.Point(27, 45);
            this.chkCaseLevel.Name = "chkCaseLevel";
            this.chkCaseLevel.Size = new System.Drawing.Size(78, 16);
            this.chkCaseLevel.TabIndex = 7;
            this.chkCaseLevel.Text = "caseLevel";
            this.chkCaseLevel.UseVisualStyleBackColor = true;
            // 
            // chkNumbericOrdering
            // 
            this.chkNumbericOrdering.AutoSize = true;
            this.chkNumbericOrdering.Location = new System.Drawing.Point(27, 120);
            this.chkNumbericOrdering.Name = "chkNumbericOrdering";
            this.chkNumbericOrdering.Size = new System.Drawing.Size(114, 16);
            this.chkNumbericOrdering.TabIndex = 7;
            this.chkNumbericOrdering.Text = "numericOrdering";
            this.chkNumbericOrdering.UseVisualStyleBackColor = true;
            // 
            // chkBackwards
            // 
            this.chkBackwards.AutoSize = true;
            this.chkBackwards.Location = new System.Drawing.Point(27, 201);
            this.chkBackwards.Name = "chkBackwards";
            this.chkBackwards.Size = new System.Drawing.Size(78, 16);
            this.chkBackwards.TabIndex = 10;
            this.chkBackwards.Text = "backwards";
            this.chkBackwards.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(84, 237);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(95, 29);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmbStrength
            // 
            this.cmbStrength.FormattingEnabled = true;
            this.cmbStrength.Location = new System.Drawing.Point(120, 95);
            this.cmbStrength.Name = "cmbStrength";
            this.cmbStrength.Size = new System.Drawing.Size(121, 20);
            this.cmbStrength.TabIndex = 13;
            // 
            // cmbAlternate
            // 
            this.cmbAlternate.FormattingEnabled = true;
            this.cmbAlternate.Location = new System.Drawing.Point(120, 141);
            this.cmbAlternate.Name = "cmbAlternate";
            this.cmbAlternate.Size = new System.Drawing.Size(121, 20);
            this.cmbAlternate.TabIndex = 14;
            // 
            // cmbMaxVariable
            // 
            this.cmbMaxVariable.FormattingEnabled = true;
            this.cmbMaxVariable.Location = new System.Drawing.Point(120, 170);
            this.cmbMaxVariable.Name = "cmbMaxVariable";
            this.cmbMaxVariable.Size = new System.Drawing.Size(121, 20);
            this.cmbMaxVariable.TabIndex = 15;
            // 
            // cmbCaseFirst
            // 
            this.cmbCaseFirst.FormattingEnabled = true;
            this.cmbCaseFirst.Location = new System.Drawing.Point(120, 66);
            this.cmbCaseFirst.Name = "cmbCaseFirst";
            this.cmbCaseFirst.Size = new System.Drawing.Size(121, 20);
            this.cmbCaseFirst.TabIndex = 16;
            // 
            // frmCreateCollation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(262, 279);
            this.Controls.Add(this.cmbCaseFirst);
            this.Controls.Add(this.cmbMaxVariable);
            this.Controls.Add(this.cmbAlternate);
            this.Controls.Add(this.cmbStrength);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkBackwards);
            this.Controls.Add(this.chkNumbericOrdering);
            this.Controls.Add(this.chkCaseLevel);
            this.Controls.Add(this.txtLocale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmCreateCollation";
            this.Text = "Create Collation";
            this.Load += new System.EventHandler(this.frmCreateCollation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLocale;
        private System.Windows.Forms.CheckBox chkCaseLevel;
        private System.Windows.Forms.CheckBox chkNumbericOrdering;
        private System.Windows.Forms.CheckBox chkBackwards;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ComboBox cmbStrength;
        private System.Windows.Forms.ComboBox cmbAlternate;
        private System.Windows.Forms.ComboBox cmbMaxVariable;
        private System.Windows.Forms.ComboBox cmbCaseFirst;
    }
}