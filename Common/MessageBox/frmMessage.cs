using System;
using System.Drawing;
using System.Windows.Forms;

namespace MongoCola
{
    public partial class frmMesssage : Form
    {
        /// <summary>
        ///     Is Show Details
        /// </summary>
        private Boolean _ShowDetails;

        internal frmMesssage()
        {
            InitializeComponent();
            //系统图标
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        ///     Show Info
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Details">Details</param>
        /// <param name="IsShowDetails">Is Show Details</param>
        internal void SetMessage(String Message, String Details, Boolean IsShowDetails)
        {
            lblMessage.Text = Message;
            txtException.Text = Details;
            txtException.Select(0, 0);
            if (Details == String.Empty)
            {
                IsShowDetails = false;
            }
            _ShowDetails = IsShowDetails;
            Height = _ShowDetails ? 350 : 130;
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
            if (_ShowDetails)
            {
                Height = 130;
                panForBgcolor.BringToFront();
            }
            else
            {
                Height = 350;
            }
            _ShowDetails = !_ShowDetails;
        }

        /// <summary>
        ///     Set Message for display
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="img"></param>
        /// <param name="Details"></param>
        internal void SetMessage(String Message, Image img, String Details)
        {
            picImage.Image = img;
            SetMessage(Message, Details, true);
        }

        /// <summary>
        ///     SetText
        /// </summary>
        /// <param name="Detail"></param>
        /// <param name="OK"></param>
        internal void SetText(String Detail, String OK)
        {
            cmdDetails.Text = Detail;
            cmdOK.Text = OK;
        }
    }
}