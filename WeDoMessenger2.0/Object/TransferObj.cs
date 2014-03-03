using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class TransferObj : IComparable
    {
        public TransferObj() { }
        /// <summary>
        ///  case "pass"://고객정보 전달 수신
        ///  pass|ani|senderID|receiverID|TONG_DATE|TONG_TIME|CustomerName
        /// </summary>
        public TransferObj(string[] msgToken)
        {
            //pass|ani|senderID|receiverID|TONG_DATE|TONG_TIME|CustomerName
            this.ani = msgToken[1];
            this.senderId = msgToken[2];
            MemberObj member = Members.GetByUserId(senderId);
            this.senderName = member.Name;
            this.receiverId = msgToken[3];
            this.tongDate = msgToken[4];
            this.tongTime = msgToken[5];
            if (msgToken.Length > 6) 
                this.customerName = msgToken[6];
            else
                this.customerName = "";
        }

        private string ani;        
        public string Ani
        {
            get { return ani; }
            set { ani = value; }
        }

        private string senderId;        
        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        private string senderName;
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }
        
        private string receiverId;
        public string ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }
        
        private string tongDate;
        public string TongDate
        {
            get { return tongDate; }
            set { tongDate = value; }
        }
        
        private string tongTime;
        public string TongTime
        {
            get { return tongTime; }
            set { tongTime = value; }
        }

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public TransferObj Clone()
        {
            TransferObj obj = new TransferObj();
            obj.ani = this.ani;
            obj.senderId = this.senderId;
            obj.senderName = this.senderName;
            obj.receiverId = this.receiverId;
            obj.tongDate = this.tongDate;
            obj.tongTime = this.tongTime;
            obj.customerName = this.customerName;
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
