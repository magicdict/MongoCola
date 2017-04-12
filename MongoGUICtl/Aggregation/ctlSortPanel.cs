using MongoDB.Bson;
using ResourceLib.Method;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlSortPanel : UserControl
    {

        /// <summary>
        ///     MatchItem数量
        /// </summary>
        private byte SortItemCount;

        /// <summary>
        ///     MatchItem位置
        /// </summary>
        private Point CurrentPos = new Point(10, 40);

        public ctlSortPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlSortPanel_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(Controls);
        }

        /// <summary>
        ///     数据集路径
        /// </summary>
        public string CollectionPath { set; get; }

        /// <summary>
        /// 增加排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SortItemCount++;
            var newSortItem = new ctlSortItem()
            {
                Location = CurrentPos,
                Name = "SortItem" + SortItemCount
            };
            Controls.Add(newSortItem);
            CurrentPos.Y += newSortItem.Height;
        }


        /// <summary>
        ///     ItemChanged
        /// </summary>
        /// <param name="sender"></param>
        public delegate void ItemChanged(object sender);
        /// <summary>
        ///     ItemRemoved
        /// </summary>
        public event ItemChanged ItemRemoved;
        /// <summary>
        ///     ItemAdded
        /// </summary>
        public event ItemChanged ItemAdded;
        /// <summary>
        /// 触发Remove事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            ItemRemoved(this);
        }

        /// <summary>
        /// 触发Add事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemAdded(this);
        }

        /// <summary>
        /// 获得排序文档
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetSortDocument()
        {
            var sortlist = new BsonDocument();
            foreach (Control item in Controls)
            {
                if (item.GetType().FullName == typeof(Button).FullName) continue;
                var sort = ((ctlSortItem)item).GetSortItem();
                if (sort != null)
                {
                    var sortName = sort.Name;
                    if (!string.IsNullOrEmpty(sortName))
                    {
                        sortlist.Add(sort);
                    }
                }
            }
            if (sortlist.ElementCount > 0)
            {
                return new BsonDocument("$sort", sortlist);
            }
            return null;
        }
        /// <summary>
        ///     清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMatch_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            SortItemCount = 0;
            CurrentPos = new Point(10, 40);
        }

    }
}
