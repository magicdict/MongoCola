using System.Windows.Forms;
using Common;

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
            ConfigItemDefine.SaveDefines();

            ctlConfFile.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.SaveFile;
            ctlConfFile.FileFilter = Common.Utility.ConfFilter;
            var CRoot = ConfigItemDefine.LoadDefines();
            TreeNode RootTreeNode = new TreeNode("Config");
            FillTreeView(CRoot, RootTreeNode);
            trvConfig.Nodes.Add(RootTreeNode);
        }

        /// <summary>
        ///     数型目录的装配
        /// </summary>
        /// <param name="CRoot"></param>
        /// <param name="RootTreeNode"></param>
        private void FillTreeView(CTreeNode CRoot,TreeNode RootTreeNode)
        {
            foreach (var child in CRoot.Children)
            {
                TreeNode ChildTreeNode = new TreeNode(child.Text);
                if (child.Children.Count == 0)
                {
                    ChildTreeNode.Tag = child.Path;
                }
                FillTreeView(child, ChildTreeNode);
                RootTreeNode.Nodes.Add(ChildTreeNode);
            }
        }
        /// <summary>
        ///     展示配置项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null) {
                configEditor.ItemDefine = ConfigItemDefine.ConfigurationItemDictionary[e.Node.Tag.ToString()];
            }
        }
        /// <summary>
        ///     添加一个配置项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (ConfigItemDefine.SelectedConfigurationValueDictionary.ContainsKey(configEditor.ItemValue.Path)) {
                ConfigItemDefine.SelectedConfigurationValueDictionary.Remove(configEditor.ItemValue.Path);
            }
            ConfigItemDefine.SelectedConfigurationValueDictionary.Add(configEditor.ItemValue.Path, configEditor.ItemValue);
        }
    }
}
