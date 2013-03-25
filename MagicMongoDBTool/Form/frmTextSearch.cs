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
            var textSearchCommand = new CommandDocument
                {
                    { "text", SystemManager.GetCurrentCollection().Name },
                    { "search", txtKey.Text }
                };
            CommandResult SearchResult = SystemManager.GetCurrentCollection().Database.RunCommand(textSearchCommand);
            MongoDBHelper.FillDataToTreeView("MapReduce Result", trvResult, SearchResult.Response);
        }
    }
}
