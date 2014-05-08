using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class CardDeckTest : Form
    {
        public CardDeckTest()
        {
            InitializeComponent();
        }
        private void CardDeckTest_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn洗牌测试_Click(object sender, EventArgs e)
        {
            Card.CardDeck t = new Card.CardDeck();
            Stack<String> cards = new Stack<string>();
            for (int i = 0; i < Card.CardDeck.MaxCards; i++)
            {
                cards.Push("C" + (i+1).ToString("D2"));
            }
            t.Init(cards,999);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn洗牌测试2_Click(object sender, EventArgs e)
        {
            Stack<String> cards = new Stack<string>();
            cards.Push("M000001");
            cards.Push("M000002");
            cards.Push("F000001");
            cards.Push("F000002");
            cards.Push("F000003");
            cards.Push("W000001");
            Card.CardDeck t = new Card.CardDeck();
            t.Init(cards,999);
        }
    }
}
