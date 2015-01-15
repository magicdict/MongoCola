using System;

namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     TextChangeEventArgs
    /// </summary>
    public class TextChangeEventArgs : System.EventArgs
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