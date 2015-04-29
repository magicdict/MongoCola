using System;
using System.Diagnostics;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;

namespace FunctionForm.Aggregation
{
    public partial class FrmTextSearch : Form
    {
        private BsonDocument _result;

        public FrmTextSearch()
        {
            InitializeComponent();
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                btnSearch.Text = GuiConfig.GetText(TextType.CommonSearch);
                cmdSave.Text = GuiConfig.GetText(TextType.CommonSave);
                cmdClose.Text = GuiConfig.GetText(TextType.CommonClose);
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
            var textSearchOption = new BsonDocument().Add(new BsonElement("search", txtKey.Text));
            //语言
            if (cmbLanguage.SelectedIndex != 0)
            {
                textSearchOption.Add(new BsonElement("language", cmbLanguage.Text));
            }
            //返回数限制
            textSearchOption.Add(new BsonElement("limit", (BsonValue) NUDLimit.Value));
            try
            {
                var searchResult = CommandHelper.ExecuteMongoColCommand("text",
                    RuntimeMongoDbContext.GetCurrentCollection(), textSearchOption);
                _result = searchResult.Response;
                UIHelper.FillDataToTreeView("Text Search Result", trvResult, _result);
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
                MongoHelper.SaveResultToJSonFile(_result, dialog.FileName);
            }
        }
    }
}