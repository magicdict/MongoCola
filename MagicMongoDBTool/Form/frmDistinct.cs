using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmDistinct : Form
    {
        public frmDistinct(DataFilter mDataFilter, Boolean IsUseFilter)
        {
            InitializeComponent();
            if (mDataFilter.QueryConditionList.Count > 0 && IsUseFilter)
            {
                this.Text += "[With DataView Filter]";
                //直接使用 DistinctConditionList = mDataFilter.QueryConditionList
                //DistinctConditionList是引用类型，在LoadQuery的时候，会改变mDataFilter.QueryConditionList的值
                //进而改变DataViewInfo在TabView上的值
                foreach (var item in mDataFilter.QueryConditionList)
                {
                    DistinctConditionList.Add(item);
                }
            }
        }

        /// <summary>
        /// Distinct条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> DistinctConditionList = new List<DataFilter.QueryConditionInputItem>();

        private void frmSelectKey_Load(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            List<String> MongoColumn = MongoDBHelper.GetCollectionSchame(mongoCol);
            Point _conditionPos = new Point(20, 20);
            foreach (String item in MongoColumn)
            {
                //动态加载控件
                RadioButton ctrItem = new RadioButton();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.Text = item;
                this.panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            if (!SystemManager.IsUseDefaultLanguage)
            {
                cmdQuery.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Distinct_Action_LoadQuery);
                cmdRun.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                lblSelectField.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Distinct_SelectField);
            }
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            String strKey = String.Empty;

            foreach (RadioButton item in panColumn.Controls)
            {
                if (item.Checked)
                {
                    strKey = item.Name;
                }
            }
            if (strKey == String.Empty)
            {
                MyMessageBox.ShowMessage("Distinct", "Pick the field");
                return;
            }
            var ResultLst = SystemManager.GetCurrentCollection().Distinct(strKey, MongoDBHelper.GetQuery(DistinctConditionList));
            List<BsonValue> result = new List<BsonValue>();
            foreach (BsonValue item in ResultLst)
            {
                result.Add(item);
            }
            String strResult = String.Empty;

            //防止错误的条件造成的海量数据
            int Count = 0;
            foreach (BsonValue item in result)
            {
                if (Count == 1000)
                {
                    strResult = "Too many result,Display first 1000 records" + System.Environment.NewLine + strResult;
                    break;
                }
                strResult += item.ToJson(SystemManager.JsonWriterSettings) + System.Environment.NewLine;
                Count++;
            }
            strResult = "Distinct Count: " + result.Count + System.Environment.NewLine + System.Environment.NewLine + strResult;
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);

        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                DistinctConditionList.Clear();
                DistinctConditionList = NewDataFilter.QueryConditionList;
            }
        }
    }
}
