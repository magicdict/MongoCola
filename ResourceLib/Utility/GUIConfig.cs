/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/6
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

namespace ResourceLib.Utility
{
    /// <summary>
    ///     Description of UIConfig.
    /// </summary>
    public static class GUIConfig
    {
        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        public static Boolean IsUseDefaultLanguage = false;

        /// <summary>
        ///     字符串
        /// </summary>
        public static StringResource MStringResource = new StringResource();

        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="DefaultText"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(string DefaultText,
            TextType tag = TextType.UseDefaultLanguage)
        {
            if (IsUseDefaultLanguage || tag == TextType.UseDefaultLanguage) return DefaultText;
            return MStringResource.GetText(tag);
        }
        public static string GetText(TextType TextType)
        {
            if (IsUseDefaultLanguage) return TextType.ToString();
            return MStringResource.GetText(TextType);
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
                var Display = MStringResource.GetText(frm.Tag.ToString());
                if (!string.IsNullOrEmpty(Display))
                {
                    frm.Text = Display;
                }
            }
            //遍历所有控件
            Translateform(frm.Controls);
        }

        public static void Translateform(ToolStripItemCollection Controls)
        {
            foreach (ToolStripItem menuItem in Controls)
            {
                if (menuItem.GetType().FullName == typeof(ToolStripSeparator).FullName) continue;
                if (menuItem.GetType().FullName == typeof(ToolStripMenuItem).FullName)
                {
                    if (((ToolStripMenuItem)menuItem).Tag == null) continue;
                    var Display = MStringResource.GetText(((ToolStripMenuItem)menuItem).Tag.ToString());
                    if (string.IsNullOrEmpty(Display)) continue;
                    ((ToolStripMenuItem)menuItem).Text = Display;
                    if (((ToolStripMenuItem)menuItem).DropDownItems.Count > 0) Translateform(((ToolStripMenuItem)menuItem).DropDownItems);
                }
                if (menuItem.GetType().FullName == typeof(ToolStripButton).FullName)
                {
                    if (((ToolStripButton)menuItem).Tag == null) continue;
                    var Display = MStringResource.GetText(((ToolStripButton)menuItem).Tag.ToString());
                    if (string.IsNullOrEmpty(Display)) continue;
                    ((ToolStripButton)menuItem).Text = Display;
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Controls"></param>
        public static void Translateform(Control.ControlCollection Controls)
        {
            var Display = string.Empty;
            foreach (Control ctrlItem in Controls)
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
                            Display = MStringResource.GetText(tab.Tag.ToString());
                            tab.Text = Display;
                        }
                        Translateform(tab.Controls);
                    }
                }
                if (ctrlItem.GetType().FullName == typeof(GroupBox).FullName)
                {
                    ((GroupBox)ctrlItem).Text = Display;
                    Translateform(ctrlItem.Controls);
                }
                if (ctrlItem.Tag == null) continue;
                Display = MStringResource.GetText(ctrlItem.Tag.ToString());
                if (string.IsNullOrEmpty(Display)) continue;

                if (ctrlItem.GetType().FullName == typeof(Label).FullName)
                {
                    ((Label)ctrlItem).Text = Display;
                }
                if (ctrlItem.GetType().FullName == typeof(Button).FullName)
                {
                    ((Button)ctrlItem).Text = Display;
                }
                if (ctrlItem.GetType().FullName == typeof(CheckBox).FullName)
                {
                    ((CheckBox)ctrlItem).Text = Display;
                }
                if (ctrlItem.GetType().FullName == typeof(RadioButton).FullName)
                {
                    ((RadioButton)ctrlItem).Text = Display;
                }
            }
        }
    }
}