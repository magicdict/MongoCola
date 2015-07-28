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

        /// <summary>
        ///     值的配置
        /// </summary>
        public ConfigurationFileOption.ConfigValue ItemValue
        {
            get
            {
                var rtnOptionItem = ConfigItemDefine.ConfigurationItemDictionary[lblPath.Text];
                ConfigurationFileOption.ConfigValue rtnValue= new ConfigurationFileOption.ConfigValue();
                rtnValue.Path = lblPath.Text;
                switch (rtnOptionItem.ValueType)
                {
                    case ConfigurationFileOption.MetaType.String:
                        rtnValue.ValueLiteral = txtValue.Text;
                        break;
                    case ConfigurationFileOption.MetaType.DirName:
                        break;
                    case ConfigurationFileOption.MetaType.FileName:
                        break;
                    case ConfigurationFileOption.MetaType.Int:
                        rtnValue.ValueLiteral = intValue.Text;
                        break;
                    case ConfigurationFileOption.MetaType.Boolean:
                        if (radTrue.Checked)
                        {
                            rtnValue.ValueLiteral = true.ToString();
                        }
                        else
                        {
                            rtnValue.ValueLiteral = false.ToString();
                        }
                        break;
                    case ConfigurationFileOption.MetaType.List:
                        rtnValue.ValueLiteral = cmbValue.Text;
                        break;
                    default:
                        break;
                }
                return rtnValue;
            }
            set
            {
                var rtnOptionItem = ConfigItemDefine.ConfigurationItemDictionary[value.Path];
                ConfigurationFileOption.ConfigValue rtnValue = new ConfigurationFileOption.ConfigValue();
                switch (rtnOptionItem.ValueType)
                {
                    case ConfigurationFileOption.MetaType.String:
                        txtValue.Text = value.ValueLiteral;
                        break;
                    case ConfigurationFileOption.MetaType.DirName:
                        break;
                    case ConfigurationFileOption.MetaType.FileName:
                        break;
                    case ConfigurationFileOption.MetaType.Int:
                        intValue.Text = rtnValue.ValueLiteral;
                        break;
                    case ConfigurationFileOption.MetaType.Boolean:
                        if (value.ValueLiteral.Equals(true.ToString()))
                        {
                            radTrue.Checked = true;
                        }
                        else
                        {
                            radFalse.Checked = true;
                        }
                        break;
                    case ConfigurationFileOption.MetaType.List:
                        cmbValue.Text = rtnValue.ValueLiteral;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        ///     定义的配置
        /// </summary>
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
                        if (!(value.RangeMax == 0 && value.RangeMin == 0))
                        {
                            intValue.Maximum = value.RangeMax;
                            intValue.Minimum = value.RangeMin;
                        }
                        break;
                    case ConfigurationFileOption.MetaType.Boolean:
                        lblBoolean.Visible = true;
                        radFalse.Visible = true;
                        radTrue.Visible = true;
                        break;
                    case ConfigurationFileOption.MetaType.List:
                        lblList.Visible = true;
                        cmbValue.Visible = true;
                        //Load ValueList
                        cmbValue.Items.Clear();
                        foreach (var OptionalValue in value.OptionValueList)
                        {
                            cmbValue.Items.Add(OptionalValue);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
