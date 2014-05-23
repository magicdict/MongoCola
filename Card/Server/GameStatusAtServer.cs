using Card;
using System;
using System.Collections.Generic;
using Card.Client;

namespace Card.Server
{

    ///原本应该是服务器方法，但是为了开始测试，暂时作为客户端方法
    ///这样的话，就可以暂时不用考虑网络通讯了
    /// <summary>
    /// 游戏状态(如果考虑到同时有多个游戏，必须为非静态)
    /// </summary>
    ///<remarks>
    /// 最低要求：双方牌堆情况
    /// （棋牌类游戏难以作弊，无需大量验证）
    /// </remarks>
    public class GameStatusAtServer
    {
        /// <summary>
        /// 游戏编号
        /// </summary>
        public int GameId = 1;
        /// <summary>
        /// 主机玩家名称
        /// </summary>
        public String HostNickName = String.Empty;
        /// <summary>
        /// 非主机玩家名称
        /// </summary>
        public String GuestNickName = String.Empty;
        /// <summary>
        /// 主机作为先手
        /// </summary>
        public Boolean HostAsFirst = false;
        /// <summary>
        /// 当前是否为先手正在的回合
        /// </summary>
        public Boolean IsFirstNowTurn = false;
        /// <summary>
        /// 先手牌堆
        /// </summary>
        private CardDeck FirstCardDeck = new CardDeck();
        /// <summary>
        /// 先手套牌
        /// </summary>
        private Stack<String> FirstCardStack;
        /// <summary>
        /// 后手牌堆
        /// </summary>
        private CardDeck SecondCardDeck = new CardDeck();
        /// <summary>
        /// 后手套牌
        /// </summary>
        private Stack<String> SecondCardStack;
        /// <summary>
        /// 行动集
        /// </summary>
        private List<String> ActionInfo = new List<string>();
        /// <summary>
        /// 建立新游戏
        /// </summary>
        /// <param name="newGameId"></param>
        public GameStatusAtServer(int newGameId, String hostNickName)
        {
            this.GameId = newGameId;
            this.HostNickName = hostNickName;
            //决定先后手,主机位先手概率为2/1
            HostAsFirst = (GameId % 2 == 0);
        }
        /// <summary>
        /// 设定牌堆
        /// </summary>
        /// <param name="IsHost">主机</param>
        /// <param name="cards">套牌</param>
        public CardUtility.CommandResult SetCardStack(Boolean IsHost, Stack<String> cards)
        {
            if ((IsHost && HostAsFirst) || (!IsHost && !HostAsFirst))
            {
                FirstCardStack = cards;
            }
            else
            {
                SecondCardStack = cards;
            }
            //如果非主机的套牌也上传的话，可以初始化了
            if (!IsHost)
            {
                Init();
            }
            return CardUtility.CommandResult.正常;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="FirstCardStack"></param>
        /// <param name="SecondCardStack"></param>
        private void Init()
        {
            //洗牌处理
            //如果以时间随机，则两者洗牌都一样
            //前者默认，后者用GameID随机
            FirstCardDeck.Init(FirstCardStack, 0);
            SecondCardDeck.Init(SecondCardStack, GameId);
        }
        /// <summary>
        /// 抽牌
        /// </summary>
        /// <param name="IsFirst"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<String> DrawCard(Boolean IsFirst, int Count)
        {
            var targetStock = IsFirst ? FirstCardDeck : SecondCardDeck;
            return targetStock.DrawCard(Count);
        }
        /// <summary>
        /// 追加指令
        /// </summary>
        /// <param name="Action"></param>
        public void WriteAction(String Action)
        {
            ActionInfo.Add(Action);
            //如果是回合结束的指令的时候，翻转是否是先手回合的标志
            if (Action == ActionCode.strEndTurn) IsFirstNowTurn = !IsFirstNowTurn;
        }
        /// <summary>
        /// 读取指令
        /// </summary>
        public String ReadAction()
        {
            String lstAction = String.Empty;
            foreach (var item in ActionInfo)
            {
                lstAction += item + "|";
            }
            if (!String.IsNullOrEmpty(lstAction)) lstAction = lstAction.TrimEnd("|".ToCharArray());
            ActionInfo.Clear();
            return lstAction;
        }
    }
}
