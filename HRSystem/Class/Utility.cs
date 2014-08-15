using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRSystem
{
    public static class Utility
    {
        /// <summary>
        /// 获得字符枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strEnum"></param>
        /// <returns></returns>
        public static T GetEnum<T>(string strEnum, T Default)
        {
            if (string.IsNullOrEmpty(strEnum)) return Default;
            try
            {
                T EnumValue = (T)Enum.Parse(typeof(T), strEnum);
                return EnumValue;
            }
            catch (Exception)
            {
                return Default;
            }
        }
        /// <summary>
        /// 获得日期，非法日期时日期则为Min
        /// </summary>
        /// <param name="Cell">Excel单元格</param>
        /// <returns></returns>
        public static DateTime GetDate(dynamic Cell)
        {
            DateTime date;
            if (Cell.Value != null)
            {
                DateTime.TryParse(Cell.Value.ToString(), out date);
            }
            else
            {
                date = DateTime.MinValue;
            }
            return date;
        }
        /// <summary>
        /// 枚举填充Combox
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="enumType"></param>
        public static void FillComberWithEnum(ComboBox combox, Type enumType, bool IsEditMode = true)
        {
            combox.Items.Clear();
            if (!IsEditMode) combox.Items.Add("<All>");
            foreach (var item in Enum.GetValues(enumType))
            {
                combox.Items.Add(item.ToString());
            }
            combox.SelectedIndex = 0;
        }
        /// <summary>
        /// 使用字符填充combox
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="EnumList"></param>
        public static void FillComberWithArray(ComboBox combox, string[] EnumList)
        {
            combox.Items.Clear();
            foreach (var item in EnumList)
            {
                combox.Items.Add(item);
            }
            combox.SelectedIndex = 0;

        }
        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToDisplayString(this PositionBasicInfo.BandEnum t)
        {
            return t.ToString().Substring(1, 1) + t.ToString().Substring(0, 1);
        }

        public static void ListViewColumnResize(ListView lstview)
        {
            int[] ColumnWidth = new int[lstview.Columns.Count];
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (int i = 0; i < lstview.Columns.Count; i++)
            {
                ColumnWidth[i] = lstview.Columns[i].Width;
            }
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (int i = 0; i < lstview.Columns.Count; i++)
            {
                ColumnWidth[i] = Math.Max(lstview.Columns[i].Width, ColumnWidth[i]);
            }
            for (int i = 0; i < lstview.Columns.Count; i++)
            {
                lstview.Columns[i].Width = ColumnWidth[i];
            }
        }

    }
}
