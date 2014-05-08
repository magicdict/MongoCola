using System;
using System.Collections.Generic;

namespace Card.Player
{
    public class CardDeck
    {
        /// <summary>
        /// 最大牌数
        /// </summary>
        public const int MaxCards = 30;
        /// <summary>
        /// 牌堆(存放牌的序列号)
        /// </summary>
        private Stack<String> CardList = new Stack<string>();
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="mCardList"></param>
        public void Init(Stack<String> mCardList,int Seed)
        {
            //设置牌堆
            CardList = mCardList;
            //洗牌
            Suffle(Seed);
        }
        /// <summary>
        /// 洗牌
        /// </summary>
        public void Suffle(int Seed)
        {
            var newList = CardUtility.RandomSort<String>(CardList.ToArray(), Seed);
            CardList.Clear();
            foreach (var item in newList)
            {
                CardList.Push(item);
            }
        }
        /// <summary>
        /// 抽卡
        /// </summary>
        /// <param name="CardCount"></param>
        /// <returns></returns>
        public List<String> DrawCard(int CardCount)
        {
            List<String> newList = new List<String>();
            for (int i = 0; i < CardCount; i++)
            {
                if (CardList.Count == 0) break;
                newList.Add(CardList.Pop());
            }
            return newList;
        }
    }
}
