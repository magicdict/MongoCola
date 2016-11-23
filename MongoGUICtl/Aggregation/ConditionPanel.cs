using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ConditionPanel : UserControl
    {

        /// <summary>
        ///     条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(5, 0);

        /// <summary>
        ///     当前数据集的字段列表
        /// </summary>
        public List<string> ColumnList = new List<string>();

        /// <summary>
        /// 初始化
        /// </summary>
        public ConditionPanel()
        {
            InitializeComponent();

        }
        private void ConditionPanel_Load(object sender, EventArgs e)
        {
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                ColumnList = MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection());
                AddCondition();
            }
        }

        /// <summary>
        ///     新增条件
        /// </summary>
        public void AddCondition()
        {
            var newCondition = new CtlQueryCondition();
            newCondition.Init(ColumnList);
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.ItemRemoved += sender => { if (Controls.Count > 1) { Controls.Remove((Control)sender); } };
            newCondition.ItemAdded += sender => AddCondition();
            Controls.Add(newCondition);
        }
        /// <summary>
        ///     清除条件
        /// </summary>
        public void ClearCondition()
        {
            Controls.Clear();
            _conditionPos = new Point(5, 0);
            AddCondition();
        }

        /// <summary>
        ///     获得Match文档
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetMatchDocument()
        {
            List<DataFilter.QueryConditionInputItem> QueryConditionList = new List<DataFilter.QueryConditionInputItem>();
            foreach (CtlQueryCondition ctl in Controls)
            {
                if (ctl.IsSeted)
                {
                    QueryConditionList.Add(ctl.ConditionItem);
                }
            }
            if (QueryConditionList.Count > 0)
            {
                return new BsonDocument("$match", QueryHelper.GetQuery(QueryConditionList).ToBsonDocument());
            }
            return null;
        }

        /// <summary>
        ///     将条件转成UI
        /// </summary>
        /// <param name="newDataFilter"></param>
        public void PutQueryToUi(DataFilter newDataFilter)
        {
            var strErrMsg = string.Empty;
            var showColumnList = new List<string>();
            foreach (var item in ColumnList)
            {
                showColumnList.Add(item);
            }
            //清除所有的控件
            var fieldList = newDataFilter.QueryFieldList;
            foreach (var queryFieldItem in newDataFilter.QueryFieldList)
            {
                //动态加载控件
                if (!ColumnList.Contains(queryFieldItem.ColName))
                {
                    strErrMsg += "Display Field [" + queryFieldItem.ColName +
                                 "] is not exist in current collection any more" + Environment.NewLine;
                }
                else
                {
                    showColumnList.Remove(queryFieldItem.ColName);
                }
            }
            foreach (var item in showColumnList)
            {
                strErrMsg += "New Field" + item + "Is Append" + Environment.NewLine;
                //输出配置的初始化
                fieldList.Add(new DataFilter.QueryFieldItem(item));
            }
            Controls.Clear();
            _conditionPos = new Point(5, 0);
            foreach (var queryConditionItem in newDataFilter.QueryConditionList)
            {
                var newCondition = new CtlQueryCondition();
                newCondition.Init(ColumnList);
                _conditionPos.Y += newCondition.Height;
                newCondition.Location = _conditionPos;
                newCondition.ConditionItem = queryConditionItem;
                Controls.Add(newCondition);

                if (!ColumnList.Contains(queryConditionItem.ColName))
                {
                    strErrMsg += queryConditionItem.ColName +
                                 "Query Condition Field is not exist in collection any more" + Environment.NewLine;
                }
            }

            if (strErrMsg != string.Empty)
            {
                MyMessageBox.ShowMessage("Load Exception", "A Exception is happened when loading", strErrMsg, true);
            }
        }
    }
}