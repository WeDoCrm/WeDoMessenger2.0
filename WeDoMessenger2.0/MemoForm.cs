using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Client.PopUp;
using WeDoCommon;

namespace Client
{
    public partial class MemoForm : FlashWindowForm
    {
        private MsgrConnection connection;
        private MemoObj obj;

        public MemoForm(MsgrConnection connection, MemoObj obj)
        {
            InitializeComponent();
            this.connection = connection;
            this.obj = obj;
            this.Text = Members.GetByUserId(obj.SenderId).Name + "님의 쪽지";
            this.richTextBoxMemo.Text = obj.Content;
        }

        private void MemoReplyDone(object sender, CustomEventArgs e)
        {
            try
            {
                MemoObj replyObj = (MemoObj)e.GetItem;
                if (Members.ContainLoginUserNode(replyObj.SenderId))
                {
                    connection.SendMsgDeliverMemo(replyObj);
                }
                else
                {
                    connection.SendMsgSaveMemoOnAway(replyObj);
                }
                //string msg = "19|" + this.myname + "|" + this.myid + "|" + memoContent.Trim();
                //string smsg = "4|" + this.myname + "|" + this.myid + "|" + memoContent.Trim();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        void MemoForm_Enter(object sender, EventArgs e)
        {
            base.StopFlash();
        }

        private void Memobtn_Click(object sender, EventArgs e)
        {
            if (richTextBoxReply.Text.Trim().Length == 0)
            {
                richTextBoxReply.Focus();
            }
            else
            {
                MemoObj replyMemoObj = new MemoObj();
                replyMemoObj.SenderId = ConfigHelper.Id;
                replyMemoObj.ReceiverId = obj.SenderId;
                replyMemoObj.Content = richTextBoxReply.Text;
                MemoReplyDone(this, new CustomEventArgs(replyMemoObj));

                Close();
            }
        }

        #region 텍스트처리 기능(복사, 자르기...)
        private void richTextBoxMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.ControlKey)
            {
                switch (e.KeyData) {
                    case Keys.C:
                        richTextBoxMemo.Copy();
                        break;
                    //case Keys.P:
                    //    richTextBoxMemo.Paste();
                    //    break;
                    //case Keys.x:
                    //    richTextBoxMemo.Cut();
                    //    break;
                    case Keys.A:
                        richTextBoxMemo.SelectAll();
                        break;
                }
            }
        }

        private void richTextBoxReply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.ControlKey)
            {
                switch (e.KeyData)
                {
                    case Keys.C:
                        richTextBoxReply.Copy();
                        break;
                    case Keys.P:
                        richTextBoxReply.Paste();
                        break;
                    case Keys.X:
                        richTextBoxReply.Cut();
                        break;
                    case Keys.A:
                        richTextBoxReply.SelectAll();
                        break;
                }
            }
        }


        private void CopyCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(richTextBoxMemo.Text);
            richTextBoxMemo.Copy();
        }

        private void CutCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBoxMemo.Cut();
        }

        private void PasteCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBoxMemo.Paste();
        }

        private void SelectAllCtrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBoxMemo.SelectAll();
        }

        private void CopyCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxReply.Copy();
        }

        private void CutCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxReply.Cut();
        }

        private void PasteCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxReply.Paste();
        }

        private void SelectAllCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxReply.SelectAll();
        }
        #endregion

        private void MemoForm_Activated(object sender, EventArgs e)
        {
            richTextBoxReply.Focus();
        }

        private void MemoForm_Load(object sender, EventArgs e)
        {
            MemoForms.AddForm(this);
        }
    }
}