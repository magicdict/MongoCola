using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
namespace MagicMongoDBTool.Module
{
    static class CloneMeunToolItem
    {
        /// <summary>
        /// 复制菜单项目
        /// </summary>
        /// <param name="OrgMenuItem"></param>
        /// <returns></returns>
        public static ToolStripMenuItem Clone(this ToolStripMenuItem OrgMenuItem)
        {
            ToolStripMenuItem CloneMenuItem = new ToolStripMenuItem();
            //!!!typeof的参数必须是ToolStripMenuItem的基类!!!如果使用Control则不能取到值!!!
            ///感谢CSDN网友beargo在帖子【如何获取事件已定制方法名?】里面的提示，网上的例子没有说明这个问题
            ///坑爹啊。。。。。。。。
            Delegate[] _List = GetObjectEventList(OrgMenuItem, "EventClick", typeof(ToolStripItem));
            CloneMenuItem.Click += new EventHandler(
                    (x, y) => { _List[0].DynamicInvoke(x,y); }
            );
            CloneMenuItem.Text = OrgMenuItem.Text;
            return CloneMenuItem;
        }

        /// <summary>   
        /// 获取控件事件  zgke@sina.com qq:116149   
        /// </summary>   
        /// <param name="p_Control">对象</param>   
        /// <param name="p_EventName">事件名 EventClick EventDoubleClick  这个需要看control.事件 是哪个类的名字是什么</param> 
        /// <param name="p_EventType">如果是WINFROM控件  使用typeof(Control)</param> 
        /// <returns>委托列</returns>   
        public static Delegate[] GetObjectEventList(object p_Object, string p_EventName, Type p_EventType)
        {
            PropertyInfo _PropertyInfo = p_Object.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            if (_PropertyInfo != null)
            {
                object _EventList = _PropertyInfo.GetValue(p_Object, null);
                if (_EventList != null && _EventList is EventHandlerList)
                {
                    EventHandlerList _List = (EventHandlerList)_EventList;
                    FieldInfo _FieldInfo = p_EventType.GetField(p_EventName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
                    if (_FieldInfo == null) return null;
                    Delegate _ObjectDelegate = _List[_FieldInfo.GetValue(p_Object)];
                    if (_ObjectDelegate == null) return null;
                    return _ObjectDelegate.GetInvocationList();
                }
            }
            return null;
        }  
    }
}
