using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MagicMongoDBTool
{
    public partial class frmAggregation : System.Windows.Forms.Form
    {
        private MongoCollection _mongocol = SystemManager.GetCurrentCollection();

        public frmAggregation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存Aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveAggregate_Click(object sender, EventArgs e)
        {
            if (txtAggregate.Text != String.Empty)
            {
                String strJsName = MyMessageBox.ShowInput("pls Input Javascript Name：", "Save Javascript");
                MongoDBHelper.CreateNewJavascript(strJsName, txtAggregate.Text);
            }
        }
        /// <summary>
        /// Aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRun_Click(object sender, EventArgs e)
        {
            CommandResult mCommandResult = MongoDBHelper.Aggregate(txtAggregate.Text);
            if (mCommandResult.Ok)
            {
                MongoDBHelper.FillDataToTreeView("Aggregate Result", trvResult, mCommandResult.Response);
                trvResult.DatatreeView.BeginUpdate();
                trvResult.DatatreeView.ExpandAll();
                trvResult.DatatreeView.EndUpdate();
            }
        }

        private void frmAggregation_Load(object sender, EventArgs e)
        {
            foreach (String item in SystemManager.GetJsNameList())
            {
                cmbForAggregate.Items.Add(item);
            }
            cmbForAggregate.SelectedIndexChanged += new EventHandler(
                (x, y) => { this.txtAggregate.Text = MongoDBHelper.LoadJavascript(cmbForAggregate.Text); }
            );
        }
    }
}
