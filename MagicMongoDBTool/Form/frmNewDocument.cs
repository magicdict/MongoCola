using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool
{
    public partial class frmNewDocument : Form
    {

        public frmNewDocument()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            BsonDocument newdoc;
            if (txtDocument.Text != string.Empty)
            {
                try
                {
                    newdoc = BsonDocument.Parse(txtDocument.Text);
                    ///居然可以指定_id...
                    ///这样的话，可能出现同一个数据库里面两个相同的_id的记录
                    //SystemManager.GetCurrentCollection().Insert(newdoc, new SafeMode(true));
                    SystemManager.GetCurrentCollection().Insert(newdoc,WriteConcern.W2);
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
