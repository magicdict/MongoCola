using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class ctlMatchItem : UserControl
    {
        public ctlMatchItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取MatchItem
        /// </summary>
        /// <returns></returns>
        public BsonDocument getMatchItem()
        {
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                return new BsonDocument(cmbField.Text, new BsonDocument(cmbComparisonfunction.Text, MatchValue.getValue()));
            }
            else {
                return null;
            }
        }
        private void ctlMatchItem_Load(object sender, EventArgs e)
        {
            foreach (string item in MongoDBHelper.getComparisonfunction())
            {
                this.cmbComparisonfunction.Items.Add(item);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                foreach (var item in MongoDBHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }

        }
    }
}
