using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class MemoObj : AbstractMemoObj
    {
        public MemoObj() { }

        /// <summary>
        /// case "m"://메모를 수신한 경우 m|name|id|message|수신자id|timekey
        /// </summary>
        public MemoObj(string msg)
        { 
            string[] msgToken = msg.Split('|');
            receiverId = msgToken[4];
            senderId = msgToken[2];
            content = Utils.DecodeMsg(msgToken[3]);
            if (msgToken.Length == 6)
                time = msgToken[5];
            else
                time = Utils.TimeKey();
        }

        public MemoObj(string[] msg)
        {
            senderId = msg[2];
            content = Utils.DecodeMsg(msg[3]);
            receiverId = msg[4];
            if (msg.Length == 6)
                time = msg[5];
            else
                time = Utils.TimeKey();
        }

        public MemoObj(string senderId, string receiverId, string content)
        {
            this.senderId = senderId;
            this.content = content;
            this.receiverId = receiverId;
            this.time = Utils.TimeKey();
        }

        public string MsgStr { get { return string.Format("m|{0}|{1}|{2}|{3}|{4}",Members.GetByUserId(senderId).Name, senderId, content, receiverId, time); } }
    }
}
