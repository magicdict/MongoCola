using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FunctionForm.Status
{
    partial class FrmServerMonitor
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
            this.MonitorGrap = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbCatalog = new System.Windows.Forms.ComboBox();
            this.lblTimeInterval = new System.Windows.Forms.Label();
            this.NumTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCustom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MonitorGrap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // MonitorGrap
            // 
            this.MonitorGrap.BorderlineColor = System.Drawing.Color.Black;
            this.MonitorGrap.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.MonitorGrap.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MonitorGrap.Legends.Add(legend1);
            this.MonitorGrap.Location = new System.Drawing.Point(28, 45);
            this.MonitorGrap.Name = "MonitorGrap";
            this.MonitorGrap.Size = new System.Drawing.Size(626, 282);
            this.MonitorGrap.TabIndex = 0;
            this.MonitorGrap.Text = "chart1";
            // 
            // cmbCatalog
            // 
            this.cmbCatalog.FormattingEnabled = true;
            this.cmbCatalog.Location = new System.Drawing.Point(533, 12);
            this.cmbCatalog.Name = "cmbCatalog";
            this.cmbCatalog.Size = new System.Drawing.Size(121, 20);
            this.cmbCatalog.TabIndex = 1;
            this.cmbCatalog.SelectedIndexChanged += new System.EventHandler(this.cmbCatalog_SelectedIndexChanged);
            // 
            // lblTimeInterval
            // 
            this.lblTimeInterval.AutoSize = true;
            this.lblTimeInterval.Location = new System.Drawing.Point(26, 15);
            this.lblTimeInterval.Name = "lblTimeInterval";
            this.lblTimeInterval.Size = new System.Drawing.Size(137, 12);
            this.lblTimeInterval.TabIndex = 2;
            this.lblTimeInterval.Text = "Time Interval (second)";
            // 
            // NumTimeInterval
            // 
            this.NumTimeInterval.Location = new System.Drawing.Point(169, 11);
            this.NumTimeInterval.Name = "NumTimeInterval";
            this.NumTimeInterval.Size = new System.Drawing.Size(78, 21);
            this.NumTimeInterval.TabIndex = 3;
            this.NumTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumTimeInterval.ValueChanged += new System.EventHandler(this.NumTimeInterval_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "0 Seconds to Pause";
            // 
            // cmdCustom
            // 
            this.cmdCustom.Location = new System.Drawing.Point(424, 11);
            this.cmdCustom.Name = "cmdCustom";
            this.cmdCustom.Size = new System.Drawing.Size(75, 23);
            this.cmdCustom.TabIndex = 5;
            this.cmdCustom.Text = "Custom";
            this.cmdCustom.UseVisualStyleBackColor = true;
            this.cmdCustom.Click += new System.EventHandler(this.cmdCustom_Click);
            // 
            // FrmServerMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 339);
            this.Controls.Add(this.cmdCustom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumTimeInterval);
            this.Controls.Add(this.lblTimeInterval);
            this.Controls.Add(this.cmbCatalog);
            this.Controls.Add(this.MonitorGrap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServerMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Main_Menu_ServerMonitor";
            this.Text = "Server Monitor";
            this.Load += new System.EventHandler(this.frmServerMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorGrap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Chart MonitorGrap;
        private ComboBox cmbCatalog;
        private Label lblTimeInterval;
        private NumericUpDown NumTimeInterval;
        private Label label1;
        private Button cmdCustom;
    }
}