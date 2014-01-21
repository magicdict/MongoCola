using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool
{
    public partial class frmValidate : Form
    {
        private BsonDocument Result;

        public frmValidate()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                cmdSave.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
                cmdClose.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
                Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
                cmdValidate.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
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
            BsonDocument TextSearchOption = new BsonDocument().Add(new BsonElement("full", chkFull.Checked.ToString()));
            CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("validate",
                SystemManager.GetCurrentCollection(), TextSearchOption);
            Result = SearchResult.Response;
            MongoDBHelper.FillDataToTreeView("Validate Result", trvResult, Result);
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
            SystemManager.SaveResultToJSonFile(Result);
        }
    }
}