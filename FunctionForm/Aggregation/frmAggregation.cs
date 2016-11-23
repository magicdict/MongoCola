using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl.ClientTree;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    public partial class FrmAggregation : Form
    {
        /// <summary>
        ///     聚合数组
        /// </summary>
        private BsonArray stages = new BsonArray();

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
            if (stages.Count <= 0)
                return;
            var mCommandResult = DataBaseCommand.Aggregate(stages, RuntimeMongoDbContext.GetCurrentCollection().Name);
            if (mCommandResult.Ok)
            {
                trvResult.DatatreeView.BeginUpdate();
                UiHelper.FillDataToTreeView("Aggregate Result", trvResult, mCommandResult.Response);
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
                stages =
                    (BsonArray)
                        BsonDocument.Parse(Operater.LoadJavascript(cmbForAggregatePipeline.Text,
                            RuntimeMongoDbContext.GetCurrentCollection())).GetValue(0);
                FillStagesTreeview();
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
                var frmAddStage = new FrmAddStage();
                UIAssistant.OpenModalForm(frmAddStage, false, true);
                if (frmAddStage.DialogResult == DialogResult.OK) {
                    stages.AddRange(frmAddStage.BsonDocumentList);
                    FillStagesTreeview();
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     将聚合条件放入可视化控件
        /// </summary>
        private void FillStagesTreeview()
        {
            var list = new List<BsonDocument>();
            foreach (BsonDocument item in stages)
            {
                list.Add(item);
            }
            trvCondition.DatatreeView.BeginUpdate();
            UiHelper.FillDataToTreeView("stages", trvCondition, list, 0);
            trvCondition.DatatreeView.ExpandAll();
            trvCondition.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     清除条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClear_Click(object sender, EventArgs e)
        {
            stages.Clear();
            FillStagesTreeview();
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
            if (stages.Count == 0)
                return;
            var strJsName = MyMessageBox.ShowInput("pls Input Aggregate Pipeline Name ：",
                "Save Aggregate Pipeline");
            Operater.CreateNewJavascript(strJsName, new BsonDocument("Pipeline:", stages).ToString());
        }

        /// <summary>
        ///     Aggregation Builder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggrBuilder_Click(object sender, EventArgs e)
        {
            var frmAggregationBuilder = new FrmStageBuilder();
            UIAssistant.OpenModalForm(frmAggregationBuilder, false, true);
            foreach (var item in frmAggregationBuilder.Aggregation)
            {
                stages.Add(item);
            }
            FillStagesTreeview();
        }
        /// <summary>
        ///     Save As View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAsView_Click(object sender, EventArgs e)
        {
            if (stages.Count == 0)
                return;
            var strViewName = MyMessageBox.ShowInput("pls Input Aggregate Pipeline Name ：",
                "Save Aggregate Pipeline");
            var pipeline = new BsonDocumentStagePipelineDefinition<BsonDocument, BsonDocument>(stages.Values.Select(x => (BsonDocument)x));
            RuntimeMongoDbContext.GetCurrentIMongoDataBase().CreateView(strViewName, RuntimeMongoDbContext.GetCurrentCollectionName() , pipeline);
        }
    }
}