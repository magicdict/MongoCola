using System;
using System.Windows.Forms;
using Common;

namespace FunctionForm.Connection
{
    public partial class CtlSshConfig : UserControl
    {
        public CtlSshConfig()
        {
            InitializeComponent();
        }

        private void CtlSshConfig_Load(object sender, EventArgs e)
        {
            fileSshPrivateKeyFile.FileFilter = Utility.PpkFilter;
        }
    }
}