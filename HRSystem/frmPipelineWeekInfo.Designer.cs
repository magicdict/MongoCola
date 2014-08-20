namespace HRSystem
{
    partial class frmPipelineWeekInfo
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
            this.WeekStart = new System.Windows.Forms.DateTimePicker();
            this.WeekEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstHiringTracking = new System.Windows.Forms.ListView();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WeekStart
            // 
            this.WeekStart.Location = new System.Drawing.Point(108, 12);
            this.WeekStart.Name = "WeekStart";
            this.WeekStart.Size = new System.Drawing.Size(128, 20);
            this.WeekStart.TabIndex = 0;
            this.WeekStart.ValueChanged += new System.EventHandler(this.WeekStart_ValueChanged);
            // 
            // WeekEnd
            // 
            this.WeekEnd.Location = new System.Drawing.Point(304, 12);
            this.WeekEnd.Name = "WeekEnd";
            this.WeekEnd.Size = new System.Drawing.Size(130, 20);
            this.WeekEnd.TabIndex = 1;
            this.WeekEnd.ValueChanged += new System.EventHandler(this.WeekEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // lstHiringTracking
            // 
            this.lstHiringTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHiringTracking.FullRowSelect = true;
            this.lstHiringTracking.GridLines = true;
            this.lstHiringTracking.Location = new System.Drawing.Point(8, 54);
            this.lstHiringTracking.Name = "lstHiringTracking";
            this.lstHiringTracking.Size = new System.Drawing.Size(813, 384);
            this.lstHiringTracking.TabIndex = 6;
            this.lstHiringTracking.UseCompatibleStateImageBehavior = false;
            this.lstHiringTracking.View = System.Windows.Forms.View.Details;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(512, 11);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(117, 21);
            this.cmbPosition.TabIndex = 46;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Position";
            // 
            // frmPipelineWeekInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(833, 438);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstHiringTracking);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WeekEnd);
            this.Controls.Add(this.WeekStart);
            this.Name = "frmPipelineWeekInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Week Picker";
            this.Load += new System.EventHandler(this.frmPipelineWeekInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker WeekStart;
        private System.Windows.Forms.DateTimePicker WeekEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstHiringTracking;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label label6;
    }
}