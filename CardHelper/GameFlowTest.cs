using System;
using System.Windows.Forms;

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
            GameId = Card.Server.GameServer.CreateNewGame();
            Card.Server.GameServer.SetCardStack(GameId, true, HelperUtility.GetCardDeck());
            Card.Server.GameServer.SetCardStack(GameId, false, HelperUtility.GetCardDeck());
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
        }
    }
}
