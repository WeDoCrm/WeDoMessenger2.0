using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class AbstractNoticeObj
    {
        protected bool isEmergency;
        public bool IsEmergency
        {
            get { return isEmergency; }
            set { isEmergency = value; }
        }
        protected string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        protected string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        protected string noticeTime;
        public string NoticeTime
        {
            get { return noticeTime; }
            set { noticeTime = value; }
        }

        public string Mode
        {
            get { return isEmergency ? "긴급" : "일반"; }
        }

        public string StrMode { get { return IsEmergency ? "e" : "n"; } }

        protected int seqNum;
        public int SeqNum
        {
            set { seqNum = value; }
            get { return seqNum; }
        }

        protected string senderId;
        public string SenderId
        {
            set { senderId = value; }
            get { return senderId; }
        }
    }
}
