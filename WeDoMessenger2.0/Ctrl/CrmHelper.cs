using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;
using System.Windows.Forms;
using CRMmanager;

namespace Client
{
    internal class CrmHelper
    {
        private static CRMmanager.CRMmanager crmManager;
        private static CRMmanager.FRM_MAIN crmFrmMain;

        private CrmHelper() { }


        /// <summary>
        /// 1	인바운드
        /// 2	아웃바운드
        /// 3	내선통화
        /// 4	기타
        /// </summary>
        public enum CallType
        {
            IN_BOUND = 1,
            OUT_BOUND = 2,
            INTERNAL_TRANSFER = 3,
            ETC = 4
        }

        private static void InitializeCRMmanager()
        {
            if (crmManager == null)
            {
                crmManager = new CRMmanager.CRMmanager();
                crmManager.SetUserInfo(ConfigHelper.CompanyCode
                                        , ConfigHelper.Id
                                        , ConfigHelper.Pass
                                        , ConfigHelper.ServerIp
                                        , Convert.ToString(ConfigHelper.SocketPortCrm));
            }
        }

        private static void InitializeCrmMain()
        {
            if (crmFrmMain == null)
            {
                crmFrmMain = new FRM_MAIN();
                crmFrmMain.FormClosing += new FormClosingEventHandler(CrmHelper.CrmMainFormClosing);
            }
        }

        public static void StartCRMmanager()
        {
            try
            {
                InitializeCRMmanager();
                InitializeCrmMain();
                DisplayCrmPopUp();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        private static void CrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                crmFrmMain.Hide();
            }

        }

        public static void ShowTransferInfo(TransferObj obj)
        {
            Logger.info("showTransferInfo: " + obj.ToString());
            try
            {
                InitializeCRMmanager();
                InitializeCrmMain();
                crmFrmMain.OpenCustomerPopupTransfer(obj.Ani, obj.SenderId, obj.TongDate, obj.TongTime, Convert.ToString(CallType.INTERNAL_TRANSFER));
                DisplayCrmPopUp();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static void ShowCustomerPopup(string ani, string calltype)
        {
            try
            {
                InitializeCRMmanager();
                InitializeCrmMain();
                crmFrmMain.OpenCustomerPopup(ani, DateTime.Now.ToString("yyyyMMddHHmmss"), calltype);
                DisplayCrmPopUp();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public static void ShowCrmOnClick()
        {
            try
            {
                InitializeCRMmanager();
                InitializeCrmMain();
                DisplayCrmPopUp();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private static bool DisplayCrmPopUp()
        {
            if (crmFrmMain == null) return false;
            crmFrmMain.WindowState = FormWindowState.Normal;
            crmFrmMain.StartPosition = FormStartPosition.Manual;
            crmFrmMain.SetBounds(0, 0, crmFrmMain.Width, crmFrmMain.Height);
            crmFrmMain.Show();
            crmFrmMain.Activate();
            crmFrmMain.TopLevel = true;
            return true;
        }
    }
}
