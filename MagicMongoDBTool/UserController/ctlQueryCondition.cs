using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class ctlQueryCondition : UserControl
    {
        public ctlQueryCondition()
        {
            InitializeComponent();
        }
        public List<String> ColumnList;
        public Boolean IsSeted
        {
            get
            {
                return (cmbCompareOpr.SelectedIndex != -1);
            }
        }
        public DataFilter.QueryConditionInputItem ConditionItem
        {
            get
            {
                if (cmbCompareOpr.SelectedIndex != -1)
                {
                    DataFilter.QueryConditionInputItem rtn = new DataFilter.QueryConditionInputItem();
                    rtn.Comp = (DataFilter.CompareEnum)cmbCompareOpr.SelectedIndex;
                    if (cmbDataType.SelectedIndex == 0)
                    {
                        rtn.Type = BsonType.String;
                    }
                    if (cmbDataType.SelectedIndex == 1)
                    {
                        rtn.Type = BsonType.Int32;
                    }
                    if (cmbDataType.SelectedIndex == 2)
                    {
                        rtn.Type = BsonType.DateTime;
                    }
                    if (cmbDataType.SelectedIndex == 3)
                    {
                        rtn.Type = BsonType.Boolean;
                    }
                    rtn.Value = txtValue.Text;
                    rtn.StartMark = cmbStartMark.Text;
                    rtn.EndMark = cmbEndMark.Text;
                    rtn.ColName = cmbColName.Text;
                    return rtn;
                }
                else
                {
                    return new DataFilter.QueryConditionInputItem();
                }
            }
            set
            {
                cmbColName.Text = value.ColName;
                cmbDataType.SelectedIndex = 0;
                if (value.Type == BsonType.String)
                {
                    cmbDataType.SelectedIndex = 0;
                }
                if (value.Type == BsonType.Int32)
                {
                    cmbDataType.SelectedIndex = 1;
                }
                if (value.Type == BsonType.DateTime)
                {
                    cmbDataType.SelectedIndex = 2;
                }
                if (value.Type == BsonType.Boolean)
                {
                    cmbDataType.SelectedIndex = 3;
                }
                txtValue.Text = value.Value.ToString();
                cmbCompareOpr.SelectedIndex = (int)value.Comp;
                cmbStartMark.Text = value.StartMark;
                cmbEndMark.Text = value.EndMark;
            }
        }
        /// <summary>
        /// 清除控件
        /// </summary>
        public void clear()
        {
            txtValue.Text = "";
            cmbCompareOpr.SelectedIndex = -1;
            cmbCompareOpr.Text = "";
            cmbDataType.SelectedIndex = 0;
            cmbStartMark.SelectedIndex = 0;
            cmbEndMark.SelectedIndex = 0;
        }
        public void Init(List<String> ColumnList)
        {
            cmbStartMark.Items.Add(" ");
            cmbStartMark.Items.Add("(");
            cmbStartMark.SelectedIndex = 0;

            cmbEndMark.Items.Add(" ");
            cmbEndMark.Items.Add(MongoDBHelper.EndMark_AND);
            cmbEndMark.Items.Add(MongoDBHelper.EndMark_OR);
            cmbEndMark.Items.Add(MongoDBHelper.EndMark_AND_T);
            cmbEndMark.Items.Add(MongoDBHelper.EndMark_OR_T);
            cmbEndMark.Items.Add(MongoDBHelper.EndMark_T);
            cmbEndMark.SelectedIndex = 0;

            //数据类型
            cmbDataType.Items.Add("字符");
            cmbDataType.Items.Add("整形");
            cmbDataType.Items.Add("日期");
            cmbDataType.Items.Add("布尔");

            //字段表的载入
            foreach (var item in ColumnList)
            {
                this.cmbColName.Items.Add(item);
            }
            //逻辑操作符号的载入
            foreach (var item in Enum.GetNames(typeof(DataFilter.CompareEnum)))
            {
                cmbCompareOpr.Items.Add(item);
            }
        }
    }
}
