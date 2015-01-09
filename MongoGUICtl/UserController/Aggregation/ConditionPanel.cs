using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;
using MongoCola.Module;
using MongoUtility.Aggregation;

namespace MongoGUICtl
{
    public partial class ConditionPanel : UserControl
    {
        /// <summary>
        ///     当前数据集的字段列表
        /// </summary>
        public List<String> ColumnList = new List<String>();

        /// <summary>
        ///     条件输入器数量
        /// </summary>
        private byte _conditionCount;

        /// <summary>
        ///     条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(5, 0);

        public ConditionPanel()
        {
            InitializeComponent();
            if (MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                ColumnList = MongoUtility.Basic.Utility.GetCollectionSchame(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection());
            }
        }

        /// <summary>
        ///     新增条件
        /// </summary>
        public void AddCondition()
        {
            _conditionCount++;
            var newCondition = new ctlQueryCondition();
            newCondition.Init(ColumnList);
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "Condition" + _conditionCount;
            Controls.Add(newCondition);
        }

        /// <summary>
        ///     设置DataFilter
        /// </summary>
        public void SetCurrDataFilter(DataViewInfo CurrentDataViewInfo)
        {
            //过滤条件
            for (int i = 0; i < _conditionCount; i++)
            {
                var ctl = (ctlQueryCondition) Controls.Find("Condition" + (i + 1), true)[0];
                if (ctl.IsSeted)
                {
                    CurrentDataViewInfo.mDataFilter.QueryConditionList.Add(ctl.ConditionItem);
                }
            }
        }

        /// <summary>
        ///     将条件转成UI
        /// </summary>
        /// <param name="NewDataFilter"></param>
        public void PutQueryToUI(DataFilter NewDataFilter)
        {
            String strErrMsg = String.Empty;
            var ShowColumnList = new List<String>();
            foreach (String item in ColumnList)
            {
                ShowColumnList.Add(item);
            }
            //清除所有的控件
            List<DataFilter.QueryFieldItem> FieldList = NewDataFilter.QueryFieldList;
            foreach (DataFilter.QueryFieldItem queryFieldItem in NewDataFilter.QueryFieldList)
            {
                //动态加载控件
                if (!ColumnList.Contains(queryFieldItem.ColName))
                {
                    strErrMsg += "Display Field [" + queryFieldItem.ColName +
                                 "] is not exist in current collection any more" + Environment.NewLine;
                }
                else
                {
                    ShowColumnList.Remove(queryFieldItem.ColName);
                }
            }
            foreach (String item in ShowColumnList)
            {
                strErrMsg += "New Field" + item + "Is Append" + Environment.NewLine;
                //输出配置的初始化
                FieldList.Add(new DataFilter.QueryFieldItem(item));
            }
            Controls.Clear();
            _conditionPos = new Point(5, 0);
            _conditionCount = 0;
            foreach (DataFilter.QueryConditionInputItem queryConditionItem in NewDataFilter.QueryConditionList)
            {
                var newCondition = new ctlQueryCondition();
                newCondition.Init(ColumnList);
                _conditionPos.Y += newCondition.Height;
                newCondition.Location = _conditionPos;
                newCondition.ConditionItem = queryConditionItem;
                _conditionCount++;
                newCondition.Name = "Condition" + _conditionCount;
                Controls.Add(newCondition);

                if (!ColumnList.Contains(queryConditionItem.ColName))
                {
                    strErrMsg += queryConditionItem.ColName +
                                 "Query Condition Field is not exist in collection any more" + Environment.NewLine;
                }
            }

            if (strErrMsg != String.Empty)
            {
                MyMessageBox.ShowMessage("Load Exception", "A Exception is happened when loading", strErrMsg, true);
            }
        }

        /// <summary>
        ///     清除条件
        /// </summary>
        public void ClearCondition()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(5, 0);
            AddCondition();
        }
    }
}