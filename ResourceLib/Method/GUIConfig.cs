/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/6
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Drawing;
using System.Windows.Forms;

namespace ResourceLib.Method
{
    /// <summary>
    ///     Description of UIConfig.
    /// </summary>
    public static class GuiConfig
    {
        /// <summary>
        ///     成功提示色
        /// </summary>
        public static Color SuccessColor = Color.LightGreen;

        /// <summary>
        /// </summary>
        public static Color FailColor = Color.Pink;

        /// <summary>
        /// </summary>
        public static Color ActionColor = Color.LightBlue;

        /// <summary>
        /// </summary>
        public static Color WarningColor = Color.LightYellow;

        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        public static bool IsUseDefaultLanguage = false;

        /// <summary>
        ///     字符串
        /// </summary>
        public static StringResource MStringResource = new StringResource();

        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="defaultText"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(string defaultText, TextType tag)
        {
            if (IsUseDefaultLanguage || tag == TextType.UseDefaultLanguage) return defaultText;
            string strText;
            StringResource.StringDic.TryGetValue(tag.ToString(), out strText);
            strText = string.IsNullOrEmpty(strText) ? tag.ToString() : strText.Replace("&amp;", "&");
            return strText;
        }

        /// <summary>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(string tag)
        {
            string strText;
            StringResource.StringDic.TryGetValue(tag, out strText);
            strText = string.IsNullOrEmpty(strText) ? tag : strText.Replace("&amp;", "&");
            return strText;
        }

        /// <summary>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(TextType tag)
        {
            return GetText(tag.ToString());
        }

        /// <summary>
        ///     自动化多语言
        /// </summary>
        /// <param name="frm"></param>
        public static void Translateform(Form frm)
        {
            if (IsUseDefaultLanguage) return;
            if (frm.Tag != null)
            {
                var display = GetText(frm.Tag.ToString());
                if (!string.IsNullOrEmpty(display))
                {
                    frm.Text = display;
                }
            }
            //遍历所有控件
            Translateform(frm.Controls);
        }


        public static void Translateform(ToolStripItemCollection controls)
        {
            foreach (ToolStripItem menuItem in controls)
            {
                if (menuItem.GetType().FullName == typeof(ToolStripSeparator).FullName) continue;
                if (menuItem.GetType().FullName == typeof(ToolStripMenuItem).FullName)
                {
                    if (((ToolStripMenuItem)menuItem).Tag == null) continue;
                    var display = GetText(((ToolStripMenuItem)menuItem).Tag.ToString());
                    if (string.IsNullOrEmpty(display)) continue;
                    ((ToolStripMenuItem)menuItem).Text = display;
                    if (((ToolStripMenuItem)menuItem).DropDownItems.Count > 0)
                        Translateform(((ToolStripMenuItem)menuItem).DropDownItems);
                }
                if (menuItem.GetType().FullName == typeof(ToolStripButton).FullName)
                {
                    if (((ToolStripButton)menuItem).Tag == null) continue;
                    var display = GetText(((ToolStripButton)menuItem).Tag.ToString());
                    if (string.IsNullOrEmpty(display)) continue;
                    ((ToolStripButton)menuItem).Text = display;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controls"></param>
        public static void Translateform(Control.ControlCollection controls)
        {
            var display = string.Empty;
            foreach (Control ctrlItem in controls)
            {
                if (ctrlItem.GetType().FullName == typeof(MenuStrip).FullName)
                {
                    if (((MenuStrip)ctrlItem).Items.Count > 0) Translateform(((MenuStrip)ctrlItem).Items);
                }
                if (ctrlItem.GetType().FullName == typeof(ToolStrip).FullName)
                {
                    if (((ToolStrip)ctrlItem).Items.Count > 0) Translateform(((ToolStrip)ctrlItem).Items);
                }
                if (ctrlItem.GetType().FullName == typeof(TabControl).FullName)
                {
                    foreach (TabPage tab in ((TabControl)ctrlItem).TabPages)
                    {
                        if (tab.Tag != null)
                        {
                            display = GetText(tab.Tag.ToString());
                            tab.Text = display;
                        }
                        Translateform(tab.Controls);
                    }
                }
                if (ctrlItem.GetType().FullName == typeof(GroupBox).FullName)
                {
                    if (!string.IsNullOrEmpty(display))
                    {
                        ((GroupBox)ctrlItem).Text = display;
                    }
                    Translateform(ctrlItem.Controls);
                }
                if (ctrlItem.Tag == null) continue;
                display = GetText(ctrlItem.Tag.ToString());
                if (string.IsNullOrEmpty(display)) continue;

                if (ctrlItem.GetType().FullName == typeof(Label).FullName)
                {
                    ((Label)ctrlItem).Text = display;
                }
                if (ctrlItem.GetType().FullName == typeof(Button).FullName)
                {
                    ((Button)ctrlItem).Text = display;
                    if (ctrlItem.Tag.ToString() == TextType.CommonOk.ToString())
                    {
                        ((Button)ctrlItem).BackColor = SuccessColor;
                    }
                    if (ctrlItem.Tag.ToString() == TextType.CommonNo.ToString() ||
                        ctrlItem.Tag.ToString() == TextType.CommonClose.ToString() ||
                        ctrlItem.Tag.ToString() == TextType.CommonCancel.ToString())
                    {
                        ((Button)ctrlItem).BackColor = FailColor;
                    }
                }
                if (ctrlItem.GetType().FullName == typeof(CheckBox).FullName)
                {
                    ((CheckBox)ctrlItem).Text = display;
                }
                if (ctrlItem.GetType().FullName == typeof(RadioButton).FullName)
                {
                    ((RadioButton)ctrlItem).Text = display;
                }
            }
        }
    }
}