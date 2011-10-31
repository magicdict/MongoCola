using System;
using System.Drawing;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmQuery : QLFUI.QLFForm
    {
        MongoCollection mongocol = SystemManager.GetCurrentCollection();
        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte ConditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        Point ConditionPos = new Point(5, 20);
        public frmQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            Point Pos = new Point(5, 20);
            foreach (var item in MongoDBHelpler.ColumnList)
            {
                //输出配置的初始化
                MongoDBHelpler.QueryFieldItem mQueryFieldList = new MongoDBHelpler.QueryFieldItem();
                mQueryFieldList.ColName = item;
                mQueryFieldList.IsShow = true;
                mQueryFieldList.sortType = MongoDBHelpler.SortType.NoSort;
                //动态加载控件
                ctlFieldInfo ctrItem = new ctlFieldInfo();
                ctrItem.Name = item;
                ctrItem.Location = Pos;
                ctrItem.QueryFieldItem = mQueryFieldList;
                grpFieldInfo.Controls.Add(ctrItem);
                //纵向位置的累加
                Pos.Y += ctrItem.Height;

                ctlQueryCondition First = new ctlQueryCondition();
                First.Location = ConditionPos;
                First.Name = "Condition" + ConditionCount.ToString();
                grpFilter.Controls.Add(First);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //清除以前的结果和内部变量，重要！
            MongoDBHelpler.ClearFilter();
            foreach (var item in MongoDBHelpler.ColumnList)
            {
                MongoDBHelpler.QueryFieldList.Add(((ctlFieldInfo)Controls.Find(item, true)[0]).QueryFieldItem);
            }
            for (int i = 0; i < ConditionCount; i++)
            {
                ctlQueryCondition ctl = (ctlQueryCondition)Controls.Find("Condition" + (i + 1).ToString(), true)[0];
                if (ctl.IsSeted)
                {
                    MongoDBHelpler.QueryCompareList.Add(ctl.CompareItem);
                }
            }
            //启用过滤器
            MongoDBHelpler.IsUseFilter = true;
            this.Close();
        }

        private void cmdAddCondition_Click(object sender, EventArgs e)
        {
            ConditionCount++;
            ctlQueryCondition NewCondition = new ctlQueryCondition();
            ConditionPos.Y += NewCondition.Height;
            NewCondition.Location = ConditionPos;
            NewCondition.Name = "Condition" + ConditionCount.ToString();
            grpFilter.Controls.Add(NewCondition);
        }


    }
}
