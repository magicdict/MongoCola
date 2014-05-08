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
        public static List<Card.CardBasicInfo> DrawCardAtServer(Boolean IsFirst,int Count){
            return null;
        }
    }
}
