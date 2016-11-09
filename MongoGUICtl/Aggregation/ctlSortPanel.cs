using System;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlSortPanel : UserControl
    {

        public ctlSortPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     数据集路径
        /// </summary>
        public string CollectionPath { set; get; }

        /// <summary>
        ///     增加排序
        /// </summary>
        public void AddSort()
        {
            var newSortItem = new ctlSortItem();
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
    }
}
