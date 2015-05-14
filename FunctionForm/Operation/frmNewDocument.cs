using System;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace FunctionForm.Operation
{
    public partial class FrmNewDocument : Form
    {
        public BsonDocument MBsonDocument;

        public FrmNewDocument()
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
                    MBsonDocument = newBsonDocument;
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
                BsonDocument newdoc;
                newdoc = BsonDocument.Parse(txtDocument.Text);
                UiHelper.FillDataToTreeView("InsertDocument", trvNewDocument, newdoc);
                trvNewDocument.TreeView.ExpandAll();
                txtDocument.Text = newdoc.ToJson(MongoHelper.JsonWriterSettings);
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
            if (txtDocument.Text != string.Empty)
            {
                Utility.SaveTextFile(txtDocument.Text, Utility.TxtFilter);
            }
        }

        /// <summary>
        ///     载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewDocument_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
        }
    }
}