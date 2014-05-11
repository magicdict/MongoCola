using System;
using System.Windows.Forms;
using System.Threading;
namespace 炉边传说
{
    public partial class frmStartGame : Form
    {
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
            GameManager.IsHost = true;
            String GameId = Card.Server.ClientUtlity.CreateGame(GameManager.PlayerNickName);
            GameManager.GameId = int.Parse(GameId);
            btnJoinGame.Enabled = false;
            btnRefresh.Enabled = false;
            while (!Card.Server.ClientUtlity.IsGameStart(GameId))
            {
                Thread.Sleep(3000);
            }
            GameManager.IsFirst = Card.Server.ClientUtlity.IsFirst(GameManager.GameId.ToString("D5"), GameManager.IsHost);
            new BattleField().ShowDialog();
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
            GameManager.IsHost = false;
            if (lstWaitGuest.SelectedItems.Count != 1) return;
            var strWait = lstWaitGuest.SelectedItem.ToString();
            String GameId = Card.Server.ClientUtlity.JoinGame(int.Parse(strWait.Substring(0, strWait.IndexOf("("))), GameManager.PlayerNickName);
            GameManager.GameId = int.Parse(GameId);
            GameManager.IsFirst = Card.Server.ClientUtlity.IsFirst(GameManager.GameId.ToString("D5"), GameManager.IsHost);
            new BattleField().ShowDialog();
        }
    }
}
