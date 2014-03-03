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
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
       
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        //�ʱ� ���� ����

        private string MsgrTitle = CommonDef.MSGR_TITLE_PROD;

        private MiscController miscCtrl = new MiscController();
        private MsgrConnection connection;

        private bool isFormHidden = false;
        private bool firstCall = false; //Ȱ��ȭ�� ��ȭ�߽ſ���
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
        private ToolStripMenuItem weDo����ToolStripMenuItem;
        private Panel InfoBar;

        public Client_Form()
        {
            try
            {
                //
                // Windows Form �����̳� ������ �ʿ��մϴ�.
                //
                InitializeComponent();
                ConfigHelper.Initialize();
                Members.Initialize();
                LogFileCheck();

                connection = new MsgrConnection(this);
                //<--- �α�������
                connection.TeamListReceived += this.GenerateTeamTreeOnTeamListReceived;
                connection.TeamListReceiveDone += this.ProcessOnTeamListReceiveDone;
                connection.MemberStatusReceived += this.ChangeStatusOnMemberStatusReceived;
                connection.LoginFailed += this.ProcessOnLoginFailed;
                connection.LoginPassed += this.ProcessOnLoginPassed;
                connection.LoginDupped += this.ProcessOnLoginDupped;
                connection.ForcedLogoutNotified += this.LogoutOnForcedLogoutNotified;
                connection.ServerCheckSucceeded += this.DisplayLoginOnServerCheckSucceeded;
                connection.ServerCheckFailed += this.DisplayLogOutOnServerCheckFailed;
                //      �α�������--->
                connection.NoticeResultFromDBReceived += this.DisplayOnNoticeResultFromDBReceived;
                connection.MemoMsgReceived += this.CreateMemoFormOnMemoMsgReceived;
                connection.NewChatMsgReceived += this.OpenNewChatFormOnMsgReceived;
                connection.NoticeCheckNotified += this.AddNoticeCheckUserOnNotified;
                // <--- FTP ---
                connection.FTPSendingNotified += this.ShowDownloadFormOnFTPInfoReceived;
                //  --- FTP --->
                // <--- ����
                connection.InstantNoticeReceived += this.PopUpNoticeOnInstantNoticeReceived;
                connection.UnCheckedDataReceived += this.PopUpOnUnCheckedDataReceived;
                connection.UnCheckedMemoReceived += this.PopUpListOnUnCheckedMemoReceived;
                connection.UnCheckedNoticeReceived += this.PopUpListOnUnCheckedNoticeReceived;
                connection.UnCheckedTransferReceived += this.PopUpListOnUnCheckedTransferReceived;
                connection.NoticeListReceived += this.DisplayFormOnNoticeListReceived;
                connection.CustomerInfoTransfered += this.PopUpNotifyOnCustomerInfoTransfered;
                //      ���� ---> 
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
        /// ���� �α��� ȭ�� ����
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
        /// �α���â ó�� �㶧 ���̵�/��� �ѷ���
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
        /// ���� ���� ����
        /// if �ڵ��α��� 
        ///     �������� �� �α���
        /// else
        ///     �α����ʱ�ȭ��
        /// �������� �� �޽��� ���� Thread ����
        /// </summary>
        /// 
        private void StartService()
        {
            try
            {
                //�ڵ��α���
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
                MessageBox.Show(this, "���̵� �Է��� �ּ���", "�˸�", MessageBoxButtons.OK);
                id.Focus();
            }
            else if (tbx_pass.Text.Trim().Length == 0)
            {
                Logger.info("���̵� üũ �Ϸ�!");
                MessageBox.Show(this, "��й�ȣ�� �Է��� �ּ���", "�˸�", MessageBoxButtons.OK);
                tbx_pass.Focus();
            }
            else if (ConfigHelper.Extension == null || ConfigHelper.Extension.Length == 0)
            {
                Logger.info("��й�ȣ üũ �Ϸ�!");
                MessageBox.Show(this, "������ȣ�� ������ �ּ���", "�˸�", MessageBoxButtons.OK);
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
                    Logger.info("������ �α��ο�û");
                }
                else
                {                
                    MessageBox.Show(this, "�������ӿ� �����߽��ϴ�." + Environment.NewLine + "���������� �ʿ��մϴ�.", "�˸�", MessageBoxButtons.OK);
                    EnableLoginCtrl(true); 
                    id.Focus();
                }
            }
        }
                
        /// <summary>
        /// ��α����϶�� �뺸�ް� ��α���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnLoginDupped(object sender, EventArgs e)
        {
            ReLogin();
        }

        /// <summary>
        /// ���� �α׾ƿ��� �α׾ƿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LogoutOnForcedLogoutNotified(object sender, EventArgs e)
        {
            MessageBox.Show(this, "������������ �޽����� ��������Ǿ����ϴ�."+Environment.NewLine+"���� �������ϼ���.", "�˸�", MessageBoxButtons.OK);
            ProcessLogOut();
        }

        /// <summary>
        /// �ý��� ����� ���μ��� ����
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
        /// ����üũ���н� �α׾ƿ�ó��
        /// 1.�α׾ƿ�
        /// 2.�α���ȭ����ȯ
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
        /// true:�α���Ȱ��ȭ 
        /// false: �α��������� ��Ȱ��ȭ(�α����Է�â ��Ȱ��ȭ)
        /// case: 
        /// 1. �α��� ���ӽ��� true
        /// 2. �ߺ��α��ν��� ó�� true
        /// 3. �α��� �������� true
        /// 4. �α׾ƿ�ó�� true
        /// 5. ���ӽõ� false
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
        /// ���ӽ��н� ���ӽõ�ȭ��
        /// True:  ������ �����ϸ�, ����â���̱�
        /// false: ���н� �α׾ƿ��ϸ� �õ�ȭ�麸��
        /// </summary>
        /// <param name="value"></param>
        private void DisplayLoginPanelBeforeLogOut(bool value)
        {
            label_id.Visible = value; //���̵��Է�â
            id.Visible = value;

            label_pass.Visible = value;//�н������Է�â
            tbx_pass.Visible = value;

            btn_login.Visible = value;//�α��ι�ư

            cbx_pass_save.Visible = value;//�н��������弱��
            pbx_loginCancel.Visible = !value; //�α�������̹��� �Ⱥ���
            if (!value)
            {
                panel_progress.Visible = true;
                label_progress_status.Text = "������";
            }
        }

        /// <summary>
        /// �α��� �� �α׾ƿ� �϶� �� �г� �� ��ư ��Ʈ��
        /// true:�α׾ƿ�ó����
        /// false:�α����� ���������ſϷ��
        /// </summary>
        /// <param name="value"></param>
        public void LogInPanelVisible(bool value)
        {
            label_id.Visible = value;  //���̵��Է�â
            id.Visible = value;

            label_pass.Visible = value;//�н������Է�â
            tbx_pass.Visible = value;
            
            btn_login.Visible = value; //�α��ι�ư
            
            default_panal.Visible = value; //�α��� �� �ǳ�
            pic_title.Visible = value;     //�α���Ÿ��Ʋ

            panel_logon.Visible = !value; //�α����� �ǳ�
        }

        /// <summary>
        /// ���ӿ����� ����üũ ������ �α���ȭ�� ���̱�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayLoginOnServerCheckSucceeded(object sender, EventArgs e)
        {
            DisplayLoginPanelBeforeLogOut(true);
            ProcessLogin();
        }

        /// <summary>
        /// �α��μ����� ��Ϻ��̱�
        /// </summary>
        private void ProcessOnLoginPassed(object sender, CustomEventArgs e)
        {
            label_progress_status.Text = "�ε���";

            //���� ������ Client_Form �� ǥ��
            name.Text = ConfigHelper.Name + "(" + ConfigHelper.Id + ")"; ;

            if (ConfigHelper.TeamName.Length > 0)
                team.Text = ConfigHelper.TeamName;
            else
                team.Text = ConfigHelper.CompanyName;

            //ȭ���� ��� ��Ʈ�ѿ� keydown�̺�Ʈ����
            this.KeyDown += new KeyEventHandler(Client_Form_KeyDown);
            int count = this.Controls.Count;

            for (int i = 0; i < count; i++)
            {
                this.Controls[i].KeyDown += new KeyEventHandler(Client_Form_KeyDown);
            }

            //���� �� ��ȭ ���� ����, ���� ����
            MemoUtils.MemoFileCheck(ConfigHelper.Id);
            miscCtrl.CheckDialogSaveFolder();
            miscCtrl.CheckFileSaveFolder();
        }

        #region ��ó�� �˾�����
        /// <summary>
        /// �̰����������� �̰�ȭ�� �˾�
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
        /// �߽��� ǥ�� �˾�
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
        /// ��ȭ�������� �˾��ݰ�, CRM�˾�
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
        /// ����ȣ�� �ٸ� Ŭ���̾�Ʈ�� ���Ž� ���︲â ó��
        /// </summary>
        private void PopUpCloseOnCallOtherAnswerReceived(object sender, EventArgs e)
        {
            if (popform != null)
            {
                popform.Close();
            }
        }

        /// <summary>
        /// ����ȣ�϶� �˾��ݱ�
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
        /// ���� ����Ű ó��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M && e.Modifiers == Keys.Control) //���� ������
            {
                MakeSendMemo(new List<MemberObj>());
            }
            else if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) //�����ϱ�
            {
                MakeSendNotice();
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control) //���� ������
            {
                MakeSendFileForm(new List<MemberObj>());
            }
        }

        /// <summary>
        /// ����� ���� ���� ó��
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

                Logger.info(memberObj.Id + "�� ���°�" + memberObj.Status + " �� ����");
            } catch (Exception ex) {
                Logger.error(" ���°� ���� ���� : " + ex.ToString());
            }
        }

        /// <summary>
        /// �ߺ��α��� �õ� ��� 
        /// </summary>
        public void ReLogin()
        {
            EnableLoginCtrl(true);
            DialogResult result = MessageBox.Show(this, "���̵� " + this.id.Text + "�� �̹� �α��� �����Դϴ�.\r\n ���� ������ �α׾ƿ� �Ͻðڽ��ϱ�?", "�α��� �ߺ�", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                connection.SendMsgUserLogOut();
                ClearResourceOnClosing();
                MessageBox.Show(this, "���������� �α׾ƿ� �߽��ϴ�. �ٽ� �α����� �ּ���", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else ClearResourceOnClosing();
        }

        private void ProcessOnLoginFailed(object sender, CustomEventArgs e)
        {
            string msg = (string)e.GetItem;
            EnableLoginCtrl(true);
            MessageBox.Show(this, msg, "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            id.Focus();
        }

        /// <summary>
        /// true: �α����� �޴�/Ʈ��/��ư(Ʈ������������)
        /// false: �α����� �޴� 
        /// </summary>
        /// <param name="value"></param>
        public void EnableLogOnCtrl(bool value)
        {
            if (value)
            {
                tooltip.Active = true;
                //tooltip ����
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
        /// �������� ������ ���� ���� ��� TreeView�� Ʈ�� ����
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
                        node = memTree.Nodes.Add(team, "");//����� �߰�
                        node.Text = team;
                        node.NodeFont = new Font("����", 9.75f, FontStyle.Bold);
                        node.ForeColor = Color.IndianRed;
                        node.EnsureVisible();
                        //memTree.e

                        Dictionary<string, MemberObj> members = Members.GetMembersByTeam(team);
                        List<MemberObj> memberList = new List<MemberObj>(members.Values);

                        foreach (MemberObj memberPair in memberList)
                        {
                            if (memberPair.Id.Equals(ConfigHelper.Id)) continue;
                            TreeNode tempNode = memTree.Nodes[nodeNum].Nodes.Add(memberPair.Id, memberPair.Name);   //����� ��� �߰�(��� key=id, value=name)
                            tempNode.ToolTipText = memberPair.Id; //MouseOver�� ��� ��Ÿ�� 
                            tempNode.ForeColor = Color.Gray;
                            tempNode.Tag = new MemberObj(team, memberPair.Id, memberPair.Name);//arg[0];
                            tempNode.ImageIndex = 0;
                            tempNode.SelectedImageIndex = 0;
                        }
                    }
                }
                memTree.ExpandAll();
                Logger.info(team + " �� ����Ʈ ����!");
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
        /// ����ȭ�� Ȱ��ȭ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessOnTeamListReceiveDone(object sender, EventArgs e)
        {
            EnableLogOnCtrl(true);   //Ʈ�����/�޴�/��ư/���� ���̱�
            LogInPanelVisible(false);//�α���ȭ�� �Ⱥ��̱�
        }

        /// <summary>
        /// �α뿡 �ʿ��� ��� ����
        /// 1. ./log, ./config ��� ����
        /// 2. minicti config file ������� ����� ����
        /// 4. log file cleansing�ʿ�
        /// </summary>
        public void LogFileCheck()
        {
            try
            {
                Logger.BackupOnInit();
                Logger.setLogLevel(LOGLEVEL.INFO);
                Logger.info("LogFile �ʱ�ȭ�Ϸ�");
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        /// <summary>
        /// �޽��� Ŭ���̾�Ʈ ���ҽ� ����
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
                Logger.error("ClearResourceOnClosing() ���� : " + ex.ToString());
            }
        }

        /// <summary>
        /// �α׾ƿ�ó���ϰ� �α���ȭ����ȯ
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
                //�����ִ� ��ȭâ �� ������ Ȯ�� �� ����
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
                label_stat.Text = "�¶��� ��";
                id.Focus();
                id.SelectAll();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        /// <summary>
        /// ���� â �ݱ�
        /// �α׾ƿ� ���� ���� �� �ݱ� �� �������̺� ����
        /// </summary>
        public void DisposeFormsOnLogOut() {
            //�ڿ����� ���
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
        /// �޽��� ������
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
            label_stat.Text = statname + " ��";
            switch (statname)
            {
                case "�ڸ����":
                    pbx_stat.Image = global::Client.Properties.Resources.������;
                    break;

                case "�������� ǥ��":
                    pbx_stat.Image = global::Client.Properties.Resources.�α׾ƿ�;
                    break;

                case "�ٸ��빫��" :
                    pbx_stat.Image = global::Client.Properties.Resources.�ٸ��빫��;
                    break;

                case "��ȭ��" :
                    pbx_stat.Image = global::Client.Properties.Resources.��ȭ��;
                    break;
                    
                case "�¶���":
                    pbx_stat.Image = global::Client.Properties.Resources.�¶���;
                    break;
            }
        }

        private void cbx_pass_save_CheckedChanged(object sender, EventArgs e)
        {
            ConfigHelper.SavePass = cbx_pass_save.Checked;
        }

        /// <summary>
        /// ����ڰ� �ݱ⸦ ������� �������� ó��
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