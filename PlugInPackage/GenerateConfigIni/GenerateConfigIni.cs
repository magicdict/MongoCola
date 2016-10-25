
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
            Utility.OpenForm(new FrmGenerateConfigIni(), true, true);
            return 0;
        }

        #endregion
    }
}