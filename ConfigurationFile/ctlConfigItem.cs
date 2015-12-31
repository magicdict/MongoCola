using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.UI;

namespace ConfigurationFile
{
    public partial class CtlConfigItem : UserControl
    {
        public CtlConfigItem()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     值的配置
        /// </summary>
        public ConfigurationFileOption.ConfigValue GetItemValue()
        {
            var rtnOptionItem = ConfigItemDefine.ConfigurationItemDictionary[lblPath.Text];
            var rtnValue = new ConfigurationFileOption.ConfigValue();
            rtnValue.Path = lblPath.Text;
            switch (rtnOptionItem.ValueType)
            {
                case ConfigurationFileOption.MetaType.String:
                    rtnValue.ValueLiteral = txtValue.Text;
                    break;
                case ConfigurationFileOption.MetaType.PathName:
                    rtnValue.ValueLiteral = fileValue.SelectedPathOrFileName;
                    break;
                case ConfigurationFileOption.MetaType.FileName:
                    rtnValue.ValueLiteral = fileValue.SelectedPathOrFileName;
                    break;
                case ConfigurationFileOption.MetaType.Int:
                    rtnValue.ValueLiteral = intValue.Text;
                    break;
                case ConfigurationFileOption.MetaType.Boolean:
                    if (radTrue.Checked)
                    {
                        rtnValue.ValueLiteral = "true";
                    }
                    else
                    {
                        rtnValue.ValueLiteral = "false";
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

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public void SetItemValue(ConfigurationFileOption.ConfigValue value)
        {
            var rtnOptionItem = ConfigItemDefine.ConfigurationItemDictionary[value.Path];
            switch (rtnOptionItem.ValueType)
            {
                case ConfigurationFileOption.MetaType.String:
                    txtValue.Text = value.ValueLiteral;
                    break;
                case ConfigurationFileOption.MetaType.PathName:
                    fileValue.SelectedPathOrFileName = value.ValueLiteral;
                    break;
                case ConfigurationFileOption.MetaType.FileName:
                    fileValue.SelectedPathOrFileName = value.ValueLiteral;
                    break;
                case ConfigurationFileOption.MetaType.Int:
                    intValue.Text = value.ValueLiteral;
                    break;
                case ConfigurationFileOption.MetaType.Boolean:
                    if (value.ValueLiteral.Equals("true"))
                    {
                        radTrue.Checked = true;
                    }
                    else
                    {
                        radFalse.Checked = true;
                    }
                    break;
                case ConfigurationFileOption.MetaType.List:
                    cmbValue.Text = value.ValueLiteral;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     定义的配置
        /// </summary>
        public void SetItemDefine(ConfigurationFileOption.Define value)
        {
            //版本检查
            lblPrimaryVersion.Text = string.Empty;
            if (value.NewSinceVersion != EnumMgr.PrimaryVersion.V000)
            {
                //新版本
                lblPrimaryVersion.Text = "New Since " + value.NewSinceVersion;
            }
            if (value.DeprecatedSinceversion != EnumMgr.PrimaryVersion.V000)
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

            fileValue.Visible = false;

            switch (value.ValueType)
            {
                case ConfigurationFileOption.MetaType.String:
                    lblString.Visible = true;
                    txtValue.Visible = true;
                    if (ConfigItemDefine.SelectedConfigurationValueDictionary.ContainsKey(value.Path))
                    {
                        var selectValue = ConfigItemDefine.SelectedConfigurationValueDictionary[value.Path];
                        txtValue.Text = selectValue.ValueLiteral;
                    }
                    break;
                case ConfigurationFileOption.MetaType.PathName:
                    fileValue.Visible = true;
                    fileValue.PickerType = CtlFilePicker.DialogType.Directory;
                    break;
                case ConfigurationFileOption.MetaType.FileName:
                    fileValue.Visible = true;
                    fileValue.PickerType = CtlFilePicker.DialogType.SaveFile;
                    break;
                case ConfigurationFileOption.MetaType.Int:
                    intValue.Visible = true;
                    lblInteger.Visible = true;
                    if (!(value.RangeMax == 0 && value.RangeMin == 0))
                    {
                        intValue.Maximum = value.RangeMax;
                        intValue.Minimum = value.RangeMin;
                    }
                    if (ConfigItemDefine.SelectedConfigurationValueDictionary.ContainsKey(value.Path))
                    {
                        var selectValue = ConfigItemDefine.SelectedConfigurationValueDictionary[value.Path];
                        intValue.Text = selectValue.ValueLiteral;
                    }
                    break;
                case ConfigurationFileOption.MetaType.Boolean:
                    lblBoolean.Visible = true;
                    radFalse.Visible = true;
                    radTrue.Visible = true;
                    if (ConfigItemDefine.SelectedConfigurationValueDictionary.ContainsKey(value.Path))
                    {
                        var selectValue = ConfigItemDefine.SelectedConfigurationValueDictionary[value.Path];
                        if (selectValue.ValueLiteral == true.ToString())
                        {
                            radTrue.Checked = true;
                        }
                        else
                        {
                            radFalse.Checked = true;
                        }
                    }
                    break;
                case ConfigurationFileOption.MetaType.List:
                    lblList.Visible = true;
                    cmbValue.Visible = true;
                    //Load ValueList
                    cmbValue.Items.Clear();
                    foreach (var optionalValue in value.OptionValueList)
                    {
                        cmbValue.Items.Add(optionalValue);
                    }
                    if (ConfigItemDefine.SelectedConfigurationValueDictionary.ContainsKey(value.Path))
                    {
                        var selectValue = ConfigItemDefine.SelectedConfigurationValueDictionary[value.Path];
                        cmbValue.Text = selectValue.ValueLiteral;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}