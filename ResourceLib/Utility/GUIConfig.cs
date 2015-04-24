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
    public class GUIConfig
    {
        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        public Boolean IsUseDefaultLanguage = false;

        /// <summary>
        ///     字符串
        /// </summary>
        public StringResource MStringResource = new StringResource();

        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="DefaultText"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetText(string DefaultText,
            TextType tag = TextType.UseDefaultLanguage)
        {
            if (IsUseDefaultLanguage || tag == TextType.UseDefaultLanguage) return DefaultText;
            return MStringResource.GetText(tag);
        }

        /// <summary>
        ///     自动化多语言
        /// </summary>
        /// <param name="frm"></param>
        public void Translateform(Form frm)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Controls"></param>
        public void Translateform(Control.ControlCollection Controls)
        {
            var Display = string.Empty;
            foreach (Control ctrlItem in Controls)
            {
                if (ctrlItem.GetType().FullName == typeof(MenuStrip).FullName)
                {
                    foreach (ToolStripMenuItem menuItem in ((MenuStrip)ctrlItem).Items)
                    {
                        if (menuItem.Tag == null) continue;
                        Display = MStringResource.GetText(menuItem.Tag.ToString());
                        if (string.IsNullOrEmpty(Display)) continue;
                        menuItem.Text = Display;
                        foreach (ToolStripItem SubmenuItem in menuItem.DropDownItems)
                        {
                            if (SubmenuItem.Tag == null) continue;
                            Display = MStringResource.GetText(SubmenuItem.Tag.ToString());
                            if (string.IsNullOrEmpty(Display)) continue;
                            SubmenuItem.Text = Display;
                        }
                    }
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
                if (ctrlItem.GetType().FullName == typeof(GroupBox).FullName)
                {
                    ((GroupBox)ctrlItem).Text = Display;
                    Translateform(((GroupBox)ctrlItem).Controls);
                }
            }
        }
    }
}