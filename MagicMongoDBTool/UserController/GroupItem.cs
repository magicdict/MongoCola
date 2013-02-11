using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System;
using System.Windows.Forms;
namespace MagicMongoDBTool
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
            BsonDocument GroupFuncItem = new BsonDocument(cmbGroupFunction.Text, cmbGroupValue.Text);
            return new BsonElement(txtProject.Text,GroupFuncItem);
        }
        private void GroupItem_Load(object sender, EventArgs e)
        {
            foreach (string item in MongoDBHelper.getGroupfunction())
            {
                cmbGroupFunction.Items.Add(item);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                cmbGroupValue.Items.Add("1");
                foreach (var item in MongoDBHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbGroupFunction.Items.Add("$" + item);
                    cmbGroupValue.Items.Add("$" + item);
                }
            }
        }
    }
}
