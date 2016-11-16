using MongoDB.Driver;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    public partial class frmCreateCollation : Form
    {
        public Collation mCollation;

        public frmCreateCollation()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocale.Text))
            {
                MessageBox.Show("Please Input Locale!");
                return;
            }
            mCollation = new Collation(locale: txtLocale.Text,
                                       caseLevel: chkCaseLevel.Checked,
                                       numericOrdering: chkNumbericOrdering.Checked,
                                       backwards: chkBackwards.Checked,
                                       strength: ((CollationStrength)cmbStrength.SelectedIndex + 1),
                                       maxVariable: (CollationMaxVariable)cmbMaxVariable.SelectedIndex,
                                       alternate: (CollationAlternate)cmbAlternate.SelectedIndex,
                                       caseFirst: (CollationCaseFirst)cmbCaseFirst.SelectedIndex);
            Close();
        }

        private void frmCreateCollation_Load(object sender, System.EventArgs e)
        {
            Common.UIAssistant.FillComberWithEnum(cmbStrength, typeof(CollationStrength));
            Common.UIAssistant.FillComberWithEnum(cmbMaxVariable, typeof(CollationMaxVariable));
            Common.UIAssistant.FillComberWithEnum(cmbAlternate, typeof(CollationAlternate));
            Common.UIAssistant.FillComberWithEnum(cmbCaseFirst, typeof(CollationCaseFirst));

            //Default 
            chkCaseLevel.Checked = false;
            //Strength是1开始的，默认值是3
            cmbStrength.SelectedIndex = 2;
            chkNumbericOrdering.Checked = false;
            cmbMaxVariable.SelectedIndex = 0;
        }
    }
}
