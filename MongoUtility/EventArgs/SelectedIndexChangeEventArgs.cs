namespace MongoUtility.EventArgs
{
    /// <summary>
    ///     SelectedIndexChangeEventArgs
    /// </summary>
    public class SelectedIndexChangeEventArgs : System.EventArgs
    {
        public SelectedIndexChangeEventArgs(int oldIndex, int newIndex)
        {
            OldIndex = oldIndex;
            NewIndex = newIndex;
        }

        public int OldIndex { get; set; }

        public int NewIndex { get; set; }
    }
}