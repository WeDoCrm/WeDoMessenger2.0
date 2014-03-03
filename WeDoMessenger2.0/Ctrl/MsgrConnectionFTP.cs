using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon.Sockets;
using Client.Common;
using System.Threading;
using WeDoCommon;
using System.Windows.Forms;
using System.IO;

namespace Client
{

    public partial class MsgrConnection
    {
        public void StartFTPListeing(FTPRcvObj rcvObj, string savePath)
        {
            try
            {
                if (mFtpServer == null || !mFtpServer.isListening())
                {
                    string path;
                    if (savePath != null && !savePath.Trim().Equals("")) path = savePath;
                    else
                        path = string.Format(WeDoCommon.ConstDef.MSGR_DATA_FILE_DIR, ConfigHelper.Id);
                    StateObject stateObj = new StateObject();
                    mFtpServer = new FtpServerMgr(ConfigHelper.SocketPortFtp, path);
                    mFtpServer.SocStatusChanged += DisplayFTPStatusOnStatusChanged;
                    mFtpServer.ReadyToListen += ProcessOnFTPReadyToListen;
                    mFtpServer.FTPReceivingProgressed += ProcessOnFTPReceivingProgressed;
                    mFtpServer.FTPReceivingFinished += ProcessOnFTPReceivingFinished;
                    mFtpServer.FTPReceivingCanceled += ProcessOnFTPReceivingCanceled;
                    mFtpServer.FTPReceivingFailed += ProcessOnFTPReceivingFailed;
                    mFtpServer.DoRun(stateObj);
                }
                else
                {
                    OnFTPReadyToListen(new SocStatusEventArgs(new StateObject()));
                }
            }
            catch (Exception e)
            {
                Logger.error("StartFTPListeing 에러 : " + e.ToString());
            }
        }

        public void CancelFTPReceiving(StateObject stateObj)
        {
            if (mFtpServer != null)
                mFtpServer.CancelReceiving(stateObj);
        }

        /// <summary>
        /// ftp listener가 준비완료되었을때.
        /// ==> ready message를 전송한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPReadyToListen(object sender, SocStatusEventArgs e)
        {
            if (mFtpServer.isListening())
                OnFTPReadyToListen(e);
        }

        public void DisplayFTPStatusOnStatusChanged(object sender, SocStatusEventArgs e)
        {
            Logger.info(e.Status);
        }

        /// <summary>
        /// FTP 전송자: 전송진행시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingProgressed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.Status.Key))
                    OnFTPSendingProgressed(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP 전송자: 전송완료시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingFinished(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.Status.Key))
                    OnFTPSendingFinished(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP 전송자: 전송취소시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingCanceled(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.Status.Key))
                    OnFTPSendingCanceled(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
        
                /// <summary>
        /// FTP 전송자: 전송오류시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingFailed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.Status.Key))
                    OnFTPSendingFailed(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

                /// <summary>
        /// FTP 전송자: 접속오류시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPConnectionError(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.Status.Key))
                    OnFTPSendingFailed(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP 수신자: 파일전송 알림이벤트 받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingNotified(object sender, SocFTPInfoEventArgs<FTPRcvObj> e)
        {
            if (Members.ContainLoginUserNode(e.GetObj.SenderId)) //전송대상자가 로그인 상태인 경우
                OnFTPSendingNotified(e);
            else
                Logger.error(string.Format("파일전송자가 접속상태가 아님 파일[{0}]전송자[{1}]", e.GetObj.FileName, e.GetObj.SenderId));
        }

        /// <summary>
        /// FTP 전송자: 파일전송 승락이벤트받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingAccepted(object sender, SocFTPInfoEventArgs<FTPSendObj> e)
        {
            //수신준비된것이 확인됨.==> 상위에서 이미 FTP기동
            try
            {
                if (SendFileForms.ContainClientKey(e.GetObj.Key))
                    OnFTPSendingAccepted(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.GetObj.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP 전송자: 파일전송 거부이벤트받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingRejected(object sender, SocFTPInfoEventArgs<FTPSendObj> e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(e.GetObj.Key))
                    OnFTPSendingRejected(e);
                else
                    Logger.info(string.Format("에러 : SendFileForms 해당화면없음.Status.Key[{0}]", e.GetObj.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP수신자: 파일수신진행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPReceivingProgressed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (DownloadForms.Contain(e.Status.Key))
                {
                    Logger.info(string.Format("파일수신 진행 ProcessOnFTPReceivingProgressed.Status.Data[{0}]", e.Status.Data));
                    OnFTPReceivingProgressed(e);
                }
                else
                    Logger.info(string.Format("에러 : DownloadForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
        /// <summary>
        /// FTP수신자: 파일수신완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPReceivingFinished(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (DownloadForms.Contain(e.Status.Key))
                    OnFTPReceivingFinished(e);
                else
                    Logger.info(string.Format("에러 : DownloadForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP수신자: 파일수신취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPReceivingCanceled(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (DownloadForms.Contain(e.Status.Key))
                    OnFTPReceivingCanceled(e);
                else
                    Logger.info(string.Format("에러 : DownloadForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// FTP수신자: 파일수신오류
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPReceivingFailed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (DownloadForms.Contain(e.Status.Key))
                    OnFTPReceivingFailed(e);
                else
                    Logger.info(string.Format("에러 : DownloadForms 해당화면없음.Status.Key[{0}]", e.Status.Key));
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
    
    }
}
