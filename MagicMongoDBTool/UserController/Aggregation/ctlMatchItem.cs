using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class ctlMatchItem : UserControl
    {
        public ctlMatchItem()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     获取MatchItem
        /// </summary>
        /// <returns></returns>
        public BsonDocument getMatchItem()
        {
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                return new BsonDocument(cmbField.Text,
                    new BsonDocument(cmbComparisonfunction.Text, MatchValue.getValue()));
            }
            return null;
        }

        private void ctlMatchItem_Load(object sender, EventArgs e)
        {
            foreach (string item in MongoDbHelper.GetComparisonfunction())
            {
                cmbComparisonfunction.Items.Add(item);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                foreach (string item in MongoDbHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }
        }
    }
}