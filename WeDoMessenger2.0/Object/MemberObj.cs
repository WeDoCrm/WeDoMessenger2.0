using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace Client
{
    public class MemberObj : IComparable
    {
        public MemberObj()
        {
        }

        public MemberObj(string teamName, string userId, string userName)
        {
            this.teamName = teamName;
            this.userId = userId;
            this.userName = userName;
            this.titleName = userName;
            this.Status = MsgrUserStatus.LOGOUT;
        }

        private string teamName;
        public string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        private string userId;
        public string Id
        {
            get { return userId; }
            set { userId = value; }
        }

        private string userName;
        public string Name
        {
            get { return userName; }
            set { userName = value; }
        }

        private string titleName;
        public string Title { get { return titleName; } set { titleName = value; } }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value; ;
                switch (status)
                {
                    case MsgrUserStatus.AWAY:
                        titleName = string.Format("{0}({1})", userName, "자리비움");
                        break;
                    case MsgrUserStatus.BUSY:
                        titleName = string.Format("{0}({1})", userName, "통화중");
                        break;
                    case MsgrUserStatus.DND:
                        titleName = string.Format("{0}({1})", userName, "다른용무중");
                        break;
                    case MsgrUserStatus.LOGOUT:
                    case MsgrUserStatus.ONLINE:
                        titleName = userName;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("teamName[{0}]userId[{1}]userName[{2}]", teamName, userId, userName);
        }

        public MemberObj Clone()
        {
            return (MemberObj)this.MemberwiseClone();
        }

        #region IComparable 멤버

        public int CompareTo(object obj)
        {
            return this.userId.CompareTo(((MemberObj)obj).userId);
        }

        #endregion
    }
}
