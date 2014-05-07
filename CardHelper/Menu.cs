using System;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnRunMagic_Click(object sender, EventArgs e)
        {
            new RunMagic().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CardStockTest().ShowDialog();
        }
    }
}
