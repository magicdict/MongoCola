using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Common;
using FunctionForm.Operation;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.UI;
using MongoDB.Bson;

namespace FunctionForm.Aggregation
{
    public partial class FrmAggregation : Form
    {
        /// <summary>
        ///     聚合数组
        /// </summary>
        private BsonArray _aggrArray = new BsonArray();

        public FrmAggregation()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Run Aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (_aggrArray.Count <= 0)
                return;
            var mCommandResult = CommandHelper.Aggregate(_aggrArray, RuntimeMongoDbContext.GetCurrentCollection().Name);
            if (mCommandResult.Ok)
            {
                UiHelper.FillDataToTreeView("Aggregate Result", trvResult, mCommandResult.Response);
                trvResult.DatatreeView.BeginUpdate();
                trvResult.DatatreeView.ExpandAll();
                trvResult.DatatreeView.EndUpdate();
            }
            else
            {
                MyMessageBox.ShowMessage("Aggregate Result", mCommandResult.ErrorMessage);
            }
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAggregation_Load(object sender, EventArgs e)
        {
            foreach (var item in MongoHelper.GetJsNameList())
            {
                cmbForAggregatePipeline.Items.Add(item);
            }
            cmbForAggregatePipeline.SelectedIndexChanged += (x, y) =>
            {
                _aggrArray = (BsonArray)BsonDocument.Parse(Operater.LoadJavascript(cmbForAggregatePipeline.Text, RuntimeMongoDbContext.GetCurrentCollection())).GetValue(0);
                FillAggreationTreeview();
            };
        }

        /// <summary>
        ///     增加条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCondition_Click(object sender, EventArgs e)
        {
            try
            {
                var frmInsertDoc = new FrmNewDocument();
                Utility.OpenForm(frmInsertDoc, false, true);
                _aggrArray.Add(frmInsertDoc.MBsonDocument);
                FillAggreationTreeview();
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     将聚合条件放入可视化控件
        /// </summary>
        private void FillAggreationTreeview()
        {
            var conditionList = new List<BsonDocument>();
            foreach (BsonDocument item in _aggrArray)
            {
                conditionList.Add(item);
            }
            UiHelper.FillDataToTreeView("Aggregation", trvCondition, conditionList, 0);
            trvCondition.DatatreeView.BeginUpdate();
            trvCondition.DatatreeView.ExpandAll();
            trvCondition.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     清除条件啊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClear_Click(object sender, EventArgs e)
        {
            _aggrArray.Clear();
            trvCondition.TreeView.Nodes.Clear();
        }

        /// <summary>
        ///     转到链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://docs.mongodb.org/manual/reference/aggregation/");
        }

        /// <summary>
        ///     Save Aggregate Pipeline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveAggregatePipeline_Click(object sender, EventArgs e)
        {
            if (_aggrArray.Count == 0)
                return;
            var strJsName = MyMessageBox.ShowInput("pls Input Aggregate Pipeline Name ：",
                "Save Aggregate Pipeline");
            Operater.CreateNewJavascript(strJsName, new BsonDocument("Pipeline:", _aggrArray).ToString());
        }

        /// <summary>
        ///     Aggregation Builder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggrBuilder_Click(object sender, EventArgs e)
        {
            var frmAggregationBuilder = new FrmAggregationCondition();
            Utility.OpenForm(frmAggregationBuilder, false, true);
            foreach (var item in frmAggregationBuilder.Aggregation)
            {
                _aggrArray.Add(item);
            }
            FillAggreationTreeview();
        }
    }
}