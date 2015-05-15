using System.Windows.Forms;

namespace FunctionForm.Connection
{
    public partial class CtlSshConfig : UserControl
    {
        public CtlSshConfig()
        {
            InitializeComponent();
        }

        private void CtlSshConfig_Load(object sender, System.EventArgs e)
        {
            fileSshPrivateKeyFile.FileFilter = Common.Utility.PpkFilter;
        }
    }
}
