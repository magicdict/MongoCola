using Card.Effect;
using System;

namespace Card
{
    /// <summary>
    /// 魔法卡牌
    /// </summary>
    [Serializable]
    public class AbilityCard : CardBasicInfo
    {
        /// <summary>
        /// 第一定义
        /// </summary>
        public EffectDefine FirstAbilityDefine = new EffectDefine();
        /// <summary>
        /// 第二定义
        /// </summary>
        public EffectDefine SecondAbilityDefine = new EffectDefine();
        /// <summary>
        /// 第一定义 和 第二定义 的连接方式
        /// </summary>
        public Card.CardUtility.EffectJoinType JoinType = Card.CardUtility.EffectJoinType.None;
        /// <summary>
        /// 施法
        /// </summary>
        /// <param name="CardSn"></param>
        /// <param name="getTarget"></param>
        /// <returns>效果</returns>
        public static String[] RunAbility(String CardSn, Card.CardUtility.deleteGetTargetPosition getTarget)
        {
            return new string[] { };
        }
    }
}
