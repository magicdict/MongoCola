using MagicMongoDBTool.Common;
using MongoDB.Driver;
using System.Windows.Forms;
namespace ExportToExcel
{
    public class ExportToExcel:PlugBase
    {
        /// <summary>
        /// 内部变量
        /// </summary>
        MongoCollection ProcessCollection;
        /// <summary>
        /// 初始化设定
        /// </summary>
        public ExportToExcel()
        {
            base.RunLv = PathLv.CollectionLV;
            base.PlugName = "导出到Excel工具";
            base.PlugFunction = "将数据集导出到Excel";
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            ProcessCollection = base.PlugObj;
            MessageBox.Show(ProcessCollection.Name);
            return 0;
        }
    }
}
