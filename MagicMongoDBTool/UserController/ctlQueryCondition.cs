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
                    rtn.Compare = (DataFilter.CompareEnum)cmbCompareOpr.SelectedIndex;
                    rtn.Value = new BsonValueEx(ElBsonValue.getValue());
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
                ElBsonValue.setValue(value.Value.GetBsonValue());
                cmbCompareOpr.SelectedIndex = (int)value.Compare;
                cmbStartMark.Text = value.StartMark;
                cmbEndMark.Text = value.EndMark;
            }
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
