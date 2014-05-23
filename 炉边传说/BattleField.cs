using Card;
using Card.Client;
using Card.Server;
using System;
using System.Windows.Forms;
namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }
        public GameManager game;
        /// <summary>
        /// Timer
        /// </summary>
        private Timer WaitTimer = new Timer();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleField_Load(object sender, System.EventArgs e)
        {
            game.GetSelectTarget = SelectPanel;
            game.PickEffect = PickEffect;
            WaitTimer.Interval = 3000;
            WaitTimer.Tick += WaitFor;
            DisplayMyInfo();
            game.IsMyTurn = game.IsFirst;
            for (int i = 0; i < 10; i++)
            {
                Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Click += this.btnUseHandCard_Click;
            }
            StartNewTurn();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CardUtility.TargetPosition SelectPanel()
        {
            CardUtility.TargetPosition t = new Card.CardUtility.TargetPosition();
            TargetSelect frm = new TargetSelect();
            frm.ShowDialog();
            t = frm.pos;
            return t;
        }
        /// <summary>
        /// 显示我方状态
        /// </summary>
        private void DisplayMyInfo()
        {
            btnMyHero.Text = game.MySelf.RoleInfo.GetInfo();
            btnYourHero.Text = game.AgainstInfo.GetInfo();
            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
            {
                Controls.Find("btnMe" + (i + 1).ToString(), true)[0].Text = game.MySelf.RoleInfo.BattleField.BattleMinions[i].Name;
            }
            for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
            {
                Controls.Find("btnYou" + (i + 1).ToString(), true)[0].Text = game.AgainstInfo.BattleField.BattleMinions[i].Name;
            }
            for (int i = 0; i < 10; i++)
            {
                if (i < game.MySelf.handCards.Count)
                {
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Text = Card.CardUtility.GetCardNameBySN(game.MySelf.handCards[i]);
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Tag = game.MySelf.handCards[i];
                }
                else
                {
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Text = "[无]";
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Tag = null;
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Enabled = false;
                }
            }
        }
        /// <summary>
        /// 新的回合
        /// </summary>
        private void StartNewTurn()
        {
            game.NewTurn();
            if (game.IsMyTurn)
            {
                DisplayMyInfo();
                btnEndTurn.Enabled = true;
                for (int i = 0; i < 10; i++)
                {
                    if (Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Tag != null)
                    {
                        Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Enabled = true;
                    }
                }
            }
            else
            {
                btnEndTurn.Enabled = false;
                for (int i = 0; i < 10; i++)
                {
                    Controls.Find("btnHandCard" + (i + 1).ToString(), true)[0].Enabled = false;
                }
                WaitTimer.Start();
            }
        }
        /// <summary>
        /// 读取
        /// </summary>
        private void WaitFor(object sender, System.EventArgs e)
        {
            var Actions = Card.Server.ClientUtlity.ReadAction(game.GameId.ToString(GameServer.GameIdFormat));
            if (String.IsNullOrEmpty(Actions)) return;
            var ActionList = Actions.Split("|".ToCharArray());
            foreach (var item in ActionList)
            {
                lstAction.Items.Add("[" + item + "]");
                if (ActionCode.GetActionType(item) != ActionCode.ActionType.EndTurn)
                {
                    ProcessAction.Process(item, game);
                }
                else
                {
                    WaitTimer.Stop();
                    btnEndTurn.Enabled = true;
                    game.IsMyTurn = true;
                    StartNewTurn();
                    break;
                }
            }
            DisplayMyInfo();
        }

        /// <summary>
        /// 结束回合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, System.EventArgs e)
        {
            Card.Server.ClientUtlity.TurnEnd(game.GameId.ToString(GameServer.GameIdFormat));
            game.IsMyTurn = false;
            StartNewTurn();
            WaitTimer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstEffect"></param>
        /// <param name="SecondEffect"></param>
        /// <returns></returns>
        private Boolean PickEffect(String FirstEffect, String SecondEffect)
        {
            Boolean IsFirst = false;
            EffectSelect t = new EffectSelect();
            t.FirstEffect = FirstEffect;
            t.SecondEffect = SecondEffect;
            t.ShowDialog();
            IsFirst = t.IsFirstEffect;
            t = null;
            return IsFirst;
        }

        /// <summary>
        /// 使用手牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseHandCard_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Tag == null) return;
            String CardSn = ((Button)sender).Tag.ToString();
            if (Card.CardUtility.GetCardInfoBySN(CardSn) != null)
            {
                Card.CardBasicInfo card = Card.CardUtility.GetCardInfoBySN(CardSn);
                if (game.MySelf.RoleInfo.crystal.CurrentRemainPoint >= card.ActualCostPoint)
                {
                    game.MySelf.RoleInfo.crystal.CurrentRemainPoint -= card.ActualCostPoint;
                    game.MySelf.handCards.Remove(CardSn);
                    game.MySelf.RoleInfo.HandCardCount = game.MySelf.handCards.Count; 
                }
                else
                {
                    MessageBox.Show("水晶不够");
                    return;
                }
                var actionlst = RunAction.StartAction(game, CardSn);
                foreach (var action in actionlst)
                {
                    Card.Server.ClientUtlity.WriteAction(game.GameId.ToString(GameServer.GameIdFormat), action);
                }
            }
            DisplayMyInfo();
        }

    }
}
