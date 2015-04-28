using MongoUtility.Aggregation;
using System.Collections.Generic;
using System.Windows.Forms;

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
        ///     文档视图
        /// </summary>
        public struct TabViewItem
        {
            /// <summary>
            /// 过滤信息
            /// </summary>
            public DataViewInfo Info;
            /// <summary>
            /// Tab页
            /// </summary>
            public TabPage Tab;
        }
        /// <summary>
        ///     新增一个视图
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Info"></param>
        /// <param name="Tab"></param>
        public static void AddTabView(string Key, DataViewInfo Info, TabPage Tab)
        {
            TabViewItem t = new TabViewItem()
            {
                Info = Info,
                Tab = Tab
            };
            TabInfo.Add(Key, t);
        }
        /// <summary>
        ///     去除一个视图
        /// </summary>
        /// <param name="Key"></param>
        public static void RemoveTab(string Key)
        {
            TabInfo.Remove(Key);
        }
        /// <summary>
        /// 主键变更
        /// </summary>
        /// <param name="strNewNodeData"></param>
        /// <param name="strNodeData"></param>
        public static void ChangeKey(string strNewNodeData, string strNodeData)
        {
            TabViewItem Item = TabInfo[strNodeData];
            RemoveTab(strNodeData);
            AddTabView(strNodeData, Item.Info, Item.Tab);
        }
    }
}
