using System;
using System.Windows.Forms;
using Common;

namespace FunctionForm.Connection
{
    public partial class CtlSslConfig : UserControl
    {
        public CtlSslConfig()
        {
            InitializeComponent();
        }

        private void CtlSSLConfig_Load(object sender, EventArgs e)
        {
            fileSslCertificateFile.FileFilter = Utility.PemFilter;
        }
    }
}