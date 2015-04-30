using System;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using MongoUtility.Extend;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace FunctionForm.Misc
{
    public partial class FrmValidate : Form
    {
        private BsonDocument _result;

        public FrmValidate()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
            cmdSave.Enabled = false;
        }

        /// <summary>
        ///     Run Validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            var textSearchOption = new BsonDocument().Add(new BsonElement("full", chkFull.Checked.ToString()));
            var searchResult = CommandHelper.ExecuteMongoColCommand("validate",
                RuntimeMongoDbContext.GetCurrentCollection(), textSearchOption);
            _result = searchResult.Response;
            UIHelper.FillDataToTreeView("Validate Result", trvResult, _result);
            cmdSave.Enabled = true;
        }

        /// <summary>
        ///     Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = Utility.JsFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MongoHelper.SaveResultToJSonFile(_result, dialog.FileName);
            }
        }
    }
}