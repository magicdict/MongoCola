using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace FunctionForm.Aggregation
{
    public partial class FrmGroup : Form
    {
        /// <summary>
        ///     条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;

        /// <summary>
        ///     条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);

        /// <summary>
        ///     Group条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> GroupConditionList =
            new List<DataFilter.QueryConditionInputItem>();

        public FrmGroup(DataFilter mDataFilter, bool isUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count <= 0 || !isUseFilter) return;
            Text += "[With DataView Filter]";
            foreach (var item in mDataFilter.QueryConditionList)
            {
                GroupConditionList.Add(item);
            }
        }

        /// <summary>
        ///     确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            var query = QueryHelper.GetQuery(GroupConditionList);
            var groupdoc = new GroupByDocument();
            var chartTite = string.Empty;
            foreach (CheckBox item in panColumn.Controls)
            {
                if (!item.Checked) continue;
                groupdoc.Add(item.Name, true);
                chartTite += item.Name + ",";
            }
            chartTite = chartTite.TrimEnd(",".ToCharArray());
            var initial = new BsonDocument();
            for (var i = 0; i < _conditionCount; i++)
            {
                var ctl = (CtlAddBsonEl) Controls.Find("BsonEl" + (i + 1), true)[0];
                if (ctl.IsSetted)
                {
                    initial.Add(ctl.GetElement());
                }
            }

            var reduce = new BsonJavaScript(ctlReduce.Context);
            var finalize = new BsonJavaScript(ctlFinalize.Context);
            var resultlst = new List<BsonDocument>();

            try
            {
                //SkipCnt Reset
                var result = mongoCol.Group(query, groupdoc, initial, reduce, finalize);
                //图形化初始化
                chartResult.Series.Clear();
                chartResult.Titles.Clear();
                var seriesResult = new Series("Result");

                //防止错误的条件造成的海量数据
                var count = 0;
                foreach (var item in result)
                {
                    if (count == 1000)
                    {
                        break;
                    }
                    resultlst.Add(item);
                    //必须带有Count元素
                    var dPoint = new DataPoint(0, (double) item.GetElement("count").Value);
                    seriesResult.Points.Add(dPoint);
                    count++;
                }
                ViewHelper.FillJsonDataToTextBox(txtResult, resultlst, 0);
                if (count == 1001)
                {
                    txtResult.Text = "Too many result,Display first 1000 records" + Environment.NewLine + txtResult.Text;
                }
                txtResult.Select(0, 0);
                //图形化加载
                chartResult.Series.Add(seriesResult);
                chartResult.Titles.Add(new Title(chartTite));
                tabGroup.SelectedIndex = 4;
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, "Exception", "Exception is Happened");
            }
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroup_Load(object sender, EventArgs e)
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            var mongoColumn = MongoHelper.GetCollectionSchame(mongoCol);
            var conditionPos = new Point(50, 20);
            foreach (var item in mongoColumn)
            {
                //动态加载控件
                var ctrItem = new CheckBox {Name = item, Location = conditionPos, Text = item};
                panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                conditionPos.Y += ctrItem.Height;
            }
            conditionPos = new Point(50, 20);
            var firstAddBsonElCtl = new CtlAddBsonEl {Location = conditionPos, Name = "BsonEl" + _conditionCount};
            var el = new BsonElement("count", new BsonInt32(0));
            firstAddBsonElCtl.SetElement(el);
            panBsonEl.Controls.Add(firstAddBsonElCtl);

            if (GuiConfig.IsUseDefaultLanguage) return;
            ctlReduce.Title = GuiConfig.GetText(TextType.GroupTabReduce);
            ctlFinalize.Title =
                GuiConfig.GetText(TextType.GroupTabFinalize);
            lblSelectGroupField.Text =
                GuiConfig.GetText(TextType.GroupTabGroupNotes);
            lblAddInitField.Text =
                GuiConfig.GetText(TextType.GroupTabInitColumnNote);
            cmdAddInitField.Text =
                GuiConfig.GetText(TextType.GroupTabInitColumn);
            lblResult.Text = GuiConfig.GetText(TextType.GroupTabResult);
            cmdQuery.Text = GuiConfig.GetText(TextType.GroupLoadQuery);
            cmdRun.Text = GuiConfig.GetText(TextType.CommonOk);
        }

        /// <summary>
        ///     添加初始化字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddFld_Click(object sender, EventArgs e)
        {
            _conditionCount++;
            var newCondition = new CtlAddBsonEl();
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "BsonEl" + _conditionCount;
            panBsonEl.Controls.Add(newCondition);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuery_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var newDataFilter = DataFilter.LoadFilter(openFile.FileName);
            GroupConditionList.Clear();
            GroupConditionList = newDataFilter.QueryConditionList;
        }
    }
}