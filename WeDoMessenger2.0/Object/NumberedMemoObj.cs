using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class NumberedMemoObj : AbstractMemoObj
    {
        /// <summary>
        /// case "Q"://안읽은 메모 리스트 (Q|sender†content†time†seqnum|...|
        /// 실제 처리 포맷 : sender†content†time†seqnum
        /// </summary>
        public NumberedMemoObj(string msg)
        { //Q|sender†content†time†seqnum|...|
            string[] msgToken = msg.Split('†');
            senderId = msgToken[0];
            content = Utils.DecodeMsg(msgToken[1]);
            time = msgToken[2];
            seqNum = Convert.ToInt32(msgToken[3]);
            receiverId = ConfigHelper.Id;
        }

        public MemoObj ToMemoObj()
        {
            MemoObj memoObj = new MemoObj();
            memoObj.SenderId = this.senderId;
            memoObj.Content = this.content;
            memoObj.ReceiverId = this.receiverId;
            memoObj.Time = this.time;
            return memoObj;
        }
    }
}
