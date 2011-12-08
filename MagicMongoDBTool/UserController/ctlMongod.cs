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
            ctlFilePickerLogPath.FileFilter = MongoDBHelper.LogFilter;
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lblPort.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Port);
                lblSource.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_SlaveSource);
                chkAuth.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_Authentication);
                chkIsAppend.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_AppendMode);
                ctlFilePickerDBPath.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_DBPath);
                ctlFilePickerLogPath.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_LogPath);
                radMaster.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_Master);
                radSlave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_Slave);
                grpLog.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy_Log);
            }
        }
        /// <summary>
        /// 加载
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
        /// DB路径
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerDBPath_PathChanged(string FilePath)
        {
            MongodCommand.DBPath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 路径
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerT_PathChanged(string FilePath)
        {
            MongodCommand.LogPath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// LOG等级
        /// </summary>
        /// <param name="logLv"></param>
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodCommand.LogLV = logLv;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// Log追加模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 服务器类型变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MongodType_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsMaster = radMaster.Checked;
            MongodCommand.IsSlave = radSlave.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 安全模式变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsAuth = chkAuth.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 端口号变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodCommand.Port = (int)numPort.Value;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        /// <summary>
        /// 源头的改变
        /// </summary>
        void txtSource_TextChanged(object sender, System.EventArgs e)
        {
            MongodCommand.Source = txtSource.Text;
            if (MongodCommand != null)
            {
                CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
            }
        }
    }
}
