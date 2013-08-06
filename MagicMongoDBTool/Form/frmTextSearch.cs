using MongoDB.Driver;
using System;
using MagicMongoDBTool.Module;
using MagicMongoDBTool;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class frmTextSearch : System.Windows.Forms.Form
    {
        public frmTextSearch()
        {
            InitializeComponent();
            //加载语言列表
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("None");
            foreach (var item in Enum.GetValues(typeof(MongoDBHelper.TextSearchLanguage)))
            {
                cmbLanguage.Items.Add(item.ToString());
            }
            cmbLanguage.SelectedIndex = 0;
        }
        /// <summary>
        /// 全文检索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ///检索文法： http://docs.mongodb.org/manual/reference/command/text/#text-search-languages
            ///检索关键字
            var TextSearchOption = new BsonDocument().Add(new BsonElement("search", txtKey.Text));
            ///语言
            if (cmbLanguage.SelectedIndex != 0){
                TextSearchOption.Add(new BsonElement("language", cmbLanguage.Text));
            }
            ///返回数限制
            TextSearchOption.Add(new BsonElement("limit", (BsonValue)NUDLimit.Value));
            CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("text", SystemManager.GetCurrentCollection(),TextSearchOption);
            MongoDBHelper.FillDataToTreeView("Text Search Result", trvResult, SearchResult.Response);
        }
        /// <summary>
        /// 增加链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRef_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://docs.mongodb.org/manual/reference/command/text/#text-search-languages");
        }
    }
}
