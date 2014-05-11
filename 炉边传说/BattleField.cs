using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        private Thread WaitForThread = new Thread(WaitFor);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleField_Load(object sender, System.EventArgs e)
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
            btnEndTurn.Enabled = false;
            if (GameManager.IsFirst)
            {
                MessageBox.Show("Your Turn");
                btnEndTurn.Enabled = true;
            }
            else {
               //WaitForThread.Start();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static void WaitFor() {
            while (!Card.Server.ClientUtlity.IsGameStart("aaaa"))
            {
                Thread.Sleep(3000);
            }
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
            Card.Server.ClientUtlity.TurnEnd(GameManager.GameId.ToString("D3"));
        }
    }
}
