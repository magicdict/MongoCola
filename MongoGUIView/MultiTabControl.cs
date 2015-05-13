using System;
using System.Windows.Forms;

namespace MongoGUIView
{
    public class MultiTabControl : UserControl
    {
        /// <summary>
        ///     View的SelectObjectTag
        /// </summary>
        public string SelectObjectTag { set; get; }

        /// <summary>
        ///     父菜单
        /// </summary>
        public ToolStripMenuItem ParentMenu { set; get; }

        /// <summary>
        ///     固定菜单
        /// </summary>
        public ToolStripMenuItem BindingMenu { set; get; }

        /// <summary>
        ///     是否为固定项目
        ///     （当不可见时，固定项目仍然保留菜单项目，只是Check标记为否定）
        /// </summary>
        public bool IsFixedItem { set; get; }

        /// <summary>
        ///     关闭Tab事件(主界面操作这个文档的时候用的事件)
        /// </summary>
        public event EventHandler CloseTab;

        /// <summary>
        ///     发起CloseTab事件
        /// </summary>
        public void RaiseCloseTabEvent()
        {
            if (CloseTab != null)
            {
                CloseTab(null, null);
            }
        }

        public virtual void RefreshGui()
        {
        }
    }
}