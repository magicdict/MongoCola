using Card.Effect;
using System;
using System.Collections.Generic;

namespace Card
{
    /// <summary>
    /// 法术卡牌
    /// </summary>
    [Serializable]
    public class AbilityCard : CardBasicInfo
    {
        /// <summary>
        /// 法术
        /// </summary>
        public Ability CardAbility = new Ability();
    }
}
