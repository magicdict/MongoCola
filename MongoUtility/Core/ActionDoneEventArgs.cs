using System;

namespace MongoUtility.Core
{
    public class ActionDoneEventArgs : EventArgs
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