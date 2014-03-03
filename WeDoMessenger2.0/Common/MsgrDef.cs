namespace Client
{
    public class CommonDef
    {

        public const string REG_APP_NAME = "WeDo";
        
        public const string MSG_DEL = "|";
        public const string MSG_LOGIN = "8|";
        public const string MSG_CHAT = "16|";

        public const string PATH_DELIM = "\\";

        public const string REG_CUR_USR_RUN = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        
        public const string MSGR_TITLE_PROD = "WeDo 메신저";

        public const string APP_VERSION= "2.2.1";

        public const string CHAT_USER_LOG_IN = ":login";
        public const string CHAT_USER_LOG_OUT = ":logout";

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";

    }

    public class MsgrMsg
    {
        public const string UNDEFINED_TEAM = "미지정"; //admin이나 부서가 지정되지 않은 경우
    }

    public enum DownloadStatus
    {
        SUCCESS,
        FAILED,
        CANCELED,
        START,
        RECEIVING,
        END,
        SENDING
    }

    /// <summary>
    /// 8881(listener on server) <--> 8882(client)
    /// 8883(listener on client) <--> 8884(client on client)
    /// 8886 (client on client) <--> 8885(listener on server)
    /// </summary>
    //class PortInfoServer
    //{
    //    public static int LISTEN_PORT = 8881;//listenport 수신전용
    //    public static int SEND_PORT = 8882;//발신전용 수신측은 8883(클라이언트)으로 받음
    //    public static int CHECK_PORT = 8885;//서버체크전용 <== 클라이언트 8886
    //    public static int CRM_PORT = 8886; //CRM 서버 체크 전용 TCP 수신 이관시 crm->서버
    //    public static int FILE_RCV_PORT = 9001; //파일수신 전용 <==클라이언트 9004
    //    public static int LICENSE_PORT = 5999; //
    //}

    //class PortInfoMsgr
    //{
    //    public static int LISTEN_PORT = 8883; //수신전용 <== 8884(클라이언트)
    //    //         <== 8882(위두서버)
    //    public static int SEND_PORT = 8884; //발신전용 수신측은 8883으로 받음 
    //    public static int FILE_RCV_PORT = 9003; //파일수신 <== 9004(클라이언트)
    //    //         <== 0   (위두서버/랜덤포트)
    //    public static int FILE_SEND_PORT = 9004; //파일발신
    //    public static int CHEKC_PORT = 8886; //==> 8885(위두서버)

    //    public static int FILE_RCV_TCP_PORT = 9002; //파일수신 TCP
    //}
}