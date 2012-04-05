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
        /// 
        /// </summary>
        private Boolean _IsElement = true;
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
        public frmElement(Boolean IsUpdateMode, TreeNode SelectNode, Boolean IsElement)
        {
            InitializeComponent();
            _IsUpdateMode = IsUpdateMode;
            _FullPath = SelectNode.FullPath;
            _SelectNode = SelectNode;
            _IsElement = IsElement;
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
                AddBsonElement.setElement(_SelectNode.Tag);
            }
            if (!SystemManager.IsUseDefaultLanguage())
            {
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);
            }
            if (!_IsElement)
            {
                //TODO:在这个模式，数组里面暂时不能添加数组或者文档
                AddBsonElement.switchToValueMode();
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
                if (_IsElement)
                {
                    MongoDBHelper.ModifyElement(_FullPath, AddBsonElement.getElement().Value, (BsonElement)_SelectNode.Tag);
                }
                else
                {
                    MongoDBHelper.ModifyArrayValue(_FullPath, AddBsonElement.getElement().Value, _SelectNode.Index);
                }
                if (String.IsNullOrEmpty(AddBsonElement.getElement().Name))
                {
                    _SelectNode.Text = MongoDBHelper.ConvertToString(AddBsonElement.getElement().Value);
                }
                else
                {
                    _SelectNode.Text = AddBsonElement.getElement().Name + ":" + MongoDBHelper.ConvertToString(AddBsonElement.getElement().Value);
                }
            }
            else
            {
                String AddMessage = String.Empty;
                if (_IsElement)
                {
                    AddMessage = MongoDBHelper.AddElement(_FullPath, AddBsonElement.getElement());
                }
                else
                {
                    MongoDBHelper.AddArrayValue(_FullPath, AddBsonElement.getElement().Value);
                }
                if (!String.IsNullOrEmpty(AddMessage))
                {
                    MyMessageBox.ShowMessage("Exception", AddMessage);
                    return;
                }
                TreeNode NewNode;
                if (String.IsNullOrEmpty(AddBsonElement.getElement().Name))
                {
                    //Array Value
                    NewNode = new TreeNode(MongoDBHelper.ConvertToString(AddBsonElement.getElement().Value));
                }
                else
                {
                    //Document Element
                    if (AddBsonElement.getElement().Value.IsBsonArray)
                    {
                        NewNode = new TreeNode(AddBsonElement.getElement().Name + MongoDBHelper.Array_Mark);
                    }
                    else
                    {
                        if (AddBsonElement.getElement().Value.IsBsonDocument)
                        {
                            NewNode = new TreeNode(AddBsonElement.getElement().Name);
                        }
                        else
                        {
                            NewNode = new TreeNode(AddBsonElement.getElement().Name + ":" +
                                                   MongoDBHelper.ConvertToString(AddBsonElement.getElement().Value));
                        }
                    }
                }
                if (_IsElement)
                {
                    NewNode.Tag = AddBsonElement.getElement();
                }
                else
                {
                    NewNode.Tag = AddBsonElement.getElement().Value;
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
