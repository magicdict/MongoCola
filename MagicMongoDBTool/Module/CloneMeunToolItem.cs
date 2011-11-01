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
        /// <param name="orgMenuItem"></param>
        /// <returns></returns>
        public static ToolStripMenuItem Clone(this ToolStripMenuItem orgMenuItem)
        {
            ToolStripMenuItem cloneMenuItem = new ToolStripMenuItem();
            //!!!typeof的参数必须是ToolStripMenuItem的基类!!!如果使用Control则不能取到值!!!
            ///感谢CSDN网友beargo在帖子【如何获取事件已定制方法名?】里面的提示，网上的例子没有说明这个问题
            ///坑爹啊。。。。。。。。
            Delegate[] list = GetObjectEventList(orgMenuItem, "EventClick", typeof(ToolStripItem));
            cloneMenuItem.Click += new EventHandler(
                    (x, y) => { list[0].DynamicInvoke(x,y); }
            );
            cloneMenuItem.Text = orgMenuItem.Text;
            cloneMenuItem.Enabled = orgMenuItem.Enabled;
            cloneMenuItem.BackgroundImage = orgMenuItem.BackgroundImage;
            return cloneMenuItem;
        }

        public static ToolStripButton CloneFromMenuItem(this ToolStripMenuItem OrgMenuItem) {
            ToolStripButton CloneButton = new ToolStripButton();
            //!!!typeof的参数必须是ToolStripMenuItem的基类!!!如果使用Control则不能取到值!!!
            ///感谢CSDN网友beargo在帖子【如何获取事件已定制方法名?】里面的提示，网上的例子没有说明这个问题
            ///坑爹啊。。。。。。。。
            Delegate[] _List = GetObjectEventList(OrgMenuItem, "EventClick", typeof(ToolStripItem));
            CloneButton.Click += new EventHandler(
                    (x, y) => { _List[0].DynamicInvoke(x, y); }
            );
            CloneButton.Image = OrgMenuItem.Image;
            CloneButton.Enabled = OrgMenuItem.Enabled;
            CloneButton.Text = OrgMenuItem.Text;
            CloneButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            return CloneButton;
        }

        /// <summary>   
        /// 获取控件事件  zgke@sina.com qq:116149   
        /// </summary>   
        /// <param name="p_Control">对象</param>   
        /// <param name="eventName">事件名 EventClick EventDoubleClick  这个需要看control.事件 是哪个类的名字是什么</param> 
        /// <param name="eventType">如果是WINFROM控件  使用typeof(Control)</param> 
        /// <returns>委托列</returns>   
        public static Delegate[] GetObjectEventList(object obj, string eventName, Type eventType)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertyInfo != null)
            {
                object eventList = propertyInfo.GetValue(obj, null);
                if (eventList != null && eventList is EventHandlerList)
                {
                    EventHandlerList list = (EventHandlerList)eventList;
                    FieldInfo fieldInfo = eventType.GetField(eventName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
                    if (fieldInfo == null)
                    {
                        return null;
                    }
                    Delegate objDelegate = list[fieldInfo.GetValue(obj)];
                    if (objDelegate == null)
                    {
                        return null;
                    }
                    return objDelegate.GetInvocationList();
                }
            }
            return null;
        }  
    }
}
