using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    //可以序列化
    [Serializable]

    /// <summary>
    /// 好友信息类
    /// </summary>
    public class Friend
    {

        //好友头像地址
        private int headId;
        //好友在线状态
        private int flag;
        //好友ID
        private string id;
        //好友昵称
        private string nickName;

        public int HeadID
        {
            set
            {
                headId = value;
            }
            get
            {
                return headId;
            }
        }
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }
        public string ID
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }

        }
        public string NickName
        {
            set
            {
                nickName = value;
            }
            get
            {
                return nickName;
            }
        }
     
 

    }
}
