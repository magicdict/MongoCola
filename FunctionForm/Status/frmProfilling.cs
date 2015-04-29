using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Status
{
    public partial class FrmProfilling : Form
    {
        /// <summary>
        /// </summary>
        public FrmProfilling()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProfilling_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
            cmbProfillingLv.Items.Add("0-No Logging");
            cmbProfillingLv.Items.Add("1-Log Slow Operations");
            cmbProfillingLv.Items.Add("2-Log All Operations");
            cmbProfillingLv.SelectedIndex = (int) RuntimeMongoDbContext.GetCurrentDataBase().GetProfilingLevel().Level;
            switch (cmbProfillingLv.SelectedIndex)
            {
                case 1:
                    NumTime.Enabled = true;
                    NumTime.Value =
                        (decimal) RuntimeMongoDbContext.GetCurrentDataBase().GetProfilingLevel().Slow.TotalSeconds*
                        1000;
                    break;
                default:
                    NumTime.Enabled = false;
                    break;
            }
        }

        /// <summary>
        ///     OK
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
                RuntimeMongoDbContext.GetCurrentDataBase()
                    .SetProfilingLevel(mProfillingLv, new TimeSpan(0, 0, 0, 0, (int) NumTime.Value));
            }
            else
            {
                RuntimeMongoDbContext.GetCurrentDataBase().SetProfilingLevel(mProfillingLv);
            }
            Close();
        }

        /// <summary>
        ///     Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     调整级别
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