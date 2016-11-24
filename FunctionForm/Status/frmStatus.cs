using Common;
using MongoDB.Bson;
using MongoGUICtl;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FunctionForm.Status
{
    public partial class FrmStatus : Form
    {
        /// <summary>
        ///     初始状态退避
        /// </summary>
        private bool tempIsDisplayNumberWithKSystem = true;

        public FrmStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStatus_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.KeyInfo);
            GuiConfig.Translateform(this);
            var strType = RuntimeMongoDbContext.SelectTagType;
            var docStatus = new BsonDocument();
            cmbChartField.Visible = false;
            chartResult.Visible = false;
            tempIsDisplayNumberWithKSystem = CtlTreeViewColumns.IsDisplayNumberWithKSystem;
            CtlTreeViewColumns.IsDisplayNumberWithKSystem = true;

            switch (strType)
            {
                case ConstMgr.ServerTag:
                case ConstMgr.SingleDbServerTag:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        var StatusList = new List<BsonDocument>();
                        var Status =  CommandExecute.ExecuteMongoSvrCommand(DataBaseCommand.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        StatusList.Add(Status);
                        try
                        {
                            var ServerDesripter = MongoUtility.ToolKit.MongoHelper.GetCurrentServerDescription();
                            StatusList.Add(ServerDesripter);
                        }
                        catch (Exception)
                        {
                            //Repl的时候，无法获得                            
                        }
                        UiHelper.FillDataToTreeView(strType, trvStatus, StatusList, 0);
                        trvStatus.Height = trvStatus.Height * 2;
                        trvStatus.DatatreeView.Nodes[0].Expand();
                        trvStatus.DatatreeView.Nodes[1].Expand();
                        return;
                    }
                    break;
                case ConstMgr.DatabaseTag:
                case ConstMgr.SingleDatabaseTag:
                    docStatus = RuntimeMongoDbContext.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
                    cmbChartField.Visible = true;
                    chartResult.Visible = true;
                    //{{ "db" : "aaaa", 
                    //   "collections" : 8, 
                    //   "objects" : 0, 
                    //   "avgObjSize" : 0.0, 
                    //   "dataSize" : 0.0, 
                    //   "storageSize" : 32768.0, 
                    //   "numExtents" : 0, 
                    //   "indexes" : 8, 
                    //   "indexSize" : 32768.0, 
                    //   "ok" : 1.0 }}
                    var statuspoint = docStatus.AsBsonDocument;
                    //这里其实应该看Collection的Status，不同的引擎所拥有的状态不一样
                    if (statuspoint.Contains("avgObjSize")) cmbChartField.Items.Add("AverageObjectSize");
                    if (statuspoint.Contains("dataSize")) cmbChartField.Items.Add("DataSize");
                    if (statuspoint.Contains("extentCount")) cmbChartField.Items.Add("ExtentCount");
                    if (statuspoint.Contains("indexes")) cmbChartField.Items.Add("IndexCount");
                    if (statuspoint.Contains("lastExtentSize")) cmbChartField.Items.Add("LastExtentSize");
                    //MaxDocuments仅在CapedCollection时候有效
                    if (statuspoint.Contains("MaxDocuments")) cmbChartField.Items.Add("MaxDocuments");
                    if (statuspoint.Contains("ObjectCount")) cmbChartField.Items.Add("ObjectCount");
                    if (statuspoint.Contains("PaddingFactor")) cmbChartField.Items.Add("PaddingFactor");
                    if (statuspoint.Contains("storageSize")) cmbChartField.Items.Add("StorageSize");
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
                    //TODO:这里无法看到Collection的Document Validation信息。
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
                    chartResult.Titles.Add(new Title("Usage"));

                    break;
                default:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        docStatus =
                            CommandExecute.ExecuteMongoSvrCommand(DataBaseCommand.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        trvStatus.Height = trvStatus.Height * 2;
                    }
                    break;
            }
            UiHelper.FillDataToTreeView(strType, trvStatus, docStatus);
            trvStatus.DatatreeView.Nodes[0].Expand();
        }


        private void RefreshDbStatusChart(string strField)
        {
            //图形化初始化
            chartResult.Series.Clear();
            chartResult.Titles.Clear();
            var seriesResult = new Series(strField);
            var viewlist = RuntimeMongoDbContext.GetCurrentDBViewNameList();
            foreach (var colName in RuntimeMongoDbContext.GetCurrentDataBase().GetCollectionNames())
            {
                if (viewlist.Contains(colName)) continue;
                DataPoint colPoint = new DataPoint(0, 0);
                switch (strField)
                {
                    case "AverageObjectSize":
                        if (RuntimeMongoDbContext.GetCurrentDataBase()
                            .GetCollection(colName).GetStats().ObjectCount > 0)
                        {
                            //如果没有任何对象的时候，平均值无法取得
                            colPoint = new DataPoint(0, RuntimeMongoDbContext.GetCurrentDataBase()
                                    .GetCollection(colName)
                                    .GetStats()
                                    .AverageObjectSize);
                        }
                        else
                        {
                            colPoint = new DataPoint(0, 0);
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
                    case "IndexCount":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().IndexCount);
                        break;
                    case "LastExtentSize":
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().LastExtentSize);
                        break;
                    case "MaxDocuments":
                        //    仅在CappedCollection时候有效 
                        colPoint = new DataPoint(0,
                            RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(colName).GetStats().MaxDocuments);
                        break;
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
            chartResult.Titles.Add(new Title(strField));
        }


        /// <summary>
        ///     切换状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///     修改为初始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStatus_Closing(object sender, FormClosingEventArgs e)
        {
            //修改为初始状态
            CtlTreeViewColumns.IsDisplayNumberWithKSystem = tempIsDisplayNumberWithKSystem;
        }
        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}