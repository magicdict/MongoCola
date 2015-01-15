using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;

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
            foreach (var item in AggregationHelper.GetComparisonfunction())
            {
                cmbComparisonfunction.Items.Add(item);
            }
            if (RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                foreach (var item in Utility.GetCollectionSchame(RuntimeMongoDBContext.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }
        }
    }
}