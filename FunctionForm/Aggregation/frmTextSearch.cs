using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    public partial class FrmTextSearch : Form
    {
        public FrmTextSearch()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
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
            //检索文法： 
            //[Before2.6]http://docs.mongodb.org/manual/reference/command/text/#text-search-languages
            //[After2.6]http://docs.mongodb.org/manual/reference/operator/query/text/#op._S_text

            //检索关键字
            IMongoQuery textSearchOption = null;
            //语言
            if (cmbLanguage.SelectedIndex != 0)
            {
                textSearchOption = Query.Text(txtKey.Text,cmbLanguage.Text);
            }
            else
            {
                textSearchOption = Query.Text(txtKey.Text);
            }
            
            //返回数限制
            try
            {
                var _result = RuntimeMongoDbContext.GetCurrentCollection().FindAs<BsonDocument>(textSearchOption);
                UiHelper.FillDataToTreeView("Text Search Result", trvResult, _result.SetLimit((int)NUDLimit.Value).ToList<BsonDocument>(),0);
                //cmdSave.Enabled = true;
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, "请确保具有 Text 类型的索引");
            }
        }
        /// <summary>
        ///     增加链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://docs.mongodb.org/manual/reference/operator/query/text/#op._S_text");
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
                //MongoHelper.SaveResultToJSonFile(_result, dialog.FileName);
            }
        }
    }
}