using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Client.PopUp;
using WeDoCommon;
using WeDoCommon.Sockets;

namespace Client
{
    public partial class DownloadForm : FlashWindowForm
    {
        bool mFileCanceled = false;
        private string formKey;
        private FTPRcvObj rcvObj;
        private StateObject stateObj;
        private MsgrConnection connection;
        private string realDownloadedFileName;
        private Timer closeOnNoResponseTimer = new Timer();
        private ToolTip ToolTipFileName = new ToolTip();

        public DownloadForm(MsgrConnection connection, FTPRcvObj info)
        {
            InitializeComponent();
            this.connection = connection;
            this.rcvObj = info;
            this.formKey = info.Key;
            Initialize();
        }

        public string getFormKey()
        {
            return this.formKey;
        }

        public void Initialize()
        {
            labelMainMessage.Text = string.Format("{0}[{1}]님이 파일을 보내려고 합니다.\n파일을 저장하시겠습니까?",
                Members.GetByUserId(rcvObj.SenderId).Name, rcvObj.SenderId);
            //TextBoxSaveDir.Text = string.Format(WeDoCommon.ConstDef.MSGR_DATA_FILE_DIR,ConfigHelper.Id);
            TextBoxSaveDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            SetValidFileName(TextBoxSaveDir.Text);

            ToolTipFileName.SetToolTip(LabelFileName, realDownloadedFileName);
            ToolTipFileName.Active = true; 
            PanelFinishFileSave.Visible = false;
            setProgressVisible(false);
            DownloadForms.AddForm(formKey, this);
            
            connection.FTPReadyToListen += ProcessOnFTPReadyToListen;
            connection.FTPReceivingProgressed += ProcessOnFTPReceivingProgressed;
            connection.FTPReceivingFinished += ProcessOnFTPReceivingFinished;
            connection.FTPReceivingCanceled += ProcessOnFTPReceivingCanceled;
            connection.FTPReceivingFailed += ProcessOnFTPReceivingFailed;

            closeOnNoResponseTimer.Interval = 30000; //타임아웃을 30초로 설정하고 타임아웃인 경우 화면을 닫는다.
            closeOnNoResponseTimer.Tick += new EventHandler(CheckDownloadFileTimeOutOnTick);
            //connection.FTP
        }

        /// <summary>
        /// 30초 시간경과후 아무런 리턴메시지를 못받았을때 실패처리함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckDownloadFileTimeOutOnTick(object sender, EventArgs e)
        {
            closeOnNoResponseTimer.Stop();
            if (MessageBox.Show(this, string.Format("{0}님으로  파일받기가 시간초과로 실패하였습니다.", Members.GetByUserId(rcvObj.SenderId).Name)
                    + Environment.NewLine
                    + string.Format("수신 파일명:{0}", rcvObj.FileName), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    if (stateObj != null)
                        connection.CancelFTPReceiving(stateObj);
                }
                catch (Exception exception)
                {
                    Logger.error(exception.ToString());
                }
                Close();
            }

        }

        public void ProcessOnFTPReceivingProgressed(object sender, FTPStatusEventArgs e) 
        {
            try 
            {
                if (this.formKey.Equals(e.Status.Key)) {
                    Logger.info(string.Format("파일수신진행 ProcessOnFTPReceivingProgressed[{0}]",e.Status.Data));
                    ProgressBarFileRcv.Value = e.ProgressIndex;
                    closeOnNoResponseTimer.Stop();
                    stateObj = e.Status;//다운받는 파일의 상태정보
                    if (e.ProgressIndex == 0 || e.ProgressIndex == 100)
                        setProgressVisible(true);
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        public void ProcessOnFTPReceivingFinished(object sender, FTPStatusEventArgs e) 
        {
            try 
            {
                if (this.formKey.Equals(e.Status.Key))
                {
                    DisplaySaveResult();
                    ShowFlashWindow();
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        public void ProcessOnFTPReceivingCanceled(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (this.formKey.Equals(e.Status.Key))
                {
                    CancelFile();
                    ShowFlashWindow();
                    closeOnNoResponseTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        public void ProcessOnFTPReceivingFailed(object sender, FTPStatusEventArgs e)
        {
            try
            {
                if (this.formKey.Equals(e.Status.Key))
                {
                    DisplayErrorResult();
                    ShowFlashWindow();
                    closeOnNoResponseTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.info(ex.ToString());
            }
        }

        /// <summary>
        /// FTP리스너 기동상태로 서버에 FTP_READY_TO_SVR 전송
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnFTPReadyToListen(object sender, SocStatusEventArgs e)
        {
            connection.SendMsgAcceptFTP(rcvObj);//구성(Y|파일명|파일Key|수신자id)
        }

        public void ShowFlashWindow()
        {
            if (this.WindowState ==  FormWindowState.Minimized)
                DoFlashWindow();
        }

        private void SetValidFileName(string dirName)
        {
            realDownloadedFileName = SocUtils.GetValidFileName(dirName, rcvObj.FileName, 0);

            string shortenedFilePath = Utils.ShortenDirString(realDownloadedFileName);
            LabelFileName.Text = string.Format("파일명:{0}", Utils.ShortenString(shortenedFilePath, LabelFileName.Width - 70, LabelFileName.Font));
        }

        private void SelectDir()
        {
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = TextBoxSaveDir.Text;
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                TextBoxSaveDir.Text = folderBrowserDialog.SelectedPath;
                SetValidFileName(TextBoxSaveDir.Text);
            }
        }

        private void AllowDownload()
        {
            ButtonSaveDir.Enabled = false;
            ButtonClose.Visible = true;
            ButtonSaveFile.Visible = false;
            ButtonCancelFile.Visible = false;
            PanelRunFileSave.Refresh();
            labelMainMessage.Text = "파일 받기를 진행합니다.";
            TextBoxSaveDir.Enabled = false;
            //start something
            //파일수신대기/수신
            connection.StartFTPListeing(rcvObj, TextBoxSaveDir.Text);
            closeOnNoResponseTimer.Start();
        }

        private void RejectDownload()
        {
            //수락거부 파일 받기 거부("N|파일명|파일키|id)
            try
            {
                connection.SendMsgRejectFTP(this.rcvObj);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            this.Close();
        }

        private void DisplaySaveResult()
        {
            this.Text = "파일받기완료";
            labelMainMessage.Text = "파일 받기가 완료되었습니다.";
            setProgressVisible(false);
            PanelRunFileSave.Visible = false;
            PanelFinishFileSave.Location = PanelRunFileSave.Location;
            PanelFinishFileSave.Visible = true;
        }

        private void DisplayErrorResult()
        {
            this.Text = "파일받기실패";
            ButtonClose.Text = "확 인";
            labelMainMessage.Text = "전송오류로 파일 받기가 중단되었습니다.";
            mFileCanceled = true;
            setProgressVisible(false);
        }

        private void CancelFile()
        {
            //FTP_Cancel
            if (stateObj != null)
                connection.CancelFTPReceiving(stateObj);
            this.Text = "파일받기취소";
            ButtonClose.Text = "확 인";
            labelMainMessage.Text = "파일 받기가 취소되었습니다.";
            mFileCanceled = true;
            setProgressVisible(false);
        }
        
        int mPanelTopOrg;

        private void setProgressVisible(bool visible)
        {
            ProgressBarFileRcv.Visible = visible;
            if (visible)
            {
                PanelRunFileSave.Top = mPanelTopOrg;
            }
            else
            {
                mPanelTopOrg = PanelRunFileSave.Top;
                PanelRunFileSave.Top = ProgressBarFileRcv.Top;
            }
        }

        private void ButtonSaveFile_Click(object sender, EventArgs e)
        {
            AllowDownload();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (!mFileCanceled)
                CancelFile();
            else
                this.Close();
        }

        private void ButtonCancelFile_Click(object sender, EventArgs e)
        {

            RejectDownload();
        }

        private void ButtonSaveDir_Click(object sender, EventArgs e)
        {
            SelectDir();
        }

        private void ButtonOpenDir_Click(object sender, EventArgs e)
        {
            try
            {
                if (realDownloadedFileName != null && realDownloadedFileName.Trim() != "")
                {
                    FileInfo fileinfo = new FileInfo(realDownloadedFileName);
                    string dirname = fileinfo.DirectoryName;
                    System.Diagnostics.Process.Start(dirname);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.info("ButtonOpenDir_Click" + ex.ToString());
            }
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (realDownloadedFileName != null && realDownloadedFileName.Trim() != "")
                    System.Diagnostics.Process.Start(realDownloadedFileName);
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.info("ButtonOpenFile_Click" + ex.ToString());
            }
        }

        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DownloadForms.RemoveForm(formKey);
            connection.FTPReadyToListen -= ProcessOnFTPReadyToListen;
            connection.FTPReceivingProgressed -= ProcessOnFTPReceivingProgressed;
            connection.FTPReceivingFinished -= ProcessOnFTPReceivingFinished;
            connection.FTPReceivingCanceled -= ProcessOnFTPReceivingCanceled;
            connection.FTPReceivingFailed -= ProcessOnFTPReceivingFailed;
        }

    }
}
