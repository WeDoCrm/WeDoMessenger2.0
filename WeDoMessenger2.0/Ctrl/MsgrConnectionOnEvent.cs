using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WeDoCommon.Sockets;
using WeDoCommon;

namespace Client
{
    public partial class MsgrConnection
    {
        #region 샘플 이벤트 처리
        /// <summary>
        /// 샘플 이벤트 처리
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
                handler(this, e);
        }
        /// <summary>
        /// 샘플 이벤트 선언
        /// </summary>
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        #endregion

        #region 쪽지받았을때
        protected virtual void OnMemoMsgReceived(CustomEventArgs e) 
        {
            EventHandler<CustomEventArgs> handler = MemoMsgReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }

        public event EventHandler<CustomEventArgs> MemoMsgReceived;
        #endregion

        #region 특정 팀목록 받았을때
        protected virtual void OnTeamListReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = TeamListReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }

        public event EventHandler<CustomEventArgs> TeamListReceived;
        #endregion

        #region 특정 팀목록 수신 완료
        protected virtual void OnTeamListReceiveDone()
        {
            EventHandler handler = TeamListReceiveDone;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler TeamListReceiveDone;
        #endregion
        
        #region 직원상태 변경됐을때
        protected virtual void OnMemberStatusReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = MemberStatusReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }

        public event EventHandler<CustomEventArgs> MemberStatusReceived;
        #endregion

        #region 채팅상대방 상태 변경됐을때
        protected virtual void OnChatterStatusReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = ChatterStatusReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }

        public event EventHandler<CustomEventArgs> ChatterStatusReceived;
        #endregion

        #region FTP관련
        /// ///////////////////////////////////////////////////////////////////
        #region FTP 전송자: 전송진행시
        protected virtual void OnFTPSendingProgressed(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPSendingProgressed;
            if (handler != null)
                owner.Invoke(handler, this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPSendingProgressed;
        #endregion

        #region FTP 전송자: 전송완료시
        protected virtual void OnFTPSendingFinished(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPSendingFinished;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPSendingFinished;
        #endregion

        #region FTP 전송자: 전송취소시
        protected virtual void OnFTPSendingCanceled(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPSendingCanceled;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPSendingCanceled;
        #endregion

        #region FTP 전송자: 전송실패시
        protected virtual void OnFTPSendingFailed(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPSendingFailed;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPSendingFailed;
        #endregion

        #region FTP 수신자: 파일전송 알림이벤트 받음
        protected virtual void OnFTPSendingNotified(SocFTPInfoEventArgs<FTPRcvObj> e)
        {
            EventHandler<SocFTPInfoEventArgs<FTPRcvObj>> handler = FTPSendingNotified;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<SocFTPInfoEventArgs<FTPRcvObj>> FTPSendingNotified;
        #endregion

        #region FTP 수신자: 리스너 기동 완료
        protected virtual void OnFTPReadyToListen(SocStatusEventArgs e)
        {
            EventHandler<SocStatusEventArgs> handler = FTPReadyToListen;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<SocStatusEventArgs> FTPReadyToListen;
        #endregion

        #region FTP 전송자: 파일전송 승락이벤트받음
        protected virtual void OnFTPSendingAccepted(SocFTPInfoEventArgs<FTPSendObj> e)
        {
            EventHandler<SocFTPInfoEventArgs<FTPSendObj>> handler = FTPSendingAccepted;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<SocFTPInfoEventArgs<FTPSendObj>> FTPSendingAccepted;
        #endregion

        #region FTP 전송자: 파일전송 거부이벤트받음
        protected virtual void OnFTPSendingRejected(SocFTPInfoEventArgs<FTPSendObj> e)
        {
            EventHandler<SocFTPInfoEventArgs<FTPSendObj>> handler = FTPSendingRejected;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<SocFTPInfoEventArgs<FTPSendObj>> FTPSendingRejected;
        #endregion

        #region FTP수신자: 파일수신진행
        protected virtual void OnFTPReceivingProgressed(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPReceivingProgressed;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPReceivingProgressed;
        #endregion

        #region FTP수신자: 파일수신완료
        protected virtual void OnFTPReceivingFinished(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPReceivingFinished;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPReceivingFinished;
        #endregion
      
        #region FTP수신자: 파일수신취소
        protected virtual void OnFTPReceivingCanceled(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPReceivingCanceled;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPReceivingCanceled;
        #endregion

        #region FTP수신자: 파일수신오류
        protected virtual void OnFTPReceivingFailed(FTPStatusEventArgs e)
        {
            EventHandler<FTPStatusEventArgs> handler = FTPReceivingFailed;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<FTPStatusEventArgs> FTPReceivingFailed;
        #endregion
        /////////////////////////////////////////////////////////////////////////
#endregion

        #region DB 공지목록 받았을때
        protected virtual void OnNoticeResultFromDBReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = NoticeResultFromDBReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }

        public event EventHandler<CustomEventArgs> NoticeResultFromDBReceived;
        #endregion

        #region 로그인 실패시
        protected virtual void OnLoginFailed(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = LoginFailed;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> LoginFailed;
        #endregion

        #region 로그인 성공
        protected virtual void OnLoginPassed(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = LoginPassed;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> LoginPassed;
        #endregion

        #region 재로그인 시도경고 수신
        protected virtual void OnLoginDupped()
        {
            EventHandler handler = LoginDupped;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler LoginDupped;
        #endregion

        #region 서버측 강제로그아웃 수신
        protected virtual void OnForcedLogoutNotified()
        {
            EventHandler handler = ForcedLogoutNotified;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler ForcedLogoutNotified;
        #endregion

        #region 새 대화메시지 수신
        protected virtual void OnNewChatMsgReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = NewChatMsgReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> NewChatMsgReceived;
        #endregion

        #region 기존창 대화메시지 수신
        protected virtual void OnChatMsgAdded(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = ChatMsgAdded;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> ChatMsgAdded;
        #endregion

        #region 대화자 채팅창 초대됨
        protected virtual void OnChatterInvited(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = ChatterInvited;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> ChatterInvited;
        #endregion

        #region 대화자 채팅창빠짐
        protected virtual void OnChatterQuit(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = ChatterQuit;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> ChatterQuit;
        #endregion

        #region 공지 확인 수신
        protected virtual void OnNoticeCheckNotified(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = NoticeCheckNotified;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> NoticeCheckNotified;
        #endregion

        #region 공지 실시간 수신
        protected virtual void OnInstantNoticeReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = InstantNoticeReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> InstantNoticeReceived;
        #endregion

        #region 부재중 데이터건수 수신
        protected virtual void OnUnCheckedDataReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = UnCheckedDataReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> UnCheckedDataReceived;
        #endregion

        #region 부재중 메모목록 수신
        protected virtual void OnUnCheckedMemoReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = UnCheckedMemoReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> UnCheckedMemoReceived;
        #endregion

        #region 부재중 공지목록 수신
        protected virtual void OnUnCheckedNoticeReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = UnCheckedNoticeReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> UnCheckedNoticeReceived;
        #endregion

        #region 부재중 이관목록 수신
        protected virtual void OnUnCheckedTransferReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = UnCheckedTransferReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> UnCheckedTransferReceived;
        #endregion

        #region 공지목록 수신
        protected virtual void OnNoticeListReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = NoticeListReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> NoticeListReceived;
        #endregion    
    
        #region 고객정보 이관받았을대
        protected virtual void OnCustomerInfoTransfered(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = CustomerInfoTransfered;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> CustomerInfoTransfered;
        #endregion    

        #region CallControl관련
        #region Ringing수신
        protected virtual void OnCallRingingReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = CallRingingReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> CallRingingReceived;
        #endregion

        #region Dialing수신
        protected virtual void OnCallDialingReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = CallDialingReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> CallDialingReceived;
        #endregion

        #region Answer수신
        protected virtual void OnCallAnswerReceived(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = CallAnswerReceived;
            if (handler != null)
                owner.Invoke(handler,this, e);
        }
        public event EventHandler<CustomEventArgs> CallAnswerReceived;
        #endregion

        #region Abandon 수신
        protected virtual void OnCallAbandonReceived()
        {
            EventHandler handler = CallAbandonReceived;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler CallAbandonReceived;
        #endregion

        #region OtherAnswer 당겨받기수신
        protected virtual void OnCallOtherAnswerReceived()
        {
            EventHandler handler = CallOtherAnswerReceived;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler CallOtherAnswerReceived;
        #endregion
        #endregion
        
        #region 서버체크 실패시
        protected virtual void OnServerCheckFailed()
        {
            EventHandler handler = ServerCheckFailed;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler ServerCheckFailed;
        #endregion

        #region 서버체크 성공시
        protected virtual void OnServerCheckSucceeded()
        {
            EventHandler handler = ServerCheckSucceeded;
            if (handler != null)
                owner.Invoke(handler,this, EventArgs.Empty);
        }
        public event EventHandler ServerCheckSucceeded;
        #endregion
    }

    #region 이벤트인자 정의
    public class MemoMsgReceivedEventArgs : EventArgs
    {
        private MemoObj _data;
        public MemoObj Data { get {return _data;}}
        public MemoMsgReceivedEventArgs(string[] msgToken)
        {
            _data = new MemoObj(msgToken);
        }
        public MemoMsgReceivedEventArgs(MemoObj data)
        {
            _data = data;
        }
    }
    
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class FTPResultReceivedEventArgs : EventArgs
    {
        private string message;
        public string Message { get { return message; } }
        private string key;
        public string Key { get { return key; } }
        private string receiverId;
        public string ReceiverId { get { return receiverId; } }
        private int transRate;
        public int TransRate { get { return transRate; } }
        private DownloadStatus status;
        public DownloadStatus Status { get { return status; } }

        public FTPResultReceivedEventArgs(string message, string key, string receiverId)
        {
            this.message = message;
            this.key = key;
            this.receiverId = receiverId;
        }
        public FTPResultReceivedEventArgs(string message, string key, DownloadStatus status, int transRate)
        {
            this.message = message;
            this.key = key;
            this.status = status;
            this.transRate = transRate;
        }
    }
    #endregion
}
