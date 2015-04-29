using System.Collections.Generic;
using System.Windows.Forms;
using MongoUtility.Aggregation;

namespace MongoCola
{
    /// <summary>
    ///     多文档视图管理
    /// </summary>
    public static class MutliTabManger
    {
        /// <summary>
        ///     多文档视图管理
        /// </summary>
        public static Dictionary<string, TabViewItem> TabInfo = new Dictionary<string, TabViewItem>();

        /// <summary>
        ///     新增一个视图
        /// </summary>
        /// <param name="key"></param>
        /// <param name="info"></param>
        /// <param name="tab"></param>
        public static void AddTabView(string key, DataViewInfo info, TabPage tab)
        {
            var t = new TabViewItem
            {
                Info = info,
                Tab = tab
            };
            TabInfo.Add(key, t);
        }

        /// <summary>
        ///     去除一个视图
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveTab(string key)
        {
            TabInfo.Remove(key);
        }

        /// <summary>
        ///     主键变更
        /// </summary>
        /// <param name="strNewNodeData"></param>
        /// <param name="strNodeData"></param>
        public static void ChangeKey(string strNewNodeData, string strNodeData)
        {
            var item = TabInfo[strNodeData];
            RemoveTab(strNodeData);
            AddTabView(strNodeData, item.Info, item.Tab);
        }

        /// <summary>
        ///     文档视图
        /// </summary>
        public struct TabViewItem
        {
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