using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoGUICtl
{
    public partial class CtlAddBsonEl : UserControl
    {
        public CtlAddBsonEl()
        {
            InitializeComponent();
            lblElement.Visible = false;
        }

        /// <summary>
        ///     是否设定
        /// </summary>
        public bool IsSetted
        {
            get
            {
                if (txtElName.Text == string.Empty | ElBsonValue.GetValue() == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///     切换为元素修改模式
        /// </summary>
        public void SwitchToUpdateMode()
        {
            txtElName.Visible = false;
            lblElement.Visible = true;
        }

        public void SwitchToValueMode()
        {
            txtElName.Visible = false;
            lblElement.Visible = false;
        }

        /// <summary>
        ///     Get Element or Bsonvalue
        /// </summary>
        public BsonElement GetElement()
        {
            var value = ElBsonValue.GetValue();
            var el = new BsonElement(txtElName.Text, value);
            return el;
        }

        /// <summary>
        ///     Set Element or Bsonvalue
        /// </summary>
        /// <param name="value"></param>
        public void SetElement(object value)
        {
            if (value.GetType() == typeof (BsonElement))
            {
                txtElName.Text = ((BsonElement) value).Name;
                lblElement.Text = ((BsonElement) value).Name;
                ElBsonValue.SetValue(((BsonElement) value).Value);
            }
            else
            {
                ElBsonValue.SetValue((BsonValue) value);
            }
        }
    }
}