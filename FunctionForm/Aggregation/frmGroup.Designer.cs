using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoGUICtl;

namespace FunctionForm.Aggregation
{
    partial class FrmGroup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmdRun = new System.Windows.Forms.Button();
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
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.ctlReduce = new CtlTextMgr();
            this.ctlFinalize = new CtlTextMgr();
            this.tabGroup.SuspendLayout();
            this.tabReduce.SuspendLayout();
            this.tabFinalize.SuspendLayout();
            this.tabGroupField.SuspendLayout();
            this.tabInitialize.SuspendLayout();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
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
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(22, 32);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(468, 233);
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
            this.tabReduce.Controls.Add(this.ctlReduce);
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
            this.tabFinalize.Controls.Add(this.ctlFinalize);
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
            this.tabResult.Controls.Add(this.chartResult);
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
            // chartResult
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResult.Legends.Add(legend1);
            this.chartResult.Location = new System.Drawing.Point(22, 278);
            this.chartResult.Name = "chartResult";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResult.Series.Add(series1);
            this.chartResult.Size = new System.Drawing.Size(469, 241);
            this.chartResult.TabIndex = 28;
            this.chartResult.Text = "chartResult";
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
            // ctlReduce
            // 
            this.ctlReduce.Context = "function(obj,prev){ prev.count++;}";
            this.ctlReduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlReduce.Location = new System.Drawing.Point(6, 24);
            this.ctlReduce.Name = "ctlReduce";
            this.ctlReduce.Size = new System.Drawing.Size(498, 506);
            this.ctlReduce.TabIndex = 0;
            this.ctlReduce.Title = "Reduce Js";
            // 
            // ctlFinalize
            // 
            this.ctlFinalize.Context = "";
            this.ctlFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinalize.Location = new System.Drawing.Point(16, 6);
            this.ctlFinalize.Name = "ctlFinalize";
            this.ctlFinalize.Size = new System.Drawing.Size(488, 524);
            this.ctlFinalize.TabIndex = 0;
            this.ctlFinalize.Title = "Title";
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
            this.Name = "FrmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.tabGroup.ResumeLayout(false);
            this.tabReduce.ResumeLayout(false);
            this.tabFinalize.ResumeLayout(false);
            this.tabGroupField.ResumeLayout(false);
            this.tabGroupField.PerformLayout();
            this.tabInitialize.ResumeLayout(false);
            this.tabInitialize.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdRun;
        private Label lblSelectGroupField;
        private Panel panColumn;
        private TextBox txtResult;
        private Label lblAddInitField;
        private Panel panBsonEl;
        private Button cmdAddInitField;
        private Label lblResult;
        private TabControl tabGroup;
        private TabPage tabReduce;
        private TabPage tabFinalize;
        private TabPage tabGroupField;
        private TabPage tabInitialize;
        private TabPage tabResult;
        private Button cmdQuery;
        private Chart chartResult;
        private CtlTextMgr ctlReduce;
        private CtlTextMgr ctlFinalize;
    }
}