using System;

namespace MongoUtility.EventArgs
{
    public class ActionDoneEventArgs : System.EventArgs
    {
        private readonly String _Message;

        public ActionDoneEventArgs(String Message)
        {
            _Message = Message;
        }

        public string Message
        {
            get { return _Message; }
        }
    }
}