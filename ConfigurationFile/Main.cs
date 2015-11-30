using System;
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
            ctlConfFile.FileFilter = Utility.ConfFilter;
            if (System.IO.File.Exists(ConfigItemDefine.ValueFilename)) ConfigItemDefine.LoadValues();
            RefreshSelectItemList();
            var CRoot = ConfigItemDefine.LoadDefines();
            TreeNode RootTreeNode = new TreeNode("Config");
            FillTreeView(CRoot, RootTreeNode);
            trvConfig.Nodes.Add(RootTreeNode);
            trvConfig.ExpandAll();
        }

        /// <summary>
        ///     数型目录的装配
        /// </summary>
        /// <param name="CRoot"></param>
        /// <param name="RootTreeNode"></param>
        private void FillTreeView(CTreeNode CRoot, TreeNode RootTreeNode)
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
            if (e.Node.Tag != null)
            {
                configEditor.SetItemDefine(ConfigItemDefine.ConfigurationItemDictionary[e.Node.Tag.ToString()]);
            }
        }
        /// <summary>
        ///     添加一个配置项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            ConfigItemDefine.UpdateValue(configEditor.GetItemValue());
            RefreshSelectItemList();
        }

        /// <summary>
        ///     刷新选择列表
        /// </summary>
        private void RefreshSelectItemList()
        {
            lstConfigValue.Items.Clear();
            foreach (var item in ConfigItemDefine.SelectedConfigurationValueDictionary)
            {
                lstConfigValue.Items.Add(item.Key + ":" + item.Value.ValueLiteral);
            }
        }

        /// <summary>
        ///     保存配置项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            ConfigItemDefine.SaveValues();
            ConfigItemDefine.SaveAsYMAL(ctlConfFile.SelectedPathOrFileName);
        }
        /// <summary>
        ///     选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstConfigValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            var key = ((ListBox)sender).SelectedItems[0].ToString().Split(":".ToCharArray())[0];
            configEditor.SetItemDefine(ConfigItemDefine.ConfigurationItemDictionary[key]);
            configEditor.SetItemValue(ConfigItemDefine.SelectedConfigurationValueDictionary[key]);
        }

        private void btnServiceCommand_Click(object sender, EventArgs e)
        {
            string Temp = "sc.exe create MongoDB binPath= \"" + ctlMongoBin.SelectedPathOrFileName + 
                          "\\mongod.exe --service --config =\\\""  + ctlConfFile.SelectedPathOrFileName + "\\\"\" DisplayName= \"MongoDB\" start= \"auto\"";
            txtServiceCommand.Text = Temp;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstConfigValue.SelectedItems.Count == 1)
            {
                var key = lstConfigValue.SelectedItems[0].ToString().Split(":".ToCharArray())[0];
                ConfigItemDefine.RemoveValue(key);
                RefreshSelectItemList();
            }
        }
    }
}
