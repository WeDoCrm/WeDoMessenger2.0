using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.PopUp;
using Client.Common;
using WeDoCommon;

namespace Client
{
    public partial class SendMemoForm: TopMostForm
    {
        ToolTip tip = new ToolTip();
        MsgrConnection connection;
        string formKey;
        public string FormKey { get { return formKey; } }

        List<MemberObj> receiverList = new List<MemberObj>();

        public SendMemoForm(MsgrConnection connection, List<MemberObj> receiverList)
        {
            InitializeComponent();
            this.connection = connection;
            this.receiverList = receiverList;
            Initialize();
        }

        public SendMemoForm(MsgrConnection connection, MemberObj userObj)
        {
            InitializeComponent();
            this.connection = connection;
            if (userObj != null)
                this.receiverList.Add(userObj);
            Initialize();
        }

        public SendMemoForm(MsgrConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            Initialize();
        }

        public void Initialize()
        {
            this.formKey = DateTime.Now.ToString();
            tip = new ToolTip();
            tip.ToolTipIcon = ToolTipIcon.Info;
            tip.ToolTipTitle = "< 받는사람 >";

            foreach (MemberObj userObj in receiverList)
                txtbox_receiver.Text += userObj.Name + "(" + userObj.Id + ");";

            SendMemoForms.AddForm(formKey, this);
            Logger.info("쪽지전송 리스트 생성 : " + txtbox_receiver.Text);
        }


        /// <summary>
        /// 메모수신자목록을 설정
        /// </summary>
        public void SetMemoReceivers(List<MemberObj> receivers)
        {
            if (receivers != null && receivers.Count > 0)
            {
                receiverList.Clear();
                txtbox_receiver.Clear();
                foreach (MemberObj userObj in receivers)
                {
                    receiverList.Add(userObj);
                    txtbox_receiver.Text += string.Format("{0}({1});", userObj.Name, userObj.Id);
                }
            }
            else
            {
                Logger.error("SetMemoReceivers:invalid receivers");
            }
            BtnSend.Enabled = (receiverList.Count > 0);
        }

        private void txtbox_receiver_MouseEnter(object sender, EventArgs e)
        {
            tip.Show(txtbox_receiver.Text, txtbox_receiver, txtbox_receiver.Location);
        }

        private void txtbox_receiver_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(txtbox_receiver);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Lines.Length >= 13)
            {
                textBox1.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                textBox1.ScrollBars = ScrollBars.None;
            }
        }

        private void BtnReceiver_Click(object sender, EventArgs e)
        {
            try
            {
                AddMemberForm addform = new AddMemberForm(connection, AddMemberMode.OnMemoReceived, formKey, receiverList, SetMemoReceivers);
                addform.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void SendMemoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SendMemoForms.RemoveForm(formKey);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_receiver.Text.Length != 0)
                {
                    string memoContent = textBox1.Text.Trim();
                    if (memoContent.Length != 0)
                    {
                        foreach (MemberObj userObj in receiverList)
                        {
                            MemoObj memoObj = new MemoObj(ConfigHelper.Id, userObj.Id, memoContent);

                            if (Members.ContainLoginUserNode(userObj.Id))
                                connection.SendMsgDeliverMemo(memoObj);
                            else
                                connection.SendMsgSaveMemoOnAway(memoObj);
                            Logger.info("쪽지 메시지 생성 : " + memoObj.ToString());
                        }
                        Close();
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "쪽지를 받을 상대방을 지정해 주세요"
                                        , "알림", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        AddMemberForm addform = new AddMemberForm(connection, AddMemberMode.OnMemoReceived, formKey, receiverList, SetMemoReceivers);
                        addform.ShowDialog(this);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void SendMemoForm_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

    }
}