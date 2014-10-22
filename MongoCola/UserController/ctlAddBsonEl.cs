using System;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoCola
{
    public partial class ctlAddBsonEl : UserControl
    {
        public ctlAddBsonEl()
        {
            InitializeComponent();
            lblElement.Visible = false;
        }

        /// <summary>
        ///     是否设定
        /// </summary>
        public Boolean IsSetted
        {
            get
            {
                if (txtElName.Text == String.Empty | ElBsonValue.getValue() == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///     切换为元素修改模式
        /// </summary>
        public void switchToUpdateMode()
        {
            txtElName.Visible = false;
            lblElement.Visible = true;
        }

        public void switchToValueMode()
        {
            txtElName.Visible = false;
            lblElement.Visible = false;
        }

        /// <summary>
        ///     Get Element or Bsonvalue
        /// </summary>
        public BsonElement getElement()
        {
            BsonValue value = ElBsonValue.getValue();
            var el = new BsonElement(txtElName.Text, value);
            return el;
        }

        /// <summary>
        ///     Set Element or Bsonvalue
        /// </summary>
        /// <param name="value"></param>
        public void setElement(Object value)
        {
            if (value.GetType() == typeof (BsonElement))
            {
                txtElName.Text = ((BsonElement) value).Name;
                lblElement.Text = ((BsonElement) value).Name;
                ElBsonValue.setValue(((BsonElement) value).Value);
            }
            else
            {
                ElBsonValue.setValue((BsonValue) value);
            }
        }
    }
}