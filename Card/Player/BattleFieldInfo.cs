using System;

namespace Card.Player
{
    /// <summary>
    /// 战场信息（炉石专用）
    /// </summary>
    public class BattleFieldInfo
    {
        /// <summary>
        /// 最多7个随从的位置
        /// </summary>
        public const int MaxFollowerCount = 7;
        /// <summary>
        /// 当前随从数量
        /// </summary>
        public int FollowerCount = 0;
        /// <summary>
        /// 随从位置
        /// </summary>
        ///<remarks>
        ///7个位置的注意事项
        ///[0][1][2][3][4][5][6]
        ///有些卡牌涉及到对于左右位置的加成问题，所以，位置是很敏感的
        ///</remarks>
        public FollowerCard[] BattleFollowers = new FollowerCard[MaxFollowerCount];
        /// <summary>
        /// 卡牌入战场
        /// </summary>
        /// <param name="Position">从1开始的位置</param>
        /// <param name="Follower">随从</param>
        /// <remarks>不涉及到战吼等计算</remarks>
        public void PutToBattle(int Position, FollowerCard Follower)
        {
            //战场满了
            if (FollowerCount == MaxFollowerCount) return;
            //无效的位置
            if ((Position < 1) || (Position > FollowerCount + 1) || Position > MaxFollowerCount) return;
            //插入操作
            if (BattleFollowers[Position - 1] == null)
            {
                //添加到最右边
                BattleFollowers[Position - 1] = Follower;
            }
            else
            {
                //Position右边的全体移位，腾出地方
                for (int i = MaxFollowerCount - 1; i >= Position; i--)
                {
                    BattleFollowers[i] = BattleFollowers[i - 1];
                }
                BattleFollowers[Position - 1] = Follower;
            }
            FollowerCount++;
        }
    }
}
