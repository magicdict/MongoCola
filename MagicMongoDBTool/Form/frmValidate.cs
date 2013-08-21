using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.IO;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmValidate : Form
    {
        BsonDocument Result;
        public frmValidate()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.cmdSave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
                this.cmdClose.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Close);
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
                this.cmdValidate.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
            }
            cmdSave.Enabled = false;
        }
        /// <summary>
        /// Run Validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            var TextSearchOption = new BsonDocument().Add(new BsonElement("full", chkFull.Checked.ToString()));
            CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("validate", SystemManager.GetCurrentCollection(), TextSearchOption);
            Result = SearchResult.Response;
            MongoDBHelper.FillDataToTreeView("Validate Result", trvResult, Result);
            cmdSave.Enabled = true;
        }
        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SystemManager.SaveResultToJSonFile(Result);
        }

    }
}
