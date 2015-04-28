using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoGUICtl.Aggregation
{
    public partial class GroupPanel : UserControl
    {
        /// <summary>
        ///     GroupItem数量
        /// </summary>
        private byte _conditionCount;

        /// <summary>
        ///     GroupItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);

        /// <summary>
        ///     构造器
        /// </summary>
        public GroupPanel()
        {
            InitializeComponent();
            AddGroupItem();
        }

        /// <summary>
        ///     增加GroupItem
        /// </summary>
        public void AddGroupItem()
        {
            _conditionCount++;
            var newGroupItem = new GroupItem();
            newGroupItem.Location = _conditionPos;
            newGroupItem.Name = "GroupItem" + _conditionCount;
            Controls.Add(newGroupItem);
            _conditionPos.Y += newGroupItem.Height;
        }

        public List<BsonElement> GetGroup()
        {
            //db.article.aggregate(
            //    { $group : {
            //        _id : "$author",
            //        docsPerAuthor : { $sum : 1 },
            //        viewsPerAuthor : { $sum : "$pageViews" }
            //    }}
            //);
            var grouplist = new List<BsonElement>();
            foreach (GroupItem item in Controls)
            {
                grouplist.Add(item.GetGroupItem());
            }
            return grouplist;
        }

        /// <summary>
        ///     清除所有GroupItem
        /// </summary>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddGroupItem();
        }
    }
}