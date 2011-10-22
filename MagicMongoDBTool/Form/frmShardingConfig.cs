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
        MongoServer mongosrv;
        private void frmShardingConfig_Load(object sender, EventArgs e)
        {
            mongosrv = SystemManager.getCurrentService();
            MongoDatabase mongoDb = mongosrv.GetDatabase("config");
            MongoCollection mongoCol = mongoDb.GetCollection("databases");
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
                MongoDatabase mongoDb = mongosrv.GetDatabase(cmbDataBase.Text);
                cmbCollection.Items.Clear();
                cmbCollection.Text = String.Empty;
                foreach (var item in mongoDb.GetCollectionNames())
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
                MongoDatabase mongoDb = mongosrv.GetDatabase(cmbDataBase.Text);
                cmbKeyList.Items.Clear();
                cmbKeyList.Text = String.Empty;
                foreach (var Indexitem in mongoDb.GetCollection(cmbCollection.Text).GetIndexes())
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
            MongoDBHelpler.EnableSharding(mongosrv, cmbDataBase.Text);
        }
        private void cmdCollectionSharding_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.shardcollection(mongosrv, cmbDataBase.Text + "." + cmbCollection.Text, cmbKeyList.SelectedItem.ToBsonDocument());
        }

       
    }
}
