using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }
        private void frmOption_Load(object sender, EventArgs e)
        {
            this.ctlFilePickerMongoBinPath.SelectedPath= SystemManager.mConfig.MongoBinPath;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.mConfig.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPath;
            SystemManager.mConfig.SaveToConfigFile();
            this.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
