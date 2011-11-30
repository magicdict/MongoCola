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
        public void switchToUpdateMode(){
            txtElName.Visible = false;
            lblElement.Visible = true;
        }
        /// <summary>
        /// 是否设定
        /// </summary>
        public Boolean IsSetted {
            get
            {
                if (txtElName.Text == String.Empty | ElBsonValue.Value == null)
                {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        /// <summary>
        /// 元素
        /// </summary>
        public BsonElement Element
        {
            get
            {
                BsonValue value = ElBsonValue.Value;
                BsonElement el = new BsonElement(txtElName.Text, value);
                return el;
            }
            set {
                txtElName.Text = value.Name;
                lblElement.Text = value.Name;
                ElBsonValue.Value = value.Value;
            }
        }
        public ctlAddBsonEl()
        {
            InitializeComponent();
            lblElement.Visible = false;
        }
    }
}
