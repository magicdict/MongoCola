using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class ctlIndexCreate : UserControl
    {
        public Boolean IsAscendingKey {
            get { return radAscendingKey.Checked; }
        }
        public String KeyName {
            get { return txtKeyName.Text; }
        }
        public ctlIndexCreate()
        {
            InitializeComponent();
        }
    }
}
