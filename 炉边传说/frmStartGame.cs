using System;
using System.Windows.Forms;
using System.Threading;
using Card.Server;
using Card.Client;
namespace 炉边传说
{
    public partial class frmStartGame : Form
    {
        GameManager game = new GameManager();
        public frmStartGame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始游戏的请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            //新建游戏的时候，已经决定游戏的先后手
            game.IsHost = true;
            String GameId = Card.Server.ClientUtlity.CreateGame(game.PlayerNickName);
            game.GameId = int.Parse(GameId);
            btnJoinGame.Enabled = false;
            btnRefresh.Enabled = false;
            btnCreateGame.Enabled = false;
            while (!Card.Server.ClientUtlity.IsGameStart(GameId))
            {
                Thread.Sleep(3000);
            }
            game.IsFirst = Card.Server.ClientUtlity.IsFirst(game.GameId.ToString(GameServer.GameIdFormat), game.IsHost);
            game.Init();
            var t = new BattleField();
            t.game = game;
            t.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstWaitGuest.Items.Clear();
            String WaitGame = Card.Server.ClientUtlity.GetWatiGameList();
            String[] WaitGameArray = WaitGame.Split("|".ToCharArray());
            for (int i = 0; i < WaitGameArray.Length; i++)
            {
                lstWaitGuest.Items.Add(WaitGameArray[i]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            game.IsHost = false;
            if (lstWaitGuest.SelectedItems.Count != 1) return;
            var strWait = lstWaitGuest.SelectedItem.ToString();
            String GameId = Card.Server.ClientUtlity.JoinGame(int.Parse(strWait.Substring(0, strWait.IndexOf("("))), game.PlayerNickName);
            game.GameId = int.Parse(GameId);
            game.IsFirst = Card.Server.ClientUtlity.IsFirst(game.GameId.ToString(GameServer.GameIdFormat), game.IsHost);
            game.Init();
            var t = new BattleField();
            t.game = game;
            t.ShowDialog();
            this.Close();
        }

        private void frmStartGame_Load(object sender, EventArgs e)
        {
            Card.CardUtility.Init(@"C:\MagicMongoDBTool\CardHelper\CardXML");
        }
    }
}
