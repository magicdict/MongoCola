using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 炉边传说
{
    public partial class EffectSelect : Form
    {
        public EffectSelect()
        {
            InitializeComponent();
        }
        public String FirstEffect
        {
            set
            {
                btnEffect1.Text = value;
            }
        }
        public String SecondEffect
        {
            set
            {
                btnEffect2.Text = value;
            }
        }
        public Boolean IsFirstEffect = false;
        private void EffectSelect_Load(object sender, EventArgs e)
        {

        }

        private void btnEffect1_Click(object sender, EventArgs e)
        {
            IsFirstEffect = true;
            this.Close();
        }

        private void btnEffect2_Click(object sender, EventArgs e)
        {
            IsFirstEffect = false;
            this.Close();
        }
    }
}
