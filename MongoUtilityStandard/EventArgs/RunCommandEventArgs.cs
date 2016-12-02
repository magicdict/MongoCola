using MongoDB.Driver;
using MongoUtility.Basic;

namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     RunCommandEventArgs
    /// </summary>
    public class RunCommandEventArgs : System.EventArgs
    {
        /// <summary>
        ///     CommandString
        /// </summary>
        public string CommandString;

        /// <summary>
        ///     Result
        /// </summary>
        public CommandResult Result;

        /// <summary>
        ///     Path Level
        /// </summary>
        public EnumMgr.PathLevel RunLevel;
    }
}