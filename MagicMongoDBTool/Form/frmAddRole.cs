using MagicMongoDBTool.Module;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmAddRole : Form
    {
        public frmAddRole()
        {
            InitializeComponent();
        }
        private void frmAddRole_Load(object sender, EventArgs e)
        {
            cmbDatabase.Items.Clear();
            foreach (String item in SystemManager.GetCurrentServer().GetDatabaseNames())
            {
                cmbDatabase.Items.Add(item);
            }
        }
    }
}
