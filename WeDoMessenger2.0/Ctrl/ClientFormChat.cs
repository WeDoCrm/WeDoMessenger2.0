using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Common;
using System.Windows.Forms;
using WeDoCommon;

namespace Client
{
    /// <summary>
    /// 메인창 클래스의 채팅관련 처리.
    /// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
        public void OpenSingleChatForm(MemberObj userObj)
        {
            if (userObj != null && Members.ContainLoginUserNode(userObj.Id))
            {
                ChatForm chatForm = ChatForms.FindSingleChatForm(userObj.Id);
                //존재하는 대화창이 없는 경우 생성
                if (chatForm == null)
                {
                    MakeChatForm(userObj);
                }
                else
                {
                    chatForm.SetForward();
                }

            }
            else  //대화가능한 상대방이 없을경우
            {
                if (MessageBox.Show(this,
                                    "대화할 상대방이 대화가 불가능한 상태입니다.\r\n 대신 쪽지를 보내시겠습니까?", 
                                    "알림", 
                                    MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Information) == DialogResult.OK)
                    MakeSendMemo(userObj);
            }

        }

        /// <summary>
        /// 새로운 대화메시지 수신시 대화창 생성
        /// </summary>
        /// <param name="ar">d|formkey|id/id/...|name|메시지내용</param>
        private void OpenNewChatFormOnMsgReceived(object sender, CustomEventArgs e)    //ar = d|formkey|id/id/...|name|메시지내용
        {
            try
            {
                ChatObj chatObj = (ChatObj)e.GetItem;
                ChatForm chatForm = new ChatForm(connection, miscCtrl, chatObj);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }


        /// <summary>
        /// 사용자가 대화하기를 선택시 대화창 생성
        /// </summary>
        /// <param name="chatter"></param>
        /// <param name="ids"></param>
        private void MakeChatForm(MemberObj userObj)
        {
            try
            {
                if (userObj.Id == null || userObj.Id == "")
                    return;
                ChatForm chatForm = new ChatForm(connection, miscCtrl, userObj);
                chatForm.Show();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 사용자가 다수의 상대방과 대화하기를 요청했을 경우 대화창 생성
        /// </summary>
        /// <param name="groupList">대화선택목록</param>
        /// <param name="chatIdList">대화가능자 조합 키값(myid/id/id..)</param>
        private void MakeChatForm(List<MemberObj> groupList, string chatIdList)
        {
            try
            {
                ChatForm chatForm = new ChatForm(connection, miscCtrl, groupList);
                chatForm.Show();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }

        }

        /// <summary>
        /// 대화하기 메뉴를 클릭한 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chat_Click(object sender, EventArgs e)
        {
            try
            {
                if (memTree.SelectedNode.GetNodeCount(false) != 0)//선택한 노드가 하위 노드를 가지고 있을 경우
                {
                    Logger.info("그룹대화 요청!");
                    List<MemberObj> groupList = new List<MemberObj>();//대화선택목록
                    int chattable = 0;
                    string chatIdList = ConfigHelper.Id;  //채팅가능자

                    foreach (TreeNode node in memTree.SelectedNode.Nodes)
                    {
                        MemberObj userObj = (MemberObj)node.Tag;
                        if (userObj == null)
                            continue;
                        if (userObj.Status != MsgrUserStatus.LOGOUT)
                        {
                            chattable++;
                            chatIdList = "/" + userObj.Id;
                        }
                        groupList.Add(userObj);
                    }

                    if (chattable == 0) //대화가능한 상대방이 없을경우
                    {
                        DialogResult result = MessageBox.Show(this, "요청한 상대방 모두가 대화가 불가능한 상태입니다.\r\n 대신 쪽지를 보내시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            OpenSendMemoBySelectedNode();//쪽지보내기
                        }
                    }
                    else if (chattable == 1)
                    {
                        MemberObj userObj = (MemberObj)groupList[0];
                        Logger.info("대화선택:" + userObj.Id);
                        OpenSingleChatForm(userObj);
                    }
                    else
                        MakeChatForm(groupList, chatIdList);
                }
                else //선택한 노드가 최하위 노드인 경우
                {
                    Logger.info("일대일대화 요청");
                    MemberObj userObj = (MemberObj)memTree.SelectedNode.Tag;
                    OpenSingleChatForm(userObj);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 우클릭시 팀노드 선택한경우 팀팝업메뉴, 이외의 경우 접속시 대화메뉴, 오프라인시 쪽지메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                memTree.SelectedNode = e.Node;

                if (e.Button == MouseButtons.Right)
                {

                    if (e.Node.GetNodeCount(false) != 0)
                    {
                        mouseMenuG.Show(memTree, e.Location, ToolStripDropDownDirection.BelowRight);
                    }
                    else
                    {
                        //if (InList.ContainsKey(e.Node.Tag)) { //접속한 경우
                        if (((MemberObj)e.Node.Tag).Status != MsgrUserStatus.LOGOUT)
                        {
                            mouseMenuN.Show(memTree, e.Location, ToolStripDropDownDirection.BelowRight);
                        }
                        else
                        {
                            mouseMenuC.Show(memTree, e.Location, ToolStripDropDownDirection.BelowRight);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }


        private void memTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (memTree.SelectedNode.GetNodeCount(true) == 0)
                { //팀원 노드 선택                    
                    MemberObj userObj = (MemberObj)e.Node.Tag;
                    Logger.info("대화선택:" + userObj.Id);
                    OpenSingleChatForm(userObj);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// memTree에 로그인 클라이언트 노드 추가
        /// </summary>
        /// <param name="tempMsg">i|id|소속|클라이언트 IP주소|이름</param>
        //private void AddMemTreeNode(string[] tempMsg)//i|id|소속|address|이름
        //{
        //    try
        //    {
        //        TreeNode[] nodeArray = memTree.Nodes.Find(tempMsg[2], true);
        //        if (!nodeArray[0].Nodes.ContainsKey(tempMsg[1]))
        //        {
        //            TreeNode tempNode = nodeArray[0].Nodes.Add(tempMsg[1], tempMsg[4]);
        //            tempNode.ToolTipText = tempMsg[1]; //MouseOver일 경우 나타남 
        //            tempNode.Tag = new MemberObj(tempMsg[1], tempMsg[4], MsgrUserStatus.ONLINE);
        //            tempNode.ImageIndex = 1;
        //            tempNode.SelectedImageIndex = 1;
        //            nodeArray[0].Expand();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.error(exception.ToString());
        //    }
        //}
    }
}
