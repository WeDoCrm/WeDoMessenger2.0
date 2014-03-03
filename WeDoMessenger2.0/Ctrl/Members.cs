using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Client.Object;
using WeDoCommon;
using System.Net;
using Client.Common;

namespace Client
{
    public sealed class Members
    {
        private static readonly object lockMembers = new object();
        private static readonly object lockConnectedNodes = new object();

        private static Dictionary<string, MemberObj> membersTable; //key=id value=Member
        private static Dictionary<string, Dictionary<string, MemberObj>> membersTableByTeam; //key=team, value=memberTable
        private static Dictionary<string, IPEndPoint> connectedNodesTable;

        private Members() {}

        public static void Initialize()
        {
            membersTable = new Dictionary<string, MemberObj>();
            membersTableByTeam = new Dictionary<string, Dictionary<string, MemberObj>>();
            connectedNodesTable = new Dictionary<string,IPEndPoint>();
        }

        /// <summary>
        /// //다른 클라이언트 목록 및 접속상태 정보(M|팀이름|id!멤버이름|id!멤버이름)
        /// </summary>
        /// <param name="msg"></param>
        public static void AddMembers(string msg) 
        {
            lock (lockMembers)
            {
                string[] tempMsg = msg.Split('|');

                if (tempMsg.Length > 2)
                {
                    string teamName = tempMsg[1];
                    Dictionary<string, MemberObj> teamMembersTable = new Dictionary<string, MemberObj>();

                    if (teamName.Trim() == "")
                    { //소속이 미지정인 경우
                        teamName = MsgrMsg.UNDEFINED_TEAM;
                    }

                    for (int i = 2; i < tempMsg.Length; i++)
                    {//배열 순서 2번째 부터인 id!name을 추출

                        if (tempMsg[i].Length != 0)
                        {
                            string[] memInfo = tempMsg[i].Split('!');  //<id>와 <name>을 분리하여 memInfo에 저장
                            MemberObj member = new MemberObj(teamName, memInfo[0], memInfo[1]);

                            membersTable[memInfo[0]] = member;
                            teamMembersTable[memInfo[0]] = member;
                            Logger.info("MemberObj정보추가: " + member.ToString());
                        }
                    }
                    membersTableByTeam[teamName] = teamMembersTable;
                    //델리게이트 생성
                }
            }
        }

        public static MemberObj GetByUserId(string userId)
        {
            MemberObj obj;
            lock (lockMembers)
            {
                obj = membersTable[userId].Clone();
            }
            return obj;
        }

        public static Dictionary<string, MemberObj> GetMembers()
        {
            Dictionary<string, MemberObj> dic;
            lock (lockMembers)
            {
                dic = new Dictionary<string, MemberObj>(membersTable);
            }
            return dic;
        }

        public static Dictionary<string, MemberObj> GetMembersByTeam(string teamName)
        {
            Dictionary<string, MemberObj> dic;
            lock (lockMembers)
            {
                dic = new Dictionary<string, MemberObj>(membersTableByTeam[teamName]);
            }
            return dic;
        }

        public static List<string> GetTeamList()
        {
            List<string> teamList;
            lock (lockMembers)
            {
                teamList = new List<string>(membersTableByTeam.Keys.ToList());
            }
            return teamList;
        }

        public static Dictionary<string, IPEndPoint> GetLoginUsers()
        {
            Dictionary<string, IPEndPoint> dic;
            lock (lockConnectedNodes)
            {
                dic = new Dictionary<string, IPEndPoint>(connectedNodesTable);
            }
            return dic;
        }

        /// <summary>
        /// 로그인 Client 리스트 메시지 포맷: IP|id|ip주소 
        /// </summary>
        /// <param name="msg"></param>
        public static void AddLoginUser(string msg) 
        {
            string[] tempMsg = msg.Split('|');
            if (tempMsg.Length == 3)
            {
                string userId = tempMsg[1];
                string ipAddress = tempMsg[2];
                AddLoginUser(userId, ipAddress);
            }
        }

        public static void AddLoginUser(string userId, string ipAddress)
        {
            lock (lockConnectedNodes)
            {
                IPEndPoint iePoint = new IPEndPoint(IPAddress.Parse(ipAddress), ConfigHelper.SocketPortFtp);
                connectedNodesTable[userId] = iePoint;
                Logger.info(" 사용자추가 id : " + userId + "IP 주소 : " + ipAddress + "  port : " + ConfigHelper.SocketPortFtp);
            }
        }

        public static void RemoveLoginUser(string key)
        {
            lock (lockConnectedNodes)
            {
                connectedNodesTable.Remove(key);
                Logger.info(" 사용자삭제 id : " + key);
            }
        }

        public static IPEndPoint GetLoginUserNode(string userId)
        {
            IPEndPoint result;
            lock (lockConnectedNodes)
            {
                result = connectedNodesTable[userId];
            }
            return result;
        }

        public static bool ContainLoginUserNode(string key)
        {
            bool result = false;
            lock (lockConnectedNodes)
            {
                result = (connectedNodesTable.ContainsKey(key) && connectedNodesTable[key] != null);
            }
            return result;
        }

        public static void ClearMembers()
        {
            membersTable.Clear();
            membersTableByTeam.Clear();
        }

        public static void ClearLoginUsers()
        {
            lock (lockConnectedNodes)
            {
                connectedNodesTable.Clear();
            }
        }

        public static void ClearAll()
        {
            lock (lockConnectedNodes)
            {
                membersTable.Clear();
                membersTableByTeam.Clear();
                connectedNodesTable.Clear();
            }
        }

    }
}
