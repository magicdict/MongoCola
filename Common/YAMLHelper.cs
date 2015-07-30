using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

namespace Common
{
    public static class YamlHelper
    {
        public const string PointChar = "$POINT$";
        /// <summary>
        ///     生成YAML文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Items"></param>
        public static void CreateFile(string fileName, List<string> Items)
        {
            //假定Items的格式为Path：Value
            //Value为字符串（可以带有双引号）
            StreamWriter YamlDoc = new StreamWriter(fileName, false, Encoding.UTF8);
            Items.Sort((x, y) => { return x.CompareTo(y); });
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == 0)
                {
                    //第一个项目
                    PrintYaml(YamlDoc, 0, Items[i]);
                    continue;
                }
                //从后一个字符串
                var Last = Items[i].Split(".".ToCharArray());
                var Pre = Items[i - 1].Split(".".ToCharArray());
                //表示相同段数
                int SameSegment = 0;
                for (int j = 0; j < Math.Min(Last.Length, Pre.Length); j++)
                {
                    if (Last[j] != Pre[j])
                    {
                        SameSegment = j;
                        break;
                    }
                }
                //Items[i]去掉相同的字符首
                string RemovedItems = string.Empty;
                for (int k = SameSegment; k < Last.Length; k++)
                {
                    if (k!= Last.Length - 1)
                    {
                        RemovedItems += Last[k] + ".";
                    }
                    else
                    {
                        RemovedItems += Last[k];
                    }
                }
                PrintYaml(YamlDoc, SameSegment, RemovedItems);
            }
            YamlDoc.Close();
        }

        private static void PrintYaml(StreamWriter YamlDoc, int IndentLevel, string Item)
        {
            int Indent = IndentLevel * 3;

            var ItemArray = Item.Split(".".ToCharArray());
            for (int i = 0; i < ItemArray.Length; i++)
            {
                if (i != (ItemArray.Length - 1))
                {
                    YamlDoc.WriteLine(new string(" ".ToCharArray()[0], Indent) + ItemArray[i] + ": ");
                    Indent += 3;
                }
                else
                {
                    YamlDoc.WriteLine(new string(" ".ToCharArray()[0], Indent) + ItemArray[i].Replace(PointChar,"."));
                }
            }
        }

    }
}
