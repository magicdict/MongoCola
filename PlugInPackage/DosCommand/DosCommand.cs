using Common;
using PlugInPrj;

namespace PlugInPackage.DosCommand
{
    /// <summary>
    ///     Description of DosCommand.
    /// </summary>
    public class DosCommand : PlugInBase
    {
        public DosCommand()
        {
            RunLv = PathLv.Misc;
            PlugName = "DosCommand";
            PlugFunction = "Dos Command Editor";
        }

        #region implemented abstract members of PlugInBase

        public override int Run()
        {
            UIAssistant.OpenModalForm(new FrmDosCommand(), true, true);
            return Success;
        }

        #endregion
    }
}