using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmValidate : Form
    {
        public frmValidate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Run Validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            var TextSearchOption = new BsonDocument().Add(new BsonElement("full", chkFull.Checked.ToString()));
            CommandResult SearchResult = MongoDBHelper.ExecuteMongoColCommand("validate", SystemManager.GetCurrentCollection(), TextSearchOption);
            MongoDBHelper.FillDataToTreeView("Validate Result", trvResult, SearchResult.Response);
        }
        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
