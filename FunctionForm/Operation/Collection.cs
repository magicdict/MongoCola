using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Operation
{
    public class Collection
    {
        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool DropCollection(TreeNode node)
        {
            var strTitle = GuiConfig.GetText("Drop Collection", TextType.DropCollection);
            var strMessage = GuiConfig.GetText("Are you sure to drop this Collection?", TextType.DropCollectionConfirm);
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage)) return false;
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int) EnumMgr.PathLevel.Collection];
            return Operater.DrapCollection(strCollection);
        }

        /// <summary>
        ///     重命名
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string RenameCollection(TreeNode node)
        {
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int) EnumMgr.PathLevel.Collection];
            var strNewCollectionName = MyMessageBox.ShowInput(
                GuiConfig.GetText("Please input new collection name：", TextType.RenameCollectionInput),
                GuiConfig.GetText("Rename collection", TextType.RenameCollection), strCollection);
            if (string.IsNullOrEmpty(strNewCollectionName)) return string.Empty;
            if (Operater.RenameCollection(strCollection, strNewCollectionName))
            {
                return strNewCollectionName;
            }
            return string.Empty;
        }
    }
}