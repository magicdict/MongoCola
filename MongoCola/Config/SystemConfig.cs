/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/8
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MongoUtility.Core;

namespace MongoCola.Config
{
    /// <summary>
    ///     SystemConfig
    /// </summary>
    [Serializable]
    public class SystemConfig
    {
        #region"通用"
        /// <summary>
        ///     MongoBin的路径，用于Dos命令
        /// </summary>
        public string MongoBinPath = string.Empty;

        /// <summary>
        ///     Config Format Version
        /// </summary>
        public byte ConfigVer = 1;
        /// <summary>
        ///     语言
        /// </summary>
        public string LanguageFileName = string.Empty;
        /// <summary>
        ///     状态刷新间隔时间
        /// </summary>
        public int RefreshStatusTimer = 30;
        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        /// <returns></returns>
        public bool IsUseDefaultLanguage()
        { 
            return (LanguageFileName == "English.xml" || string.IsNullOrEmpty(LanguageFileName));
        }
        #endregion
    }
}