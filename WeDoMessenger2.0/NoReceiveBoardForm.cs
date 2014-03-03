using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.Common;
using WeDoCommon;

namespace Client
{
    public partial class NoReceiveBoardForm : Form
    {
        Color labelColorInit;
        Color panelColorInit;

        Color labelColorSelected = Color.Black;
        Color panelColorSelected = Color.LightGray;

        MsgrConnection connection;

        int memoCnt;
        int noticeCnt;
        int fileCnt;
        int transCnt;

        public NoReceiveBoardForm(MsgrConnection connection)
        {
            InitializeComponent();
            labelColorInit = label_notice.ForeColor;
            this.connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="msg">T|sender†content†time†mode†seqnum†title|sender†content†time†mode†seqnum|...</param>
        public void SetNoticeValues(int count, string[] msg)
        {
            dgv_notice.Visible = true;
            panel_notice.Enabled = true;
            label_notice.Text = "부재중 공지 (" + count + ")";
            noticeCnt = count;

            foreach (string item in msg)
            {
                if (item.Equals("T")) continue;

                NumberedNoticeObj obj = new NumberedNoticeObj(item);

                bool isExist = false;
                foreach (DataGridViewRow itemObj in dgv_notice.Rows)
                {
                    if (((NumberedNoticeObj)itemObj.Tag != null) && ((NumberedNoticeObj)itemObj.Tag).SeqNum == obj.SeqNum)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    int rownum = dgv_notice.Rows.Add(new object[] {obj.Mode, 
                                                                   obj.Title, 
                                                                   obj.Content, 
                                                                   Members.GetByUserId(obj.SenderId).Name + "(" + obj.SenderId + ")", 
                                                                   obj.NoticeTime });
                    DataGridViewRow row = dgv_notice.Rows[rownum];
                    row.Tag = obj;
                    if (obj.IsEmergency)
                        row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="msg">Q|sender†content†time†seqnum|...|</param>
        public void SetMemoValues(int count, string[] msg)
        {
            panel_memo.Enabled = true;
            dgv_memo.Visible = true;
            label_memo.Text = "부재중 쪽지 (" + count + ")";
            this.memoCnt = count;

            foreach (string item in msg)
            {
                if (item.Equals("Q")) continue;

                NumberedMemoObj obj = new NumberedMemoObj(item);

                bool isExist = false;
                foreach (DataGridViewRow itemObj in dgv_memo.Rows)
                {
                    if (((NumberedMemoObj)itemObj.Tag != null) && ((NumberedMemoObj)itemObj.Tag).SeqNum == obj.SeqNum)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    int rownum = dgv_memo.Rows.Add(new object[] { Members.GetByUserId(obj.SenderId).Name + "(" + obj.SenderId + ")", obj.Time, obj.Content });
                    dgv_memo.Rows[rownum].Tag = obj;
                }
            }
        }

        /// <summary>
        /// trans|sender†content†time†seqnum|...
        /// </summary>
        /// <param name="count"></param>
        /// <param name="msg"></param>
        public void SetTransferValues(int count, string[] msg)
        {
            panel_trans.Enabled = true;
            dgv_transfer.Visible = true;
            label_trans.Text = "부재중 이관 (" + count + ")";
            this.transCnt = count;

            foreach (string item in msg)
            {
                if (item.Equals("trans")) continue;

                UncheckedTransferObj obj = new UncheckedTransferObj(item);

                bool isExist = false;
                foreach (DataGridViewRow itemObj in dgv_transfer.Rows)
                {
                    if ((UncheckedTransferObj)itemObj.Tag != null && ((UncheckedTransferObj)itemObj.Tag).SeqNum == obj.SeqNum)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    int rownum = 0;
                    if (obj.ContentObj == null)
                        rownum = dgv_transfer.Rows.Add(new object[] { obj.Time, obj.Content, Members.GetByUserId(obj.SenderId).Name + "(" + obj.SenderId + ")" });
                    else
                    {
                        string content = (obj.ContentObj.CustomerName == null || obj.ContentObj.CustomerName.Equals(""))
                                                                      ? obj.ContentObj.Ani : string.Format("{0}({1})", obj.ContentObj.CustomerName, obj.ContentObj.Ani);
                        rownum = dgv_transfer.Rows.Add(new object[] { obj.Time, 
                                                                       content, 
                                                                      Members.GetByUserId(obj.SenderId).Name + "(" + obj.SenderId + ")" });
                    }
                    dgv_transfer.Rows[rownum].Tag = obj;
                }
            }
        }

        #region 화면효과 관련처리 
        /// <summary>
        /// 공지버튼 마우스반응효과
        /// </summary>
        private void panel_notice_MouseEnter(object sender, EventArgs e)
        {
            panel_notice.BackColor = panelColorSelected;
            label_notice.ForeColor = labelColorSelected;
        }

        /// <summary>
        /// 공지버튼 마우스반응효과
        /// </summary>
        private void panel_notice_MouseLeave(object sender, EventArgs e)
        {
            panel_notice.BackColor = panelColorInit;
            label_notice.ForeColor = labelColorInit;
        }

        /// <summary>
        /// 쪽지버튼 마우스반응효과
        /// </summary>
        private void panel_memo_MouseEnter(object sender, EventArgs e)
        {
            panel_memo.BackColor = panelColorSelected;
            label_memo.ForeColor = labelColorSelected;
        }

        /// <summary>
        /// 쪽지버튼 마우스반응효과
        /// </summary>
        private void panel_memo_MouseLeave(object sender, EventArgs e)
        {
            panel_memo.BackColor = panelColorInit;
            label_memo.ForeColor = labelColorInit;
        }

        /// <summary>
        /// 이관업무 마우스반응효과
        /// </summary>
        private void panel_trans_MouseEnter(object sender, EventArgs e)
        {
            panel_trans.BackColor = panelColorSelected;
            label_trans.ForeColor = labelColorSelected;
        }

        /// <summary>
        /// 이관업무 마우스반응효과
        /// </summary>
        private void panel_trans_MouseLeave(object sender, EventArgs e)
        {
            panel_trans.BackColor = panelColorInit;
            label_trans.ForeColor = labelColorInit;
        }

        private void panel_notice_MouseClick(object sender, MouseEventArgs e)
        {
            dgv_memo.Visible = false;
            dgv_transfer.Visible = false;
            dgv_notice.Visible = true;
        }

        private void panel_memo_MouseClick(object sender, MouseEventArgs e)
        {
            dgv_memo.Visible = true;
            dgv_transfer.Visible = false;
            dgv_notice.Visible = false;
        }

        private void panel_trans_MouseClick(object sender, MouseEventArgs e)
        {
            dgv_memo.Visible = false;
            dgv_transfer.Visible = true;
            dgv_notice.Visible = false;
        }
#endregion

        private void dgv_memo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            delNRmemo(e.RowIndex);
        }

        private void delNRmemo(int rowIndex)
        {
            try
            {
                NumberedMemoObj obj = (NumberedMemoObj)dgv_memo.Rows[rowIndex].Tag;
                //쪽지 보여줌
                MemoForm memoForm = new MemoForm(connection, obj.ToMemoObj());
                memoForm.Show();
                memoForm.Activate();

                //확인한 쪽지를 미확인목록에서 삭제
                MemoUtils.MemoFileWrite(ConfigHelper.Id, obj.ToMemoObj());
                dgv_memo.Rows.RemoveAt(rowIndex);
                connection.SendMsgDeleteUnReadOnChecked(obj.SeqNum);

                memoCnt = memoCnt - 1;
                if (memoCnt >= 0)
                {
                    if (memoCnt == 0)
                        panel_memo.Enabled = false;
                    label_memo.Text = "부재중 메모(" + memoCnt + ")";
                    connection.UpdateUnCheckedData(memoCnt, -1, -1, -1);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        private void NoReceiveBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void dgv_notice_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            delNRnotice(e.RowIndex);
        }

        private void delNRnotice(int rowIndex)
        {
            try
            {
                NumberedNoticeObj obj = (NumberedNoticeObj)dgv_notice.Rows[rowIndex].Tag;//n|메시지|발신자id|mode|seqnum|title

                //실시간 공지사항 수신시 확인결과 전송 처리
                Notice nform = new Notice(connection, obj.ToNoticeObj());
                nform.Show();
                nform.Activate();

                connection.SendMsgDeleteUnReadOnChecked(obj.SeqNum);
                dgv_notice.Rows.RemoveAt(rowIndex);

                noticeCnt = noticeCnt - 1;
                if (noticeCnt >= 0)
                {
                    if (noticeCnt == 0)
                        panel_notice.Enabled = false;
                    label_notice.Text = "부재중 공지(" + noticeCnt + ")";
                    connection.UpdateUnCheckedData(-1, noticeCnt, -1, -1);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void dgv_transfer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            delNRTrans(e.RowIndex);
        }

        private void delNRTrans(int rowIndex)
        {
            try
            {
                UncheckedTransferObj uncheckedObj = (UncheckedTransferObj)dgv_transfer.Rows[rowIndex].Tag;
                if (uncheckedObj.ContentObj != null)
                {
                    string ani = uncheckedObj.ContentObj.Ani;

                    ShowTransferInfoHandler showTransferInfoHandler = new ShowTransferInfoHandler(CrmHelper.ShowTransferInfo);
                    Invoke(showTransferInfoHandler, uncheckedObj.ContentObj);

                    //connection.OnCallDialingReceived(new CustomEventArgs(new object[] { ani, "3" }));
                    connection.PopUpUncheckedTransfer(ani, "3");

                    dgv_transfer.Rows.RemoveAt(rowIndex);

                    //선택한 부재중 이관 row 관련 DB 삭제 요청
                    connection.SendMsgDeleteUnReadOnChecked(uncheckedObj.SeqNum);

                    transCnt = transCnt - 1;
                    if (transCnt >= 0)
                    {
                        if (transCnt == 0)
                            panel_trans.Enabled = false;
                        label_trans.Text = "부재중 이관(" + transCnt + ")";

                        connection.UpdateUnCheckedData(-1, -1, -1, transCnt);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
    }
}
