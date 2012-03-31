using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmMesssage : Form
    {
        /// <summary>
        /// Is Show Details
        /// </summary>
        private Boolean _ShowDetails = false;
        /// <summary>
        /// Show Info
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Details">Details</param>
        /// <param name="IsShowDetails">Is Show Details</param>
        internal void SetMessage(String Message, String Details, Boolean IsShowDetails = true)
        {
            this.lblMessage.Text = Message;
            this.txtException.Text = Details;
            this.txtException.Select(0, 0);
            if (Details == String.Empty)
            {
                IsShowDetails = false;
            }
            _ShowDetails = IsShowDetails;
            if (_ShowDetails)
            {
                this.Height = 350;
            }
            else
            {
                this.Height = 130;
            }
        }
        internal frmMesssage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Swith details mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDetails_Click(object sender, EventArgs e)
        {
            if (_ShowDetails)
            {
                this.Height = 130;
            }
            else
            {
                this.Height = 350;
            }
            _ShowDetails = !_ShowDetails;
        }
        /// <summary>
        /// Set Message for display
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="img"></param>
        /// <param name="Details"></param>
        internal void SetMessage(String Message, System.Drawing.Image img, String Details)
        {
            this.picImage.Image = img;
            SetMessage(Message, Details);
        }
        /// <summary>
        /// Set Text
        /// </summary>
        /// <param name="Yes"></param>
        /// <param name="No"></param>
        internal void SetText(String Detail, String OK)
        {
            cmdDetails.Text = Detail;
            cmdOK.Text = OK;
        }
    }
}
