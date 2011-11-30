using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class ctlMongod : UserControl
    {

        public event MagicMongoDBTool.frmDosCommand.CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.StruMongod MongodCommand = new MongodbDosCommand.StruMongod();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ctlMongod()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lblPort.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Port);
                lblSource.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_SlaveSource);
                chkAuth.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_Authentication);
                chkIsAppend.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_AppendMode);
                ctlFilePickerDBPath.Title = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_DBPath);
                ctlFilePickerLogPath.Title = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_LogPath);
                chkIsMaster.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_MasterDB);
                chkIsSlave.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_SlaveDB);
                txtSource.WaterMark = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_MasterAddress);
                grpLog.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.DosCommand_Tab_Deploy_Log);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlMongod_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += new ctllogLv.LogLvChangedHandler(ctllogLvT_LoglvChanged);
            ctlFilePickerLogPath.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerT_PathChanged);
            ctlFilePickerDBPath.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerDBPath_PathChanged);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerDBPath_PathChanged(string FilePath)
        {
            MongodCommand.DBPath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerT_PathChanged(string FilePath)
        {
            MongodCommand.LogPath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLv"></param>
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodCommand.LogLV = logLv;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkIsMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsMaster.Checked) { chkIsSlave.Checked = false; }
            MongodCommand.IsMaster = chkIsMaster.Checked;
            MongodCommand.IsSlave = chkIsSlave.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkIsSlave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSlave.Checked)
            {
                chkIsMaster.Checked = false;
            }
            MongodCommand.IsMaster = chkIsMaster.Checked;
            MongodCommand.IsSlave = chkIsSlave.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsAuth = chkAuth.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodCommand.Port = (int)numPort.Value;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void txtSource_TextChanged(string strNewText)
        {
            MongodCommand.Source = strNewText;
            if (MongodCommand != null)
            {
                CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
            }
        }
    }
}
