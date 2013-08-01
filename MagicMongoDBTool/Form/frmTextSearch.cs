using MongoDB.Driver;
using System;
using MagicMongoDBTool.Module;
using MagicMongoDBTool;
namespace MagicMongoDBTool
{
    public partial class frmTextSearch : System.Windows.Forms.Form
    {
        public frmTextSearch()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 全文检索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("text", SystemManager.GetCurrentCollection(),
                new MongoDB.Bson.BsonDocument().Add(new MongoDB.Bson.BsonElement("search", txtKey.Text)));
            MongoDBHelper.FillDataToTreeView("Text Search Result", trvResult, SearchResult.Response);
        }
    }
}
