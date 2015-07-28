using System.Windows.Forms;
using MongoUtility.Core;

namespace ConfigurationFile
{
    public partial class ctlConfigItem : UserControl
    {

        public ctlConfigItem()
        {
            InitializeComponent();
        }

        public ConfigurationFileOption.Define ItemDefine
        {
            set
            {
                //版本检查
                lblPrimaryVersion.Text = string.Empty;
                if (value.NewSinceVersion != MongoUtility.Basic.EnumMgr.PrimaryVersion.V000)
                {
                    //新版本
                    lblPrimaryVersion.Text = "New Since " + value.NewSinceVersion;
                }
                if (value.DeprecatedSinceversion != MongoUtility.Basic.EnumMgr.PrimaryVersion.V000)
                {
                    //过时版本
                    lblPrimaryVersion.Text = "Deprecated Since " + value.DeprecatedSinceversion;
                }
                //路径
                lblPath.Text = value.Path;
                lblDescription.Text = value.Description;
                lblValueType.Text = value.ValueType.ToString();

                //全部不可见
                lblBoolean.Visible = false;
                lblInteger.Visible = false;
                lblList.Visible = false;
                lblString.Visible = false;

                radFalse.Visible = false;
                radTrue.Visible = false;
                intValue.Visible = false;
                cmbValue.Visible = false;
                txtValue.Visible = false;

                switch (value.ValueType)
                {
                    case ConfigurationFileOption.MetaType.String:
                        lblString.Visible = true;
                        txtValue.Visible = true;
                        break;
                    case ConfigurationFileOption.MetaType.DirName:
                        break;
                    case ConfigurationFileOption.MetaType.FileName:
                        break;
                    case ConfigurationFileOption.MetaType.Int:
                        intValue.Visible = true;
                        lblInteger.Visible = true;
                        break;
                    case ConfigurationFileOption.MetaType.Boolean:
                        lblBoolean.Visible = true;
                        radFalse.Visible = true;
                        radTrue.Visible = true;
                        break;
                    case ConfigurationFileOption.MetaType.List:
                        lblList.Visible = true;
                        cmbValue.Visible = true;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
