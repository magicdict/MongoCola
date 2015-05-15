using System;
using System.Windows.Forms;
using ResourceLib.Method;
using MongoDB.Bson;

namespace FunctionForm.User
{
    public partial class FrmUserRole : Form
    {
        internal BsonArray Result;

        public FrmUserRole(BsonArray orgRoles)
        {
            InitializeComponent();
            Result = orgRoles;
            otherDBRolesPanel.SetRoles(Result);
            otherDBRolesPanel.IsAdmin = false;
            GuiConfig.Translateform(this);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = otherDBRolesPanel.GetRoles();
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}