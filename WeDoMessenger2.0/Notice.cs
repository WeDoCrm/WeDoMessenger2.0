using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Client.PopUp;

namespace Client
{
    public partial class Notice : FlashWindowForm
    {
        public event EventHandler NoticeAlreadyRead;

        private MsgrConnection connection;
        private NoticeObj obj;

        public Notice(MsgrConnection connection, string[] msgToken)
        {
            InitializeComponent();
            this.connection = connection;
            obj = new NoticeObj(msgToken);
            SetNoticeInfo();
        }

        public Notice(MsgrConnection connection, NoticeObj obj)
        {
            InitializeComponent();
            this.connection = connection;
            this.obj = obj;
            SetNoticeInfo();
        }

        private void SetNoticeInfo()
        {
            RichTextBoxContent.Text = obj.Content;
            LabelNoticeSender.Text = Members.GetByUserId(obj.SenderId).Name;
            TextBoxTitle.Text = obj.Title;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (obj.NeedReply) //실시간 공지사항 수신시 확인결과 전송 처리
                connection.SendMsgNotifyNoticeRead(obj);

            Close();
        }

        private void CopyCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBoxContent.Copy();
        }

        private void SelectAllCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBoxContent.SelectAll();
        }

        private void RichTextBoxContent_KeyDown(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.ControlKey) {
                switch (e.KeyData) {
                    case Keys.C:
                        RichTextBoxContent.Copy();
                        break;
                    case Keys.A:
                        RichTextBoxContent.SelectAll();
                        break;
                }
            }
        }

        private void Notice_Activated(object sender, EventArgs e)
        {
            if (obj.NeedReply)
                DoFlashWindow();
        }
    }
}