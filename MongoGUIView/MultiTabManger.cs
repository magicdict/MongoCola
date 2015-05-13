using System.Collections.Generic;
using System.Windows.Forms;
using MongoGUIView;
using MongoUtility.Aggregation;
using System;

namespace MongoCola
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
        public static TabControl ViewTabContain = null;
        /// <summary>
        /// Tab变更事件
        /// </summary>
        public static event EventHandler TabSelectIndexChanged;
        /// <summary>
        /// 固定菜单项目列表
        /// </summary>
        static Dictionary<string, ToolStripMenuItem> BindingMenuItems = new Dictionary<string, ToolStripMenuItem>();
        /// <summary>
        /// 父菜单列表
        /// </summary>
        public static List<ToolStripMenuItem> ParentMenuItems = new List<ToolStripMenuItem>();
        /// <summary>
        /// 已经存在的TabPage的字典
        /// </summary>
        static Dictionary<string, TabPage> ExistTabPage = new Dictionary<string, TabPage>();

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init(TabControl mViewTabContain, List<ToolStripMenuItem> mParentMenuItems)
        {
            ViewTabContain = mViewTabContain;
            //固定项目可以通过FixItem的Key获得，非固定项目ParentMenu则不能
            ParentMenuItems = mParentMenuItems;
            ViewTabContain.SelectedIndexChanged += (send, e) =>
            {
                if (TabSelectIndexChanged != null)
                {
                    TabSelectIndexChanged(send, e);
                }
            };
        }

        /// <summary>
        /// 增加一个MultiTabControl
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="tab"></param>
        public static void AddView(MultiTabControl view, string TabPageTitle)
        {
            string key = view.SelectObjectTag;
            if (ExistTabPage.ContainsKey(key))
            {
                ViewTabContain.SelectedTab = ExistTabPage[key];
                return;
            }
            var tabpage = new TabPage();
            tabpage.Text = TabPageTitle;
            tabpage.Tag = view.SelectObjectTag;
            view.Dock = DockStyle.Fill;
            tabpage.Controls.Add(view);
            ViewTabContain.TabPages.Add(tabpage);
            ViewTabContain.SelectTab(tabpage);
            if (view.IsFixedItem)
            {
                if (!BindingMenuItems.ContainsKey(key))
                {
                    BindingMenuItems.Add(key, view.BindingMenu);
                }
            }
            ExistTabPage.Add(key, tabpage);
            RefreshMenuItem();
        }

        /// <summary>
        /// 删除一个视图
        /// </summary>
        /// <param name="SelectObjectTag"></param>
        public static void RemoveView(string SelectObjectTag)
        {
            if (ExistTabPage.ContainsKey(SelectObjectTag))
            {
                ViewTabContain.TabPages.Remove(ExistTabPage[SelectObjectTag]);
                ExistTabPage.Remove(SelectObjectTag);
            }
            RefreshMenuItem();
        }

        /// <summary>
        /// 刷新当前选中的Tab
        /// </summary>
        public static void RefreshSelectTab()
        {
            if (ExistTabPage.Count == 0) return;
            MultiTabControl CurrentView = ViewTabContain.SelectedTab.Controls[0] as MultiTabControl;
            CurrentView.RefreshGUI();
        }

        /// <summary>
        ///     刷新菜单
        /// </summary>
        /// <param name="ViewMenu"></param>
        private static void RefreshMenuItem()
        {
            foreach (ToolStripMenuItem item in BindingMenuItems.Values)
            {
                item.Checked = false;
            }
            foreach (ToolStripMenuItem item in ParentMenuItems)
            {
                item.DropDownItems.Clear();
            }
            foreach (TabPage tabpage in ViewTabContain.TabPages)
            {
                MultiTabControl view = (MultiTabControl)tabpage.Controls[0];
                if (view.IsFixedItem)
                {
                    view.BindingMenu.Checked = true;
                }
                else
                {
                    view.ParentMenu.DropDownItems.Add(ExistTabPage[tabpage.Tag.ToString()].Text);
                }
            }
        }
        
        /// <summary>
        ///     IsExist
        /// </summary>
        /// <param name="SelectObjectTag"></param>
        /// <returns></returns>
        public static bool IsExist(string SelectObjectTag)
        {
            return ExistTabPage.ContainsKey(SelectObjectTag);
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

    }
}