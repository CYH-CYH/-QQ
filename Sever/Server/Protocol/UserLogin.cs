using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 协议类集合
/// </summary>
namespace Protocol
{
    /// <summary>
    /// 用户登录
    /// </summary>
    [Serializable]
    public class UserLogin
    {
        private string name;
        private string pwd;
        int rememberPsw;
        int autoLogin;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Pwd
        {
            get
            {
                return pwd;
            }
            set
            {
                pwd = value;
            }
        }
        public int Remember
        {
            set
            {
                rememberPsw = value;
            }
            get
            {
                return rememberPsw;
            }
        }
        public int AutoLogin

        {
            get
            {
                return autoLogin;
            }
            set
            {
                autoLogin = value;
            }
        }

    }
}
