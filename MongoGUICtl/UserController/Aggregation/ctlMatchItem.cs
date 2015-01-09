using System;
using System.Windows.Forms;
using MongoCola.Module;
using MongoDB.Bson;
using MongoUtility.Aggregation;

namespace MongoGUICtl
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
            foreach (string item in AggregationHelper.GetComparisonfunction())
            {
                cmbComparisonfunction.Items.Add(item);
            }
            if (MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                foreach (string item in MongoUtility.Basic.Utility.GetCollectionSchame(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }
        }
    }
}