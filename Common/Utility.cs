using System;
using System.Linq;

namespace Common
{
    public static partial class Utility
    {
        #region "Misc"

        /// <summary>
        ///     是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return str.All(char.IsNumber);
        }

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
                var enumValue = (T) Enum.Parse(typeof (T), strEnum);
                return enumValue;
            }
            catch (Exception)
            {
                return Default;
            }
        }

        /// <summary>
        ///     32位整型
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetKSystemInt32(int size)
        {
            string[] unit =
            {
                "", "K", "M", "G", "T"
            };
            if (size == 0)
            {
                return "0";
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
            return tempSize + " " + unit[unitOrder];
        }

        /// <summary>
        ///     64位整型
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetKSystemInt64(long size)
        {
            string[] unit =
            {
                "", "K", "M", "G", "T"
            };
            if (size == 0)
            {
                return "0";
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
            return tempSize + " " + unit[unitOrder];
        }

        /// <summary>
        ///     64位整型
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetKSystemDouble(double size)
        {
            string[] unit =
            {
                "", "K", "M", "G", "T"
            };
            if (size == 0)
            {
                return "0";
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
            return tempSize + " " + unit[unitOrder];
        }

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetSize(long size)
        {
            string[] unit =
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
            return tempSize.ToString("F2") + " " + unit[unitOrder]; //$"{tempSize:F2}" + " " + unit[unitOrder];
        }

        /// <summary>
        ///     将表示的尺寸还原为实际尺寸以对应排序的要求
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static long ReconvSize(string size)
        {
            string[] unit =
            {
                "Byte", "KB", "MB", "GB", "TB"
            };
            if (size == "0 Byte")
            {
                return 0;
            }
            for (var i = 0; i < unit.Length; i++)
            {
                if (size.EndsWith(unit[i]))
                {
                    size = size.Replace(unit[i], string.Empty).Trim();
                    return (long) (Convert.ToDouble(size)*Math.Pow(2, i*10));
                }
            }
            return 0;
        }

        #endregion
    }
}