using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class ctlMongod : UserControl
    {

        public EventHandler<TextChangeEventArgs> CommandChanged;
        public MongodbDosCommand.MongodConfig MongodCommand = new MongodbDosCommand.MongodConfig();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ctlMongod()
        {
            InitializeComponent();
            ctlFilePickerLogPath.FileFilter = MongoDBHelper.LogFilter;
            if (!SystemManager.IsUseDefaultLanguage)
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
        protected virtual void OnCommandChange(TextChangeEventArgs e)
        {
            e.Raise(this, ref CommandChanged);
        }
        /// <summary>
        /// DB路径
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerDBPath_PathChanged(String FilePath)
        {
            MongodCommand.DBPath = FilePath;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// 路径
        /// </summary>
        /// <param name="FilePath"></param>
        void ctlFilePickerT_PathChanged(String FilePath)
        {
            MongodCommand.LogPath = FilePath;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// LOG等级
        /// </summary>
        /// <param name="logLv"></param>
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodCommand.LogLV = logLv;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// Log追加模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// 服务器类型变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MongodType_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.master = radMaster.Checked;
            MongodCommand.slave = radSlave.Checked;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// 安全模式变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsAuth = chkAuth.Checked;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// 端口号变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodCommand.Port = (int)numPort.Value;
            OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }
        /// <summary>
        /// 源头的改变
        /// </summary>
        void txtSource_TextChanged(object sender, System.EventArgs e)
        {
            MongodCommand.source = txtSource.Text;
            if (MongodCommand != null)
            {
                OnCommandChange(new TextChangeEventArgs(String.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
            }
        }

        private void grpLog_Enter(object sender, EventArgs e)
        {

        }
    }
}
