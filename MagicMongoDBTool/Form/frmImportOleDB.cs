using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmImportOleDB : QLFUI.QLFForm
    {
        public String DataBaseFileName = String.Empty;
        public frmImportOleDB()
        {
            InitializeComponent();
            ctlFilePickerDBName.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerDBName_PathChanged);
        }
        void ctlFilePickerDBName_PathChanged(string FilePath)
        {
            DataBaseFileName = FilePath;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
