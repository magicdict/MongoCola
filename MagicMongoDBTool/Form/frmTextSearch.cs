using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
namespace MagicMongoDBTool
{
    public partial class frmTextSearch : System.Windows.Forms.Form
    {
        BsonDocument Result;
        public frmTextSearch()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.btnSearch.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Search);
                this.cmdSave.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
                this.cmdClose.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
            }
            //加载语言列表
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("None");
            foreach (var item in Enum.GetValues(typeof(MongoDBHelper.TextSearchLanguage)))
            {
                cmbLanguage.Items.Add(item.ToString());
            }
            cmbLanguage.SelectedIndex = 0;
            this.cmdSave.Enabled = false;
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
            if (cmbLanguage.SelectedIndex != 0)
            {
                TextSearchOption.Add(new BsonElement("language", cmbLanguage.Text));
            }
            ///返回数限制
            TextSearchOption.Add(new BsonElement("limit", (BsonValue)NUDLimit.Value));
            try
            {
                CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("text", SystemManager.GetCurrentCollection(), TextSearchOption);
                Result = SearchResult.Response;
                MongoDBHelper.FillDataToTreeView("Text Search Result", trvResult, Result);
                cmdSave.Enabled = true;
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex); 
            }
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
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SystemManager.SaveResultToJSonFile(Result);
        }
    }
}
