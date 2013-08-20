using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MagicMongoDBTool
{
    public partial class frmGroup : Form
    {
        public frmGroup(DataFilter mDataFilter, Boolean IsUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count > 0 && IsUseFilter)
            {
                this.Text += "[With DataView Filter]";
                foreach (var item in mDataFilter.QueryConditionList)
                {
                    GroupConditionList.Add(item);
                }
            }
        }
        /// <summary>
        /// Group条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> GroupConditionList = new List<DataFilter.QueryConditionInputItem>();
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            IMongoQuery query = MongoDBHelper.GetQuery(GroupConditionList);
            GroupByDocument groupdoc = new GroupByDocument();
            String ChartTite = string.Empty;
            foreach (CheckBox item in panColumn.Controls)
            {
                if (item.Checked)
                {
                    groupdoc.Add(item.Name, true);
                    ChartTite += item.Name + ",";
                }
            }
            ChartTite = ChartTite.TrimEnd(",".ToCharArray());
            BsonDocument Initial = new BsonDocument();
            for (int i = 0; i < _conditionCount; i++)
            {
                ctlAddBsonEl ctl = (ctlAddBsonEl)Controls.Find("BsonEl" + (i + 1).ToString(), true)[0];
                if (ctl.IsSetted)
                {
                    Initial.Add(ctl.getElement());
                }
            }

            BsonJavaScript reduce = new BsonJavaScript(ctlReduce.Context);
            BsonJavaScript finalize = new BsonJavaScript(ctlFinalize.Context);
            List<BsonDocument> resultlst = new List<BsonDocument>();

            try
            {
                ///SkipCnt Reset
                var Result = mongoCol.Group(query, groupdoc, Initial, reduce, finalize);
                //图形化初始化
                chartResult.Series.Clear();
                chartResult.Titles.Clear();
                Series SeriesResult = new Series("Result");

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
                    DataPoint dPoint = new DataPoint(0, (double)item.GetElement("count").Value);
                    SeriesResult.Points.Add(dPoint);
                    Count++;
                };
                MongoDBHelper.FillJSONDataToTextBox(this.txtResult, resultlst, 0);
                if (Count == 1001)
                {
                    this.txtResult.Text = "Too many result,Display first 1000 records" + System.Environment.NewLine + this.txtResult.Text;
                }
                this.txtResult.Select(0, 0);
                //图形化加载
                chartResult.Series.Add(SeriesResult);
                chartResult.Titles.Add(ChartTite);
                tabGroup.SelectedIndex = 4;

            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex, "Exception", "Exception is Happened");
            }
        }
        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);

        private void frmGroup_Load(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            List<String> MongoColumn = MongoDBHelper.GetCollectionSchame(mongoCol);
            Point _conditionPos = new Point(50, 20);
            foreach (String item in MongoColumn)
            {
                //动态加载控件
                CheckBox ctrItem = new CheckBox();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.Text = item;
                this.panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            _conditionPos = new Point(50, 20);
            ctlAddBsonEl firstAddBsonElCtl = new ctlAddBsonEl();
            firstAddBsonElCtl.Location = _conditionPos;
            firstAddBsonElCtl.Name = "BsonEl" + _conditionCount.ToString();
            BsonElement el = new BsonElement("count", new BsonInt32(0));
            firstAddBsonElCtl.setElement(el);
            panBsonEl.Controls.Add(firstAddBsonElCtl);

            if (!SystemManager.IsUseDefaultLanguage)
            {
                ctlReduce.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_Reduce);
                ctlFinalize.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_Finalize);
                lblSelectGroupField.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_Group_Notes);
                lblAddInitField.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_InitColumn_Note);
                cmdAddInitField.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_InitColumn);
                lblResult.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_Tab_Result);
                cmdQuery.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Group_LoadQuery);
                cmdRun.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
            }

        }
        /// <summary>
        /// 添加初始化字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddFld_Click(object sender, EventArgs e)
        {
            _conditionCount++;
            ctlAddBsonEl newCondition = new ctlAddBsonEl();
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "BsonEl" + _conditionCount.ToString();
            panBsonEl.Controls.Add(newCondition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuery_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                GroupConditionList.Clear();
                GroupConditionList = NewDataFilter.QueryConditionList;
            }
        }
    }
}
