using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
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
            foreach (var item in Enum.GetValues(typeof(EnumMgr.TextSearchLanguage)))
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
            var result = MongoUtility.Aggregation.QueryHelper.SearchText(txtKey.Text, (int)NUDLimit.Value,
                (cmbLanguage.SelectedIndex == 0) ? "" : cmbLanguage.Text);
            //返回数限制
            try
            {
                UiHelper.FillDataToTreeView("Text Search Result", trvResult, result, 0);
                MessageBox.Show("找到符合条件的结果数：" + result.Count());
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