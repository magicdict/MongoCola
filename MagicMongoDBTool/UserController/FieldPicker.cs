using System;
using System.Drawing;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Collections.Generic;

namespace MagicMongoDBTool
{
    public partial class FieldPicker : UserControl
    {
        private List<DataFilter.QueryFieldItem> mQueryFieldList = new List<DataFilter.QueryFieldItem>();
        /// <summary>
        /// QueryFieldList
        /// </summary>
        public List<DataFilter.QueryFieldItem> QueryFieldList
        {
            set
            {
                mQueryFieldList = value;
                SetFieldList();
            }
            get
            {
                List<DataFilter.QueryFieldItem> rtnList = new List<DataFilter.QueryFieldItem>();
                foreach (var item in mQueryFieldList)
                {
                    rtnList.Add(((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).QueryFieldItem);
                }
                return rtnList;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public FieldPicker()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载控件
        /// </summary>
        private void SetFieldList()
        {
            Point _conditionPos = new Point(20, 30);
            //清除所有的控件
            Controls.Clear();
            Controls.Add(btnSelectAll);
            Controls.Add(btnUnSelectAll);

            foreach (DataFilter.QueryFieldItem queryFieldItem in mQueryFieldList)
            {
                //动态加载控件
                ctlFieldInfo ctrItem = new ctlFieldInfo();
                ctrItem.Name = queryFieldItem.ColName;
                ctrItem.Location = _conditionPos;
                ctrItem.QueryFieldItem = queryFieldItem;
                Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).IsShow = true;
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).IsShow = false;
            }

        }
    }
}
