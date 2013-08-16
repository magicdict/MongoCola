using MagicMongoDBTool.Module;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace MagicMongoDBTool
{
    public partial class frmServerMonitor : Form
    {
        public frmServerMonitor()
        {
            InitializeComponent();
        }
        Timer M;
        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            this.Icon = GetSystemIcon.ConvertImgToIcon(MagicMongoDBTool.Properties.Resources.KeyInfo);
            M = new Timer();
            M.Interval = 3000;
            M.Tick += M_Tick;
            Series QuerySeries = new Series("Query");
            QuerySeries.ChartType = SeriesChartType.Line;
            QuerySeries.XValueType = ChartValueType.String;
            QuerySeries.YValueType = ChartValueType.Int32;
            MonitorGrap.Series.Add(QuerySeries);

            Series InsertSeries = new Series("Insert");
            InsertSeries.ChartType = SeriesChartType.Line;
            InsertSeries.XValueType = ChartValueType.String;
            InsertSeries.YValueType = ChartValueType.Int32;
            MonitorGrap.Series.Add(InsertSeries);
            this.FormClosing += (x,y) =>
            {
                M.Stop();
            };
            M.Start();
        }
        void M_Tick(object sender, EventArgs e)
        {
                var DocStatus = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentServer()).Response;

                DataPoint queryPoint = new DataPoint();
                queryPoint.SetValueXY(DateTime.Now.ToString(), DocStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("query").Value);
                MonitorGrap.Series[0].Points.Add(queryPoint);

                DataPoint insertPoint = new DataPoint();
                insertPoint.SetValueXY(DateTime.Now.ToString(), DocStatus.GetElement("opcounters").Value.AsBsonDocument.GetElement("insert").Value);
                MonitorGrap.Series[1].Points.Add(insertPoint);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            M.Stop();
            this.Close();
        }
    }
}
