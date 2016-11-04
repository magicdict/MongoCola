using MongoDB.Bson;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        private Dictionary<string, string> QueryName = new Dictionary<string, string>();

        private void FillQueryName()
        {
            //opcounters
            QueryName.Add("opcounters.Query", "opcounters.query");
            QueryName.Add("opcounters.Insert", "opcounters.insert");
            QueryName.Add("opcounters.Update", "opcounters.update");
            QueryName.Add("opcounters.Delete", "opcounters.delete");

            //memory
            QueryName.Add("mem.bits", "mem.bits");
            QueryName.Add("mem.resident", "mem.resident");
            QueryName.Add("mem.virtual", "mem.virtual");
            QueryName.Add("mem.mapped", "mem.mapped");
        }

        /// <summary>
        ///     刷新时间间隔
        /// </summary>
        public static int RefreshInterval { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            FillQueryName();
            if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            _mTime = new Timer { Interval = RefreshInterval * 1000 };
            _mTime.Tick += SetValue;
            MonitorGrap.Series.Clear();

            foreach (var item in QueryName.Keys)
            {
                var querySeries = new Series(item.Split(".".ToCharArray())[1])
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                MonitorGrap.Series.Add(querySeries);
            }
            SetValue(null,null);
            FormClosing += (x, y) => _mTime.Stop();
            _mTime.Start();
        }
        /// <summary>
        ///     将值设定到图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetValue(object sender, EventArgs e)
        {
            var docStatus = CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand,
                    RuntimeMongoDbContext.GetCurrentServer()).Response;
            foreach (var item in QueryName.Keys)
            {
                var queryPoint = new DataPoint();
                queryPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture), GetValue(docStatus, QueryName[item]));
                MonitorGrap.Series[item.Split(".".ToCharArray())[1]].Points.Add(queryPoint);
            }
        }
        /// <summary>
        ///     获得值
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private BsonValue GetValue(BsonDocument Doc, string Path)
        {
            var PathArray = Path.Split(".".ToCharArray());
            return Doc.GetElement(PathArray[0]).Value.AsBsonDocument.GetElement(PathArray[1]).Value;
        }

    }
}