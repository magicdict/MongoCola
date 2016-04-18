using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;

namespace FunctionForm.Status
{
    public partial class FrmServerMonitor : Form
    {
        private Timer _mTime;

        public FrmServerMonitor()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
        }

        /// <summary>
        /// </summary>
        public static int RefreshInterval { set; get; }

        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            _mTime = new Timer {Interval = RefreshInterval*1000};
            _mTime.Tick += M_Tick;

            var querySeries = new Series("Query")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(querySeries);

            var insertSeries = new Series("Insert")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(insertSeries);


            var updateSeries = new Series("Update")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(updateSeries);

            var deleteSeries = new Series("Delete")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(deleteSeries);


            FormClosing += (x, y) => _mTime.Stop();
            _mTime.Start();
        }

        private void M_Tick(object sender, EventArgs e)
        {
            var docStatus =
                CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand,
                    RuntimeMongoDbContext.GetCurrentServer()).Response;

            var queryPoint = new DataPoint();
            queryPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                docStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("query").Value);
            MonitorGrap.Series[0].Points.Add(queryPoint);

            var insertPoint = new DataPoint();
            insertPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                docStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("insert").Value);
            MonitorGrap.Series[1].Points.Add(insertPoint);


            var updatePoint = new DataPoint();
            updatePoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                docStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("update").Value);
            MonitorGrap.Series[2].Points.Add(updatePoint);

            var deletePoint = new DataPoint();
            deletePoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                docStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("delete").Value);
            MonitorGrap.Series[3].Points.Add(deletePoint);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _mTime.Stop();
            Close();
        }
    }
}