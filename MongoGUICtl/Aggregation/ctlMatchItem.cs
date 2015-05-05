using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.ToolKit;

namespace MongoGUICtl.Aggregation
{
    public partial class CtlMatchItem : UserControl
    {
        public CtlMatchItem()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     获取MatchItem
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetMatchItem()
        {
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                return new BsonDocument(cmbField.Text,
                    new BsonDocument(cmbComparisonfunction.Text, MatchValue.GetValue()));
            }
            return null;
        }

        private void ctlMatchItem_Load(object sender, EventArgs e)
        {
            foreach (var item in AggregationHelper.GetComparisonfunction())
            {
                cmbComparisonfunction.Items.Add(item);
            }
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                foreach (
                    var item in
                        MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection())
                    )
                {
                    cmbField.Items.Add(item);
                }
            }
        }
    }
}