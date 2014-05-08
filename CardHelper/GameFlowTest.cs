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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitGame_Click(object sender, EventArgs e)
        {
            Card.Server.GameStatusAtServer game = new Card.Server.GameStatusAtServer();
            game.Init(HelperUtility.GetCardDeck(),HelperUtility.GetCardDeck());
        }
    }
}
