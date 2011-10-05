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
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }
        private void frmOption_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// MongoBin路径的浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMongoBinPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMongoBinPath.Text = fbd.SelectedPath;
            }
        }


    }
}
