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
    public partial class frmErrMsg : QLFUI.QLFForm
    {
        public void SetMessage(String Message,String Details) {
            this.lblMessage.Text = Message;
            this.txtException.Text = Details;        
        }
        public frmErrMsg()
        {
            InitializeComponent();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
