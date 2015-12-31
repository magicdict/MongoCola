/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

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
            Utility.OpenForm(new FrmDosCommand(), true, true);
            return Success;
        }

        #endregion
    }
}