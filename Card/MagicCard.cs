using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public int StandardAttackPoint = 1;
        /// <summary>
        /// 攻击点数(实际)
        /// </summary>
        public int ActualAttackPoint = 1;
        /// <summary>
        /// 攻击回数
        /// </summary>
        public int AttackCount = 1;
    }
}
