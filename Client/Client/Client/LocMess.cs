using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //序列化
    [Serializable]
    /// <summary>
    /// 用户登录记录对象，存入本地文件
    /// </summary>

    class LocMess
    {
       
       
            //用户名
            string i;
            //用户密码
            string p;
            //用户头像ID
            int h;
            //记住密码
            int r;
            //自动登录
            int a;
            public string I
            {
                get
                {
                    return i;
                }
                set
                {
                    i = value;
                }
            }
            public string P
            {
                get
                {
                    return p;
                }
                set
                {
                    p = value;
                }
            }
            public int H
            {
                set
                {
                    h = value;
                }
                get
                {
                    return h;
                }
            }
            public int R
            {
                set
                {
                    r = value;
                }
                get
                {
                    return r;
                }
            }
            public int A
            {
                set
                {
                    a = value;
                }
                get
                {
                    return a;
                }
            }
        }
    
}
