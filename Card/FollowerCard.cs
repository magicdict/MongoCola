using System;

namespace Card
{
    /// <summary>
    /// 随从卡牌
    /// </summary>
    public class FollowerCard : CardBasicInfo
    {
        /// <summary>
        /// 攻击力（标准）
        /// </summary>
        public int StandardAttackPoint = 1;
        /// <summary>
        /// 攻击力（实际）
        /// </summary>
        public int ActualAttackPoint = 1;
        /// <summary>
        /// 体力（标准）
        /// </summary>
        public int StandardHealthPoint = 1;
        /// <summary>
        /// 体力（实际）
        /// </summary>
        public int ActualHealthPoint = 1;
        /// <summary>
        /// 嘲讽(标准)
        /// </summary>
        public Boolean Standard嘲讽 = true;
        /// <summary>
        /// 嘲讽(实际)
        /// </summary>
        public Boolean Actual嘲讽 = true;
        /// <summary>
        /// 冲锋(标准)
        /// </summary>
        public Boolean Standard冲锋 = true;
        /// <summary>
        /// 冲锋(实际)
        /// </summary>
        public Boolean Actual冲锋 = true;
    }
}
