using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.ToolKit;

namespace MongoGUICtl.Aggregation
{
    public partial class GroupItem : UserControl
    {
        public GroupItem()
        {
            InitializeComponent();
        }

        public BsonElement GetGroupItem()
        {
            //_id : "$author",
            //docsPerAuthor : { $sum : 1 },
            //viewsPerAuthor : { $sum : "$pageViews" }
            var groupFuncItem = new BsonDocument(cmbGroupFunction.Text, cmbGroupValue.Text);
            return new BsonElement(txtProject.Text, groupFuncItem);
        }

        private void GroupItem_Load(object sender, EventArgs e)
        {
            foreach (var item in AggregationHelper.GetGroupfunction())
            {
                cmbGroupFunction.Items.Add(item);
            }
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                cmbGroupValue.Items.Add("1");
                foreach (
                    var item in
                        MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection())
                    )
                {
                    cmbGroupFunction.Items.Add("$" + item);
                    cmbGroupValue.Items.Add("$" + item);
                }
            }
        }
    }
}