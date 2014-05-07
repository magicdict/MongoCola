using System;
using System.Drawing;
namespace Card
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public static class CardUtility
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {

        }
        /// <summary>
        /// 职业
        /// </summary>
        public enum OccupationEnum
        {
            猎人,
            盗贼,
            中立,
            德鲁伊,
            术士,
            圣骑士,
            萨满,
            牧师,
            法师,
            战士,
        }

        /// <summary>
        /// 目标选择模式
        /// </summary>
        public enum TargetSelectModeEnum
        {
            /// <summary>
            /// 随机
            /// </summary>
            随机,
            /// <summary>
            /// 全体
            /// </summary>
            全体,
            /// <summary>
            /// 指定
            /// </summary>
            指定,
        }
        /// <summary>
        /// 目标选择方向
        /// </summary>
        public enum TargetSelectDirectEnum
        {
            /// <summary>
            /// 本方
            /// </summary>
            本方,
            /// <summary>
            /// 对方
            /// </summary>
            对方,
            /// <summary>
            /// 无限制
            /// </summary>
            无限制
        }
        /// <summary>
        /// 目标选择角色
        /// </summary>
        public enum TargetSelectRoleEnum
        {
            /// <summary>
            /// 随从
            /// </summary>
            随从,
            /// <summary>
            /// 英雄
            /// </summary>
            英雄,
            /// <summary>
            /// 全体
            /// </summary>
            全体
        }

        /// <summary>
        /// 随机打算数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] RandomSort<T>(T[] array)
        {
            int len = array.Length;
            System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
            T[] ret = new T[len];
            Random rand = new Random();
            int i = 0;
            while (list.Count < len)
            {
                int iter = rand.Next(0, len);
                if (!list.Contains(iter))
                {
                    list.Add(iter);
                    ret[i] = array[iter];
                    i++;
                }
            }
            return ret;
        }

        /// <summary>
        /// 获得卡牌的图案（需要外部程序具体实现）
        /// </summary>
        public static delegateGetImageByString GetCardImage;

        #region"委托"

        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        public delegate Image delegateGetImageByString(String ImagePath);

        #endregion
    }
}
