using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
namespace GUIResource
{
    /// <summary>
    /// 字符资源
    /// </summary>
    ///<remarks>
    ///这个功能的负责人是MoLing。
    ///有任何翻译上的问题，或者您想共享某个语种的翻译文件，请在Github上给MoLing留言
    ///</remarks>
    public partial class StringResource
    {
        /// <summary>
        /// 国际化文字字典
        /// </summary>
        Dictionary<string, string> _stringDic = new Dictionary<string, string>();
        /// <summary>
        /// 字符资源
        /// </summary>
        /// <param name="LanguageFileName">当前语言文件</param>
        public void InitLanguage(String LanguageFileName)
        {
            string tag = string.Empty;
            string text = string.Empty;
            XmlTextReader reader = new XmlTextReader(LanguageFileName);
            _stringDic.Clear();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: 
                        // The node is an element.
                        if (reader.Name == "Language")
                        {
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
        /// 获得国际化文字
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetText(TextType tag)
        {
            String strText = String.Empty;
            //使用TryGetValue方法防止出现不存在的字符，同时比Exist提高效率
            _stringDic.TryGetValue(tag.ToString(), out strText);
            if (strText == null)
            {
                strText = tag.ToString();
            }
            else
            {
                strText = XMLUtility.XMLDecode(strText);
            }
            return strText;
        }
    }
}
