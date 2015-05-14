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
            this.btnClose = new System.Windows.Forms.Button();
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
            this.MonitorGrap.Location = new System.Drawing.Point(12, 11);
            this.MonitorGrap.Name = "MonitorGrap";
            this.MonitorGrap.Size = new System.Drawing.Size(837, 280);
            this.MonitorGrap.TabIndex = 0;
            this.MonitorGrap.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(774, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Tag = "Common_Close";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmServerMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 339);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.MonitorGrap);
            this.Name = "FrmServerMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServerMonitor";
            this.Load += new System.EventHandler(this.frmServerMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorGrap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Chart MonitorGrap;
        private Button btnClose;
    }
}