using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocol;

namespace Client
{
    public partial class Chat : Form
    {

        public string friendID;//当前聊天的好友号码
        public string nickName;//当前聊天的好友昵称
        public int headID;//当前聊天的好友头像ID   
        ProtocolQQ qq;
        UTU utu;
        
        public Chat()
        {
            InitializeComponent();
           #region 不可以删除但是单独运行，请把它注释掉
            qq = new ProtocolQQ();
            utu = new UTU();
            #endregion

        }

        private void Chat_Load(object sender, EventArgs e)
        {
           #region 不可以删除但是单独运行，请把它注释掉
            //将窗体中的publiRichBox加入
            PublicFun.AddRichTalk(friendID,this.talkRich);
            //显示好友列表
            this.friendNIckName.Text = nickName;

            qq.mode = 1;
            utu.ReceID = friendID;
            utu.SendID = Variable.user.ID;
            qq.data = utu;
            #endregion

        }
        
  
        //像好友发送消息
        private void send_Click(object sender, EventArgs e)
        {
            if (qq.ope == 0)
            {
                if (talk.Text == "")
                {
                    //这里可以用一个窗口---记住！！！
                    return;
                    
                }
                else
                {
                    Str strMsg = new Str();
                    strMsg.Message = talk.Text.Trim();
                    utu.Msg = strMsg;
                    utu.Time = DateTime.Now;
                    //把消息框画出来---展示还，还没有画出来
                    talkRich.ReadOnly = false;
                    
                    talkRich.AppendText(nickName + "\r\n" + strMsg.Message + "\r\n" + utu.Time.ToString());
                    talkRich.ReadOnly = true;
                }
                

            }
            Variable.client.SendMsg(qq);
            //清空文本框
            talk.Clear();
        }

        private void wenJian_Click(object sender, EventArgs e)
        {
            qq.ope = 1;
        }

        private void douPin_Click(object sender, EventArgs e)
        {
            qq.ope = 3;
        }

        private void talk_TextChanged(object sender, EventArgs e)
        {
            if (talk.Text != "")
            {
                qq.ope = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            qq.ope = 2;
        }
        bool test = false;
        private void jilu_Click(object sender, EventArgs e)
        {

            if (test == false)
            {
                if (talkRich.Size.Width > 500)
                {
                    pictureBox26_Click(this,e);
                }
                pictureBox2.Visible = false;
                this.Width = 730;
                pictureBox18.Left += 155;
                pictureBox19.Left += 155;
                pictureBox20.Left += 155;
                pictureBox21.Left += 100;
                friendNIckName.Left += 100;
                test = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                button4.Visible = true;
                pictureBox27.Visible = true;
                pictureBox28.Visible = true;
                pictureBox29.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
                button4.Visible = false;
                pictureBox27.Visible = false;
                pictureBox28.Visible = false;
                pictureBox29.Visible = false;
                pictureBox2.Visible = false;
                this.Width = 578;
                pictureBox2.Visible = true;
                pictureBox18.Left -= 155;
                pictureBox19.Left -= 155;
                pictureBox20.Left -= 155;
                pictureBox21.Left -= 100;
                friendNIckName.Left -= 100;
                test = false;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
                pictureBox17.Visible = true;
                pictureBox16.Visible = false;
                pictureBox12.Visible = true;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                pictureBox15.Visible = true;
            if (talkRich.Size.Width < 500)
            {
                pictureBox10.Left = 162;
                pictureBox11.Left = 201;
                pictureBox12.Left = 241;
                pictureBox13.Left = 281;
                pictureBox14.Left = 323;
                pictureBox15.Left = 365;
                pictureBox16.Left = pictureBox17.Left = 406;
            }
            else
            {
                pictureBox10.Left = 162+133;
                pictureBox11.Left = 201+133;
                pictureBox12.Left = 241+133;
                pictureBox13.Left = 281+133;
                pictureBox14.Left = 323+133;
                pictureBox15.Left = 365+133;
                pictureBox16.Left = pictureBox17.Left = 539;
            }

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;
            pictureBox16.Visible = true;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
                pictureBox10.Left += 161;
                pictureBox11.Left += 164;
        }

        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            if (talkRich.Size.Width < 500) { pictureBox5.Left = 235; }
            else { pictureBox5.Left = 235+133; }
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            if (talkRich.Size.Width < 500) { pictureBox7.Left = 317; }
            else { pictureBox7.Left = 317 + 133; }
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
        }

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            if (talkRich.Size.Width < 500) { pictureBox8.Left = 272; }
            else { pictureBox8.Left = 272 + 133; }
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox22.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox22.Visible = false;
        }

        private void jianCai_MouseEnter(object sender, EventArgs e)
        {
            pictureBox23.Visible = true;
        }

        private void jianCai_MouseLeave(object sender, EventArgs e)
        {
            pictureBox23.Visible = false;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox24.Visible = true;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox24.Visible = false;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (test == true)
            {
                jilu_Click(this, e);
            }
            pictureBox2.Visible = false;
            talkRich.Size = new Size(576,233);
            close.Left = 391;
            send.Left = 472;
            jilu.Left = 539;
            if (pictureBox16.Visible == true)
            {
                pictureBox10.Left = 162 + 133 + 161;
                pictureBox11.Left = 201 + 133 + 164;
                pictureBox16.Left = pictureBox17.Left = 539;
            }
            else
            {
                pictureBox10.Left += 133;
                pictureBox11.Left += 133;
                pictureBox12.Left += 133;
                pictureBox13.Left += 133;
                pictureBox14.Left += 133;
                pictureBox15.Left += 133;
                pictureBox16.Left = pictureBox17.Left = 539;
            }
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            if (close.Left != 391)
            {
                pictureBox25.Visible = true;
            }
        }
        private void pictureBox25_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox25.Visible = false;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            talkRich.Size = new Size(434, 233);
            close.Left = 260;
            send.Left = 341;
            jilu.Left = 406;
            if (pictureBox16.Visible == true)
            {
                pictureBox10.Left = 162 + 161;
                pictureBox11.Left = 201 + 164;
                pictureBox16.Left = pictureBox17.Left = 406;
            }
            else
            {
                pictureBox10.Left -= 133;
                pictureBox11.Left -= 133;
                pictureBox12.Left -= 133;
                pictureBox13.Left -= 133;
                pictureBox14.Left -= 133;
                pictureBox15.Left -= 133;
            }
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            if (close.Left == 391)
            {
                pictureBox26.Visible = true;
            }
        }

        private void pictureBox26_MouseLeave(object sender, EventArgs e)
        {
            pictureBox26.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        void ss(Button a)
        {
            a.ForeColor = Color.Black;
            a.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(39,140,222);
            button1.ForeColor = Color.White;
            ss(button2);
            ss(button3);
            ss(button4);
            ss(button5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(39, 140, 222);
            button2.ForeColor = Color.White;
            ss(button1);
            ss(button3);
            ss(button4);
            ss(button5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(39, 140, 222);
            button3.ForeColor = Color.White;
            ss(button2);
            ss(button1);
            ss(button4);
            ss(button5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(39, 140, 222);
            button5.ForeColor = Color.White;
            ss(button2);
            ss(button3);
            ss(button4);
            ss(button1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(39, 140, 222);
            button4.ForeColor = Color.White;
            ss(button2);
            ss(button3);
            ss(button5);
            ss(button1);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //窗体移动
        //
        Point before;
        bool isMove;
        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void Chat_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left + e.X - before.X, this.Top + e.Y - before.Y);
        }

        private void Chat_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}
