using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Runtime.InteropServices;
using Client.PopUp;
using Client.Common;
using WeDoCommon;

namespace Client {

    public partial class ChatForm : FlashWindowForm {

        private Font userNamePartFont = new Font("굴림", 9.0f, FontStyle.Regular);
        private Color userNamePartColor = Color.DarkSlateGray;
        private Font messagePartFont;
        private Color messagePartColor;

        private Hashtable htUserColorTable = new Hashtable();
        private MsgColor msgColor = new MsgColor();
        
        private string finalPoster;

        private ToolTip toolTip = new ToolTip();
        private ToolTip tipAddChatter = new ToolTip();

        private string formKey;
        private MsgrConnection connection;
        private MiscController miscCtrl;

        private bool isActivated = false;

        /// <param name="chatMsg">chatMsg = d|formkey|id/id/...|name|메시지내용</param>
        public ChatForm(MsgrConnection connection, MiscController miscCtrl,ChatObj chatObj) {
            try {
                InitializeComponent();
                this.connection = connection;
                this.miscCtrl = miscCtrl;
                formKey = chatObj.ChatKey;
                Initialize();
                Logger.info(string.Format("채팅창생성 key[{0}]", formKey));

                //첫번째가 대화메시지 띄운 사람.
                foreach (MemberObj memberObj in chatObj.MemberList)
                {
                    if (!ConfigHelper.Id.Equals(memberObj.Id))
                        SetChatterOnFormOpening(Members.GetByUserId(memberObj.Id));
                }

                //chatForm.WindowState = FormWindowState.Minimized;
                //chatForm.Show();
                this.PostUserMessage(chatObj.UserId, chatObj.UserName, chatObj.Msg);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                MessageBox.Show("화면 초기화중 오류가 발생했습니다.\n 담당자에게 문의하세요.","초기화 오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ChatForm(MsgrConnection connection, MiscController miscCtrl, MemberObj chatterObj)
        {
            try
            {
                InitializeComponent();
                this.connection = connection;
                this.miscCtrl = miscCtrl;
                formKey = ChatUtils.GetFormKey(chatterObj.Id, ConfigHelper.Id);
                Initialize();
                Logger.info(string.Format("채팅창생성 key[{0}]", formKey));
                SetChatterOnFormOpening(chatterObj);//대화창에 참가자 노드 추가(key=id, text=name)
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                MessageBox.Show("화면 초기화중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "초기화 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <param name="chatterList">채팅가능자 조합한 키값(myid/id/id/id..)</param>
        public ChatForm(MsgrConnection connection, MiscController miscCtrl, List<MemberObj> groupList)
        {
            try
            {
                InitializeComponent();
                this.connection = connection;
                this.miscCtrl = miscCtrl;
                List<string> userList = new List<string>();
                foreach (MemberObj userObj in groupList)
                {
                    if (userObj.Status != MsgrUserStatus.LOGOUT)
                        userList.Add(userObj.Id);
                }
                formKey = ChatUtils.GetFormKey(userList, ConfigHelper.Id);
                Initialize();
                Logger.info(string.Format("채팅창생성 key[{0}]", formKey));

                foreach (MemberObj userObj in groupList)
                {
                    if (userObj.Status != MsgrUserStatus.LOGOUT)
                    {
                        SetChatterOnFormOpening(userObj);
                    }
                    else
                    {
                        PostCanNotJoinMessage(userObj.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                MessageBox.Show("화면 초기화중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "초기화 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 채팅창 초기화

        private void Initialize()
        {
            this.chatBox.TextChanged += new EventHandler(chatBox_TextChanged);

            connection.ChatterStatusReceived += ChangeStatusOnChatterStatusReceived;
            connection.ChatMsgAdded += AddMsgOnChatMsgAdded;
            connection.ChatterInvited += AddChatterOnChatterInvited;
            connection.ChatterQuit += DeleteChatterOnChatterQuit;
            connection.MemberStatusReceived += this.ChangeStatusOnChatterStatusReceived;

            StatusLabelChatStatus.Text = "";
            ConfigHelper.Id = ConfigHelper.Id;
            ConfigHelper.Name = Members.GetByUserId(ConfigHelper.Id).Name;
            tipAddChatter.SetToolTip(BtnAddChatter, "대화 상대방 추가");
            SetCustomFont();
            ChatForms.AddForm(formKey, this);
        }

        private void SetCustomFont()
        {
            messagePartColor = ChatUtils.GetCustomColor(ConfigHelper.CustomColor);
            messagePartFont = ChatUtils.GetCustomFont(ConfigHelper.CustomFont);
            txtbox_exam.Font = messagePartFont;
            txtbox_exam.ForeColor = messagePartColor;
        }

        public void SetFormKey(string formKey)
        {
            this.formKey = formKey;
        }

        #endregion

        #region 폼처리메소드

        private void FontChanged(object sender, EventArgs e)
        {
            _ChangeFont();
        }

        private void _ChangeFont()
        {
            try
            {
                Color txtcolor = txtbox_exam.ForeColor;
                Font txtfont = txtbox_exam.Font;
                Logger.info("사용자 폰트/색상 변경 : " + txtcolor.Name + "/" + txtfont.ToString());
                ConfigHelper.SaveFontColor(txtcolor, txtfont);
            }
            catch (Exception ex)
            {
                Logger.error("txtbox_exam_Changed Error : " + ex.ToString());
            }
        }

        private void label_font_Click(object sender, EventArgs e) {
            try {
                FontDialog dialog = new FontDialog();
                
                dialog.Font = txtbox_exam.Font;
                dialog.Color = txtbox_exam.ForeColor;
                dialog.ShowColor = true;

                DialogResult result = dialog.ShowDialog(this);
                
                if (result == DialogResult.OK) {
                    messagePartFont = dialog.Font;
                    messagePartColor = dialog.Color;
                    txtbox_exam.Font = dialog.Font;
                    txtbox_exam.ForeColor = dialog.Color;
                    txtbox_exam.Refresh();
                }
            } catch (Exception ex) {
                Logger.error(ex.ToString());
                MessageBox.Show("화면 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_font_MouseEnter(object sender, EventArgs e) {
            label_font.ForeColor = Color.DarkViolet;
        }

        private void label_font_MouseLeave(object sender, EventArgs e) {
            label_font.ForeColor = Color.Black;
        }

        public void SetForward() {
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.Show();
        }

        private void ChatForm_Activated(object sender, EventArgs e)
        {
            ReBox.Focus();
            isActivated = true;
            Logger.info("ChatForm_Activated");
        }

        private void ChatForm_Deactivate(object sender, EventArgs e)
        {
            isActivated = false;
        }

        public bool IsActivated()
        {
            return isActivated;
        }

        private void ChatForm_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void ChatForm_Enter(object sender, EventArgs e)
        {
            ReBox.Focus();
        }
        #endregion

        #region 메시지 작성 박스 화면처리
        private void ReBox_KeyDown(object sender, KeyEventArgs e) {
            StopFlash();
            if (e.Modifiers == Keys.ControlKey) {
                switch (e.KeyData) {
                    case Keys.C:
                        ReBox.Copy();
                        break;
                    case Keys.P:
                        ReBox.Paste();
                        break;
                    case Keys.X:
                        ReBox.Cut();
                        break;
                    case Keys.A:
                        ReBox.SelectAll();
                        break;
                }
            }
        }

        private void ReBox_MouseClick(object sender, MouseEventArgs e) {
            StopFlash();
        }

        private void ReBox_MouseEnter(object sender, EventArgs e) {
            StopFlash();
        }

        private void ReBox_TextChanged(object sender, EventArgs e) {
            if (ReBox.Lines.Length >= 4)
                ReBox.ScrollBars = ScrollBars.Vertical;
            else
                ReBox.ScrollBars = ScrollBars.None;
        }

        private void ReBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    AddChatMessageOnWritingCompleted();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
                MessageBox.Show("화면 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 오른쪽클릭 팝업
        private void CopyCtrlCToolStripMenuItem1_Click(object sender, EventArgs e) {
            chatBox.Copy();
        }

        private void SelectAllCtrlCToolStripMenuItem1_Click(object sender, EventArgs e) {
            chatBox.SelectAll();
        }

        private void CutCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            ReBox.Cut();
        }

        private void CopyCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            ReBox.Copy();
        }

        private void PasteCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            ReBox.Paste();
        }

        private void SelectAllCtrlCToolStripMenuItem2_Click(object sender, EventArgs e) {
            ReBox.SelectAll();
        }
        #endregion

        #region 메시지 보이기 박스 화면처리
        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.Focused == false && this.ReBox.Focused == false && this.btnSend.Focused == false && chatBox.Focused == false)
                if (!isActivated) DoFlashWindow();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                MessageBox.Show("입력문 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.ControlKey) {
                switch (e.KeyData) {
                    case Keys.C:
                        chatBox.Copy();
                        break;
                    case Keys.A:
                        chatBox.SelectAll();
                        break;
                }
            }
        }
        #endregion

        #region 메시지 작성 화면처리
        private void btnSend_Click(object sender, EventArgs e) {
            try {
                AddChatMessageOnWritingCompleted();
            } catch (Exception exception) {
                Logger.error(exception.ToString());
                MessageBox.Show("화면 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChatForm_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Enter) 
                    AddChatMessageOnWritingCompleted();
            } catch (Exception exception) {
                Logger.error(exception.ToString());
                MessageBox.Show("화면 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddChatter_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.info("상담원추가 폼 키값 생성 :" + this.formKey);
                //로그인사용자만 선택
                 List<MemberObj> chatters = ChatUtils.GetLoggedInMemberFromNodeTag(ChattersTree.Nodes);
                 AddMemberForm addform = new AddMemberForm(connection, AddMemberMode.OnChatformAdded, this.formKey, chatters, AddChatters);
                addform.ShowDialog(this);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        #endregion

        #region 대화자 정보 처리

        private void DeleteChatterOnChatterQuit(object sender, CustomEventArgs e)
        {
            ChatObj chatObj = (ChatObj)e.GetItem;
            if (this.formKey.Equals(chatObj.ChatKey))
            {
                foreach (MemberObj member in chatObj.MemberList)
                    DeleteChatter(member.Id, member.Name);

                string tempFormKey = this.formKey;
                string newFormKey = ChatUtils.GetFormKeyWithMultiUsersAdded(tempFormKey, ConfigHelper.Id, chatObj.MemberList);
                ChatForms.UpdateFormKey(newFormKey, tempFormKey);
            }
        }

        /// <summary>
        /// 채팅초대가 발생할때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChatterOnChatterInvited(object sender, CustomEventArgs e)
        {
            ChatObj chatObj = (ChatObj)e.GetItem;
            if (this.formKey.Equals(chatObj.ChatKey))
            {
                foreach (MemberObj member in chatObj.MemberList)
                    AddChatterToNode(member);

                string tempFormKey = this.formKey;
                string newFormKey = ChatUtils.GetFormKeyWithMultiUsersAdded(tempFormKey, ConfigHelper.Id, chatObj.MemberList);
                ChatForms.UpdateFormKey(newFormKey, tempFormKey);
            }
        }

        /// <summary>
        /// 채팅메시지 수신시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void AddMsgOnChatMsgAdded(object sender, CustomEventArgs e)
        {
            ChatObj chatObj = (ChatObj)e.GetItem;
            if (this.formKey.Equals(chatObj.ChatKey))
                PostUserMessage(chatObj.UserId, chatObj.UserName, chatObj.Msg);
        }
        
        //if (InvokeRequired)
        //    {
        //        DoOnChatMsgAdded handler = new DoOnChatMsgAdded(InvokeOnChatMsgAdded);
        //        this.Invoke(handler, e);
        //    }
        //    else
        //        InvokeOnChatMsgAdded(e);
        //}

        //public delegate void DoOnChatMsgAdded(CustomEventArgs e);

        //protected virtual void InvokeOnChatMsgAdded(CustomEventArgs e)
        //{
        //}

        public void SetChatterOnFormOpening(MemberObj userObj)
        {
            if (userObj == null || userObj.Id == null
                || userObj.Id.Trim() == "" || userObj.Id.Trim() == ConfigHelper.Id)
                return;
            _AddChatter(userObj);
        }


        public string GetFormKey() {
            return this.formKey;
        }

        //public List<MemberObj> GetChattersID()
        //{
        //    List<MemberObj> chatters = new List<MemberObj>();
        //    try {
        //        chatters = ChatUtils.GetLoggedInMemberFromNodeTag(ChattersTree.Nodes);
        //    } catch (Exception exception) {
        //        Logger.error(exception.ToString());
        //        MessageBox.Show("화면 처리중 오류가 발생했습니다.\n 담당자에게 문의하세요.", "처리 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return chatters;
        //}

        public bool ContainsId(string id) {
            TreeNode[] nodeArray = ChattersTree.Nodes.Find(id, false);
            return (nodeArray != null && nodeArray.Length > 0);
        }

        private void _AddNextChatter(MemberObj userObj) {
            if (userObj == null || userObj.Id == null
                || userObj.Id.Trim() == "" || userObj.Id.Trim() == ConfigHelper.Id)
                return;
            _AddChatter(userObj);
            PostUserJoinMessage(userObj.Name);
        }

        /// <summary>
        /// 1. 노드 추가
        /// 2. 창타이틀에 이름 반영
        /// 3. 색깔반영
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private void _AddChatter(MemberObj userObj) {

            TreeNode node = ChattersTree.Nodes.Add(userObj.Id, userObj.Title + "(" + userObj.Id + ")");
            node.Tag = userObj;
            //node.ImageIndex = 0;
            //node.SelectedImageIndex = 0;
            node.BackColor = Color.FromArgb(205, 220, 237);
            if (ChattersTree.Nodes.Count == 1)
                this.Text += userObj.Name;
            else
                this.Text += "/" + userObj.Name;
            //채팅참여했다가 나간후 다시 참여한 경우, 원래 색을 그대로 쓴다.
            if (!htUserColorTable.Contains(userObj.Id)) {
                htUserColorTable.Add(userObj.Id, msgColor.GetColor(ChattersTree.Nodes.Count));
            }
            //상태지정
            SetChatterStatus(userObj.Id, userObj.Name, userObj.Status);
        }

        /// <summary>
        /// 다자간 채팅중 대화창을 닫은 구성원을 알림
        /// </summary>
        /// <param name="id"></param>
        public void DeleteChatter(string id, string name) {
            TreeNode[] node = ChattersTree.Nodes.Find(id, false);
            string message = string.Format("{0}님이 창을 닫고 대화를 종료하였습니다.\r\n", node[0].Text);
            AddMessage(message);
            node[0].Remove();

            this.Text = ChatUtils.RemoveFromTitle(this.Text, name);
        }

        public void AddChatters(List<MemberObj> addedUserList)
        {
            List<MemberObj> joinedChatterList = ChatUtils.GetLoggedInMemberFromNodeTag(ChattersTree.Nodes);
            string addlist = ChatUtils.GetLoggedInMemberList(joinedChatterList);
            
            //추가한 사용자 리스트 기존 대화자에게 전송
            foreach (MemberObj memberObj in joinedChatterList)
                connection.SendMsgNotifyAddedUsers(formKey, addlist, memberObj.Id);

            //추가한 사용자 채팅창의 대화자 리스트에 추가
            foreach (MemberObj memberObj in addedUserList)
                AddChatterToNode(memberObj);

            //채팅창 폼키에 대화자리스트 반영
            string newFormKey = ChatUtils.GetFormKeyWithMultiUsersAdded(formKey, ConfigHelper.Id, addlist);
            ChatForms.UpdateFormKey(newFormKey, formKey);
        }

        /// <summary>
        /// 트리노드에 대화자 노드 추가
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="name">user name</param>
        public void AddChatterToNode(MemberObj userObj) {
            if (userObj == null || userObj.Id == null
                || userObj.Id.Trim() == "" || userObj.Id.Trim() == ConfigHelper.Id)
                return;

            TreeNode[] nodearray = ChattersTree.Nodes.Find(userObj.Id, false);

            if (nodearray != null && nodearray.Length != 0) {
                //있는경우는 오류
                Logger.error(string.Format("AddChatterToNode:{0}({1})이 이미 존재함.", userObj.Name, userObj.Id));
                //throw new Exception("대화자 노드처리 오류");
            } else {
                _AddNextChatter(userObj);
            }
        }

        public void SetChatterStatus(string userId, string userName, string status) {
            TreeNode[] nodearray = ChattersTree.Nodes.Find(userId, false);

            if (nodearray != null && nodearray.Length != 0) {
                if (nodearray.Length > 1)
                {
                    Logger.error(string.Format("채팅창에 참여한 {0}이 하나이상 존재.", userId));
                    throw new Exception("채팅창 대화자처리 오류");
                }
                
                TreeNode anode = nodearray[0];
                try {
                    MemberObj userObj = (MemberObj)anode.Tag;
                    if (userId.Equals(userObj.Id)) {

                        switch (status) {
                            case MsgrUserStatus.ONLINE://"online":
                                anode.ImageIndex = 0;
                                anode.SelectedImageIndex = 0;
                                anode.ForeColor = Color.Black;
                                break;
                            case MsgrUserStatus.LOGOUT://"logout":
                                anode.ImageIndex = 1;
                                anode.SelectedImageIndex = 1;
                                anode.ForeColor = Color.Gray;
                                break;
                            case MsgrUserStatus.BUSY://"busy":
                                anode.ImageIndex = 2;
                                anode.SelectedImageIndex = 2;
                                anode.ForeColor = Color.Black;
                                break;
                            case MsgrUserStatus.DND://"DND":
                                anode.ImageIndex = 3;
                                anode.SelectedImageIndex = 3;
                                anode.ForeColor = Color.Black;
                                break;
                            case MsgrUserStatus.AWAY://"away":
                                anode.ImageIndex = 4;
                                anode.SelectedImageIndex = 4;
                                anode.ForeColor = Color.Black;
                                break;
                        }
                        userObj.Status = status;
                        anode.Text = string.Format("{0}({1})", userObj.Title, userId);
                        anode.Tag = userObj; //userId + CommonDef.CHAT_USER_LOG_IN;
                    }
                } catch (Exception ex) {
                    Logger.error(ex.ToString());
                    throw new Exception("대화자 상태정보 처리 오류");
                }
            }
        }

        /// <summary>
        /// 경우: 1:1, 다자대화
        /// 1. 로그아웃메시지 표시
        /// 2. 노드 로그아웃표시
        /// 3. 1:1인경우 창 비활성화시킴
        /// 
        /// 다자창의 경우는 LogOut이전에 Quit이 먼저발생하나, 예외상황을 감안함.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void SetChatterLogOut(string userId, string userName) {

            TreeNode[] node = ChattersTree.Nodes.Find(userId, false);

            if (node != null && node.Length != 0 ) {
                //메시지 표시
                AddMessage(string.Format("{0}님이 로그아웃하셨습니다.\r\n", userName));
                //노드에 로그아웃으로 표시함
                SetChatterStatus(userId, userName, MsgrUserStatus.LOGOUT);
                Logger.info(string.Format("{0}({1})를 로그아웃 처리.", userName, userId));
                //1:1 인 경우
                if (this.HasSingleChatter()) {
                    ReBox.Enabled = false;
                    toolTip.SetToolTip(ReBox, string.Format("{0}님이 로그아웃하셨습니다.\r\n", userName));
                }
            }
        }

        /// <summary>
        /// 1:1창에서 out->in인 경우만 해당
        /// 다자창에서 busy/dnd/away->in인 경우만 해당
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void SetChatterLogIn(string userId, string userName) {

            TreeNode[] node = ChattersTree.Nodes.Find(userId, false);

            if ( node != null && node.Length != 0 ) {
                //메시지 표시
                if (this.HasSingleChatter()) {//다자창에서는 필요없음
                    AddMessage(string.Format("{0}님이 로그인하셨습니다.\r\n", userName));
                    ReBox.Enabled = true;
                    toolTip.RemoveAll();
                    ReBox.Focus();
                }
                //노드에 로그인으로 표시함
                SetChatterStatus(userId, userName, MsgrUserStatus.ONLINE);
                Logger.info(string.Format("{0}({1})를 로그인 처리.", userName, userId));
            }
        }

        /// <summary>
        /// ___________1:1창__________다자창_______
        /// 
        /// on   | key(out->in)      key변경없음
        ///        노드상태변경      노드상태변경
        /// 
        /// out  | key(in->out)      quit처리(**비정상종료로 quit없이 아웃됨)
        ///        노드상태변경
        ///        메시지display
        /// 
        /// busy | key변경없음       key변경없음
        ///        노드상태변경      노드상태변경
        /// 
        /// away |     동일
        /// 
        /// dnd  |     동일
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void ChangeStatusOnChatterStatusReceived(object sender, CustomEventArgs e)
        {
            try {
                MemberObj memberObj = (MemberObj)e.GetItem;
                if (this.formKey.Contains(ConfigHelper.Id))
                {
                    switch (memberObj.Status)
                    {
                        case MsgrUserStatus.ONLINE:
                            //1:1채팅인 경우만
                            if (HasSingleChatter())
                            {
                                //1.키변경
                                string newFormKey = ChatUtils.GetFormKeyWithUserAdded(formKey, ConfigHelper.Id, memberObj.Id);
                                ChatForms.UpdateFormKey(newFormKey, formKey);
                                //2.노드상태변경
                                //3.메시지디스플레이
                                SetChatterLogIn(memberObj.Id, Members.GetByUserId(memberObj.Id).Name);
                            }
                            else
                            {//다자창
                                //1.키변경없음
                                //2.노드상태변경
                                SetChatterLogIn(memberObj.Id, Members.GetByUserId(memberObj.Id).Name);
                            }
                            break;
                        case MsgrUserStatus.LOGOUT:
                            //1:1채팅인 경우만
                            if (HasSingleChatter())
                            {
                                //1.키변경
                                string newFormKey = ChatUtils.GetFormKeyWithUserLogOut(formKey, ConfigHelper.Id, memberObj.Id);
                                ChatForms.UpdateFormKey(newFormKey, formKey);
                                //2.노드상태변경
                                //3.메시지디스플레이
                                SetChatterLogOut(memberObj.Id, Members.GetByUserId(memberObj.Id).Name);
                            }
                            else
                            {//다자창
                                //quit처리
                                //  1.키변경
                                string newFormKey = ChatUtils.GetFormKeyWithUserQuit(formKey, ConfigHelper.Id, memberObj.Id);
                                ChatForms.UpdateFormKey(newFormKey, formKey);
                                //  2. 노드삭제
                                DeleteChatter(memberObj.Id, Members.GetByUserId(memberObj.Id).Name);
                            }
                            break;
                        case MsgrUserStatus.BUSY:
                        case MsgrUserStatus.AWAY:
                        case MsgrUserStatus.DND:
                            //노드상태변경
                            SetChatterStatus(memberObj.Id, Members.GetByUserId(memberObj.Id).Name, memberObj.Status);
                            break;
                    }
                }
            } catch (Exception exception) {
                Logger.error(exception.ToString());
            }
        }

        #endregion

        #region 메시지 처리 유틸함수
        private void AddChatMessageOnWritingCompleted()
        {
            string str = null;

            if (ReBox.Text.Trim().Length != 0)
            {

                if (this.ChattersTree.Nodes.Count == 0)
                {//채팅참가자 리스트뷰에 참가자가 없다면

                    MessageBox.Show("대화 상대방이 없습니다.\r\n대화할 상대방을 추가해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.info("ChattersTree 에 대화상대방 없음");
                }
                else
                {//채팅참가자가 있을 경우만
                    string ids = ConfigHelper.Id;

                    foreach (TreeNode node in ChattersTree.Nodes)
                    {
                        ids += "/" + (node.Tag as MemberObj).Id;
                    }

                    //d|Formkey|id/id/..|발신자name|메시지 

                    connection.SendMsgUserChatMsg(formKey, ids, ReBox.Text.Trim());

                    this.PostMyMessage(ConfigHelper.Name, ReBox.Text.Trim());

                    ReBox.Clear();
                    ReBox.Focus();
                }
            }
        }


        private void AddMessage(string msg)
        {
            chatBox.AppendText(msg + "\r\n");
            chatBox.ScrollToCaret();
            if (isActivated) ReBox.Focus();
        }
        
        public void PostCanNotJoinMessage(string userName) {
            AddMessage(userName + " 님은 대화가 불가능한 상태이므로 참가하지 못했습니다.\r\n");
        }

        public void PostUserJoinMessage(string userName) {
            AddMessage(userName + "님을 대화에 초대하였습니다.\r\n");
        }

        public void PostMyMessage(string myName, string message) {
            PostChatMessage(ConfigHelper.Id, ConfigHelper.Name, message, true);
        }

        public void PostUserMessage(string userId, string userName, string message)
        {
            PostChatMessage(userId, userName, message, false);
        }
        public void PostChatMessage(string userId, string userName, string message, bool isMine)
        {
            int startPos = 0;
            //이전 메시지올린사람과 동일인 경우, 생략.
            if (finalPoster != userName) {
                string msgUserName = userName + " 님의 말 :";
                startPos = chatBox.Text.Length;
                AddMessage(msgUserName);
                chatBox.Select(startPos, msgUserName.Length);
                chatBox.SelectionFont = this.userNamePartFont;
                chatBox.SelectionColor = this.userNamePartColor;
                chatBox.ScrollToCaret();
            }

            string msgMain = "ㆍ  " + message;
            startPos = chatBox.Text.Length;
            AddMessage(msgMain);
            if (isMine) {
                chatBox.Select(startPos, msgMain.Length);
                chatBox.SelectionFont = this.messagePartFont;
                chatBox.SelectionColor = this.messagePartColor;
            } else {
                chatBox.Select(startPos, msgMain.Length);
                chatBox.SelectionColor = (Color)htUserColorTable[userId];
            }
            chatBox.ScrollToCaret();

            finalPoster = userName;

            if (!isMine) {
                StatusLabelChatStatus.Text = "마지막 메시지를 받은 시간:" + DateTime.Now.ToString();
            }
            if (isActivated) ReBox.Focus();
        }

        public bool HasSingleChatter()
        {
            return (ChattersTree.Nodes.Count == 1);
        }

        #endregion

        /// <summary>
        /// 대화창에서 파일보내기 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chatSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChattersTree.Nodes.Count == 0)
                {//채팅참가자 리스트뷰에 참가자가 없다면
                    MessageBox.Show("파일전송을 할 대상자가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.info("ChattersTree 에 파일수신 상대방 없음");
                }

                string fileName = null;
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;

                    foreach (TreeNode node in ChattersTree.Nodes)
                    {
                        MemberObj userObj = (MemberObj)node.Tag;
                        if (userObj.Status != MsgrUserStatus.LOGOUT)
                        {
                            SendFileForm sendform = new SendFileForm(connection, userObj, fileName);
                            sendform.Show();
                            sendform.Activate();
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                miscCtrl.WriteDialogSaveFile(formKey, chatBox.Text, this.Text);

                if (ChattersTree.Nodes.Count > 1)
                {                     //2명이상과 대화중 폼을 닫을 경우
                    foreach (TreeNode node in ChattersTree.Nodes)
                    {
                        MemberObj userObj = (MemberObj)node.Tag;

                        if (!ConfigHelper.Id.Equals(userObj.Id))
                        { //자신 빼고 전송
                            Logger.info("대화종료 메시지 생성:상대방 id : " + userObj.Id);
                            connection.SendMsgNotifyChatFormClosed(formKey, userObj.Id);
                        }
                    }
                }

                ChatForms.RemoveForm(formKey);
                Logger.info("채팅창 닫음으로 key=" + formKey + " ChatterList 테이블에서 삭제");

                connection.ChatterStatusReceived -= ChangeStatusOnChatterStatusReceived;
                connection.ChatMsgAdded -= AddMsgOnChatMsgAdded;
                connection.ChatterInvited -= AddChatterOnChatterInvited;
                connection.ChatterQuit -= DeleteChatterOnChatterQuit;
                connection.MemberStatusReceived -= this.ChangeStatusOnChatterStatusReceived;
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

    }
}