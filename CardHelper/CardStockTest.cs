using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class CardStockTest : Form
    {
        public CardStockTest()
        {
            InitializeComponent();
        }

        private void CardStockTest_Load(object sender, EventArgs e)
        {
        }

        private void btn洗牌测试_Click(object sender, EventArgs e)
        {
            Card.CardStock t = new Card.CardStock();
            Stack<String> cards = new Stack<string>();
            for (int i = 0; i < Card.CardStock.MaxCards; i++)
            {
                cards.Push("C" + (i+1).ToString("D2"));
            }
            t.Init(cards);
        }
    }
}
