using Card;
using Card.Effect;
using Card.Server;
using System;
using System.Collections.Generic;

namespace Card.Player
{
    /// <summary>
    /// 游戏管理
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// 游戏玩家名称
        /// </summary>
        public String PlayerNickName = "DARUMA";
        /// <summary>
        /// 是否主机
        /// </summary>
        public Boolean IsHost;
        /// <summary>
        /// 是否为先手
        /// </summary>
        public Boolean IsFirst;
        /// <summary>
        /// 游戏编号
        /// </summary>
        public int GameId;
        /// <summary>
        /// 是否为我的回合
        /// </summary>
        public Boolean IsMyTurn;
        /// <summary>
        /// 获得目标对象
        /// </summary>
        public Card.CardUtility.deleteGetTargetPosition GetSelectTarget;
        /// <summary>
        /// 抉择卡牌
        /// </summary>
        public Card.CardUtility.delegatePickEffect PickEffect;
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //抽牌的具体方法
            CardUtility.DrawCard += DrawCardAtServer;
            //图片请求
            CardUtility.GetCardImage += GetCardImageAtServer;
            //属性
            var HandCard = Card.Server.ClientUtlity.DrawCard(GameId.ToString(GameServer.GameIdFormat), IsFirst, IsFirst ? 3 : 4);
            //DEBUG
            HandCard.Add("A000075");
            HandCard.Add("A000066");
            //DEBUG
            if (!IsFirst) HandCard.Add(Card.CardUtility.SN幸运币);
            MySelf.handCards = HandCard;
            MySelf.RoleInfo.HandCardCount = HandCard.Count;
            if (IsFirst)
            {
                MySelf.RoleInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 3;
                AgainstInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 4;
            }
            else
            {
                MySelf.RoleInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 4;
                AgainstInfo.RemainCardDeckCount = Card.Player.CardDeck.MaxCards - 3;
            }
        }
        /// <summary>
        /// 本方情报
        /// </summary>
        public PlayerDetailInfo MySelf = new PlayerDetailInfo();
        /// <summary>
        /// 对方情报
        /// </summary>
        public PlayerBasicInfo AgainstInfo = new PlayerBasicInfo();
        /// <summary>
        /// 新的回合
        /// </summary>
        public void NewTurn()
        {
            if (IsMyTurn)
            {
                //魔法水晶的增加
                MySelf.RoleInfo.crystal.NewTurn();
                //手牌
                MySelf.handCards.AddRange(Card.Server.ClientUtlity.DrawCard(GameId.ToString(GameServer.GameIdFormat), IsFirst, 1));
                MySelf.RoleInfo.HandCardCount++;
                MySelf.RoleInfo.RemainCardDeckCount--;
            }
            else
            {
                AgainstInfo.crystal.NewTurn();
                AgainstInfo.HandCardCount++;
                AgainstInfo.RemainCardDeckCount--;
            }
        }
        /// <summary>
        /// 使用法术
        /// </summary>
        /// <param name="CardSn"></param>
        public List<String> UseAbility(String CardSn)
        {
            List<String> Result = new List<string>();
            Card.AbilityCard card = (Card.AbilityCard)CardUtility.GetCardInfoBySN(CardSn);
            Boolean IsPickFirstEffect = false;
            if (card.CardAbility.IsNeedSelect())
            {
                IsPickFirstEffect = PickEffect(card.CardAbility.FirstAbilityDefine.Description,card.CardAbility.SecondAbilityDefine.Description);
            }
            var SingleEffectList = card.CardAbility.GetSingleEffectList(IsPickFirstEffect);
            foreach (var singleEff in SingleEffectList)
            {
                Card.CardUtility.TargetPosition Pos = new CardUtility.TargetPosition();
                if (singleEff.IsNeedSelectTarget())
                {
                    Pos = GetSelectTarget();
                }
                Result.AddRange(EffectDefine.RunSingleEffect(singleEff, this,Pos));
            }
            return Result;
        }
        /// <summary>
        /// 抽牌（服务器方法）
        /// </summary>
        /// <returns></returns>
        public List<String> DrawCardAtServer(Boolean IsFirst, int Count)
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
