using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.Method;
using MongoUtility.Security;
using System.Collections.Generic;
using MongoUtility.Core;

namespace FunctionForm.User
{
    public partial class FrmUserRole : Form
    {
        /// <summary>
        ///     Role List
        /// </summary>
        public List<Role.GrantRole> PickedRoles = new List<Role.GrantRole>();

        public FrmUserRole(List<Role.GrantRole> orgRoles, Boolean IsAdmin)
        {
            InitializeComponent();
            otherDBRolesPanel.IsAdmin = IsAdmin;
            PickedRoles = orgRoles;
            RefreshRoles();
            GuiConfig.Translateform(this);
        }

        private void FrmUserRole_Load(object sender, EventArgs e)
        {
            var dbs = RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames();
            Common.UIAssistant.FillComberWithArray(cmbDB, dbs, false);
        }

        private void cmdAddRole_Click(object sender, EventArgs e)
        {
            BsonArray Result = otherDBRolesPanel.GetRoles();
            if (cmbDB.SelectedIndex != 0)
            {
                foreach (var item in Result)
                {
                    PickedRoles.Add(new Role.GrantRole() { Db = cmbDB.Text, Role = item.ToString() });
                }
            }
            else
            {
                foreach (var item in Result)
                {
                    PickedRoles.Add(new Role.GrantRole() { Role = item.ToString() });
                }
            }
            RefreshRoles();
        }

        private void RefreshRoles()
        {
            lstRoles.Items.Clear();
            foreach (var role in PickedRoles)
            {
                var lst = new ListViewItem(role.Role);
                lst.SubItems.Add(role.Db);
                lstRoles.Items.Add(lst);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            PickedRoles.Clear();
            Close();
        }

    }
}