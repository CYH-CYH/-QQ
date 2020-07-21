using Protocol;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// 
    /// </summary>

    public class ServerSocket
    {
        Socket server;
        public RichTextBox richText;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ServerSocket(RichTextBox rich)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            richText = rich;

        }
        /// <summary>
        /// 开启服务端监听
        /// </summary>
        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 20200);
            server.Bind(endPoint);
            server.Listen(100);
            ShowMsg("开始监听！" + "\r\n");

            Thread accThread = new Thread(AccSocket);
            accThread.IsBackground = true;
            accThread.Start();
        }
        /// <summary>
        /// 服务器接收客户端的请求
        /// </summary>
        Thread receThread;
        void AccSocket()
        {
            Socket client;

            while (true)
            {
                try
                {
                    client = server.Accept();
                    ShowMsg("接收到来自客户端：" + client.RemoteEndPoint.ToString() + "\r\n");
                    receThread = new Thread(ReceMsg);
                    receThread.IsBackground = true;
                    receThread.Start(client);
                }
                catch
                {

                }

            }


        }
        /// <summary>
        /// 接收客户端发来的信息
        /// </summary>
        /// <param name="obj"></param>
        void ReceMsg(object obj)
        {
            Socket client;
            byte[] mag = new byte[1024 * 1024 * 5];
            int msgLength;
            while (true)
            {

                client = obj as Socket;
                msgLength = client.Receive(mag);
                string sqlconn;
                //内存流
                MemoryStream stream = new MemoryStream(mag, 0, msgLength);
                //二进制与Object 类的转换
                BinaryFormatter fomatter = new BinaryFormatter();
                //强制转换并且接收她
                var protocolqq = fomatter.Deserialize(stream) as Protocol.ProtocolQQ;

                switch (protocolqq.mode)
                {
                    //用户登录
                    case 0:
                        switch (protocolqq.ope)
                        {
                            //验证登录
                            case 0:
                                var userLogin = protocolqq.data as Protocol.UserLogin;
                                //弄错了应该是ID，但是我也并没有很想改转来，所以就不改了。
                                string name = userLogin.Name;
                                string pwd = userLogin.Pwd;
                                //数据库操作语句
                                sqlconn = "select count(*) from tb_User where ID= '" + name + "'" + "and Pwd = '" + pwd + " '";

                                //新建一个用户登录返回类
                                ReturnLogin IsLogin = new ReturnLogin();
                                //如果num==1则数据库中有该用户
                                int num = DataOperator.ESSql(sqlconn);

                                if (num !=0)
                                {

                                    ClientManager.AddClient(name, client);

                                    //判断是否重复登录该用户
                                    if (ClientManager.reLogin == true)
                                    {
                                        IsLogin.ResultLogin = false;
                                        client.Send(SendMsg(0, 1, IsLogin));
                                        //关闭该字
                                        string s_1 = "用户：" + client.RemoteEndPoint.ToString() + "下线。" + "\r\n";
                                
                                        ShowMsg(s_1);
                                        receThread.Abort();
                                        while (receThread.ThreadState == ThreadState.Aborted)
                                        {
                                            Thread.Sleep(100);
                                        }
                                        break;

                                    }
                                    else
                                    {
                                        
                                        IsLogin.ResultLogin = true;
                                        User user = new User();
                                        user.ID = name;
                                        //数据库更新用户记住密码,自动登录操作的操作
                                        sqlconn = "update tb_User set Remember = " + userLogin.Remember + ",AutoLogin=" + userLogin.AutoLogin + " where ID = '" + name+" '";
                                        DataOperator.ENQSql(sqlconn);
                                        //访问数据库，得到好友列表
                                        
                                        List<Friend> friends = new List<Friend>();

                                        sqlconn = "select NickName, HeadID,Sign from tb_User where ID='" + name + "'";
                                        //查询用户信息和用户好友信息的数据库查询语句
                                        SqlDataReader dataReader = DataOperator.GetDataReader(sqlconn);
                                        //一直读
                                        if (dataReader.Read())
                                        {
                                            if (!(dataReader["NickName"] is DBNull))
                                            {
                                                user.NickName = dataReader["NickName"].ToString();
                                            }
                                            user.HeadId = Convert.ToInt32(dataReader["HeadID"]);
                                            user.Sign = dataReader["Sign"].ToString();
                                        }
                                        //加载好友的SQL语句
                                        sqlconn = "select FriendID,NickName,HeadID,Flag from tb_User,tb_Friend where tb_Friend.HostID='" + name + "'" + " and tb_User.ID=tb_Friend.FriendID";
                                        dataReader = DataOperator.GetDataReader(sqlconn);
                                        while (dataReader.Read())
                                        {
                                            Friend friend = new Friend();
                                            friend.HeadID = Convert.ToInt32(dataReader["HeadID"]);
                                            //?????
                                            friend.ID = Convert.ToString(dataReader["FriendID"]);
                                            friend.NickName = dataReader["NickName"].ToString();
                                            friends.Add(friend);
                                        }
                                        //关闭读取器
                                        dataReader.Close();
                                        //关闭数据库连接
                                        DataOperator.conn.Close();
                                        IsLogin.Friends = friends;
                                        IsLogin.GetUser = user;
                                        client.Send(SendMsg(0, 0, IsLogin));

                                    }
                                }
                                else
                                {
                                    IsLogin.ResultLogin = false;
                                    client.Send(SendMsg(0, 0, IsLogin));
                                }
                                
                                break;
                            //注册用户
                            case 1:
                                //不太对得起我自己---这个只允许注册100个
                                Random rand=new Random();
                                int v;
                                v =rand.Next(0, 101);
                                var reger = protocolqq.data as Protocol.Regr;
                                reger.ID = Convert.ToString(20000 + v);
                                sqlconn = "Select ID from tb_User Where ID = '" + reger.ID.Trim()+"'";
                                while (true)
                                {
                                    if (DataOperator.ESSql(sqlconn).ToString()!=reger.ID)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        v= rand.Next(0, 100);
                                        reger.ID = Convert.ToString(20000 + v);
                                        sqlconn = "Select ID from tb_User Where ID ='" + reger.ID+"'";
                                    }
                                }
                                sqlconn = string.Format("insert into tb_User(ID,Pwd, NickName) values('{0}', '{1}','{2}')",reger.ID.Trim(), reger.PSW, reger.NickName);
                                int num_ = DataOperator.ENQSql(sqlconn);
                                if (num_ == 1)
                                {
                                    client.Send(SendMsg(0,2,reger));
                                }
                                else
                                {
                                    reger.ID = "";
                                    client.Send(SendMsg(0, 2, reger));
                                }
                                break;
                            //忘记密码---验证账号是否正确
                            case 2:
                                //忘记密码和登录时的协议我们采用一样的
                                var fuser = protocolqq.data as Protocol.UserLogin;
                                
                                string name_ = fuser.Name.Trim();
                                //数据库操作语句
                                sqlconn = "select ID from tb_User where ID= '" + name_ + "'";
                                int num_1 = DataOperator.ESSql(sqlconn);
                                if (num_1!=0)
                                {
                                    client.Send(SendMsg(0, 3, fuser));
                                }
                                else
                                {
                                    fuser.Name = "";
                                    client.Send(SendMsg(0, 3, fuser));
                                }
                                break;
                                //忘记密码---修改密码
                            case 3:
                                var ffuer = protocolqq.data as UserLogin;
                                //修改密码的数据库语句
                                sqlconn = "update tb_User set Pwd= '" + ffuer.Pwd.Trim() + "'" + "where ID= '" +ffuer.Name+ "'";
                                int num_2 = DataOperator.ENQSql(sqlconn);
                                if (num_2!=0)
                                {
                                    client.Send(SendMsg(0, 4, ffuer));
                                }
                                else
                                {
                                    ffuer.Name = "";
                                    client.Send(SendMsg(0, 4, ffuer));
                                }
                                break;
                              //用户勾选密码
                            case 4:

                                break;

                        }

                        break;
                    //用户聊天
                    case 1:
                        switch (protocolqq.ope)
                        {

                            //普通聊天
                            case 0:
                                var utu = protocolqq.data as Protocol.UTU;
                                var str = utu.Msg as Str;
                                utu.ReceID = utu.ReceID.Trim();
                                if (ClientManager.CheckingUser(utu.ReceID))
                                {
                                    
                                    ClientManager.SendMsg(mag, ClientManager.client);
                                }
                                //此处的MessageTypeId为1，表示聊天消息；MessageState为0，表示消息未读

                                //把聊天记录插入数据库
                                sqlconn = string.Format("INSERT INTO tb_Message (FromUserID, ToUserID, Message, MessageTypeID, MessageState,MessageTime) VALUES ('{0}','{1}','{2}',{3},{4},'{5}')",
                                utu.SendID, utu.ReceID, str.Message, 1, 0, utu.Time);
                                int num = DataOperator.ENQSql(sqlconn);
                                if (num != 1)
                                {
                                    //发给客户端
                                    MessageBox.Show("用户：" + utu.SendID + "向用户：" + utu.ReceID + "发送消息失败！"+"/r/n");
                                }
                                break;
                            // 发送文件
                            case 1:
                                break;
                            //发送图片
                            case 2:
                                break;
                            //发送抖屏
                            case 3:
                                break;

                        }
                        break;
                        //用户离线
                    case 3:
                        //关闭套接字且移除用户
                        string s_0 = "用户：" + client.RemoteEndPoint.ToString() + "下线。" + "\r\n";
                        ClientManager.Clear(client);
                        
                        ShowMsg(s_0);
                        receThread.Abort();
                        while (receThread.ThreadState == ThreadState.Aborted)
                        {
                            Thread.Sleep(100);
                        }
                        break;

                }
            }
        }
        /// <summary>
        /// 显示服务端相应消息
        /// </summary>
        /// <param name="msg"></param>
        void ShowMsg(string msg)
        {
            richText.AppendText(msg);
        }
        /// <summary>
        /// 服务器端向客户端发送消息
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="oper"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] SendMsg(int mode, int oper, object obj)
        {
            ProtocolQQ qq = new ProtocolQQ();
            qq.mode = mode;
            qq.ope = oper;
            qq.data = obj;
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, qq);
            byte[] msg = stream.GetBuffer();
            return msg;
        }


    }
}
