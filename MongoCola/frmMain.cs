using Common;
using FunctionForm.Aggregation;
using FunctionForm.Connection;
using FunctionForm.Extend;
using FunctionForm.Operation;
using FunctionForm.Status;
using FunctionForm.User;
using MongoGUICtl;
using MongoGUICtl.ClientTree;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using PlugInPrj;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            GuiConfig.Translateform(this);
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                //其他控件
                statusStripMain.Items[0].Text = GuiConfig.GetText("MainStatusBarTextReady");
            }
            //Init ToolBar
            InitToolBar();
            Text += "  " + SystemManager.Version;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemManager.MonoMode)
            {
                Text += " MONO";
            }
            //获得数据对象方法的注入
            GetInject();
        }

        /// <summary>
        ///     获得数据对象方法的注入
        /// </summary>
        private static void GetInject()
        {
            //新建文档的文档获得方法注入
            CtlDocumentView._getDocument = () =>
            {
                var frmInsertDoc = new frmCreateDocument();
                UIAssistant.OpenModalForm(frmInsertDoc, false, true);
                return frmInsertDoc.mBsonDocument;
            };
            ctlBsonValue.GetDocument = () =>
            {
                var frmInsertDoc = new frmCreateDocument();
                UIAssistant.OpenModalForm(frmInsertDoc, false, true);
                return frmInsertDoc.mBsonDocument;
            };
            ctlBsonValue.GetArray = () =>
            {
                var frmInsertArray = new frmArrayCreator();
                UIAssistant.OpenModalForm(frmInsertArray, false, true);
                return frmInsertArray.mBsonArray;
            };
            ctlBsonValue.GetGeoPoint = () =>
            {
                var frmGeo = new frmCreateGeo();
                UIAssistant.OpenModalForm(frmGeo, false, true);
                return frmGeo.mBsonArray;
            };
            frmGeoNear.GetGeo = () =>
            {
                var frmGeo = new frmCreateGeo();
                UIAssistant.OpenModalForm(frmGeo, false, true);
                return frmGeo.mBsonArray;
            };

            FrmServerMonitor.FreshTimeChanged = (time) =>
            {
                SystemManager.SystemConfig.RefreshStatusTimer = time;
                SystemManager.SystemConfig.SaveSystemConfig();
            };

            FrmServerMonitor.MonitorItemsChanged = (items) =>
            {
                SystemManager.SystemConfig.MonitorItems = items;
                SystemManager.SystemConfig.SaveSystemConfig();
            };

            RuntimeMongoDbContext.GetPassword = (username) =>
            {
                var Password = MyMessageBox.ShowPasswordInput("Please Input Password of " + username, "Password");
                return Password;
            };

            CtlUserView.OpenAddNewUserForm = (isAdmin) =>
            {
                UIAssistant.OpenModalForm(new FrmUser(isAdmin), true, true);
            };
            CtlUserView.OpenChangePasswordForm = (isAdmin, name) =>
            {
                UIAssistant.OpenModalForm(new FrmUser(isAdmin, name), true, true);
            };

            CtlDocumentView.ElementOp = (isUpdate, selectedNode, isElement) =>
            {
                var f = new FrmElement(isUpdate, selectedNode, isElement);
                f.ShowDialog();
            };
            CtlGfsView.GetUploadFileOption = () =>
            {
                var opt = new Gfs.UpLoadFileOption();
                var frm = new FrmGfsOption();
                frm.ShowDialog();
                opt.AlreadyOpt = frm.Option;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                opt.FileNameOpt = frm.Filename;
                opt.IgnoreSubFolder = frm.IgnoreSubFolder;
                return opt;
            };
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
            UIAssistant.OpenModalForm(new frmConnect(), true, true);

            //多文档管理器的设定
            var parentMenuItems = new List<ToolStripMenuItem>
            {
                CollectionToolStripMenuItem,
                JavaScriptStripMenuItem
            };
            MultiTabManger.Init(tabView, parentMenuItems);
            //MultiTab固定项目的初始化
            var serverStatusCtl = new CtlServerStatus()
            {
                IsFixedItem = true,
                SelectObjectTag = "[ServerStatus]",
                BindingMenu = StatusToolStripMenuItem
            };
            MultiTabManger.AddView(serverStatusCtl, GuiConfig.IsUseDefaultLanguage ? "Status" : GuiConfig.GetText("MainMenu.MangtStatus"), string.Empty);

            //刷新
            RefreshToolStripMenuItem_Click(sender, e);
            serverStatusCtl.RefreshGui();
            MultiTabManger.SelectTab("[ServerStatus]");

            //委托设置
            trvsrvlst.NodeMouseClick += trvsrvlst_NodeMouseClick;
            trvsrvlst.NodeMouseDoubleClick += (x, y) => ViewDataObj();
            ViewDataToolStripMenuItem.Click += (x, y) => ViewDataObj();
            trvsrvlst.KeyDown += trvsrvlst_KeyDown;
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
            if (trvsrvlst.Nodes.Count > 0) trvsrvlst.SelectedNode = trvsrvlst.Nodes[0];
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
                var strNodeType = TagInfo.GetTagType(e.Node.Tag.ToString());
                var mongoSvrKey = TagInfo.GetTagPath(e.Node.Tag.ToString()).Split("/".ToCharArray())[0];
                RuntimeMongoDbContext.CurrentMongoConnectionconfig =
                    MongoConnectionConfig.MongoConfig.ConnectionList[mongoSvrKey];
                if (string.IsNullOrEmpty(RuntimeMongoDbContext.CurrentMongoConnectionconfig.UserName))
                {
                    lblUserInfo.Text = GuiConfig.GetText("UserInfo", "UserInfo") + ":Admin";
                }
                else
                {
                    lblUserInfo.Text = GuiConfig.GetText("UserInfo", "UserInfo") + ":" + RuntimeMongoDbContext.CurrentMongoConnectionconfig.UserName;
                }
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.AuthMode)
                {
                    lblUserInfo.Text += " @AuthMode";
                }
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
                {
                    lblUserInfo.Text += " [" + GuiConfig.GetText("ReadOnly", "Common_ReadOnly") + "]";
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
                        statusStripMain.Items[0].Text = GuiConfig.GetText("System Collection List ", "SystemCollectionList");
                        break;
                    case ConstMgr.CollectionListTag:
                        //添加数据集
                        CollectionListHandler(e);
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Collection List ", "CollectionList");
                        break;
                    case ConstMgr.ViewListTag:
                        ViewListHandler(e);
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = GuiConfig.GetText("List View ", "ViewList");
                        break;
                    case ConstMgr.CollectionTag:
                        CollectionHandler(e);
                        break;
                    case ConstMgr.ViewTag:
                        ViewHandler(e);
                        break;
                    case ConstMgr.IndexTag:
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected Index:", "SelectedIndex") +
                                                        ":" + RuntimeMongoDbContext.SelectTagData;
                        break;
                    case ConstMgr.IndexesTag:
                        statusStripMain.Items[0].Text =
                            GuiConfig.GetText("Selected Index", "SelectedIndexes") + ":" +
                            RuntimeMongoDbContext.SelectTagData;
                        break;
                    case ConstMgr.UserListTag:
                        statusStripMain.Items[0].Text =
                            GuiConfig.GetText("Selected UserList", "SelectedUserList") + ":" +
                            RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var viewDataTool = ViewDataToolStripMenuItem.Clone();
                                viewDataTool.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(viewDataTool);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case ConstMgr.RoleListTag:
                        statusStripMain.Items[0].Text =
                            GuiConfig.GetText("Selected RoleList", "Selected_RoleList") + ":" + RuntimeMongoDbContext.SelectTagData;
                        break;
                    case ConstMgr.GridFileSystemTag:
                        //GridFileSystem
                        RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected GFS", "SelectedGfs") + ":" +
                                                        RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var viewData = ViewDataToolStripMenuItem.Clone();
                                viewData.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(viewData);
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
                                var creatJavaScript = creatJavaScriptToolStripMenuItem.Clone();
                                creatJavaScript.Click += creatJavaScriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(creatJavaScript);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(creatJavaScriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected collection Javascript ", "JavascriptCollection");
                        break;
                    case ConstMgr.JavascriptDocTag:
                        statusStripMain.Items[0].Text = GuiConfig.GetText("Selected JavaScript", "Selected_Javascript") + ":" + RuntimeMongoDbContext.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MonoMode)
                            {
                                var viewData = ViewDataToolStripMenuItem.Clone();
                                viewData.Click += (x, y) => ViewDataObj();
                                contextMenuStripMain.Items.Add(viewData);
                                var dropJavascript = dropJavascriptToolStripMenuItem.Clone();
                                dropJavascript.Click += dropJavascriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(dropJavascript);
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
                    case ConstMgr.ViewTag:
                    case ConstMgr.RoleListTag:
                        ViewDataRecord();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     View Js
        /// </summary>
        private void ViewJavascript()
        {
            var tagArray = RuntimeMongoDbContext.SelectTagData.Split("/".ToCharArray());
            var jsName = tagArray[(int)EnumMgr.PathLevel.Document];
            if (MultiTabManger.IsExist(RuntimeMongoDbContext.SelectTagData))
            {
                MultiTabManger.SelectTab(RuntimeMongoDbContext.SelectTagData);
                return;
            }

            var jsEditor = new CtlJsEditor { StrDBtag = RuntimeMongoDbContext.SelectObjectTag };
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
            //MultiTabManger.AddTabInfo(RuntimeMongoDbContext.SelectTagData, null, dataTab,string.Empty);
            jsEditor.CloseTab += (x, y) =>
            {
                tabView.Controls.Remove(dataTab);
                //MultiTabManger.RemoveTabInfo(RuntimeMongoDbContext.SelectTagData);
                JavaScriptStripMenuItem.DropDownItems.Remove(dataMenuItem);
            };
            tabView.SelectTab(dataTab);
        }

        /// <summary>
        ///     Create a DataView Tab
        /// </summary>
        private void ViewDataRecord()
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            var dataKey = RuntimeMongoDbContext.SelectTagData;
            if (MultiTabManger.IsExist(dataKey))
            {
                MultiTabManger.SelectTab(dataKey);
                return;
            }

            var mDataViewInfo = new DataViewInfo
            {
                strCollectionPath = RuntimeMongoDbContext.SelectObjectTag,
                IsReadOnly = RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly,
            };

            CtlDataView dataViewctl;
            switch (RuntimeMongoDbContext.SelectTagType)
            {
                case ConstMgr.GridFileSystemTag:
                    dataViewctl = new CtlGfsView(mDataViewInfo)
                    {
                        AllowDrop = true
                    };
                    break;
                case ConstMgr.UserListTag:
                    dataViewctl = new CtlUserView(mDataViewInfo);
                    break;
                case ConstMgr.ViewTag:
                    mDataViewInfo.IsView = true;
                    dataViewctl = new CtlDocumentView(mDataViewInfo);
                    break;
                default:
                    dataViewctl = new CtlDocumentView(mDataViewInfo);
                    break;
            }

            dataViewctl.mDataViewInfo = mDataViewInfo;
            dataViewctl.SelectObjectTag = RuntimeMongoDbContext.SelectObjectTag;
            dataViewctl.ParentMenu = CollectionToolStripMenuItem;
            var TabTitle = UiHelper.GetShowName(RuntimeMongoDbContext.GetCurrentDataBaseName(),RuntimeMongoDbContext.GetCurrentCollectionName());
            MultiTabManger.AddView(dataViewctl, TabTitle, RuntimeMongoDbContext.SelectTagType);
        }

        /// <summary>
        ///     Refresh View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiTabManger.RefreshSelectTab();
        }
        #endregion


    }
}