using System;
using System.Collections;
using System.Windows.Forms;
using Common;

namespace MongoGUICtl.ClientTree
{
    public class LvwColumnSorter : IComparer
    {
        /// <summary>
        ///     比较方式
        /// </summary>
        public enum SortMethod
        {
            StringCompare,
            SizeCompare,
            NumberCompare
        }

        /// <summary>
        ///     声明CaseInsensitiveComparer类对象
        /// </summary>
        private readonly CaseInsensitiveComparer _objectCompare;

        /// <summary>
        ///     构造函数
        /// </summary>
        public LvwColumnSorter()
        {
            SortColumn = 0; // 默认按第一列排序            
            Order = SortOrder.None; // 排序方式为不排序            
            _objectCompare = new CaseInsensitiveComparer(); // 初始化CaseInsensitiveComparer类对象
            CompareMethod = SortMethod.StringCompare; //是否使用Size比较
        }

        public SortMethod CompareMethod { set; get; }

        /// 获取或设置按照哪一列排序.
        public int SortColumn { set; get; }

        /// 获取或设置排序方式.
        public SortOrder Order { set; get; }

        /// <summary>
        ///     比较
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            var lstX = (ListViewItem)x;
            var lstY = (ListViewItem)y;
            var rtnCompare = 0;
            switch (CompareMethod)
            {
                case SortMethod.StringCompare:
                    rtnCompare = _objectCompare.Compare(lstX.SubItems[SortColumn].Text,
                        lstY.SubItems[SortColumn].Text);
                    break;
                case SortMethod.SizeCompare:
                    rtnCompare =
                        (int)
                            (Utility.ReconvSize(lstX.SubItems[SortColumn].Text) -
                             Utility.ReconvSize(lstY.SubItems[SortColumn].Text));
                    break;
                case SortMethod.NumberCompare:

                    if (lstX.SubItems[SortColumn].Text.Equals(lstY.SubItems[SortColumn].Text))
                    {
                        //直接比较字符串
                        rtnCompare = 0;
                    }
                    else
                    {
                        //当两个数字相减小于1时，(int)的强制转换会将结果变成0，所以不能使用减法来获得Ret。。。
                        if (Convert.ToDouble(lstX.SubItems[SortColumn].Text) >
                            Convert.ToDouble(lstY.SubItems[SortColumn].Text))
                        {
                            rtnCompare = 1;
                        }
                        else
                        {
                            rtnCompare = -1;
                        }
                    }
                    break;
            }
            if (Order == SortOrder.Descending)
            {
                rtnCompare = rtnCompare * -1;
            }
            return rtnCompare;
        }
    }
}