namespace MagicMongoDBTool
{
    partial class frmAggregationCondition
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.QueryFieldPicker = new MagicMongoDBTool.FieldPicker();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProject);
            this.tabControl1.Controls.Add(this.tabMatch);
            this.tabControl1.Controls.Add(this.tabOption);
            this.tabControl1.Controls.Add(this.tabGroup);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 354);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.QueryFieldPicker);
            this.tabProject.Location = new System.Drawing.Point(4, 22);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabProject.Size = new System.Drawing.Size(604, 328);
            this.tabProject.TabIndex = 0;
            this.tabProject.Text = "$project(Basic)";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // tabMatch
            // 
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(604, 328);
            this.tabMatch.TabIndex = 2;
            this.tabMatch.Text = "$match";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.txtSkip);
            this.tabOption.Controls.Add(this.txtLimit);
            this.tabOption.Controls.Add(this.chkSkip);
            this.tabOption.Controls.Add(this.chkLimit);
            this.tabOption.Location = new System.Drawing.Point(4, 22);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(604, 328);
            this.tabOption.TabIndex = 1;
            this.tabOption.Text = "Options";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // txtSkip
            // 
            this.txtSkip.Location = new System.Drawing.Point(81, 37);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(135, 20);
            this.txtSkip.TabIndex = 29;
            this.txtSkip.Text = "1";
            this.txtSkip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(81, 15);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(135, 20);
            this.txtLimit.TabIndex = 28;
            this.txtLimit.Text = "1";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Location = new System.Drawing.Point(26, 40);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(51, 17);
            this.chkSkip.TabIndex = 1;
            this.chkSkip.Text = "$skip";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // chkLimit
            // 
            this.chkLimit.AutoSize = true;
            this.chkLimit.Location = new System.Drawing.Point(26, 17);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(49, 17);
            this.chkLimit.TabIndex = 0;
            this.chkLimit.Text = "$limit";
            this.chkLimit.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(542, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // QueryFieldPicker
            // 
            this.QueryFieldPicker.AutoScroll = true;
            this.QueryFieldPicker.BackColor = System.Drawing.Color.White;
            this.QueryFieldPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryFieldPicker.IsIDProtect = false;
            this.QueryFieldPicker.Location = new System.Drawing.Point(3, 3);
            this.QueryFieldPicker.Name = "QueryFieldPicker";
            this.QueryFieldPicker.Size = new System.Drawing.Size(598, 322);
            this.QueryFieldPicker.TabIndex = 1;
            // 
            // tabGroup
            // 
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(604, 328);
            this.tabGroup.TabIndex = 3;
            this.tabGroup.Text = "$group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // frmAggregationCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 412);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAggregationCondition";
            this.Text = "Aggregation Condition Builder";
            this.Load += new System.EventHandler(this.frmAggregationCondition_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProject;
        private FieldPicker QueryFieldPicker;
        private System.Windows.Forms.TabPage tabOption;
        private System.Windows.Forms.TabPage tabMatch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkSkip;
        private System.Windows.Forms.CheckBox chkLimit;
        private System.Windows.Forms.TextBox txtSkip;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.TabPage tabGroup;


    }
}