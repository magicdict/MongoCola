using System;
using System.Threading;

namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     This Method Copy From CLR via C#
    /// </summary>
    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e,
            object sender, ref EventHandler<TEventArgs> eventDelegate)
            where TEventArgs : System.EventArgs
        {
            // Copy a reference to the delegate field now into a temporary field for thread safety
            var temp =
                Interlocked.CompareExchange(ref eventDelegate, null, null);
            // If any methods registered interest with our event, notify them
            if (temp != null) temp(sender, e);
        }
    }
}