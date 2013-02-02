using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class FieldPicker : UserControl
    {
        private bool mIDProtectMode;
        /// <summary>
        /// ID的显示属性是否可变
        /// </summary>
        public bool IsIDProtect
        {
            set { mIDProtectMode = value; }
            get { return mIDProtectMode; }
        }
        private List<DataFilter.QueryFieldItem> mQueryFieldList = new List<DataFilter.QueryFieldItem>();
        /// <summary>
        /// QueryFieldList
        /// </summary>
        public void setQueryFieldList(List<DataFilter.QueryFieldItem> value)
        {
            mQueryFieldList = value;
            SetFieldList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DataFilter.QueryFieldItem> getQueryFieldList()
        {
            List<DataFilter.QueryFieldItem> rtnList = new List<DataFilter.QueryFieldItem>();
            foreach (var item in mQueryFieldList)
            {
                rtnList.Add(((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).QueryFieldItem);
            }
            return rtnList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mIsShow"></param>
        public void InitByCurrentCollection(bool mIsShow)
        {
            List<String> ColumnList = MongoDBHelper.GetCollectionSchame(SystemManager.GetCurrentCollection());
            List<DataFilter.QueryFieldItem> FieldList = new List<DataFilter.QueryFieldItem>();
            foreach (String item in ColumnList)
            {
                //输出配置的初始化
                DataFilter.QueryFieldItem queryFieldItem = new DataFilter.QueryFieldItem();
                queryFieldItem.ColName = item;
                queryFieldItem.IsShow = mIsShow;
                queryFieldItem.sortType = DataFilter.SortType.NoSort;
                if (queryFieldItem.ColName == MongoDBHelper.KEY_ID)
                {
                    queryFieldItem.IsShow = true;
                }
                FieldList.Add(queryFieldItem);
            }
            mQueryFieldList = FieldList;
            SetFieldList();
        }
        /// <summary>
        /// Aggregation用的$project和$order
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetAggregation()
        {
            BsonDocument Aggregation = new BsonDocument();
            BsonDocument project = new BsonDocument();
            BsonDocument sort = new BsonDocument();
            foreach (var item in mQueryFieldList)
            {
                var ctl = ((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.ColName == MongoDBHelper.KEY_ID)
                {
                    if (!ctl.IsShow)
                    {
                        project.Add(new BsonElement(MongoDBHelper.KEY_ID, 0));
                    }
                }
                else
                {
                    if (ctl.IsShow)
                    {
                        project.Add(new BsonElement(ctl.ColName, 1));
                    }
                }
                switch (ctl.sortType)
                {
                    case DataFilter.SortType.NoSort:
                        break;
                    case DataFilter.SortType.Ascending:
                        sort.Add(new BsonElement(ctl.ColName, 1));
                        break;
                    case DataFilter.SortType.Descending:
                        sort.Add(new BsonElement(ctl.ColName, -1));
                        break;
                    default:
                        break;
                }
            }
            //Note The $sort cannot begin sorting documents until previous operators in the pipeline have returned all output.
            //如果先$project，再$sort的话，全字段输出
            if (sort.ElementCount > 0)
            {
                Aggregation.Add(new BsonElement("$sort", sort));
            }
            Aggregation.Add(new BsonElement("$project", project));
            return Aggregation;
        }
        /// <summary>
        /// FieldPicker
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
                ctrItem.IsIDProtect = mIDProtectMode;
                ctrItem.QueryFieldItem = queryFieldItem;
                Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
        }
        /// <summary>
        /// 全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).IsShow = true;
            }
        }
        /// <summary>
        /// 全部不选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo)Controls.Find(item.ColName, true)[0]).IsShow = false;
            }

        }
    }
}
