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
    public partial class SetExtensionForm : Form
    {
        public SetExtensionForm()
        {
            InitializeComponent();
            tbx_extension.Text = ConfigHelper.Extension;
        }

        private void tbx_extension_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (tbx_extension.Text.Trim().Length > 0)
                    {
                        ConfigHelper.Extension = tbx_extension.Text.Trim();
                        this.DialogResult = DialogResult.OK; //폼을 닫음
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void btn_ext_confirm_Click(object sender, EventArgs e)
        {
            if (tbx_extension.Text.Trim().Length > 0)
            {
                ConfigHelper.Extension = tbx_extension.Text.Trim();
                Close();
            }
            else
            {
                tbx_extension.Focus();
                DialogResult = DialogResult.None;
            }

        }
    }
}
