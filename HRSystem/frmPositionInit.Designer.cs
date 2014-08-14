namespace HRSystem
{
    partial class frmPositionInit
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
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHiringType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.DataPickerOpenDate = new System.Windows.Forms.DateTimePicker();
            this.DataPickerApprovedDate = new System.Windows.Forms.DateTimePicker();
            this.NumTarget = new System.Windows.Forms.NumericUpDown();
            this.cmbHBound = new System.Windows.Forms.ComboBox();
            this.cmbLBound = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbHiringManager = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(119, 29);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(212, 20);
            this.txtPosition.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hiring Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hiring Type";
            // 
            // cmbHiringType
            // 
            this.cmbHiringType.FormattingEnabled = true;
            this.cmbHiringType.Location = new System.Drawing.Point(119, 84);
            this.cmbHiringType.Name = "cmbHiringType";
            this.cmbHiringType.Size = new System.Drawing.Size(97, 21);
            this.cmbHiringType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Band";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Target";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Open Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Approved Date";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(256, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DataPickerOpenDate
            // 
            this.DataPickerOpenDate.Location = new System.Drawing.Point(119, 166);
            this.DataPickerOpenDate.Name = "DataPickerOpenDate";
            this.DataPickerOpenDate.Size = new System.Drawing.Size(212, 20);
            this.DataPickerOpenDate.TabIndex = 11;
            // 
            // DataPickerApprovedDate
            // 
            this.DataPickerApprovedDate.Location = new System.Drawing.Point(119, 192);
            this.DataPickerApprovedDate.Name = "DataPickerApprovedDate";
            this.DataPickerApprovedDate.Size = new System.Drawing.Size(212, 20);
            this.DataPickerApprovedDate.TabIndex = 12;
            // 
            // NumTarget
            // 
            this.NumTarget.Location = new System.Drawing.Point(120, 140);
            this.NumTarget.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NumTarget.Name = "NumTarget";
            this.NumTarget.Size = new System.Drawing.Size(96, 20);
            this.NumTarget.TabIndex = 13;
            this.NumTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbHBound
            // 
            this.cmbHBound.FormattingEnabled = true;
            this.cmbHBound.Location = new System.Drawing.Point(241, 113);
            this.cmbHBound.Name = "cmbHBound";
            this.cmbHBound.Size = new System.Drawing.Size(75, 21);
            this.cmbHBound.TabIndex = 14;
            // 
            // cmbLBound
            // 
            this.cmbLBound.FormattingEnabled = true;
            this.cmbLBound.Location = new System.Drawing.Point(119, 113);
            this.cmbLBound.Name = "cmbLBound";
            this.cmbLBound.Size = new System.Drawing.Size(71, 21);
            this.cmbLBound.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "----";
            // 
            // cmbHiringManager
            // 
            this.cmbHiringManager.FormattingEnabled = true;
            this.cmbHiringManager.Location = new System.Drawing.Point(120, 55);
            this.cmbHiringManager.Name = "cmbHiringManager";
            this.cmbHiringManager.Size = new System.Drawing.Size(211, 21);
            this.cmbHiringManager.TabIndex = 17;
            // 
            // frmPositionInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 284);
            this.Controls.Add(this.cmbHiringManager);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLBound);
            this.Controls.Add(this.cmbHBound);
            this.Controls.Add(this.NumTarget);
            this.Controls.Add(this.DataPickerApprovedDate);
            this.Controls.Add(this.DataPickerOpenDate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbHiringType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositionInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Position Initilizer";
            this.Load += new System.EventHandler(this.frmPositionInit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbHiringType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker DataPickerOpenDate;
        private System.Windows.Forms.DateTimePicker DataPickerApprovedDate;
        private System.Windows.Forms.NumericUpDown NumTarget;
        private System.Windows.Forms.ComboBox cmbHBound;
        private System.Windows.Forms.ComboBox cmbLBound;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbHiringManager;
    }
}