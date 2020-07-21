using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class main_1 : Form
    {
        public main_1()
        {
            InitializeComponent();
            label1.Text = Variable.user.NickName.Trim();
        }
    }
}
