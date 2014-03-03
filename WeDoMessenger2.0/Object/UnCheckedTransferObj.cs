using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class UncheckedTransferObj : IComparable
    {
        public UncheckedTransferObj()
        { }

        /// <summary>
        /// case "trans"://부재중 이관 메시시 수신(trans|sender†content†time†seqnum|...)
        /// 실제처리 포맷: sender†content†time†seqnum
        ///  ==> content 포맷 : 22&ani&senderID&receiverID&일자&시간&CustomerName
        /// </summary>
        public UncheckedTransferObj(string msg)
        {
            string[] msgToken = msg.Split('†');
            this.senderId = msgToken[0];
            string[] contentToken = msgToken[1].Split('&');
            if (contentToken.Length > 1)
            {
                this.contentObj = new TransferObj(contentToken);
                this.content = "";
            }
            else
            {
                this.contentObj = null;
                this.content = msgToken[1];
            }
            this.time =  msgToken[2];
            this.seqNum = Convert.ToInt32(msgToken[3]);
        }

        private string senderId;        
        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private TransferObj contentObj;
        public TransferObj ContentObj
        {
            get { return contentObj; }
            set { contentObj = value; }
        }
        
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        
        private int seqNum;
        public int SeqNum
        {
            get { return seqNum; }
            set { seqNum = value; }
        }

        public UncheckedTransferObj Clone()
        {
            UncheckedTransferObj obj = new UncheckedTransferObj();
            obj.senderId = this.senderId;
            obj.content = this.content;
            obj.time = this.time;
            obj.seqNum = this.seqNum;
            obj.contentObj = this.contentObj.Clone();
            return obj;
        }

        #region IComparable 멤버

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
