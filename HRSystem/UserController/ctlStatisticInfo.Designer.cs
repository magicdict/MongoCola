namespace HRSystem
{
    partial class ctlStatisticInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbHiringType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHiringManager = new System.Windows.Forms.ComboBox();
            this.lstPosition = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HiringTrackingchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.PhaseChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPhase = new System.Windows.Forms.ComboBox();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HiringTrackingchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhaseChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.cmbHiringType);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbHiringManager);
            this.splitContainer1.Panel1.Controls.Add(this.lstPosition);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.HiringTrackingchart);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.PhaseChart);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cmbPhase);
            this.splitContainer1.Panel2.Controls.Add(this.chartResult);
            this.splitContainer1.Size = new System.Drawing.Size(1553, 714);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmbHiringType
            // 
            this.cmbHiringType.FormattingEnabled = true;
            this.cmbHiringType.Location = new System.Drawing.Point(333, 6);
            this.cmbHiringType.Name = "cmbHiringType";
            this.cmbHiringType.Size = new System.Drawing.Size(97, 21);
            this.cmbHiringType.TabIndex = 7;
            this.cmbHiringType.SelectedIndexChanged += new System.EventHandler(this.cmbHiringType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hiring Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hiring Manager";
            // 
            // cmbHiringManager
            // 
            this.cmbHiringManager.FormattingEnabled = true;
            this.cmbHiringManager.Location = new System.Drawing.Point(98, 6);
            this.cmbHiringManager.Name = "cmbHiringManager";
            this.cmbHiringManager.Size = new System.Drawing.Size(121, 21);
            this.cmbHiringManager.TabIndex = 2;
            this.cmbHiringManager.SelectedIndexChanged += new System.EventHandler(this.cmbHiringManager_SelectedIndexChanged);
            // 
            // lstPosition
            // 
            this.lstPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPosition.FullRowSelect = true;
            this.lstPosition.GridLines = true;
            this.lstPosition.Location = new System.Drawing.Point(0, 30);
            this.lstPosition.Name = "lstPosition";
            this.lstPosition.Size = new System.Drawing.Size(1550, 270);
            this.lstPosition.TabIndex = 0;
            this.lstPosition.UseCompatibleStateImageBehavior = false;
            this.lstPosition.View = System.Windows.Forms.View.Details;
            this.lstPosition.SelectedIndexChanged += new System.EventHandler(this.lstPosition_SelectedIndexChanged);
            this.lstPosition.DoubleClick += new System.EventHandler(this.lstPosition_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Channel Management ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(888, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Leading time Management: ";
            // 
            // HiringTrackingchart
            // 
            this.HiringTrackingchart.BorderlineColor = System.Drawing.Color.Black;
            this.HiringTrackingchart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.HiringTrackingchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.HiringTrackingchart.Legends.Add(legend1);
            this.HiringTrackingchart.Location = new System.Drawing.Point(889, 83);
            this.HiringTrackingchart.Name = "HiringTrackingchart";
            this.HiringTrackingchart.Size = new System.Drawing.Size(407, 241);
            this.HiringTrackingchart.TabIndex = 36;
            this.HiringTrackingchart.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Qualification Management :";
            // 
            // PhaseChart
            // 
            this.PhaseChart.BorderlineColor = System.Drawing.Color.Black;
            this.PhaseChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.PhaseChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.PhaseChart.Legends.Add(legend2);
            this.PhaseChart.Location = new System.Drawing.Point(461, 83);
            this.PhaseChart.Name = "PhaseChart";
            this.PhaseChart.Size = new System.Drawing.Size(407, 241);
            this.PhaseChart.TabIndex = 33;
            this.PhaseChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Final Stauts:";
            // 
            // cmbPhase
            // 
            this.cmbPhase.FormattingEnabled = true;
            this.cmbPhase.Location = new System.Drawing.Point(119, 61);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(143, 21);
            this.cmbPhase.TabIndex = 31;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // chartResult
            // 
            chartArea3.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartResult.Legends.Add(legend3);
            this.chartResult.Location = new System.Drawing.Point(12, 83);
            this.chartResult.Name = "chartResult";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResult.Series.Add(series1);
            this.chartResult.Size = new System.Drawing.Size(407, 241);
            this.chartResult.TabIndex = 30;
            // 
            // ctlStatisticInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlStatisticInfo";
            this.Size = new System.Drawing.Size(1553, 714);
            this.Load += new System.EventHandler(this.ctlLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HiringTrackingchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhaseChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstPosition;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResult;
        private System.Windows.Forms.ComboBox cmbPhase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart PhaseChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart HiringTrackingchart;
        private System.Windows.Forms.ComboBox cmbHiringManager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHiringType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}
