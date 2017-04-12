using System;
using System.Windows.Forms;
using Common;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace FunctionForm.Status
{
    public partial class FrmValidate : Form
    {
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
            UiHelper.FillDataToTreeView("Validate Result", trvResult, Operater.Validate(chkFull.Checked));
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
            var dialog = new SaveFileDialog()
            {
                Filter = Utility.JsFilter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MongoHelper.SaveResultToJSonFile(Operater.Validate(chkFull.Checked), dialog.FileName);
            }
        }
    }
}