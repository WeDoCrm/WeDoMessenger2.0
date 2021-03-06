﻿using System;
namespace WeDoCommon
{
    /// <summary>
    /// /define:XXX
    /// XXX=WEDO_SERVER
    /// XXX=WEDO_MSGR
    /// XXX=CONFIG_UTIL
    /// XXX=DB_IMPORT
    /// XXX=SERVER_INSTAL
    /// XXX=MSGR_INSTALL
    /// XXX=CALL_SIP
    /// XXX=CALL_CID
    /// XXX=CALL_KPN
    /// </summary>
    public sealed class ConstDef
    {
#if (WEDO_SERVER)
        #region wedo_server - 프로그램별 정의
        public const string REG_APP_NAME = "WeDo Server";
        public const string VERSION = "2.0.13";
        #endregion
#endif

        #region logfile
        public const int LOG_BACKUP_PERIOD = -14;
#if (WEDO_SERVER)
        public const string APP_DATA_CONFIG_FILE = APP_DATA_CONFIG_DIR + WEDO_SERVER_CONFIG;

        public const string LOG_FILE_PREFIX = "wd_server_"; //wedo_server
        public const string LOG_DIR = WEDO_SERVER_DIR + "log\\";

        public const string LOG_FILE_PREFIX_CALLSIP = "callsip_";        //callcontrol sip
        public const string LOG_FILE_CALLSIP = LOG_FILE_PREFIX_CALLSIP +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE_CALLSIP = LOG_FILE_PREFIX_CALLSIP + "log_{0}" + ".zip";

        public const string LOG_FILE_PREFIX_CALLCID = "callcid_";        //callcontrol cid
        public const string LOG_FILE_CALLCID = LOG_FILE_PREFIX_CALLCID +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE_CALLCID = LOG_FILE_PREFIX_CALLCID + "log_{0}" + ".zip";

        public const string LOG_FILE_PREFIX_CALLKPN = "callkpn_";        //callcontrol kpn
        public const string LOG_FILE_CALLKPN = LOG_FILE_PREFIX_CALLKPN +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE_CALLKPN = LOG_FILE_PREFIX_CALLKPN + "log_{0}" + ".zip";
#endif
#if (WEDO_MSGR)
        public const string APP_DATA_CONFIG_FILE = APP_DATA_CONFIG_DIR + WEDO_CLIENT_CONFIG;
        public const string LOG_FILE_PREFIX = "wd_msgr_";   //wedo msgr
        public const string LOG_DIR = WEDO_MSGR_DIR + "log\\";
#endif
#if (CONFIG_UTIL)
        public const string LOG_FILE_PREFIX = "configutil_";//config util
        public const string LOG_DIR = WEDO_CONFIG_DIR + "log\\";
#endif
#if (DB_IMPORT)
        public const string LOG_FILE_PREFIX = "dbimport_";  //db manager
        public const string LOG_DIR = WEDO_DBUTIL_DIR + "log\\";
#endif
#if (SERVER_INSTAL)
        public const string LOG_FILE_PREFIX = "wd_server_inst_"; //wedo server installer
        public const string LOG_DIR = WEDO_SERVER_DIR + "log\\";
#endif
#if (MSGR_INSTALL)
        public const string LOG_FILE_PREFIX = "wd_msgr_inst_";   //wedo messenger installer
        public const string LOG_DIR = WEDO_MSGR_DIR + "log\\";
#endif
        public const string LOG_FILE_EXT = ".log";
        public const string LOG_FILE = LOG_FILE_PREFIX +"{0}"+LOG_FILE_EXT;
        public const string LOG_BACKUP_FILE = LOG_FILE_PREFIX + "log_{0}" + ".zip";
        public const string LOG_BACKUP_DIR = APP_DATA_DIR + "logBackup\\";
        public const string LOG_FILE_FMT = "yyyyMMdd";
        public const string LOG_DATE_TIME_FMT = "yyyy-MM-dd HH:mm:sss";

        public const string TIME_KEY_FMT = "yyyyMMddHHmmss";

        #endregion

        #region callcontrol
        public const string RBT_TYPE_SIP = "rbt_type_sip";
        public const string NIC_SIP = "SIP";
        public const string NIC_LG_KP = "LG";
        public const string NIC_CID_PORT1 = "CI1";
        public const string NIC_CID_PORT2 = "CI2";
        public const string NIC_CID_PORT4 = "CI4";
        public const string NIC_SS_KP = "SS";
        #endregion

        #region directory info
        public const string WEDO_MAIN_DIR = "eclues";

        public const string WORK_DIR = "\\" + WEDO_MAIN_DIR + "\\";
        public const string APP_DATA_DIR = WORK_DIR + "AppData\\";
        public const string APP_DATA_CONFIG_DIR = APP_DATA_DIR + "config\\";
        public const string MSGR_DATA_DIR = APP_DATA_DIR + "msgr\\";
        public const string MSGR_DATA_FILE_DIR = MSGR_DATA_DIR + "{0}\\Files\\";
        public const string MSGR_DATA_MEMO_DIR = MSGR_DATA_DIR + "{0}\\Memo\\";
        public const string MSGR_DATA_DLOG_DIR = MSGR_DATA_DIR + "{0}\\Dialog\\";
        public const string DB_BACKUP_DIR = APP_DATA_DIR + "dbBackup\\";
        public const string WEDO_SERVER_DIR = WORK_DIR + "WeDo Server\\";         //WDMsgServer
        public const string WEDO_MSGR_DIR = WORK_DIR + "WeDo\\";         //WDMsgr

        public const string WEDO_CONFIG_DIR = WORK_DIR + "WeDo Config\\";         //WeDo Config
        public const string WEDO_DBUTIL_DIR = WORK_DIR + "WeDo Config\\";         //WeDo DB Manager

        public const string mainTitle = "WeDo Server 설치";
        public const string WINPCAP = "\\WinPcap_4_1_3.exe";
        public const string WINPCAP_INSTALLNAME = "WinPcap 4.1.3";
        public const string WINPCAP_RES_FILE = APP_NAMESPACE + ".winpcap.WinPcap_4_1_3.exe";

        public const string WEDO_SERVER_NAME = "WeDo Server";
        public const string WEDO_CLIENT_NAME = "WeDo Messenger";
        public const string WEDO_MYSQL_NAME = "WeDo MySql Server";

        public const string WEDO_SERVER_EXE = "WD_Server.exe";         //WDMsgServer
        public const string WEDO_SERVER_CONFIG = "WD_Server.exe.config";         //WDMsgServer
        public const string WEDO_SERVER_CMD = WEDO_SERVER_DIR + WEDO_SERVER_EXE;         //WDMsgServer
        public const string WEDO_CLIENT_EXE = "WDMsg_Client.exe";             //WDMsgClient
        public const string WEDO_CLIENT_CONFIG = "WDMsg_Client.exe.config";             //WDMsgClient

        public const string WEDO_CRM_PORT_FIREWALL_NAME = "WeDo Crm Port";
        public const string WEDO_MSGR_PORT_FIREWALL_NAME = "WeDo Msgr Port";
        public const string WEDO_FTP_PORT_FIREWALL_NAME = "WeDo FTP Port";
        public const string WEDO_DB_PORT_FIREWALL_NAME = "WeDo Db Port";

        #endregion

        #region db_install
        public const string MYSQL_SERVICE_NAME = "WedoSqlTest";
        public const string MYINI_BASE_DIR = "C:/" + WEDO_MAIN_DIR + "/db/mysql-5.5.19-win32/";//WeDoMySQL
        public const string MYINI_DATA_DIR = MYINI_BASE_DIR + "Data/";//WeDoMySQL
        public const string MYSQL_DIR = WORK_DIR + "db\\mysql-5.5.19-win32\\";//WeDoMySQL
        public const string MYSQL_INI = MYSQL_DIR + "my.ini";//WeDoMySQL
        public const string MYSQL_SERVICE_CMD = MYSQL_DIR + "bin\\mysqld.exe";//WeDoMySQL
        public const string MYSQL_INSTALL_OPT = "--install " + MYSQL_SERVICE_NAME
            + " --defaults-file=" + MYSQL_INI;
        public const string MYSQL_UNINSTALL_OPT = "--remove " + MYSQL_SERVICE_NAME;
        //\MiniCTI\mysql-5.5.19-win32\bin\mysqld --defaults-file=\MiniCTI\mysql-5.5.19-win32\my.ini WedoSql

        //db install
        public const string APP_NAMESPACE = "CustomAction";
        public const string MYSQL_ZIP_FILE = APP_NAMESPACE + ".mysql.mysql-5.5.19-win32.zip";
        public const string MYSQL_CREATE_USER_FILE = APP_NAMESPACE + ".mysql.create_user.sql";
        public const string MYSQL_CREATE_DB_FILE = APP_NAMESPACE + ".mysql.create_database.sql";
        public const string MYSQL_CREATE_TABLE_FILE = APP_NAMESPACE + ".mysql.create_table.sql";
        public const string MYSQL_INSERT_DATA_FILE = APP_NAMESPACE + ".mysql.insert_data.sql";

        
        //db backup
        public const string MYSQL_BACKUP_CMD = MYSQL_DIR + "bin\\mysqldump.exe";
        public const string WEDO_DB_BACKUP_OPT = " --default-character-set=euckr --user root --password=Genesys!@# wedo_db ";
        public const string WEDO_DB_BACKUP_FILE = DB_BACKUP_DIR + "\\wedo_db_{0}.dmp";
        #endregion

        #region db_info
        public const string DEFAULT_DB = "mysql";
        public const string WEDO_DB = "wedo_db";
        public const string WEDO_DB_URL = "127.0.0.1";
        public const string WEDO_DB_USER = "root";
        public const string WEDO_DB_PASSWORD = "Genesys!@#";
        public const int MYSQL_PORT = 3306;
        #endregion

#if (SERVER_INSTAL)
        public const string CONFIG_MSGR_PORT_NAME = "MSGR_PORT"; //wedo server installer
        public const string CONFIG_CRM_PORT_NAME = "CRM_PORT";
        public const string CONFIG_DB_PORT_NAME = "DB_PORT";
#endif
#if (MSGR_INSTALL)
        public const string CONFIG_MSGR_PORT_NAME = "SocketPortMsgr"; //wedo server installer
        public const string CONFIG_CRM_PORT_NAME = "SocketPortCrm";
        public const string CONFIG_FTP_PORT_NAME = "SocketPortFtp";
        public const string CONFIG_DB_PORT_NAME = "DbPort";
#endif

        public const string LICENSE_FILE = "*license.ini";

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string YES = "yes";
        public const string NO = "no";
        public const string PIPE = "&PIP"; //==> "|"
        public const string UNDERSCORE = "&UNS"; //==> "_"
    }

}