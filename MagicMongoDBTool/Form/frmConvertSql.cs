using System;
using System.Windows.Forms;

using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmConvertSql : Form
    {
        public frmConvertSql()
        {
            InitializeComponent();
        }
        private void frmRunSql_Load(object sender, EventArgs e)
        {
            txtSql.Text = "select * from CollectionName where FieldName=1 order by FieldName asc";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ConvertSql_Title);
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdSave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = MongoDBHelper.ConvertQuerySql(txtSql.Text);
                NewDataFilter.SaveFilter(savefile.FileName);
            }
            this.Close();
        }
    }
}
