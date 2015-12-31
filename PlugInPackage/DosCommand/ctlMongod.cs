using System;
using System.Windows.Forms;
using Common;
using MongoUtility.EventArgs;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace PlugInPackage.DosCommand
{
    public partial class CtlMongod : UserControl
    {
        public EventHandler<TextChangeEventArgs> CommandChanged;
        public MongodConfig MongodCommand = new MongodConfig();

        /// <summary>
        ///     构造函数
        /// </summary>
        public CtlMongod()
        {
            InitializeComponent();
            ctlFilePickerLogPath.FileFilter = Utility.LogFilter;
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                lblPort.Text = GuiConfig.GetText(TextType.CommonPort);
                lblSource.Text =
                    GuiConfig.GetText(
                        TextType.DosCommandTabDeploySlaveSource);
                chkAuth.Text =
                    GuiConfig.GetText(
                        TextType.DosCommandTabDeployAuthentication);
                chkIsAppend.Text =
                    GuiConfig.GetText(
                        TextType.DosCommandTabDeployAppendMode);
                ctlFilePickerDBPath.Title =
                    GuiConfig.GetText(TextType.DosCommandTabDeployDbPath);
                ctlFilePickerLogPath.Title =
                    GuiConfig.GetText(
                        TextType.DosCommandTabDeployLogPath);
                radMaster.Text =
                    GuiConfig.GetText(TextType.DosCommandTabDeployMaster);
                radSlave.Text =
                    GuiConfig.GetText(TextType.DosCommandTabDeploySlave);
                grpLog.Text =
                    GuiConfig.GetText(TextType.DosCommandTabDeployLog);
            }
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlMongod_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += ctllogLvT_LoglvChanged;
            ctlFilePickerLogPath.PathChanged += ctlFilePickerT_PathChanged;
            ctlFilePickerDBPath.PathChanged += ctlFilePickerDBPath_PathChanged;
        }

        protected virtual void OnCommandChange(TextChangeEventArgs e)
        {
            e.Raise(this, ref CommandChanged);
        }

        /// <summary>
        ///     DB路径
        /// </summary>
        /// <param name="filePath"></param>
        private void ctlFilePickerDBPath_PathChanged(string filePath)
        {
            MongodCommand.DbPath = filePath;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     路径
        /// </summary>
        /// <param name="filePath"></param>
        private void ctlFilePickerT_PathChanged(string filePath)
        {
            MongodCommand.LogPath = filePath;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     LOG等级
        /// </summary>
        /// <param name="logLv"></param>
        private void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodCommand.LogLv = logLv;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     Log追加模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     服务器类型变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MongodType_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Master = radMaster.Checked;
            MongodCommand.Slave = radSlave.Checked;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     安全模式变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsAuth = chkAuth.Checked;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     端口号变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodCommand.Port = (int) numPort.Value;
            OnCommandChange(new TextChangeEventArgs(string.Empty, MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
        }

        /// <summary>
        ///     源头的改变
        /// </summary>
        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            MongodCommand.Source = txtSource.Text;
            if (MongodCommand != null)
            {
                OnCommandChange(new TextChangeEventArgs(string.Empty,
                    MongodbDosCommand.GetMongodCommandLine(MongodCommand)));
            }
        }

        private void grpLog_Enter(object sender, EventArgs e)
        {
        }
    }
}