using System;
using System.IO;
using System.Windows.Forms;
using Common;
using ResourceLib.UI;
using ResourceLib.Method;

namespace ConfigurationFile
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //选择器初始化
            ConfigItemDefine.SaveDefines();
            ctlConfFile.PickerType = CtlFilePicker.DialogType.SaveFile;
            ctlConfFile.FileFilter = Utility.ConfFilter;
            if (File.Exists(ConfigItemDefine.ValueFilename)) ConfigItemDefine.LoadValues();
            RefreshSelectItemList();
            var cRoot = ConfigItemDefine.LoadDefines();
            var rootTreeNode = new TreeNode("Config");
            FillTreeView(cRoot, rootTreeNode);
            trvConfig.Nodes.Add(rootTreeNode);
            trvConfig.ExpandAll();
			var MonoMode = Type.GetType("Mono.Runtime") != null;
			if (MonoMode) {
				this.Text = "Configuration File";
				this.Font = GuiConfig.GetMonoFont (this.Font);
			}
        }

        /// <summary>
        ///     数型目录的装配
        /// </summary>
        /// <param name="cRoot"></param>
        /// <param name="rootTreeNode"></param>
        private void FillTreeView(CTreeNode cRoot, TreeNode rootTreeNode)
        {
            foreach (var child in cRoot.Children)
            {
                var childTreeNode = new TreeNode(child.Text);
                if (child.Children.Count == 0)
                {
                    childTreeNode.Tag = child.Path;
                }
                FillTreeView(child, childTreeNode);
                rootTreeNode.Nodes.Add(childTreeNode);
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
        private void btnOK_Click(object sender, EventArgs e)
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigItemDefine.SaveValues();
            ConfigItemDefine.SaveAsYmal(ctlConfFile.SelectedPathOrFileName);
        }

        /// <summary>
        ///     选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstConfigValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            var key = ((ListBox) sender).SelectedItems[0].ToString().Split(":".ToCharArray())[0];
            configEditor.SetItemDefine(ConfigItemDefine.ConfigurationItemDictionary[key]);
            configEditor.SetItemValue(ConfigItemDefine.SelectedConfigurationValueDictionary[key]);
        }

        private void btnServiceCommand_Click(object sender, EventArgs e)
        {
            var temp = "sc.exe create MongoDB binPath= \"" + ctlMongoBin.SelectedPathOrFileName +
                       "\\mongod.exe --service --config =\\\"" + ctlConfFile.SelectedPathOrFileName +
                       "\\\"\" DisplayName= \"MongoDB\" start= \"auto\"";
            txtServiceCommand.Text = temp;
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