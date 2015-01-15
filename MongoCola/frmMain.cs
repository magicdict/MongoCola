using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SystemUtility;
using Common.Logic;
using MongoCola.Connection;
using MongoGUICtl;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using PlugInPackage;
using ResourceLib.Properties;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola
{
    public partial class frmMain
    {
        #region"MainForm"

        /// <summary>
        ///     切换Tab的时候，必须切换当前对象
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            GetSystemIcon.InitTabViewImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            tabView.ImageList = GetSystemIcon.TabViewImage;
            SetMenuImage();
            if (!SystemConfig.guiConfig.IsUseDefaultLanguage)
            {
                //Set Menu Text
                SetMenuText();
            }
            //Init ToolBar
            InitToolBar();
            Text += "  " + SystemConfig.Version;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemConfig.MonoMode)
            {
                Text += " MONO";
            }
        }

        #region "多文档视图管理"

        /// <summary>
        ///     多文档视图管理
        /// </summary>
        public static Dictionary<string, DataViewInfo> _viewInfoList =
            new Dictionary<string, DataViewInfo>();

        /// <summary>
        ///     多文档视图管理
        /// </summary>
        public static Dictionary<string, TabPage> _viewTabList = new Dictionary<string, TabPage>();

        #endregion

        /// <summary>
        ///     Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //加载插件
            PlugInSetting();
            //禁用操作
            DisableAllOpr();
            //Set Tool bar button enable
            SetToolBarEnabled();
            //Open ConnectionManagement Form
            Utility.OpenForm(new frmConnect(), true, true);
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
            CommandHelper.RunCommandComplete += CommandLog;
            //长时间操作时候，实时提示进度在状态栏中
            lblAction.Text = string.Empty;
            MongoUtility.Basic.Utility.ActionDone += (x, y) =>
            {
                //1.lblAction 没有InvokeRequired
                //2.DoEvents必须
                lblAction.Text = y.Message;
                Application.DoEvents();
            };
        }

        /// <summary>
        ///     加载插件信息
        /// </summary>
        private void PlugInSetting()
        {
            try
            {
                PlugIn.LoadPlugIn();
                foreach (var plugin in PlugIn.PlugInList)
                {
                    var PlugInType = string.Empty;
                    switch (plugin.Value.RunLv)
                    {
                        case PlugInBase.PathLv.ConnectionLV:
                            PlugInType = "[Connection]";
                            break;
                        case PlugInBase.PathLv.InstanceLV:
                            PlugInType = "[Instance]";
                            break;
                        case PlugInBase.PathLv.DatabaseLV:
                            PlugInType = "[Database]";
                            break;
                        case PlugInBase.PathLv.CollectionLV:
                            PlugInType = "[Collection]";
                            break;
                        case PlugInBase.PathLv.DocumentLV:
                            PlugInType = "[Document]";
                            break;
                        case PlugInBase.PathLv.Misc:
                            PlugInType = "[Misc]";
                            break;
                    }
                    ToolStripItem menu = new ToolStripMenuItem(plugin.Value.PlugName + PlugInType);
                    menu.ToolTipText = plugin.Value.PlugFunction;
                    menu.Tag = plugin.Key;
                    menu.Click += (x, y) => PlugIn.RunPlugIn(plugin.Key);
                    plugInToolStripMenuItem.DropDownItems.Add(menu);
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
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
                RuntimeMongoDBContext._CurrentMongoConnectionconfig = SystemConfig.config.ConnectionList[mongoSvrKey];
                if (string.IsNullOrEmpty(RuntimeMongoDBContext._CurrentMongoConnectionconfig.UserName))
                {
                    lblUserInfo.Text = "UserInfo:Admin";
                }
                else
                {
                    lblUserInfo.Text = "UserInfo:" + RuntimeMongoDBContext._CurrentMongoConnectionconfig.UserName;
                }
                if (RuntimeMongoDBContext._CurrentMongoConnectionconfig.AuthMode)
                {
                    lblUserInfo.Text += " @AuthMode";
                }
                if (RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly)
                {
                    lblUserInfo.Text += " [ReadOnly]";
                }
                if (!RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly)
                {
                    //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                    RestoreMongoToolStripMenuItem.Enabled = true;
                }
                RuntimeMongoDBContext.SelectObjectTag = string.Empty;
                if (RuntimeMongoDBContext.SelectObjectTag != null)
                {
                    RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
                }
                switch (strNodeType)
                {
                    case ConstMgr.CONNECTION_TAG:
                    case ConstMgr.CONNECTION_REPLSET_TAG:
                    case ConstMgr.CONNECTION_CLUSTER_TAG:
                        ConnectionHandler(strNodeType, e);
                        break;
                    case ConstMgr.CONNECTION_EXCEPTION_TAG:
                        ExceptionConnectionHandler(strNodeType, e);
                        break;
                    case ConstMgr.SERVER_TAG:
                        ServerHandler(strNodeType, e);
                        break;
                    case ConstMgr.SINGLE_DB_SERVER_TAG:
                        SingleDBServerHandler(strNodeType, e);
                        break;
                    case ConstMgr.DATABASE_TAG:
                    case ConstMgr.SINGLE_DATABASE_TAG:
                        DataBaseHandler(strNodeType, e);
                        break;
                    case ConstMgr.SYSTEM_COLLECTION_LIST_TAG:
                        RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "System Collection List ";
                        break;
                    case ConstMgr.COLLECTION_LIST_TAG:
                        RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "Collection List ";
                        break;
                    case ConstMgr.COLLECTION_TAG:
                        CollectionHandler(strNodeType, e);
                        break;
                    case ConstMgr.INDEX_TAG:
                        if (SystemConfig.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + RuntimeMongoDBContext.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Index) +
                                ":" +
                                RuntimeMongoDBContext.SelectTagData;
                        }
                        break;
                    case ConstMgr.INDEXES_TAG:
                        if (SystemConfig.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + RuntimeMongoDBContext.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Indexes) +
                                ":" +
                                RuntimeMongoDBContext.SelectTagData;
                        }
                        break;
                    case ConstMgr.USER_LIST_TAG:
                        if (SystemConfig.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected UserList:" + RuntimeMongoDBContext.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_UserList) +
                                ":" +
                                RuntimeMongoDBContext.SelectTagData;
                        }
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemConfig.MonoMode)
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
                    case ConstMgr.GRID_FILE_SYSTEM_TAG:
                        //GridFileSystem
                        RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemConfig.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected GFS:" + RuntimeMongoDBContext.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_GFS) +
                                ":" +
                                RuntimeMongoDBContext.SelectTagData;
                        }

                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemConfig.MonoMode)
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
                    case ConstMgr.JAVASCRIPT_TAG:
                        RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (!RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly)
                        {
                            creatJavaScriptToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemConfig.MonoMode)
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
                    case ConstMgr.JAVASCRIPT_DOC_TAG:
                        statusStripMain.Items[0].Text = "Selected JavaScript:" + RuntimeMongoDBContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemConfig.MonoMode)
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

            ShutDownToolStripMenuItem.Image = GetResource.GetImage(ImageType.ShutDown);

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

            ShutDownToolStripButton = ShutDownToolStripMenuItem.CloneFromMenuItem();

            OptionToolStripButton = OptionsToolStripMenuItem.CloneFromMenuItem();
            UserGuideToolStripButton = UserGuideToolStripMenuItem.CloneFromMenuItem();
            //暂时不对应MONO
            if (SystemConfig.MonoMode)
            {
                RefreshToolStripButton.Click += RefreshToolStripMenuItem_Click;
                ShutDownToolStripButton.Click += ShutDownToolStripMenuItem_Click;
                OptionToolStripButton.Click += OptionToolStripMenuItem_Click;
                UserGuideToolStripButton.Click += userGuideToolStripMenuItem_Click;
            }
            //Main ToolTip
            toolStripMain.Items.Add(ExpandAllConnectionToolStripButton);
            toolStripMain.Items.Add(CollapseAllConnectionToolStripButton);
            toolStripMain.Items.Add(RefreshToolStripButton);
            toolStripMain.Items.Add(ExitToolStripButton);
            toolStripMain.Items.Add(new ToolStripSeparator());
            toolStripMain.Items.Add(ShutDownToolStripButton);
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
            ShutDownToolStripButton.Enabled = ShutDownToolStripMenuItem.Enabled;
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
                RuntimeMongoDBContext.SelectObjectTag = tabView.SelectedTab.Tag.ToString();
            }
        }

        /// <summary>
        ///     ViewData
        /// </summary>
        private void ViewDataObj()
        {
            switch (RuntimeMongoDBContext.SelectTagType)
            {
                case ConstMgr.USER_LIST_TAG:
                    MongoUtility.Basic.Utility.InitDBUser(RuntimeMongoDBContext.GetCurrentDataBase());
                    ViewDataRecord();
                    break;
                case ConstMgr.GRID_FILE_SYSTEM_TAG:
                    MongoUtility.Basic.Utility.InitGFS(RuntimeMongoDBContext.GetCurrentDataBase());
                    ViewDataRecord();
                    break;
                case ConstMgr.JAVASCRIPT_TAG:
                    MongoUtility.Basic.Utility.InitJavascript(RuntimeMongoDBContext.GetCurrentDataBase());
                    break;
                case ConstMgr.JAVASCRIPT_DOC_TAG:
                    ViewJavascript();
                    break;
                case ConstMgr.COLLECTION_TAG:
                case ConstMgr.DOCUMENT_TAG:
                    ViewDataRecord();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     View Js
        /// </summary>
        private void ViewJavascript()
        {
            var DataList = RuntimeMongoDBContext.SelectTagData.Split("/".ToCharArray());

            if (_viewTabList.ContainsKey(RuntimeMongoDBContext.SelectTagData))
            {
                tabView.SelectTab(_viewTabList[RuntimeMongoDBContext.SelectTagData]);
            }
            else
            {
                var JsName = DataList[(int) EnumMgr.PathLv.DocumentLv];
                var JsEditor = new ctlJsEditor {strDBtag = RuntimeMongoDBContext.SelectObjectTag};
                var DataTab = new TabPage(JsName)
                {
                    Tag = RuntimeMongoDBContext.SelectObjectTag,
                    ImageIndex = 1
                };

                JsEditor.JsName = JsName;
                DataTab.Controls.Add(JsEditor);
                JsEditor.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                var DataMenuItem = new ToolStripMenuItem(JsName)
                {
                    Tag = DataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[1]
                };
                JavaScriptStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += (x, y) => tabView.SelectTab(DataTab);
                _viewTabList.Add(RuntimeMongoDBContext.SelectTagData, DataTab);
                JsEditor.CloseTab += (x, y) =>
                {
                    tabView.Controls.Remove(DataTab);
                    _viewTabList.Remove(RuntimeMongoDBContext.SelectTagData);
                    JavaScriptStripMenuItem.DropDownItems.Remove(DataMenuItem);
                };
                tabView.SelectTab(DataTab);
            }
        }

        /// <summary>
        ///     Create a DataView Tab
        /// </summary>
        private void ViewDataRecord()
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            var DataKey = RuntimeMongoDBContext.SelectTagData;
            if (_viewTabList.ContainsKey(DataKey))
            {
                tabView.SelectTab(_viewTabList[DataKey]);
            }
            else
            {
                var mDataViewInfo = new DataViewInfo
                {
                    strDBTag = RuntimeMongoDBContext.SelectObjectTag,
                    IsUseFilter = false,
                    IsReadOnly = RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly,
                    mDataFilter = new DataFilter()
                };

                //mDataViewInfo.IsSafeMode = config.IsSafeMode;

                ctlDataView DataViewctl;
                switch (RuntimeMongoDBContext.SelectTagType)
                {
                    case ConstMgr.GRID_FILE_SYSTEM_TAG:
                        DataViewctl = new ctlGFSView(mDataViewInfo);
                        break;
                    case ConstMgr.USER_LIST_TAG:
                        DataViewctl = new ctlUserView(mDataViewInfo);
                        break;
                    default:
                        DataViewctl = new ctlDocumentView(mDataViewInfo);
                        break;
                }


                DataViewctl.mDataViewInfo = mDataViewInfo;

                var DataTab = new TabPage(RuntimeMongoDBContext.GetCurrentCollection().FullName)
                {
                    Tag = RuntimeMongoDBContext.SelectObjectTag,
                    ToolTipText = RuntimeMongoDBContext.SelectObjectTag
                };

                switch (RuntimeMongoDBContext.SelectTagType)
                {
                    case ConstMgr.COLLECTION_TAG:
                        DataTab.ImageIndex = 2;
                        break;
                    case ConstMgr.USER_LIST_TAG:
                        DataTab.ImageIndex = 3;
                        break;
                    default:
                        DataTab.ImageIndex = 4;
                        break;
                }

                DataTab.Controls.Add(DataViewctl);
                DataViewctl.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                var DataMenuItem = new ToolStripMenuItem(RuntimeMongoDBContext.GetCurrentCollection().Name)
                {
                    Tag = DataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[DataTab.ImageIndex]
                };
                collectionToolStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += (x, y) => tabView.SelectTab(DataTab);
                _viewTabList.Add(DataKey, DataTab);
                _viewInfoList.Add(DataKey, mDataViewInfo);
                DataViewctl.CloseTab += (x, y) =>
                {
                    tabView.Controls.Remove(DataTab);
                    _viewTabList.Remove(DataKey);
                    _viewInfoList.Remove(DataKey);
                    collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
                    DataTab = null;
                };
                tabView.SelectTab(DataTab);
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
                ctl.RefreshGUI();
            }
        }

        #endregion
    }
}