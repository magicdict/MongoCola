using System;

namespace Common.Logic
{
    /// <summary>
    ///     数据库记录
    /// </summary>
    [Serializable]
    public class Model<T>
    {
        /// <summary>
        ///     数据
        /// </summary>
        public T DataRec;

        /// <summary>
        ///     统一编号
        /// </summary>
        public string DBId;

        /// <summary>
        ///     删除标志
        /// </summary>
        public Boolean IsDel;

        /// <summary>
        ///     最后更新时间
        /// </summary>
        public DateTime LastUpdate;
    }
}