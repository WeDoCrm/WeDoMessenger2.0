using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CRMmanager;
using Microsoft.Win32;
using WeDoCommon.Sockets;
using Client.Common;
using System.Collections.Generic;
using WeDoCommon;

namespace Client
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
       
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //초기 설정 관련

        private string MsgrTitle = CommonDef.MSGR_TITLE_PROD;

        private MiscController miscCtrl = new MiscController();
        private MsgrConnection connection;

        private bool isFormHidden = false;
        private bool firstCall = false; //활성화시 전화발신여부
        private Point mousePoint = Point.Empty;
        private Color labelColor;
        
        private ToolTip tooltip = new ToolTip();

        private static PopForm popform = null;
        private NotifyForm notifyform = null;
        private NoticeResultForm noticeresultform = null;
        private NoticeListForm noticelistform = null;
        private NoReceiveBoardForm noreceiveboardform = null;
        private MemoListForm mMemoListForm = null;
        
        private int mainform_width = 0;
        private int mainform_height = 0;
        private int screenWidth = 0;
        private int screenHeight = 0;
        private int mainform_x = 0;
        private int mainform_y = 0;

        //public ArrayList cmstorage = new ArrayList();

        private SkinSoft.AquaSkin.AquaSkin aquaSkin1;
        private PictureBox pbx_stat;
        private Label label4;
        private PictureBox pic_NRtrans;
        private Label NRtrans;
        private ToolStripMenuItem weDo정보ToolStripMenuItem;
        private Panel InfoBar;

        public Client_Form()
        {
            try
            {
                //
                // Windows Form 디자이너 지원에 필요합니다.
                //
                InitializeComponent();
                ConfigHelper.Initialize();
                Members.Initialize();
                LogFileCheck();

                connection = new MsgrConnection(this);
                //<--- 로그인접속
                connection.TeamListReceived += this.GenerateTeamTreeOnTeamListReceived;
                connection.TeamListReceiveDone += this.ProcessOnTeamListReceiveDone;
                connection.MemberStatusReceived += this.ChangeStatusOnMemberStatusReceived;
                connection.LoginFailed += this.ProcessOnLoginFailed;
                connection.LoginPassed += this.ProcessOnLoginPassed;
                connection.LoginDupped += this.ProcessOnLoginDupped;
                connection.ForcedLogoutNotified += this.LogoutOnForcedLogoutNotified;
                connection.ServerCheckSucceeded += this.DisplayLoginOnServerCheckSucceeded;
                connection.ServerCheckFailed += this.DisplayLogOutOnServerCheckFailed;
                //      로그인접속--->
                connection.NoticeResultFromDBReceived += this.DisplayOnNoticeResultFromDBReceived;
                connection.MemoMsgReceived += this.CreateMemoFormOnMemoMsgReceived;
                connection.NewChatMsgReceived += this.OpenNewChatFormOnMsgReceived;
                connection.NoticeCheckNotified += this.AddNoticeCheckUserOnNotified;
                // <--- FTP ---
                connection.FTPSendingNotified += this.ShowDownloadFormOnFTPInfoReceived;
                //  --- FTP --->
                // <--- 공지
                connection.InstantNoticeReceived += this.PopUpNoticeOnInstantNoticeReceived;
                connection.UnCheckedDataReceived += this.PopUpOnUnCheckedDataReceived;
                connection.UnCheckedMemoReceived += this.PopUpListOnUnCheckedMemoReceived;
                connection.UnCheckedNoticeReceived += this.PopUpListOnUnCheckedNoticeReceived;
                connection.UnCheckedTransferReceived += this.PopUpListOnUnCheckedTransferReceived;
                connection.NoticeListReceived += this.DisplayFormOnNoticeListReceived;
                connection.CustomerInfoTransfered += this.PopUpNotifyOnCustomerInfoTransfered;
                //      공지 ---> 
                // <--- CallControl
                connection.CallRingingReceived += this.PopUpOnCallRingingReceived;
                connection.CallAnswerReceived += this.PopUpOnCallAnswerReceived;
                connection.CallDialingReceived += this.PopUpOnCallAnswerReceived;
                connection.CallOtherAnswerReceived += this.PopUpCloseOnCallOtherAnswerReceived;
                connection.CallAbandonReceived += this.PopUpCloseOnCallAbandonReceived;
                //      CallControl --->
                
                Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);
                TransferNotiForms.Initialize();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private void Client_Form_Load(object sender, EventArgs e)
        {
            InitializeLoginForm();
            StartService();
        }

        /// <summary>
        /// 최초 로그인 화면 보임
        /// </summary>
        private void InitializeLoginForm()
        {
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.SetBounds(screenWidth - this.Width, 0, this.Width, this.Height);

            this.Text = MsgrTitle;
            SetinitLoginBox();
        }

        /// <summary>
        /// 로그인창 처음 뜰때 아이디/비번 뿌려줌
        /// </summary>
        private void SetinitLoginBox()
        {
            try
            {
                id.Text = ConfigHelper.Id;

                if (ConfigHelper.SavePass)
                {
                    tbx_pass.Text = ConfigHelper.Pass;
                    cbx_pass_save.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Logger.error("SetLoginInfo Error : " + ex.ToString());
            }
        }

        /// <summary>
        /// 최초 서비스 시작
        /// if 자동로그인 
        ///     서버접속 및 로그인
        /// else
        ///     로그인초기화면
        /// 서버접속 및 메시지 수신 Thread 시작
        /// </summary>
        /// 
        private void StartService()
        {
            try
            {
                //자동로그인
                if (ConfigHelper.AutoStart && ConfigHelper.Id != null && ConfigHelper.Pass != null && ConfigHelper.Extension != null)
                {
                    ProcessLogin();
                }
                else
                {
                    if (ConfigHelper.Id == null)
                        id.Focus();
                    else
                        tbx_pass.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        private void ProcessLogin()
        {
            if (id.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "아이디를 입력해 주세요", "알림", MessageBoxButtons.OK);
                id.Focus();
            }
            else if (tbx_pass.Text.Trim().Length == 0)
            {
                Logger.info("아이디 체크 완료!");
                MessageBox.Show(this, "비밀번호를 입력해 주세요", "알림", MessageBoxButtons.OK);
                tbx_pass.Focus();
            }
            else if (ConfigHelper.Extension == null || ConfigHelper.Extension.Length == 0)
            {
                Logger.info("비밀번호 체크 완료!");
                MessageBox.Show(this, "내선번호를 설정해 주세요", "알림", MessageBoxButtons.OK);
                DisplayExtensionForm();
            }
            else
            {
                ConfigHelper.TryId = id.Text.ToLower().Trim();
                ConfigHelper.TryPass = tbx_pass.Text.Trim();
                EnableLoginCtrl(false);
                if (connection != null && connection.StartService())
                {
                    connection.SendMsgUserLogin();
                    Logger.info("서버에 로그인요청");
                }
                else
                {                
                    MessageBox.Show(this, "서버접속에 실패했습니다." + Environment.NewLine + "서버점검이 필요합니다.", "알림", MessageBoxButtons.OK);
                    EnableLoginCtrl(true); 
                    id.Focus();
                }
            }
        }
                
        /// <summary>
        /// 재로그인하라는 통보받고 재로그인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnLoginDupped(object sender, EventArgs e)
        {
            ReLogin();
        }

        /// <summary>
        /// 강제 로그아웃시 로그아웃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LogoutOnForcedLogoutNotified(object sender, EventArgs e)
        {
            MessageBox.Show(this, "서버사정으로 메신저가 강제종료되었습니다."+Environment.NewLine+"추후 재접속하세요.", "알림", MessageBoxButtons.OK);
            ProcessLogOut();
        }

        /// <summary>
        /// 시스템 종료시 프로세스 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            try
            {
                if (connection.IsConnected)
                    ProcessLogOut();
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// 접속체크실패시 로그아웃처리
        /// 1.로그아웃
        /// 2.로그인화면전환
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayLogOutOnServerCheckFailed(object sender, EventArgs e)
        {
            try
            {
                DisplayLoginPanelBeforeLogOut(false);
                ProcessLogOut();
                //LogOutDelegate logoutdele = new LogOutDelegate(ProcessLogOut);
                //Invoke(ProcessLogOut);
                //PanelCtrlDelegate dele = new PanelCtrlDelegate(DisplayLoginPanelBeforeLogOut);
                //Invoke(dele, false);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// true:로그인활성화 
        /// false: 로그인진행전 비활성화(로그인입력창 비활성화)
        /// case: 
        /// 1. 로그인 접속실패 true
        /// 2. 중복로그인실패 처리 true
        /// 3. 로그인 인증실패 true
        /// 4. 로그아웃처리 true
        /// 5. 접속시도 false
        /// </summary>
        /// <param name="value"></param>
        private void EnableLoginCtrl(bool value)
        {
            tbx_pass.Enabled = value;
            id.Enabled = value;
            btn_login.Enabled = value;
            cbx_pass_save.Enabled = value;
            panel_progress.Visible = !value;
        }

        /// <summary>
        /// 접속실패시 접속시도화면
        /// True:  성공시 접속하며, 로인창보이기
        /// false: 실패시 로그아웃하며 시도화면보임
        /// </summary>
        /// <param name="value"></param>
        private void DisplayLoginPanelBeforeLogOut(bool value)
        {
            label_id.Visible = value; //아이디입력창
            id.Visible = value;

            label_pass.Visible = value;//패스워드입력창
            tbx_pass.Visible = value;

            btn_login.Visible = value;//로그인버튼

            cbx_pass_save.Visible = value;//패스워드저장선택
            pbx_loginCancel.Visible = !value; //로그인취소이미지 안보임
            if (!value)
            {
                panel_progress.Visible = true;
                label_progress_status.Text = "접속중";
            }
        }

        /// <summary>
        /// 로그인 및 로그아웃 일때 폼 패널 및 버튼 컨트롤
        /// true:로그아웃처리시
        /// false:로그인후 팀정보수신완료시
        /// </summary>
        /// <param name="value"></param>
        public void LogInPanelVisible(bool value)
        {
            label_id.Visible = value;  //아이디입력창
            id.Visible = value;

            label_pass.Visible = value;//패스워드입력창
            tbx_pass.Visible = value;
            
            btn_login.Visible = value; //로그인버튼
            
            default_panal.Visible = value; //로그인 전 판넬
            pic_title.Visible = value;     //로그인타이틀

            panel_logon.Visible = !value; //로그인후 판넬
        }

        /// <summary>
        /// 접속오류후 서버체크 성공시 로그인화면 보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayLoginOnServerCheckSucceeded(object sender, EventArgs e)
        {
            DisplayLoginPanelBeforeLogOut(true);
            ProcessLogin();
        }

        /// <summary>
        /// 로그인성공후 목록보이기
        /// </summary>
        private void ProcessOnLoginPassed(object sender, CustomEventArgs e)
        {
            label_progress_status.Text = "로딩중";

            //개인 정보를 Client_Form 에 표시
            name.Text = ConfigHelper.Name + "(" + ConfigHelper.Id + ")"; ;

            if (ConfigHelper.TeamName.Length > 0)
                team.Text = ConfigHelper.TeamName;
            else
                team.Text = ConfigHelper.CompanyName;

            //화면의 모든 콘트롤에 keydown이벤트설정
            this.KeyDown += new KeyEventHandler(Client_Form_KeyDown);
            int count = this.Controls.Count;

            for (int i = 0; i < count; i++)
            {
                this.Controls[i].KeyDown += new KeyEventHandler(Client_Form_KeyDown);
            }

            //쪽지 및 대화 저장 폴더, 파일 생성
            MemoUtils.MemoFileCheck(ConfigHelper.Id);
            miscCtrl.CheckDialogSaveFolder();
            miscCtrl.CheckFileSaveFolder();
        }

        #region 콜처리 팝업관련
        /// <summary>
        /// 이관업무받을때 이관화면 팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUpNotifyOnCustomerInfoTransfered(object sender, CustomEventArgs e)//pass|ani|senderID|receiverID|TONG_DATE|TONG_TIME|CustomerName
        {
            try
            {
                string[] tempMsg = (string[])e.GetItem;
                if (!tempMsg[2].Equals(ConfigHelper.Id))
                {
                    notifyform = new NotifyForm(tempMsg);
                    notifyform.Focus();
                    notifyform.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// 발신자 표시 팝업
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="name"></param>
        /// <param name="server_type"></param>
        private void PopUpOnCallRingingReceived(object sender, CustomEventArgs e)
        {
            try
            {
                string[] msg = (string[])e.GetItem;
                string ani = msg[0];
                string name = msg[1];
                string server_type = msg[2];

                Logger.info("Ringing : ani[" + ani + "]name[" + name + "]server_type[" + server_type + "]nopop[" + ConfigHelper.NoPop + "]");

                if (popform != null)
                {
                    popform.Close();
                }
                //getForegroundWindow();
                popform = new PopForm();
                popform.Tag = name;
                if (name.Length > 0)
                    popform.label1.Text = name + "\r\n" + ani;
                else
                    popform.label1.Text = ani;

                if (isFormHidden == false && firstCall == false)
                {
                    popform.TopMost = true;
                    firstCall = true;
                }
                else
                {
                    popform.TopMost = false;
                }

                this.TopLevel = true;
                popform.TopLevel = true;
                popform.Show();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        /// <summary>
        /// 수화기들었을때 팝업닫고, CRM팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUpOnCallAnswerReceived(object sender, CustomEventArgs e)
        {
            string[] msg = (string[])e.GetItem;
            string ani = msg[0];
            string calltype = msg[1];

            Logger.info("Answer : ani[" + ani + "]calltype[" + calltype + "]nopop[" + ConfigHelper.NoPop + "]nopop_outbound[" + ConfigHelper.NoPopOutBound + "]");
            if (popform != null)
            {
                if (ConfigHelper.NoPop)
                {
                    string name = popform.Tag.ToString();
                    TransferNotiForms.AddForm(ani, name);
                }
                popform.Close();                
            }
            if (!ConfigHelper.NoPop)
                CrmHelper.ShowCustomerPopup(ani, calltype);
        }

        /// <summary>
        /// 인입호를 다른 클라이언트가 수신시 벨울림창 처리
        /// </summary>
        private void PopUpCloseOnCallOtherAnswerReceived(object sender, EventArgs e)
        {
            if (popform != null)
            {
                popform.Close();
            }
        }

        /// <summary>
        /// 포기호일때 팝업닫기
        /// </summary>
        private void PopUpCloseOnCallAbandonReceived(object sender, EventArgs e)
        {
            if (popform != null)
            {
                popform.Close();
            }
        }
        #endregion

        /// <summary>
        /// 각종 단축키 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control) //쪽지 보내기
            {
                MakeSendMemo(new List<MemberObj>());
            }
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) //공지하기
            {
                MakeSendNotice();
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control) //파일 보내기
            {
                MakeSendFileForm(new List<MemberObj>());
            }
        }

        /// <summary>
        /// 사용자 상태 변경 처리
        /// </summary>
        /// <param name="statid"></param>
        /// <param name="presence"></param>
        private void ChangeStatusOnMemberStatusReceived(object sender, CustomEventArgs e)
        {
            try {
                MemberObj memberObj = (MemberObj)e.GetItem;

                TreeNode[] teamNode = memTree.Nodes.Find(memberObj.TeamName, false);
                TreeNode[] memNode = teamNode[0].Nodes.Find(memberObj.Id, false);
                MemberObj userObj = (MemberObj)memNode[0].Tag;
                switch (memberObj.Status)
                {
                    case MsgrUserStatus.BUSY://"busy":
                        memNode[0].ImageIndex = 6;
                        memNode[0].SelectedImageIndex = 6;
                        userObj.Status = MsgrUserStatus.BUSY;
                        break;

                    case MsgrUserStatus.AWAY://"away":
                        memNode[0].ImageIndex = 4;
                        memNode[0].SelectedImageIndex = 4;
                        userObj.Status = MsgrUserStatus.AWAY;
                        break;

                    case MsgrUserStatus.LOGOUT://"logout":
                        memNode[0].ForeColor = Color.Gray;
                        memNode[0].ImageIndex = 0;
                        memNode[0].SelectedImageIndex = 0;
                        Members.RemoveLoginUser(memberObj.Id);
                        userObj.Status = MsgrUserStatus.LOGOUT;
                        break;

                    case MsgrUserStatus.ONLINE://"online":
                        memNode[0].ForeColor = Color.Black;
                        memNode[0].ImageIndex = 1;
                        memNode[0].SelectedImageIndex = 1;
                        userObj.Status = MsgrUserStatus.ONLINE;
                        break;

                    case MsgrUserStatus.DND://"DND":
                        memNode[0].ImageIndex = 5;
                        memNode[0].SelectedImageIndex = 5;
                        userObj.Status = MsgrUserStatus.DND;
                        break;
                }
                memNode[0].Text = userObj.Title;
                memNode[0].Tag = userObj;

                Logger.info(memberObj.Id + "의 상태값" + memberObj.Status + " 로 변경");
            } catch (Exception ex) {
                Logger.error(" 상태값 변경 오류 : " + ex.ToString());
            }
        }

        /// <summary>
        /// 중복로그인 시도 경우 
        /// </summary>
        public void ReLogin()
        {
            EnableLoginCtrl(true);
            DialogResult result = MessageBox.Show(this, "아이디 " + this.id.Text + "는 이미 로그인 상태입니다.\r\n 기존 접속을 로그아웃 하시겠습니까?", "로그인 중복", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                connection.SendMsgUserLogOut();
                ClearResourceOnClosing();
                MessageBox.Show(this, "정상적으로 로그아웃 했습니다. 다시 로그인해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else ClearResourceOnClosing();
        }

        private void ProcessOnLoginFailed(object sender, CustomEventArgs e)
        {
            string msg = (string)e.GetItem;
            EnableLoginCtrl(true);
            MessageBox.Show(this, msg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id.Focus();
        }

        /// <summary>
        /// true: 로그인후 메뉴/트리/버튼(트리정보받은후)
        /// false: 로그인전 메뉴 
        /// </summary>
        /// <param name="value"></param>
        public void EnableLogOnCtrl(bool value)
        {
            if (value)
            {
                tooltip.Active = true;
                //tooltip 설정
                tooltip.AutoPopDelay = 0;
                tooltip.AutomaticDelay = 2000;
                tooltip.InitialDelay = 100;
            }
            else
            {
                tooltip.Active = false;
            }
            InfoBar.Visible = value;
            memTree.Visible = value;
            MnDialogue.Enabled = value;
            MnSendFile.Enabled = value;
            MnLogout.Enabled = value;
            MnMemo.Enabled = value;
            //MnNoticeShow.Enabled = value;
            MnNotice.Enabled = value;
            Mn_server.Enabled = !value;
            Mn_extension.Enabled = !value;
        }

        /// <summary>
        /// 팀정보를 서버로 부터 받은 경우 TreeView에 트리 생성
        /// </summary>
        /// <param name="team"></param>
        /// <param name="list"></param>
        private void GenerateTeamTreeOnTeamListReceived(object sender, CustomEventArgs e) //list[] {id!name}
        {
            try
            {
                string team = (string)e.GetItem;
                int nodeNum = memTree.Nodes.Count;
                TreeNode node=null;
                if (team.Length != 0)
                {
                    if (!memTree.Nodes.ContainsKey(team))
                    {
                        node = memTree.Nodes.Add(team, "");//팀노드 추가
                        node.Text = team;
                        node.NodeFont = new Font("굴림", 9.75f, FontStyle.Bold);
                        node.ForeColor = Color.IndianRed;
                        node.EnsureVisible();
                        //memTree.e

                        Dictionary<string, MemberObj> members = Members.GetMembersByTeam(team);
                        List<MemberObj> memberList = new List<MemberObj>(members.Values);

                        foreach (MemberObj memberPair in memberList)
                        {
                            if (memberPair.Id.Equals(ConfigHelper.Id)) continue;
                            TreeNode tempNode = memTree.Nodes[nodeNum].Nodes.Add(memberPair.Id, memberPair.Name);   //사용자 노드 추가(노드 key=id, value=name)
                            tempNode.ToolTipText = memberPair.Id; //MouseOver일 경우 나타남 
                            tempNode.ForeColor = Color.Gray;
                            tempNode.Tag = new MemberObj(team, memberPair.Id, memberPair.Name);//arg[0];
                            tempNode.ImageIndex = 0;
                            tempNode.SelectedImageIndex = 0;
                        }
                    }
                }
                memTree.ExpandAll();
                Logger.info(team + " 팀 리스트 생성!");
                //if (!memTree.Nodes[0].IsExpanded) memTree.Nodes[0].Expand();
                //if (team.Equals(this.team.Text)) node.Expand(); 

                //this.statusBar.Text = "";
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 접속화면 활성화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnTeamListReceiveDone(object sender, EventArgs e)
        {
            EnableLogOnCtrl(true);   //트리목록/메뉴/버튼/툴팁 보이기
            LogInPanelVisible(false);//로그인화면 안보이기
        }

        /// <summary>
        /// 로깅에 필요한 경로 생성
        /// 1. ./log, ./config 경로 생성
        /// 2. minicti config file 없을경우 백업본 복사
        /// 4. log file cleansing필요
        /// </summary>
        public void LogFileCheck()
        {
            try
            {
                Logger.BackupOnInit();
                Logger.setLogLevel(LOGLEVEL.INFO);
                Logger.info("LogFile 초기화완료");
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        /// <summary>
        /// 메신저 클라이언트 리소스 정리
        /// </summary>
        private void ClearResourceOnClosing()
        {
            try
            {
                if (connection.IsConnected)
                    connection.Dispose();
            }
            catch (Exception ex)
            {
                Logger.error("ClearResourceOnClosing() 에러 : " + ex.ToString());
            }
        }

        /// <summary>
        /// 로그아웃처리하고 로그인화면전환
        /// </summary>
        private void ProcessLogOut()
        {
            try
            {
                if (connection != null && connection.IsConnected)
                {
                    connection.SendMsgUserLogOut();
                    connection.Dispose();
                }
                //열려있는 대화창 및 쪽지폼 확인 및 삭제
                LogOutDelegate disposeForms = new LogOutDelegate(DisposeFormsOnLogOut);
                Invoke(disposeForms, null);

                memTree.Nodes.Clear();
                ClearResourceOnClosing();
                EnableLogOnCtrl(false);
                LogInPanelVisible(true);
                EnableLoginCtrl(true);
                if (cbx_pass_save.Checked == false)
                {
                    tbx_pass.Text = "";
                }
                label_stat.Text = "온라인 ▼";
                id.Focus();
                id.SelectAll();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        /// <summary>
        /// 열린 창 닫기
        /// 로그아웃 전에 열린 폼 닫기 및 정보테이블 삭제
        /// </summary>
        public void DisposeFormsOnLogOut() {
            //자원해제 대상
            try {
                if (noticelistform != null && !noticelistform.IsDisposed)
                {
                    noticelistform.Close();
                    noticelistform.Dispose();
                }

                if (noticeresultform != null && !noticeresultform.IsDisposed)
                {
                    noticeresultform.Close();
                    noticeresultform.Dispose();
                }

                if (noreceiveboardform != null && !noreceiveboardform.IsDisposed)
                {
                    noreceiveboardform.Close();
                    noreceiveboardform.Dispose();
                }

                if (mMemoListForm != null && !mMemoListForm.IsDisposed)
                {
                    mMemoListForm.Close();
                    mMemoListForm.Dispose();
                }

                ChatForms.Dispose();
                SendMemoForms.Dispose();
                Members.ClearAll();
                FileSendDetailListViews.Dispose();
                SendFileForms.Dispose();
                DownloadForms.Dispose();
                NoticeDetailForms.Dispose();
                MemoForms.Dispose();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        /// <summary>
        /// 메신저 끝내기
        /// </summary>
        private void ExitMessenger() {

            if (connection.IsConnected)
                ProcessLogOut();
            else
                ClearResourceOnClosing();
            this.notifyIcon.Visible = false;
            Process.GetCurrentProcess().Kill();
        }

        private void DisplayExtensionForm()
        {
            SetExtensionForm frm = null;
            try
            {
                frm = new SetExtensionForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!connection.IsConnected)
                        ProcessLogin();
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
            finally
            {
                if (frm != null) frm.Dispose();
            }
        }

        private void ChangeMyStatus(string statname)
        {
            label_stat.Text = statname + " ▼";
            switch (statname)
            {
                case "자리비움":
                    pbx_stat.Image = global::Client.Properties.Resources.부재중;
                    break;

                case "오프라인 표시":
                    pbx_stat.Image = global::Client.Properties.Resources.로그아웃;
                    break;

                case "다른용무중" :
                    pbx_stat.Image = global::Client.Properties.Resources.다른용무중;
                    break;

                case "통화중" :
                    pbx_stat.Image = global::Client.Properties.Resources.통화중;
                    break;
                    
                case "온라인":
                    pbx_stat.Image = global::Client.Properties.Resources.온라인;
                    break;
            }
        }

        private void cbx_pass_save_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper.SavePass = cbx_pass_save.Checked;
        }

        /// <summary>
        /// 사용자가 닫기를 누른경우 숨김으로 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                mainform_width = this.Width;
                mainform_height = this.Height;
                mainform_x = this.Left;
                mainform_y = this.Top;
                this.Hide();
                this.ShowInTaskbar = false;
                isFormHidden = true;
            }
            else
            {
                if (connection.IsConnected)
                    connection.SendMsgUserLogOut();
                ClearResourceOnClosing();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void memTree_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (memTree.SelectedNode != null)
                    OpenSendFileFormBySelectedNode(file);
            }
        }

        private void memTree_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void memTree_DragOver(object sender, DragEventArgs e)
        {
            Point fileDropPoint = new Point(0, 0);
            fileDropPoint.X = e.X;
            fileDropPoint.Y = e.Y;
            fileDropPoint = memTree.PointToClient(fileDropPoint);
            memTree.SelectedNode = memTree.GetNodeAt(fileDropPoint);
        }     
    }
}