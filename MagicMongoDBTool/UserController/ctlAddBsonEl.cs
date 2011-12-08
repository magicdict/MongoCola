using System;
using System.Windows.Forms;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class ctlAddBsonEl : UserControl
    {
        /// <summary>
        /// 切换为元素修改模式
        /// </summary>
        public void switchToUpdateMode()
        {
            txtElName.Visible = false;
            lblElement.Visible = true;
        }
        /// <summary>
        /// 是否设定
        /// </summary>
        public Boolean IsSetted
        {
            get
            {
                if (txtElName.Text == String.Empty | ElBsonValue.getValue() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 取得元素
        /// </summary>
        public BsonElement getElement()
        {
            BsonValue value = ElBsonValue.getValue();
            BsonElement el = new BsonElement(txtElName.Text, value);
            return el;
        }
        /// <summary>
        /// 设置元素
        /// </summary>
        /// <param name="value"></param>
        public void setElement(BsonElement value)
        {
            txtElName.Text = value.Name;
            lblElement.Text = value.Name;
            ElBsonValue.setValue(value.Value);
        }
        public ctlAddBsonEl()
        {
            InitializeComponent();
            lblElement.Visible = false;
        }
    }
}
