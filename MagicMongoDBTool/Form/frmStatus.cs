using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MagicMongoDBTool
{
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            this.Icon = GetSystemIcon.ConvertImgToIcon(MagicMongoDBTool.Properties.Resources.KeyInfo);
            String strType = SystemManager.SelectTagType;
            List<BsonDocument> SrvDocList = new List<BsonDocument>();
            BsonDocument cr = new BsonDocument();
            switch (strType)
            {
                case MongoDBHelper.SERVER_TAG:
                case MongoDBHelper.SINGLE_DB_SERVER_TAG:
                    if (SystemManager.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        cr = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentServer()).Response;
                    }
                    break;
                case MongoDBHelper.DATABASE_TAG:
                case MongoDBHelper.SINGLE_DATABASE_TAG:
                    cr = SystemManager.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
                    cmbChartField.Items.Add("AverageObjectSize");
                    cmbChartField.Items.Add("DataSize");
                    cmbChartField.Items.Add("ExtentCount");
                    cmbChartField.Items.Add("IndexCount");
                    cmbChartField.Items.Add("LastExtentSize");
                    //cmbChartField.Items.Add("MaxDocuments");
                    cmbChartField.Items.Add("ObjectCount");
                    cmbChartField.Items.Add("PaddingFactor");
                    cmbChartField.Items.Add("StorageSize");
                    cmbChartField.SelectedIndex = 0;
                    RefreshDBStatusChart("StorageSize");
                    break;
                case MongoDBHelper.COLLECTION_TAG:
                    cr = SystemManager.GetCurrentCollection().GetStats().Response.ToBsonDocument();
                    cmbChartField.Visible = false;
                    //图形化初始化
                    chartResult.Series.Clear();
                    chartResult.Titles.Clear();
                    Series SeriesResult = new Series("Usage");
                    DataPoint dpDataSize = new DataPoint(0, SystemManager.GetCurrentCollection().GetStats().DataSize);
                    dpDataSize.LegendText = "DataSize";
                    dpDataSize.LegendToolTip = "DataSize";
                    dpDataSize.ToolTip = "DataSize";
                    SeriesResult.Points.Add(dpDataSize);

                    DataPoint dpTotalIndexSize = new DataPoint(0, SystemManager.GetCurrentCollection().GetStats().TotalIndexSize);
                    dpTotalIndexSize.LegendText = "TotalIndexSize";
                    dpTotalIndexSize.LegendToolTip = "TotalIndexSize";
                    dpTotalIndexSize.ToolTip = "TotalIndexSize";
                    SeriesResult.Points.Add(dpTotalIndexSize);

                    DataPoint dpFreeSize = new DataPoint(0, SystemManager.GetCurrentCollection().GetStats().StorageSize - 
                                                               SystemManager.GetCurrentCollection().GetStats().TotalIndexSize - 
                                                               SystemManager.GetCurrentCollection().GetStats().DataSize);
                    dpFreeSize.LegendText = "FreeSize";
                    dpFreeSize.LegendToolTip = "FreeSize";
                    dpFreeSize.ToolTip = "FreeSize";
                    SeriesResult.Points.Add(dpFreeSize);

                    SeriesResult.ChartType = SeriesChartType.Pie;
                    chartResult.Series.Add(SeriesResult);
                    chartResult.Titles.Add("Usage");

                    break;
                default:
                    if (SystemManager.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        cr = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentServer()).Response;
                    }
                    break;
            }
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            }
            SrvDocList.Add(cr);
            MongoDBHelper.FillDataToTreeView(strType, this.trvStatus, SrvDocList, 0);
            this.trvStatus.DatatreeView.Nodes[0].Expand();

        }

        private void RefreshDBStatusChart(String strField)
        {
            //图形化初始化
            chartResult.Series.Clear();
            chartResult.Titles.Clear();
            Series SeriesResult = new Series(strField);
            foreach (String colName in SystemManager.GetCurrentDataBase().GetCollectionNames())
            {
                DataPoint ColPoint;
                switch (strField)
                {
                    case "AverageObjectSize":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().AverageObjectSize);
                        break;
                    case "DataSize":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().DataSize);
                        break;
                    case "ExtentCount":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().ExtentCount);
                        break;
                    //case "Flags":
                    //    ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().Flags);
                    //    break;
                    case "IndexCount":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().IndexCount);
                        break;
                    case "LastExtentSize":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().LastExtentSize);
                        break;
                    //case "MaxDocuments":
                    //    ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().MaxDocuments);
                    //    break;
                    case "ObjectCount":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().ObjectCount);
                        break;
                    case "PaddingFactor":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().PaddingFactor);
                        break;
                    case "StorageSize":
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().StorageSize);
                        break;
                    default:
                        ColPoint = new DataPoint(0, SystemManager.GetCurrentDataBase().GetCollection(colName).GetStats().StorageSize);
                        break;
                }

                ColPoint.LegendText = colName;
                ColPoint.LabelToolTip = colName;
                ColPoint.ToolTip = colName;
                SeriesResult.Points.Add(ColPoint);
            }
            //图形化加载

            SeriesResult.ChartType = SeriesChartType.Pie;
            chartResult.Series.Add(SeriesResult);
            chartResult.Titles.Add(strField);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbChartField_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strType = SystemManager.SelectTagType;
            switch (strType)
            {
                case MongoDBHelper.DATABASE_TAG:
                case MongoDBHelper.SINGLE_DATABASE_TAG:
                    RefreshDBStatusChart(cmbChartField.Text);
                    break;
            }
        }
    }
}
