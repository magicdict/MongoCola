using System;
using System.Windows.Forms;

namespace MongoGUIView
{
    public class MultiTabControl : UserControl
    {
        /// <summary>
        ///    关闭Tab事件(主界面操作这个文档的时候用的事件)
        /// </summary>
        public event EventHandler CloseTab;
        /// <summary>
        ///    发起CloseTab事件
        /// </summary>
        public void RaiseCloseTabEvent()
        {
            if (CloseTab != null)
            {
                CloseTab(null, null);
            }
        }
        /// <summary>
        ///     View的主键
        /// </summary>
        public string ViewKey { set; get; }
        /// <summary>
        ///     父菜单的主键
        /// </summary>
        public string ParentMenuKey { set; get; }
        /// <summary>
        /// 是否为固定项目
        /// （当不可见时，固定项目仍然保留菜单项目，只是Check标记为否定）
        /// </summary>
        public bool IsFixedItem { set; get; }

    }
}
