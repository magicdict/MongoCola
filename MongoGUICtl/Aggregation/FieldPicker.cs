using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoGUICtl.Aggregation
{
    public partial class FieldPicker : UserControl
    {
        private List<DataFilter.QueryFieldItem> mQueryFieldList = new List<DataFilter.QueryFieldItem>();

        /// <summary>
        ///     FieldPicker
        /// </summary>
        public FieldPicker()
        {
            InitializeComponent();
        }

        public ctlFieldInfo.FieldMode FieldListMode { get; set; }

        /// <summary>
        ///     ID的显示属性是否可变
        /// </summary>
        public bool IsIDProtect { set; get; }

        /// <summary>
        ///     QueryFieldList
        /// </summary>
        public void setQueryFieldList(List<DataFilter.QueryFieldItem> value)
        {
            mQueryFieldList = value;
            SetFieldList();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<DataFilter.QueryFieldItem> getQueryFieldList()
        {
            var rtnList = new List<DataFilter.QueryFieldItem>();
            foreach (var item in mQueryFieldList)
            {
                rtnList.Add(((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem);
            }
            return rtnList;
        }

        /// <summary>
        /// </summary>
        /// <param name="mIsShow"></param>
        public void InitByCurrentCollection(bool mIsShow)
        {
            var ColumnList = Utility.GetCollectionSchame(RuntimeMongoDBContext.GetCurrentCollection());
            var FieldList = new List<DataFilter.QueryFieldItem>();
            foreach (var item in ColumnList)
            {
                //输出配置的初始化
                var queryFieldItem = new DataFilter.QueryFieldItem();
                queryFieldItem.ColName = item;
                queryFieldItem.IsShow = mIsShow;
                queryFieldItem.sortType = DataFilter.SortType.NoSort;
                if (queryFieldItem.ColName == ConstMgr.KEY_ID)
                {
                    queryFieldItem.IsShow = true;
                }
                FieldList.Add(queryFieldItem);
            }
            mQueryFieldList = FieldList;
            SetFieldList();
        }

        /// <summary>
        ///     Aggregation用的$project和$order
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetAggregation()
        {
            var Aggregation = new BsonDocument();
            var project = new BsonDocument();
            var sort = new BsonDocument();
            foreach (var item in mQueryFieldList)
            {
                var ctl = ((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.ColName == ConstMgr.KEY_ID)
                {
                    if (!ctl.IsShow)
                    {
                        project.Add(new BsonElement(ConstMgr.KEY_ID, 0));
                    }
                }
                else
                {
                    if (ctl.IsShow)
                    {
                        project.Add(string.IsNullOrEmpty(ctl.ProjectName)
                            ? new BsonElement(ctl.ColName, 1)
                            : new BsonElement(ctl.ProjectName, "$" + ctl.ColName));
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
        ///     获取Group的ID
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetAggregationGroup()
        {
            var Aggregation = new BsonDocument();
            var project = new BsonDocument();
            foreach (var item in mQueryFieldList)
            {
                var ctl = ((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.IsShow)
                {
                    project.Add(string.IsNullOrEmpty(ctl.ProjectName)
                        ? new BsonElement(ctl.ColName, ctl.ColName)
                        : new BsonElement(ctl.ProjectName, "$" + ctl.ColName));
                }
            }
            Aggregation.Add("_id", project);
            return Aggregation;
        }

        /// <summary>
        ///     加载控件
        /// </summary>
        private void SetFieldList()
        {
            var _conditionPos = new Point(20, 30);
            //清除所有的控件
            Controls.Clear();
            Controls.Add(btnSelectAll);
            Controls.Add(btnUnSelectAll);

            foreach (var queryFieldItem in mQueryFieldList)
            {
                //动态加载控件
                var ctrItem = new ctlFieldInfo();
                ctrItem.Mode = FieldListMode;
                ctrItem.Name = queryFieldItem.ColName;
                ctrItem.Location = _conditionPos;
                ctrItem.IsIDProtect = IsIDProtect;
                ctrItem.QueryFieldItem = queryFieldItem;
                Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
        }

        /// <summary>
        ///     全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).IsShow = true;
            }
        }

        /// <summary>
        ///     全部不选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in mQueryFieldList)
            {
                ((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).IsShow = false;
            }
        }

        /// <summary>
        ///     GroupID
        /// </summary>
        /// <returns></returns>
        public BsonDocument getGroupID()
        {
            // { _id : { author: '$author', pageViews: '$pageViews', posted: '$posted' } }
            var id = new BsonDocument();
            var member = new BsonDocument();
            foreach (var item in mQueryFieldList)
            {
                var ctl = ((ctlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.IsShow && ctl.ColName != "_id")
                {
                    member.Add(string.IsNullOrEmpty(ctl.ProjectName)
                        ? new BsonElement(ctl.ColName, "$" + ctl.ColName)
                        : new BsonElement(ctl.ProjectName, "$" + ctl.ColName));
                }
            }
            id.Add("_id", member);
            return id;
        }
    }
}