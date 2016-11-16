using Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    public partial class frmCreateCollection : Form
    {
        public string CollectionName;
        public bool Result;
        public string StrSvrPathWithTag;
        public TreeNode TreeNode;

        public frmCreateCollection()
        {
            InitializeComponent();
        }

        private void frmCreateCollection_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                Text = GuiConfig.GetText(TextType.CreateNewCollection);
                lblCollectionName.Text = GuiConfig.GetText(TextType.CollectionStatusCollectionName);
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
                chkIsCapped.Text = GuiConfig.GetText(TextType.CollectionStatusIsCapped);
                lblMaxDocument.Text = GuiConfig.GetText(TextType.CollectionStatusMaxDocuments);
                lblMaxSize.Text = GuiConfig.GetText(TextType.CollectionStatusMaxSize);
                chkIsAutoIndexId.Text = GuiConfig.GetText(TextType.CollectionStatusIsAutoIndexId);
            }

            //Difference between with long and decimal.....
            numMaxDocument.Maximum = decimal.MaxValue;
            numMaxSize.Maximum = decimal.MaxValue;
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            if (txtCollectionName.Text == string.Empty) return;
            CollectionName = txtCollectionName.Text.Trim();
            try
            {
                string errMessage;
                RuntimeMongoDbContext.GetCurrentDataBase().IsCollectionNameValid(txtCollectionName.Text, out errMessage);
                if (errMessage != null)
                {
                    MyMessageBox.ShowMessage("Create Collection", "Argument Exception", errMessage, true);
                    return;
                }
                var option = new CollectionOptionsBuilder();
                if (chkIsCapped.Checked)
                {
                    if (numMaxSize.Value == 0 || numMaxDocument.Value == 0)
                    {
                        MyMessageBox.ShowMessage("Create Collection", "Argument Exception", "Please Input MaxSize Or MaxDocument When IsCapped", true);
                        return;
                    }
                    option.SetCapped(chkIsCapped.Checked);
                    if (numMaxSize.Value != 0) option.SetMaxSize((long)numMaxSize.Value);
                    if (numMaxDocument.Value != 0) option.SetMaxDocuments((long)numMaxDocument.Value);
                }

                //CappedCollection Default is AutoIndexId After MongoDB 2.2.2
                option.SetAutoIndexId(chkIsAutoIndexId.Checked);

                if (chkValidation.Checked)
                {
                    //Start From MongoDB 3.2.0
                    BsonDocument query = BsonSerializer.Deserialize<BsonDocument>(txtValidation.Text);
                    QueryDocument queryDoc = new QueryDocument(query);
                    option.SetValidator(queryDoc);
                    //Validation Level
                    if (radLevel_off.Checked) option.SetValidationLevel(DocumentValidationLevel.Off);
                    if (radLevel_strict.Checked) option.SetValidationLevel(DocumentValidationLevel.Strict);
                    if (radLevel_moderate.Checked) option.SetValidationLevel(DocumentValidationLevel.Moderate);
                    //Validation Action
                    if (radAction_error.Checked) option.SetValidationAction(DocumentValidationAction.Error);
                    if (radAction_warn.Checked) option.SetValidationAction(DocumentValidationAction.Warn);
                }
                if (mCollation != null) option.SetCollation(mCollation);
                Result = Operater.CreateCollectionWithOptions(StrSvrPathWithTag, txtCollectionName.Text,
                    option, RuntimeMongoDbContext.GetCurrentDataBase());

                Close();
            }
            catch (ArgumentException ex)
            {
                Utility.ExceptionDeal(ex, "Create MongoDatabase", "Argument Exception");
                Result = false;
            }
        }

        /// <summary>
        ///     Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     CappedCollections官方说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkCappedCollections_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://docs.mongodb.org/manual/core/capped-collections/");
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            try
            {
                BsonDocument newdoc;
                newdoc = BsonDocument.Parse(txtValidation.Text);
                UiHelper.FillDataToTreeView("InsertDocument", trvNewDocument, newdoc);
                trvNewDocument.TreeView.ExpandAll();
                txtValidation.Text = newdoc.ToJson(MongoHelper.JsonWriterSettings);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     排序规则
        /// </summary>
        Collation mCollation = null;

        private void btnCollation_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateCollation();
            UIAssistant.OpenModalForm(frm, false, true);
            if (frm.mCollation != null)
            {
                mCollation = frm.mCollation;
                UiHelper.FillDataToTreeView("Collation", trvCollation, mCollation.ToBsonDocument());

            }
        }
    }
}