using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using WeDoCommon;
using System.Threading;
using Client.Common;

namespace Client {

    public partial class MsgrConnection
    {
        /// <summary>
        /// 수신된 메시지를 분석하여 각 요청에 맞게 처리
        /// </summary>
        /// <param name="obj">ArrayList로 형변환할 Object</param>
        protected void MsgFilter(object obj, IPEndPoint iep)
        {
            try
            {
                string msg = ((string)obj).Trim(); //수신 메시지
                string tempFormKey;
                string[] tempMsg = msg.Split('|');
                string code = tempMsg[0];

                switch (code)
                {
                    #region "f"//로그인 실패시(f|n or p)
                    case "f":
                        {
                            isLoggedOn = false;
                            string errmsg;
                            if (tempMsg[1].Equals("n"))
                                errmsg = "등록되지 않은 사용자 입니다.";
                            else
                                errmsg = "비밀번호가 틀렸습니다.";
                            OnLoginFailed(new CustomEventArgs(errmsg));
                        }
                        break;
                    #endregion

                    #region "g"//로그인 성공시 (g|name|team|company|com_cd|db_port)
                    case "g": //로그인 성공시 (g|name|team|company|com_cd|db_port)
                        isLoggedOn = true;
                        ConfigHelper.DbServerIp = serverIP;
                        ConfigHelper.DbPort = Convert.ToInt16(tempMsg[5]);

                        //서버측에서 전달된 이름 저장
                        ConfigHelper.Id = ConfigHelper.TryId;
                        ConfigHelper.Pass = ConfigHelper.TryPass;
                        ConfigHelper.CompanyCode = tempMsg[4];
                        ConfigHelper.CompanyName = tempMsg[3];
                        Logger.info("로그인 성공");
                        ConfigHelper.Name = tempMsg[1];
                        ConfigHelper.TeamName = tempMsg[2];

                        OnLoginPassed(new CustomEventArgs());

                        if (checkThread == null)
                        {
                            checkThread = new Thread(new ThreadStart(SendCheck));
                            checkThread.Start();
                            Logger.info("SendCheck 스레드 시작");
                        }

                        break;
                    #endregion

                    #region "a"//재로그인 이미 로그인상태알려줌
                    case "a":  //중복로그인 시도를 알려줌
                        isLoggedOn = false;
                        ConfigHelper.Id = ConfigHelper.TryId;
                        ConfigHelper.Pass = ConfigHelper.TryPass;
                        OnLoginDupped();
                        break;
                    #endregion

                    #region "M"//다른 클라이언트 목록 및 접속상태 정보(M|팀이름|id!멤버이름|id!멤버이름)
                    case "M": //다른 클라이언트 목록 및 접속상태 정보(M|팀이름|id!멤버이름|id!멤버이름)
                        if (tempMsg[1].Equals("e"))
                        { //모든 팀트리 정보 전송완료 메시지일 경우 -> Client_Form을 로그인 상태로 하위 구성요소를 활성화 한다.
                            OnTeamListReceiveDone();
                        }
                        else
                        { // 팀트리 정보를 수신한 경우
                            if (tempMsg.Length > 2)
                            {
                                Members.AddMembers(msg);
                                string teamName = tempMsg[1];
                                OnTeamListReceived(new CustomEventArgs(teamName));
                            }
                        }
                        break;
                    #endregion

                    #region "y"//로그인 Client 리스트 상태값
                    case "y":    //로그인 Client 리스트 y|id|상태값|ipaddress 
                        {
                            MemberObj memberObj = Members.GetByUserId(tempMsg[1]);
                            memberObj.Status = tempMsg[2];
                            //1. 로그인 리스트 테이블에 추가
                            Members.AddLoginUser(tempMsg[1], tempMsg[3]);
                            //2. memTree 뷰에 로그인 사용자 상태 변경
                            OnMemberStatusReceived(new CustomEventArgs(memberObj));
                            this.OnMemberStatusReceived(new CustomEventArgs(memberObj));
                            break;
                        }
                    #endregion
                        
                    #region "u"//서버측에서 강제 로그아웃 메시지 수신한 경우
                    case "u": //서버측에서 강제 로그아웃 메시지 수신한 경우
                        isLoggedOn = false;
                        OnForcedLogoutNotified();
                        break;
                    #endregion

                    #region "d"//상대방 대화메시지
                    case "d":  //상대방 대화메시지일 경우 (d|Formkey|id/id/...|name|메시지)
                        {
                            ChatObj chatObj = new ChatObj(tempMsg);
                            if (!chatObj.UserId.Equals(ConfigHelper.Id))
                            {
                                if (ChatForms.Contain(chatObj.ChatKey))
                                 //이미 발신자와 채팅중일 경우
                                    OnChatMsgAdded(new CustomEventArgs(chatObj));
                                
                                else
                                  //새로운 대화요청일 경우, 대화창 생성
                                    OnNewChatMsgReceived(new CustomEventArgs(chatObj));
                            }
                        }
                        break;
                    #endregion

                    #region "c"//대화중 초대
                    case "c":  //c|formkey|id/id/..|name  //대화중 초대가 일어난 경우
                        {
                            ChatObj chatObj = new ChatObj(tempMsg);
                            if (ChatForms.Contain(chatObj.ChatKey))
                                OnChatterInvited(new CustomEventArgs(chatObj));
                            else
                                Logger.info(string.Format("'c' key[{0}]를 갖는 채팅창이 존재하지 않음.", chatObj.ChatKey));
                        }
                        break;
                    #endregion

                    #region "C"//보낸공지 읽음확인 수신
                    case "C":  //보낸공지 읽음확인 수신(C|확인자id|noticeid)
                        OnNoticeCheckNotified(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "q"|"dc"//다자 대화중 상대방이 대화창 나감
                    case "q": //다자 대화중 상대방이 대화창 나감 (q|Formkey|id)
                    case "dc": //다자 대화중 상대방이 연결 끊김 (dc|Formkey|id)
                        {
                            ChatObj chatObj = new ChatObj(tempMsg);
                            if (ChatForms.Contain(chatObj.ChatKey))
                                OnChatterQuit(new CustomEventArgs(chatObj));
                            else
                                Logger.info(string.Format("'q' key[{0}]를 갖는 채팅창이 존재하지 않음.", chatObj.ChatKey));
                        }
                        break;
                    #endregion

                    #region "m"//메모를 수신한 경우
                    case "m": //메모를 수신한 경우 m|name|id|message|수신자id
                        {
                            MemoObj memoObj = new MemoObj(tempMsg);
                            OnMemoMsgReceived(new CustomEventArgs(memoObj));
                            MemoUtils.MemoFileWrite(ConfigHelper.Id, memoObj);
                            break;
                        }
                    #endregion

                    #region "i"//사용자 로그인 알림
                    case "i":  //추가 로그인 상담원일 경우  형태 : i|id|소속팀명|ip|이름
                        {
                            MemberObj memberObj = Members.GetByUserId(tempMsg[1]);
                            memberObj.Status = MsgrUserStatus.ONLINE;
                            //1. 로그인 리스트 테이블에 추가
                            Members.AddLoginUser(tempMsg[1], tempMsg[3]);

                            //2. memTree 뷰에 로그인 사용자 상태 변경
                            OnMemberStatusReceived(new CustomEventArgs(memberObj));

                            //3. 각 채팅창 key변경 및 채팅창 노드/상태변경
                            OnChatterStatusReceived(new CustomEventArgs(memberObj));

                            //4. 로그인 했음 메시지 창 띄움
                            // 추후 구현
                        }
                        break;
                    #endregion

                    #region "o"//사용자 로그아웃 알림
                    case "o":  //로그아웃 상담원이 발생할 경우  o|id|소속
                        {
                            MemberObj memberObj = Members.GetByUserId(tempMsg[1]);
                            memberObj.Status = MsgrUserStatus.LOGOUT;
                            //1. 로그인 리스트 테이블에서 삭제
                            Members.RemoveLoginUser(tempMsg[1]);
                            //2. memTree 뷰에 로그아웃 사용자 상태 변경
                            OnMemberStatusReceived(new CustomEventArgs(memberObj));

                            //3. 각 채팅창 key변경 및 채팅창 노드/상태변경
                            OnChatterStatusReceived(new CustomEventArgs(memberObj));
                        }
                        break;
                    #endregion

                    #region "n"//공지사항 수신
                    case "n":  //공지사항 메시지 (n|메시지|발신자id|mode|noticetime|제목)
                        {
                        Logger.info("공지사항 수신!");
                        NoticeObj noticeObj = new NoticeObj(tempMsg);
                        if (!noticeObj.SenderId.Equals(ConfigHelper.Id)) //자기가 보낸 공지일 경우 보이지 않음
                            OnInstantNoticeReceived(new CustomEventArgs(noticeObj));

                        break;
                        }
                    #endregion

                    #region "A"//사용자부재 미처리건 정보 수신 
                    case "A": //부재중 정보 전달(A|mnum|fnum|nnum|tnum)
                        OnUnCheckedDataReceived(new CustomEventArgs(new int[] { Convert.ToInt32(tempMsg[1]),
                                                                                Convert.ToInt32(tempMsg[2]),
                                                                                Convert.ToInt32(tempMsg[3]),
                                                                                Convert.ToInt32(tempMsg[4])
                                                                                }));
                        break;
                    #endregion

                    #region "Q"//부재중 안읽은 메모리스트
                    case "Q"://안읽은 메모 리스트 (Q|sender†content†time†seqnum|...|
                        OnUnCheckedMemoReceived(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "T"//부재중 안읽은 공지리스트
                    case "T"://안읽은 공지 리스트 (T|sender†content†time†mode†seqnum†title|sender†content†time†mode†seqnum|...
                        OnUnCheckedNoticeReceived(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "R"//부재중 안읽은 파일리스트==> 안쓰임
                    case "R"://안읽은 파일 리스트 (R|sender†filenum†filename†time†size†seqnum|sender†filenum†filename†time†size†seqnum|...
                        //안쓰임
                        break;
                    #endregion

                    #region "trans"//부재중 이관 메시시 수신
                    case "trans"://부재중 이관 메시시 수신(trans|sender†content†time†seqnum|...)
                        OnUnCheckedTransferReceived(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "t"//DB공지상세목록 수신
                    case "t": //"t|ntime†content†nmode†title†안읽은사람1:안읽은사람2:...|...
                        OnNoticeResultFromDBReceived(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "L"//공지사항목록 수신
                    case "L"://공지사항 리스트 수신한 경우  L|time‡content‡mode‡sender‡seqnum‡title|...  
                        OnNoticeListReceived(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region "s"//각 클라이언트 상태값 변경메시지+ IP주소
                    case "s"://각 클라이언트 상태값 변경 메시지 s|id|상태|IPAddress
                        {
                            if (!tempMsg[1].Equals(ConfigHelper.Id))
                            {
                                MemberObj memberObj = Members.GetByUserId(tempMsg[1]);
                                memberObj.Status = tempMsg[2];
                                //1. 트리상태변경 
                                OnMemberStatusReceived(new CustomEventArgs(memberObj));
                                //2. 로그인리스트 테이블에 추가
                                Members.AddLoginUser(tempMsg[1], tempMsg[3]);
                                //3. 채팅창 상태변경
                                //   각 채팅창 key변경 및 채팅창 노드/상태변경
                                OnChatterStatusReceived(new CustomEventArgs(memberObj));
                            }
                        }
                        break;
                    #endregion

                    #region "pass"//고객정보 전달 수신
                    case "pass"://고객정보 전달 수신(pass|ani|senderID|receiverID|일자|시간|CustomerName
                        OnCustomerInfoTransfered(new CustomEventArgs(tempMsg));
                        break;
                    #endregion

                    #region //전화기능

                    #region "Ring"//Ringing
                    case "Ring": //발신자 표시(Ring|ani|name|server_type)
                        OnCallRingingReceived(new CustomEventArgs(new string[] { tempMsg[1], tempMsg[2], tempMsg[3] }));
                        break;
                    #endregion

                    #region "Dial"//Dialing
                    case "Dial": //다이얼시 고객정보 팝업(Dial|ani)
                        if (!ConfigHelper.NoPopOutBound)
                        {
                            OnCallDialingReceived(new CustomEventArgs(new string[] { tempMsg[1], "2" }));
                        }
                        break;
                    #endregion

                    #region "Answer"//Answer
                    case "Answer": //offhook시 고객정보 팝업(Answer|ani|type)
                        OnCallAnswerReceived(new CustomEventArgs(new string[] { tempMsg[1], tempMsg[2] }));
                        break;
                    #endregion

                    #region "Abandon"//Abandon
                    case "Abandon": //Abandon 발생시
                        OnCallAbandonReceived();
                        break;
                    #endregion

                    #region "Other"//Other 호전환수신
                    case "Other": //다른사람이 응답시
                        OnCallOtherAnswerReceived();
                        break;
                    #endregion
                    #endregion //전화기능

                    #region default //비정상메시지
                    default:
                        Logger.info("지정되지 않은 메시지포맷:" + msg);
                        break;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
        #region 서버코드 참고용
        /*
        public void ParseMessage()
        {
            switch (messageHeader) {
                case "f"://로그인 실패시(f|n or p)
                    break;

                case "g": //로그인 성공시 (g|name|team|company|com_cd|db_port)
                    break;
                case "M": //다른 클라이언트 목록 및 접속상태 정보(M|팀이름|id!멤버이름|id!멤버이름)
                    // M|e ==> 전송완료
                    break;
                case "y":    //로그인 Client 리스트 y|id|상태값 
                    break;
                case "IP":    //로그인 Client 리스트 IP|id|ip주소 
                        break;
                    case "a":  //중복로그인 시도를 알려줌
                        break;
                    case "u": //서버측에서 강제 로그아웃 메시지 수신한 경우
                        break;
                    case "d":  //상대방 대화메시지일 경우 (d|Formkey|id/id/...|name|메시지) 첫번째가 문자올린 대화자
                        break;
                    case "c":  //c|formkey|id/id/..|name  //대화중 초대가 일어난 경우
                        break;
                    case "C":  //보낸공지 읽음확인 수신(C|확인자id|noticeid)
                        break;

                    case "q": //다자 대화중 상대방이 대화창 나감 (q|Formkey|id)
                        break;
                    case "dc": //다자 대화중 상대방이 연결 끊김 (dc|Formkey|id)
                        break;
                    case "A": //부재중 정보 전달(A|mnum|fnum|nnum|tnum)
                        break;
                    case "i":  //추가 로그인 상담원일 경우  형태 : i|id|소속팀명|ip|이름
                        break;
                    case "o":  //로그아웃 상담원이 발생할 경우  o|id|소속
                        break;
                    case "s"://각 클라이언트 상태값 변경 메시지 s|id|상태|IPAddress
                        break;
                    case "Ring": //발신자 표시(Ring|ani|name|server_type)
                        break;
                    case "Dial": //다이얼시 고객정보 팝업(Dial|ani)
                        break;
                    case "Answer": //offhook시 고객정보 팝업(Answer|ani|type)
                        break;
                    case "Abandon": //Abandon 발생시
                        break;
                    case "Other": //다른사람이 응답시
                        break;

                

                    case "R"://안읽은 파일 리스트 (R|sender†filenum†filename†time†size†seqnum|sender†filenum†filename†time†size†seqnum|...
                    NumberedFileObj
                        break;
                    case "F":  //파일받기전 파일 정보 수신     F|파일명|파일크기|파일key|전송자id
                    FileObj
                        break;
                    case "Y"://파일 받기 수락 메시지(Y|파일명|파일key|수신자id)
                        break;
                    case "FS"://파일 받기 수락 메시지(FS|파일명|파일key|수신자id)
                        break;
                    case "N": //파일 받기 거부("N|파일명|파일키|id)
                        break;

                
                    case "n":  //공지사항 메시지 (n|메시지|발신자id|mode|noticetime|제목)
                    NoticeObj
                        break;
                    case "L"://공지사항 리스트 수신한 경우  L|time‡content‡mode‡sender‡seqnum‡title|...  
                    NumberedNoticeObj
                        break;
                    case "T"://안읽은 공지 리스트 (T|sender†content†time†mode†seqnum†title|sender†content†time†mode†seqnum|...
                    UnCheckedNoticeObj
                        break;
                    case "t": //"t|ntime†content†nmode†title†안읽은사람1:안읽은사람2:...|...
                    UserListedNoticeObj
                        break;


                    
                    case "Q"://안읽은 메모 리스트 (Q|sender†content†time†seqnum|...|
                    NumberedMemoObj
                        break;
                    case "m"://메모를 수신한 경우 m|name|id|message|수신자id
                    MemoObj
                        break;

                
                    case "trans"://부재중 이관 메시시 수신(trans|sender†content†time†seqnum|...)
                    TransferObj
                        break;
                    case "pass"://고객정보 전달 수신(pass|ani|senderID|receiverID|일자|시간|CustomerName
                        break;

        }
  */
        #endregion
    }

}
