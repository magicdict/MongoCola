using System;

namespace MongoUtility.EventArgs
{
    public class ActionDoneEventArgs : System.EventArgs
    {
        private readonly string _Message;

        public ActionDoneEventArgs(string Message)
        {
            _Message = Message;
        }

        public string Message
        {
            get { return _Message; }
        }
    }
}