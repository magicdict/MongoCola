using PlugInPrj;
using ResourceLib.Method;
using ResourceLib.Properties;
using ResourceLib.UI;
using System.Windows.Forms;

namespace MongoCola
{
    /// <summary>
    ///     Description of frmMain_Helper.
    /// </summary>
    public partial class frmMain : Form
    {

        /// <summary>
        ///     设置图标
        /// </summary>
        private void SetMenuImage()
        {
            ExitToolStripMenuItem.Image = Resources.exit.ToBitmap();
            ExpandAllConnectionToolStripMenuItem.Image = GetResource.GetImage(ImageType.Expand);
            CollapseAllConnectionToolStripMenuItem.Image = GetResource.GetImage(ImageType.Collpse);
            DelMongoCollectionToolStripMenuItem.Image = GetResource.GetIcon(IconType.No).ToBitmap();
            DelMongoDBToolStripMenuItem.Image = GetResource.GetIcon(IconType.No).ToBitmap();

            RefreshToolStripMenuItem.Image = GetResource.GetImage(ImageType.Refresh);
            OptionsToolStripMenuItem.Image = GetResource.GetImage(ImageType.Option);

            ThanksToolStripMenuItem.Image = GetResource.GetImage(ImageType.Smile);
            UserGuideToolStripMenuItem.Image = GetResource.GetIcon(IconType.UserGuide).ToBitmap();
        }

        /// <summary>
        ///     初始化Toolbar
        /// </summary>
        private void InitToolBar()
        {
            ExpandAllConnectionToolStripButton = ExpandAllConnectionToolStripMenuItem.CloneFromMenuItem();
            CollapseAllConnectionToolStripButton = CollapseAllConnectionToolStripMenuItem.CloneFromMenuItem();
            RefreshToolStripButton = RefreshToolStripMenuItem.CloneFromMenuItem();
            ExitToolStripButton = ExitToolStripMenuItem.CloneFromMenuItem();
            OptionToolStripButton = OptionsToolStripMenuItem.CloneFromMenuItem();
            UserGuideToolStripButton = UserGuideToolStripMenuItem.CloneFromMenuItem();

            if (SystemManager.MonoMode)
            {
                ExpandAllConnectionToolStripButton.Click += ExpandAllToolStripMenuItem_Click;
                CollapseAllConnectionToolStripButton.Click += CollapseAllToolStripMenuItem_Click;
                RefreshToolStripButton.Click += RefreshToolStripMenuItem_Click;
                ExitToolStripButton.Click += ExitToolStripMenuItem_Click;
                OptionToolStripButton.Click += OptionToolStripMenuItem_Click;
                UserGuideToolStripButton.Click += userGuideToolStripMenuItem_Click;
            }
            //Main ToolTip
            toolStripMain.Items.Add(ExpandAllConnectionToolStripButton);
            toolStripMain.Items.Add(CollapseAllConnectionToolStripButton);
            toolStripMain.Items.Add(RefreshToolStripButton);
            toolStripMain.Items.Add(ExitToolStripButton);
            toolStripMain.Items.Add(new ToolStripSeparator());
            toolStripMain.Items.Add(OptionToolStripButton);
            toolStripMain.Items.Add(UserGuideToolStripButton);
        }

        /// <summary>
        ///     设定工具栏
        /// </summary>
        private void SetToolBarEnabled()
        {
            UserGuideToolStripButton.Enabled = true;
            RefreshToolStripButton.Enabled = true;
            OptionToolStripButton.Enabled = true;
        }

        /// <summary>
        ///     禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {
            //管理-服务器
            CreateMongoDBToolStripMenuItem.Enabled = false;
            AddUserToAdminToolStripMenuItem.Enabled = false;
            AddAdminCustomeRoleStripMenuItem.Enabled = false;
            ServerStatusToolStripMenuItem.Enabled = false;
            InitReplsetToolStripMenuItem.Enabled = false;
            ReplicaSetToolStripMenuItem.Enabled = false;
            ShardingConfigToolStripMenuItem.Enabled = false;
            DisconnectToolStripMenuItem.Enabled = false;
            ServerMonitorToolStripMenuItem.Enabled = false;

            //管理-数据库
            CreateMongoCollectionToolStripMenuItem.Enabled = false;
            CreateViewtoolStripMenuItem.Enabled = false;
            CopyDatabasetoolStripMenuItem.Enabled = false;
            DelMongoDBToolStripMenuItem.Enabled = false;
            AddUserToolStripMenuItem.Enabled = false;
            AddDBCustomeRoleStripMenuItem.Enabled = false;
            EvalJSToolStripMenuItem.Enabled = false;
            RepairDBToolStripMenuItem.Enabled = false;
            InitGFSToolStripMenuItem.Enabled = false;
            DBStatusToolStripMenuItem.Enabled = false;
            ProfillingLevelToolStripMenuItem.Enabled = false;

            //管理-数据集
            IndexManageToolStripMenuItem.Enabled = false;
            ReIndexToolStripMenuItem.Enabled = false;
            RenameCollectionToolStripMenuItem.Enabled = false;
            DelMongoCollectionToolStripMenuItem.Enabled = false;
            CompactToolStripMenuItem.Enabled = false;
            ViewDataToolStripMenuItem.Enabled = false;
            AggregationToolStripMenuItem.Enabled = false;
            creatJavaScriptToolStripMenuItem.Enabled = false;
            dropJavascriptToolStripMenuItem.Enabled = false;
            CollectionStatusToolStripMenuItem.Enabled = false;
            ValidateToolStripMenuItem.Enabled = false;
            ExportToFileToolStripMenuItem.Enabled = false;
            ConvertToCappedtoolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            DumpDatabaseToolStripMenuItem.Enabled = false;
            RestoreMongoToolStripMenuItem.Enabled = false;
            DumpCollectionToolStripMenuItem.Enabled = false;
            ImportCollectionToolStripMenuItem.Enabled = false;
            ExportCollectionToolStripMenuItem.Enabled = false;

            //插件
            foreach (ToolStripItem item in plugInToolStripMenuItem.DropDownItems)
            {
                if (item.Tag != null)
                {
                    item.Enabled = PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.Misc;
                }
            }
        }
    }
}