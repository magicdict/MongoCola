using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System;
using Card.Server;

namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实例方法
        /// </summary>
        private Thread WaitForThread;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleField_Load(object sender, System.EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            System.Diagnostics.Debug.WriteLine("Loading");
            DisplayMyInfo();
            GameManager.IsMyTurn = GameManager.IsFirst;
            StartNewTurn();
        }
        /// <summary>
        /// 显示我方状态
        /// </summary>
        private void DisplayMyInfo()
        {
            //抽手牌,先手3张，后手4张，后手还有幸运币，不公平啊
            StringBuilder Status = new StringBuilder();
            Status.AppendLine("==============");
            Status.AppendLine("System：");
            Status.AppendLine("GameId：" + GameManager.GameId);
            Status.AppendLine("PlayerNickName：" + GameManager.PlayerNickName);
            Status.AppendLine("IsHost：" + GameManager.IsHost);
            Status.AppendLine("IsFirst：" + GameManager.IsFirst);
            Status.AppendLine("==============");
            Status.AppendLine("Role：");
            Status.AppendLine("Crystal：" + GameManager.SelfInfo.role.crystal.CurrentRemainPoint + "/" + GameManager.SelfInfo.role.crystal.CurrentFullPoint);
            Status.AppendLine("HealthPoint：" + GameManager.SelfInfo.role.HealthPoint);
            Status.AppendLine("RemainCardDeckCount：" + GameManager.SelfInfo.role.RemainCardDeckCount);
            Status.AppendLine("==============");
            lblStatus.Text = Status.ToString();
            lstHandCard.Items.Clear();
            foreach (var handCard in GameManager.SelfInfo.handCards)
            {
                lstHandCard.Items.Add(Card.CardUtility.GetCardNameBySN(handCard) + "[" + handCard + "]");
            }
        }
        /// <summary>
        /// 新的回合
        /// </summary>
        private void StartNewTurn() {
            GameManager.NewTurn();
            if (GameManager.IsMyTurn)
            {
                DisplayMyInfo();
                btnEndTurn.Enabled = true;
                lblEnemyBattle.Text = "You Turn";
            }
            else {
                btnEndTurn.Enabled = false;
                lblEnemyBattle.Text = "Enemy Action";
                WaitForThread = new Thread(new BattleField().WaitFor);
                WaitForThread.Start();
            }
        }
        /// <summary>
        /// 读取
        /// </summary>
        private void WaitFor()
        {
            do
            {
                var Actions = Card.Server.ClientUtlity.ReadAction(GameManager.GameId.ToString(GameServer.GameIdFormat));
                lblAction.Text = "[" + Actions + "]";
                if (!(String.IsNullOrEmpty(Actions))) {
                    break; 
                }
                Thread.Sleep(5000);
            } while (true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstHandCard_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstHandCard.SelectedItems.Count != 1) return;
            var CardSn = lstHandCard.SelectedItem.ToString().Substring(lstHandCard.SelectedItem.ToString().IndexOf("[") + 1, 7);
            if (Card.CardUtility.GetCardInfoBySN(CardSn) != null)
            {
                Card.CardBasicInfo info = Card.CardUtility.GetCardInfoBySN(CardSn);
                StringBuilder Status = new StringBuilder();
                Status.AppendLine("==============");
                Status.AppendLine("Description" + info.Description);
                Status.AppendLine("StandardCostPoint" + info.StandardCostPoint);
                Status.AppendLine("Type：" + info.CardType.ToString());
                switch (CardSn.Substring(0, 1))
                {
                    case "A":
                        break;
                    case "M":
                        Status.AppendLine("标准攻击力：" + ((Card.MinionCard)info).StandardAttackPoint.ToString());
                        Status.AppendLine("标准生命值：" + ((Card.MinionCard)info).StandardHealthPoint.ToString());
                        break;
                    case "W":
                        Status.AppendLine("标准攻击力：" + ((Card.WeaponCard)info).StandardAttackPoint.ToString());
                        Status.AppendLine("标准耐久度：" + ((Card.WeaponCard)info).标准耐久度.ToString());
                        break;
                    default:
                        break;
                }

                lblSelectedHandCardInfo.Text = Status.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, System.EventArgs e)
        {
            Card.Server.ClientUtlity.TurnEnd(GameManager.GameId.ToString(GameServer.GameIdFormat));
            btnEndTurn.Enabled = false;
            lblEnemyBattle.Text = "Enemy Action";
            WaitForThread = new Thread(new BattleField().WaitFor);
            WaitForThread.Start();
        }

        private void btnReadAction_Click(object sender, EventArgs e)
        {
            var Actions = Card.Server.ClientUtlity.ReadAction(GameManager.GameId.ToString(GameServer.GameIdFormat));
            MessageBox.Show("[" + Actions + "]");
        }
    }
}
