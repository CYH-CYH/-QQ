using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [Serializable]
    /// <summary>
    /// 用户登录返回信息
    /// </summary>
    public class ReturnLogin
    {
        
        bool resultLogin;
        List<Friend> friends;
        User user;
        public bool ResultLogin
        {
            get
            {
               return  resultLogin;
            }
            set
            {
                resultLogin = value;
            }
        }
        public List<Friend> Friends
        {
            get
            {
                return friends;
            }
            set
            {
                friends = value;
            }
        }
        public User GetUser
        {
            set
            {
                user = value;

            }
            get
            {
                return user;
            }
        }
    }
}
