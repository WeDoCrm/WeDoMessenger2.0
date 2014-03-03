using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Common;
using System.Windows.Forms;
using WeDoCommon;
using WeDoCommon.Sockets;

namespace Client
{
    /// <summary>
    /// 메인창 클래스의 FTP 처리.
    /// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
 
        //수락여부 확인 플로우로 넘김
        //1.수락
        //      FTP_ShowDialog(Hashtable info);
        //                 form.ShowDialog(Hashtable info);
        //          event FTP_DialogResultReceived(CustomEvent);
        //2-1.거부
        //2-2.종료
        //          event FTP_StatusChanged
        //                  
        //2.수락메시지전송
        //      
        //3.수신대기 
        //      FileReceiver
        //4.수신
        //      FTP_ShowStatus(Receive|Cancel|Done|Error)
        //              form.ShowStatus(Hashtable info);
        //5.완료
        //      FTP_StopReceiving()
        //6.취소
        //      FTP_CancelReceiving()
        //7.실패
        //     

        public void ShowDownloadFormOnFTPInfoReceived(object sender, SocFTPInfoEventArgs<FTPRcvObj> e)
        {
            //call DownloadForm
            DownloadForm frm = new DownloadForm(this.connection, e.GetObj);
            frm.Show();
        }

        private void MakeSendFileForm(List<MemberObj> userList)//key=id, value=name
        {
            try
            {
                foreach (MemberObj user in userList)
                {
                    SendFileForm sendform = new SendFileForm(connection, user);
                    sendform.Show();
                    sendform.Activate();
                }
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private void MakeSendFileForm(MemberObj userObj)//key=id, value=name
        {
            try
            {
                SendFileForm sendform = new SendFileForm(connection, userObj);
                sendform.Show();
                sendform.Activate();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private void MakeSendFileForm(MemberObj userObj, string fileName)//key=id, value=name
        {
            try
            {
                SendFileForm sendform = new SendFileForm(connection, userObj, fileName);
                sendform.Show();
                sendform.Activate();
            }
            catch (Exception e)
            {
                Logger.error(e.ToString());
            }
        }

        private string _OpenSendFileFormBySelectedNode(TreeNode node, string fileName)
        {
            string invalidList = "";
            MemberObj userObj = (MemberObj)node.Tag;
            if (userObj.Status != MsgrUserStatus.LOGOUT)
                MakeSendFileForm(userObj, fileName);
            else
                invalidList = string.Format(",{0}({1})", userObj.Name, userObj.Id);

            return invalidList;
        }

        private void OpenSendFileFormBySelectedNode()
        {
            List<MemberObj> receiverList = new List<MemberObj>();
            try
            {
                if (memTree.SelectedNode == null)
                {
                    MessageBox.Show("파일을 보낼 상대방을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.info("ChattersTree 에 파일수신 상대방 없음");
                }
                else
                {
                    if (memTree.SelectedNode.GetNodeCount(true) != 0)
                    {
                        string fileName = null;
                        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                        {
                            fileName = openFileDialog.FileName;
                            string invalidList = "";
                            foreach (TreeNode node in memTree.SelectedNode.Nodes)
                                invalidList += _OpenSendFileFormBySelectedNode(node, fileName);
                            if (!invalidList.Equals(""))
                            {
                                MessageBox.Show(string.Format("{0}님은 로그아웃상태입니다. 파일을 보낼수 없습니다.", invalidList.Substring(1)), "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Logger.info("파일전송불가: " + invalidList);
                            }
                        }
                    }
                    else
                    {
                        string invalidUser = _OpenSendFileFormBySelectedNode(memTree.SelectedNode, null);
                        if (!invalidUser.Equals(""))
                        {
                            MessageBox.Show(string.Format("{0}님은 로그아웃상태입니다. 파일을 보낼수 없습니다.", invalidUser.Substring(1)), "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Logger.info("파일전송불가: " + invalidUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }

        }

        private void OpenSendFileFormBySelectedNode(string fileName)
        {
            List<MemberObj> receiverList = new List<MemberObj>();
            try
            {
                if (memTree.SelectedNode == null)
                {
                    MessageBox.Show("파일을 보낼 상대방을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.info("ChattersTree 에 파일수신 상대방 없음");
                }
                else
                {
                    if (memTree.SelectedNode.GetNodeCount(true) != 0)
                    {
                        string invalidList = "";
                        foreach (TreeNode node in memTree.SelectedNode.Nodes)
                            invalidList += _OpenSendFileFormBySelectedNode(node, fileName);
                        if (invalidList != null && !invalidList.Equals(""))
                        {
                            MessageBox.Show(string.Format("{0}님은 로그아웃상태입니다. 파일을 보낼수 없습니다.", invalidList.Substring(1)), "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Logger.info("파일전송불가: " + invalidList);
                        }
                    }
                    else
                    {
                        string invalidUser = _OpenSendFileFormBySelectedNode(memTree.SelectedNode, fileName);
                        if (invalidUser != null && !invalidUser.Equals(""))
                        {
                            MessageBox.Show(string.Format("{0}님은 로그아웃상태입니다. 파일을 보낼수 없습니다.", invalidUser.Substring(1)), "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Logger.info("파일전송불가: " + invalidUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }

        }

        #region 파일전송 팝업창관련
        /// <summary>
        /// 상단메뉴 파일보내기버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnSendFile_Click(object sender, EventArgs e)
        {
            OpenSendFileFormBySelectedNode();
        }

        /// <summary>
        /// 트리에서 1명의 사용자를 선택후 팝업메뉴: 파일 전송
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripMn_file_Click(object sender, EventArgs e)
        {
            OpenSendFileFormBySelectedNode();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripMn_gfile_Click(object sender, EventArgs e)
        {
            OpenSendFileFormBySelectedNode();
        }
        #endregion
    }
}