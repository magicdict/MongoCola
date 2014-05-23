using System;

namespace Card.Client
{
    public class Crystal
    {
        /// <summary>
        /// 最大水晶数
        /// </summary>
        public const int MaxPoint = 10;
        /// <summary>
        /// 当前满值水晶数
        /// </summary>
        public int CurrentFullPoint = 0;
        /// <summary>
        /// 当前可用水晶数
        /// </summary>
        public int CurrentRemainPoint = 0;
        /// <summary>
        /// 新的回合
        /// </summary>
        public void NewTurn() { 
            AddFullPoint();
            CurrentRemainPoint = CurrentFullPoint;
        }
        /// <summary>
        /// 增加一个空水晶
        /// </summary>
        /// <remarks>野性成长</remarks>
        public void AddFullPoint() { 
            if (CurrentFullPoint < MaxPoint) CurrentFullPoint++;
        }
        /// <summary>
        /// 增加一个可用水晶
        /// </summary>
        public void AddCurrentPoint()
        {
            if (CurrentRemainPoint < MaxPoint) CurrentRemainPoint++;
        }
        /// <summary>
        /// 减少一个可用水晶
        /// </summary>
        public void ReduceCurrentPoint()
        {
            if (CurrentRemainPoint > 0) CurrentRemainPoint--;
        }
        /// <summary>
        /// 减少一个空水晶
        /// </summary>
        public void ReduceFullPoint()
        {
            if (CurrentFullPoint > 0) CurrentFullPoint--;
        }
    }
}
