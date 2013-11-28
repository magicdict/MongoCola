using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MagicMongoDBTool
{
    public partial class frmAggregation : System.Windows.Forms.Form
    {
        /// <summary>
        /// 聚合数组
        /// </summary>
        private BsonArray _AggrArray = new BsonArray();
        public frmAggregation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Run Aggregate
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
                else
                {
                    MyMessageBox.ShowMessage("Aggregate Result", mCommandResult.ErrorMessage);
                }

            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAggregation_Load(object sender, EventArgs e)
        {
            foreach (String item in SystemManager.GetJsNameList())
            {
                cmbForAggregatePipeline.Items.Add(item);
            }
            cmbForAggregatePipeline.SelectedIndexChanged += new EventHandler(
                (x, y) =>
                {
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
                frmNewDocument frmInsertDoc = new frmNewDocument();
                SystemManager.OpenForm(frmInsertDoc, false, true);
                _AggrArray.Add(frmInsertDoc.mBsonDocument);
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
        /// Save Aggregate Pipeline
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
        /// <summary>
        /// Aggregation Builder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggrBuilder_Click(object sender, EventArgs e)
        {
            frmAggregationCondition frmAggregationBuilder = new frmAggregationCondition();
            SystemManager.OpenForm(frmAggregationBuilder, false, true);
            foreach (var item in frmAggregationBuilder.Aggregation)
            {
                _AggrArray.Add(item);
            }
            FillAggreationTreeview();
        }
    }
}
