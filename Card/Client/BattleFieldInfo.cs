using System;
using System.Collections.Generic;

namespace Card.Client
{
    /// <summary>
    /// 战场信息（炉石专用）
    /// </summary>
    public class BattleFieldInfo
    {
        /// <summary>
        /// 最多7个随从的位置
        /// </summary>
        public const int MaxMinionCount = 7;
        /// <summary>
        /// 当前随从数量
        /// </summary>
        public int MinionCount = 0;
        /// <summary>
        /// 随从位置
        /// </summary>
        ///<remarks>
        ///7个位置的注意事项
        ///[0][1][2][3][4][5][6]
        ///有些卡牌涉及到对于左右位置的加成问题，所以，位置是很敏感的
        ///</remarks>
        public MinionCard[] BattleMinions = new MinionCard[MaxMinionCount];
        /// <summary>
        /// 卡牌入战场
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="CardSn"></param>
        public void PutToBattle(int Position, String CardSn)
        {
            Card.CardBasicInfo card = Card.CardUtility.GetCardInfoBySN(CardSn);
            PutToBattle(Position, (MinionCard)card);
        }
        /// <summary>
        /// 卡牌入战场
        /// </summary>
        /// <param name="Position">从1开始的位置</param>
        /// <param name="Minion">随从</param>
        /// <remarks>不涉及到战吼等计算</remarks>
        public void PutToBattle(int Position, MinionCard Minion)
        {
            //战场满了
            if (MinionCount == MaxMinionCount) return;
            //无效的位置
            if ((Position < 1) || (Position > MinionCount + 1) || Position > MaxMinionCount) return;
            //插入操作
            if (BattleMinions[Position - 1] == null)
            {
                //添加到最右边
                BattleMinions[Position - 1] = Minion;
            }
            else
            {
                //Position右边的全体移位，腾出地方
                for (int i = MaxMinionCount - 1; i >= Position; i--)
                {
                    BattleMinions[i] = BattleMinions[i - 1];
                }
                BattleMinions[Position - 1] = Minion;
            }
            MinionCount++;
        }
        /// <summary>
        /// 从战场移除单位
        /// </summary>
        /// <param name="Position">从1开始的位置</param>
        /// <remarks>不涉及到亡语等计算</remarks>
        public void GetOutFromBattle(int Position)
        {
            for (int i = Position - 1; i < MaxMinionCount - 1; i++)
            {
                BattleMinions[i] = BattleMinions[i + 1];
            }
            BattleMinions[MaxMinionCount - 1] = null;
        }
        /// <summary>
        /// Buff的设置
        /// </summary>
        public void ResetBuff()
        {
            //去除所有光环效果
            for (int i = 0; i < BattleMinions.Length; i++)
            {
                if (BattleMinions[i] != null) BattleMinions[i].受战地效果.Clear();
            }
            //设置光环效果
            for (int i = 0; i < BattleMinions.Length; i++)
            {
                var minion = BattleMinions[i];
                if (minion != null)
                {
                    if (!String.IsNullOrEmpty(minion.光环效果.BuffInfo))
                    {
                        switch (minion.光环效果.EffectType)
                        {
                            case MinionCard.光环类型.增加攻防:
                                switch (minion.光环效果.Scope)
                                {
                                    case MinionCard.光环范围.随从全体:
                                        for (int j = 0; j < BattleMinions.Length; j++)
                                        {
                                            if (BattleMinions[j] != null) BattleMinions[j].受战地效果.Add(minion.光环效果);
                                        }
                                        break;
                                    case MinionCard.光环范围.相邻随从:
                                        break;
                                    case MinionCard.光环范围.英雄:
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case MinionCard.光环类型.减少施法成本:
                                break;
                            case MinionCard.光环类型.增加法术效果:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 去除死去随从
        /// </summary>
        public void ClearDead()
        {
            var CloneMinions = new MinionCard[BattleFieldInfo.MaxMinionCount];
            int ALive = 0;
            for (int i = 0; i < BattleFieldInfo.MaxMinionCount; i++)
            {
                if (BattleMinions[i] != null && BattleMinions[i].IsLive())
                {
                    CloneMinions[ALive] = BattleMinions[i];
                    ALive++;
                }
            }
            BattleMinions = CloneMinions;
            MinionCount = ALive;
        }
    }
}
