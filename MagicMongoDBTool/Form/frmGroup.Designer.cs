namespace MagicMongoDBTool
{
    partial class frmGroup
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
            this.cmbForReduce = new System.Windows.Forms.ComboBox();
            this.cmdSaveReduceJs = new System.Windows.Forms.Button();
            this.lblReduceFunction = new System.Windows.Forms.Label();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.txtfinalizeJs = new System.Windows.Forms.TextBox();
            this.lblfinalizeFunction = new System.Windows.Forms.Label();
            this.cmdSavefinalizeJs = new System.Windows.Forms.Button();
            this.cmbForfinalize = new System.Windows.Forms.ComboBox();
            this.lblSelectGroupField = new System.Windows.Forms.Label();
            this.panColumn = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblAddInitField = new System.Windows.Forms.Label();
            this.panBsonEl = new System.Windows.Forms.Panel();
            this.cmdAddInitField = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.tabReduce = new System.Windows.Forms.TabPage();
            this.tabFinalize = new System.Windows.Forms.TabPage();
            this.tabGroupField = new System.Windows.Forms.TabPage();
            this.tabInitialize = new System.Windows.Forms.TabPage();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.tabGroup.SuspendLayout();
            this.tabReduce.SuspendLayout();
            this.tabFinalize.SuspendLayout();
            this.tabGroupField.SuspendLayout();
            this.tabInitialize.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(95, 32);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(175, 23);
            this.cmbForReduce.TabIndex = 0;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(290, 28);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(82, 28);
            this.cmdSaveReduceJs.TabIndex = 1;
            this.cmdSaveReduceJs.Text = "Save";
            this.cmdSaveReduceJs.UseVisualStyleBackColor = false;
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // lblReduceFunction
            // 
            this.lblReduceFunction.AutoSize = true;
            this.lblReduceFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblReduceFunction.Location = new System.Drawing.Point(24, 35);
            this.lblReduceFunction.Name = "lblReduceFunction";
            this.lblReduceFunction.Size = new System.Drawing.Size(65, 15);
            this.lblReduceFunction.TabIndex = 20;
            this.lblReduceFunction.Text = "Reduce Js";
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReduceJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReduceJs.Location = new System.Drawing.Point(12, 69);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(487, 454);
            this.txtReduceJs.TabIndex = 2;
            this.txtReduceJs.Text = "function(obj,prev){ prev.count++;}";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(389, 582);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(117, 37);
            this.cmdRun.TabIndex = 2;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtfinalizeJs
            // 
            this.txtfinalizeJs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfinalizeJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinalizeJs.Location = new System.Drawing.Point(16, 61);
            this.txtfinalizeJs.Multiline = true;
            this.txtfinalizeJs.Name = "txtfinalizeJs";
            this.txtfinalizeJs.Size = new System.Drawing.Size(479, 463);
            this.txtfinalizeJs.TabIndex = 19;
            // 
            // lblfinalizeFunction
            // 
            this.lblfinalizeFunction.AutoSize = true;
            this.lblfinalizeFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblfinalizeFunction.Location = new System.Drawing.Point(24, 33);
            this.lblfinalizeFunction.Name = "lblfinalizeFunction";
            this.lblfinalizeFunction.Size = new System.Drawing.Size(61, 15);
            this.lblfinalizeFunction.TabIndex = 20;
            this.lblfinalizeFunction.Text = "finalize Js";
            // 
            // cmdSavefinalizeJs
            // 
            this.cmdSavefinalizeJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSavefinalizeJs.Location = new System.Drawing.Point(287, 27);
            this.cmdSavefinalizeJs.Name = "cmdSavefinalizeJs";
            this.cmdSavefinalizeJs.Size = new System.Drawing.Size(82, 28);
            this.cmdSavefinalizeJs.TabIndex = 21;
            this.cmdSavefinalizeJs.Text = "Save";
            this.cmdSavefinalizeJs.UseVisualStyleBackColor = false;
            this.cmdSavefinalizeJs.Click += new System.EventHandler(this.cmdForSavefinalize_Click);
            // 
            // cmbForfinalize
            // 
            this.cmbForfinalize.FormattingEnabled = true;
            this.cmbForfinalize.Location = new System.Drawing.Point(104, 30);
            this.cmbForfinalize.Name = "cmbForfinalize";
            this.cmbForfinalize.Size = new System.Drawing.Size(175, 23);
            this.cmbForfinalize.TabIndex = 18;
            // 
            // lblSelectGroupField
            // 
            this.lblSelectGroupField.AutoSize = true;
            this.lblSelectGroupField.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectGroupField.Location = new System.Drawing.Point(20, 14);
            this.lblSelectGroupField.Name = "lblSelectGroupField";
            this.lblSelectGroupField.Size = new System.Drawing.Size(103, 15);
            this.lblSelectGroupField.TabIndex = 27;
            this.lblSelectGroupField.Text = "Pick Group Fields";
            // 
            // panColumn
            // 
            this.panColumn.AutoScroll = true;
            this.panColumn.BackColor = System.Drawing.Color.White;
            this.panColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panColumn.Location = new System.Drawing.Point(23, 32);
            this.panColumn.Name = "panColumn";
            this.panColumn.Size = new System.Drawing.Size(467, 478);
            this.panColumn.TabIndex = 28;
            // 
            // txtResult
            // 
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(22, 32);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(468, 487);
            this.txtResult.TabIndex = 0;
            // 
            // lblAddInitField
            // 
            this.lblAddInitField.AutoSize = true;
            this.lblAddInitField.BackColor = System.Drawing.Color.Transparent;
            this.lblAddInitField.Location = new System.Drawing.Point(21, 24);
            this.lblAddInitField.Name = "lblAddInitField";
            this.lblAddInitField.Size = new System.Drawing.Size(83, 15);
            this.lblAddInitField.TabIndex = 27;
            this.lblAddInitField.Text = "Add Init Fields";
            // 
            // panBsonEl
            // 
            this.panBsonEl.AutoScroll = true;
            this.panBsonEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBsonEl.Location = new System.Drawing.Point(24, 50);
            this.panBsonEl.Name = "panBsonEl";
            this.panBsonEl.Size = new System.Drawing.Size(466, 455);
            this.panBsonEl.TabIndex = 29;
            // 
            // cmdAddInitField
            // 
            this.cmdAddInitField.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddInitField.Location = new System.Drawing.Point(117, 18);
            this.cmdAddInitField.Name = "cmdAddInitField";
            this.cmdAddInitField.Size = new System.Drawing.Size(82, 26);
            this.cmdAddInitField.TabIndex = 22;
            this.cmdAddInitField.Text = "Add";
            this.cmdAddInitField.UseVisualStyleBackColor = false;
            this.cmdAddInitField.Click += new System.EventHandler(this.cmdAddFld_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(26, 14);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(45, 15);
            this.lblResult.TabIndex = 27;
            this.lblResult.Text = "Result:";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.tabReduce);
            this.tabGroup.Controls.Add(this.tabFinalize);
            this.tabGroup.Controls.Add(this.tabGroupField);
            this.tabGroup.Controls.Add(this.tabInitialize);
            this.tabGroup.Controls.Add(this.tabResult);
            this.tabGroup.Location = new System.Drawing.Point(12, 12);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.Size = new System.Drawing.Size(518, 564);
            this.tabGroup.TabIndex = 0;
            // 
            // tabReduce
            // 
            this.tabReduce.Controls.Add(this.lblReduceFunction);
            this.tabReduce.Controls.Add(this.txtReduceJs);
            this.tabReduce.Controls.Add(this.cmdSaveReduceJs);
            this.tabReduce.Controls.Add(this.cmbForReduce);
            this.tabReduce.Location = new System.Drawing.Point(4, 24);
            this.tabReduce.Name = "tabReduce";
            this.tabReduce.Padding = new System.Windows.Forms.Padding(3);
            this.tabReduce.Size = new System.Drawing.Size(510, 536);
            this.tabReduce.TabIndex = 0;
            this.tabReduce.Text = "Reduce";
            this.tabReduce.UseVisualStyleBackColor = true;
            // 
            // tabFinalize
            // 
            this.tabFinalize.Controls.Add(this.lblfinalizeFunction);
            this.tabFinalize.Controls.Add(this.txtfinalizeJs);
            this.tabFinalize.Controls.Add(this.cmdSavefinalizeJs);
            this.tabFinalize.Controls.Add(this.cmbForfinalize);
            this.tabFinalize.Location = new System.Drawing.Point(4, 24);
            this.tabFinalize.Name = "tabFinalize";
            this.tabFinalize.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinalize.Size = new System.Drawing.Size(510, 536);
            this.tabFinalize.TabIndex = 1;
            this.tabFinalize.Text = "Finalize";
            this.tabFinalize.UseVisualStyleBackColor = true;
            // 
            // tabGroupField
            // 
            this.tabGroupField.Controls.Add(this.lblSelectGroupField);
            this.tabGroupField.Controls.Add(this.panColumn);
            this.tabGroupField.Location = new System.Drawing.Point(4, 24);
            this.tabGroupField.Name = "tabGroupField";
            this.tabGroupField.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupField.Size = new System.Drawing.Size(510, 536);
            this.tabGroupField.TabIndex = 2;
            this.tabGroupField.Text = "Group Fields";
            this.tabGroupField.UseVisualStyleBackColor = true;
            // 
            // tabInitialize
            // 
            this.tabInitialize.Controls.Add(this.cmdAddInitField);
            this.tabInitialize.Controls.Add(this.panBsonEl);
            this.tabInitialize.Controls.Add(this.lblAddInitField);
            this.tabInitialize.Location = new System.Drawing.Point(4, 24);
            this.tabInitialize.Name = "tabInitialize";
            this.tabInitialize.Padding = new System.Windows.Forms.Padding(3);
            this.tabInitialize.Size = new System.Drawing.Size(510, 536);
            this.tabInitialize.TabIndex = 3;
            this.tabInitialize.Text = "Init Fields";
            this.tabInitialize.UseVisualStyleBackColor = true;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.lblResult);
            this.tabResult.Controls.Add(this.txtResult);
            this.tabResult.Location = new System.Drawing.Point(4, 24);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(510, 536);
            this.tabResult.TabIndex = 4;
            this.tabResult.Text = "Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuery.Location = new System.Drawing.Point(253, 582);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(117, 37);
            this.cmdQuery.TabIndex = 1;
            this.cmdQuery.Text = "Load Query";
            this.cmdQuery.UseVisualStyleBackColor = false;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 631);
            this.Controls.Add(this.tabGroup);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.cmdQuery);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.tabGroup.ResumeLayout(false);
            this.tabReduce.ResumeLayout(false);
            this.tabReduce.PerformLayout();
            this.tabFinalize.ResumeLayout(false);
            this.tabFinalize.PerformLayout();
            this.tabGroupField.ResumeLayout(false);
            this.tabGroupField.PerformLayout();
            this.tabInitialize.ResumeLayout(false);
            this.tabInitialize.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.ComboBox cmbForReduce;
        private System.Windows.Forms.Button cmdSaveReduceJs;
        private System.Windows.Forms.Label lblReduceFunction;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.ComboBox cmbForfinalize;
        private System.Windows.Forms.Button cmdSavefinalizeJs;
        private System.Windows.Forms.Label lblfinalizeFunction;
        private System.Windows.Forms.TextBox txtfinalizeJs;
        private System.Windows.Forms.Label lblSelectGroupField;
        private System.Windows.Forms.Panel panColumn;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblAddInitField;
        private System.Windows.Forms.Panel panBsonEl;
        private System.Windows.Forms.Button cmdAddInitField;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TabControl tabGroup;
        private System.Windows.Forms.TabPage tabReduce;
        private System.Windows.Forms.TabPage tabFinalize;
        private System.Windows.Forms.TabPage tabGroupField;
        private System.Windows.Forms.TabPage tabInitialize;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.Button cmdQuery;
    }
}