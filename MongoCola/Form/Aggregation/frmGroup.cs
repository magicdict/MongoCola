using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoCola.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl;
using MongoUtility.Aggregation;

namespace MongoCola
{
    public partial class frmGroup : Form
    {
        /// <summary>
        ///     Group条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> GroupConditionList =
            new List<DataFilter.QueryConditionInputItem>();

        /// <summary>
        ///     条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;

        /// <summary>
        ///     条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);

        public frmGroup(DataFilter mDataFilter, Boolean IsUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count <= 0 || !IsUseFilter) return;
            Text += "[With DataView Filter]";
            foreach (DataFilter.QueryConditionInputItem item in mDataFilter.QueryConditionList)
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
            MongoCollection mongoCol = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection();
            IMongoQuery query = QueryHelper.GetQuery(GroupConditionList);
            var groupdoc = new GroupByDocument();
            String ChartTite = string.Empty;
            foreach (CheckBox item in panColumn.Controls)
            {
                if (!item.Checked) continue;
                groupdoc.Add(item.Name, true);
                ChartTite += item.Name + ",";
            }
            ChartTite = ChartTite.TrimEnd(",".ToCharArray());
            var Initial = new BsonDocument();
            for (int i = 0; i < _conditionCount; i++)
            {
                var ctl = (ctlAddBsonEl) Controls.Find("BsonEl" + (i + 1), true)[0];
                if (ctl.IsSetted)
                {
                    Initial.Add(ctl.getElement());
                }
            }

            var reduce = new BsonJavaScript(ctlReduce.Context);
            var finalize = new BsonJavaScript(ctlFinalize.Context);
            var resultlst = new List<BsonDocument>();

            try
            {
                //SkipCnt Reset
                IEnumerable<BsonDocument> Result = mongoCol.Group(query, groupdoc, Initial, reduce, finalize);
                //图形化初始化
                chartResult.Series.Clear();
                chartResult.Titles.Clear();
                var SeriesResult = new Series("Result");

                //防止错误的条件造成的海量数据
                int Count = 0;
                foreach (BsonDocument item in Result)
                {
                    if (Count == 1000)
                    {
                        break;
                    }
                    resultlst.Add(item);
                    //必须带有Count元素
                    var dPoint = new DataPoint(0, (double) item.GetElement("count").Value);
                    SeriesResult.Points.Add(dPoint);
                    Count++;
                }
                MongoGUIView.ViewHelper.FillJSONDataToTextBox(txtResult, resultlst, 0);
                if (Count == 1001)
                {
                    txtResult.Text = "Too many result,Display first 1000 records" + Environment.NewLine + txtResult.Text;
                }
                txtResult.Select(0, 0);
                //图形化加载
                chartResult.Series.Add(SeriesResult);
                chartResult.Titles.Add(ChartTite);
                tabGroup.SelectedIndex = 4;
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex, "Exception", "Exception is Happened");
            }
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroup_Load(object sender, EventArgs e)
        {
            MongoCollection mongoCol = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection();
            List<String> MongoColumn = MongoUtility.Basic.Utility.GetCollectionSchame(mongoCol);
            var _conditionPos = new Point(50, 20);
            foreach (String item in MongoColumn)
            {
                //动态加载控件
                var ctrItem = new CheckBox {Name = item, Location = _conditionPos, Text = item};
                panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            _conditionPos = new Point(50, 20);
            var firstAddBsonElCtl = new ctlAddBsonEl {Location = _conditionPos, Name = "BsonEl" + _conditionCount};
            var el = new BsonElement("count", new BsonInt32(0));
            firstAddBsonElCtl.setElement(el);
            panBsonEl.Controls.Add(firstAddBsonElCtl);

            if (SystemManager.IsUseDefaultLanguage) return;
            ctlReduce.Title = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_Reduce);
            ctlFinalize.Title = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_Finalize);
            lblSelectGroupField.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_Group_Notes);
            lblAddInitField.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_InitColumn_Note);
            cmdAddInitField.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_InitColumn);
            lblResult.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_Tab_Result);
            cmdQuery.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Group_LoadQuery);
            cmdRun.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
        }

        /// <summary>
        ///     添加初始化字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddFld_Click(object sender, EventArgs e)
        {
            _conditionCount++;
            var newCondition = new ctlAddBsonEl();
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
            DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
            GroupConditionList.Clear();
            GroupConditionList = NewDataFilter.QueryConditionList;
        }
    }
}