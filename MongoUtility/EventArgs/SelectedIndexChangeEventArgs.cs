namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     SelectedIndexChangeEventArgs
    /// </summary>
    public class SelectedIndexChangeEventArgs : System.EventArgs
    {
        private readonly int _newIndex;
        private readonly int _oldIndex;

        public SelectedIndexChangeEventArgs(int oldIndex, int newIndex)
        {
            _oldIndex = oldIndex;
            _newIndex = newIndex;
        }

        public int OldIndex
        {
            get { return _oldIndex; }
        }

        public int NewIndex
        {
            get { return _newIndex; }
        }
    }
}