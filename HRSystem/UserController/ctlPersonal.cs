using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRSystem.UserController
{
    public partial class ctlPersonal : UserControl
    {
        public ctlPersonal()
        {
            InitializeComponent();
        }
        public string Department
        {
            set
            {
                lblDepartment.Text = value;
            }
        }
        /// <summary>
        /// Photo
        /// </summary>
        public Image imgFace
        {
            set
            {
                picFace.Image = value;
            }
        }
        /// <summary>
        /// Position of Manger
        /// </summary>
        public string Position
        {
            set
            {
                lblPosition.Text = value;
            }
        }
        /// <summary>
        /// Name Of Manger
        /// </summary>
        public string PersonName
        {
            set
            {
                lblName.Text = value;
            }

        }
    }
}
