using Card;
using Card.Player;
using Card.Server;
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
        /// 游戏玩家名称
        /// </summary>
        public static String PlayerNickName = "DARUMA";
        /// <summary>
        /// 是否主机
        /// </summary>
        public static Boolean IsHost;
        /// <summary>
        /// 是否为先手
        /// </summary>
        public static Boolean IsFirst;
        /// <summary>
        /// 游戏编号
        /// </summary>
        public static int GameId;
        /// <summary>
        /// 是否为我的回合
        /// </summary>
        public static Boolean IsMyTurn;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //抽牌的具体方法
            CardUtility.DrawCard += DrawCardAtServer;
            //图片请求
            CardUtility.GetCardImage += GetCardImageAtServer;
            //属性
            var HandCard = Card.Server.ClientUtlity.DrawCard(GameId.ToString(GameServer.GameIdFormat), GameManager.IsFirst, GameManager.IsFirst ? 3 : 4);
            if (!IsFirst) HandCard.Add(Card.CardUtility.SN幸运币);
            SelfInfo.handCards = HandCard;
            SelfInfo.role.HandCardCount = HandCard.Count;
            if (IsFirst)
            {
                SelfInfo.role.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 3;
                AgainstInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 4;
            }
            else
            {
                SelfInfo.role.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 4;
                AgainstInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 3;
            }
        }
        /// <summary>
        /// 本方情报
        /// </summary>
        public static PlayerDetailInfo SelfInfo = new PlayerDetailInfo();
        /// <summary>
        /// 对方情报
        /// </summary>
        public static PlayerBasicInfo AgainstInfo = new PlayerBasicInfo();
        /// <summary>
        /// 新的回合
        /// </summary>
        public static void NewTurn(){
            if (IsMyTurn)
            {
                //魔法水晶的增加
                SelfInfo.role.crystal.NewTurn();
                //手牌
                SelfInfo.handCards.AddRange(Card.Server.ClientUtlity.DrawCard(GameId.ToString(GameServer.GameIdFormat), IsFirst, 1));
                SelfInfo.role.HandCardCount++;
                SelfInfo.role.RemainCardDeckCount--;
            }
            else {
                AgainstInfo.crystal.NewTurn();
                AgainstInfo.HandCardCount++;
                AgainstInfo.RemainCardDeckCount--;
            }
        }
        /// <summary>
        /// 抽牌（服务器方法）
        /// </summary>
        /// <returns></returns>
        public static List<String> DrawCardAtServer(Boolean IsFirst, int Count)
        {
            //向服务器提出请求，获得牌
            return GameServer.DrawCard(GameId, IsFirst, Count);
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
