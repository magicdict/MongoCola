namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     TextChangeEventArgs
    /// </summary>
    public class TextChangeEventArgs : System.EventArgs
    {
        public TextChangeEventArgs(string oldString, string newString)
        {
            OldString = oldString;
            NewString = newString;
        }

        public string OldString { get; set; }

        public string NewString { get; set; }
    }
}