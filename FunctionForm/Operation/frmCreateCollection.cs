using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Operation
{
    public partial class FrmCreateCollection : Form
    {
        public string CollectionName;
        public bool Result;
        public string StrSvrPathWithTag;
        public TreeNode TreeNode;

        public FrmCreateCollection()
        {
            InitializeComponent();
        }

        private void frmCreateCollection_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                Text = GuiConfig.GetText(TextType.CreateNewCollection);
                lblCollectionName.Text =
                    GuiConfig.GetText(
                        TextType.CollectionStatusCollectionName);
                chkAdvance.Text =
                    GuiConfig.GetText(TextType.CommonAdvanceOption);
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
                chkIsCapped.Text =
                    GuiConfig.GetText(TextType.CollectionStatusIsCapped);
                lblMaxDocument.Text =
                    GuiConfig.GetText(
                        TextType.CollectionStatusMaxDocuments);
                lblMaxSize.Text =
                    GuiConfig.GetText(TextType.CollectionStatusMaxSize);
                chkIsAutoIndexId.Text =
                    GuiConfig.GetText(
                        TextType.CollectionStatusIsAutoIndexId);
            }

            //Difference between with long and decimal.....
            numMaxDocument.Maximum = decimal.MaxValue;
            numMaxSize.Maximum = decimal.MaxValue;
            chkAdvance.Checked = false;
            chkAdvance.Location = new Point(grpAdvanced.Location.X + 10, grpAdvanced.Location.Y);
            chkAdvance.BringToFront();
            grpAdvanced.Enabled = false;
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
            CollectionName = txtCollectionName.Text;
            try
            {
                string errMessage;
                RuntimeMongoDbContext.GetCurrentDataBase().IsCollectionNameValid(txtCollectionName.Text, out errMessage);
                if (errMessage != null)
                {
                    MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", errMessage, true);
                    return;
                }
                if (chkAdvance.Checked)
                {
                    var option = new CollectionOptionsBuilder();
                    option.SetCapped(chkIsCapped.Checked);
                    option.SetMaxSize((long) numMaxSize.Value);
                    option.SetMaxDocuments((long) numMaxDocument.Value);
                    //CappedCollection Default is AutoIndexId After MongoDB 2.2.2
                    option.SetAutoIndexId(chkIsAutoIndexId.Checked);

                    if (chkValidation.Checked)
                    {
                        //Start From MongoDB 3.2.0
                        option.SetValidator((QueryDocument) BsonDocument.Parse(txtValidation.Text));
                        //Validation Level
                        if (radLevel_off.Checked) option.SetValidationLevel(DocumentValidationLevel.Off);
                        if (radLevel_strict.Checked) option.SetValidationLevel(DocumentValidationLevel.Strict);
                        if (radLevel_moderate.Checked) option.SetValidationLevel(DocumentValidationLevel.Moderate);
                        //Validation Action
                        if (radAction_error.Checked) option.SetValidationAction(DocumentValidationAction.Error);
                        if (radAction_warn.Checked) option.SetValidationAction(DocumentValidationAction.Warn);
                    }

                    Result = Operater.CreateCollectionWithOptions(StrSvrPathWithTag, txtCollectionName.Text,
                        option, RuntimeMongoDbContext.GetCurrentDataBase());
                }
                else
                {
                    Result = Operater.CreateCollection(StrSvrPathWithTag, txtCollectionName.Text,
                        RuntimeMongoDbContext.GetCurrentDataBase());
                }
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
        ///     高级选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAdvance_CheckedChanged(object sender, EventArgs e)
        {
            grpAdvanced.Enabled = chkAdvance.Checked;
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
    }
}