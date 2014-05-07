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
        /// 最大生命值
        /// </summary>
        public const int MaxHealthPoint = 30;
        /// <summary>
        /// 是否为先手
        /// </summary>
        public Boolean IsFirst;
        /// <summary>
        /// 是否为冰冻状态
        /// </summary>
        public Boolean Is冰冻Status = false;
        /// <summary>
        /// 护盾点数
        /// </summary>
        public int Sheild = 0;
        /// <summary>
        /// 生命力
        /// </summary>
        public int HealthPoint = 30;
        /// <summary>
        /// 
        /// </summary>
        public Card.Crystal crystal = new Crystal();
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
