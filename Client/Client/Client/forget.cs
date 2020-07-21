using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocol;
namespace Client
{
    public partial class forget : Form
    {
        public forget()
        {
            InitializeComponent();
            qq = new ProtocolQQ();
        }
        public UserLogin user;
        ProtocolQQ qq;
        private void ZC_Click(object sender, EventArgs e)
        {
            if (psw.Text.Trim() == "")
            {
                for (int i = 0; i < 100; i++)
                {
                    psw.BackColor = Color.FromArgb(200, 255, 255, 255);
                }
                psw.BackColor = Color.FromArgb(55, 255, 255, 255);
                return;

            }
            if (pswPlus.Text.Trim() == "")
            {
                for (int i = 0; i < 100; i++)
                {
                    pswPlus.BackColor = Color.FromArgb(200, 255, 255, 255);
                }
                pswPlus.BackColor = Color.FromArgb(55, 255, 255, 255);
                return;
            }
            if (psw.Text.Trim() != pswPlus.Text.Trim())
            {
                MessageBox.Show("两次密码不一致！", "提示");
                return;
            }
            user.Pwd = psw.Text.Trim();
            qq.mode = 0;
            qq.ope = 3;
            qq.data = user;
            Variable.client.SendMsg(qq);
        }
        //关闭窗口
        private void QX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClosePic_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //最小化窗口
        private void minBoxPic_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        Point before;
        bool isMove = false;
        private void forget_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void forget_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left+e.X-before.X,this.Top+e.Y-before.Y);
        }

        private void forget_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}
