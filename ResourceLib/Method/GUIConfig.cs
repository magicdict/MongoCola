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
        ///     失败提示色
        /// </summary>
        public static Color FailColor = Color.Pink;

        /// <summary>
        ///     动作提示色
        /// </summary>
        public static Color ActionColor = Color.LightBlue;

        /// <summary>
        ///     警告提示色
        /// </summary>
        public static Color WarningColor = Color.LightYellow;

        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        public static bool IsUseDefaultLanguage = false;

        /// <summary>
        ///     是否为Mono
        /// </summary>
        public static bool IsMono = false;

        /// <summary>
        ///     Mac默认中文字体
        ///     中/日
        /// </summary>
        public static string MacFontFamilyName = "苹方-简";

        /// <summary>
        ///     字符串
        /// </summary>
        public static StringResource mStringResource = new StringResource();



        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(string tag)
        {
            return GetText(tag, tag);
        }

        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="defaultText"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetText(string defaultText, string tag)
        {
            if (IsUseDefaultLanguage) return defaultText;
            tag = tag.Replace("_", string.Empty).ToUpper();
            var strText = string.Empty;
            StringResource.StringDic.TryGetValue(tag, out strText);
            strText = string.IsNullOrEmpty(strText) ? defaultText : strText.Replace("&amp;", "&");
            return strText;
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
                    //Window Title'font can't be modify
                    if (!IsMono) frm.Text = display;
                    if (IsMono) frm.Font = GetMonoFont(frm.Font);
                }
            }
            //遍历所有控件
            Translateform(frm.Controls);
        }

        /// <summary>
        ///     ChangeFont
        /// </summary>
        /// <returns>The mono font.</returns>
        /// <param name="orgFont">Org font.</param>
        public static Font GetMonoFont(Font orgFont)
        {
            var macFont = new Font(MacFontFamilyName, orgFont.Size, orgFont.Style);
            return macFont;
        }

        /// <summary>
        ///     Mono
        /// </summary>
        /// <param name="frm">Frm.</param>
        public static void MonoCompactControl(Control.ControlCollection controls)
        {
            if (!IsMono)
                return;
            foreach (Control ctrlItem in controls)
            {
                if (ctrlItem.GetType().FullName == typeof(NumericUpDown).FullName)
                {
                    //TextAlign
                    ((NumericUpDown)ctrlItem).TextAlign = HorizontalAlignment.Left;
                }
                if (ctrlItem.GetType().FullName == typeof(TabControl).FullName)
                {
                    foreach (TabPage tab in ((TabControl)ctrlItem).TabPages)
                    {
                        MonoCompactControl(tab.Controls);
                    }
                }
            }
        }

        /// <summary>
        ///     控件多语言化
        /// </summary>
        /// <param name="controls"></param>
        public static void Translateform(ToolStripItemCollection controls)
        {
            if (IsUseDefaultLanguage) return;
            foreach (ToolStripItem menuItem in controls)
            {
                if (menuItem.GetType().FullName == typeof(ToolStripSeparator).FullName) continue;
                if (menuItem.GetType().FullName == typeof(ToolStripMenuItem).FullName)
                {
                    if (menuItem.Tag == null) continue;
                    var display = GetText(menuItem.Text, menuItem.Tag.ToString());
                    if (string.IsNullOrEmpty(display)) continue;
                    menuItem.Text = display;
                    if (IsMono) menuItem.Font = GetMonoFont(menuItem.Font);
                    if (((ToolStripMenuItem)menuItem).DropDownItems.Count > 0)
                        Translateform(((ToolStripMenuItem)menuItem).DropDownItems);
                }
                if (menuItem.GetType().FullName == typeof(ToolStripButton).FullName)
                {
                    if (menuItem.Tag == null) continue;
                    var display = GetText(menuItem.Text, menuItem.Tag.ToString());
                    if (string.IsNullOrEmpty(display)) continue;
                    menuItem.Text = display;
                    if (IsMono) menuItem.Font = GetMonoFont(menuItem.Font);
                }
            }
        }

        /// <summary>
        ///     控件多语言化
        /// </summary>
        /// <param name="controls"></param>
        public static void Translateform(Control.ControlCollection controls)
        {
            if (IsUseDefaultLanguage) return;
            foreach (Control ctrlItem in controls)
            {
                var display = string.Empty;
                if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                //复合控件
                if (ctrlItem.GetType().FullName == typeof(MenuStrip).FullName)
                {
                    if (((MenuStrip)ctrlItem).Items.Count > 0) Translateform(((MenuStrip)ctrlItem).Items);
                }
                //ToolStrip
                if (ctrlItem.GetType().FullName == typeof(ToolStrip).FullName)
                {
                    if (((ToolStrip)ctrlItem).Items.Count > 0) Translateform(((ToolStrip)ctrlItem).Items);
                }
                if (ctrlItem.GetType().FullName == typeof(ToolStripContainer).FullName)
                {
                    var x = ((ToolStripContainer)ctrlItem);
                    //上下左右应该都有，暂时加Top
                    Translateform(x.TopToolStripPanel.Controls);
                }

                //Tab
                if (ctrlItem.GetType().FullName == typeof(TabControl).FullName)
                {
                    if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                    foreach (TabPage tab in ((TabControl)ctrlItem).TabPages)
                    {
                        if (tab.Tag != null)
                        {
                            display = GetText(tab.Tag.ToString());
                            tab.Text = display;
                            if (IsMono) tab.Font = GetMonoFont(tab.Font);
                        }
                        Translateform(tab.Controls);
                    }
                }
                //GroupBox
                if (ctrlItem.GetType().FullName == typeof(GroupBox).FullName)
                {
                    if (((GroupBox)ctrlItem).Tag != null) display = GetText(((GroupBox)ctrlItem).Text, ctrlItem.Tag.ToString()); ;
                    if (!string.IsNullOrEmpty(display))
                    {
                        ((GroupBox)ctrlItem).Text = display;
                        if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                    }
                    Translateform(ctrlItem.Controls);
                }
                //列表控件
                if (ctrlItem.GetType().FullName == typeof(ListView).FullName)
                {
                    var lst = (ListView)ctrlItem;
                    if (IsMono) lst.Font = GetMonoFont(lst.Font);
                    foreach (ColumnHeader header in lst.Columns)
                    {
                        if (header.Tag != null)
                        {
                            header.Text = GetText(header.Text, header.Tag.ToString());
                        }
                    }
                }
                //单一控件
                if (ctrlItem.Tag == null) continue;
                //标签
                if (ctrlItem.GetType().FullName == typeof(Label).FullName)
                {
                    ((Label)ctrlItem).Text = GetText(((Label)ctrlItem).Text, ctrlItem.Tag.ToString());
                    if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                }
                //按钮
                if (ctrlItem.GetType().FullName == typeof(Button).FullName)
                {
                    ((Button)ctrlItem).Text = GetText(((Button)ctrlItem).Text, ctrlItem.Tag.ToString());
                    if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                    if (ctrlItem.Tag.ToString().ToUpper() == "Common.Ok".ToUpper())
                    {
                        ((Button)ctrlItem).BackColor = SuccessColor;
                    }
                    if (ctrlItem.Tag.ToString().ToUpper() == "Common.No".ToUpper() ||
                        ctrlItem.Tag.ToString().ToUpper() == "Common.Close".ToUpper() ||
                        ctrlItem.Tag.ToString().ToUpper() == "Common.Cancel".ToUpper())
                    {
                        ((Button)ctrlItem).BackColor = FailColor;
                    }
                }
                //复选框
                if (ctrlItem.GetType().FullName == typeof(CheckBox).FullName)
                {
                    ((CheckBox)ctrlItem).Text = GetText(((CheckBox)ctrlItem).Text, ctrlItem.Tag.ToString());
                    if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                }
                //单选框
                if (ctrlItem.GetType().FullName == typeof(RadioButton).FullName)
                {
                    ((RadioButton)ctrlItem).Text = GetText(((RadioButton)ctrlItem).Text, ctrlItem.Tag.ToString());
                    if (IsMono) ctrlItem.Font = GetMonoFont(ctrlItem.Font);
                }
            }
        }
    }
}