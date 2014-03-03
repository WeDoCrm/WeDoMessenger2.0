using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using Client.Common;
using WeDoCommon;

namespace Client
{
    /// <summary>
    /// 공지/메모/이관/파일관련
    /// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {

        /// <summary>
        /// 로그인 시 부재중 건수 정보 보이기
        /// 메시지 형식
        /// </summary>
        /// <param name="arg"></param>
        private void PopUpOnUnCheckedDataReceived(object sender, CustomEventArgs e)
        {
            int[] arg = (int[])e.GetItem;

            if (arg[0] >= 0)
                NRmemo.Text = Convert.ToString(arg[0]);
            if (arg[1] >= 0)
                NRfile.Text = Convert.ToString(arg[1]);
            if (arg[2] >= 0)
            {
                NRnotice.Text = Convert.ToString(arg[2]);
                if (arg[2] > 0)
                    connection.SendMsgReqUnReadNotice();
            }
            if (arg[3] >= 0)
                NRtrans.Text = Convert.ToString(arg[3]);
        }

        private void CreateMemoFormOnMemoMsgReceived(object sender, CustomEventArgs e)
        {
            try
            {
                MemoObj memoObj = (MemoObj)e.GetItem;
                MemoForm memoForm = new MemoForm(connection, memoObj);
                memoForm.Show();
                memoForm.Activate();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void OpenSendMemoBySelectedNode()
        {
            List<MemberObj> receiverList = new List<MemberObj>();
            try
            {
                if (memTree.SelectedNode == null)
                    MakeSendMemo(receiverList);
                else
                {
                    if (memTree.SelectedNode.GetNodeCount(true) != 0)
                    {
                        foreach (TreeNode node in memTree.SelectedNode.Nodes)
                            receiverList.Add((MemberObj)node.Tag);
                        MakeSendMemo(receiverList);
                    }
                    else
                        MakeSendMemo((MemberObj)memTree.SelectedNode.Tag);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }

        }

        private void MakeSendMemo(List<MemberObj> receiverList)
        { //MemoReceiver(key=id, value=name)
            try
            {
                SendMemoForm form;
                if (receiverList == null || receiverList.Count == 0)
                    form = new SendMemoForm(connection);
                else
                    form = new SendMemoForm(connection, receiverList);
                form.Show();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private void MakeSendMemo(MemberObj receiver)
        {
            try
            {
                SendMemoForm form;
                if (receiver == null)
                    form = new SendMemoForm(connection);
                else
                    form = new SendMemoForm(connection, receiver);
                form.Show();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private void MakeSendNotice()
        {
            SendNoticeForm form = new SendNoticeForm(connection);
            form.NoticeRegisterRequested += RegisterNotice;
            form.Show();
        }

        public void RegisterNotice(object sender, CustomEventArgs e)//bool isEmergency, string title, string content)
        {
            try
            {
                NoticeObj obj = (NoticeObj)(e.GetItem);

                if (noticeresultform == null || noticeresultform.IsDisposed)
                {
                    noticeresultform = new NoticeResultForm();
                }
                noticeresultform.AddItem(obj);
                connection.SendMsgRegisterNotice(obj);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        public void DisplayOnNoticeResultFromDBReceived(object sender, CustomEventArgs e)//t|ntime†content†nmode†title†안읽은사람1:안읽은사람2:...|...
        {
            Logger.info("DisplayOnNoticeResultFromDBReceived 실행");
            try
            {
                string[] tempMsg = (string[])e.GetItem;
                if (noticeresultform == null || noticeresultform.IsDisposed)
                    noticeresultform = new NoticeResultForm();

                foreach (string strarr in tempMsg) //ntime†content†nmode†title†안읽은사람1:안읽은사람2:...
                {
                    if (strarr.Equals("t")) continue;
                    Logger.info(strarr);
                    UserListedNoticeObj noticeInfo = new UserListedNoticeObj(strarr);
                    noticeresultform.AddItem(noticeInfo);

                    //발송 공지 항목 각각의 상세 확인 리스트폼 생성
                    if (noticeInfo.UnReaders != null && noticeInfo.UnReaders.Count > 0)
                        NoticeDetailForms.AddForm(noticeInfo.NoticeTime, noticeInfo.UnReaders);
                }
                noticeresultform.Show();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// 메시지형식:C|id|noticeid
        /// </summary>
        private void AddNoticeCheckUserOnNotified(object sender, CustomEventArgs e)
        {
            try
            {
                string[] msg = (string[])e.GetItem;
                if (msg.Length == 3)
                    NoticeDetailForms.UpdateNoticeRead(msg[2], msg[1]);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// 공지함 리스트 생성
        /// </summary>
        /// <param name="msg"></param>
        private void DisplayFormOnNoticeListReceived(object sender, CustomEventArgs e)
        {//L|time‡content‡mode‡sender‡seqnum‡title|...

            try
            {
                string[] msg = (string[])e.GetItem;
                if (msg.Length >= 2)
                {
                    if (noticelistform != null || noticelistform.IsDisposed)
                        noticelistform = new NoticeListForm(connection);
                    noticelistform.AssignListInfo(msg);
                    noticelistform.Show();
                }
                else
                    MessageBox.Show("등록된 공지가 없습니다.", "공지없음", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Logger.error("MakeNoticeListForm() " + ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// 쪽지함 리스트 폼 생성
        /// </summary>
        private void MakeMemoList()
        {
            try
            {
                List<MemoObj> list = MemoUtils.MemoFileRead(ConfigHelper.Id);
                if (list == null || list.Count == 0)
                    MessageBox.Show("저장된 쪽지가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (mMemoListForm != null && !mMemoListForm.IsDisposed)
                        mMemoListForm.Close();
                    mMemoListForm = new MemoListForm(connection, list);
                    mMemoListForm.Show();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void MakeNoticeResultList()
        {
            try
            {
                if (noticeresultform != null && !noticeresultform.IsDisposed)
                    noticeresultform.Show();
                connection.SendMsgReqNoticeList();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }
        
        /// <summary>
        /// 실시간 공지사항 수신
        /// </summary>
        private void PopUpNoticeOnInstantNoticeReceived(object sender, CustomEventArgs e) //n|메시지 | 발신자id | mode | noticetime |제목
        {
            try
            {
                NoticeObj obj = (NoticeObj)e.GetItem;
                Notice nform = new Notice(connection, obj);
                nform.Show();
                nform.Activate();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// MemoListForm 생성
        /// </summary>
        /// <param name="tempMsg"></param>
        private void PopUpListOnUnCheckedMemoReceived(object sender, CustomEventArgs e)  //(Q|sender†content†time†seqnum|...|
        {
            try
            {
                string[] tempMsg = (string[])e.GetItem;
                if (noreceiveboardform == null || noreceiveboardform.IsDisposed)
                    noreceiveboardform = new NoReceiveBoardForm(connection);

                noreceiveboardform.SetMemoValues(Convert.ToInt32(NRmemo.Text), tempMsg);
                noreceiveboardform.WindowState = FormWindowState.Normal;
                noreceiveboardform.Show();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void notreadmemoform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;
            e.Cancel = true;
            form.Hide();
        }

        /// <summary>
        /// 읽지 않은 공지사항을 보여줌
        /// </summary>
        /// <param name="tempMsg"></param>
        private void PopUpListOnUnCheckedNoticeReceived(object sender, CustomEventArgs e)  //(T|sender†content†time†mode†seqnum†title|sender†content†time†mode†seqnum|...
        {
            try
            {
                string[] tempMsg = (string[])e.GetItem;
                if (noreceiveboardform == null || noreceiveboardform.IsDisposed)
                    noreceiveboardform = new NoReceiveBoardForm(connection);
                noreceiveboardform.SetNoticeValues(Convert.ToInt16(this.NRnotice.Text), tempMsg);
                noreceiveboardform.WindowState = FormWindowState.Normal;
                noreceiveboardform.Show();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void PopUpListOnUnCheckedTransferReceived(object sender, CustomEventArgs e)
        {
            try
            {
                string[] tempMsg = (string[])e.GetItem;
                if (noreceiveboardform == null || noreceiveboardform.IsDisposed)
                    noreceiveboardform = new NoReceiveBoardForm(connection);
                noreceiveboardform.SetTransferValues(Convert.ToInt16(this.NRtrans.Text), tempMsg);
                noreceiveboardform.WindowState = FormWindowState.Normal;
                noreceiveboardform.Show();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

    }
}
