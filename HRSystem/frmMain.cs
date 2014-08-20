using System;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Hiring Tracking
        /// </summary>
        private ctlStatisticInfo HiringtrackingStatisticInfo = new ctlStatisticInfo();
        /// <summary>
        /// Hiring Tracking
        /// </summary>
        private ctlOrgChart OrgChartInfo = new ctlOrgChart();
        /// <summary>
        /// 视图切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHiringTracking_Click(object sender, EventArgs e)
        {
            btnHiringTracking.Enabled = false;
            btnOrgnization.Enabled = true;
            MainContainer.Panel2.Controls.Clear();
            MainContainer.Panel2.Controls.Add(HiringtrackingStatisticInfo);
        }
        /// <summary>
        /// 视图切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrgnization_Click(object sender, EventArgs e)
        {
            btnHiringTracking.Enabled = true;
            btnOrgnization.Enabled = false;
            MainContainer.Panel2.Controls.Clear();
            MainContainer.Panel2.Controls.Add(OrgChartInfo);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = SystemManager.AppName;
            HiringtrackingStatisticInfo.RefreshData();
            SystemStatus.Text = "Ready";
            btnHiringTracking.Enabled = false;
            HiringtrackingStatisticInfo.Dock = DockStyle.Fill;
            OrgChartInfo.Dock = DockStyle.Fill;
            MainContainer.Panel2.Controls.Clear();
            MainContainer.Panel2.Controls.Add(HiringtrackingStatisticInfo);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmPositionInit(string.Empty)).ShowDialog();
            HiringtrackingStatisticInfo.RefreshData();
        }

        private void weeklyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmPipelineWeekInfo()).ShowDialog();
        }

        private void viewManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmViewMgr()).ShowDialog();
            HiringtrackingStatisticInfo.RefreshData();
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            MainContainer.SplitterDistance = 250;
        }

        private void addCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmCandidateEditor(String.Empty)).ShowDialog();
            HiringtrackingStatisticInfo.RefreshData();
        }

        private void recylceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmRecycle()).ShowDialog();
            HiringtrackingStatisticInfo.RefreshData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCenter.BackUp();
            MessageBox.Show("Complete");
        }
        /// <summary>
        /// Init Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCenter.Init();
            MessageBox.Show("Complete");
            HiringtrackingStatisticInfo.RefreshData();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmImport()).ShowDialog();
            GC.Collect();
            HiringtrackingStatisticInfo.RefreshData();
        }

    }
}
