using System;
using System.Windows.Forms;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class ctlAddBsonEl : UserControl
    {
        public Boolean IsSetted {
            get {
                if (txtElName.Text == String.Empty | txtElValue.Text == String.Empty | cmbDataType.Text == String.Empty)
                {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        public BsonElement Element
        {
            get
            {
                BsonValue value = null;
                if (cmbDataType.SelectedIndex == 0)
                {
                    value = new BsonString(txtElValue.Text);
                }
                if (cmbDataType.SelectedIndex == 1)
                {
                    value = new BsonInt32(Convert.ToInt16(txtElValue.Text));
                }
                if (cmbDataType.SelectedIndex == 2)
                {
                    value = new BsonDateTime(Convert.ToDateTime(txtElValue.Text));
                }
                if (cmbDataType.SelectedIndex == 3)
                {
                    if (txtElValue.Text.ToUpper() == "TRUE")
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
                BsonElement el = new BsonElement(txtElName.Text, value);
                return el;
            }
            set {
                txtElName.Text = value.Name;
                txtElValue.Text = value.Value.ToString();
                if (value.Value.IsString)
                {
                    cmbDataType.SelectedIndex = 0;
                }
                if (value.Value.IsInt32)
                {
                    cmbDataType.SelectedIndex = 1;
                }
                if (value.Value.IsDateTime)
                {
                    cmbDataType.SelectedIndex = 2;
                }
                if (value.Value.IsBoolean)
                {
                    cmbDataType.SelectedIndex = 3;
                }
            }
        }
        public ctlAddBsonEl()
        {
            InitializeComponent();
            //数据类型
            cmbDataType.Items.Add("字符");
            cmbDataType.Items.Add("整形");
            cmbDataType.Items.Add("日期");
            cmbDataType.Items.Add("布尔");
        }
        private void ctlAddBsonEl_Load(object sender, EventArgs e)
        {
        }
    }
}
