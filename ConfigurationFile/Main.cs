using System.Windows.Forms;

namespace ConfigurationFile
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            //选择器初始化
            ctlConfFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            ctlConfFile.FileFilter = Common.Utility.ConfFilter;

            ConfigItemDefine.SaveDefines();
            ConfigItemDefine.LoadDefines();
            ConfigItemDefine.Parse();
            configEditor.ItemDefine = ConfigItemDefine.ConfigurationItemDictionary["systemLog.verbosity"];
        }
    }
}
