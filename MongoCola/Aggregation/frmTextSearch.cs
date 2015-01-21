using System;
using System.Diagnostics;
using System.Windows.Forms;
using SystemUtility;
using MongoDB.Bson;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola.Aggregation
{
    public partial class frmTextSearch : Form
    {
        private BsonDocument Result;

        public frmTextSearch()
        {
            InitializeComponent();
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                btnSearch.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Search);
                cmdSave.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
                cmdClose.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
            }
            //加载语言列表
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add("None");
            foreach (var item in Enum.GetValues(typeof (EnumMgr.TextSearchLanguage)))
            {
                cmbLanguage.Items.Add(item.ToString());
            }
            cmbLanguage.SelectedIndex = 0;
            cmdSave.Enabled = false;
        }

        /// <summary>
        ///     全文检索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //检索文法： http://docs.mongodb.org/manual/reference/command/text/#text-search-languages
            //检索关键字
            var TextSearchOption = new BsonDocument().Add(new BsonElement("search", txtKey.Text));
            //语言
            if (cmbLanguage.SelectedIndex != 0)
            {
                TextSearchOption.Add(new BsonElement("language", cmbLanguage.Text));
            }
            //返回数限制
            TextSearchOption.Add(new BsonElement("limit", (BsonValue) NUDLimit.Value));
            try
            {
                var SearchResult = CommandHelper.ExecuteMongoColCommand("text",
                    RuntimeMongoDBContext.GetCurrentCollection(), TextSearchOption);
                Result = SearchResult.Response;
                UIHelper.FillDataToTreeView("Text Search Result", trvResult, Result);
                cmdSave.Enabled = true;
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     增加链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://docs.mongodb.org/manual/reference/command/text/#text-search-languages");
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = Utility.JsFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MongoUtility.Basic.Utility.SaveResultToJSonFile(Result, dialog.FileName);
            }
        }
    }
}