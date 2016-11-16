using System;
using System.IO;
using System.Windows.Forms;
using ResourceLib.Method;

namespace MongoCola.Config
{
    public partial class FrmOption : Form
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Load
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void frmOption_Load(object sender, EventArgs e)
        {
            fileMongoBinPath.SelectedPathOrFileName = SystemManager.SystemConfig.MongoBinPath;
            if (SystemManager.SystemConfig.IsUtc)
            {
                radUTC.Checked = true;
            }
            else
            {
                radLocal.Checked = true;
            }

            switch (SystemManager.SystemConfig.DateTimeFormat)
            {
                case DateTimePickerFormat.Long:
                    radDateTime_Long.Checked = true;
                    break;
                case DateTimePickerFormat.Short:
                    radDateTime_Short.Checked = true;
                    break;
                case DateTimePickerFormat.Time:
                    radDateTime_Time.Checked = true;
                    break;
                case DateTimePickerFormat.Custom:
                    radDateTime_Custom.Checked = true;
                    txtDateTimeFormat.Text = SystemManager.SystemConfig.DateTimeCustomFormat;
                    break;
                default:
                    break;
            }

            if (SystemManager.SystemConfig.jsonMode == MongoDB.Bson.IO.JsonOutputMode.Strict)
            {
                radJsonStrict.Checked = true;
            }
            else
            {
                radJsonShell.Checked = true;
            }

            if (SystemManager.SystemConfig.IsDisplayNumberWithKSystem)
            {
                chkIsDisplayNumberWithKSystem.Checked = true;
            }
            else
            {
                chkIsDisplayNumberWithKSystem.Checked = false;
            }
            if (SystemManager.SystemConfig.RefreshStatusTimer == 0)
            {
                SystemManager.SystemConfig.RefreshStatusTimer = SystemConfig.DefaultRefreshStatusTimer;
            }
            intRefreshStatusTimer.Value = SystemManager.SystemConfig.RefreshStatusTimer;
            if (string.IsNullOrEmpty(SystemManager.SystemConfig.UiFontFamily))
            {
                lblCurrentFont.Text = Font.FontFamily.Name;
            }
            else
            {
                lblCurrentFont.Text = SystemManager.SystemConfig.UiFontFamily;
            }
            cmbLanguage.Items.Add(StringResource.LanguageEnglish);
            var LanguagePath = Application.StartupPath + Path.DirectorySeparatorChar + "Language";
            if (Directory.Exists(LanguagePath))
            {
                foreach (var fileName in Directory.GetFiles(LanguagePath))
                {
                    cmbLanguage.Items.Add(new FileInfo(fileName).Name.Substring(0,
                        new FileInfo(fileName).Name.Length - 4));
                }
            }

            if (!GuiConfig.IsUseDefaultLanguage)
            {
                if (
                    File.Exists("Language" + Path.DirectorySeparatorChar +
                                SystemManager.SystemConfig.LanguageFileName))
                {
                    cmbLanguage.Text = SystemManager.SystemConfig.LanguageFileName.Substring(0,
                        SystemManager.SystemConfig.LanguageFileName.Length - 4);
                }
                else
                {
                    cmbLanguage.Text = StringResource.LanguageEnglish;
                }
            }
            else
            {
                cmbLanguage.Text = StringResource.LanguageEnglish;
            }

            //GuidRepresentation
            Common.UIAssistant.FillComberWithEnum(cmbGuidRepresentation, typeof(SystemConfig.GuidRepresentation), true);
            cmbGuidRepresentation.SelectedIndex = SystemManager.SystemConfig.BsonGuidRepresentation.GetHashCode();

            GuiConfig.Translateform(this);
            GuiConfig.MonoCompactControl(Controls);
        }

        /// <summary>
        ///     Font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SystemManager.SystemConfig.UiFontFamily = fontDialog.Font.FontFamily.Name;
                lblCurrentFont.Text = SystemManager.SystemConfig.UiFontFamily;
            }
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            _ctlReadWriteConfig1.SaveConfig();
            SystemManager.SystemConfig.IsUtc = radUTC.Checked;
            if (radDateTime_Custom.Checked)
            {
                SystemManager.SystemConfig.DateTimeFormat = DateTimePickerFormat.Custom;
                SystemManager.SystemConfig.DateTimeCustomFormat = txtDateTimeFormat.Text;
            }
            if (radDateTime_Long.Checked) SystemManager.SystemConfig.DateTimeFormat = DateTimePickerFormat.Long;
            if (radDateTime_Short.Checked) SystemManager.SystemConfig.DateTimeFormat = DateTimePickerFormat.Short;
            if (radDateTime_Time.Checked) SystemManager.SystemConfig.DateTimeFormat = DateTimePickerFormat.Time;

            if (radJsonShell.Checked) SystemManager.SystemConfig.jsonMode = MongoDB.Bson.IO.JsonOutputMode.Shell;
            if (radJsonStrict.Checked) SystemManager.SystemConfig.jsonMode = MongoDB.Bson.IO.JsonOutputMode.Strict;

            SystemManager.SystemConfig.IsDisplayNumberWithKSystem = chkIsDisplayNumberWithKSystem.Checked;
            SystemManager.SystemConfig.MongoBinPath = fileMongoBinPath.SelectedPathOrFileName;
            SystemManager.SystemConfig.RefreshStatusTimer = (int)intRefreshStatusTimer.Value;
            SystemManager.SystemConfig.LanguageFileName = cmbLanguage.Text + ".xml";
            SystemManager.SystemConfig.BsonGuidRepresentation = (SystemConfig.GuidRepresentation)cmbGuidRepresentation.SelectedIndex;
            SystemManager.SystemConfig.SaveSystemConfig();
            Close();
        }

        /// <summary>
        ///     Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}