using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoGUICtl;

namespace FunctionForm.Status
{
    partial class FrmStatus
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbChartField = new System.Windows.Forms.ComboBox();
            this.btnOpCnt = new System.Windows.Forms.Button();
            this.trvStatus = new MongoGUICtl.CtlTreeViewColumns();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(358, 498);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(125, 28);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chartResult
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResult.Legends.Add(legend1);
            this.chartResult.Location = new System.Drawing.Point(14, 251);
            this.chartResult.Name = "chartResult";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartResult.Series.Add(series1);
            this.chartResult.Size = new System.Drawing.Size(469, 241);
            this.chartResult.TabIndex = 29;
            // 
            // cmbChartField
            // 
            this.cmbChartField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartField.FormattingEnabled = true;
            this.cmbChartField.Location = new System.Drawing.Point(41, 222);
            this.cmbChartField.Name = "cmbChartField";
            this.cmbChartField.Size = new System.Drawing.Size(200, 23);
            this.cmbChartField.TabIndex = 30;
            this.cmbChartField.SelectedIndexChanged += new System.EventHandler(this.cmbChartField_SelectedIndexChanged);
            // 
            // btnOpCnt
            // 
            this.btnOpCnt.Location = new System.Drawing.Point(227, 498);
            this.btnOpCnt.Name = "btnOpCnt";
            this.btnOpCnt.Size = new System.Drawing.Size(125, 28);
            this.btnOpCnt.TabIndex = 31;
            this.btnOpCnt.Tag = "Common_OpCnt";
            this.btnOpCnt.Text = "Operate Counter";
            this.btnOpCnt.UseVisualStyleBackColor = true;
            this.btnOpCnt.Click += new System.EventHandler(this.btnOpCnt_Click);
            // 
            // trvStatus
            // 
            this.trvStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvStatus.Location = new System.Drawing.Point(14, 14);
            this.trvStatus.Name = "trvStatus";
            this.trvStatus.Padding = new System.Windows.Forms.Padding(1);
            this.trvStatus.Size = new System.Drawing.Size(469, 202);
            this.trvStatus.TabIndex = 2;
            // 
            // FrmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 537);
            this.Controls.Add(this.btnOpCnt);
            this.Controls.Add(this.cmbChartField);
            this.Controls.Add(this.chartResult);
            this.Controls.Add(this.trvStatus);
            this.Controls.Add(this.cmdClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmStatus";
            this.Tag = "Main_Menu_Mangt_Status";
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStatus_Closing);
            this.Load += new System.EventHandler(this.frmStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdClose;
        private CtlTreeViewColumns trvStatus;
        private Chart chartResult;
        private ComboBox cmbChartField;
        private Button btnOpCnt;
    }
}