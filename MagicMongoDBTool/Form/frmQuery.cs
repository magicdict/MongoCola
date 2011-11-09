using System;
using System.Collections.Generic;
using System.Drawing;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmQuery : QLFUI.QLFForm
    {
        private MongoCollection _mongoCol = SystemManager.GetCurrentCollection();
        private List<String> ColumnList = new List<String>();

        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);
        public frmQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            ColumnList = MongoDBHelpler.GetCollectionSchame(_mongoCol);

            foreach (var item in ColumnList)
            {
                //输出配置的初始化
                MongoDBHelpler.QueryFieldItem queryFieldList = new MongoDBHelpler.QueryFieldItem();
                queryFieldList.ColName = item;
                queryFieldList.IsShow = true;
                queryFieldList.sortType = MongoDBHelpler.SortType.NoSort;
                //动态加载控件
                ctlFieldInfo ctrItem = new ctlFieldInfo();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.QueryFieldItem = queryFieldList;
                tabFieldInfo.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            _conditionPos = new Point(5, 20);
            ctlQueryCondition firstQueryCtl = new ctlQueryCondition();
            firstQueryCtl.Init(ColumnList);
            firstQueryCtl.Location = _conditionPos;
            firstQueryCtl.Name = "Condition" + _conditionCount.ToString();
            tabFilter.Controls.Add(firstQueryCtl);

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //清除以前的结果和内部变量，重要！
            MongoDBHelpler.ClearFilter();
            foreach (var item in ColumnList)
            {
                MongoDBHelpler.QueryFieldList.Add(((ctlFieldInfo)Controls.Find(item, true)[0]).QueryFieldItem);
            }
            for (int i = 0; i < _conditionCount; i++)
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
            _conditionCount++;
            ctlQueryCondition newCondition = new ctlQueryCondition();
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "Condition" + _conditionCount.ToString();
            tabFilter.Controls.Add(newCondition);
        }


    }
}
