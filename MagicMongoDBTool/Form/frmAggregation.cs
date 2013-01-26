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
        private BsonArray _AggrArray = new BsonArray();
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
            if (txtAggregate.Text!= string.Empty)
            {
                String strJsName = MyMessageBox.ShowInput("pls Input Aggregate Name：", "Save Aggregate");
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
            if (_AggrArray.Count > 0)
            {
                CommandResult mCommandResult = MongoDBHelper.Aggregate(_AggrArray);
                if (mCommandResult.Ok)
                {
                    MongoDBHelper.FillDataToTreeView("Aggregate Result", trvResult, mCommandResult.Response);
                    trvResult.DatatreeView.BeginUpdate();
                    trvResult.DatatreeView.ExpandAll();
                    trvResult.DatatreeView.EndUpdate();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAggregation_Load(object sender, EventArgs e)
        {
            foreach (String item in SystemManager.GetJsNameList())
            {
                cmbForAggregate.Items.Add(item);
                cmbForAggregatePipeline.Items.Add(item);
            }
            cmbForAggregate.SelectedIndexChanged += new EventHandler(
                (x, y) => { this.txtAggregate.Text = MongoDBHelper.LoadJavascript(cmbForAggregate.Text); }
            );
            cmbForAggregatePipeline.SelectedIndexChanged += new EventHandler(
                (x, y) => {
                    _AggrArray = (BsonArray)BsonDocument.Parse(MongoDBHelper.LoadJavascript(cmbForAggregatePipeline.Text)).GetValue(0); 
                    FillAggreationTreeview();
                }
            );
        }
        /// <summary>
        /// 增加条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCondition_Click(object sender, EventArgs e)
        {
            try
            {
                _AggrArray.Add(BsonDocument.Parse(txtAggregate.Text));
                txtAggregate.Text = "";
                FillAggreationTreeview();
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }
        /// <summary>
        /// 将聚合条件放入可视化控件
        /// </summary>
        private void FillAggreationTreeview()
        {
            List<BsonDocument> ConditionList = new List<BsonDocument>();
            foreach (BsonDocument item in _AggrArray)
            {
                ConditionList.Add(item);
            }
            MongoDBHelper.FillDataToTreeView("Aggregation", trvCondition, ConditionList, 0);
            trvCondition.DatatreeView.BeginUpdate();
            trvCondition.DatatreeView.ExpandAll();
            trvCondition.DatatreeView.EndUpdate();
        }
        /// <summary>
        /// 清除条件啊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAggregate.Text = "";
            _AggrArray.Clear();
            trvCondition.TreeView.Nodes.Clear();
        }
        /// <summary>
        /// 转到链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReference_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://docs.mongodb.org/manual/reference/aggregation/");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveAggregatePipeline_Click(object sender, EventArgs e)
        {
            if (this._AggrArray.Count != 0)
            {
                String strJsName = MyMessageBox.ShowInput("pls Input Aggregate Pipeline Name ：", "Save Aggregate Pipeline");
                MongoDBHelper.CreateNewJavascript(strJsName, new BsonDocument("Pipeline:", _AggrArray).ToString());
            }
        }
    }
}
