using Common;
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

        /// <summary>
        ///     刷新时间间隔
        /// </summary>
        public static int RefreshInterval { set; get; }

        /// <summary>
        ///     自定义系统监视项目
        /// </summary>
        public static List<string> MonitorItems { get; set; }

        /// <summary>
        ///     分类内部项目
        /// </summary>
        public static Dictionary<string, string> CatalogDetailDic = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServerMonitor_Load(object sender, EventArgs e)
        {
            //填充分组
            GuiConfig.Translateform(this);
            UIAssistant.FillComberWithArray(cmbCatalog, SystemStatus.GetCatalog().ToArray());
            //自定义分组
            cmbCatalog.Items.Add("Custom");

            cmbCatalog.SelectedIndex = 0;
            if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            _mTime = new Timer { Interval = RefreshInterval * 1000 };
            NumTimeInterval.Value = RefreshInterval;
            _mTime.Tick += SetValue;
            SetValue(null, null);
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
            var docStatus = CommandExecute.ExecuteMongoSvrCommand(DataBaseCommand.ServerStatusCommand,
                    RuntimeMongoDbContext.GetCurrentServer()).Response;
            foreach (var item in CatalogDetailDic.Keys)
            {
                var queryPoint = new DataPoint();
                queryPoint.SetValueXY(DateTime.Now.ToString(CultureInfo.InvariantCulture), SystemStatus.GetValue(docStatus, CatalogDetailDic[item]));
                MonitorGrap.Series[item.Split(".".ToCharArray())[1]].Points.Add(queryPoint);
            }
        }
        /// <summary>
        ///     Index变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCatalog.SelectedIndex == cmbCatalog.Items.Count - 1)
            {
                CatalogDetailDic.Clear();
                foreach (var item in MonitorItems)
                {
                    CatalogDetailDic.Add(item, item);
                }
            }
            else
            {
                CatalogDetailDic = SystemStatus.GetCatalogDic(cmbCatalog.Text);
            }
            ResetMonitorItems();
        }
        /// <summary>
        ///     重制监视项目
        /// </summary>
        private void ResetMonitorItems()
        {
            MonitorGrap.Series.Clear();
            foreach (var item in CatalogDetailDic.Keys)
            {
                var querySeries = new Series(item.Split(".".ToCharArray())[1])
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                MonitorGrap.Series.Add(querySeries);
            }
        }

        /// <summary>
        ///     刷新时间变更的委托
        /// </summary>
        public static Action<int> FreshTimeChanged;
        /// <summary>
        ///     自定义监视项目
        /// </summary>
        public static Action<List<string>> MonitorItemsChanged;

        /// <summary>
        ///     时间变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumTimeInterval_ValueChanged(object sender, EventArgs e)
        {
            if ((int)NumTimeInterval.Value == 0)
            {
                _mTime.Stop();
            }
            else
            {
                _mTime.Start();
                _mTime.Interval = (int)NumTimeInterval.Value * 1000;
                FreshTimeChanged((int)NumTimeInterval.Value);
            }
        }

        private void cmdCustom_Click(object sender, EventArgs e)
        {
            var frm = new frmCustomMonitorItems();
            UIAssistant.OpenModalForm(frm, false, true);
            if (frm.SelectedItems != null)
            {
                MonitorItemsChanged(frm.SelectedItems);
                MonitorItems = frm.SelectedItems;
                cmbCatalog.SelectedIndex = cmbCatalog.Items.Count - 1;
            }
        }
    }
}