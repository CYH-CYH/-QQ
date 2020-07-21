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
    
    public partial class Main : Form
    {
        TextBox_tm tm;

        public Main()
        {
            InitializeComponent();
            ShowMyTextBox();
          
            this.tm.Click += new System.EventHandler(this.tm_Click);
            //70为行距，120为列距（跟图片大小有关）
            PublicClass.SendMessage(this.friendLis.Handle, PublicClass.LVM_SETICONAPACING, 0, 0x10000 * 70 + 130);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            #region 自己的代码
            //%%%%%%%%%%%%%%%%%%%%%%%%%
            My();
            //%%%%%%%%%%%%%%%%%%%%%%%%%
            ShowFriends();
            

            this.Controls.Add(tm);

            tm.Show();

            signRichBox.Hide();
            
            #endregion

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
            pictureBox28.Visible = false;
            pictureBox29.Visible = false;
            pictureBox30.Visible = false;
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;
            pictureBox33.Visible = false;
            //天气窗口
            tianqi = new TianQi();
            tianqi.Location = new Point(this.Location.X+this.Width + 6+500, this.Location.Y);
        }
        //这个现在可以拖动了
        void ShowMyTextBox()
        {
            Font font = new Font("楷体",14);
            tm = new TextBox_tm();
            tm.Location = new Point(signRichBox.Location.X, signRichBox.Location.Y+5);
            tm.Size = signRichBox.Size;
            tm.BorderStyle = BorderStyle.None;
            tm.Font = font;
            tm.Text = "搜索";
            

        }
       //显示好友列表-----网络编码
        private void ShowFriends()
        {
            //string status="[离线]";
            friendLis.Clear();
            int i = friendLis.Items.Count;
            foreach (var F in Variable.friends)
            {
                if (F.Flag == 0)
                {
                    //status = "[在线]";
                }
                //肯定有问题
                friendLis.Items.Add(F.ID,F.NickName,F.HeadID);
                friendLis.Items[i].Name = F.ID;
                //仅仅把他加入了一个分组里面
               friendLis.Items[i].Group = friendLis.Groups[0];
                i++;

            }
        }
        //SHOW自己---网络编码
        private void My()
        {
            button15.Text = Variable.user.Sign.Trim();
            myHead.BackgroundImage = headImg.Images[Variable.user.HeadId];
            nameBut.Text = Variable.user.NickName;
            if (Variable.user.NickName.Trim() != "")
            {
               sign.Text = Variable.user.NickName.Trim();
            }

        }
        //聊天窗体对象
        Chat chatForm;
        //好友对象
        Friend friend;
        private void friendLis_DoubleClick(object sender, EventArgs e)
        {
            //是否有选中项
            if (friendLis.SelectedItems.Count > 0)
            {
                //聊天窗体是否为空
                if (chatForm == null)
                {
                    chatForm = new Chat();//创建聊天窗体对象
                    friend = PublicFun.GetFriend(friendLis.SelectedItems[0].Name);
                    chatForm.nickName = friend.NickName;
                    chatForm.friendID = friend.ID;
                    
                    chatForm.Show();
                    chatForm = null;   

                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        private void tm_Click(object sender, EventArgs e)
        {
            tm.Hide();
            signRichBox.Show();
        }
        //忘记改名字了，这个是哪个个性签名的按钮
        private void button15_Click(object sender, EventArgs e)
        {
           button15.Hide();
            sign.Visible = true;
           
        }

        private void button15_MouseHover(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderSize = 1;
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderSize = 1;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderSize = 0;
        }
        //最小化窗体
        private void minBut_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗体
        }

        private void closeBut_Click(object sender, EventArgs e)
        {
            //???????
            //差一个下线消息！！！
            ProtocolQQ qq=new ProtocolQQ();
            qq.mode = 3;
            qq.ope = 0;
            qq.data = null;
            Variable.client.SendMsg(qq);
            Application.ExitThread();//退出当前应用程序
        }
       
        private void kjBut_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            kjBut.BackgroundImage = Properties.Resources.main_69;
        }

        private void kjBut_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            kjBut.BackgroundImage = Properties.Resources.main_kongjian;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            button1.BackgroundImage = Properties.Resources.main_pifu_1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            button1.BackgroundImage = Properties.Resources.main_pifu;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            button2.BackgroundImage = Properties.Resources.main_72;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            button2.BackgroundImage = Properties.Resources.main_3;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            button3.BackgroundImage = Properties.Resources.main_70;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            button3.BackgroundImage = Properties.Resources.main_youxiang;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            button4.BackgroundImage = Properties.Resources.main_71;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            button4.BackgroundImage = Properties.Resources.main_5;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            button5.BackgroundImage = Properties.Resources.main_6_1;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            button5.BackgroundImage = Properties.Resources.main_6;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            button6.BackgroundImage = Properties.Resources.main_shangcheng_1;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            button6.BackgroundImage = Properties.Resources.main_shangcheng;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            button7.BackgroundImage = Properties.Resources.main_7_1png;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            button7.BackgroundImage = Properties.Resources.main_7;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Visible = true;
            button8.BackgroundImage = Properties.Resources.main_9_1;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.Visible = false;
            button8.BackgroundImage = Properties.Resources.main_9;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Visible = true;
            button9.BackgroundImage = Properties.Resources.main_10_1;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Visible = false;
            button9.BackgroundImage = Properties.Resources.main_10;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            button10.BackgroundImage = Properties.Resources.main_11_1;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            button10.BackgroundImage = Properties.Resources.main_11;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            button11.BackgroundImage = Properties.Resources.main_29;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            button11.BackgroundImage = Properties.Resources.main_28;
        }

        private void minBut_MouseEnter(object sender, EventArgs e)
        {
            pictureBox13.Visible = true;
            minBut.BackgroundImage = Properties.Resources.mian_27;
        }

        private void minBut_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.Visible = false;
            minBut.BackgroundImage = Properties.Resources.main_26;
        }

        private void closeBut_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.Visible = true;
            closeBut.BackgroundImage = Properties.Resources.main_guanbi_1;
        }

        private void closeBut_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.Visible = false;
            closeBut.BackgroundImage = Properties.Resources.mian_guanbi;
        }
        main_1 f1 = new main_1();
        private void myHead_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.Visible = true;
           
            f1.Show();
        }

      
        private void myHead_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.Visible = false;
            
            f1.Hide();
        }
        main_2 f2 = new main_2();
        private void myHead_Click(object sender, EventArgs e)
        {
            f2.Show();
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox25.Visible = true;
            pictureBox16.BackgroundImage = Properties.Resources.main_42;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox25.Visible = false;
            pictureBox16.BackgroundImage = Properties.Resources.main_41;
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            pictureBox26.Visible = true;
            pictureBox18.BackgroundImage = Properties.Resources.main_44;
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            pictureBox26.Visible = false;
            pictureBox18.BackgroundImage = Properties.Resources.main_43;
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox27.Visible = true;
            pictureBox17.BackgroundImage = Properties.Resources.main_46;
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox27.Visible = false;
            pictureBox17.BackgroundImage = Properties.Resources.main_45;
        }

        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {
            pictureBox28.Visible = true;
            pictureBox19.BackgroundImage = Properties.Resources.main_48;
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            pictureBox28.Visible = false;
            pictureBox19.BackgroundImage = Properties.Resources.main_47;
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            pictureBox29.Visible = true;
            pictureBox20.BackgroundImage = Properties.Resources.main_50;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            pictureBox29.Visible = false;
            pictureBox20.BackgroundImage = Properties.Resources.main_49;
        }

        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            pictureBox30.Visible = true;
            pictureBox21.BackgroundImage = Properties.Resources.main_52;
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            pictureBox30.Visible = false;
            pictureBox21.BackgroundImage = Properties.Resources.main_51;
        }

        private void pictureBox22_MouseEnter(object sender, EventArgs e)
        {
            pictureBox31.Visible = true;
            pictureBox22.BackgroundImage = Properties.Resources.main_54;
        }

        private void pictureBox22_MouseLeave(object sender, EventArgs e)
        {
            pictureBox31.Visible = false;
            pictureBox22.BackgroundImage = Properties.Resources.main53;
        }

        private void pictureBox23_MouseEnter(object sender, EventArgs e)
        {
            pictureBox32.Visible = true;
            pictureBox23.BackgroundImage = Properties.Resources.main_56;
        }

        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
            pictureBox32.Visible = false;
            pictureBox23.BackgroundImage = Properties.Resources.main_55;
        }

        private void pictureBox24_MouseEnter(object sender, EventArgs e)
        {
            pictureBox33.Visible = true;
            pictureBox24.BackgroundImage = Properties.Resources.main_58;
        }

        private void pictureBox24_MouseLeave(object sender, EventArgs e)
        {
            pictureBox33.Visible = false;
            pictureBox24.BackgroundImage = Properties.Resources.main_57;
        }
        //修改个性签名
        private void sign_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //修改用户个性签名
        private void sign_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果用户按下回车---同时更新数据库
            if (e.KeyChar == '\r')
            {
                button15.Text = sign.Text.Trim();
                sign.Visible = false;
                button15.Visible = true;
                sign.Text = "";
            }

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {

        }
        //窗体移动
        //
        Point before;
        bool isMove = false;
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left + e.X - before.X, this.Top + e.Y - before.Y);
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void sign_TextChanged(object sender, EventArgs e)
        {

        }
        //显示天气
        TianQi tianqi;
        bool isShow;
        private void TianQi_MouseEnter(object sender, EventArgs e)
        {
            isShow = true;
            
            tianqi.Show();
           
        }

        private void Wt_MouseLeave(object sender, EventArgs e)
        {
            if (isShow)
            {
                tianqi.Hide();
            }
            isShow = false;
        }

        private void TianQi_MouseMove(object sender, MouseEventArgs e)
        {
        
        }

        private void TianQi_MouseHover(object sender, EventArgs e)
        {
            isShow = true;

            tianqi.Show();


        }
    }
}

