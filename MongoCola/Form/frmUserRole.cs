using System;
using System.Windows.Forms;
using MongoCola.Module;
using MongoDB.Bson;

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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                cmdOK.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Cancel);
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