using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocol;
namespace Client
{
    public partial class Login : Form
    {
        ProtocolQQ protocolqq;
        clientUser user;
        //记录点击了多少次登录按钮
       // int record = 1;

        //当ID和psw都为空的时候，文本框上面的Text
        string idText = "QQ号码/手机/邮箱";
        string pswText = "密码";

        //原型图片控件
        MyPicture headPic;
        
        //用户登录
        UserLogin userLogin;
        //本地用户记录
        LocMess l;
        //本地用户字典
        Dictionary<string, LocMess> ls;

        public Login()
        {
            InitializeComponent();
            protocolqq = new ProtocolQQ();
            oldIdFont = idTextBox.Font;
            oldPswFont = pswTextBox.Font;

            headPic = new MyPicture();
            //新建本地用户类

            #region 记到莫乱删
            //网络套接字------ 
            user = new clientUser();
            user.Start();
            Variable.client = user;
            //建立一个用户登录对象
            userLogin = new UserLogin();
            //建立一个本地用户类
            l = new LocMess();
            ls = new Dictionary<string, LocMess>();
            #endregion
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //将已经处理好的背景图片放入数组中
            bkImageLis.LoadImg();
            //二维码移动
            left = Ewm.Left;
            ShowHeadPic();
            #region 将用户记录读出来放入用户字典
            //  读取配置文件寻找记住的用户名和密码
            FileStream fs = new FileStream("LocalMess.Bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                //二进制序列化和反序列化
                BinaryFormatter bf = new BinaryFormatter();
                //将反序列化的数据放入字典中，这个有点简单（语法）
                ls = bf.Deserialize(fs) as Dictionary<string, LocMess>;
               
                //用户非第一次登录
                //Variable.fl = false;
                fs.Close();
            }
            #endregion
        }

        private void ShowHeadPic()
        {
            headPic.Location = new Point(this.Width / 2 - 33, this.Height / 4 + 5);
            headPic.Size = new Size(65, 65);
            headPic.BorderStyle = BorderStyle.None;
            headPic.BackColor = Color.Transparent;
            headPic.BackgroundImage = Properties.Resources.addition;
            headPic.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(headPic);
            //将控件至于顶层
            headPic.BringToFront();
            headPic.Show();
        }

        //记录当前窗口的播放到哪一张图片的索引
        int i = 0;
        //控制背景图片变化的时钟
        private void BkTimer_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = bkImageLis.bk[i];
            i++;
            if (i > 110)
            {
                i = 0;
            }

        }
        //判断输入的psw回车---控制鼠标焦点
        private void pawTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //使登录按钮获得鼠标焦点
                loginBut_Click(sender, e);
            }
        }
        //判断用户输入的id，若为空则ID输入框上的信息为初始信息
        void CheckingIdTextBox()

        {

            if (idTextBox.Text == "")
            {
                idTextBox.Font = oldIdFont;
                idTextBox.Text = idText;
            }


        }
        //判断用户输入的密码，若为空则ID输入框上的信息为初始信息
        void CheckingPswTextBox()
        {
            if (pswTextBox.Text == "")
            {
                pswTextBox.Font = oldPswFont;
                pswTextBox.Text = pswText;
                pswTextBox.UseSystemPasswordChar = false;
            }
        }
        //登录

        public void loginBut_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text.Trim() == idText || idTextBox.Text.Trim() == "")
            {

                ToolTip.Show("请输入账号在登录", idTextBox);
                //这边的强制转换我暂时不清楚会不会成功
                //idTextBox_MouseDown(sender, (MouseEventArgs)e);
                if (pswTextBox.Text.Trim() == idText || pswTextBox.Text.Trim() == "")
                {
                    ToolTip.Show("请输入账号再登录", idTextBox);
                    //idTextBox_MouseDown(sender, (MouseEventArgs)e);
                }
            }
            else if (pswTextBox.Text.Trim() == pswText || pswTextBox.Text.Trim() == "")
            {
                ToolTip.Show("请输入密码再登录", idTextBox);
               // pswTextBox_MouseDown(sender, (MouseEventArgs)e);
            }
            else
            {
               
                //用户如果是第一次登录---需要验证
                if (Variable.fl)
                {
                    Y y = new Y();
                    y.Show();
                    //初始化用户名
                    y.login = this;
                    y.name = idTextBox.Text.Trim();
                    y.psw = pswTextBox.Text.Trim();
                }
                if(Variable.fl==false)
                {
                    //this.Show();
                    userLogin.Name = idTextBox.Text.Trim();
                    userLogin.Pwd = pswTextBox.Text.Trim();
                    //将用户的勾选自动登录、记住密码的操作更新到数据库
                    if (remeber.Checked)
                    {
                        userLogin.Remember = 1;
                    }
                    else
                    {
                        userLogin.Remember = 0;
                    }
                    if (AutoLogin.Checked)
                    {
                        userLogin.AutoLogin = 1;
                    }
                    else
                    {
                        userLogin.AutoLogin = 0;
                    }
                    //对登录的操作
                    protocolqq.mode = 0;
                    protocolqq.ope = 0;
                    protocolqq.data = userLogin;
                    //这个线程会睡1秒
                    user.SendMsg(protocolqq);

                    //如果登录成功
                    if (Variable.IsLogin)
                    {
                        //将该用户的用户名-密码-头像-勾选记住密码、自动登录记录到本地文件 
                        #region 将这个类写入文件
                        l = new LocMess();
                        l.I = Variable.user.ID;
                        l.H = Variable.user.HeadId;
                        //用户勾选了记住密码才想文件中存入密码
                        if (userLogin.Remember == 1)
                        {
                            l.P = userLogin.Pwd;
                        }
                        else
                        {
                            l.P = "";
                        }
                        l.R = userLogin.Remember;
                        l.A = userLogin.AutoLogin;
                        //

                        FileStream fs = new FileStream("LocalMess.bin", FileMode.Create);
                        BinaryFormatter bf = new BinaryFormatter();
                        //  选在集合中是否存在用户名 
                        if (ls.ContainsKey(l.I))
                        {
                            ls.Remove(l.I);
                        }

                        ls.Add(l.I, l);
                        //要先将l类先设为可以序列化(即在类的前面加[Serializable])
                        bf.Serialize(fs, ls);
                        //user.Password = this.PassWord.Text;
                        fs.Close();
                        #endregion
                        //显示主窗口
                        Main form = new Main();
                        this.Visible = false;
                        form.Show();
                    }

                    //用户密码错误，显示可以修改密码的pannel

                    //用户密码错误，显示可以修改密码的pannel
                    else
                    {
                        headPic.Visible = false;
                        errorPsw.Visible = true;

                    }

                }
            }

        }
      
        #region 以下代码全部为窗体上的细节设计
        //文本框的设计

        //控制字体的变量
        Font oldIdFont;
        Font oldPswFont;

        bool idTextDown = false;
        bool pswTextDown = false;

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            ToolTip.Hide(idTextBox);
            if (idTextBox.Text.Trim().Length == 5 || idTextBox.Text.Trim().Length == 9)
            {
                //尝试从用户字典中得到用户输入框上面的用户名
                if (ls.TryGetValue(idTextBox.Text.Trim(), out l))
                {
                    Variable.fl = false;
                    int term = l.H;
                    //这条路径的正确性我也不太清除
                    string path = "..//..//..//Image//head//" + term + ".bmp";
                    headPic.BackgroundImage = new Bitmap(path);
                    if (l.R == 1)
                    {
                        remeber.Checked = true;
                        //自动填充密码
                        pswTextBox.UseSystemPasswordChar = true;
                        pswTextBox.Text = l.P.Trim();
                        //
                        if (l.A == 1)
                        {
                            AutoLogin.Checked = true;
                            //直接登录
                            loginBut_Click(sender, e);
                        }
                    }
                }
                //如果是用户第一次登录这个
            }

        }

        private void idTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            ToolTip.Hide(idTextBox);
            CheckingPswTextBox();
            pswTextDown = false;
            idTextDown = true;
            pswLine.BackColor = Color.DarkGray;
            pic12.BackgroundImage = Properties.Resources.Login_120;

            pic11.BackgroundImage = Properties.Resources.Login_111;
            idLine.BackColor = Color.DeepSkyBlue;

            //如果id框中的数据任然是初始数据，那么马上清空
            if (idTextBox.Text == idText)
            {
                idTextBox.Text = "";
            }
            //鼠标按下，立马改变字体

            idTextBox.Font = new Font("微软雅黑", 12);

        }

        private void idTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (!idTextDown)
                idLine.BackColor = Color.DimGray;
        }

        private void idTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (!idTextDown)
                idLine.BackColor = Color.DarkGray;
        }

        private void pswTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            ToolTip.Hide(pswTextBox);
            CheckingIdTextBox();
            idTextDown = false;
            pswTextDown = true;

            pic12.BackgroundImage = Properties.Resources.Login_121;
            pswLine.BackColor = Color.DeepSkyBlue;

            pic11.BackgroundImage = Properties.Resources.Login_110;
            idLine.BackColor = Color.DarkGray;
            //如果id框中的数据任然是初始数据，那么马上清空
            if (pswTextBox.Text == pswText)
            {
                pswTextBox.Text = "";
            }
            //鼠标按下，立马改变字体
            pswTextBox.Font = new Font("微软雅黑", 12);
            this.pswTextBox.UseSystemPasswordChar = true;
        }

        private void pswTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (!pswTextDown)
            {
                pswLine.BackColor = Color.DimGray;
            }
        }

        private void pswTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (!pswTextDown)
            {
                pswLine.BackColor = Color.DarkGray;
            }
        }

        private void sezhipic_MouseEnter(object sender, EventArgs e)
        {
            sezhipic.BackColor = Color.FromArgb(75, 255, 255, 255);
        }


        private void sezhipic_MouseLeave(object sender, EventArgs e)
        {
            sezhipic.BackColor = Color.Transparent;
        }


        private void ClosePic_MouseEnter(object sender, EventArgs e)
        {
            ClosePic.BackColor = Color.Red;
        }


        private void ClosePic_MouseLeave(object sender, EventArgs e)
        {
            ClosePic.BackColor = Color.Transparent;
        }

        private void minBoxPic_MouseEnter(object sender, EventArgs e)
        {
            minBoxPic.BackColor = Color.FromArgb(75, 255, 255, 255);
        }

        private void minBoxPic_MouseLeave(object sender, EventArgs e)
        {
            minBoxPic.BackColor = Color.Transparent;
        }

        private void minBoxPic_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗体
        }

        private void ClosePic_Click(object sender, EventArgs e)
        {
            //让服务器端知道该用户马上下线
            ProtocolQQ qq = new ProtocolQQ();
            qq.mode = 3;
            qq.ope = 0;
            qq.data = null;
            Variable.client.SendMsg(qq);
            Application.ExitThread();//退出当前应用程序
        }

        private void pic22_MouseEnter(object sender, EventArgs e)
        {
            pic22.BackgroundImage = Properties.Resources.Login_221;
        }

        private void pic22_MouseLeave(object sender, EventArgs e)
        {
            pic22.BackgroundImage = Properties.Resources.Login_220;
        }

        private void pic22_Click(object sender, EventArgs e)
        {
            pic22.BackgroundImage = Properties.Resources.Login_223;
        }

        //注册事件发生
        private void ZCBut_MouseEnter(object sender, EventArgs e)
        {
            ZCBut.ForeColor = Color.DimGray;
        }

        private void ZCBut_MouseLeave(object sender, EventArgs e)
        {
            ZCBut.ForeColor = Color.DarkGray;
        }
        //ZC=注册
        private void ZCBut_Click(object sender, EventArgs e)
        {
            ZCBut.ForeColor = Color.DeepSkyBlue;
            Register register = new Register();
            register.Show();
        }
        //二维码
        private void EWMPic_MouseEnter(object sender, EventArgs e)
        {
            EWMPic.BackgroundImage = Properties.Resources.erweima1;
        }

        private void EWMPic_MouseLeave(object sender, EventArgs e)
        {
            EWMPic.BackgroundImage = Properties.Resources.erweima0;
        }

        private void EWMPic_Click(object sender, EventArgs e)
        {
            EWMPic.BackgroundImage = Properties.Resources.erweima2;
            panel1.Hide();
            headPic.Hide();
            picture2.Visible = true;
            this.Invalidate();
            Ewm.Visible = true;
            fhBut.Location = new Point(loginBut.Location.Y, loginBut.Location.Y + 100);
            fhBut.Visible = true;
        }
        #endregion


        //是点击二维码发生的事件
        bool isRight = false;
        bool isLeft = false;
        int left;
        int j = 0;

        private void fanhuiBut_MouseEnter(object sender, EventArgs e)
        {

        }

        private void fanhuiBut_MouseLeave(object sender, EventArgs e)
        {

        }
        //kongzhi yidong 
        private void EWTimer_Tick(object sender, EventArgs e)
        {


            if (Ewm.Left > left - 55 && Ewm.Left <= left + 3)
            {
                j++;
                if (isLeft)
                {

                    Ewm.Location = new Point(left - j - 1, Ewm.Top);

                }

            }
            if (Ewm.Left > left - 56 && Ewm.Left < left)
            {
                if (isRight)
                {

                    Ewm.Location = new Point(left + j + 1, Ewm.Top);
                }
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //二维码移动
        private void Ewm_MouseEnter(object sender, EventArgs e)
        {
            EWTimer.Enabled = true;
            isRight = false;
            isLeft = true;
            j = 0;

            pictureBox3.Visible = true;

        }

        private void Ewm_MouseLeave(object sender, EventArgs e)
        {
            isRight = true;
            isLeft = false;
            j = 0;
            pictureBox3.Visible = false;
        }

        #region 我又没删除到
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {


        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {

        }




        #endregion



        private void picture2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, 0, 0, 100, 100);
            Rectangle R = new Rectangle(0, 0, picture2.Width, picture2.Height / 3);
            LinearGradientBrush b = new LinearGradientBrush(R, Color.Transparent, Color.Red, LinearGradientMode.Vertical);
            g.FillRectangle(b, R);
        }
        //忘记密码
        //public static forget f;

        private void reSetPsw_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text.Trim() != "")
            {
                if (MessageBox.Show("确认：" + idTextBox.Text.Trim() + "找回密码。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {

                    UserLogin userLogin = new UserLogin();
                    userLogin.Name = idTextBox.Text.Trim();
                    //对登录的操作
                    protocolqq.mode = 0;
                    protocolqq.ope = 2;
                    protocolqq.data = userLogin;
                    user.SendMsg(protocolqq);
                    if (Variable.fLU.Name.Trim() == "")
                    {
                        MessageBox.Show("未找到该用户");
                    }
                    else
                    {
                        Variable.fr = new forget();
                        Variable.fr.Show();
                        Variable.fr.user = Variable.fLU;
                    }
                }
                else
                {
                    return;
                }


            }

        }
        //关闭二维码的图片
        private void fhBut_Click(object sender, EventArgs e)
        {
            EWMPic.BackgroundImage = Properties.Resources.erweima0;
            panel1.Show();
            headPic.Show();
            picture2.Visible = false;
            //this.Invalidate();
            Ewm.Visible = false;
            fhBut.Visible = false;
        }
        //用户勾选了自动登录就一定勾选记住密码
        private void AutoLogin_Click(object sender, EventArgs e)
        {
            if (AutoLogin.Checked == true)
            {
                remeber.Checked = true;
            }
        }
        //只要用户勾选了自动登录就不可以单独不勾选记住密码
        private void remeber_Click(object sender, EventArgs e)
        {
            if (AutoLogin.Checked == true)
            {
                remeber.Checked = true;
            }
        }
        //从用户密码错误开始找回密码
        private void findPsw_Click(object sender, EventArgs e)
        {
            //这段代码和用户主动点击找回密码的操作是一样的
            UserLogin userLogin = new UserLogin();
            userLogin.Name = idTextBox.Text.Trim();
            //对登录的操作
            protocolqq.mode = 0;
            protocolqq.ope = 2;
            protocolqq.data = userLogin;
            user.SendMsg(protocolqq);
            if (Variable.fLU.Name.Trim() == "")
            {
                MessageBox.Show("该用户不存在");
                
                //errorPsw.Visible = false;
            }
            else
            {
                errorPsw.Visible = false;
                headPic.Visible = true;
                Variable.fr = new forget();
                
                Variable.fr.user = Variable.fLU;
                Variable.fr.Show();
            }
        }
        //用户放弃找回密码
        private void gu_Click(object sender, EventArgs e)
        {
            headPic.Visible = true;
            errorPsw.Visible = false;
        }
        //窗体移动
        //
        Point before;
        bool isMove=false;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left + e.X - before.X, this.Top + e.Y - before.Y);
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }

}
