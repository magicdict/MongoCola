using System;
using System.Drawing;
using System.Windows.Forms;
using Common;
using MongoCola.Connection;
using MongoGUICtl;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using PlugInPackage;
using ResourceLib.Method;
using ResourceLib.Properties;
using ResourceLib.UI;

namespace MongoCola
{
    public partial class FrmMain
    {
        #region"MainForm"

        /// <summary>
        ///     切换Tab的时候，必须切换当前对象
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            GetSystemIcon.InitTabViewImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            tabView.ImageList = GetSystemIcon.TabViewImage;
            SetMenuImage();
            GuiConfig.Translateform(this);
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                //其他控件
                statusStripMain.Items[0].Text =GuiConfig.GetText(TextType.MainStatusBarTextReady);
                tabSvrStatus.Text =GuiConfig.GetText(TextType.Main_Menu_Mangt_Status);
            }
            //Init ToolBar
            InitToolBar();
            Text += "  " + SystemManager.Version;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemManager.MonoMode)
            {
                Text += " MONO";
            }
        }

        /// <summary>
        ///     Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //加载到菜单
            PlugIn.LoadPlugInMenuItem(plugInToolStripMenuItem);
            //禁用操作
            DisableAllOpr();
            //Set Tool bar button enable
            SetToolBarEnabled();
            //Open ConnectionManagement Form
            Utility.OpenForm(new FrmConnect(), true, true);
            try
            {
                ServerStatusCtl.SetEnable(true);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
            RefreshToolStripMenuItem_Click(sender, e);
            commandShellToolStripMenuItem.Checked = true;
            statusToolStripMenuItem.Checked = true;
            //委托设置
            trvsrvlst.NodeMouseClick += trvsrvlst_NodeMouseClick;
            trvsrvlst.NodeMouseDoubleClick += (x, y) => ViewDataObj();
            ViewDataToolStripMenuItem.Click += (x, y) => ViewDataObj();
            trvsrvlst.KeyDown += trvsrvlst_KeyDown;
            ServerStatusCtl.CloseTab += (x, y) =>
            {
                statusToolStripMenuItem.Checked = false;
                tabView.Controls.Remove(tabSvrStatus);
            };
            ctlShellCommandEditor.CloseTab += (x, y) =>
            {
                commandShellToolStripMenuItem.Checked = false;
                tabView.Controls.Remove(tabCommandShell);
            };
            tabView.SelectedIndexChanged += tabView_SelectedIndexChanged;
            //CommandHelper.RunCommandComplete += CommandLog;
            //长时间操作时候，实时提示进度在状态栏中
            lblAction.Text = string.Empty;
            MongoHelper.ActionDone += (x, y) =>
            {
                //1.lblAction 没有InvokeRequired
                //2.DoEvents必须
                lblAction.Text = y.Message;
                Application.DoEvents();
            };
            //多文档管理器的设定
            MultiTabManger.ViewMenu = collectionToolStripMenuItem;
            MultiTabManger.ViewJsMenu = JavaScriptStripMenuItem;
            MultiTabManger.ViewTabContain = tabView;
        }

        /// <summary>
        ///     KeyEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    //Del
                    if (DelMongoDBToolStripMenuItem.Enabled)
                    {
                        DelMongoDBToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        if (DelMongoCollectionToolStripMenuItem.Enabled)
                        {
                            DelMongoCollectionToolStripMenuItem_Click(null, null);
                        }
                    }
                    break;
                case Keys.F2:
                    //Rename
                    if (RenameCollectionToolStripMenuItem.Enabled)
                    {
                        RenameCollectionToolStripMenuItem_Click(null, null);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     ConnectionList TreeView Node is clicked by mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex != -1)
            {
                statusStripMain.Items[0].Image = GetSystemIcon.MainTreeImage.Images[e.Node.ImageIndex];
            }
            //First , set Every MenuItem to disable
            DisableAllOpr();
            if (e.Node.Tag != null)
            {
                //选中节点的设置
                trvsrvlst.SelectedNode = e.Node;
                var strNodeType = Utility.GetTagType(e.Node.Tag.ToString());
                var mongoSvrKey = Utility.GetTagData(e.Node.Tag.ToString()).Split("/".ToCharArray())[0];
                RuntimeMongoDbContext.CurrentMongoConnectionconfig = MongoConnectionConfig.MongoConfig.ConnectionList[mongoSvrKey];
                if (string.IsNullOrEmpty(RuntimeMongoDbContext.CurrentMongoConnectionconfig.UserName))
                {
                    lblUserInfo.Text = "UserInfo:Admin";
                }
                else
                {
                    lblUserInfo.Text = "UserInfo:" + RuntimeMongoDbContext.CurrentMongoConnectionconfig.UserName;
                }
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.AuthMode)
                {
                    lblUserInfo.Text += " @AuthMode";
                }
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
                {
                    lblUserInfo.Text += " [ReadOnly]";
                }
                if (!RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
                {
                    //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                    RestoreMongoToolStripMenuItem.Enabled = true;
                }
                RuntimeMongoDbContext.SelectObjectTag = string.Empty;
                if (RuntimeMongoDbContext.SelectObjectTag != null)
                {
                    RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                }
                switch (strNodeType)
                {
                    case ConstMgr.ConnectionTag:
                    case ConstMgr.ConnectionReplsetTag:
                    case ConstMgr.ConnectionClusterTag:
                        ConnectionHandler(strNodeType, e);
                        break;
                    case ConstMgr.ConnectionExceptionTag:
                        ExceptionConnectionHandler(e);
                        break;
                    case ConstMgr.ServerTag:
                        ServerHandler(e);
                        break;
                    case ConstMgr.SingleDbServerTag:
                        SingleDBServerHandler(e);
                        break;
                    case ConstMgr.DatabaseTag:
                    case ConstMgr.SingleDatabaseTag:
                        DataBaseHandler(strNodeType, e);
                        break;
                    case ConstMgr.SystemCollectionListTag:
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "System Collection List ";
                        break;
                    case ConstMgr.CollectionListTag:
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "Collection List ";
                        break;
                    case ConstMgr.CollectionTag:
                        CollectionHandler(e);
                        break;
                    case ConstMgr.IndexTag:
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected Index:", TextType.SelectedIndex) +
                                                        ":" + RuntimeMongoDbContext.SelectTagData;
                        break;
                    case ConstMgr.IndexesTag:
                        statusStripMain.Items[0].Text =
                            GuiConfig.GetText("Selected Index:", TextType.SelectedIndexes) + ":" +
                            RuntimeMongoDbContext.SelectTagData;
                        break;
                    case ConstMgr.UserListTag:
                        statusStripMain.Items[0].Text =
                            GuiConfig.GetText("Selected UserList:", TextType.SelectedUserList) + ":" +
                            RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var t8 = ViewDataToolStripMenuItem.Clone();
                                t8.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case ConstMgr.GridFileSystemTag:
                        //GridFileSystem
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected GFS", TextType.SelectedGfs) + ":" +
                                                        RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var t8 = ViewDataToolStripMenuItem.Clone();
                                t8.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case ConstMgr.JavascriptTag:
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (!RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
                        {
                            creatJavaScriptToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var t8 = creatJavaScriptToolStripMenuItem.Clone();
                                t8.Click += creatJavaScriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(creatJavaScriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected collection Javascript";
                        break;
                    case ConstMgr.JavascriptDocTag:
                        statusStripMain.Items[0].Text = "Selected JavaScript:" + RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var t1 = ViewDataToolStripMenuItem.Clone();
                                t1.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(t1);
                                var t8 = dropJavascriptToolStripMenuItem.Clone();
                                t8.Click += dropJavascriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(dropJavascriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    default:
                        statusStripMain.Items[0].Text = "Selected Object:" + e.Node.Text;
                        break;
                }
            }
            else
            {
                statusStripMain.Items[0].Text = "Selected Object:" + e.Node.Text;
            }
            //重新Reset工具栏
            SetToolBarEnabled();
        }

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

            tabSvrStatus.ImageIndex = 0;
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
            //暂时不对应MONO
            if (SystemManager.MonoMode)
            {
                RefreshToolStripButton.Click += RefreshToolStripMenuItem_Click;
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

        #endregion

        #region"View Manager"

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabView.SelectedTab != null && tabView.SelectedTab.Tag != null)
            {
                RuntimeMongoDbContext.SelectObjectTag = tabView.SelectedTab.Tag.ToString();
            }
        }

        /// <summary>
        ///     ViewData
        /// </summary>
        private void ViewDataObj()
        {
            try
            {
                switch (RuntimeMongoDbContext.SelectTagType)
                {
                    case ConstMgr.UserListTag:
                        MongoHelper.InitDbUser();
                        ViewDataRecord();
                        break;
                    case ConstMgr.GridFileSystemTag:
                        MongoHelper.InitGfs();
                        ViewDataRecord();
                        break;
                    case ConstMgr.JavascriptTag:
                        MongoHelper.InitJavascript();
                        break;
                    case ConstMgr.JavascriptDocTag:
                        ViewJavascript();
                        break;
                    case ConstMgr.CollectionTag:
                    case ConstMgr.DocumentTag:
                        ViewDataRecord();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                trvsrvlst.Nodes.Clear();
                trvsrvlst.Nodes.Add("丢失与数据库的连接！");
            }
        }

        /// <summary>
        ///     View Js
        /// </summary>
        private void ViewJavascript()
        {
            var dataList = RuntimeMongoDbContext.SelectTagData.Split("/".ToCharArray());

            if (MultiTabManger.TabInfo.ContainsKey(RuntimeMongoDbContext.SelectTagData))
            {
                tabView.SelectTab(MultiTabManger.TabInfo[RuntimeMongoDbContext.SelectTagData].Tab);
            }
            else
            {
                var jsName = dataList[(int) EnumMgr.PathLv.DocumentLv];
                var jsEditor = new CtlJsEditor {StrDBtag = RuntimeMongoDbContext.SelectObjectTag};
                var dataTab = new TabPage(jsName)
                {
                    Tag = RuntimeMongoDbContext.SelectObjectTag,
                    ImageIndex = 1
                };

                jsEditor.JsName = jsName;
                dataTab.Controls.Add(jsEditor);
                jsEditor.Dock = DockStyle.Fill;
                tabView.Controls.Add(dataTab);

                var dataMenuItem = new ToolStripMenuItem(jsName)
                {
                    Tag = dataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[1]
                };
                JavaScriptStripMenuItem.DropDownItems.Add(dataMenuItem);
                dataMenuItem.Click += (x, y) => tabView.SelectTab(dataTab);
                MultiTabManger.AddTabInfo(RuntimeMongoDbContext.SelectTagData, null, dataTab);
                jsEditor.CloseTab += (x, y) =>
                {
                    tabView.Controls.Remove(dataTab);
                    MultiTabManger.RemoveTabInfo(RuntimeMongoDbContext.SelectTagData);
                    JavaScriptStripMenuItem.DropDownItems.Remove(dataMenuItem);
                };
                tabView.SelectTab(dataTab);
            }
        }

        /// <summary>
        ///     Create a DataView Tab
        /// </summary>
        private void ViewDataRecord()
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            var dataKey = RuntimeMongoDbContext.SelectTagData;
            if (MultiTabManger.TabInfo.ContainsKey(dataKey))
            {
                tabView.SelectTab(MultiTabManger.TabInfo[dataKey].Tab);
            }
            else
            {
                var mDataViewInfo = new DataViewInfo
                {
                    StrDbTag = RuntimeMongoDbContext.SelectObjectTag,
                    IsUseFilter = false,
                    IsReadOnly = RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly,
                    MDataFilter = new DataFilter()
                };

                //mDataViewInfo.IsSafeMode = config.IsSafeMode;

                ctlDataView dataViewctl;
                switch (RuntimeMongoDbContext.SelectTagType)
                {
                    case ConstMgr.GridFileSystemTag:
                        dataViewctl = new ctlGFSView(mDataViewInfo);
                        break;
                    case ConstMgr.UserListTag:
                        dataViewctl = new ctlUserView(mDataViewInfo);
                        break;
                    default:
                        dataViewctl = new ctlDocumentView(mDataViewInfo);
                        break;
                }


                dataViewctl.MDataViewInfo = mDataViewInfo;

                var dataTab = new TabPage(RuntimeMongoDbContext.GetCurrentCollectionFullName())
                {
                    Tag = RuntimeMongoDbContext.SelectObjectTag,
                    ToolTipText = RuntimeMongoDbContext.SelectObjectTag
                };

                switch (RuntimeMongoDbContext.SelectTagType)
                {
                    case ConstMgr.CollectionTag:
                        dataTab.ImageIndex = 2;
                        break;
                    case ConstMgr.UserListTag:
                        dataTab.ImageIndex = 3;
                        break;
                    default:
                        dataTab.ImageIndex = 4;
                        break;
                }

                dataTab.Controls.Add(dataViewctl);
                dataViewctl.Dock = DockStyle.Fill;
                tabView.Controls.Add(dataTab);

                var dataMenuItem = new ToolStripMenuItem(RuntimeMongoDbContext.GetCurrentCollectionName())
                {
                    Tag = dataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[dataTab.ImageIndex]
                };
                collectionToolStripMenuItem.DropDownItems.Add(dataMenuItem);
                dataMenuItem.Click += (x, y) => tabView.SelectTab(dataTab);
                MultiTabManger.AddTabInfo(dataKey, mDataViewInfo, dataTab);

                dataViewctl.CloseTab += (x, y) =>
                {
                    MultiTabManger.RemoveTabInfo(dataKey);
                    tabView.Controls.Remove(dataTab);
                    collectionToolStripMenuItem.DropDownItems.Remove(dataMenuItem);
                    dataTab = null;
                };
                tabView.SelectTab(dataTab);
            }
        }

        /// <summary>
        ///     Refresh View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabView.SelectedTab == null)
                return;
            var ctl = tabView.SelectedTab.Controls[0] as ctlDataView;
            if (ctl != null)
            {
                ctl.RefreshGui();
            }
        }

        #endregion
    }
}