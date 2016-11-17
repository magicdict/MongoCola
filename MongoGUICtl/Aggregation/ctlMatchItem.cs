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

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlMatchItem_Load(object sender, EventArgs e)
        {
            Common.UIAssistant.FillComberWithArray(cmbComparisonfunction, AggregationFunc.GetComparisonfunction(), true);
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                foreach (var item in MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }
        }
    }
}