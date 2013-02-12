using System.Drawing;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class GroupPan : UserControl
    {
        /// <summary>
        /// GroupItem数量
        /// </summary>
        private byte _conditionCount = 0;
        /// <summary>
        /// GroupItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);
        /// <summary>
        /// 构造器
        /// </summary>
        public GroupPan()
        {
            InitializeComponent();
            AddGroupItem();
        }
        /// <summary>
        /// 增加GroupItem
        /// </summary>
        public void AddGroupItem()
        {
            _conditionCount++;
            GroupItem newGroupItem = new GroupItem();
            newGroupItem.Location = _conditionPos;
            newGroupItem.Name = "GroupItem" + _conditionCount.ToString();
            Controls.Add(newGroupItem);
            _conditionPos.Y += newGroupItem.Height;
        }
        /// <summary>
        /// 清除所有GroupItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddGroupItem();
        }
    }
}
