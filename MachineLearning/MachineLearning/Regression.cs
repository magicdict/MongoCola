using MongoDB.Driver;
using PlugInPrj;

namespace MachineLearning.MachineLearning
{
    public class Regression : PlugInBase
    {
        /// <summary>
        ///     内部变量
        /// </summary>
        private static MongoCollection _processCollection;

        public Regression()
        {
            RunLv = PathLv.CollectionLv;
            PlugName = "机器学习回归算法";
            PlugFunction = "机器学习回归算法";
        }

        public override int Run()
        {
            _processCollection = (MongoCollection)PlugObj;
            var frm = new frmRegression();
            frm.mongoCol = _processCollection;
            frm.ShowDialog();
            return Success;
        }
    }
}
