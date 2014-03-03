using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class NumberedNoticeObj : AbstractNoticeObj
    {
        /// <summary>
        /// case "L"://공지사항 리스트 수신한 경우  L|time‡content‡mode‡sender‡seqnum‡title|...  
        /// 실제 유입 포맷: time‡content‡mode‡sender‡seqnum‡title
        /// </summary>
        /// <param name="msg"></param>
        public NumberedNoticeObj(string msg)
        {
            string[] msgToken = msg.Split('‡');
            noticeTime = msgToken[0];
            content = Utils.DecodeMsg(msgToken[1]);
            isEmergency = (msgToken[2].Equals("e")); //긴급 일반
            senderId = msgToken[3];
            seqNum = Convert.ToInt32(msgToken[4]);
            Title = Utils.DecodeMsg(msgToken[5]);
        }

        public NoticeObj ToNoticeObj()
        {
            NoticeObj noticeObj = new NoticeObj();
            noticeObj.NoticeTime = this.noticeTime;
            noticeObj.Content = this.content;
            noticeObj.IsEmergency = this.isEmergency;
            noticeObj.SenderId = this.senderId;
            noticeObj.SeqNum = this.seqNum;
            noticeObj.Title = this.title;
            return noticeObj;
        }
    }
}
