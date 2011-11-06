using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class frmShardingConfig : QLFUI.QLFForm
    {
        public frmShardingConfig()
        {
            InitializeComponent();
        }
        private MongoServer _prmSvr;
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            _prmSvr = SystemManager.GetCurrentService();

            MongoDatabase mongoDB = _prmSvr.GetDatabase("config");
            MongoCollection mongoCol = mongoDB.GetCollection("databases");
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                if (item.GetValue("_id") != "admin")
                {
                    cmbDataBase.Items.Add(item.GetValue("_id"));
                };
            }

            string strPrmKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (!cmbReplsetName.Items.Contains(item.ReplSetName))
                    {
                        cmbReplsetName.Items.Add(item.ReplSetName);
                    }
                }
            }
        }
        private void RefreshSrv()
        {
            lstShard.Items.Clear();
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (item.ReplSetName == cmbReplsetName.Text)
                    {
                        lstShard.Items.Add(item.ConnectionName);
                    }
                }
            }
        }
        private void cmdAddSharding_Click(object sender, EventArgs e)
        {
            List<string> srvKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (string item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            }
            MongoDBHelpler.AddSharding(_prmSvr, cmbReplsetName.Text, srvKeys);
        }

        private void cmbReplsetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSrv();
        }
        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MongoDatabase mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbCollection.Items.Clear();
                cmbCollection.Text = String.Empty;
                foreach (var item in mongoDB.GetCollectionNames())
                {
                    cmbCollection.Items.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cmbCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MongoDatabase mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbKeyList.Items.Clear();
                cmbKeyList.Text = string.Empty;
                foreach (var Indexitem in mongoDB.GetCollection(cmbCollection.Text).GetIndexes())
                {
                    cmbKeyList.Items.Add(Indexitem.Name);
                }
                cmbKeyList.Text = cmbKeyList.Items[0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cmdEnableSharding_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.EnableSharding(_prmSvr, cmbDataBase.Text);
        }
        private void cmdCollectionSharding_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.ShardCollection(_prmSvr, cmbDataBase.Text + "." + cmbCollection.Text, cmbKeyList.SelectedItem.ToBsonDocument());
        }
    }
}
