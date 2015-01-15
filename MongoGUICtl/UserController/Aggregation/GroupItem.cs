using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;

namespace MongoGUICtl
{
    public partial class GroupItem : UserControl
    {
        public GroupItem()
        {
            InitializeComponent();
        }

        public BsonElement getGroupItem()
        {
            //_id : "$author",
            //docsPerAuthor : { $sum : 1 },
            //viewsPerAuthor : { $sum : "$pageViews" }
            var GroupFuncItem = new BsonDocument(cmbGroupFunction.Text, cmbGroupValue.Text);
            return new BsonElement(txtProject.Text, GroupFuncItem);
        }

        private void GroupItem_Load(object sender, EventArgs e)
        {
            foreach (string item in AggregationHelper.GetGroupfunction())
            {
                cmbGroupFunction.Items.Add(item);
            }
            if (MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                cmbGroupValue.Items.Add("1");
                foreach (string item in MongoUtility.Basic.Utility.GetCollectionSchame(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection()))
                {
                    cmbGroupFunction.Items.Add("$" + item);
                    cmbGroupValue.Items.Add("$" + item);
                }
            }
        }
    }
}