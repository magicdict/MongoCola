using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoGUIView
{
    public partial class FrmElement : Form
    {
        /// <summary>
        ///     路径
        /// </summary>
        private readonly string _fullPath = string.Empty;

        /// <summary>
        /// </summary>
        private readonly bool _isElement = true;

        /// <summary>
        ///     是否为更新模式
        /// </summary>
        private readonly bool _isUpdateMode;

        /// <summary>
        /// </summary>
        private readonly TreeNode _selectNode;

        /// <summary>
        /// </summary>
        /// <param name="isUpdateMode"></param>
        /// <param name="selectNode"></param>
        /// <param name="isElement"></param>
        public FrmElement(bool isUpdateMode, TreeNode selectNode, bool isElement)
        {
            InitializeComponent();
            _isUpdateMode = isUpdateMode;
            _fullPath = selectNode.FullPath;
            _selectNode = selectNode;
            _isElement = isElement;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmElement_Load(object sender, EventArgs e)
        {
            if (_isUpdateMode)
            {
                AddBsonElement.SwitchToUpdateMode();
                AddBsonElement.SetElement(_selectNode.Tag);
            }
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
            }
            if (!_isElement)
            {
                //TODO:在这个模式，数组里面暂时不能添加数组或者文档
                AddBsonElement.SwitchToValueMode();
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
                    ElementHelper.ModifyElement(_fullPath, AddBsonElement.GetElement().Value,
                        (BsonElement) _selectNode.Tag,
                        RuntimeMongoDbContext.CurrentDocument,
                        RuntimeMongoDbContext.GetCurrentCollection());
                    //元素的场合，Tag直接放入元素
                    _selectNode.Tag = AddBsonElement.GetElement();
                }
                else
                {
                    ElementHelper.ModifyArrayValue(_fullPath, AddBsonElement.GetElement().Value, _selectNode.Index,
                        RuntimeMongoDbContext.CurrentDocument,
                        RuntimeMongoDbContext.GetCurrentCollection());
                    _selectNode.Tag = AddBsonElement.GetElement().Value;
                }
                _selectNode.Text = string.IsNullOrEmpty(AddBsonElement.GetElement().Name)
                    ? string.Empty
                    : AddBsonElement.GetElement().Name;
            }
            else
            {
                var addMessage = string.Empty;
                if (_isElement)
                {
                    addMessage = ElementHelper.AddElement(_fullPath, AddBsonElement.GetElement(),
                        RuntimeMongoDbContext.CurrentDocument,
                        RuntimeMongoDbContext.GetCurrentCollection());
                }
                else
                {
                    ElementHelper.AddArrayValue(_fullPath, AddBsonElement.GetElement().Value,
                        RuntimeMongoDbContext.CurrentDocument,
                        RuntimeMongoDbContext.GetCurrentCollection());
                }
                if (!string.IsNullOrEmpty(addMessage))
                {
                    MyMessageBox.ShowMessage("Exception", addMessage);
                    return;
                }
                TreeNode newNode;
                newNode = string.IsNullOrEmpty(AddBsonElement.GetElement().Name)
                    ? new TreeNode()
                    : new TreeNode(AddBsonElement.GetElement().Name);
                if (_isElement)
                {
                    newNode.Tag = AddBsonElement.GetElement();
                }
                else
                {
                    newNode.Tag = AddBsonElement.GetElement().Value;
                }
                _selectNode.Nodes.Add(newNode);
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