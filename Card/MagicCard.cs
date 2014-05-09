using Card.Effect;
using System;

namespace Card
{
    /// <summary>
    /// 魔法卡牌
    /// </summary>
    [Serializable]
    public class MagicCard : CardBasicInfo
    {
        /// <summary>
        /// 多个效果的连接方式
        /// </summary>
        public enum EffectJoinType
        {
            /// <summary>
            /// 两个效果是并且的关系：副作用
            /// 例如：造成4点伤害，随机弃一张牌。
            /// </summary>
            AND,
            /// <summary>
            /// 两个效果是或者的关系：抉择
            /// 例如：抉择: 对一个随从造成3点伤害；或者造成1点伤害并抽一张牌。
            /// </summary>
            OR,
            /// <summary>
            /// 无需
            /// </summary>
            None
        }
        /// <summary>
        /// 第一定义
        /// </summary>
        public EffectDefine FirstMagicDefine = new EffectDefine();
        /// <summary>
        /// 第二定义
        /// </summary>
        public EffectDefine SecondMagicDefine = new EffectDefine();
        /// <summary>
        /// 第一定义 和 第二定义 的连接方式
        /// </summary>
        public EffectJoinType JoinType = EffectJoinType.None;
        /// <summary>
        /// 施法
        /// </summary>
        public void RunMagic() { 
            
        }
    }
}
