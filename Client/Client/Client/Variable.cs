using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Protocol;
namespace Client
{
     public static class Variable
    {
        //用户是否第一次登录
        public static bool fl = true;
        //验证登录是否成功
        public static bool isLogin=false;
        public static bool IsLogin
        {
            get
            {
                return isLogin;
            }
            set
            {
                isLogin = value;
            }
        }
        //返回的一个好友列表
        public static List<Friend>friends;
        //返回用户自己
        public static User user;
        public static clientUser client;
        //在线对话
        public static UTU utu;
        public static Str str;
        //对话窗口
        //用户注册
        public static Regr regr;
        //忘记密码
        public static UserLogin fLU;
        //忘记密码的窗口
        public static forget fr;
        //注册密码的窗口
        public static Register reg;
       

    }
}
