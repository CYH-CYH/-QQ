using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Protocol;

namespace Client
{
    /// <summary>
    /// 
    /// </summary>
    public static class PublicFun
    {
        /// <summary>
        /// 当用户选择了好友进行聊天时，通过好友ID进行筛选
        /// </summary>
        /// <param name="id">传入的好友ID</param>
        /// <returns>返回一个好友结构</returns>
        ///

        public static Friend GetFriend(string id)
        {
            Friend friend = new Friend();
            if (Variable.friends.Count > 0)
            {
                foreach (var f in Variable.friends)
                {
                    friend = f;
                    if (id == friend.ID)
                    {
                        return friend;
                    }
                }
                
                friend.ID = null;
                return friend;
            }
            else
            {
               
                friend.ID = null;
                return friend;
            }
           
        }
        /// <summary>
        /// 定位一个静态聊天窗口
        /// </summary>
        public static Dictionary<string, RichTextBox> talkDiction=new Dictionary<string, RichTextBox>();
        public static void AddRichTalk(string id, RichTextBox rich)
        {
            id = id.Trim();
            if (talkDiction.Keys.Contains(id))
            {
                return;
            }
            else
            {
                talkDiction.Add(id, rich);
            }
        }
        public static RichTextBox FindRichTalk(string id)
        {
            id = id.Trim();
            if (talkDiction.Count > 0)
            {
                if (talkDiction.Keys.Contains(id))
                {
                    return talkDiction[id];
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }
        public static void ShowMsg(RichTextBox rich,string friendName,string msg,DateTime time)
        {
            if (rich != null)
            {
                rich.ReadOnly = false;
                rich.AppendText(friendName+"\r\n"+msg+"\r\n"+time.ToString()+"\r\n");
                rich.ReadOnly = true;
            }
        }

        
        
    }
}
