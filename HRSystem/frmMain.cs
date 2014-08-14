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

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = SystemManager.AppName;
            ctlStatisticInfo1.RefreshData();
            SystemStatus.Text = "Ready";
        }
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmImport()).ShowDialog();
            ctlStatisticInfo1.RefreshData();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmPositionInit()).ShowDialog();
            ctlStatisticInfo1.RefreshData();
        }

        private void weeklyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmPipelineWeekInfo()).ShowDialog();
        }

        private void viewManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmViewMgr()).ShowDialog();
            ctlStatisticInfo1.RefreshData();
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 250;
        }

        private void addCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmCandidateEditor(String.Empty)).ShowDialog();
            ctlStatisticInfo1.RefreshData();
        }
    }
}
