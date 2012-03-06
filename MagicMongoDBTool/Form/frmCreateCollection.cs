using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmCreateCollection : Form
    {
        public String strSvrPathWithTag;
        public TreeNode treeNode;
        public Boolean Result = false;
        public frmCreateCollection()
        {
            InitializeComponent();
        }

        private void frmCreateCollection_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_Collection);
                this.lblCollectionName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName);
                this.cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
                this.cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
            }

            ///Difference between with long and decimal.....
            numMaxDocument.Maximum = decimal.MaxValue;
            numMaxSize.Maximum = decimal.MaxValue;
            chkAdvance.Checked = false;
            chkAdvance.Location = new System.Drawing.Point(grpAdvanced.Location.X + 10, grpAdvanced.Location.Y );
            chkAdvance.BringToFront();
            grpAdvanced.Enabled = false;
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtCollectionName.Text != String.Empty)
            {
                if (chkAdvance.Checked)
                {
                    Result = MongoDBHelper.CreateCollectionWithOptions(strSvrPathWithTag, treeNode, txtCollectionName.Text, chkIsCapped.Checked,
                         (long)numMaxSize.Value, chkIsAutoIndexId.Checked, (long)numMaxDocument.Value);
                }
                else
                {
                    Result = MongoDBHelper.CreateCollection(strSvrPathWithTag, treeNode, txtCollectionName.Text);
                }
                this.Close();
            }
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAdvance_CheckedChanged(object sender, EventArgs e)
        {
            grpAdvanced.Enabled = chkAdvance.Checked;
        }


    }
}
