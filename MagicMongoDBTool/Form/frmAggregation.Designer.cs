namespace MagicMongoDBTool
{
    partial class frmAggregation
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
            this.cmbForAggregate = new System.Windows.Forms.ComboBox();
            this.cmdSaveAggregate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAggregate = new System.Windows.Forms.Label();
            this.txtAggregate = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdAddCondition = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.lnkReference = new System.Windows.Forms.LinkLabel();
            this.trvCondition = new TreeViewColumnsProject.TreeViewColumns();
            this.trvResult = new TreeViewColumnsProject.TreeViewColumns();
            this.cmdSaveAggregatePipeline = new System.Windows.Forms.Button();
            this.lblAggregatePipeline = new System.Windows.Forms.Label();
            this.cmbForAggregatePipeline = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbForAggregate
            // 
            this.cmbForAggregate.FormattingEnabled = true;
            this.cmbForAggregate.Location = new System.Drawing.Point(126, 14);
            this.cmbForAggregate.Name = "cmbForAggregate";
            this.cmbForAggregate.Size = new System.Drawing.Size(235, 21);
            this.cmbForAggregate.TabIndex = 16;
            // 
            // cmdSaveAggregate
            // 
            this.cmdSaveAggregate.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveAggregate.Location = new System.Drawing.Point(280, 170);
            this.cmdSaveAggregate.Name = "cmdSaveAggregate";
            this.cmdSaveAggregate.Size = new System.Drawing.Size(82, 25);
            this.cmdSaveAggregate.TabIndex = 17;
            this.cmdSaveAggregate.Text = "Save";
            this.cmdSaveAggregate.UseVisualStyleBackColor = false;
            this.cmdSaveAggregate.Click += new System.EventHandler(this.cmdSaveAggregate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(381, 25);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 20;
            this.lblResult.Text = "Result";
            // 
            // lblAggregate
            // 
            this.lblAggregate.AutoSize = true;
            this.lblAggregate.BackColor = System.Drawing.Color.Transparent;
            this.lblAggregate.Location = new System.Drawing.Point(17, 17);
            this.lblAggregate.Name = "lblAggregate";
            this.lblAggregate.Size = new System.Drawing.Size(103, 13);
            this.lblAggregate.TabIndex = 19;
            this.lblAggregate.Text = "Aggregate Condition";
            // 
            // txtAggregate
            // 
            this.txtAggregate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAggregate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAggregate.Location = new System.Drawing.Point(13, 39);
            this.txtAggregate.Multiline = true;
            this.txtAggregate.Name = "txtAggregate";
            this.txtAggregate.Size = new System.Drawing.Size(348, 126);
            this.txtAggregate.TabIndex = 18;
            this.txtAggregate.Text = " { $project : {\r\n        _id : 0 ,\r\n        title : 1 ,\r\n        author : 1\r\n    " +
    "}}";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(280, 394);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(82, 25);
            this.cmdRun.TabIndex = 21;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.Location = new System.Drawing.Point(91, 171);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(95, 24);
            this.cmdAddCondition.TabIndex = 23;
            this.cmdAddCondition.Text = "Add to Pipeline ";
            this.cmdAddCondition.UseVisualStyleBackColor = true;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(192, 171);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(82, 24);
            this.cmdClear.TabIndex = 23;
            this.cmdClear.Text = "Clear ";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // lnkReference
            // 
            this.lnkReference.AutoSize = true;
            this.lnkReference.Location = new System.Drawing.Point(377, 7);
            this.lnkReference.Name = "lnkReference";
            this.lnkReference.Size = new System.Drawing.Size(172, 13);
            this.lnkReference.TabIndex = 24;
            this.lnkReference.TabStop = true;
            this.lnkReference.Text = "Aggregation Framework Reference";
            this.lnkReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReference_LinkClicked);
            // 
            // trvCondition
            // 
            this.trvCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCondition.Location = new System.Drawing.Point(12, 236);
            this.trvCondition.Name = "trvCondition";
            this.trvCondition.Padding = new System.Windows.Forms.Padding(1);
            this.trvCondition.Size = new System.Drawing.Size(349, 142);
            this.trvCondition.TabIndex = 22;
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvResult.Location = new System.Drawing.Point(380, 45);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(438, 374);
            this.trvResult.TabIndex = 0;
            // 
            // cmdSaveAggregatePipeline
            // 
            this.cmdSaveAggregatePipeline.Location = new System.Drawing.Point(117, 394);
            this.cmdSaveAggregatePipeline.Name = "cmdSaveAggregatePipeline";
            this.cmdSaveAggregatePipeline.Size = new System.Drawing.Size(157, 25);
            this.cmdSaveAggregatePipeline.TabIndex = 25;
            this.cmdSaveAggregatePipeline.Text = "Save Aggregate Pipeline";
            this.cmdSaveAggregatePipeline.UseVisualStyleBackColor = true;
            this.cmdSaveAggregatePipeline.Click += new System.EventHandler(this.cmdSaveAggregatePipeline_Click);
            // 
            // lblAggregatePipeline
            // 
            this.lblAggregatePipeline.AutoSize = true;
            this.lblAggregatePipeline.BackColor = System.Drawing.Color.Transparent;
            this.lblAggregatePipeline.Location = new System.Drawing.Point(12, 207);
            this.lblAggregatePipeline.Name = "lblAggregatePipeline";
            this.lblAggregatePipeline.Size = new System.Drawing.Size(96, 13);
            this.lblAggregatePipeline.TabIndex = 26;
            this.lblAggregatePipeline.Text = "Aggregate Pipeline";
            // 
            // cmbForAggregatePipeline
            // 
            this.cmbForAggregatePipeline.FormattingEnabled = true;
            this.cmbForAggregatePipeline.Location = new System.Drawing.Point(126, 204);
            this.cmbForAggregatePipeline.Name = "cmbForAggregatePipeline";
            this.cmbForAggregatePipeline.Size = new System.Drawing.Size(235, 21);
            this.cmbForAggregatePipeline.TabIndex = 27;
            // 
            // frmAggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 444);
            this.Controls.Add(this.cmbForAggregatePipeline);
            this.Controls.Add(this.lblAggregatePipeline);
            this.Controls.Add(this.cmdSaveAggregatePipeline);
            this.Controls.Add(this.lnkReference);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdAddCondition);
            this.Controls.Add(this.trvCondition);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.cmbForAggregate);
            this.Controls.Add(this.cmdSaveAggregate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblAggregate);
            this.Controls.Add(this.txtAggregate);
            this.Controls.Add(this.trvResult);
            this.Name = "frmAggregation";
            this.Text = "frmAggregation";
            this.Load += new System.EventHandler(this.frmAggregation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewColumnsProject.TreeViewColumns trvResult;
        private System.Windows.Forms.ComboBox cmbForAggregate;
        private System.Windows.Forms.Button cmdSaveAggregate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAggregate;
        private System.Windows.Forms.TextBox txtAggregate;
        private System.Windows.Forms.Button cmdRun;
        private TreeViewColumnsProject.TreeViewColumns trvCondition;
        private System.Windows.Forms.Button cmdAddCondition;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.LinkLabel lnkReference;
        private System.Windows.Forms.Button cmdSaveAggregatePipeline;
        private System.Windows.Forms.Label lblAggregatePipeline;
        private System.Windows.Forms.ComboBox cmbForAggregatePipeline;
    }
}