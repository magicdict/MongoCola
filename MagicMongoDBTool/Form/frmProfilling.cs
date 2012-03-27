using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmProfilling : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmProfilling()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProfilling_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage()) {
                cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
                cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
                lblProfilingLevel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_ProfillingLevel);
            }
            
            cmbProfillingLv.Items.Add("0-No Logging");
            cmbProfillingLv.Items.Add("1-Log Slow Operations");
            cmbProfillingLv.Items.Add("2-Log All Operations");

            cmbProfillingLv.SelectedIndex = (int)SystemManager.GetCurrentDataBase().GetProfilingLevel().Level;
            switch (cmbProfillingLv.SelectedIndex)
            {
                case 1:
                    NumTime.Enabled = true;
                    this.NumTime.Value = (decimal)SystemManager.GetCurrentDataBase().GetProfilingLevel().Slow.TotalSeconds * 1000;
                    break;
                default:
                    NumTime.Enabled = false;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            ProfilingLevel mProfillingLv;
            switch (cmbProfillingLv.SelectedIndex)
            {
                case 0:
                    mProfillingLv = ProfilingLevel.None;
                    break;
                case 1:
                    mProfillingLv = ProfilingLevel.Slow;
                    break;
                case 2:
                    mProfillingLv = ProfilingLevel.All;
                    break;
                default:
                    mProfillingLv = ProfilingLevel.None;
                    break;
            }
            if (mProfillingLv == ProfilingLevel.Slow)
            {
                SystemManager.GetCurrentDataBase().SetProfilingLevel(mProfillingLv, new TimeSpan(0, 0, 0, 0, (int)NumTime.Value));
            }
            else
            {
                SystemManager.GetCurrentDataBase().SetProfilingLevel(mProfillingLv);
            }
            this.Close();
        }
        /// <summary>
        /// 
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
        private void cmbProfillingLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbProfillingLv.SelectedIndex)
            {
                case 1:
                    NumTime.Enabled = true;
                    break;
                default:
                    NumTime.Enabled = false;
                    break;
            }
        }
    }
}
