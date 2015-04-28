namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     TextChangeEventArgs
    /// </summary>
    public class TextChangeEventArgs : System.EventArgs
    {
        private readonly string _newString;
        private readonly string _oldString;

        public TextChangeEventArgs(string oldString, string newString)
        {
            _oldString = oldString;
            _newString = newString;
        }

        public string OldString
        {
            get { return _oldString; }
        }

        public string NewString
        {
            get { return _newString; }
        }
    }
}