namespace MongoUtility.EventArgs
{
    public class ActionDoneEventArgs : System.EventArgs
    {
        public ActionDoneEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}