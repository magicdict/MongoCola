using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;
using ResourceLib.Properties;

namespace MongoCola.Status
{
    public partial class FrmServerMonitor : Form
    {
        private Timer _m;

        public FrmServerMonitor()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
        }

        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            _m = new Timer {Interval = 3000};
            _m.Tick += M_Tick;
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
            FormClosing += (x, y) => _m.Stop();
            _m.Start();
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _m.Stop();
            Close();
        }
    }
}