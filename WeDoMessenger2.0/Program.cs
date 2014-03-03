using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client
{
    class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {

            Process[] pros = Process.GetProcessesByName("WDMsg_Client");
            if (pros.Length <= 1)
            {
                try
                {
                    Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF";
                    Application.Run(new Client_Form());
                }
                catch (Exception ex)
                {
                }
            }
            else if (pros.Length > 1)
            {

                MessageBox.Show("WeDo 메신저가 이미 실행중 입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
