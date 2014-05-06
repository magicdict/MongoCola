using System;
using System.Collections.Generic;

namespace Card
{
    /// <summary>
    /// 战场
    /// </summary>
    public class RoleInfo
    {
        /// <summary>
        /// 是否为先手
        /// </summary>
        public Boolean IsFirst;
        /// <summary>
        /// 满值的水晶数
        /// </summary>
        public int FullPoint;
        /// <summary>
        /// 当前的水晶数
        /// </summary>
        public int RemainPoint;
        /// <summary>
        /// 生命力
        /// </summary>
        public int HealthPoint =30;
        /// <summary>
        /// 武器
        /// </summary>
        public Card.WeaponCard Weapon;
        /// <summary>
        /// 手牌
        /// </summary>
        public List<String> handCards = new List<string>();
        /// <summary>
        /// 牌堆
        /// </summary>
        public CardStock cardStock = new CardStock();
        /// <summary>
        /// 战场信息
        /// </summary>
        public BattleFieldInfo myBattleField = new BattleFieldInfo();
    }
}
