using System.Collections.Generic;
using System.Windows.Forms;
using MongoGUIView;
using MongoUtility.Aggregation;

namespace MongoCola
{
    /// <summary>
    ///     多文档视图管理
    /// </summary>
    public static class MultiTabManger
    {

        /// <summary>
        ///     菜单列表
        /// </summary>
        /// <remarks>
        ///     Key:MenuKey 
        ///     Value:MenuItem
        /// </remarks>
        public static Dictionary<string, ToolStripMenuItem> MenuItemList = new Dictionary<string, ToolStripMenuItem>();

        /// <summary>
        ///     多文档视图管理
        /// </summary>
        /// <remarks>
        ///     Key:Tag
        ///     Value:TabViewItem
        /// </remarks>
        public static Dictionary<string, TabViewItem> TabInfo = new Dictionary<string, TabViewItem>();

        /// <summary>
        ///     显示文档的Tab容器
        /// </summary>
        public static TabControl ViewTabContain = null;


        /// <summary>
        ///     新增一个视图
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="tab"></param>
        public static void AddTabInfo(string key, DataViewInfo info, TabPage tab, string ParentMenuKey)
        {
            var t = new TabViewItem
            {
                Info = info,
                Tab = tab
            };
            TabInfo.Add(key, t);
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="tab"></param>
        public static void AddView(string key, DataViewInfo info, CtlDataView view, string ParentMenuKey)
        {
            var p = new TabPage();
            view.Dock = DockStyle.Fill;
            p.Controls.Add(view);
            ViewTabContain.TabPages.Add(p);
            var t = new TabViewItem
            {
                Info = info,
                Tab = p
            };
            view.CloseTab += (x, y) =>
            {
                RemoveTabInfo(key);
                ViewTabContain.TabPages.Remove(p);
                RefreshMenuItem();
            };
            TabInfo.Add(key, t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="view"></param>
        public static void AddView(string key, DataViewInfo info, CtlServerStatus view)
        {
            var p = new TabPage();
            view.Dock = DockStyle.Fill;
            p.Controls.Add(view);
            ViewTabContain.TabPages.Add(p);
            var t = new TabViewItem
            {
                Info = info,
                Tab = p
            };
            view.CloseTab += (x, y) =>
            {
                RemoveTabInfo(key);
                ViewTabContain.TabPages.Remove(p);
                RefreshMenuItem();
            };
            TabInfo.Add(key, t);
        }

        /// <summary>
        ///     去除一个视图
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveTabInfo(string key)
        {
            TabInfo.Remove(key);
            ViewTabContain.TabPages.Remove(TabInfo[key].Tab);
            RefreshMenuItem();
        }

        /// <summary>
        ///     主键变更
        /// </summary>
        /// <param name="strNewNodeData"></param>
        /// <param name="strOldNodeData"></param>
        public static void ChangeKey(string strNewNodeData, string strOldNodeData)
        {
            var item = TabInfo[strOldNodeData];
            AddTabInfo(strOldNodeData, item.Info, item.Tab, string.Empty);
            RemoveTabInfo(strOldNodeData);
            RefreshMenuItem();
        }

        /// <summary>
        ///     刷新菜单
        /// </summary>
        /// <param name="ViewMenu"></param>
        private static void RefreshMenuItem()
        {
            foreach (string MenuKey in MenuItemList.Keys)
            {
                ToolStripMenuItem ViewMenu = MenuItemList[MenuKey];
                ViewMenu.DropDownItems.Clear();
                foreach (var key in TabInfo.Keys)
                {
                    var menuItem = new ToolStripMenuItem
                    {
                        Tag = key,
                        Text = TabInfo[key].Tab.Text
                    };
                    menuItem.Click += (x, y) => { ViewTabContain.SelectedTab = TabInfo[key].Tab; };
                    if (TabInfo[key].ContentType == "Javascript")
                    {
                        //ViewJsMenu.DropDownItems.Add(menuItem);
                    }
                    else
                    {
                        ViewMenu.DropDownItems.Add(menuItem);
                    }
                }
            }
        }

        /// <summary>
        ///     文档视图
        /// </summary>
        public struct TabViewItem
        {
            /// <summary>
            ///     内容类型：
            ///     Javascript/Collection/Status
            /// </summary>
            public string ContentType;

            /// <summary>
            ///     过滤信息
            /// </summary>
            public DataViewInfo Info;

            /// <summary>
            ///     Tab页
            /// </summary>
            public TabPage Tab;
        }
    }
}