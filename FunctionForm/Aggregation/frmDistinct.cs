using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Aggregation
{
    public partial class FrmDistinct : Form
    {
        /// <summary>
        ///     Distinct条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> DistinctConditionList =
            new List<DataFilter.QueryConditionInputItem>();

        public FrmDistinct(DataFilter mDataFilter, bool isUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count <= 0 || !isUseFilter) return;
            Text += "[With DataView Filter]";
            //直接使用 DistinctConditionList = mDataFilter.QueryConditionList
            //DistinctConditionList是引用类型，在LoadQuery的时候，会改变mDataFilter.QueryConditionList的值
            //进而改变DataViewInfo在TabView上的值
            foreach (var item in mDataFilter.QueryConditionList)
            {
                DistinctConditionList.Add(item);
            }
        }

        private void frmSelectKey_Load(object sender, EventArgs e)
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            var mongoColumn = MongoHelper.GetCollectionSchame(mongoCol);
            var conditionPos = new Point(20, 20);
            foreach (var item in mongoColumn)
            {
                //动态加载控件
                var ctrItem = new RadioButton {Name = item, Location = conditionPos, Text = item};
                panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                conditionPos.Y += ctrItem.Height;
            }
            if (GuiConfig.IsUseDefaultLanguage) return;
            cmdQuery.Text =
                GuiConfig.GetText(TextType.DistinctActionLoadQuery);
            cmdRun.Text = GuiConfig.GetText(TextType.CommonOk);
            lblSelectField.Text =
                GuiConfig.GetText(TextType.DistinctSelectField);
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            var strKey = string.Empty;

            foreach (RadioButton item in panColumn.Controls)
            {
                if (item.Checked)
                {
                    strKey = item.Name;
                }
            }
            if (strKey == string.Empty)
            {
                MyMessageBox.ShowMessage("Distinct", "Pick the field");
                return;
            }
            var strResult = AggregationHelper.Distinct(strKey, DistinctConditionList);
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var newDataFilter = DataFilter.LoadFilter(openFile.FileName);
            DistinctConditionList.Clear();
            DistinctConditionList = newDataFilter.QueryConditionList;
        }
    }
}