using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib;
using ResourceLib.Properties;

namespace MongoCola
{
    public partial class frmServerMonitor : Form
    {
        private Timer M;

        public frmServerMonitor()
        {
            InitializeComponent();
        }

        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            M = new Timer {Interval = 3000};
            M.Tick += M_Tick;
            var QuerySeries = new Series("Query")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(QuerySeries);

            var InsertSeries = new Series("Insert")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32
            };
            MonitorGrap.Series.Add(InsertSeries);
            FormClosing += (x, y) => M.Stop();
            M.Start();
        }

        private void M_Tick(object sender, EventArgs e)
        {
            var DocStatus =
                CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command,
                    RuntimeMongoDBContext.GetCurrentServer()).Response;

            var queryPoint = new DataPoint();
            queryPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                DocStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("query").Value);
            MonitorGrap.Series[0].Points.Add(queryPoint);

            var insertPoint = new DataPoint();
            insertPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture),
                DocStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("insert").Value);
            MonitorGrap.Series[1].Points.Add(insertPoint);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            M.Stop();
            Close();
        }
    }
}