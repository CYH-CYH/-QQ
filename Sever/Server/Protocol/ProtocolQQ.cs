using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [Serializable]
    public class ProtocolQQ
    {
        //模块——用户将要执行的操作集
        //0:登录操作
        //1:聊天
        //3:代表下线操作
        public int mode;

        //操作
        //用户要进行的实际操作
        //（0,0）：登录……
        
        public int ope;
        //数据——用户登录操作类、好友类……
        public object data;
    }
}
