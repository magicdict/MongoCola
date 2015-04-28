namespace Common
{
    public static partial class Utility
    {
        #region"Excel"

        /// <summary>
        ///     获得数字，默认是0
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static int GetExcelIntValue(dynamic cell)
        {
            int t;
            int.TryParse(cell.Text, out t);
            return t;
        }

        /// <summary>
        ///     获得布尔值，默认是False
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static bool GetExcelBooleanValue(dynamic cell)
        {
            return !string.IsNullOrEmpty(cell.Text);
        }

        #endregion
    }
}