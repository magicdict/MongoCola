namespace PlugInPackage
{
    public abstract class PlugInBase
    {
        /// <summary>
        ///     路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        public enum PathLv
        {
            /// <summary>
            ///     连接/服务器
            /// </summary>
            ConnectionLv = 0,

            /// <summary>
            ///     具体的实例
            /// </summary>
            InstanceLv = 1,

            /// <summary>
            ///     数据库
            /// </summary>
            DatabaseLv = 2,

            /// <summary>
            ///     数据集
            /// </summary>
            CollectionLv = 3,

            /// <summary>
            ///     数据文档
            /// </summary>
            DocumentLv = 4,

            /// <summary>
            ///     杂项
            /// </summary>
            Misc = 9
        }

        public const int Success = 0;

        /// <summary>
        ///     插件功能简述
        /// </summary>
        public string PlugFunction = string.Empty;

        /// <summary>
        ///     插件菜单表示名称
        /// </summary>
        public string PlugName = string.Empty;

        /// <summary>
        ///     处理对象
        /// </summary>
        public object PlugObj;

        /// <summary>
        ///     对象层次
        /// </summary>
        public PathLv RunLv = PathLv.ConnectionLv;

        /// <summary>
        ///     运行
        /// </summary>
        /// <returns></returns>
        public abstract int Run();
    }
}