
namespace Card
{
    /// <summary>
    /// 武器卡牌
    /// </summary>
    public class WeaponCard : CardBasicInfo
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
        /// 耐久（标准）
        /// </summary>
        public int StandardHealthPoint = 1;
        /// <summary>
        /// 耐久（实际）
        /// </summary>
        public int ActualHealthPoint = 1;
    }
}
