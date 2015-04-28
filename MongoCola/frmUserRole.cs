using System;
using System.Windows.Forms;

using MongoDB.Bson;
using ResourceLib;

namespace MongoCola
{
    public partial class frmUserRole : Form
    {
        internal BsonArray Result;

        public frmUserRole(BsonArray orgRoles)
        {
            InitializeComponent();
            Result = orgRoles;
            otherDBRolesPanel.setRoles(Result);
            otherDBRolesPanel.IsAdmin = false;
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                cmdOK.Text = GUIConfig.GetText(TextType.Common_OK);
                cmdCancel.Text = GUIConfig.GetText(TextType.Common_Cancel);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = otherDBRolesPanel.getRoles();
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}