using System;
using System.Windows.Forms;
using SystemUtility;
using Common.Logic;
using MongoDB.Bson;
using MongoGUICtl;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;

namespace MongoCola
{
    public partial class frmValidate : Form
    {
        private BsonDocument Result;

        public frmValidate()
        {
            InitializeComponent();
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                cmdSave.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
                cmdClose.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
                Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Validate);
                cmdValidate.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Validate);
            }
            cmdSave.Enabled = false;
        }

        /// <summary>
        ///     Run Validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            var TextSearchOption = new BsonDocument().Add(new BsonElement("full", chkFull.Checked.ToString()));
            var SearchResult = CommandHelper.ExecuteMongoColCommand("validate",
                RuntimeMongoDBContext.GetCurrentCollection(), TextSearchOption);
            Result = SearchResult.Response;
            UIHelper.FillDataToTreeView("Validate Result", trvResult, Result);
            cmdSave.Enabled = true;
        }

        /// <summary>
        ///     Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Save
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