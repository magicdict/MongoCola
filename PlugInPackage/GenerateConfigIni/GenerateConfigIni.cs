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
	public class GenerateConfigIni: PlugInBase
	{
		public GenerateConfigIni()
		{
        	base.RunLv = PlugInBase.PathLv.Misc;
            base.PlugName = "GenerateConfigIni";
            base.PlugFunction = "GenerateConfigIni";
		}
		#region implemented abstract members of PlugInBase

		public override int Run()
		{
			Common.Utility.OpenForm(new frmGenerateConfigIni(),true,true);
			return 0;
		}
		#endregion
	}
}
