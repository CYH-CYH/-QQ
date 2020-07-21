using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    [Serializable]
    /// <summary>
    /// 用户自己的信息
    /// </summary>
    public class User
    {
        int headId;
        string nickName;
        string sign;
        string id;
      
        public int HeadId
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
      

        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
            }

        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = value;
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
    }
}
