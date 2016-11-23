using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Status
{
    public partial class FrmStatusMono : Form
    {
        public FrmStatusMono()
        {
            InitializeComponent();
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            var strType = RuntimeMongoDbContext.SelectTagType;
            var docStatus = new BsonDocument();
            switch (strType)
            {
                case ConstMgr.ServerTag:
                case ConstMgr.SingleDbServerTag:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        docStatus =
                            CommandExecute.ExecuteMongoSvrCommand(DataBaseCommand.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        trvStatus.Height = trvStatus.Height*2;
                    }
                    break;
                case ConstMgr.DatabaseTag:
                case ConstMgr.SingleDatabaseTag:
                    docStatus = RuntimeMongoDbContext.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
                    break;
                case ConstMgr.CollectionTag:
                    //TODO:这里无法看到Collection的Document Validation信息。
                    docStatus = RuntimeMongoDbContext.GetCurrentCollection().GetStats().Response.ToBsonDocument();

                    break;
                default:
                    if (RuntimeMongoDbContext.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        docStatus =
                            CommandExecute.ExecuteMongoSvrCommand(DataBaseCommand.ServerStatusCommand,
                                RuntimeMongoDbContext.GetCurrentServer()).Response;
                        trvStatus.Height = trvStatus.Height*2;
                    }
                    break;
            }
            GuiConfig.Translateform(this);
            UiHelper.FillDataToTreeView(strType, trvStatus, docStatus);
            trvStatus.DatatreeView.Nodes[0].Expand();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}