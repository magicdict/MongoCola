using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                ColorfulControl(item);
            }
        }
        private void ColorfulControl(Control item)
        {
            switch (item.GetType().ToString())
            {
                case "System.Windows.Forms.Button":
                    Button button = (Button)item;
                    button.BackColor = Color.Orange;
                    button.ForeColor = Color.White;
                    break;
                case "System.Windows.Forms.TrackBar":
                    TrackBar trackbar = (TrackBar)item;
                    trackbar.BackColor = this.BackColor;
                    break;
                case "System.Windows.Forms.TextBox":
                    TextBox textbox = (TextBox)item;
                    break;
                default:
                    item.BackColor = this.BackColor;
                    foreach (Control ctl in item.Controls)
                    {
                        ColorfulControl(ctl);
                    }
                    break;
            }
        }
    }
}
