using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Common
{
    public static partial class Utility
    {
        #region "Resource "

        /// <summary>
        ///     获得嵌入式资源
        ///     必须保证资源和本函数在同一个DLL中
        /// </summary>
        /// <param name="saveFilename"></param>
        /// <param name="resFilename"></param>
        public static void GetResource(string saveFilename, string resFilename)
        {
            var asm = Assembly.GetExecutingAssembly();
            if (File.Exists(saveFilename))
            {
                File.Delete(saveFilename);
            }
            Stream read = new FileStream(saveFilename, FileMode.Create);
            var manifestResourceStream = asm.GetManifestResourceStream("DevKit.Common.Resources." + resFilename);
            if (manifestResourceStream != null)
                manifestResourceStream.CopyTo(read);
            read.Close();
        }

        /// <summary>
        ///     保存对象
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        public static void SaveObjAsXml<T>(string filename, T obj)
        {
            var settings = new XmlWriterSettings { Indent = true, NewLineChars = Environment.NewLine };
            //NewLineChars对于String属性的东西无效
            //这是对于XML中换行有效，
            //String的换行会变成Console的NewLine /n
            var xml = new XmlSerializer(typeof(T));
            var writer = XmlWriter.Create(filename, settings);
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xml.Serialize(writer, obj, ns);
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
            var xml = new XmlSerializer(typeof(T));
            var reader = XmlReader.Create(filename, setting);
            var obj = (T)xml.Deserialize(reader);
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
            return (T)bFormatter.Deserialize(stream);
        }


        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="result"></param>
        public static void SaveJavascriptFile(string result)
        {
            var dialog = new SaveFileDialog { Filter = JsFilter };
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
            var context = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var reader = new StreamReader(dialog.FileName);
                    context = reader.ReadToEnd();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    ExceptionDeal(ex);
                }
            }
            return context;
        }

        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="result"></param>
        /// <param name="filter"></param>
        public static void SaveTextFile(string result, string filter)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = filter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(result);
                writer.Close();
            }
        }

        /// <summary>
        ///     获得数字，默认是0
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static int GetExcelIntValue(dynamic cell)
        {
            int.TryParse(cell.Text, out int t);
            return t;
        }

        /// <summary>
        ///     获得布尔值，默认是False
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static bool GetExcelBooleanValue(dynamic cell)
        {
            return !string.IsNullOrEmpty(cell.Text);
        }

        #endregion
    }
}