using MongoDB.Bson;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using System;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlSortItem : UserControl
    {
        public ctlSortItem()
        {
            InitializeComponent();
        }

        private void ctlSortItem_Load(object sender, EventArgs e)
        {
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                foreach (var item in MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection()))
                {
                    cmbField.Items.Add(item);
                }
            }
            cmbSort.Items.Clear();
            cmbSort.Items.Add("Asce");
            cmbSort.Items.Add("Desc");
            cmbSort.Items.Add("TextScore(Desc)");
        }
        /// <summary>
        ///     获得排序项目
        /// </summary>
        /// <returns></returns>
        public BsonElement GetSortItem()
        {
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                if (cmbSort.Text == "Asce")
                {
                    return new BsonElement(cmbField.Text, 1);
                }
                if (cmbSort.Text == "Desc")
                {
                    return new BsonElement(cmbField.Text, -1);
                }
                if (cmbSort.Text == "TextScore(Desc)")
                {
                    return new BsonElement(cmbField.Text, new BsonDocument("$meta", "textScore"));
                }
            }
            return new BsonElement(string.Empty, string.Empty);
        }
    }
}
