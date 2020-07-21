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
    public partial class main_2 : Form
    {
        public main_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗体
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            button1.BackgroundImage = Properties.Resources.main_36;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            button1.BackgroundImage = Properties.Resources.main_35;
        }

        private void main_2_Load(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            button2.BackgroundImage = Properties.Resources.main_38;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            button2.BackgroundImage = Properties.Resources.main_37;
        }
    }
}
