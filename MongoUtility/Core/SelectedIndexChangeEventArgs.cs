using System;

namespace MongoUtility.Core
{
    /// <summary>
    ///     SelectedIndexChangeEventArgs
    /// </summary>
    public class SelectedIndexChangeEventArgs : EventArgs
    {
        private readonly int _NewIndex;
        private readonly int _OldIndex;

        public SelectedIndexChangeEventArgs(int OldIndex, int NewIndex)
        {
            _OldIndex = OldIndex;
            _NewIndex = NewIndex;
        }

        public int OldIndex
        {
            get { return _OldIndex; }
        }

        public int NewIndex
        {
            get { return _NewIndex; }
        }
    }
}