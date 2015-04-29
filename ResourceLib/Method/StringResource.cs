using System.Collections.Generic;
using System.Xml;

namespace ResourceLib.Method
{
    /// <summary>
    ///     String Resource
    /// </summary>
    /// <remarks>
    ///     这个功能的负责人是MoLing。
    ///     有任何翻译上的问题，或者您想共享某个语种的翻译文件，请在Github上给MoLing留言
    /// </remarks>
    public class StringResource
    {
        /// <summary>
        ///     国际化文字字典
        /// </summary>
        private readonly Dictionary<string, string> _stringDic = new Dictionary<string, string>();

        /// <summary>
        ///     语种
        /// </summary>
        public string LanguageType = string.Empty;

        /// <summary>
        ///     英语（默认语种）
        /// </summary>
        public const string LanguageEnglish = "English";

        /// <summary>
        ///     字符资源
        /// </summary>
        /// <param name="languageFileName">当前语言文件</param>
        public void InitLanguage(string languageFileName)
        {
            var tag = string.Empty;
            var text = string.Empty;
            var reader = new XmlTextReader(languageFileName);
            _stringDic.Clear();
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
                        tag = reader.Name.Trim();
                        text = reader.ReadInnerXml().Trim();
                        if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(text))
                        {
                            _stringDic.Add(tag, text);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///     Get Global String
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetText(TextType tag)
        {
            var strText = string.Empty;
            _stringDic.TryGetValue(tag.ToString(), out strText);
            strText = string.IsNullOrEmpty(strText) ? tag.ToString() : strText.Replace("&amp;", "&");
            return strText;
        }

        /// <summary>
        ///     Get Global String
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetText(string tag)
        {
            var strText = string.Empty;
            _stringDic.TryGetValue(tag, out strText);
            strText = string.IsNullOrEmpty(strText) ? tag : strText.Replace("&amp;", "&");
            return strText;
        }
    }
}