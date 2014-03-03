using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.Common;
using System.Net;
using WeDoCommon;

namespace Client
{
    public partial class AddMemberForm : Form
    {
        public bool curListOnly = false;
        public bool multipleSelect = true;
        private AddMemberMode mode;
        private MsgrConnection connection;
        private string myId;
        private string myName;
        private string formKey;
        private SetMemberListHandler setMemberList;
        private int formHeight;

        public AddMemberForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 쪽지(메모)/채팅창에서 인원추가시 팝업
        /// 쪽지는 팀별/전체/접속자선택모두 가능
        /// 채팅은 접속자만 가능
        /// 이미 추가된 인원은 보여줌.
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="mode"></param>
        /// <param name="formKey"></param>
        public AddMemberForm(MsgrConnection connection, AddMemberMode mode, string formKey, List<MemberObj> userList, SetMemberListHandler setMemberList)
        {
            InitializeComponent();
            myId = ConfigHelper.Id;
            myName = Members.GetByUserId(myId).Name;
            this.formKey = formKey;
            this.mode = mode;
            this.connection = connection;
            this.setMemberList = setMemberList;
            formHeight = this.Height;
            //대화인 경우 현재 접속자만.
            if (mode == AddMemberMode.OnChatformAdded) {
                this.RadioButtonAll.Enabled = false;
                this.RadioButtonListByTeam.Enabled = false;
                SetTeamMode(false);
                this.RadioButtonConnectedUserOnly.Checked = true;
            }
            SetListBox(userList);
        }

        private void SetTeamMode(bool enable)
        {
            if (ComboBoxTeam.Items.Count > 0)
                ComboBoxTeam.SelectedIndex = 0;

            if (enable)
            {
                PanelTeam.Visible = true;
                PanelMain.Top = PanelTeam.Bottom;
                this.Height = formHeight;
            }
            else
            {
                PanelTeam.Visible = false;
                PanelMain.Top = PanelTeam.Top;
                this.Height = formHeight - PanelTeam.Height;
            }
        }

        #region 컨트롤이벤트처리
        private void ButtonAddUser_Click(object sender, EventArgs e) {
        
            if (ListBoxSource.SelectedItems.Count != 0) {

                List<ListBoxItem> listBoxItemList = new List<ListBoxItem>();
                ListBox.SelectedObjectCollection collection=ListBoxSource.SelectedItems;

                if (!multipleSelect && ListBoxSelected.Items.Count > 0) {
                    MessageBox.Show("사용자선택은 1명만 가능합니다.", "선택초과", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            
                foreach (ListBoxItem member in collection) {
                
                    if (ListBox.NoMatches != ListBoxSelected.FindStringExact(member.Text)) {
                        MessageBox.Show("이미 선택된 사용자 입니다.", "중복선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        ListBoxSelected.Items.Add(member);
                        listBoxItemList.Add(member);
                    }
                }

                foreach (ListBoxItem obj in listBoxItemList)
                {
                    ListBoxSource.Items.Remove(obj);
                }
            }
        }

        private void ButtonRemoveUser_Click(object sender, EventArgs e)
        {

            List<ListBoxItem> listBoxItemList = new List<ListBoxItem>();
            if (ListBoxSelected.SelectedItems.Count != 0)
            {

                foreach (ListBoxItem item in ListBoxSelected.SelectedItems)
                {
                    listBoxItemList.Add(item);
                }

                foreach (ListBoxItem obj in listBoxItemList)
                {
                    ListBoxSource.Items.Add(obj);
                    ListBoxSelected.Items.Remove(obj);
                }
            }
        }

        private void ButtonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// 선택대상목록/선택목록 보여줌
        /// 1.쪽지: 이전 선택목록 무시
        /// </summary>
        /// <param name="userList">이미 선택된 대상자목록</param>
        private void SetListBox(List<MemberObj> userList)
        {
            foreach (MemberObj obj in userList)
            {
                if (obj.Id.Equals("")) continue;
                ListBoxSelected.Items.Add(new ListBoxItem(obj));
            }
            _SetListBoxSource();
        }


        private void _SetListBoxSource()
        {
            List<string> userList;
            if (mode == AddMemberMode.OnMemoReceived) // 전체
                userList = new List<string>(Members.GetMembers().Keys);
            else //로그인사용자만
                userList = new List<string>(Members.GetLoginUsers().Keys);

            foreach (string user in userList)
            {
                MemberObj userObj = Members.GetByUserId(user);
                if (userObj == null || userObj.Id == "")
                    continue;

                ListBoxItem item = new ListBoxItem(userObj);
                if (ListBox.NoMatches == ListBoxSelected.FindStringExact(item.Text))
                    ListBoxSource.Items.Add(item);
            }
        }

        private void RadioButtonConnectedUserOnly_Click(object sender, EventArgs e)
        {
            _DisplayLoginUsers();
        }

        /// <summary>
        /// 쪽지 및 파일 전송 수신자 추가 폼에서 "접속자" 라디오 버튼 클릭시
        /// </summary>
        private void _DisplayLoginUsers()
        {
            try
            {
                SetTeamMode(false);

                ListBoxSource.Items.Clear();

                Dictionary<string, IPEndPoint> loginUsers = Members.GetLoginUsers();

                foreach (var de in loginUsers)
                {
                    if (de.Value != null)
                    {
                        MemberObj userObj = Members.GetByUserId(de.Key.ToString());
                        ListBoxItem item = new ListBoxItem(userObj);
                        if (ListBox.NoMatches == ListBoxSelected.FindStringExact(item.Text))
                        {
                            ListBoxSource.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 팀선택
        /// 쪽지인경우만 해당
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mode == AddMemberMode.OnChatformAdded)
                _RefreshListBoxSource();
            else
                _RefreshListBoxSourceAll();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            List<MemberObj> receiverList = new List<MemberObj>();
            foreach (ListBoxItem item in ListBoxSelected.Items)
            {
                receiverList.Add(item.Tag as MemberObj);
            }
            Invoke(this.setMemberList, receiverList);
            Close();
        }

        /// <summary>
        /// 접속자 명단 다시보기
        /// </summary>
        private void _RefreshListBoxSource()
        {
            try
            {
                string teamname = (String)ComboBoxTeam.SelectedItem;
                if (teamname == "기타")
                    teamname = "";

                Dictionary<string, MemberObj> teamMembers = Members.GetMembersByTeam(teamname);

                ListBoxSource.Items.Clear();
                foreach (var de in teamMembers)
                {
                    //string tempname = (String)de.Value;
                    string tempId = de.Key;
                    if (Members.ContainLoginUserNode(tempId))
                    {
                        //string item = tempname + "(" + tempid + ")";
                        MemberObj userObj = Members.GetByUserId(tempId);
                        ListBoxItem item = new ListBoxItem(userObj);
                        if (ListBox.NoMatches == ListBoxSelected.FindStringExact(item.Text))
                            ListBoxSource.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 비접속자 포함 명단 다시보기
        /// </summary>
        private void _RefreshListBoxSourceAll()
        {
            try
            {
                string teamname = (String)ComboBoxTeam.SelectedItem;
                if (teamname == "기타") teamname = "";

                Dictionary<string, MemberObj> memTable = Members.GetMembersByTeam(teamname);

                ListBoxSource.Items.Clear();
                foreach (var de in memTable)
                {
                    string tempid = (String)de.Key;

                    ListBoxItem item = new ListBoxItem(de.Value);

                    if (ListBox.NoMatches == ListBoxSelected.FindStringExact(item.Text))
                    {
                        ListBoxSource.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 팀목록 재생성
        /// 대상자명단 클리어
        /// </summary>
        private void _DisplayMembersByTeam()
        {
            try
            {
                Logger.info("팀별 보기 선택!");
                SetTeamMode(true);
                ComboBoxTeam.Items.Clear();
                List<string> teamList = Members.GetTeamList();
                foreach (string item in teamList)
                {
                    if (item == "")
                    {
                        ComboBoxTeam.Items.Add("기타");
                    }
                    else
                    {
                        ComboBoxTeam.Items.Add(item);
                    }
                }

                ListBoxSource.Items.Clear();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }

        }

        private void RadioButtonListByTeam_Click(object sender, EventArgs e)
        {
            _DisplayMembersByTeam();
        }

        private void RadioButtonAll_Click(object sender, EventArgs e)
        {
            _DisplayAllMembers();
        }

        /// <summary>
        /// 쪽지 수신자 추가 폼에서 "전체" 라디오 버튼 클릭시
        /// </summary>
        private void _DisplayAllMembers()
        {
            try
            {
                SetTeamMode(false);

                ListBoxSource.Items.Clear();

                Dictionary<string, MemberObj> membersAll = Members.GetMembers();

                foreach (var de in membersAll)
                {

                    if (de.Value != null)
                    {
                        ListBoxItem item = new ListBoxItem(de.Value);
                        if (ListBox.NoMatches == ListBoxSelected.FindStringExact(item.Text))
                        {
                            ListBoxSource.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void _SelectUserInSourceList()
        {
            try
            {
                ListBoxItem additem;
                if (ListBoxSource.SelectedItems.Count != 0)
                {
                    additem = (ListBoxSource.SelectedItem as ListBoxItem);
                    if (ListBoxSelected.FindString(additem.Text) >= 0)
                        MessageBox.Show(this, "이미 선택된 사용자 입니다.", "중복선택", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        ListBoxSelected.Items.Add(additem);
                        ListBoxSource.Items.Remove(additem);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void ListBoxSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _SelectUserInSourceList();
        }
    }

    public enum AddMemberMode
    {
        OnMemoReceived,
        OnChatformAdded,
        OnFileReceived
    }
}