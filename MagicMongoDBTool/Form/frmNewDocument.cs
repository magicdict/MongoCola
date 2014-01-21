using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
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
                    SystemManager.ExceptionDeal(ex, "Error", "Format Error");
                }
            }
            else
            {
                try
                {
                    MongoDBHelper.InsertEmptyDocument(SystemManager.GetCurrentCollection(), true);
                    Close();
                }
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex, "Error", "InsertEmptyDocument Error");
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
                MongoDBHelper.FillDataToTreeView("InsertDocument", trvNewDocument, newdoc);
                trvNewDocument.TreeView.ExpandAll();
                txtDocument.Text = newdoc.ToJson(SystemManager.JsonWriterSettings);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
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
                SystemManager.SaveTextFile(txtDocument.Text, MongoDBHelper.TxtFilter);
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
            cmdClose.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
            cmdSaveAggregate.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
            cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
            //cmdPreview.Text = SystemManager.mStringResource.GetText();
        }
    }
}