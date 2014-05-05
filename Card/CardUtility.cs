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
        /// 稀有度
        /// </summary>
        public static string[] RareNameDic;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //初始化稀有度
            RareNameDic = new string[] { "白色", "绿色", "蓝色", "紫色", "橙色" };
        }
        /// <summary>
        /// 获得稀有度表示名称
        /// </summary>
        /// <remarks>
        /// 通过设置SystemManager.RareNameDic自定义稀有度表示名称
        /// </remarks>
        /// <returns></returns>
        public static String GetRareName(Byte Rare)
        {
            if (CardUtility.RareNameDic.Length - 1 < Rare)
            {
                return "<Err>";
            }
            else
            {
                return CardUtility.RareNameDic[Rare];
            }
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
