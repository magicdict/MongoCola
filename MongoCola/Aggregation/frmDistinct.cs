using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SystemUtility;
using Common.UI;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Utility;

namespace MongoCola.Aggregation
{
    public partial class frmDistinct : Form
    {
        /// <summary>
        ///     Distinct条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> DistinctConditionList =
            new List<DataFilter.QueryConditionInputItem>();

        public frmDistinct(DataFilter mDataFilter, Boolean IsUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count <= 0 || !IsUseFilter) return;
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
            var mongoCol = RuntimeMongoDBContext.GetCurrentCollection();
            var MongoColumn = Utility.GetCollectionSchame(mongoCol);
            var _conditionPos = new Point(20, 20);
            foreach (var item in MongoColumn)
            {
                //动态加载控件
                var ctrItem = new RadioButton {Name = item, Location = _conditionPos, Text = item};
                panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            if (SystemConfig.IsUseDefaultLanguage) return;
            cmdQuery.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Distinct_Action_LoadQuery);
            cmdRun.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
            lblSelectField.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Distinct_SelectField);
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
            var ResultArray =
                (BsonArray)
                    RuntimeMongoDBContext.GetCurrentCollection()
                        .Distinct(strKey, QueryHelper.GetQuery(DistinctConditionList));
            var ResultList = new List<BsonValue>();
            foreach (var item in ResultArray)
            {
                ResultList.Add(item);
            }
            //防止错误的条件造成的海量数据
            var Count = 0;
            var strResult = string.Empty;
            ResultList.Sort();
            foreach (var item in ResultList)
            {
                if (Count == 1000)
                {
                    strResult = "Too many result,Display first 1000 records" + Environment.NewLine + strResult;
                    break;
                }
                strResult += item.ToJson(Utility.JsonWriterSettings) + Environment.NewLine;
                Count++;
            }
            strResult = "Distinct Count: " + ResultList.Count + Environment.NewLine + Environment.NewLine + strResult;
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
            DistinctConditionList.Clear();
            DistinctConditionList = NewDataFilter.QueryConditionList;
        }
    }
}