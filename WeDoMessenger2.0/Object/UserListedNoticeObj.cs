using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class UserListedNoticeObj : AbstractNoticeObj
    {
        /// <summary>
        /// case "t": //"t|ntime†content†nmode†title†안읽은사람1:안읽은사람2:...|...
        /// 실제 유입 포맷 : ntime†content†nmode†title†안읽은사람1:안읽은사람2:...
        /// </summary>
        public UserListedNoticeObj(string msg)
        {
            string[] msgToken = msg.Split('†');
            
            noticeTime = msgToken[0];
            content = Utils.DecodeMsg(msgToken[1]);
            isEmergency = (msgToken[2].Equals("e")); //긴급 일반
            title = Utils.DecodeMsg(msgToken[3]);
            
            if (msgToken.Length >= 5) {
                string[] unReadersToken = msgToken[4].Split(':');
                unReaders.AddRange(unReadersToken);
            }
        }

        List<string> unReaders;
        public List<string> UnReaders
        {
            get { return UnReaders; }
        }
    }
}
