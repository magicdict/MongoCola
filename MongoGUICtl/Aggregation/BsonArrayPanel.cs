using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoGUICtl.Aggregation
{
    public partial class BsonArrayPanel : UserControl
    {

        /// <summary>
        ///     ArrayItem数量
        /// </summary>
        private byte _conditionCount;

        /// <summary>
        ///     GroupItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);

        /// <summary>
        ///     构造器
        /// </summary>
        public BsonArrayPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsonValuePanel_Load(object sender, EventArgs e)
        {
            AddBsonValueItem();
        }

        /// <summary>
        ///     增加BsonValueItem
        /// </summary>
        public void AddBsonValueItem()
        {
            _conditionCount++;
            var newBsonValueItem = new ctlBsonValueType()
            {
                Location = _conditionPos,
                Name = "BsonValueItem" + _conditionCount
            };
            Controls.Add(newBsonValueItem);
            _conditionPos.Y += newBsonValueItem.Height;
        }

        /// <summary>
        ///     获得数组
        /// </summary>
        /// <returns></returns>
        public BsonArray GetBsonArray()
        {
            var valueList = new BsonArray();
            foreach (ctlBsonValueType item in Controls)
            {
                if (item.GetValue() != null)
                {
                    valueList.Add(item.GetValue());
                }
            }
            return valueList;
        }

        /// <summary>
        ///     清除所有数组
        /// </summary>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddBsonValueItem();
        }
    }
}