/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/12
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace SystemUtility
{
	/// <summary>
	/// Description of SystemManager.
	/// </summary>
	public static class SystemConfig
	{
		#region"通用"
		/// 配置
		/// </summary>
		public static Config config = new Config();
		/// <summary>
		///     版本号
		/// </summary>
		public static string Version = string.Empty;
		/// <summary>
		///     测试模式
		/// </summary>
		public static bool DebugMode = false;
		/// <summary>
		///     是否为MONO
		/// </summary>
		public static bool MonoMode = false;
		#endregion
		#region"多语言"
		public static ResourceLib.GUIConfig guiConfig = new ResourceLib.GUIConfig();
		/// <summary>
		///     是否使用默认语言
		/// </summary>
		/// <returns></returns>
		public static bool IsUseDefaultLanguage {
			get {
				if (config == null) {
					return true;
				}
				return (config.LanguageFileName == "English.xml" ||
				string.IsNullOrEmpty(config.LanguageFileName));
			}
		}
		/// <summary>
		///     初始化
		/// </summary>
		public static void InitLanguage()
		{
			guiConfig.IsUseDefaultLanguage = IsUseDefaultLanguage;
			//语言的初始化
			if (!IsUseDefaultLanguage) {
				string LanguageFile = "Language" + Path.DirectorySeparatorChar + config.LanguageFileName;
				if (File.Exists(LanguageFile)) {
					guiConfig.MStringResource.InitLanguage(LanguageFile);
				}
				Common.MyMessageBox.SwitchLanguage();
			}
		}
		
		#endregion
	}
}
