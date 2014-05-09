using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace 炉边传说
{
    public partial class frmStartGame : Form
    {
        public frmStartGame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 13000);
            var stream = client.GetStream();
            var bytes = new Byte[512];
            bytes = Encoding.ASCII.GetBytes("STARTGAME");
            stream.Write(bytes, 0, bytes.Length);
            client.Close();
        }
    }
}
