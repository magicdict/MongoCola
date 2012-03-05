using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmCreateCollection : Form
    {
       public String strSvrPathWithTag;
       public TreeNode treeNode;

        public frmCreateCollection()
        {
            InitializeComponent();
        }

        private void frmCreateCollection_Load(object sender, EventArgs e)
        {
            ///Difference between with long and decimal.....
            numMaxDocument.Maximum = decimal.MaxValue;
            numMaxSize.Maximum = decimal.MaxValue;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtCollectionName.Text != String.Empty)
            {
                MongoDBHelper.CreateCollectionWithOptions(strSvrPathWithTag, treeNode, txtCollectionName.Text, chkIsCapped.Checked,
                    (long)numMaxSize.Value, chkIsAutoIndexId.Checked, (long)numMaxDocument.Value);
                this.Close();
            }
        }
    }
}
