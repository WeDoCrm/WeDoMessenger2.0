using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class NoticeObj : AbstractNoticeObj
    {
        public NoticeObj()
        {
        }
        
        /// <summary>
        /// case "n":  //공지사항 메시지 (n|메시지|발신자id|mode|noticetime|제목)
        /// 공지리스트포맷    :           r|메시지|발신자id|mode|ntime|seqnum|title
        /// </summary>
        public NoticeObj(string msg)
        {
            string[] msgToken = msg.Split('|');
            needReply = msgToken[0].Equals("n"); //"r"read:"n"notice
            content = Utils.DecodeMsg(msgToken[1]);
            senderId = msgToken[2];
            isEmergency = (msgToken[3].Equals("e")); //긴급 일반
            noticeTime = msgToken[4];
            if (msgToken.Length == 6)
            {
                seqNum = Convert.ToInt32(msgToken[5]);
                title = Utils.DecodeMsg(msgToken[6]);
            }
            else
            {
                title = Utils.DecodeMsg(msgToken[5]);
            }
        }

        public NoticeObj(string[] msg)
        {
            needReply = msg[0].Equals("n");
            content = Utils.DecodeMsg(msg[1]);
            senderId = msg[2];
            isEmergency = (msg[3].Equals("e")); //긴급 일반
            noticeTime = msg[4];
            if (msg.Length == 6)
            {
                seqNum = Convert.ToInt32(msg[5]);
                title = Utils.DecodeMsg(msg[6]);
            }
            else
            {
                title = Utils.DecodeMsg(msg[5]);
            }

        }

        private bool needReply;
        public bool NeedReply
        {
            get { return needReply; }
            set { needReply = value; }
        }
    }
}
