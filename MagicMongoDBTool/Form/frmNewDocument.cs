using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
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
                    SystemManager.GetCurrentCollection().Insert(newdoc,new SafeMode(true));
                    this.Close();
                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowMessage("Error", "Format Error",ex.ToString(),true);
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
