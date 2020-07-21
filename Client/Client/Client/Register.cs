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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        //点击注册事件
        private void ZC_Click(object sender, EventArgs e)
        {
            
            if (psw.Text.Trim() == "" || pswPlus.Text.Trim()==""||name.Text.Trim()=="")
            {
                MessageBox.Show("昵称或者密码设置为空，请重新输入","提示");
            }
            if (psw.Text.Trim() != pswPlus.Text.Trim())
            {
                MessageBox.Show("两次密码输入不一致，请重新输入");
                pswPlus.Focus();
            }
            else
            {
                ProtocolQQ qq = new ProtocolQQ();
                Regr reger = new Regr();
                qq.mode = 0;
                qq.ope = 1;
                reger.NickName = name.Text.Trim();
                reger.PSW = psw.Text.Trim();
                qq.data = reger;
                Variable.client.SendMsg(qq);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             this.Close();
        }
        //关闭窗口
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //最小化窗口
        private void minBoxPic_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        //窗体移动
        //
        Point before;
        bool isMove = false;
        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void Register_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left + e.X - before.X, this.Top + e.Y - before.Y);
        }

        private void Register_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
