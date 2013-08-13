using MongoDB.Bson;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmUserRole : Form
    {
        internal BsonArray Result;

        public frmUserRole(BsonArray orgRoles)
        {
            InitializeComponent();
            Result = orgRoles;
            userRolesPanel1.setRoles(Result);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = userRolesPanel1.getRoles();
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
