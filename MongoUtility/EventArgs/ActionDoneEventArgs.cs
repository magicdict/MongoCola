namespace MongoUtility.EventArgs
{
    public class ActionDoneEventArgs : System.EventArgs
    {
        private readonly string _message;

        public ActionDoneEventArgs(string message)
        {
            _message = message;
        }

        public string Message
        {
            get { return _message; }
        }
    }
}