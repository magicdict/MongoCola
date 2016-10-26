using MongoUtility.Basic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoGUIView
{
    /// <summary>
    ///     多文档视图管理
    /// </summary>
    public static class MultiTabManger
    {
        /////////////////////////////////
        //  说明：
        //  TabControl
        //      TabPage：
        //              Tag = SelectObjTab
        //          MultiTabControl:    
        //              SelectObjTag
        //              ParentMenu
        //              IsFixedItem
        /////////////////////////////////

        /// <summary>
        ///     显示文档的Tab容器
        /// </summary>
        public static TabControl ViewTabContain;

        /// <summary>
        ///     固定菜单项目列表
        /// </summary>
        private static readonly Dictionary<string, ToolStripMenuItem> BindingMenuItems =
            new Dictionary<string, ToolStripMenuItem>();

        /// <summary>
        ///     父菜单列表
        /// </summary>
        public static List<ToolStripMenuItem> ParentMenuItems = new List<ToolStripMenuItem>();

        /// <summary>
        ///     已经存在的TabPage的字典
        /// </summary>
        private static readonly Dictionary<string, TabPage> ExistTabPage = new Dictionary<string, TabPage>();

        /// <summary>
        ///     固定Tab的缓存
        /// </summary>
        private static readonly Dictionary<string, TabPage> FixItemCache = new Dictionary<string, TabPage>();

        /// <summary>
        ///     Tab变更事件
        /// </summary>
        public static event EventHandler TabSelectIndexChanged;

        /// <summary>
        ///     初始化
        /// </summary>
        public static void Init(TabControl mViewTabContain, List<ToolStripMenuItem> mParentMenuItems)
        {
            ViewTabContain = mViewTabContain;
            //固定项目可以通过FixItem的Key获得，非固定项目ParentMenu则不能
            ParentMenuItems = mParentMenuItems;
            ViewTabContain.SelectedIndexChanged += (send, e) =>
            {
                TabSelectIndexChanged?.Invoke(send, e);
            };
        }

        /// <summary>
        ///     增加一个MultiTabControl
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="tab"></param>
        public static void AddView(MultiTabControl view, string tabPageTitle,string SelectTagType)
        {
            var key = view.SelectObjectTag;
            if (ExistTabPage.ContainsKey(key))
            {
                ViewTabContain.SelectedTab = ExistTabPage[key];
                return;
            }
            var tabpage = new TabPage();
            if (SelectTagType == ConstMgr.GridFileSystemTag) tabpage.AllowDrop = true;
            if (view.IsFixedItem)
            {
                if (!BindingMenuItems.ContainsKey(key))
                {
                    BindingMenuItems.Add(key, view.BindingMenu);
                }
                if (FixItemCache.ContainsKey(key))
                {
                    tabpage = FixItemCache[key];
                }
                else
                {
                    FixItemCache.Add(key, tabpage);
                    //Fix项目的MenuItem事件的绑定
                    //注意，事件只能绑定一次
                    view.BindingMenu.Click += (x, y) =>
                    {
                        view.BindingMenu.Checked = !view.BindingMenu.Checked;
                        if (view.BindingMenu.Checked)
                        {
                            //加入
                            view.RefreshGui();
                            AddView(view, tabPageTitle, SelectTagType);
                        }
                        else
                        {
                            //删除
                            RemoveView(view.SelectObjectTag);
                        }
                    };
                    //Close Event
                    view.CloseTab += (x, y) => { RemoveView(view.SelectObjectTag); };
                }
            }
            else
            {
                //Close Event
                view.CloseTab += (x, y) => { RemoveView(view.SelectObjectTag); };
            }
            tabpage.Text = tabPageTitle;
            tabpage.Tag = view.SelectObjectTag;
            tabpage.ToolTipText = view.SelectObjectTag;
            view.Dock = DockStyle.Fill;
            tabpage.Controls.Add(view);
            ViewTabContain.TabPages.Add(tabpage);
            ViewTabContain.SelectTab(tabpage);
            ExistTabPage.Add(key, tabpage);
            RefreshMenuItem();
        }

        /// <summary>
        ///     删除一个视图
        /// </summary>
        /// <param name="selectObjectTag"></param>
        public static void RemoveView(string selectObjectTag)
        {
            if (ExistTabPage.ContainsKey(selectObjectTag))
            {
                ViewTabContain.TabPages.Remove(ExistTabPage[selectObjectTag]);
                ExistTabPage.Remove(selectObjectTag);
            }
            RefreshMenuItem();
        }

        /// <summary>
        ///     刷新当前选中的Tab
        /// </summary>
        public static void RefreshSelectTab()
        {
            if (ExistTabPage.Count == 0) return;
            var currentView = ViewTabContain.SelectedTab.Controls[0] as MultiTabControl;
            currentView.RefreshGui();
        }

        /// <summary>
        ///     刷新菜单
        /// </summary>
        /// <param name="ViewMenu"></param>
        private static void RefreshMenuItem()
        {
            foreach (var item in BindingMenuItems.Values)
            {
                item.Checked = false;
            }
            foreach (var item in ParentMenuItems)
            {
                item.DropDownItems.Clear();
            }
            foreach (TabPage tabpage in ViewTabContain.TabPages)
            {
                var view = (MultiTabControl)tabpage.Controls[0];
                if (view.IsFixedItem)
                {
                    view.BindingMenu.Checked = true;
                }
                else
                {
                    var menuItem = new ToolStripMenuItem(ExistTabPage[tabpage.Tag.ToString()].Text);
                    menuItem.Click += (x, y) => { ViewTabContain.SelectedTab = ExistTabPage[tabpage.Tag.ToString()]; };
                    view.ParentMenu.DropDownItems.Add(menuItem);
                }
            }
        }

        /// <summary>
        ///     是否存在TabPage
        /// </summary>
        /// <param name="selectObjectTag"></param>
        /// <returns></returns>
        public static bool IsExist(string selectObjectTag)
        {
            return ExistTabPage.ContainsKey(selectObjectTag);
        }

        /// <summary>
        ///     切换选中项
        /// </summary>
        /// <param name="dataKey"></param>
        public static void SelectTab(string dataKey)
        {
            ViewTabContain.SelectedTab = ExistTabPage[dataKey];
            RefreshSelectTab();
        }

        /// <summary>
        ///     由于Rename造成的SelectObjectTag变化
        /// </summary>
        public static void SelectObjectTagChanged(string oldTag, string newTag, string tabPageTitle)
        {
            if (!IsExist(oldTag)) return;
            //修改TabPage和View，以及字典
            var currentView = ExistTabPage[oldTag].Controls[0] as MultiTabControl;
            currentView.SelectObjectTag = newTag;
            var tabpage = ExistTabPage[oldTag];
            tabpage.Tag = newTag;
            tabpage.Text = tabPageTitle;
            ExistTabPage.Remove(oldTag);
            ExistTabPage.Add(newTag, tabpage);
            RefreshMenuItem();
        }

        /// <summary>
        ///     由于Drop造成的SelectObjectTag删除
        /// </summary>
        /// <param name="strTag"></param>
        public static void SelectObjectTagDeleted(string strTag)
        {
            if (!IsExist(strTag)) return;
            RemoveView(strTag);
        }

        /// <summary>
        /// </summary>
        /// <param name="strTagPrefix"></param>
        public static void SelectObjectTagPrefixDeleted(string strTagPrefix)
        {
            foreach (var tabkey in ExistTabPage.Keys)
            {
                if (tabkey.StartsWith(strTagPrefix)) RemoveView(tabkey);
            }
        }
    }
}