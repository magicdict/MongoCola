using System;
using System.Windows.Forms;
using Common.UI;
using MongoDB.Bson;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Utility;

namespace MongoGUIView
{
    public partial class frmElement : Form
    {
        /// <summary>
        ///     路径
        /// </summary>
        private readonly String _FullPath = String.Empty;

        /// <summary>
        /// </summary>
        private readonly Boolean _isElement = true;

        /// <summary>
        ///     是否为更新模式
        /// </summary>
        private readonly Boolean _isUpdateMode;

        /// <summary>
        /// </summary>
        private readonly TreeNode _selectNode;

        /// <summary>
        /// </summary>
        /// <param name="IsUpdateMode"></param>
        /// <param name="SelectNode"></param>
        /// <param name="IsElement"></param>
        public frmElement(Boolean IsUpdateMode, TreeNode SelectNode, Boolean IsElement)
        {
            InitializeComponent();
            _isUpdateMode = IsUpdateMode;
            //TODO:
            _FullPath = SelectNode.FullPath;
            _selectNode = SelectNode;
            _isElement = IsElement;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmElement_Load(object sender, EventArgs e)
        {
            if (_isUpdateMode)
            {
                AddBsonElement.switchToUpdateMode();
                AddBsonElement.setElement(_selectNode.Tag);
            }
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                cmdOK.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
                cmdCancel.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Cancel);
            }
            if (!_isElement)
            {
                //TODO:在这个模式，数组里面暂时不能添加数组或者文档
                AddBsonElement.switchToValueMode();
            }
        }

        /// <summary>
        ///     确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (_isUpdateMode)
            {
                if (_isElement)
                {
                    ElementHelper.ModifyElement(_FullPath, AddBsonElement.getElement().Value,
                        (BsonElement) _selectNode.Tag,
                        RuntimeMongoDBContext.CurrentDocument,
                        RuntimeMongoDBContext.GetCurrentCollection());
                }
                else
                {
                    ElementHelper.ModifyArrayValue(_FullPath, AddBsonElement.getElement().Value, _selectNode.Index,
                        RuntimeMongoDBContext.CurrentDocument,
                        RuntimeMongoDBContext.GetCurrentCollection());
                }
                _selectNode.Text = String.IsNullOrEmpty(AddBsonElement.getElement().Name)
                    ? String.Empty
                    : AddBsonElement.getElement().Name;
            }
            else
            {
                var AddMessage = String.Empty;
                if (_isElement)
                {
                    AddMessage = ElementHelper.AddElement(_FullPath, AddBsonElement.getElement(),
                        RuntimeMongoDBContext.CurrentDocument,
                        RuntimeMongoDBContext.GetCurrentCollection());
                }
                else
                {
                    ElementHelper.AddArrayValue(_FullPath, AddBsonElement.getElement().Value,
                        RuntimeMongoDBContext.CurrentDocument,
                        RuntimeMongoDBContext.GetCurrentCollection());
                }
                if (!String.IsNullOrEmpty(AddMessage))
                {
                    MyMessageBox.ShowMessage("Exception", AddMessage);
                    return;
                }
                TreeNode NewNode;
                NewNode = String.IsNullOrEmpty(AddBsonElement.getElement().Name)
                    ? new TreeNode()
                    : new TreeNode(AddBsonElement.getElement().Name);
                if (_isElement)
                {
                    NewNode.Tag = AddBsonElement.getElement();
                }
                else
                {
                    NewNode.Tag = AddBsonElement.getElement().Value;
                }
                _selectNode.Nodes.Add(NewNode);
            }
            Close();
        }

        /// <summary>
        ///     取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}