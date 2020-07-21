using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Protocol;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Server
{
    static class ClientManager
    {
        //判断是否已经有用户在登录
        public static bool reLogin = false;
        //将要发送信息的网络套接字
        public static Socket client;
        //通信套接字key ：客户端ip value ：对应的通信套接字
        private static Dictionary<string, Socket> clientSocket = new Dictionary<string, Socket>();
        // 通信套接字key ：客户端ip value ：用户ID（数据库中获得）
        //private static Dictionary<string, string> userSocket = new Dictionary<string, string>();
        public static void AddClient(string id, Socket client)
        {
            string endPoint = client.RemoteEndPoint.ToString();


            if (clientSocket.Keys.Contains(id))
            {
                //强制下线===没写这个逻辑
                reLogin = true;

                //别忙在这儿关线程，待会儿关
                //client.Close();
                return;

            }
            else
            {
                clientSocket.Add(id, client);
                //userSocket.Add(endPoint, id);
            }


        }
        /// <summary>
        /// 向客户端转发消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckingUser(string id)
        {
            if (clientSocket.Count > 0)
            {

                if (clientSocket.Keys.Contains(id))
                {

                    client = clientSocket[id];
                    return true;
                }
                else
                    return false;
            }
            else
                return false;


        }
        /// <summary>
        /// 服务器端向客户端发送消息
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="oper"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void SendMsg(byte[] buffer, Socket client)
        {
            client.Send(buffer);
        }
        /// <summary>
        /// 移除套接字
        /// </summary>
        /// <param name="s"></param>
        public static void Clear(Socket s)
        {
            if (clientSocket.Count > 0)
            {
                foreach (KeyValuePair<string, Socket> kvp in clientSocket)
                {
                    if (kvp.Value.Equals(s))
                    {
                        clientSocket.Remove(kvp.Key);
                        break;
                    }
                }
            }
            //关闭这个套接字
            s.Close();

        }

    }
}
