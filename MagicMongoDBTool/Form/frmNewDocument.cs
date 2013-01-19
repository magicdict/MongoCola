using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

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
        /// 插入文档
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
                    this.Close();
                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowMessage("Error", "Format Error", ex.ToString(), true);
                }
            }
            else
            {
                try
                {
                    MongoDBHelper.InsertEmptyDocument(SystemManager.GetCurrentCollection(), true);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowMessage("Error", "InsertEmptyDocument Error", ex.ToString(), true);
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPreview_Click(object sender, EventArgs e)
        {
            try
            {
                BsonDocument newdoc;
                newdoc = BsonDocument.Parse(txtDocument.Text);
                MongoDBHelper.FillDataToTreeView("InsertDocument", this.treeViewColumns1, newdoc);
                this.treeViewColumns1.TreeView.ExpandAll();
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }
    }
}
