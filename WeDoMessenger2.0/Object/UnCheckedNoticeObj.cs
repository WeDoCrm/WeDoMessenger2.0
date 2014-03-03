using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client.Object
{
    public class UnCheckedNoticeObj : AbstractNoticeObj
    {
        /// <summary>
        /// case "T"://안읽은 공지 리스트 (T|sender†content†time†mode†seqnum†title|sender†content†time†mode†seqnum|...
        /// 실제 유입 포맷 : sender†content†time†mode†seqnum†title
        /// </summary>
        public UnCheckedNoticeObj(string msg)
        {
            string[] msgToken = msg.Split('†');
            senderId = msgToken[0];
            content = Utils.DecodeMsg(msgToken[1]);
            noticeTime = msgToken[2];
            isEmergency = (msgToken[3].Equals("e")); //긴급 일반
            seqNum = Convert.ToInt32(msgToken[4]);
            title = Utils.DecodeMsg(msgToken[5]);
        }
    }
}
