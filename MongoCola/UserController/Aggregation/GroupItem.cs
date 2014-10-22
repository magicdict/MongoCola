using System;
using System.Windows.Forms;
using MongoCola.Module;
using MongoDB.Bson;
using Common.Aggregation;

namespace MongoCola
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
            if (SystemManager.GetCurrentCollection() != null)
            {
                cmbGroupValue.Items.Add("1");
                foreach (string item in MongoDbHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbGroupFunction.Items.Add("$" + item);
                    cmbGroupValue.Items.Add("$" + item);
                }
            }
        }
    }
}