using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

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

            String strType = SystemManager.SelectTagType;
            List<BsonDocument> SrvDocList = new List<BsonDocument>();
            BsonDocument cr;
            switch (strType)
            {
                case MongoDBHelper.SERVICE_TAG:
                case MongoDBHelper.SINGLE_DB_SERVICE_TAG:
                    cr = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentService()).Response;
                    break;
                case MongoDBHelper.DATABASE_TAG:
                case MongoDBHelper.SINGLE_DATABASE_TAG:
                    cr = SystemManager.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
                    break;
                case MongoDBHelper.COLLECTION_TAG:
                    cr = SystemManager.GetCurrentCollection().GetStats().Response.ToBsonDocument();
                    break;
                default:
                    cr = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentService()).Response;
                    break;
            }
            SrvDocList.Add(cr);
            MongoDBHelper.FillDataToTreeView(strType, this.trvStatus, SrvDocList, 0);
            this.trvStatus.Nodes[0].Expand();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
