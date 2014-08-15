using System;
using System.Windows.Forms;

namespace Common.Present
{
    public class Utility
    {
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
