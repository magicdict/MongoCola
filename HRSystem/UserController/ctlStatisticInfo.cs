using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace HRSystem
{
    public partial class ctlStatisticInfo : UserControl
    {
        string Position = SystemManager.strTotal;
        ViewControl.PositionDelegate condition = (x) => { return true; };
        public ctlStatisticInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData()
        {
            ViewControl.FillPositionListView(lstPosition, DataCenter.PositionStatisticDataSet, condition);
            InitPhaseChart();
            RefreshChanel(cmbPhase.Text);
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlLoad(object sender, EventArgs e)
        {
            Utility.FillComberWithEnum(cmbPhase, typeof(HiringTracking.FinalStatusEnum), false);
            Utility.FillComberWithArray(cmbHiringManager, SystemManager.HiringManagerArray, false);
            Utility.FillComberWithEnum(cmbHiringType, typeof(PositionBasicInfo.HiringTypeEnum), false);
        }
        /// <summary>
        /// SelectIndex Chanaged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChanel(cmbPhase.Text);
        }
        /// <summary>
        /// Phase图
        /// </summary>
        private void InitPhaseChart()
        {
            if (DataCenter.HiringTrackingDataSet.Count == 0) return;
            var QuerySeries = new Series("Pileline")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            PhaseChart.Series.Clear();
            PhaseChart.Series.Add(QuerySeries);

            List<HiringTracking> Target;
            if (Position == SystemManager.strTotal)
            {
                Target = DataCenter.GetHiringTrackingDataSet();
            }
            else
            {
                Target = DataCenter.GetHiringTrackByPosition(Position);
            }

            var queryPoint = new DataPoint();
            queryPoint.SetValueXY("Pipeline", Target.Count());
            PhaseChart.Series[0].Points.Add(queryPoint);


            queryPoint = new DataPoint();
            queryPoint.SetValueXY("ScreenPass", Target.Count((x) =>
            {
                return !string.IsNullOrEmpty(x.FirstInterviewer);
            }));
            PhaseChart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("1stPass", Target.Count((x) =>
            {
                return HiringTracking.InterviewPassCheck(x.FirstInterviewResult);
            }));
            PhaseChart.Series[0].Points.Add(queryPoint);


            queryPoint = new DataPoint();
            queryPoint.SetValueXY("2ndPass", Target.Count((x) =>
            {
                return HiringTracking.InterviewPassCheck(x.SecondInterviewResult);
            }));
            PhaseChart.Series[0].Points.Add(queryPoint);


            queryPoint = new DataPoint();
            queryPoint.SetValueXY("3rdPass", Target.Count((x) =>
            {
                return HiringTracking.InterviewPassCheck(x.ThirdInterviewResult);
            }));
            PhaseChart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("OB", Target.Count((x) =>
            {
                return x.FinalStatus == HiringTracking.FinalStatusEnum.Onboard;
            }));
            PhaseChart.Series[0].Points.Add(queryPoint);
        }

        /// <summary>
        /// Phase图
        /// </summary>
        private void InitHiringTrackingChart()
        {
            if (DataCenter.HiringTrackingDataSet.Count == 0) return;
            var QuerySeries = new Series("First Date")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            HiringTrackingchart.Series.Clear();
            HiringTrackingchart.Series.Add(QuerySeries);

            List<HiringTracking> Target;
            if (Position == SystemManager.strTotal)
            {
                return;
            }
            else
            {
                Target = DataCenter.GetHiringTrackByPosition(Position);
            }

            DateTime BaseDate = DataCenter.GetBasicPositionInfo(Position).OpenDate;

            var queryPoint = new DataPoint();
            queryPoint.SetValueXY("Screen", Target.Min<HiringTracking>((x) =>
            {
                if (x.ScreenDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.ScreenDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("1st", Target.Min<HiringTracking>((x) =>
            {
                if (x.FirstInterviewDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.FirstInterviewDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("2nd", Target.Min<HiringTracking>((x) =>
            {
                if (x.SecondInterviewDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.SecondInterviewDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("3rd", Target.Min<HiringTracking>((x) =>
            {
                if (x.ThirdInterviewDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.ThirdInterviewDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("ANOB", Target.Min<HiringTracking>((x) =>
            {
                if (x.OfferOfferDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.OfferOfferDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);

            queryPoint = new DataPoint();
            queryPoint.SetValueXY("OB", Target.Min<HiringTracking>((x) =>
            {
                if (x.OnboardDate == DateTime.MinValue)
                {
                    return 999;
                }
                else
                {
                    return (x.OnboardDate.Date - BaseDate.Date).Days;
                };
            }));
            HiringTrackingchart.Series[0].Points.Add(queryPoint);
        }

        /// <summary>
        /// Refresh 
        /// </summary>
        /// <param name="strTitle"></param>
        private void RefreshChanel(string strTitle)
        {
            //图形化初始化
            chartResult.Series.Clear();
            chartResult.Titles.Clear();
            var SeriesResult = new Series(strTitle);
            List<HiringTracking> Target;

            if (cmbPhase.SelectedIndex == 0)
            {
                if (Position == SystemManager.strTotal)
                {
                    Target = DataCenter.HiringTrackingDataSet;
                }
                else
                {
                    Target = DataCenter.GetHiringTrackByPosition(Position);
                }
            }
            else
            {
                HiringTracking.FinalStatusEnum FinalStatus = (HiringTracking.FinalStatusEnum)cmbPhase.SelectedIndex - 1;
                if (Position == SystemManager.strTotal)
                {
                    Target = DataCenter.GetHiringTrackByFinalStatus(FinalStatus);
                }
                else
                {
                    Target = DataCenter.GetHiringTrackByPosition(Position, FinalStatus);
                }
            }

            foreach (HiringTracking.ChannelEnum item in Enum.GetValues(typeof(HiringTracking.ChannelEnum)))
            {
                DataPoint ColPoint;
                ColPoint = new DataPoint(0, Target.Count((x) =>
                {
                    return x.Channel == item;
                }));
                if (Target.Count() == 0)
                {
                    ColPoint.LegendText = item.ToString() + "(0%)";
                }
                else
                {
                    ColPoint.LegendText = item.ToString() + "(" + Math.Round((ColPoint.YValues[0] / (double)Target.Count()) * 100, 2) + "%" + ")";
                }
                ColPoint.LabelToolTip = item.ToString();
                ColPoint.ToolTip = item.ToString();
                SeriesResult.Points.Add(ColPoint);
            }
            //图形化加载
            SeriesResult.ChartType = SeriesChartType.Pie;
            chartResult.Series.Add(SeriesResult);
            chartResult.Titles.Add(strTitle);
        }
        /// <summary>
        /// lstPosition Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPosition.SelectedItems.Count == 1)
            {
                Position = lstPosition.SelectedItems[0].SubItems[2].Text;
                if (Position == string.Empty) Position = SystemManager.strTotal;
                cmbPhase.SelectedIndex = 0;
                InitPhaseChart();
                InitHiringTrackingChart();
                RefreshChanel("Channel");
            }
        }
        /// <summary>
        /// lstPostion Doublue Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPosition_DoubleClick(object sender, EventArgs e)
        {
            if (lstPosition.SelectedItems.Count == 1)
            {
                Position = lstPosition.SelectedItems[0].SubItems[2].Text;
                if (Position == string.Empty) Position = SystemManager.strTotal;
                (new frmHiringTracking(Position)).ShowDialog();
                RefreshData();
            }
        }
        /// <summary>
        /// Hiring Manager Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbHiringManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHiringManager.SelectedIndex == 0)
            {
                condition = (x) => { return true; };
            }
            else
            {
                condition = (x) => { return x.BasicInfo.HiringManager == cmbHiringManager.Text; };
            }
            ViewControl.FillPositionListView(lstPosition, DataCenter.PositionStatisticDataSet, condition);
        }

        private void cmbHiringType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHiringType.SelectedIndex == 0)
            {
                condition = (x) => { return true; };
            }
            else
            {
                condition = (x) => { return x.BasicInfo.HiringType.GetHashCode() == (cmbHiringType.SelectedIndex - 1); };
            }
            ViewControl.FillPositionListView(lstPosition, DataCenter.PositionStatisticDataSet, condition);

        }
    }
}
