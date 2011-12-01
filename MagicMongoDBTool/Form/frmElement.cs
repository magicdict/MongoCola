using System;
using MagicMongoDBTool.Module;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmElement : QLFUI.QLFForm
    {
        /// <summary>
        /// 是否为更新模式
        /// </summary>
        private Boolean _IsUpdateMode = false;
        /// <summary>
        /// 路径
        /// </summary>
        private String _FullPath = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        private TreeNode _SelectNode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsUpdateMode"></param>
        /// <param name="FullPath"></param>
        public frmElement(Boolean IsUpdateMode, TreeNode SelectNode)
        {
            InitializeComponent();
            _IsUpdateMode = IsUpdateMode;
            _FullPath = SelectNode.FullPath;
            _SelectNode = SelectNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmElement_Load(object sender, EventArgs e)
        {
            if (_IsUpdateMode)
            {
                AddBsonElement.switchToUpdateMode();
                AddBsonElement.Element = MongoDBHelper.GetElementFromPath(_FullPath); 
            }
            if (!SystemManager.IsUseDefaultLanguage())
            {
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Cancel);
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (_IsUpdateMode)
            {
                MongoDBHelper.ModifyElement(_FullPath, AddBsonElement.Element.Value);
                _SelectNode.Text = AddBsonElement.Element.Name + ":" + AddBsonElement.Element.Value.ToString();
            }
            else
            {
                MongoDBHelper.AddElement(_FullPath, AddBsonElement.Element);
                _SelectNode.Nodes.Add(new TreeNode(AddBsonElement.Element.Name + ":" + AddBsonElement.Element.Value.ToString()));
            }
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
