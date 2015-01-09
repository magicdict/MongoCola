using System;
using System.Windows.Forms;
using MongoCola.Module;
using MongoDB.Bson;
using MongoUtility.Basic;

namespace MongoCola
{
    public partial class frmNewDocument : Form
    {
        public BsonDocument mBsonDocument;

        public frmNewDocument()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     插入文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            BsonDocument newBsonDocument;
            if (txtDocument.Text != string.Empty)
            {
                try
                {
                    newBsonDocument = BsonDocument.Parse(txtDocument.Text);
                    mBsonDocument = newBsonDocument;
                    Close();
                }
                catch (Exception ex)
                {
                    Common.Utility.ExceptionDeal(ex, "Error", "Format Error");
                }
            }
            else
            {
                try
                {
                    MongoDbHelper.InsertEmptyDocument(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection(), true);
                    Close();
                }
                catch (Exception ex)
                {
                    Common.Utility.ExceptionDeal(ex, "Error", "InsertEmptyDocument Error");
                }
            }
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
        ///     预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPreview_Click(object sender, EventArgs e)
        {
            try
            {
                BsonDocument newdoc;
                newdoc = BsonDocument.Parse(txtDocument.Text);
                MongoGUICtl.UIHelper.FillDataToTreeView("InsertDocument", trvNewDocument, newdoc);
                trvNewDocument.TreeView.ExpandAll();
                txtDocument.Text = newdoc.ToJson(MongoUtility.Basic.Utility.JsonWriterSettings);
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     保存文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveDocument_Click(object sender, EventArgs e)
        {
            if (txtDocument.Text != string.Empty)
            {
                Common.Utility.SaveTextFile(txtDocument.Text, Common.Utility.TxtFilter);
            }
        }

        /// <summary>
        ///     载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewDocument_Load(object sender, EventArgs e)
        {
            if (SystemManager.IsUseDefaultLanguage) return;
            cmdClose.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
            cmdSaveAggregate.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
            cmdOK.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
            //cmdPreview.Text = SystemManager.guiConfig.MStringResource.GetText();
        }
    }
}