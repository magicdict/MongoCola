using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLFUI
{
    /// <summary>
    /// 跨平台用的Ini类
    /// </summary>
    public class IniFile
    {
        private System.Collections.SortedList m_SectionList = new System.Collections.SortedList();

        public IniFile()
        {
        }

        public IniFile(string fileName)
        {
            m_FileName = fileName;

            if (System.IO.File.Exists(fileName))
            {
                LoadFrom(this.FileName);
            }
        }

        private string m_FileName;
        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
            }
        }

        public void LoadFrom(string fileName)
        {
            string s1, s2, key, v;
            int index;
            string section = string.Empty;
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName, System.Text.ASCIIEncoding.Default);
            try
            {
                System.Collections.SortedList thisSection = null;

                m_SectionList.Clear();

                while (reader.Peek() >= 0)
                {
                    s1 = reader.ReadLine();
                    s2 = s1.Trim();
                    if (s2.Length < 2)
                    {
                        continue;
                    }

                    if (s2[0] == '[' && s2[s2.Length - 1] == ']')
                    {
                        //new section
                        s1 = s2.Substring(1, s2.Length - 2).Trim();
                        if (s1.Length == 0)
                        {
                            continue;
                        }

                        section = s1;

                        thisSection = m_SectionList[section] as System.Collections.SortedList;
                        if (thisSection == null)
                        {
                            thisSection = new System.Collections.SortedList();
                            m_SectionList.Add(section, thisSection);
                        }

                        continue;
                    }
                    else
                    {
                        //old section
                        if (section == string.Empty)
                        {
                            continue;
                        }

                        index = s1.IndexOf("=");
                        if (index < 0)
                        {
                            //no key or value
                            continue;
                        }

                        key = s1.Substring(0, index).Trim();
                        v = s1.Substring(index + 1, s1.Length - index - 1);

                        if (key.Length == 0 || v.Length == 0)
                        {
                            continue;
                        }

                        if (thisSection[key] == null)
                        {
                            thisSection.Add(key, v);
                        }
                        else
                        {
                            thisSection[key] = v;
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void SaveTo(string fileName)
        {
            System.Collections.SortedList thisSection;
            string section, key, v;
            string sectionFmt = "[{0}]/r/n";
            string keyFmt = "{0}={1}/r/n";

            System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(stream, System.Text.ASCIIEncoding.Default);
                try
                {
                    for (int i = 0; i < m_SectionList.Count; i++)
                    {
                        section = (string)m_SectionList.GetKey(i);
                        writer.Write(string.Format(sectionFmt, section));

                        thisSection = m_SectionList.GetByIndex(i) as System.Collections.SortedList;
                        for (int j = 0; j < thisSection.Count; j++)
                        {
                            key = (string)thisSection.GetKey(j);
                            v = (string)thisSection.GetByIndex(j);
                            writer.Write(string.Format(keyFmt, key, v));
                        }
                    }
                }
                finally
                {
                    writer.Close();
                }
            }
            finally
            {
                stream.Close();
            }
        }

        public void Updates()
        {
            this.SaveTo(this.FileName);
        }

        public string ReadString(string section, string key)
        {
            System.Collections.SortedList thisSection = m_SectionList[section] as System.Collections.SortedList;
            if (thisSection == null)
            {
                return string.Empty;
            }
            else
            {
                object obj = thisSection[key];
                if (obj == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (string)obj;
                }
            }
        }

        public void WriteString(string section, string key, string value)
        {
            section = section.Trim();
            key = key.Trim();
            if (section == string.Empty || key == string.Empty)
            {
                return;
            }

            System.Collections.SortedList thisSection = m_SectionList[section] as System.Collections.SortedList;
            if (thisSection == null)
            {
                thisSection = new System.Collections.SortedList();
                m_SectionList.Add(section, thisSection);
            }

            object obj = thisSection[key];
            if (obj == null)
            {
                thisSection.Add(key, value);
            }
            else
            {
                thisSection[key] = value;
            }
        }

        public void EraseSection(string section)
        {
            m_SectionList.Remove(section);
        }

        public void DeleteKey(string section, string key)
        {
            System.Collections.SortedList thisSection = m_SectionList[section] as System.Collections.SortedList;
            if (thisSection == null)
            {
                return;
            }

            thisSection.Remove(key);
        }
    }

}
