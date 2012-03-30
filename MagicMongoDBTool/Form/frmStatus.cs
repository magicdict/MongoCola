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
                    break;
                case MongoDBHelper.COLLECTION_TAG:
                    cr = SystemManager.GetCurrentCollection().GetStats().Response.ToBsonDocument();
                    break;
                default:
                    if (SystemManager.GetCurrentServerConfig().LoginAsAdmin)
                    {
                        cr = MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command, SystemManager.GetCurrentServer()).Response;
                    }
                    break;
            }
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            }
            SrvDocList.Add(cr);
            MongoDBHelper.FillDataToTreeView(strType, this.trvStatus, SrvDocList, 0);
            this.trvStatus.DatatreeView.Nodes[0].Expand();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
