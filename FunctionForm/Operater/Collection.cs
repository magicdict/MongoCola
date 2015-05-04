using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;
using ResourceLib.UI;
using System.Windows.Forms;

namespace FunctionForm
{
    public class Collection
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool DropCollection(TreeNode node)
        {
            var strTitle = GuiConfig.GetText("Drop Collection", TextType.DropCollection);
            var strMessage = GuiConfig.GetText("Are you sure to drop this Collection?", TextType.DropCollectionConfirm);
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage)) return false;
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
            return OperationHelper.DrapCollection(strCollection);
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool RenameCollection(TreeNode node)
        {
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
            string strNewCollectionName = MyMessageBox.ShowInput(
                    GuiConfig.GetText("Please input new collection name：", TextType.RenameCollectionInput),
                    GuiConfig.GetText("Rename collection", TextType.RenameCollection), strCollection);
            if (string.IsNullOrEmpty(strNewCollectionName)) return false;
            return OperationHelper.RenameCollection(strCollection, strNewCollectionName);
        }

    }
}
