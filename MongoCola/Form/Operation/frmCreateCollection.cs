using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SystemUtility;
using Common;
using MongoDB.Driver.Builders;
using MongoUtility.Core;
using MongoUtility.Operation;
using ResourceLib;

namespace MongoCola
{
    public partial class frmCreateCollection : Form
    {
        public bool Result;
        public string strSvrPathWithTag;
        public TreeNode treeNode;

        public frmCreateCollection()
        {
            InitializeComponent();
        }

        private void frmCreateCollection_Load(object sender, EventArgs e)
        {
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Create_New_Collection);
                lblCollectionName.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Status_CollectionName);
                chkAdvance.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Advance_Option);
                cmdOK.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Cancel);
                chkIsCapped.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_IsCapped);
                lblMaxDocument.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Status_MaxDocuments);
                lblMaxSize.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_MaxSize);
                chkIsAutoIndexId.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Status_IsAutoIndexId);
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
            try
            {
                string ErrMessage;
                RuntimeMongoDBContext.GetCurrentDataBase().IsCollectionNameValid(txtCollectionName.Text, out ErrMessage);
                if (ErrMessage != null)
                {
                    MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", ErrMessage, true);
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
                    Result = OperationHelper.CreateCollectionWithOptions(strSvrPathWithTag, txtCollectionName.Text,
                        option, RuntimeMongoDBContext.GetCurrentDataBase());
                }
                else
                {
                    Result = OperationHelper.CreateCollection(strSvrPathWithTag, txtCollectionName.Text,
                        RuntimeMongoDBContext.GetCurrentDataBase());
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