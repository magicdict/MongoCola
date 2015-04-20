using System;

namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     TextChangeEventArgs
    /// </summary>
    public class TextChangeEventArgs : System.EventArgs
    {
        private readonly string _NewString;
        private readonly string _OldString;

        public TextChangeEventArgs(string OldString, string NewString)
        {
            _OldString = OldString;
            _NewString = NewString;
        }

        public string OldString
        {
            get { return _OldString; }
        }

        public string NewString
        {
            get { return _NewString; }
        }
    }
}