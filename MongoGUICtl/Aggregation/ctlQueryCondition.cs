﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Basic;

namespace MongoGUICtl
{
    public partial class CtlQueryCondition : UserControl
    {
        public List<string> ColumnList;

        public CtlQueryCondition()
        {
            InitializeComponent();
        }

        public bool IsSeted
        {
            get
            {
                return cmbCompareOpr.SelectedIndex != -1;
            }
        }

        public DataFilter.QueryConditionInputItem ConditionItem
        {
            get
            {
                if (cmbCompareOpr.SelectedIndex != -1)
                {
                    var rtn = new DataFilter.QueryConditionInputItem()
                    {
                        Compare = (DataFilter.CompareEnum)cmbCompareOpr.SelectedIndex,
                        Value = new BsonValueEx(ElBsonValue.GetValue()),
                        StartMark = cmbStartMark.Text,
                        EndMark = cmbEndMark.Text,
                        ColName = cmbColName.Text
                    };
                    return rtn;
                }
                return new DataFilter.QueryConditionInputItem();
            }
            set
            {
                cmbColName.Text = value.ColName;
                ElBsonValue.SetValue(value.Value.GetBsonValue());
                cmbCompareOpr.SelectedIndex = (int)value.Compare;
                cmbStartMark.Text = value.StartMark;
                cmbEndMark.Text = value.EndMark;
            }
        }

        public void Init(List<string> columnList)
        {
            cmbStartMark.Items.Add(string.Empty);
            cmbStartMark.Items.Add(ConstMgr.StartMarkT);
            cmbStartMark.SelectedIndex = 0;
            cmbEndMark.Items.Add(string.Empty);
            cmbEndMark.Items.Add(ConstMgr.EndMarkAnd);
            cmbEndMark.Items.Add(ConstMgr.EndMarkOr);
            cmbEndMark.Items.Add(ConstMgr.EndMarkAndT);
            cmbEndMark.Items.Add(ConstMgr.EndMarkOrT);
            cmbEndMark.Items.Add(ConstMgr.EndMarkT);
            cmbEndMark.SelectedIndex = 0;
            //字段表的载入
            Common.UIAssistant.FillComberWithArray(cmbColName, columnList.ToArray(), true);
            //逻辑操作符号的载入
            Common.UIAssistant.FillComberWithEnum(cmbCompareOpr, typeof(DataFilter.CompareEnum), true);
            cmbCompareOpr.SelectedIndex = -1;
        }

        public delegate void ItemChanged(object sender);

        public event ItemChanged ItemRemoved;

        public event ItemChanged ItemAdded;
        /// <summary>
        /// 触发Remove事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemRemoved(this);
        }
        /// <summary>
        /// 触发Add事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemAdded(this);
        }
    }
}