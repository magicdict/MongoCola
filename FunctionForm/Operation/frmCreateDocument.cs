using Common;
using ICSharpCode.TextEditor.Document;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using System;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    public partial class frmCreateDocument : Form
    {
        public BsonDocument mBsonDocument;

        public frmCreateDocument()
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
            if (txtJsCode.Text != string.Empty)
            {
                try
                {
                    newBsonDocument = BsonDocument.Parse(txtJsCode.Text);
                    mBsonDocument = newBsonDocument;
                    Close();
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex, "Error", "Format Error");
                }
            }
            else
            {
                try
                {
                    Operater.InsertEmptyDocument(RuntimeMongoDbContext.GetCurrentCollection(), true);
                    Close();
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex, "Error", "InsertEmptyDocument Error");
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
                BsonDocument newdoc = BsonDocument.Parse(txtJsCode.Text);
                UiHelper.FillDataToTreeView("InsertDocument", trvNewDocument, newdoc);
                trvNewDocument.TreeView.ExpandAll();
                txtJsCode.Text = newdoc.ToJson(MongoHelper.JsonWriterSettings);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     保存文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveDocument_Click(object sender, EventArgs e)
        {
            if (txtJsCode.Text != string.Empty)
            {
                Utility.SaveTextFile(txtJsCode.Text, Utility.TxtFilter);
            }
        }

        /// <summary>
        ///     载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewDocument_Load(object sender, EventArgs e)
        {
            txtJsCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            GuiConfig.Translateform(this);
        }
    }
}