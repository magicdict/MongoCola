using System;
using MongoDB.Driver;
using MongoUtility.Basic;

namespace MongoUtility.Core
{
    /// <summary>
    ///     RunCommandEventArgs
    /// </summary>
    public class RunCommandEventArgs : EventArgs
    {
        /// <summary>
        ///     CommandString
        /// </summary>
        public String CommandString;

        /// <summary>
        ///     Result
        /// </summary>
        public CommandResult Result;

        /// <summary>
        ///     Path Level
        /// </summary>
        public EnumMgr.PathLv RunLevel;
    }
}