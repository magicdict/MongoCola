/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PlugInPackage
{
	/// <summary>
	/// Description of DosCommand.
	/// </summary>
	public class DosCommand: PlugInBase
	{
		public DosCommand()
		{
        	base.RunLv = PlugInBase.PathLv.Misc;
            base.PlugName = "DosCommand";
            base.PlugFunction = "DosCommand";
		}
		#region implemented abstract members of PlugInBase

		public override int Run()
		{
			Common.Utility.OpenForm(new frmDosCommand(),true,true);
			return 0;
		}
		#endregion
	}
}
