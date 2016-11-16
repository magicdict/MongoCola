
using Common;
using PlugInPrj;

namespace PlugInPackage.GenerateConfigIni
{
    /// <summary>
    ///     Description of DosCommand.
    /// </summary>
    public class GenerateConfigIni : PlugInBase
    {
        public GenerateConfigIni()
        {
            RunLv = PathLv.Misc;
            PlugName = "GenerateConfigIni";
            PlugFunction = "GenerateConfigIni";
        }

        #region implemented abstract members of PlugInBase

        public override int Run()
        {
            UIAssistant.OpenModalForm(new FrmGenerateConfigIni(), true, true);
            return Success;
        }

        #endregion
    }
}