using System;
using System.Windows.Forms;

namespace FunctionForm.Connection
{
    public partial class CtlSSLConfig : UserControl
    {
        public CtlSSLConfig()
        {
            InitializeComponent();
        }

        private void CtlSSLConfig_Load(object sender, EventArgs e)
        {
            fileSslCertificateFile.FileFilter = Common.Utility.PemFilter;
        }
    }
}
