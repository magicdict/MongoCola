using System.Collections.Generic;
using System.Xml;

namespace ResourceLib.Method
{
    /// <summary>
    ///     StringResource
    /// </summary>
    public class StringResource
    {
        /// <summary>
        ///     英语（默认语种）
        /// </summary>
        public const string LanguageEnglish = "English";

        /// <summary>
        ///     国际化文字字典
        /// </summary>
        public static Dictionary<string, string> StringDic = new Dictionary<string, string>();

        /// <summary>
        ///     语种
        /// </summary>
        public static string LanguageType = string.Empty;

        /// <summary>
        ///     字符资源
        /// </summary>
        /// <param name="languageFileName">当前语言文件</param>
        public static void InitLanguage(string languageFileName)
        {
            StringDic.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(languageFileName);
            var root = xmlDoc.DocumentElement;
            LanguageType = root.GetAttribute("Type");

            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.NodeType == XmlNodeType.Element) SetItem(string.Empty, item);
            }
        }
        /// <summary>
        ///     递归遍历
        /// </summary>
        /// <param name="PreTag"></param>
        /// <param name="node"></param>
        public static void SetItem(string PreTag, XmlNode node)
        {
            var tag = string.Empty;
            var text = string.Empty;

            if (node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
            {
                tag = PreTag + node.Name.Trim().Replace("_", "").ToUpper();
                text = node.ChildNodes[0].InnerText;
                if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(text))
                {
                    StringDic.Add(tag, text);
                }
            }
            else
            {
                tag = PreTag + node.Name.Trim().Replace("_", "").ToUpper() + ".";
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.NodeType == XmlNodeType.Element) SetItem(tag, item);
                }
            }
        }
    }
}