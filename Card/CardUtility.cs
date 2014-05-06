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
            /// <summary>
            /// 本方英雄
            /// </summary>
            本方英雄,
            /// <summary>
            /// 敌方英雄
            /// </summary>
            敌方英雄
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
