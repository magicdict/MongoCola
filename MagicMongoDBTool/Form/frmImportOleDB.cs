using System;

namespace MagicMongoDBTool
{
    public partial class frmImportOleDB : QLFUI.QLFForm
    {
        public string DataBaseFileName = string.Empty;
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
