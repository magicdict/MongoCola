using MagicMongoDBTool.Common;
using System;
using System.Windows.Forms;
using MongoDB.Driver;
namespace ExportToExcel
{
    public class ExportToExcel:PlugBase
    {
        MongoCollection ProcessCollection;
        public ExportToExcel()
        {
            base.RunLv = PathLv.CollectionLV;
            base.PlugName = "Export To Excel Tool";
        }
        public override int Run()
        {
            ProcessCollection = base.PlugObj;
            MessageBox.Show(ProcessCollection.Name);
            return 0;
        }
    }
}
