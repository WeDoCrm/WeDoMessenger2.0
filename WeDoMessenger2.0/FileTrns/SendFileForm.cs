using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Client.Common;
using WeDoCommon;
using System.IO;
using WeDoCommon.Sockets;

namespace Client
{
    /// <summary>
    /// 파일&수신자 선택은 채팅창이나 메신저창에서 선택하고,
    /// 이 창에서는 수신자변경은 안됨. 파일변경은 가능.
    /// </summary>
    public partial class SendFileForm : Form
    {
        private Hashtable htReceiverTable = new Hashtable();
        private string formKey;
        public string FormKey { get { return formKey; } }
        private MsgrConnection connection;
        private MemberObj receiverObj;
        private FTPSendObj sendObj;
        //private List<MemberObj> receiverList;
        private FileInfo sendFile;
        private Timer sendFileTimer = new Timer();

        /// <summary>
        /// 메신저: 트리에서 대상자선택
        ///   0명: 에러
        ///   1명: 띄움
        ///   2+명: 파일선택 먼저 하고 띄움
        /// 채팅창: 상대방선택
        ///   0명: 에러
        ///   1명: 띄움
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="receiver"></param>
        public SendFileForm(MsgrConnection connection, MemberObj receiver)
        {
            InitializeComponent();
            this.connection = connection;
            this.formKey = DateTime.Now.ToLongTimeString();
            this.receiverObj = receiver;
            Initialize();
        }

        //파일이 선택된경우 바로 실행
        public SendFileForm(MsgrConnection connection, MemberObj receiver, string fileName) 
            : this(connection, receiver)
        {
            if (fileName != null && !fileName.Equals(""))
            {
                sendFile = new FileInfo(fileName);
                SelectFile();
                _StartFileSending();
                ButtonFileSelect.Enabled = false;
            }
        }

        //파일이 선택된경우 바로 실행
        public SendFileForm(MsgrConnection connection, MemberObj receiver, string fileName, bool autoStart)
            : this(connection, receiver, fileName)
        {
            if (fileName != null && !fileName.Equals("") && autoStart)
            {
                _StartFileSending();
                ButtonFileSelect.Enabled = false;
            }
        }

        private void Initialize()
        {
            ToolTip tip = new ToolTip();
            tip.IsBalloon = true;
            tip.ToolTipIcon = ToolTipIcon.Info;
            tip.ToolTipTitle = "받는사람";
            tip.SetToolTip(txtbox_FileReceiver, txtbox_FileReceiver.Text);
            ButtonFTPStart.Enabled = false;

            txtbox_FileReceiver.Text += receiverObj.Name + "(" + receiverObj.Id + ");";

            connection.FTPSendingProgressed += DisplayOnFTPSendingProgressed;
            connection.FTPSendingFinished += DisplayOnFTPSendingFinished;
            connection.FTPSendingCanceled += DisplayOnFTPSendingCanceled;
            connection.FTPSendingFailed += DisplayOnFTPSendingFailed;
            connection.FTPSendingAccepted += ProcessOnFTPSendingAccepted;
            connection.FTPSendingRejected += ProcessOnFTPSendingRejected;

            sendFileTimer.Tick += new EventHandler(CheckSendFileTimeOutOnTick);
            sendFileTimer.Interval = 30000; //30초 경과후 타임아웃처리
            SendFileForms.AddForm(formKey, this);
        }

        private void SendFileForm_Activated(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void SendFileForm_Deactivate(object sender, EventArgs e)
        {
            TopMost = false;
        }

        /// <summary>
        /// 30초 시간경과후 아무런 리턴메시지를 못받았을때 실패처리함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckSendFileTimeOutOnTick(object sender, EventArgs e)
        {
            sendFileTimer.Stop();
            if (MessageBox.Show(this, string.Format("{0}님에게 파일보내기가 시간초과로 실패하였습니다.(30초초과)", Members.GetByUserId(sendObj.ReceiverId).Name)
                    + Environment.NewLine
                    + string.Format("전송 파일명:{0}", sendObj.FileName), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    connection.CancelFTPSending(sendObj);
                }
                catch (Exception exception)
                {
                    Logger.error(exception.ToString());
                }
                Close();
            }

        }

        #region 파일수신자 외부설정 메소드
        /// <summary>
        /// 파일수신자를 추가
        /// </summary>
        //public void AddFileReceiver(string user)
        //{
        //    if (user != null && user != "")
        //    {
        //        MemberObj userObj = new MemberObj(Members.GetByUserId(user));
        //        receiverList.Add(userObj);
        //        txtbox_FileReceiver.Text += string.Format("{0}({1});", userObj.Name, userObj.Id);
        //    }
        //    else
        //    {
        //        Logger.error("AddFileReceiver:invalid user");
        //    }
        //}

        ///// <summary>
        ///// 파일수신자를 추가
        ///// </summary>
        //public void AddFileReceiver(MemberObj userObj)
        //{
        //    if (userObj != null && userObj.Id != "")
        //    {
        //        receiverList.Add(userObj);
        //        txtbox_FileReceiver.Text += string.Format("{0}({1});", userObj.Name, userObj.Id);
        //    }
        //    else
        //    {
        //        Logger.error("AddFileReceiver:invalid userObj");
        //    }
        //}

        /// <summary>
        /// 파일수신자목록을 설정
        /// </summary>
        //public void SetFileReceivers(List<string> receivers)
        //{
        //    if (receivers != null && receivers.Count > 0)
        //    {
        //        receiverList.Clear();
        //        txtbox_FileReceiver.Clear();
        //        foreach (string receiver in receivers)
        //        {
        //            MemberObj userObj = new MemberObj(Members.GetByUserId(receiver));
        //            receiverList.Add(userObj);
        //            txtbox_FileReceiver.Text += string.Format("{0}({1});", userObj.Name, userObj.Id);
        //        }
        //    }
        //    else
        //    {
        //        Logger.error("AddFileReceiver:invalid receivers");
        //    }
        //}

        /// <summary>
        /// 파일수신자목록을 설정
        /// </summary>
        //public void SetFileReceivers(List<MemberObj> receivers)
        //{
        //    if (receivers != null && receivers.Count > 0)
        //    {
        //        receiverList.Clear();
        //        txtbox_FileReceiver.Clear();
        //        foreach (MemberObj userObj in receivers)
        //        {
        //            receiverList.Add(userObj);
        //            txtbox_FileReceiver.Text += string.Format("{0}({1});", userObj.Name, userObj.Id);
        //        }
        //    }
        //    else
        //    {
        //        Logger.error("AddFileReceiver:invalid receivers");
        //    }
        //}

        #endregion

        public void setProgress(int index)
        {
            if (index < 0)
                progressBarSendFile.Visible = false;
            else
            {
                if (!progressBarSendFile.Visible)
                    progressBarSendFile.Visible = true;
                
                if (index >= 0)
                    progressBarSendFile.Value = index;
                if (index == 100)
                    progressBarSendFile.Visible = false;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            _StartFileSending();
            ButtonFileSelect.Enabled = false;
        }



        private void _StartFileSending()
        {
            try
            {
                Logger.info("파일전송시작");
                ButtonFTPStart.Visible = false;
                ButtonCancel.Left += 40;
                label_result.Text = "전송 대기중";
                //전송 상태 자세히 보기 생성
                connection.SendMsgNotifyFileInfo(sendObj.FileName, sendObj.FileSize, this.formKey, sendObj.ReceiverId);
                SendFileForms.AddClientKey(sendObj.FileName, sendObj.FileSize, sendObj.ReceiverId, this.formKey);
                sendFileTimer.Start();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// FTP 전송자: 파일전송 승락이벤트받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingAccepted(object sender, SocFTPInfoEventArgs<FTPSendObj> e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.GetObj.Key))
                {
                    Logger.info(string.Format("ProcessOnFTPSendingAccepted : 파일수신승락 파일[{0}]수신자[{1}]", e.GetObj.FileName, e.GetObj.ReceiverId));
                    setProgress(0);
                    label_result.Text = "전송 시작";
                    ButtonCancel.Click += CancelOnButtonCancelClicked;
                    sendFileTimer.Stop();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// FTP 전송자: 파일전송 거부이벤트받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOnFTPSendingRejected(object sender, SocFTPInfoEventArgs<FTPSendObj> e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.GetObj.Key))
                {
                    Logger.info(string.Format("ProcessOnFTPSendingRejected : 파일수신거부 파일[{0}]수신자[{1}]", e.GetObj.FileName, e.GetObj.ReceiverId));
                    MessageBox.Show(this, string.Format("{0}님이 파일받기를 거부하셨습니다.", Members.GetByUserId(e.GetObj.ReceiverId).Name)
                                        + Environment.NewLine
                                        + string.Format("전송 파일명:{0}", e.GetObj.FileName), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_result.Text = "파일수신거부";
                    sendFileTimer.Stop();
                    Close();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 파일전송 진행보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayOnFTPSendingProgressed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.Status.Key))
                {
                    setProgress(e.ProgressIndex);
                    label_result.Text = e.Msg;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 파일전송 완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayOnFTPSendingFinished(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.Status.Key))
                {
                    label_result.Text = "파일 전송이 완료되었습니다.";
                    ButtonCancel.Text = "닫  기";
                    ButtonCancel.Click -= CancelOnButtonCancelClicked;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 파일전송취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayOnFTPSendingCanceled(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.Status.Key))
                {
                    label_result.Text = e.PrintMsg;
                    setProgress(-1);
                    ButtonCancel.Text = "닫  기";
                    ButtonCancel.Click -= CancelOnButtonCancelClicked;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 파일전송실패
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayOnFTPSendingFailed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (SendFileForms.ContainClientKey(this, e.Status.Key))
                {
                    label_result.Text = "파일 전송이 실패되었습니다.";
                    setProgress(-1);
                    ButtonCancel.Text = "닫  기";
                    ButtonCancel.Click -= CancelOnButtonCancelClicked;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void CancelOnButtonCancelClicked(object sender, EventArgs e)
        {
            try
            {
                connection.CancelFTPSending(sendObj);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 전송후 보여서 클릭. 
        /// 창 생성불필요함 이미 상세창은 만들어진 상태.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void label_detail_Click(object sender, EventArgs e)
        //{
        //    FileSendDetailListView view = FileSendDetailListViews.GetForm(formKey);
        //    view.Show();
        //}

        private void ButtonFileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = null;
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    sendFile = new FileInfo(fileName);
                    SelectFile();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void SelectFile()
        {
            try
            {
                if (sendFile != null)
                {
                    label_filename.Text = Utils.ShortenDirString(sendFile.FullName);
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(label_filename, sendFile.FullName);
                    
                    label_filesize.Text = String.Format(new FileSizeFormatProvider(), "{0:fs} ({0:#,##0} 바이트)", sendFile.Length);
                    //예) 2.05MB(2,145,243 바이트)
                    //    2.00GB(2,145,243,245 바이트)
                    string clientKey = SocUtils.GenerateFTPClientKey(ConfigHelper.Id, 
                                                                    WeDoCommon.Sockets.SocUtils.GetFileName(sendFile.FullName),
                                                                    sendFile.Length, 
                                                                    receiverObj.Id);
                    sendObj = new FTPSendObj(Members.GetLoginUserNode(receiverObj.Id), clientKey, sendFile.FullName, sendFile.Length, receiverObj.Id);
                    ButtonFTPStart.Enabled = true;
                }
                else
                    ButtonFTPStart.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void SendFileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (SendFileForms.Contain(this.formKey))
                {
                    SendFileForms.RemoveForm(this.formKey);
                    Logger.info("SendFileForms.Remove(key) :" + this.formKey);
                }

                connection.FTPSendingProgressed -= DisplayOnFTPSendingProgressed;
                connection.FTPSendingFinished -= DisplayOnFTPSendingFinished;
                connection.FTPSendingCanceled -= DisplayOnFTPSendingCanceled;
                connection.FTPSendingFailed -= DisplayOnFTPSendingFailed;
                connection.FTPSendingAccepted -= ProcessOnFTPSendingAccepted;
                connection.FTPSendingRejected -= ProcessOnFTPSendingRejected;
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


    }
}