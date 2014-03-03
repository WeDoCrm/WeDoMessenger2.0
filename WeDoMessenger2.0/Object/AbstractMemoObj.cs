using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class AbstractMemoObj
    {
        public AbstractMemoObj() { }

        protected string receiverId;
        public string ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        protected string senderId;
        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        protected string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        protected string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        protected int seqNum;
        public int SeqNum
        {
            get { return seqNum; }
            set { seqNum = value; }
        }
    }
}
