using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public partial class ctlMongodump : UserControl
    {
        public delegate void CommandChangedEventHandler(string strCommandLine);
        public event CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.struMongodump MongodumpCommand = new MongodbDosCommand.struMongodump();
        public ctlMongodump()
        {
            InitializeComponent();
        }
    }
}
