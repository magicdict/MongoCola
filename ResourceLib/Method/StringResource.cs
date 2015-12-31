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
            var tag = string.Empty;
            var text = string.Empty;
            var reader = new XmlTextReader(languageFileName);
            StringDic.Clear();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        // The node is an element.
                        if (reader.Name == "Language")
                        {
                            LanguageType = reader.GetAttribute("Type");
                            continue;
                        }
                        tag = reader.Name.Trim().Replace("_", "").ToUpper();
                        text = reader.ReadInnerXml().Trim();
                        if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(text))
                        {
                            StringDic.Add(tag, text);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}