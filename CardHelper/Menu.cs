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
            new CardDeckTest().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GameFlowTest().ShowDialog();
        }
    }
}
