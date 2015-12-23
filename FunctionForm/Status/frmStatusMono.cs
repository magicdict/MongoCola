using System;
using System.Windows.Forms;
using ZedGraph;
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
	public partial class frmStatusMono : Form
    {
		public frmStatusMono()
        {
            InitializeComponent();
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            var strType = RuntimeMongoDbContext.SelectTagType;
            var docStatus = new BsonDocument();
            cmbChartField.Visible = false;
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
                    //TODO:这里无法看到Collection的Document Validation信息。
                    docStatus = RuntimeMongoDbContext.GetCurrentCollection().GetStats().Response.ToBsonDocument();

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
			cmbChartField.Visible = false;
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