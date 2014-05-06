
namespace Card
{
    /// <summary>
    /// 魔法卡牌
    /// </summary>
    public class MagicCard:CardBasicInfo
    {
        /// <summary>
        /// 攻击点数(标准)
        /// </summary>
        public int StandardAttackPoint = -1;
        /// <summary>
        /// 攻击点数(实际)
        /// </summary>
        public int ActualAttackPoint = -1;
        /// <summary>
        /// 攻击回数
        /// </summary>
        public int AttackCount = -1;
        /// <summary>
        /// 攻击模式
        /// </summary>
        public AttackModeEnum AttackMode = AttackModeEnum.指定;
        /// <summary>
        /// 攻击模式
        /// </summary>
        public enum AttackModeEnum
        { 
            /// <summary>
            /// 随机攻击敌方对象
            /// </summary>
            随机,
            /// <summary>
            /// 攻击敌方全体
            /// </summary>
            全体,
            /// <summary>
            /// 攻击指定目标
            /// </summary>
            指定
        }
    }
}
