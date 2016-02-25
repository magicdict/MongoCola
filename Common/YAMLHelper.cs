using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public static class YamlHelper
    {
        public const string PointChar = "$POINT$";

        /// <summary>
        ///     生成YAML文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="items"></param>
        public static void CreateFile(string fileName, List<string> items)
        {
            //假定Items的格式为Path：Value
            //Value为字符串（可以带有双引号）
            var yamlDoc = new StreamWriter(fileName, false, Encoding.UTF8);
            items.Sort((x, y) => string.Compare(x, y, StringComparison.Ordinal));
            for (var i = 0; i < items.Count; i++)
            {
                if (i == 0)
                {
                    //第一个项目
                    PrintYaml(yamlDoc, 0, items[i]);
                    continue;
                }
                //从后一个字符串
                var last = items[i].Split(".".ToCharArray());
                var pre = items[i - 1].Split(".".ToCharArray());
                //表示相同段数
                var sameSegment = 0;
                for (var j = 0; j < Math.Min(last.Length, pre.Length); j++)
                {
                    if (last[j] != pre[j])
                    {
                        sameSegment = j;
                        break;
                    }
                }
                //Items[i]去掉相同的字符首
                var removedItems = string.Empty;
                for (var k = sameSegment; k < last.Length; k++)
                {
                    if (k != last.Length - 1)
                    {
                        removedItems += last[k] + ".";
                    }
                    else
                    {
                        removedItems += last[k];
                    }
                }
                PrintYaml(yamlDoc, sameSegment, removedItems);
            }
            yamlDoc.Close();
        }

        private static void PrintYaml(StreamWriter yamlDoc, int indentLevel, string item)
        {
            var indent = indentLevel*3;

            var itemArray = item.Split(".".ToCharArray());
            for (var i = 0; i < itemArray.Length; i++)
            {
                if (i != itemArray.Length - 1)
                {
                    yamlDoc.WriteLine(new string(" ".ToCharArray()[0], indent) + itemArray[i] + ": ");
                    indent += 3;
                }
                else
                {
                    yamlDoc.WriteLine(new string(" ".ToCharArray()[0], indent) + itemArray[i].Replace(PointChar, "."));
                }
            }
        }
    }
}