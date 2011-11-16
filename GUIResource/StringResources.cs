using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GUIResource
{
    public class StringResources
    {
        Dictionary<string, string> _stringDic = new Dictionary<string, string>();

        public StringResources(string currentLanguage)
        {
            string tag = string.Empty;
            string text = string.Empty;
            XmlTextReader reader = new XmlTextReader(string.Format("Language\\{0}.xml",currentLanguage));
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.Name=="Language")
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
                }
                
                
            }
        }



        public string GetText(string tag)
        {
            return _stringDic[tag];
        }

        
    }
}
