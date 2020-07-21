using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [Serializable]
    /// <summary>
    /// 发送的消息类型为普通字符串
    /// </summary>
    public class Str
    {
        string message;
        public string Message
        {
            set
            {
                message = value;
            }
            get
            {
                return message;
            }
        }
    }
}
