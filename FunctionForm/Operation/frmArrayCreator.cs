using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.Method;

namespace FunctionForm.Operation
{
    public partial class frmArrayCreator : Form
    {
        /// <summary>
        ///     BsonArray
        /// </summary>
        public BsonArray mBsonArray;

        public frmArrayCreator()
        {
            GuiConfig.Translateform(this);
            InitializeComponent();
        }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayPanel.AddBsonValueItem();
        }

        /// <summary>
        ///     清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ArrayPanel.Clear();
        }

        /// <summary>
        ///     确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            mBsonArray = ArrayPanel.GetBsonArray();
            Close();
        }

        private void frmArrayCreator_Load(object sender, EventArgs e)
        {

        }
    }
}