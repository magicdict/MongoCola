using System;

namespace MongoUtility.Core
{
    /// <summary>
    ///     TextChangeEventArgs
    /// </summary>
    public class TextChangeEventArgs : EventArgs
    {
        private readonly String _NewString;
        private readonly String _OldString;

        public TextChangeEventArgs(String OldString, String NewString)
        {
            _OldString = OldString;
            _NewString = NewString;
        }

        public String OldString
        {
            get { return _OldString; }
        }

        public String NewString
        {
            get { return _NewString; }
        }
    }
}