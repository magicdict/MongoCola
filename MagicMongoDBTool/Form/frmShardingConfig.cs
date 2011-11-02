using System;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmShardingConfig : QLFUI.QLFForm
    {
        public frmShardingConfig()
        {
            InitializeComponent();
        }
        private MongoServer _mongoSvr;
        private void frmShardingConfig_Load(object sender, EventArgs e)
        {
            _mongoSvr = SystemManager.GetCurrentService();
            MongoDatabase mongoDB = _mongoSvr.GetDatabase("config");
            MongoCollection mongoCol = mongoDB.GetCollection("databases");
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                if (item.GetValue("_id") != "admin")
                {
                    cmbDataBase.Items.Add(item.GetValue("_id"));
                };
            }
        }

        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MongoDatabase mongoDB = _mongoSvr.GetDatabase(cmbDataBase.Text);
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
                MongoDatabase mongoDB = _mongoSvr.GetDatabase(cmbDataBase.Text);
                cmbKeyList.Items.Clear();
                cmbKeyList.Text = string.Empty;
                foreach (var Indexitem in mongoDB.GetCollection(cmbCollection.Text).GetIndexes())
                {
                    cmbKeyList.Items.Add(Indexitem[1]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cmdEnableSharding_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.EnableSharding(_mongoSvr, cmbDataBase.Text);
        }
        private void cmdCollectionSharding_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.ShardCollection(_mongoSvr, cmbDataBase.Text + "." + cmbCollection.Text, cmbKeyList.SelectedItem.ToBsonDocument());
        }


    }
}
