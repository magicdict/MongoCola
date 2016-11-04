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
            ((System.ComponentModel.ISupportInitialize)(this.MonitorGrap)).BeginInit();
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
            this.MonitorGrap.Location = new System.Drawing.Point(12, 27);
            this.MonitorGrap.Name = "MonitorGrap";
            this.MonitorGrap.Size = new System.Drawing.Size(626, 282);
            this.MonitorGrap.TabIndex = 0;
            this.MonitorGrap.Text = "chart1";
            // 
            // FrmServerMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 339);
            this.Controls.Add(this.MonitorGrap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmServerMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Monitor";
            this.Load += new System.EventHandler(this.frmServerMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorGrap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Chart MonitorGrap;
    }
}