using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Common
{
    public static partial class Utility
    {
        #region"UI"

        /// <summary>
        ///     枚举填充Combox
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="enumType"></param>
        /// <param name="isEditMode"></param>
        public static void FillComberWithEnum(ComboBox combox, Type enumType, bool isEditMode = true)
        {
            combox.Items.Clear();
            if (!isEditMode)
                combox.Items.Add("<All>");
            foreach (var item in Enum.GetValues(enumType))
            {
                combox.Items.Add(item.ToString());
            }
            combox.SelectedIndex = 0;
        }

        /// <summary>
        ///     使用字符填充combox
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="enumList"></param>
        /// <param name="isEditMode"></param>
        public static void FillComberWithArray(ComboBox combox, string[] enumList, bool isEditMode = true)
        {
            combox.Items.Clear();
            if (!isEditMode)
                combox.Items.Add("<All>");
            foreach (var item in enumList)
            {
                combox.Items.Add(item);
            }
            combox.SelectedIndex = 0;
        }

        /// <summary>
        ///     自动调整列宽度
        /// </summary>
        /// <param name="lstview"></param>
        public static void ListViewColumnResize(ListView lstview)
        {
            var columnWidth = new int[lstview.Columns.Count];
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                columnWidth[i] = lstview.Columns[i].Width;
            }
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                columnWidth[i] = Math.Max(lstview.Columns[i].Width, columnWidth[i]);
            }
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                lstview.Columns[i].Width = columnWidth[i];
            }
        }

        /// <summary>
        ///     输入框
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string InputBox(string prompt, string title = "中和软件")
        {
            return Interaction.InputBox(prompt, title);
        }

        /// <summary>
        ///     格式化窗体
        /// </summary>
        /// <param name="orgForm"></param>
        /// <returns></returns>
        /// <param name="showDialog"></param>
        public static void SetUp(Form orgForm, bool showDialog = true)
        {
            orgForm.StartPosition = FormStartPosition.CenterParent;
            orgForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            if (showDialog)
                orgForm.ShowDialog();
        }

        /// <summary>
        ///     对话框子窗体的统一管理
        /// </summary>
        /// <param name="mfrm"></param>
        /// <param name="isDispose">有些时候需要使用被打开窗体产生的数据，所以不能Dispose</param>
        /// <param name="isUseAppIcon"></param>
        public static void OpenForm(Form mfrm, bool isDispose, bool isUseAppIcon)
        {
            mfrm.StartPosition = FormStartPosition.CenterParent;
            mfrm.BackColor = Color.White;
            mfrm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mfrm.MaximizeBox = false;
            mfrm.Font = new Font("微软雅黑", 9);
            if (isUseAppIcon)
            {
                mfrm.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            mfrm.ShowDialog();
            mfrm.Close();
            if (isDispose)
            {
                mfrm.Dispose();
            }
        }

        /// <summary>
        ///     文件对话框模式
        /// </summary>
        public enum FileDialogMode
        {
            /// <summary>
            ///     打开文件
            /// </summary>
            Open,

            /// <summary>
            ///     保存文件
            /// </summary>
            Save
        }

        /// <summary>
        ///     选取文件
        /// </summary>
        /// <param name="mode">模式</param>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        public static string PickFile(FileDialogMode mode, string filter = "*.*(All Files)|*.*")
        {
            FileDialog dialog;
            if (mode == FileDialogMode.Open)
            {
                dialog = new OpenFileDialog();
            }
            else
            {
                dialog = new SaveFileDialog();
            }
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }


        /// <summary>
        ///     选择文件夹
        /// </summary>
        /// <returns></returns>
        public static string PickFolder()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return string.Empty;
        }

        #endregion
    }
}