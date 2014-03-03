using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.PopUp;
using WeDoCommon;

namespace Client
{
    public partial class SendNoticeForm : TopMostForm
    {
        public event EventHandler<CustomEventArgs> NoticeRegisterRequested;
        MsgrConnection connection;

        public SendNoticeForm(MsgrConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

            if (TextBoxTitle.Text.Length == 0)
            {
                MessageBox.Show("공지 제목을 적어 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBoxTitle.Focus();
                return;
            }
            if (richTextBoxContent.Text.Length != 0)
            {
                String NoticeTime = DateTime.Now.ToString();
                NoticeObj obj = new NoticeObj();
                obj.IsEmergency = ToggleButtonNormalNotice.Pressed;
                obj.Title = TextBoxTitle.Text;
                obj.Content = richTextBoxContent.Text;
                obj.NoticeTime = Utils.TimeKey();
                NoticeRegisterRequested(this, new CustomEventArgs(obj));
                Close();
            }
            else
            {
                MessageBox.Show("공지할 내용을 적어 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBoxContent.Focus();
            }
        }

        private void ToggleButtonNormalNotice_PressedChanged(object sender, EventArgs e)
        {
            string tag = "[긴급]";
            if (ToggleButtonNormalNotice.Pressed)
            {
                ToggleButtonNormalNotice.ScreenTip.Text = "긴급공지";
                if (TextBoxTitle.Text.Length >= 4 && TextBoxTitle.Text.Substring(0, 4) == tag)
                {
                    TextBoxTitle.Text = TextBoxTitle.Text;
                }
                else
                {
                    TextBoxTitle.Text = tag + TextBoxTitle.Text;
                }

            }
            else
            {
                ToggleButtonNormalNotice.ScreenTip.Text = "일반공지";
                if (TextBoxTitle.Text.Length >= 4 && TextBoxTitle.Text.Substring(0, 4) == tag)
                {
                    TextBoxTitle.Text = TextBoxTitle.Text.Substring(4);
                }
            }

        }

        private void CutCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            richTextBoxContent.Cut();
        }

        private void CopyCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            richTextBoxContent.Copy();
        }

        private void PasteCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            richTextBoxContent.Paste();
        }

        private void SelectAllCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            richTextBoxContent.SelectAll();
        }

        private void RichTextBoxContent_KeyDown(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.ControlKey) {
                switch (e.KeyData) {
                    case Keys.C:
                        richTextBoxContent.Copy();
                        break;
                    case Keys.P:
                        richTextBoxContent.Paste();
                        break;
                    case Keys.X:
                        richTextBoxContent.Cut();
                        break;
                    case Keys.A:
                        richTextBoxContent.SelectAll();
                        break;
                }
            }
        }
    }
}