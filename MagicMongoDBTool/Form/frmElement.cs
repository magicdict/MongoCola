using System;
using MagicMongoDBTool.Module;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class frmElement : Form
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
                AddBsonElement.setElement(MongoDBHelper.GetElementOrValueFromPath(_FullPath));
            }
            if (!SystemManager.IsUseDefaultLanguage())
            {
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);
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
                MongoDBHelper.ModifyElement(_FullPath, AddBsonElement.getElement().Value, _SelectNode.Index);
                if (String.IsNullOrEmpty(AddBsonElement.getElement().Name))
                {
                    _SelectNode.Text = AddBsonElement.getElement().Value.ToString();
                }
                else
                {
                    _SelectNode.Text = AddBsonElement.getElement().Name + ":" + AddBsonElement.getElement().Value.ToString();
                }
            }
            else
            {
                MongoDBHelper.AddElement(_FullPath, AddBsonElement.getElement());
                TreeNode NewNode;
                if (String.IsNullOrEmpty(AddBsonElement.getElement().Name))
                {
                    NewNode = new TreeNode(AddBsonElement.getElement().Value.ToString());
                }
                else
                {
                    NewNode = new TreeNode(AddBsonElement.getElement().Name + ":" + AddBsonElement.getElement().Value.ToString());
                }
                _SelectNode.Nodes.Add(NewNode);
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
