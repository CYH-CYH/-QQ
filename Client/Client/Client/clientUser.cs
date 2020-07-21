using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Protocol;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Client
{
    public class clientUser
    {
        Socket client;
        ProtocolQQ protocolqq;
        public clientUser()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.43.21"),20200);
            client.Connect(endPoint);

            Thread ReceThread = new Thread(ReceMsg);
            ReceThread.IsBackground = true;
            ReceThread.Start();
        }
        /// <summary>
        /// 客户端发送消息
        /// </summary>
        /// <param name="qq"></param>
        public void SendMsg(ProtocolQQ qq)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, qq);
            byte[] msg = stream.GetBuffer();
            client.Send(msg);
            //
            Thread.Sleep(5000);
        }
        /// <summary>
        /// 客户端接收消息
        /// </summary>
        void ReceMsg()
        {
            //修改密码的窗体
            
            byte[] mag = new byte[1024 * 1024 * 5];
            int msgLength;
            while (true)
            {
                try
                {
                    msgLength = client.Receive(mag);

                    //内存流
                    MemoryStream stream = new MemoryStream(mag, 0, msgLength);
                    //二进制与Object 类的转换
                    BinaryFormatter fomatter = new BinaryFormatter();
                    //强制转换并且接收她
                    var protocolqq = fomatter.Deserialize(stream) as Protocol.ProtocolQQ;
                    switch (protocolqq.mode)
                    {
                        //用户登录---客户端
                        case 0:
                            switch (protocolqq.ope)
                            {
                                //验证登录结果---是否密码和账号正确
                                case 0:
                                    var login = protocolqq.data as Protocol.ReturnLogin;
                                    if (login.ResultLogin)
                                    {
                                        Variable.IsLogin = true;
                                        Variable.friends = login.Friends;
                                        Variable.user = login.GetUser;
                                    }
                                    else
                                    {
                                        Variable.IsLogin = false;
                                    }
                                    break;
                                //该用户是否已经登录---无法再次登录
                                case 1:
                                    MessageBox.Show("您已经登录了该账号，不可以重复登录！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                    break;
                                //注册结果
                                case 2:
                                    var reger = protocolqq.data as Regr;
                                    reger.ID = reger.ID.Trim();
                                    if (reger.ID == "")
                                    {
                                        MessageBox.Show("注册失败请重试！");
                                    }
                                    else
                                    {
                                        Variable.regr = reger;
                                        MessageBox.Show("注册成功！您的账号为："+Variable.regr.ID+"快去登录吧！");

                                    }
                                    break;
                                   
                                case 3:
                                    Variable.fLU = protocolqq.data as UserLogin;
                                    
                                    break;
                                    //修改密码是否成功
                                case 4:
                                    UserLogin fuser = protocolqq.data as UserLogin;
                                    if (fuser.Name.Trim() == "")
                                    {
                                        MessageBox.Show("修改密码失败！");
                                    }
                                    else
                                    {
                                        MessageBox.Show("修改成功，快去登录吧！");
                                        Variable.fr.Close();
                                    }
                                    break;
                            }
                            break;

                        //用户聊天
                        case 1:
                            switch (protocolqq.ope)
                            {
                                //接收普通字符串
                                case 0:
                                    //如果接受消息的客户端在线，那么像对话窗口添加消息
                                    RichTextBox rich;
                                    Variable.utu = protocolqq.data as UTU;
                                    Variable.str= Variable.utu.Msg as Str;
                                    rich=PublicFun.FindRichTalk(Variable.utu.SendID);
                                    PublicFun.ShowMsg(rich, PublicFun.GetFriend(Variable.utu.SendID).NickName,Variable.str.Message, Variable.utu.Time);
                                    break;       
                            }
                            break;

                    }




                }
                catch
                {

                }
            }
        }
       
        
    }
}
