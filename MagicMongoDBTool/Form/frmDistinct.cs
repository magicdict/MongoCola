using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QLFUI;
namespace MagicMongoDBTool
{
    public partial class frmDistinct : QLFUI.QLFForm
    {
        public frmDistinct()
        {
            InitializeComponent();
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
            if (SystemManager.ConfigHelperInstance.currentLanguage != GUIResource.StringResource.Language.Default)
            {
                cmdQuery.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Distinct_Action_LoadQuery);
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Distinct_Action_OK);
                lblSelectField.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Distinct_SelectField);
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
                MyMessageBox.ShowMessage("Distinct", "请选择字段");
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
                    strResult = "显示前1000条记录" + "\r\n" + strResult;
                    break;
                }
                strResult += MongoDBHelper.GetBsonElementText(strKey, item, 0);
                Count++;
            }
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);

        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                DistinctConditionList = NewDataFilter.QueryConditionList;
            }
        }
    }
}
