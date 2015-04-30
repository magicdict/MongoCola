using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.Method;

namespace FunctionForm.Misc
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
            }
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