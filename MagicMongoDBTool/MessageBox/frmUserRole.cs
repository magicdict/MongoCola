using MongoDB.Bson;
using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
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
            if (!SystemManager.IsUseDefaultLanguage) {
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = otherDBRolesPanel.getRoles();
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
