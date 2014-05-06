using System;

namespace Card
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
        public int CurrentFullPoint;
        /// <summary>
        /// 当前的水晶数
        /// </summary>
        public int CurrentRemainPoint;
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
    }
}
