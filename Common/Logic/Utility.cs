using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Common.UI;
using Microsoft.VisualBasic;
using ResourceLib.Utility;

namespace Common.Logic
{
    public static class Utility
    {
        public static GUIConfig guiconfig = new GUIConfig();

        public static void Init(GUIConfig _guiconfig)
        {
            guiconfig = _guiconfig;
            MyMessageBox.InitMsgBoxUI();
        }

        #region "类型"

        /// <summary>
        ///     获得字符枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strEnum"></param>
        /// <returns></returns>
        /// <param name="Default"></param>
        public static T GetEnum<T>(string strEnum, T Default)
        {
            if (string.IsNullOrEmpty(strEnum))
                return Default;
            try
            {
                var EnumValue = (T) Enum.Parse(typeof (T), strEnum);
                return EnumValue;
            }
            catch (Exception)
            {
                return Default;
            }
        }

        #endregion

        #region"Excel"

        /// <summary>
        ///     获得数字，默认是0
        /// </summary>
        /// <param name="Cell"></param>
        /// <returns></returns>
        public static int GetExcelIntValue(dynamic Cell)
        {
            int t;
            int.TryParse(Cell.Text, out t);
            return t;
        }

        /// <summary>
        ///     获得布尔值，默认是False
        /// </summary>
        /// <param name="Cell"></param>
        /// <returns></returns>
        public static bool GetExcelBooleanValue(dynamic Cell)
        {
            return !String.IsNullOrEmpty(Cell.Text);
        }

        #endregion

        #region "Misc"

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetSize(long size)
        {
            string[] Unit =
            {
                "Byte", "KB", "MB", "GB", "TB"
            };
            if (size == 0)
            {
                return "0 Byte";
            }
            byte unitOrder = 2;
            var tempSize = size/Math.Pow(2, 20);
            while (!(tempSize > 0.1 & tempSize < 1000))
            {
                if (tempSize < 0.1)
                {
                    tempSize = tempSize*1024;
                    unitOrder--;
                }
                else
                {
                    tempSize = tempSize/1024;
                    unitOrder++;
                }
            }
            return string.Format("{0:F2}", tempSize) + " " + Unit[unitOrder];
        }

        /// <summary>
        ///     将表示的尺寸还原为实际尺寸以对应排序的要求
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static long ReconvSize(string size)
        {
            string[] Unit =
            {
                "Byte", "KB", "MB", "GB", "TB"
            };
            if (size == "0 Byte")
            {
                return 0;
            }
            for (var i = 0; i < Unit.Length; i++)
            {
                if (size.EndsWith(Unit[i]))
                {
                    size = size.Replace(Unit[i], string.Empty).Trim();
                    return (long) (Convert.ToDouble(size)*Math.Pow(2, (i*10)));
                }
            }
            return 0;
        }

        /// <summary>
        ///     获得对象的种类
        /// </summary>
        /// <returns></returns>
        public static string GetTagType(string objectTag)
        {
            return objectTag == string.Empty ? string.Empty : objectTag.Split(":".ToCharArray())[0];
        }

        /// <summary>
        ///     获得对象的路径
        /// </summary>
        /// <returns></returns>
        public static string GetTagData(string objectTag)
        {
            if (objectTag == string.Empty)
            {
                return string.Empty;
            }
            if (objectTag.Split(":".ToCharArray()).Length == 2)
            {
                return objectTag.Split(":".ToCharArray())[1];
            }
            return string.Empty;
        }

        #endregion

        #region "Resource "

        /// <summary>
        ///     获得嵌入式资源
        ///     必须保证资源和本函数在同一个DLL中
        /// </summary>
        /// <param name="saveFilename"></param>
        /// <param name="ResFilename"></param>
        public static void getResource(String saveFilename, String ResFilename)
        {
            var asm = Assembly.GetExecutingAssembly();
            if (File.Exists(saveFilename))
            {
                File.Delete(saveFilename);
            }
            Stream Read = new FileStream(saveFilename, FileMode.Create);
            asm.GetManifestResourceStream("DevKit.Common.Resources." + ResFilename).CopyTo(Read);
            Read.Close();
        }

        /// <summary>
        ///     保存对象
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Obj"></param>
        public static void SaveObjAsXml<T>(string filename, T Obj)
        {
            var settings = new XmlWriterSettings {Indent = true, NewLineChars = Environment.NewLine};
            //NewLineChars对于String属性的东西无效
            //这是对于XML中换行有效，
            //String的换行会变成Console的NewLine /n
            var xml = new XmlSerializer(typeof (T));
            var writer = XmlWriter.Create(filename, settings);
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xml.Serialize(writer, Obj, ns);
            writer.Close();
        }

        /// <summary>
        ///     读取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T LoadObjFromXml<T>(string filename)
        {
            var setting = new XmlReaderSettings();
            var xml = new XmlSerializer(typeof (T));
            var reader = XmlReader.Create(filename, setting);
            var obj = (T) xml.Deserialize(reader);
            reader.Close();
            return obj;
        }

        /// <summary>
        ///     深拷贝
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T obj)
        {
            var bFormatter = new BinaryFormatter();
            var stream = new MemoryStream();
            bFormatter.Serialize(stream, obj);
            stream.Seek(0, SeekOrigin.Begin);
            return (T) bFormatter.Deserialize(stream);
        }


        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="result"></param>
        public static void SaveJavascriptFile(string result)
        {
            var dialog = new SaveFileDialog {Filter = JsFilter};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(result);
                writer.Close();
            }
        }

        /// <summary>
        ///     Load File
        /// </summary>
        /// <returns></returns>
        public static string LoadFile()
        {
            var dialog = new OpenFileDialog();
            var Context = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var reader = new StreamReader(dialog.FileName);
                    Context = reader.ReadToEnd();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    ExceptionDeal(ex);
                }
            }
            return Context;
        }

        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="Result"></param>
        /// <param name="Filter"></param>
        public static void SaveTextFile(string Result, string Filter)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = Filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(Result);
                writer.Close();
            }
        }

        #endregion

        #region"UI"

        /// <summary>
        ///     枚举填充Combox
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="enumType"></param>
        /// <param name="IsEditMode"></param>
        public static void FillComberWithEnum(ComboBox combox, Type enumType, bool IsEditMode = true)
        {
            combox.Items.Clear();
            if (!IsEditMode)
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
        /// <param name="EnumList"></param>
        /// <param name="IsEditMode"></param>
        public static void FillComberWithArray(ComboBox combox, string[] EnumList, bool IsEditMode = true)
        {
            combox.Items.Clear();
            if (!IsEditMode)
                combox.Items.Add("<All>");
            foreach (var item in EnumList)
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
            var ColumnWidth = new int[lstview.Columns.Count];
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                ColumnWidth[i] = lstview.Columns[i].Width;
            }
            lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                ColumnWidth[i] = Math.Max(lstview.Columns[i].Width, ColumnWidth[i]);
            }
            for (var i = 0; i < lstview.Columns.Count; i++)
            {
                lstview.Columns[i].Width = ColumnWidth[i];
            }
        }

        /// <summary>
        ///     输入框
        /// </summary>
        /// <param name="Prompt"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public static string InputBox(string Prompt, string Title = "中和软件")
        {
            return Interaction.InputBox(Prompt, Title);
        }

        /// <summary>
        ///     格式化窗体
        /// </summary>
        /// <param name="orgForm"></param>
        /// <returns></returns>
        /// <param name="ShowDialog"></param>
        public static void SetUp(Form orgForm, Boolean ShowDialog = true)
        {
            orgForm.Text += " - 中和软件";
            orgForm.StartPosition = FormStartPosition.CenterParent;
            orgForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            if (ShowDialog)
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
        /// <param name="Filter">过滤器</param>
        /// <returns></returns>
        public static string PickFile(FileDialogMode mode, string Filter = "*.*(All Files)|*.*")
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
            dialog.Filter = Filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        public static string JsFilter = "*.js(JavaScript Files)|*.js";

        /// <summary>
        ///     XML
        /// </summary>
        public static string XmlFilter = "*.xml(XML Files)|*.xml";

        /// <summary>
        ///     Xlsx
        /// </summary>
        public static string XlsxFilter = "*.xlsx(Excel Files)|*.xlsx";

        /// <summary>
        ///     CShapr
        /// </summary>
        public static string CSFilter = "*.cs(C# SourceCode)|*.cs";

        /// <summary>
        ///     Java
        /// </summary>
        public static string JavaFilter = "*.java(Java SourceCode)|*.java";

        /// <summary>
        ///     Sql
        /// </summary>
        public static string SqlFilter = "*.sql(Sql files)|*.sql";

        /// <summary>
        ///     Excel文件选择过滤器
        /// </summary>
        public const String ExcelFilter = "Excel File(*.xls)|*.xls|*.*(All Files)|*.*";

        /// <summary>
        ///     Txt文件选择过滤器
        /// </summary>
        public const String TxtFilter = "Plan Text File(*.txt)|*.txt|*.*(All Files)|*.*";

        /// <summary>
        ///     LOG文件选择过滤器
        /// </summary>
        public const String LogFilter = "Log File(*.log)|*.log|*.*(All Files)|*.*";

        /// <summary>
        ///     MDB文件选择过滤器
        /// </summary>
        public const String MdbFilter = "Access File(*.mdb)|*.mdb|*.*(All Files)|*.*";

        /// <summary>
        ///     Conf文件选择过滤器
        /// </summary>
        public const String ConfFilter = "Config File(*.conf)|*.conf|*.*(All Files)|*.*";

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

        #region"异常处理"

        public static string ExceptionAppendInfo = string.Empty;

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        public static void ExceptionDeal(Exception ex)
        {
            ExceptionDeal(ex, "Exception", "Exception");
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">消息</param>
        public static void ExceptionDeal(Exception ex, string message)
        {
            try
            {
                ExceptionDeal(ex, "Exception", message);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="Title">标题</param>
        /// <param name="Message">消息</param>
        public static void ExceptionDeal(Exception ex, string Title, string Message)
        {
            var ExceptionString = string.Empty;
            if (!String.IsNullOrEmpty(ExceptionAppendInfo))
                ExceptionString = ExceptionAppendInfo;
            ExceptionString += ex.ToString();
            MyMessageBox.ShowMessage(Title, Message, ExceptionString, true);
            ExceptionLog(ExceptionString);
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="ExceptionString">异常文字</param>
        public static void ExceptionLog(string ExceptionString)
        {
            var exLog = new StreamWriter("Exception.log", true);
            exLog.WriteLine("DateTime:" + DateTime.Now);
            exLog.WriteLine(ExceptionString);
            exLog.Close();
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void ExceptionLog(Exception ex)
        {
            var ExceptionString = string.Empty;
            //			ExceptionString = "MongoDB.Driver.DLL:" + MongoDbDriverVersion + Environment.NewLine;
            //			ExceptionString += "MongoDB.Bson.DLL:" + MongoDbBsonVersion + Environment.NewLine;
            ExceptionString += ex.ToString();
            ExceptionLog(ExceptionString);
        }

        #endregion
    }
}