using Card;
using System;
using System.Collections.Generic;

namespace 炉边传说
{
    /// <summary>
    /// 游戏管理
    /// </summary>
    public static class GameManager
    {
        /// <summary>
        /// 是否为先手
        /// </summary>
        public static Boolean IsFirst;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init() {
            //抽牌的具体方法
            CardUtility.DrawCard += DrawCardAtServer;
            //图片请求
            CardUtility.GetCardImage += GetCardImageAtServer;
        }
        /// <summary>
        /// 本方情报
        /// </summary>
        public static RoleDetailInfo SelfInfo = new RoleDetailInfo();
        /// <summary>
        /// 对方情报
        /// </summary>
        public static RoleBasicInfo AgainstInfo = new RoleBasicInfo();
        /// <summary>
        /// 抽牌（服务器方法）
        /// </summary>
        /// <returns></returns>
        public static List<String> DrawCardAtServer(Boolean IsFirst, int Count)
        {
            //向服务器提出请求，获得牌
            return GameStatus.DrawCard(IsFirst,Count);
        }
        /// <summary>
        /// 获得图片（服务器方法）
        /// </summary>
        /// <param name="ImageKey"></param>
        /// <returns></returns>
        private static System.Drawing.Image GetCardImageAtServer(string ImageKey)
        {
            throw new NotImplementedException();
        }
    }
}
