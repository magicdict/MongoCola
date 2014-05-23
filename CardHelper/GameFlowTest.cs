using Card.Client;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace CardHelper
{
    public partial class GameFlowTest : Form
    {
        public GameFlowTest()
        {
            InitializeComponent();
        }
        /// <summary>
        /// GameId
        /// </summary>
        int GameId;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitGame_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init(@"C:\MagicMongoDBTool\CardHelper\CardXML");
            GameId = Card.Server.GameServer.CreateNewGame("NickName");
            Card.Server.GameServer.SetCardStack(GameId, true, CardDeck.GetRandomCardStack(0));
            Card.Server.GameServer.SetCardStack(GameId, false, CardDeck.GetRandomCardStack(1));
            btnInitGame.Enabled = false;
            btn给先后手抽牌.Enabled = true;
        }
        /// <summary>
        /// 给先后手抽牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn给先后手抽牌_Click(object sender, EventArgs e)
        {
            var HandA = Card.Server.GameServer.DrawCard(GameId, true, 3);
            var HandB = Card.Server.GameServer.DrawCard(GameId, false, 4);
            foreach (String item in HandA)
            {
                Debug.WriteLine("A的手牌：" + Card.CardUtility.GetCardNameBySN(item));
            }
            foreach (String item in HandB)
            {
                Debug.WriteLine("B的手牌：" + Card.CardUtility.GetCardNameBySN(item));
            }
            btn给先后手抽牌.Enabled = false;
        }
    }
}
