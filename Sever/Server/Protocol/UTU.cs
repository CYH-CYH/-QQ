using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [Serializable]
    /// <summary>
    /// 是客户端向客户端发送消息
    /// </summary>
    public class UTU
    {
        
        string receID;
        string sendID;
        object msg;
        DateTime time;
        public string ReceID
        {
            set
            {
                receID = value;
            }
            get
            {
                return receID;
            }
        }
        public string SendID
        {
            set
            {
                sendID = value;
            }
            get
            {
                return sendID;
            }
        }
        public object Msg
        {
            set
            {
                msg = value;
            }
            get
            {
                return msg;
            }
        }

        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }
}
