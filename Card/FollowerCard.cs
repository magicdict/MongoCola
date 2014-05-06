using System;

namespace Card
{
    /// <summary>
    /// 随从卡牌
    /// </summary>
    public class FollowerCard : CardBasicInfo
    {
        #region"属性"
        /// <summary>
        /// 攻击力（标准）
        /// </summary>
        public int StandardAttackPoint = -1;
        /// <summary>
        /// 攻击力（实际）
        /// </summary>
        public int ActualAttackPoint = -1;
        /// <summary>
        /// 体力（标准）
        /// </summary>
        public int StandardHealthPoint = -1;
        /// <summary>
        /// 体力（实际）
        /// </summary>
        public int ActualHealthPoint = -1;
        /// <summary>
        /// 嘲讽(标准)
        /// </summary>
        public Boolean Standard嘲讽 = false;
        /// <summary>
        /// 嘲讽(实际)
        /// </summary>
        public Boolean Actual嘲讽 = false;
        /// <summary>
        /// 冲锋(标准)
        /// </summary>
        public Boolean Standard冲锋 = false;
        /// <summary>
        /// 冲锋(实际)
        /// </summary>
        public Boolean Actual冲锋 = false;
        /// <summary>
        /// 是否能潜行
        /// </summary>
        public Boolean Can潜行 = false;
        /// <summary>
        /// 是否为潜行状态
        /// </summary>
        public Boolean Is潜行Status = false;
        /// <summary>
        /// 特别效果
        /// </summary>
        public SpecialEnum CardSpecial = SpecialEnum.None;
        /// <summary>
        /// 特别效果
        /// </summary>
        public enum SpecialEnum
        {
            /// <summary>
            /// 没有
            /// </summary>
            None,
            /// <summary>
            /// 亡语
            /// </summary>
            DeathMessage,
            /// <summary>
            /// 战吼
            /// </summary>
            FightMessage,
            /// <summary>
            /// 战地效果
            /// </summary>
            BattleEffect,
            /// <summary>
            /// 刺激（每次）
            /// 例如：受到伤害后则增加供给力
            /// </summary>
            AfterHurt
        }
        #endregion

        #region"亡语"
        /// <summary>
        /// 亡语类型
        /// </summary>
        enum DeathMessage
        {

        }
        #endregion

        #region"战吼"
        /// <summary>
        /// 战吼类型
        /// </summary>
        enum FightMessage
        {

        }
        #endregion

        #region"战场效果"
        enum BattleEffect {
            /// <summary>
            /// 减少魔法成本
            /// </summary>
            MagicCostDown
        }
        #endregion
    }
}
