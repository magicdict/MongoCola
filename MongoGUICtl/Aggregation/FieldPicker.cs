using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace MongoGUICtl.Aggregation
{
    public partial class FieldPicker : UserControl
    {
        private List<DataFilter.QueryFieldItem> _mQueryFieldList = new List<DataFilter.QueryFieldItem>();

        /// <summary>
        ///     FieldPicker
        /// </summary>
        public FieldPicker()
        {
            InitializeComponent();
        }

        public CtlFieldInfo.FieldMode FieldListMode { get; set; }

        /// <summary>
        ///     ID的显示属性是否可变
        /// </summary>
        public bool IsIdProtect { set; get; }

        private void FieldPicker_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(Controls);
        }

        /// <summary>
        ///     QueryFieldList
        /// </summary>
        public void SetQueryFieldList(List<DataFilter.QueryFieldItem> value)
        {
            _mQueryFieldList = value;
            SetFieldList();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<DataFilter.QueryFieldItem> GetQueryFieldList()
        {
            var rtnList = new List<DataFilter.QueryFieldItem>();
            foreach (var item in _mQueryFieldList)
            {
                rtnList.Add(((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem);
            }
            return rtnList;
        }

        /// <summary>
        /// </summary>
        /// <param name="mIsShow"></param>
        public void InitByCurrentCollection(bool mIsShow)
        {
            var columnList =
                MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection());
            var fieldList = new List<DataFilter.QueryFieldItem>();
            foreach (var item in columnList)
            {
                //输出配置的初始化
                var queryFieldItem = new DataFilter.QueryFieldItem();
                queryFieldItem.ColName = item;
                queryFieldItem.IsShow = mIsShow;
                queryFieldItem.SortType = DataFilter.SortType.NoSort;
                if (queryFieldItem.ColName == ConstMgr.KeyId)
                {
                    queryFieldItem.IsShow = true;
                }
                fieldList.Add(queryFieldItem);
            }
            _mQueryFieldList = fieldList;
            SetFieldList();
        }

        /// <summary>
        ///     Aggregation用的$project和$order
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetAggregation()
        {
            var aggregation = new BsonDocument();
            var project = new BsonDocument();
            var sort = new BsonDocument();
            foreach (var item in _mQueryFieldList)
            {
                var ctl = ((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.ColName == ConstMgr.KeyId)
                {
                    if (!ctl.IsShow)
                    {
                        project.Add(new BsonElement(ConstMgr.KeyId, 0));
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
                switch (ctl.SortType)
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
                aggregation.Add(new BsonElement("$sort", sort));
            }
            aggregation.Add(new BsonElement("$project", project));
            return aggregation;
        }

        /// <summary>
        ///     获取Group的ID
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetAggregationGroup()
        {
            var aggregation = new BsonDocument();
            var project = new BsonDocument();
            foreach (var item in _mQueryFieldList)
            {
                var ctl = ((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
                if (ctl.IsShow)
                {
                    project.Add(string.IsNullOrEmpty(ctl.ProjectName)
                        ? new BsonElement(ctl.ColName, ctl.ColName)
                        : new BsonElement(ctl.ProjectName, "$" + ctl.ColName));
                }
            }
            aggregation.Add("_id", project);
            return aggregation;
        }

        /// <summary>
        ///     加载控件
        /// </summary>
        private void SetFieldList()
        {
            var conditionPos = new Point(20, 30);
            //清除所有的控件
            Controls.Clear();
            Controls.Add(btnSelectAll);
            Controls.Add(btnUnSelectAll);
            Controls.Add(lblSortOrder);
            foreach (var queryFieldItem in _mQueryFieldList.OrderBy(info => info.ColName))
            {
                //动态加载控件
                var ctrItem = new CtlFieldInfo
                {
                    Mode = FieldListMode,
                    Name = queryFieldItem.ColName,
                    Location = conditionPos,
                    IsIdProtect = IsIdProtect,
                    QueryFieldItem = queryFieldItem,
                    Width = 450
                };
                Controls.Add(ctrItem);
                //纵向位置的累加
                conditionPos.Y += ctrItem.Height;
            }
        }

        /// <summary>
        ///     全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _mQueryFieldList)
            {
                ((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).IsShow = true;
            }
        }

        /// <summary>
        ///     全部不选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _mQueryFieldList)
            {
                ((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).IsShow = false;
            }
        }

        /// <summary>
        ///     GroupID
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetGroupId()
        {
            // { _id : { author: '$author', pageViews: '$pageViews', posted: '$posted' } }
            var id = new BsonDocument();
            var member = new BsonDocument();
            foreach (var item in _mQueryFieldList)
            {
                var ctl = ((CtlFieldInfo) Controls.Find(item.ColName, true)[0]).QueryFieldItem;
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