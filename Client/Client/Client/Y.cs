using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Y : Form
    {
        public Login login;
        public string name;
        public string psw;
        ProtocolQQ protocolqq;
        UserLogin userLogin;
        //本地用户记录
       LocMess l_;
        //本地用户字典
        Dictionary<string, LocMess> ls;
        public Y()
        {
            InitializeComponent();
            protocolqq=new ProtocolQQ();
            //将已经处理好的背景图片放入数组中
            bkImageLis.LoadImg();
            //建立一个用户登录对象
            userLogin = new UserLogin();
            //建立一个本地用户类
           //l_ = new LocMess();
            //将反序列化的数据放入字典中，这个有点简单（语法）
            //ls = new Dictionary<string, LocMess>();
           
        }
        //记录当前窗口的播放到哪一张图片的索引
        int i = 0;
        //控制背景图片变化的时钟
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = bkImageLis.bk[i];
            i++;
            if (i > 110)
            {
                i = 0;
            }
        }      
        bool isR = true;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        //生成的验证码字符串
        string code;
        //用户验证码是否输入正确
        private void Y_Load(object sender, EventArgs e)
        {
            code = YZM.CreateRandomCode(4);
            //一个图片信息
            picY.BackgroundImage = YZM.CreateValidateGraphic(code);
            //输入验证码验证
 
        }

        public void inputY_TextChanged(object sender, EventArgs e)
        {
            if (inputY.Text.Trim().Length == 4)
            {
                if (inputY.Text.Trim() != code)
                {
                    code = YZM.CreateRandomCode(4);
                    //一个图片信息
                    picY.BackgroundImage = YZM.CreateValidateGraphic(code);
                    //输入验证码验证
                }
                else
                {
                    Variable.fl = false;
                    this.Visible = false;
                    login.loginBut_Click(sender, e);
#if false
                    UserLogin userLogin=new UserLogin();
                    userLogin.Name = name;
                    userLogin.Pwd = psw.Trim();
                    protocolqq.mode = 0;
                    protocolqq.ope = 0;
                    protocolqq.data = userLogin;
                    //这个线程会睡1秒
                    Variable.client.SendMsg(protocolqq);

                    //Thread.Sleep(1000);
                    if (Variable.IsLogin)
                    {
                        Variable.fl = false;
                        login.loginBut_Click(sender,e);
                        //将该用户的用户名-密码-头像-勾选记住密码、自动登录记录到本地文件 
#region 将这个类写入文件
                        l.I = userLogin.Name;
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

                    else
                    {
                        errorPsw.Visible = true;
                    }
#endif
                }
            }
        }

        private void findPsw_Click(object sender, EventArgs e)
        {
            //这段代码和用户主动点击找回密码的操作是一样的
            UserLogin userLogin = new UserLogin();
            userLogin.Name = name.Trim();
            //对登录的操作
            protocolqq.mode = 0;
            protocolqq.ope = 2;
            protocolqq.data = userLogin;
            Variable.client.SendMsg(protocolqq);
            if (Variable.fLU.Name.Trim() == "")
            {
                MessageBox.Show("该用户不存在");
                this.Close();
            }
            else
            {
                errorPsw.Visible = false;
                Variable.fr = new forget();
                Variable.fr.Show();
                Variable.fr.user = Variable.fLU;
                this.Close();
            }
        }

        private void gu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //窗体移动
        //
        Point before;
        bool isMove = false;
        private void Y_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            before = new Point(e.X, e.Y);
        }

        private void Y_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMove)
            this.Location = new Point(this.Left + e.X - before.X, this.Top + e.Y - before.Y);
        }

        private void Y_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}
