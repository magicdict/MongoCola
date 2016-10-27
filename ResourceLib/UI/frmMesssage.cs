using System;
using System.Drawing;
using System.Windows.Forms;
using ResourceLib.Method;

namespace ResourceLib.UI
{
    public partial class frmMesssage : Form
    {
        /// <summary>
        ///     Is Show Details
        /// </summary>
        private bool _showDetails;

        internal frmMesssage()
        {
            InitializeComponent();
            //系统图标
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     Show Info
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="details">Details</param>
        /// <param name="isShowDetails">Is Show Details</param>
        internal void SetMessage(string message, string details, bool isShowDetails)
        {
            lblMessage.Text = message;
            txtException.Text = details;
            txtException.Select(0, 0);
            if (string.IsNullOrEmpty(details))
            {
                isShowDetails = false;
            } else
            {
                isShowDetails = true;
            }
            _showDetails = isShowDetails;
            txtException.Visible = isShowDetails;
            cmdDetails.Visible = isShowDetails;
            Height = _showDetails ? 350 : 150;
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Swith details mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDetails_Click(object sender, EventArgs e)
        {
            if (_showDetails)
            {
                Height = 130;
                panForBgcolor.BringToFront();
            }
            else
            {
                Height = 350;
            }
            _showDetails = !_showDetails;
        }

        /// <summary>
        ///     Set Message for display
        /// </summary>
        /// <param name="message"></param>
        /// <param name="img"></param>
        /// <param name="details"></param>
        internal void SetMessage(string message, Image img, string details)
        {
            picImage.Image = img;
            SetMessage(message, details, true);
        }

        /// <summary>
        ///     SetText
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="ok"></param>
        internal void SetText(string detail, string ok)
        {
            cmdDetails.Text = detail;
            cmdOK.Text = ok;
        }
    }
}