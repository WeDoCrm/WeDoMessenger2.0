using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Client.Common;
using System.Net;
using WeDoCommon;
using WeDoCommon.Sockets;

namespace Client
{
    public partial class MsgrConnection
    {
        #region //서버로 전송
        public bool SendMsgToServer(string msg)
        {
            return msgClient.SendMsg(msg);
        }
        #endregion

        #region //로그인요청
        internal const string SEND_MSG_USER_LOGIN = "8|{0}|{1}|{2}|{3}"; //msg 구성 : 8|id|비밀번호|내선번호|ip주소
        public bool SendMsgUserLogin() {
            string msg = string.Format(SEND_MSG_USER_LOGIN, ConfigHelper.TryId, 
                                        ConfigHelper.TryPass, ConfigHelper.Extension, ConfigHelper.ServerIp);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //중복 로그인 상황에서 기존접속 끊기
        internal const string SEND_MSG_DISCONNECT_PREV_LOGIN = "2|{0}";//msg 구성 : 2|id
        public bool SendMsgDisconnectPrevLogin() {
            string msg = string.Format(SEND_MSG_DISCONNECT_PREV_LOGIN, ConfigHelper.TryId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //공지사항 목록 요청(1|id)
        internal const string SEND_MSG_REQ_NOTICE_LIST_ALL = "1|{0}";//msg 구성 : 1|id
        public bool SendMsgRequestNoticeListAll() {
            string msg = string.Format(SEND_MSG_REQ_NOTICE_LIST_ALL, ConfigHelper.TryId);
            return SendMsgToServer(msg);
        }
        #endregion
        
        #region //대화종료
        internal const string SEND_MSG_QUIT_CHAT = "0";//msg 구성 : 1|id
        public bool SendMsgQuitChat() {
            string msg = SEND_MSG_QUIT_CHAT;
            return SendMsgToServer(msg);
        }
        #endregion

        #region //메모 부재중처리(상대방 부재)
        internal const string SEND_MSG_SAVE_MEMO_ON_AWAY = "4|{0}|{1}|{2}|{3}";//msg 구성 : 4|발신자name|발신자id|메시지|수신자id
        public bool SendMsgSaveMemoOnAway(MemoObj obj)
        {
            string msg = string.Format(SEND_MSG_SAVE_MEMO_ON_AWAY, Members.GetByUserId(ConfigHelper.Id).Name, ConfigHelper.Id, Utils.EncodeMsg(obj.Content), obj.ReceiverId);
            return SendMsgToServer(msg);
        }
        #endregion
        
        #region //메모 부재중처리(전송실패로 메모 반송)
        internal const string SEND_MSG_SAVE_MEMO_ON_FAIL = "4|m|{0}|{1}|{2}|{3}";//msg 구성 : 4|m|발신자name|발신자id|메시지|수신자id
        public bool SendMsgSaveMemoOnFail(MemoObj obj) {
            string msg = string.Format(SEND_MSG_SAVE_MEMO_ON_FAIL, Members.GetByUserId(ConfigHelper.Id).Name, ConfigHelper.Id, Utils.EncodeMsg(obj.Content), obj.ReceiverId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //사용자 로그인 상태 체크요청(3|id)
        internal const string SEND_MSG_CHECK_LOGIN = "3|{0}";//msg 구성 3|id
        public bool SendMsgCheckLogin(string userId)
        {
            string msg = string.Format(SEND_MSG_CHECK_LOGIN, userId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //공지사항 전달
        internal const string SEND_MSG_REGISTER_NOTICE = "6|{0}|{1}|{2}|{3}|{4}";//msg 구성 6|메시지|발신자id | n 또는 e | noticetime | 제목)  n : 일반공지 , e : 긴급공지
        public bool SendMsgRegisterNotice(NoticeObj obj) {
            string msg = string.Format(SEND_MSG_REGISTER_NOTICE, Utils.EncodeMsg(obj.Content), ConfigHelper.Id, obj.StrMode, obj.NoticeTime, Utils.EncodeMsg(obj.Title));
            return SendMsgToServer(msg);
        }
        #endregion

        #region //로그아웃
        internal const string SEND_MSG_USER_LOGOUT = "9|{0}";//msg 구성 : 코드번호|id
        public bool SendMsgUserLogOut() {
            string msg = string.Format(SEND_MSG_USER_LOGOUT, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //안읽은 메모 요청
        internal const string SEND_MSG_REQ_UNREAD_MEMO = "7|{0}";//msg 구성 : 코드번호|id
        public bool SendMsgReqUnReadMemo() {
            string msg = string.Format(SEND_MSG_REQ_UNREAD_MEMO, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //안받은 파일 요청==> 폐기
        //internal const string SEND_MSG_REQ_UNREAD_FILE = "10|{0}";//msg 구성 : 코드번호|id
        //public bool SendMsgReqUnReadFile() {
        //    string msg = string.Format(SEND_MSG_REQ_UNREAD_FILE, ConfigHelper.Id);
        //    return SendMsgToServer(msg);
        //}
        #endregion

        #region //안읽은 공지 요청(11|id)
        internal const string SEND_MSG_REQ_UNREAD_NOTICE = "11|{0}";//msg 구성 : 코드번호|id
        public bool SendMsgReqUnReadNotice() {
            string msg = string.Format(SEND_MSG_REQ_UNREAD_NOTICE, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //파일 전송 요청 ==> 폐기
        //internal const string SEND_MSG_REQ_FILE_SEND = "12|{0}|{1}";//msg 구성 : 12|id|filenum
        //public bool SendMsgReqFileSend(int fileNum) {
        //    string msg = string.Format(SEND_MSG_REQ_FILE_SEND, ConfigHelper.Id, Convert.ToString(fileNum));
        //    return SendMsgToServer(msg);
        //}
        #endregion

        #region //보낸 공지 리스트 요청(내가 등록한 공지 + 부재중 공지)==> 안쓰임
        internal const string SEND_MSG_REQ_NOTICE_LIST = "13|{0}";//msg 구성 : 13|id
        public bool SendMsgReqNoticeList() {
            string msg = string.Format(SEND_MSG_REQ_NOTICE_LIST, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //읽은 정보(메모/공지/이관/파일) 삭제 요청
        internal const string SEND_MSG_DELETE_UNREAD_ON_CHECKED = "14|{0}";//msg 구성 : 14|seqnum
        public bool SendMsgDeleteUnReadOnChecked(int listNum) {
            string msg = string.Format(SEND_MSG_DELETE_UNREAD_ON_CHECKED, Convert.ToString(listNum));
            return SendMsgToServer(msg);
        }
        #endregion

        #region //관리자 공지 삭제
        internal const string SEND_MSG_ADMIN_DELETE_NOTICE = "15|{0}";//msg 구성 : 15|seqnum;seqnum;seqnum;...
        public bool SendMsgAdminDeleteNotice(int listNums) {
            string msg = string.Format(SEND_MSG_ADMIN_DELETE_NOTICE, listNums);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //채팅메시지 전달
        internal const string SEND_MSG_USER_CHAT_MSG = "16|{0}|{1}|{2}|{3}";//msg 구성 : 16|Formkey|id/id/..|발신자name|메시지
        public bool SendMsgUserChatMsg(string formKey, string idList, string message) {
            string msg = string.Format(SEND_MSG_USER_CHAT_MSG, formKey, idList, Members.GetByUserId(ConfigHelper.Id).Name, Utils.EncodeMsg(message));
            return SendMsgToServer(msg);
        }
        #endregion

        #region //추가한 상담원 리스트 기존 대화자에게 전송
        internal const string SEND_MSG_NOTIFY_ADDED_USERS = "17|{0}|{1}|{2}|{3}";//msg 구성 : 17|formkey|id/id/...|name|receiverID
        public bool SendMsgNotifyAddedUsers(string formKey, string idList, string recvId) {
            string msg = string.Format(SEND_MSG_NOTIFY_ADDED_USERS, formKey, idList, Members.GetByUserId(ConfigHelper.Id).Name, recvId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //대화종료알림: 2명 이상과 대화중 폼을 닫은 경우
        internal const string SEND_MSG_NOTIFY_CHATFORM_CLOSED = "18|q|{0}|{1}|{2}";//msg 구성 : 18|q|Formkey|id|receiverID
        public bool SendMsgNotifyChatFormClosed(string formKey, string recvId) {
            string msg = string.Format(SEND_MSG_NOTIFY_CHATFORM_CLOSED, formKey, ConfigHelper.Id, recvId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //쪽지 전송요청
        internal const string SEND_MSG_DELIVER_MEMO = "19|m|{0}|{1}|{2}|{3}";//msg 구성 : 19|m|발송자name|발송자id|content|수신자id
        public bool SendMsgDeliverMemo(MemoObj obj) {
            string msg = string.Format(SEND_MSG_DELIVER_MEMO, Members.GetByUserId(ConfigHelper.Id).Name, ConfigHelper.Id, Utils.EncodeMsg(obj.Content), obj.ReceiverId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //상태변경 알림
        internal const string SEND_MSG_CHANGE_STATUS = "20|{0}|{1}";//msg 구성 : 20|senderid|상태
        public bool SendMsgChangeStatus(string status) {
            string msg = string.Format(SEND_MSG_CHANGE_STATUS, ConfigHelper.Id, status);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //공지 읽음 확인 메시지
        internal const string SEND_MSG_NOTIFY_NOTICE_READ = "21|{0}|{1}|{2}";//msg 구성 : 21 | receiverid | notice id | sender id
        public bool SendMsgNotifyNoticeRead(NoticeObj obj) {
            string msg = string.Format(SEND_MSG_NOTIFY_NOTICE_READ, ConfigHelper.Id, obj.NoticeTime, obj.SenderId);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //고객정보 전달시도(이관)
        internal const string SEND_MSG_TRANSFER_CUSTOMER_INFO = "22|{0}|{1}|{2}|{3}|{4}|{5}";//msg 구성 : 22&ani&senderID&receiverID&일자&시간&CustomerName
        public bool SendMsgTransferCustomerInfo(TransferObj obj) {
            string msg = string.Format(SEND_MSG_TRANSFER_CUSTOMER_INFO, obj.Ani, obj.SenderId, 
                                            obj.ReceiverId, obj.TongDate, obj.TongTime, obj.CustomerName);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //안읽은 이관 요청
        internal const string SEND_MSG_REQ_UNREAD_TRANSFER = "23|{0}";//msg 구성 : 23|id
        public bool SendMsgReqUnreadTransfer() {
            string msg = string.Format(SEND_MSG_REQ_UNREAD_TRANSFER, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion

        #region //파일정보 보내기
        public bool SendMsgNotifyFileInfo(string fullFileName, long fileSize, string timeKey, string receiverId)
        {
            IPEndPoint iep = Members.GetLoginUserNode(receiverId);
            iep.Port = ConfigHelper.SocketPortFtp;
            return msgClient.NotifyFTPStart(iep, receiverId, fullFileName, fileSize);
        }
        #endregion

        #region //파일수신 수락
        public bool SendMsgAcceptFTP(FTPRcvObj obj)
        {
            return msgClient.NotifyFTPReady(obj.RemoteEndPoint, obj.SenderId, obj.FileName, obj.FileSize);
        }
        #endregion

        #region //파일수신 거부
        public bool SendMsgRejectFTP(FTPRcvObj obj)
        {
            return msgClient.NotifyFTPReject(obj.RemoteEndPoint, obj.SenderId, obj.FileName, obj.FileSize);
        }
        #endregion

        #region //파일전송 취소
        public void CancelFTPSending(FTPSendObj obj)
        {
            msgClient.CancelFTPSending(obj.Key);
        }
        #endregion

        #region //다른 사용자(들)에게 파일 전송 준비
        /// <summary>
        /// 다른 사용자(들)에게 파일 전송 준비
        /// </summary>
        /// <param name="list">파일 전송 대상자 목록</param>
        /// <param name="filename">파일명</param>
        /// <param name="timekey">파일전송시간(여러 파일전송작업 간 구분키가 됨)</param>
        public bool NotifyFileSend(List<MemberObj> receiverList, string fileName, string formKey)
        {
            bool result = false;
            try
            {
                FileInfo fi = new FileInfo(fileName);
                long fileSize = fi.Length;
                //파일 정보 보내기(F|파일명|파일크기|파일key|전송자id)
                foreach (MemberObj receiver in receiverList)
                {
                    if (Members.ContainLoginUserNode(receiver.Id)) //전송대상자가 로그인 상태인 경우
                    {
                        //msgClient.NotifyFTPStart(new IPEndPoint(Utils.getIPfromHost(mHostName), SocConst.FTP_PORT), MsgDef.FTP_ON_SERVER, mFullFileName, mFileSize);
                        this.SendMsgNotifyFileInfo(fileName, fileSize, formKey, receiver.Id);
                        SendFileForms.AddClientKey(fileName, fileSize, receiver.Id, formKey);
                    }
                    else  
                    {
                        //전송대상자가 로그아웃 상태인 경우
                    }
                }
                result = true;
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
            return result;
        }
        #endregion

        #region//미확인건(쪽지, 공지, 파일, 이관)변경
        /// <summary>
        /// 메인에 미확인건(쪽지, 공지, 파일, 이관)변경
        /// </summary>
        /// <param name="memoCnt">쪽지건수</param>
        /// <param name="noticeCnt">공지건수</param>
        /// <param name="fileCnt">파일건수</param>
        /// <param name="transCnt">이관건수</param>
        public void UpdateUnCheckedData(int memoCnt, int noticeCnt, int fileCnt, int transCnt)
        {
            OnUnCheckedDataReceived(new CustomEventArgs(new int[]{memoCnt, noticeCnt, fileCnt, transCnt}));
        }
        #endregion


        #region 이관처리
        /// <summary>
        /// 부재중 이관처리건 확인
        /// </summary>
        public void PopUpUncheckedTransfer(string ani, string callType)
        {
            OnCallDialingReceived(new CustomEventArgs(new string[] { ani, callType }));
        }
        #endregion
        
        #region //서버접속체크
        internal const string SEND_MSG_PING = "24";//msg 구성 24
        public bool SendMsgPing()
        {
            string msg = string.Format(SEND_MSG_PING, ConfigHelper.Id);
            return SendMsgToServer(msg);
        }
        #endregion
    }
}
