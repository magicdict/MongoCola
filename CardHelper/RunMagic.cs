using Card.Client;
using System;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class RunAbility : Form
    {
        public RunAbility()
        {
            InitializeComponent();
        }

        Card.AbilityCard 奥术飞弹 = new Card.AbilityCard();
        BattleFieldInfo 敌方战场 = new BattleFieldInfo();
        PlayerBasicInfo 敌人 = new PlayerBasicInfo();

        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            奥术飞弹 = HelperUtility.Get奥术飞弹();
        }
        /// <summary>
        /// 重置对手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetEenmey_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 敌方战场.BattleMinions.Length; i++)
            {
                var 狼骑兵= HelperUtility.Get狼骑兵();
                狼骑兵.Init();
                敌方战场.BattleMinions[i] = 狼骑兵;
            }
        }

 
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserAbility_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUserAbility变羊术_Click(object sender, EventArgs e)
        {
            var 变羊术 = HelperUtility.Get变羊术();
            
        }
    }
}
