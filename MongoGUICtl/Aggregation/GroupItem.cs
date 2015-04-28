using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoGUICtl.Aggregation
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
            foreach (var item in AggregationHelper.GetGroupfunction())
            {
                cmbGroupFunction.Items.Add(item);
            }
            if (RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                cmbGroupValue.Items.Add("1");
                foreach (var item in MongoUtility.Basic.MongoUtility.GetCollectionSchame(RuntimeMongoDBContext.GetCurrentCollection()))
                {
                    cmbGroupFunction.Items.Add("$" + item);
                    cmbGroupValue.Items.Add("$" + item);
                }
            }
        }
    }
}