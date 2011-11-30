using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class ctlBsonValue : UserControl
    {
        public BsonValue Value
        {
            get
            {
                BsonValue value = null;
                if (cmbDataType.SelectedIndex == 0)
                {
                    value = new BsonString(txtBsonValue.Text);
                }
                if (cmbDataType.SelectedIndex == 1)
                {
                    value = new BsonInt32(Convert.ToInt16(txtBsonValue.Text));
                }
                if (cmbDataType.SelectedIndex == 2)
                {
                    value = new BsonDateTime(Convert.ToDateTime(txtBsonValue.Text));
                }
                if (cmbDataType.SelectedIndex == 3)
                {
                    if (txtBsonValue.Text.ToUpper() == "TRUE")
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
                return value;
            }
            set
            {
                if (value == null) {
                    return;
                }
                txtBsonValue.Text = value.ToString();
                if (value.IsString)
                {
                    cmbDataType.SelectedIndex = 0;
                }
                if (value.IsInt32)
                {
                    cmbDataType.SelectedIndex = 1;
                }
                if (value.IsDateTime)
                {
                    cmbDataType.SelectedIndex = 2;
                }
                if (value.IsBoolean)
                {
                    cmbDataType.SelectedIndex = 3;
                }
            }
        }
        public ctlBsonValue()
        {
            InitializeComponent();
            if (SystemManager.IsUseDefaultLanguage())
            {
                cmbDataType.Items.Add("字符");
                cmbDataType.Items.Add("整形");
                cmbDataType.Items.Add("日期");
                cmbDataType.Items.Add("布尔");
            }
            else {
                if (SystemManager.mStringResource != null)
                {
                    cmbDataType.Items.Add(SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_BsonType_String));
                    cmbDataType.Items.Add(SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_BsonType_Integer));
                    cmbDataType.Items.Add(SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_BsonType_DateTime));
                    cmbDataType.Items.Add(SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_BsonType_Boolean));
                }
            }
        }
    }
}
