using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class ChatObj
    {
        public ChatObj()
        {
        }
        
        /// <summary>
        /// 1. 상대방 대화메시지일 경우  (d|Formkey|id/id/...|name|메시지)
        /// 2. 대화중 초대가 일어난 경우 (c|formkey|id/id/...|name ) 
        /// 3. 다자 대화중 상대방이 대화창 나감 (q|Formkey|id)
        /// 4. 다자 대화중 상대방이 연결 끊김 (dc|Formkey|id)
        /// </summary>
        /// <param name="_msg"></param>
        public ChatObj(string[] _msg) 
        {
            if (_msg[0].Equals("d"))
            {
                ParseChatMsg(_msg);
            }
            else if (_msg[0].Equals("c"))
            {
                ParseInviteMsg(_msg);
            }
            else if (_msg[0].Equals("q") || _msg[0].Equals("dc"))
            {
                ParseChatterQuitMsg(_msg);
            }
        }
        private void ParseChatterQuitMsg(string[] _msg)
        {
            chatKey = ChatUtils.GetFormKey(_msg[1], ConfigHelper.Id);
            quitter = Members.GetByUserId(_msg[2]);
        }

        private void ParseInviteMsg(string[] _msg)
        {
            chatKey = ChatUtils.GetFormKey(_msg[1], ConfigHelper.Id);

            string[] addedIdArray = _msg[2].Split('/');

            foreach (string addedId in addedIdArray)
                memberList.Add(Members.GetByUserId(addedId));
        }

        private void ParseChatMsg(string[] _msg)
        {
            chatKey = ChatUtils.GetFormKey(_msg[1], ConfigHelper.Id);

            string[] addedIdArray = _msg[2].Split('/');
            
            foreach (string addedId in addedIdArray)
                memberList.Add(Members.GetByUserId(addedId));

            userId = addedIdArray[0];
            userName = _msg[3];
            msg = Utils.DecodeMsg(_msg[4]);
        }


        private string userId;
        public string UserId { get { return userId; } set { userId = value; } }

        private string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        
        private string chatKey;
        public string ChatKey { get { return chatKey; } set { chatKey = value; } }

        private string msg;
        public string Msg { get { return msg; } set { msg= value; } }

        private List<MemberObj> memberList = new List<MemberObj>();
        public List<MemberObj> MemberList {get { return memberList; } set { memberList = value; } }

        private MemberObj quitter;
        public MemberObj Quitter { get { return quitter; } set { quitter = value; } }

    }
}
