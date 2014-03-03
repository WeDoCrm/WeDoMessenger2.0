using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Client.Common;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using WeDoCommon;
using WeDoCommon.Sockets;

namespace Client
{
    public partial class MsgrConnection
    {
        private string serverIP = null;

        private MsgrClientManager msgClient;
        private FtpServerMgr mFtpServer;
        private Thread checkThread = null;
        private Form owner;

        private bool isLoggedOn = false;
        /// <summary>
        /// 정상적으로 로그인한경우. 이런 경우 항상 서버체크를 한다.
        /// </summary>
        private string lastMessageReceivedTime;

        public MsgrConnection(Form owner) {
            this.owner = owner;
        }

        public bool IsConnected
        {
            get { return (msgClient != null && msgClient.IsConnected()); }
        }

        public bool StartService()
        {
            bool result = false;
            try
            {
                Logger.info("StartService() 시작");
                //서버 IP구하기
                serverIP = ConfigHelper.ServerIp;
                if (serverIP.ToLower().Equals("localhost")
                    || serverIP.ToLower().Equals("127.0.0.1"))
                {
                    //serverIP = "127.0.0.1";
                    IPHostEntry host = Dns.Resolve(Dns.GetHostName());
                    serverIP = host.AddressList[0].ToString();
                }

                if (msgClient == null || !msgClient.IsConnected())
                {
                    msgClient = new MsgrClientManager(serverIP, ConfigHelper.SocketPortMsgr, ConfigHelper.TryId);
                    msgClient.TCPStatusChanged += ProcessOnTCPStatusChanged;
                    msgClient.ManagerStatusChanged += ProcessOnManagerStatusChanged;
                    msgClient.TCPMsgReceived += ProcessOnMessageReceived;
                    msgClient.FTPSendingProgressed += ProcessOnFTPSendingProgressed;
                    msgClient.FTPSendingFinished += ProcessOnFTPSendingFinished;
                    msgClient.FTPSendingCanceled += ProcessOnFTPSendingCanceled;
                    msgClient.FTPSendingFailed += ProcessOnFTPSendingFailed;
                    msgClient.TCPConnectionError += ProcessOnTCPConnectionError;
                    msgClient.FTPConnectionError += ProcessOnFTPConnectionError;
                    msgClient.FTPSendingNotified += ProcessOnFTPSendingNotified;
                    msgClient.FTPSendingAccepted += ProcessOnFTPSendingAccepted;
                    msgClient.FTPSendingRejected += ProcessOnFTPSendingRejected;

                }
                else
                    Logger.info("[SERVER_CONNECT]Socket Already Inited.");

                if (!msgClient.IsConnected())
                    msgClient.Connect();
                else
                    Logger.info("[SERVER_CONNECT]Server Already Connected.");

                if (msgClient.IsConnected())
                    Logger.info(string.Format("[SERVER_CONNECT]서버 접속.[{0}:{1}]", serverIP, ConfigHelper.SocketPortMsgr));
                else
                    throw new Exception(string.Format("[SERVER_CONNECT]서버 접속실패.[{0}:{1}]", serverIP, ConfigHelper.SocketPortMsgr));

                Thread thMsgReader = new Thread(new ThreadStart(msgClient.ReceiveMessage));
                thMsgReader.Start();
                result = true;
            }
            catch (Exception ex)
            {
                Logger.error("connection.StartService 실행에러 : " + ex.ToString());
            }
            return result;            
        }

        /// <summary>
        /// 서버접속 체크
        /// 체크조건
        /// 1. 접속상태이고 로그인상태
        /// 2. 로그인상태
        /// 3. 1분이내 데이터 수신
        /// 로그아웃하면 이 thread는 종료
        /// </summary>
        private void SendCheck()
        {
            bool sendSuccess = true;
            try
            {
                while (true)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        while (isLoggedOn)
                        {
                            Thread.Sleep(10000);
                            //로그인되어있고 메시지 받은지 1분이 지난 경우
                            int timeGap = Utils.TimeGap(Utils.TimeKey(), lastMessageReceivedTime);

                            if (timeGap < 60) continue;
                            
                            if (this.SendMsgPing())
                            {
                                //접속실패후 성공
                                if (!sendSuccess)
                                {
                                    //재접속 처리
                                    //NoParamDele reconnect = new NoParamDele(StartService);
                                    //Invoke(reconnect);
                                    sendSuccess = true;
                                    OnServerCheckSucceeded();
                                }
                            }
                            else
                                break;
                        }
                    }
                    sendSuccess = false;
                    OnServerCheckFailed();
                } //while
            }
            catch (Exception ex2)
            {
                Logger.error(ex2.ToString());
            }
        }

        /// <summary>
        /// MsgClientManager발생 로그처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnManagerStatusChanged(object sender, SocStatusEventArgs e)
        {
            Logger.info(e.Status.SocMessage);
        }

        private void ProcessOnTCPConnectionError(object sender, SocStatusEventArgs e)
        {
            Logger.info(e.Status.SocMessage);
            this.OnServerCheckFailed();
        }

        private void ProcessOnTCPStatusChanged(object sender, SocStatusEventArgs e)
        {
            string strStatus = "";
            switch (e.Status.Status)
            {
                case SocHandlerStatus.UNINIT:
                    strStatus = "UNINIT";
                    break;
                case SocHandlerStatus.CONNECTED:
                    strStatus = "CONNECTED";
                    break;
                case SocHandlerStatus.DISCONNECTED:
                    strStatus = "DISCONNECTED";
                    break;
                case SocHandlerStatus.ERROR:
                    strStatus = "ERROR";
                    break;
                case SocHandlerStatus.RECEIVING:
                    strStatus = "RECEIVING";
                    break;
                case SocHandlerStatus.SENDING:
                    strStatus = "SENDING";
                    break;
            }
            Logger.info(e.Status);
        }

        /// <summary>
        /// 메시지 수신 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnMessageReceived(object sender, SocStatusEventArgs e)
        {
            string msg = e.Status.Data.Substring(MsgDef.MSG_TEXT.Length+1); //"MSG|..."
            lastMessageReceivedTime = Utils.TimeKey();
            MsgFilter(msg, (IPEndPoint)e.Status.Soc.RemoteEndPoint);
        }


        /// <summary>
        /// 메시지 전송 메소드(채팅 및 서버 전송 메시지)
        /// </summary>
        /// <param name="msg">메시지</param>
        /// <param name="iep">메시지 발신자 IPEndPoint</param>
        /// 
        public bool SendMsg(string msg)
        {
            bool result = false;
            try
            {
                result = msgClient.SendMsg(msg);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            return result;
        }

        public void Dispose()
        {
            try
            {
                if (msgClient == null || !msgClient.IsConnected()) { MessageBox.Show("미접속상태"); return; }
                msgClient.Close();
                //정상적인 로그아웃인경우 쓰레드를 종료한다.
                //비정상 접속장애이면 접속재시도를 계속 실행
                if (!isLoggedOn) 
                    checkThread.Abort();
            }
            catch (ThreadAbortException ex)
            {
                Logger.error("ClearResourceOnClosing() 에러 : " + ex.ToString());
            }
            catch (SocketException ex)
            {
                Logger.error("ClearResourceOnClosing() 에러 : " + ex.ToString());
            }
        }
        
    }
}
