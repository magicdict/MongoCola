using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Common;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;

namespace FunctionForm.Status
{
    public partial class FrmStatus : Form
    {
        public FrmStatus()
        {
            InitializeComponent();
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            var strType = RuntimeMongoDbContext.SelectTagType;
            var docStatus = new BsonDocument();
            cmbChartField.Visible = false;
            chartResult.Visible = false;
            btnOpCnt.Visible = false;
            switch (strType)
            {
                case ConstMgr.ServerTag:
                case ConstMgr.SingleDbServerTag:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        docStatus =
                            CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        trvStatus.Height = trvStatus.Height*2;
                    }
                    if (strType == ConstMgr.ServerTag)
                    {
                        btnOpCnt.Visible = true;
                    }
                    break;
                case ConstMgr.DatabaseTag:
                case ConstMgr.SingleDatabaseTag:
                    docStatus = RuntimeMongoDbContext.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
                    cmbChartField.Visible = true;
                    chartResult.Visible = true;

                    cmbChartField.Items.Add("AverageObjectSize");
                    cmbChartField.Items.Add("DataSize");
                    cmbChartField.Items.Add("ExtentCount");
                    cmbChartField.Items.Add("IndexCount");
                    cmbChartField.Items.Add("LastExtentSize");
                    //MaxDocuments仅在CapedCollection时候有效
                    //cmbChartField.Items.Add("MaxDocuments");
                    cmbChartField.Items.Add("ObjectCount");
                    cmbChartField.Items.Add("PaddingFactor");
                    cmbChartField.Items.Add("StorageSize");
                    cmbChartField.SelectedIndex = 0;
                    try
                    {
                        RefreshDbStatusChart("StorageSize");
                    }
                    catch (Exception ex)
                    {
                        Utility.ExceptionDeal(ex);
                    }
                    break;
                case ConstMgr.CollectionTag:
                    docStatus = RuntimeMongoDbContext.GetCurrentCollection().GetStats().Response.ToBsonDocument();
                    //图形化初始化
                    chartResult.Visible = true;

                    chartResult.Series.Clear();
                    chartResult.Titles.Clear();
                    var seriesResult = new Series("Usage");
                    var dpDataSize = new DataPoint(0, RuntimeMongoDbContext.GetCurrentCollection().GetStats().DataSize)
                    {
                        LegendText = "DataSize",
                        LegendToolTip = "DataSize",
                        ToolTip = "DataSize"
                    };
                    seriesResult.Points.Add(dpDataSize);

                    var dpTotalIndexSize = new DataPoint(0,
                        RuntimeMongoDbContext.GetCurrentCollection().GetStats().TotalIndexSize)
                    {
                        LegendText = "TotalIndexSize",
                        LegendToolTip = "TotalIndexSize",
                        ToolTip = "TotalIndexSize"
                    };
                    seriesResult.Points.Add(dpTotalIndexSize);

                    var dpFreeSize = new DataPoint(0,
                        RuntimeMongoDbContext.GetCurrentCollection().GetStats().StorageSize -
                        RuntimeMongoDbContext.GetCurrentCollection().GetStats().TotalIndexSize -
                        RuntimeMongoDbContext.GetCurrentCollection().GetStats().DataSize)
                    {
                        LegendText = "FreeSize",
                        LegendToolTip = "FreeSize",
                        ToolTip = "FreeSize"
                    };
                    seriesResult.Points.Add(dpFreeSize);

                    seriesResult.ChartType = SeriesChartType.Pie;
                    chartResult.Series.Add(seriesResult);
                    chartResult.Titles.Add("Usage");

                    break;
                default:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        docStatus =
                            CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        trvStatus.Height = trvStatus.Height*2;
                    }
                    break;
            }
            GuiConfig.Translateform(this);
            UiHelper.FillDataToTreeView(strType, trvStatus, docStatus);
            trvStatus.DatatreeView.Nodes[0].Expand();
        }

        private void btnOpCnt_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmServerMonitor(), true, true);
        }

        private void RefreshDbStatusChart(string strField)
        {
            //图形化初始化
            chartResult.Series.Clear();
            chartResult.Titles.Clear();
            var seriesResult = new Series(strField);
            foreach (var colName in RuntimeMongoDbContext.GetCurrentDataBase().GetCollectionNames())
            {
                DataPoint colPoint;
                switch (strField)
                {
                    case "AverageObjectSize":
                        try
                        {
                            //如果没有任何对象的时候，平均值无法取得
                            colPoint = new DataPoint(0,
                                RuntimeMongoDbContext.GetCurrentDataBase()
                                    .GetCollection(colName)
                                    .GetStats()
                                    .AverageObjectSize);
                        }
                        catch (Exception ex)
                        {
                            colPoint = new DataPoint(0, 0);
                            Utility.ExceptionDeal(ex);
                        }
                        break;
                    case "DataSize":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().DataSize);
                        break;
                    case "ExtentCount":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().ExtentCount);
                        break;
                    //case "Flags":
                    //    ColPoint = new DataPoint(0, MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase().GetCollection(colName).GetStats().Flags);
                    //    break;
                    case "IndexCount":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().IndexCount);
                        break;
                    case "LastExtentSize":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().LastExtentSize);
                        break;
                    //case "MaxDocuments":
                    //    仅在CappedCollection时候有效 
                    //    ColPoint = new DataPoint(0, MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase().GetCollection(colName).GetStats().MaxDocuments);
                    //    break;
                    case "ObjectCount":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().ObjectCount);
                        break;
                    case "PaddingFactor":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().PaddingFactor);
                        break;
                    case "StorageSize":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().StorageSize);
                        break;
                    default:
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().StorageSize);
                        break;
                }

                colPoint.LegendText = colName;
                colPoint.LabelToolTip = colName;
                colPoint.ToolTip = colName;
                seriesResult.Points.Add(colPoint);
            }
            //图形化加载

            seriesResult.ChartType = SeriesChartType.Pie;
            chartResult.Series.Add(seriesResult);
            chartResult.Titles.Add(strField);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbChartField_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strType = RuntimeMongoDbContext.SelectTagType;
            switch (strType)
            {
                case ConstMgr.DatabaseTag:
                case ConstMgr.SingleDatabaseTag:
                    try
                    {
                        RefreshDbStatusChart(cmbChartField.Text);
                    }
                    catch (Exception ex)
                    {
                        Utility.ExceptionDeal(ex);
                    }
                    break;
            }
        }
    }
}