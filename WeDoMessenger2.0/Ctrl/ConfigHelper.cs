using System;
using System.Collections.Generic;
using System.Text;
using WeDoCommon;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Client
{
    public class ConfigHelper
    {
        private static ConfigFileHandler configFileHandler = null;


        private ConfigHelper()
        {}

        public static void Initialize() {
            configFileHandler = new ConfigFileHandler(ConstDef.WEDO_MSGR_DIR, ConstDef.WEDO_CLIENT_EXE);

            serverIp = configFileHandler.GetValue("ServerIp");
            socketPortCrm = Convert.ToInt16(configFileHandler.GetValue("SocketPortCrm"));
            socketPortFtp = Convert.ToInt16(configFileHandler.GetValue("SocketPortFtp"));
            socketPortMsgr = Convert.ToInt16(configFileHandler.GetValue("SocketPortMsgr"));
            id = configFileHandler.GetValue("MyId");
            extension = configFileHandler.GetValue("PhoneExtension"); 
            pass = configFileHandler.GetValue("MyPass");
            customColor = configFileHandler.GetValue("CustomColor");
            customFont = configFileHandler.GetValue("CustomFont");
            savePass = (configFileHandler.GetValue("SaveMyPass").Equals(CommonDef.TRUE));
            noPopOutBound = (configFileHandler.GetValue("NoPopUpOnCallOutBound").Equals(CommonDef.TRUE));
            topMost = (configFileHandler.GetValue("TopMost").Equals(CommonDef.TRUE));
            noPop = (configFileHandler.GetValue("NoPopUpOnCall").Equals(CommonDef.TRUE));
            autoStart = (configFileHandler.GetValue("AutoStart").Equals(CommonDef.TRUE));
            dbServerIp = configFileHandler.GetValue("DbServerIp");
            dbPort = Convert.ToInt16(configFileHandler.GetValue("DbPort"));
            promotionUrl = configFileHandler.GetValue("PromotionUrl");
        }

        private static string serverIp;
        private static int socketPortCrm;
        private static int socketPortFtp;
        private static int socketPortMsgr;

        private static string id;
        private static string pass;
        private static string name;
        private static string tryId;
        private static string tryPass;
        private static string teamName;
        private static string extension;
        private static bool savePass;
        private static string customColor;
        private static string customFont;
        private static bool noPopOutBound;
        private static bool topMost;
        private static bool noPop;
        private static bool autoStart;
        private static string dbServerIp;
        private static int dbPort;
        private static string dbName = ConstDef.WEDO_DB;
        private static string dbUserId = ConstDef.WEDO_DB_USER;
        private static string dbPassword = ConstDef.WEDO_DB_PASSWORD;
        private static string companyCode;
        private static string companyName;
        private static string promotionUrl;

        public static string ServerIp
        {
            get { return serverIp; }
            set {
                serverIp = value;
                configFileHandler.SetValue("ServerIp", value);
            }
        }

        public static int SocketPortCrm
        {
            get { return socketPortCrm; }
            set {
                socketPortCrm = value;
                configFileHandler.SetValue("SocketPortCrm", Convert.ToString(value));
            }
        }

        public static int SocketPortFtp
        {
            get { return socketPortFtp; }
            set
            {
                socketPortFtp = value;
                configFileHandler.SetValue("SocketPortFtp", Convert.ToString(value));
            }
        }

        public static int SocketPortMsgr
        {
            get { return socketPortMsgr; }
            set
            {
                socketPortCrm = value;
                configFileHandler.SetValue("SocketPortMsgr", Convert.ToString(value));
            }
        }
        
        public static string Id
        {
            get { return id; }
            set {
                id = value;
                configFileHandler.SetValue("MyId", value);
            }
        }

        public static string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public static string Extension
        {
            get { return extension; }
            set {
                extension = value;
                configFileHandler.SetValue("PhoneExtension", value);
            }
        }

        public static string Pass
        {
            get { return pass; }
            set {
                pass = value;
                configFileHandler.SetValue("MyPass", value);
            }
        }

        public static string TryId
        {
            get { return tryId; }
            set { tryId = value; }
        }

        public static string TryPass
        {
            get { return tryPass; }
            set { tryPass = value; }
        }

        public static bool AutoStart
        {
            get { return autoStart; }
            set {
                autoStart = value;
                configFileHandler.SetValue("AutoStart", (value?CommonDef.TRUE:CommonDef.FALSE));

                if (value)
                {
                    RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(CommonDef.REG_CUR_USR_RUN, true);
                    rkApp.SetValue(CommonDef.REG_APP_NAME, Application.ExecutablePath.ToString());
                    rkApp.Close();
                }
                else
                {
                    RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(CommonDef.REG_CUR_USR_RUN, true);
                    if (rkApp.GetValue(CommonDef.REG_APP_NAME) != null)
                        rkApp.DeleteValue(CommonDef.REG_APP_NAME);
                    rkApp.Close();
                }

            }
        }

        public static bool TopMost
        {
            get { return topMost; }
            set {
                topMost = value;
                configFileHandler.SetValue("TopMost", (value ? CommonDef.TRUE : CommonDef.FALSE));
            }
        }

        public static bool NoPop
        {
            get { return noPop; }
            set {
                noPop = value;
                configFileHandler.SetValue("NoPopUpOnCall", (value ? CommonDef.TRUE : CommonDef.FALSE));
            }
        }

        public static bool NoPopOutBound
        {
            get { return noPopOutBound; }
            set {
                noPopOutBound = value;
                configFileHandler.SetValue("NoPopUpOnCallOutBound", (value ? CommonDef.TRUE : CommonDef.FALSE));
            }
        }

        public static bool SavePass
        {
            get { return savePass; }
            set {
                savePass = value;
                configFileHandler.SetValue("SaveMyPass", (value ? CommonDef.TRUE : CommonDef.FALSE));
            }
        }

        public static string CustomFont
        {
            get { return customFont; }
            set {
                customFont = value;
                configFileHandler.SetValue("CustomFont", value);
            }
        }

        public static string CustomColor
        {
            get { return customColor; }
            set {
                customColor = value;
                configFileHandler.SetValue("CustomColor", value);
            }
        }

        public static string DbServerIp
        {
            get { return dbServerIp; }
            set {
                dbServerIp = value;
                configFileHandler.SetValue("DbServerIp", value);
            }
        }

        public static int DbPort
        {
            get { return dbPort; }
            set {
                dbPort = value;
                configFileHandler.SetValue("DbPort", Convert.ToString(value));
            }
        }

        public static string DbName
        {
            get { return dbName; }
        }

        public static string DbUserId
        {
            get { return dbUserId; }
        }

        public static string DbPassword
        {
            get { return dbPassword; }
        }

        public static string CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }

        public static string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public static string PromotionUrl { get { return promotionUrl; } }

        public static void SaveFontColor(Color color, Font font)
        {
            try
            {
                string _color = color.Name;
                TypeConverter fontConverter = TypeDescriptor.GetConverter(typeof(Font));
                string _font = fontConverter.ConvertToString(font);
                ConfigHelper.CustomColor = _color;
                ConfigHelper.CustomFont = _font;
            }
            catch (Exception ex)
            {
                Logger.error("saveFontColor Error : " + ex.ToString());
            }
        }
    }
}
