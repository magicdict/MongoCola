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
        public Boolean IsSeted{
            get { 
                return(cmbCompareOpr.SelectedIndex != -1);
            }
        }
        public MongoDBHelpler.QueryConditionInputItem CompareItem
        { 
            get{
                if (cmbCompareOpr.SelectedIndex != -1)
                {
                    MongoDBHelpler.QueryConditionInputItem rtn = new MongoDBHelpler.QueryConditionInputItem();
                    rtn.Comp = (MongoDBHelpler.CompareEnum)cmbCompareOpr.SelectedIndex;
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
                else {
                    return new MongoDBHelpler.QueryConditionInputItem();
                }
            }
            set{
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
        public void clear() {
            txtValue.Text = "";
            cmbCompareOpr.SelectedIndex = -1;
            cmbCompareOpr.Text = "";
            cmbDataType.SelectedIndex = 0;
            cmbStartMark.SelectedIndex = 0;
            cmbEndMark.SelectedIndex = 0;
        }
        private void ctlQueryCondition_Load(object sender, EventArgs e)
        {
            cmbStartMark.Items.Add(" ");
            cmbStartMark.Items.Add("(");
            cmbStartMark.SelectedIndex = 0;

            cmbEndMark.Items.Add(" ");    
            cmbEndMark.Items.Add(" AND ");    
            cmbEndMark.Items.Add(" OR ");    
            cmbEndMark.Items.Add(") AND ");    
            cmbEndMark.Items.Add(") OR ");    
            cmbEndMark.Items.Add(")");
            cmbEndMark.SelectedIndex = 0;

            //数据类型
            cmbDataType.Items.Add("字符");
            cmbDataType.Items.Add("整形");
            cmbDataType.Items.Add("日期");
            cmbDataType.Items.Add("布尔");

            //字段表的载入
            foreach (var item in MongoDBHelpler.ColumnList)
            {
                this.cmbColName.Items.Add(item);
            }
            //逻辑操作符号的载入
            foreach (var item in Enum.GetNames(typeof(MongoDBHelpler.CompareEnum)))
            {
                cmbCompareOpr.Items.Add(item);
            }
        }
    }
}
