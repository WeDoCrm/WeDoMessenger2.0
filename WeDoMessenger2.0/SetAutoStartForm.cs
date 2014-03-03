using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeDoCommon;

namespace Client
{
    public partial class SetAutoStartForm : Form
    {

        public SetAutoStartForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            cbx_autostart.Checked = ConfigHelper.AutoStart;
            cbx_topmost.Checked = ConfigHelper.TopMost;
            cbx_nopop.Checked = ConfigHelper.NoPop;
            cbx_nopop_outbound.Checked = ConfigHelper.NoPopOutBound;
        }

        private void pbx_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_autostart.CheckState == CheckState.Checked)
                {
                    ConfigHelper.AutoStart = true;
                }
                else
                {
                    ConfigHelper.AutoStart = false;
                }

                if (cbx_topmost.CheckState == CheckState.Checked)
                {
                    ConfigHelper.TopMost = true;
                }
                else
                {
                    ConfigHelper.TopMost = false;
                }

                if (cbx_nopop.CheckState == CheckState.Checked)
                {
                    ConfigHelper.NoPop = true;
                }
                else
                {
                    ConfigHelper.NoPop = false;
                }

                if (cbx_nopop_outbound.CheckState == CheckState.Checked)
                {
                    ConfigHelper.NoPopOutBound = true;
                }
                else
                {
                    ConfigHelper.NoPopOutBound = false;
                }

            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

    }
}
