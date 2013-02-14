using MongoDB.Bson;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmArrayCreator : Form
    {
        /// <summary>
        /// BsonArray
        /// </summary>
        public BsonArray mBsonArray;
        public frmArrayCreator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayPanel.AddBsonValueItem();
        }
        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ArrayPanel.Clear();
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            mBsonArray = ArrayPanel.GetBsonArray();
            this.Close();
        }
    }
}
