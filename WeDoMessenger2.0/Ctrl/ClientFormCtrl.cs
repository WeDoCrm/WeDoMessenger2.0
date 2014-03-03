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
    /// 메인창 클래스의 이벤트 처리.
    /// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
        private void Mn_default_Click(object sender, EventArgs e)
        {
            miscCtrl.DisplaySetAutoStartForm();
        }

        private void Mn_server_Click(object sender, EventArgs e)
        {
            ctrlParamDel dele = new ctrlParamDel(miscCtrl.DisplaySetServerForm);
            Invoke(dele);
        }

        private void Mn_notify_dispose_Click(object sender, EventArgs e)
        {
            ExitMessenger();
        }

        private void Mn_notify_show_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Activate();
        }

        private void MnFile_MouseClick(object sender, MouseEventArgs e)
        {
            TM_file_sub.Show(new Point((this.Left), (this.Top + 48)), ToolStripDropDownDirection.BelowRight);
        }

        private void MnMotion_MouseClick(object sender, MouseEventArgs e)
        {
            TM_motion_sub.Show(new Point((this.Left + 60), (this.Top + 48)), ToolStripDropDownDirection.BelowRight);
        }

        private void MnOption_MouseClick(object sender, MouseEventArgs e)
        {
            TM_option_sub.Show(new Point((this.Left + 120), (this.Top + 48)), ToolStripDropDownDirection.BelowRight);
        }

        private void MnHelp_MouseClick(object sender, MouseEventArgs e)
        {
            TM_help_sub.Show(new Point((this.Left + 180), (this.Top + 48)), ToolStripDropDownDirection.BelowRight);
        }

        private void btn_crm_MouseClick(object sender, MouseEventArgs e)
        {
            CrmHelper.ShowCrmOnClick();
        }

        /// <summary>
        /// 공지게시판 조회
        /// </summary>
        private void btn_board_MouseClick(object sender, MouseEventArgs e)
        {
            connection.SendMsgRequestNoticeListAll();
        }

        private void btn_memobox_MouseClick(object sender, MouseEventArgs e)
        {
            MakeMemoList();
        }

        private void btn_dialoguebox_MouseClick(object sender, MouseEventArgs e)
        {
            miscCtrl.DisplayDialogList();//MakeDialogueboxList();
        }

        private void btn_sendnotice_MouseClick(object sender, MouseEventArgs e)
        {
            MakeSendNotice();
        }

        private void btn_resultnotice_MouseClick(object sender, MouseEventArgs e)
        {
            MakeNoticeResultList();
        }

        private void btn_login_MouseClick(object sender, MouseEventArgs e)
        {
            NoParamDele dele = new NoParamDele(ProcessLogin);
            Invoke(dele);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start(ConfigHelper.PromotionUrl);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            tooltip.Show("재민정보통신 홈페이지로 바로가기", pictureBox2, 3000);
        }

        #region 안읽은 건수(메모, 공지, 파일, 이관)
        /// <summary>
        /// 안읽은 메모 요청
        /// </summary>
        private void NRmemo_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (!NRmemo.Text.Equals("0"))
                {
                    if (noreceiveboardform == null)
                        connection.SendMsgReqUnReadMemo();
                    else
                        noreceiveboardform.Show();
                }
                else
                    MessageBox.Show("부재중 등록된 메모가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 안읽은 공지 요청(11|id)
        /// </summary>
        private void pic_NRnotice_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!NRnotice.Text.Equals("0"))
                {
                    if (noreceiveboardform == null)
                        connection.SendMsgReqUnReadNotice();
                    else
                        noreceiveboardform.Show();
                }
                else
                    MessageBox.Show("부재중 등록된 공지가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 안받은 파일 요청
        /// </summary>
        private void pic_NRfile_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (!NRfile.Text.Equals("0"))
            //    {
            //        if (noreceiveboardform == null)
            //            connection.SendMsgReqUnReadFile();
            //        else
            //            noreceiveboardform.Show();
            //    }
            //    else
            //        MessageBox.Show("부재중 수신된 파일내역이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception exception)
            //{
            //    Logger.error(exception.ToString());
            //}
        }
        /// <summary>
        /// 안읽은 이관 요청
        /// </summary>
        private void pic_NRtrans_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!NRtrans.Text.Equals("0"))
                {
                    if (noreceiveboardform == null)
                        connection.SendMsgReqUnreadTransfer();
                    else
                        noreceiveboardform.Show();
                }
                else
                    MessageBox.Show("부재중 등록된 이관내역이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }
        #endregion

        private void weDo정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            miscCtrl.DisplayAboutForm();
        }

        private void btn_crm_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("고객관리", btn_crm);
        }

        private void btn_board_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("공지게시판", btn_board);
        }

        private void btn_memobox_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("쪽지함", btn_memobox);
        }

        private void btn_dialoguebox_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("대화함", btn_dialoguebox);
        }

        private void btn_sendnotice_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("공지하기", btn_sendnotice);
        }

        private void btn_resultnotice_MouseEnter(object sender, EventArgs e)
        {
            tooltip.Show("공지결과 보기", btn_resultnotice);
        }

        #region 부재중 쪽지
        private void UpperMemoToolTipShow(object sender, EventArgs e)
        {
            tooltip.Show("부재중 쪽지", (Control)sender);
        }

        private void UpperMemoToolTipHide(object sender, EventArgs e)
        {
            tooltip.Hide((Control)sender);
        }
        #endregion

        #region 부재중 공지
        private void UpperNoticeToolTipShow(object sender, EventArgs e)
        {
            tooltip.Show("부재중 공지", (Control)sender);
        }

        private void UpperNoticeToolTipHide(object sender, EventArgs e)
        {
            tooltip.Hide((Control)sender);
        }
        #endregion

        #region 부재중 파일
        private void UpperFileToolTipShow(object sender, EventArgs e)
        {
            tooltip.Show("부재중 파일", (Control)sender);
        }

        private void UpperFileToolTipHide(object sender, EventArgs e)
        {
            tooltip.Hide((Control)sender);
        }
        #endregion

        #region 부재중 이관
        private void UpperTransToolTipShow(object sender, EventArgs e)
        {
            tooltip.Show("부재중 이관", (Control)sender);
        }

        private void UpperTransToolTipHide(object sender, EventArgs e)
        {
            tooltip.Hide((Control)sender);
        }
        #endregion

        private void label_stat_MouseEnter(object sender, EventArgs e)
        {
            labelColor = label_stat.ForeColor;
            label_stat.ForeColor = Color.DarkOrange;
        }

        private void label_stat_MouseLeave(object sender, EventArgs e)
        {
            label_stat.ForeColor = labelColor;
        }

        private void label_stat_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseMenuStat.Show(label_stat, e.Location, ToolStripDropDownDirection.BelowRight);
            }
        }

        #region 내상태 지정
        private void StripMn_online_Click(object sender, EventArgs e)
        {
            stringDele dele = new stringDele(ChangeMyStatus);
            Invoke(dele, "온라인");
            connection.SendMsgChangeStatus(MsgrUserStatus.ONLINE);
        }

        private void StringMn_away_Click(object sender, EventArgs e)
        {
            stringDele dele = new stringDele(ChangeMyStatus);
            Invoke(dele, "자리비움");
            connection.SendMsgChangeStatus(MsgrUserStatus.AWAY);
        }

        private void StripMn_logout_Click(object sender, EventArgs e)
        {
            stringDele dele = new stringDele(ChangeMyStatus);
            Invoke(dele, "오프라인 표시");
            connection.SendMsgChangeStatus(MsgrUserStatus.LOGOUT);
        }

        private void StripMn_DND_Click(object sender, EventArgs e)
        {
            stringDele dele = new stringDele(ChangeMyStatus);
            Invoke(dele, "다른용무중");
            connection.SendMsgChangeStatus(MsgrUserStatus.DND);
        }

        private void StripMn_busy_Click(object sender, EventArgs e)
        {
            stringDele dele = new stringDele(ChangeMyStatus);
            Invoke(dele, "통화중");
            connection.SendMsgChangeStatus(MsgrUserStatus.BUSY);
        }
        #endregion

        private void tbx_pass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    NoParamDele dele = new NoParamDele(ProcessLogin);
                    Invoke(dele);
                }
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        private void pbx_sizemark_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mousePoint = e.Location;
        }

        private void pbx_sizemark_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xdifference = e.X - mousePoint.X;
                int ydifference = e.Y - mousePoint.Y;

                this.Width = 285 + xdifference;
                this.Height = 418 + ydifference;
            }
        }

        private void Mn_extension_Click(object sender, EventArgs e)
        {
            NoParamDele npdele = new NoParamDele(DisplayExtensionForm);
            Invoke(npdele);
        }
        
        private void StripMn_Quit_Click(object sender, EventArgs e)
        {
            ExitMessenger();
        }

        private void pic_notice_Click(object sender, EventArgs e)
        {
            MakeSendNotice();
        }

        private void StripMn_show_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void pbx_login_MouseClick(object sender, MouseEventArgs e)
        {
            NoParamDele dele = new NoParamDele(ProcessLogin);
            Invoke(dele);
        }

        private void pic_memolist_Click(object sender, EventArgs e)
        {
            MakeMemoList();
        }

        private void MnNotice_Click(object sender, EventArgs e)
        {
            MakeSendNotice();
        }

        private void pic_noticelist_Click(object sender, EventArgs e)
        {
            connection.SendMsgRequestNoticeListAll();
        }

        private void StripMn_gmemo_Click(object sender, EventArgs e)
        {
            OpenSendMemoBySelectedNode();
        }
        
        private void Btnlogout_Click(object sender, EventArgs e)
        {
            Logger.info("Btnlogout_Click !");
            try
            {
                if (ChatForms.Count > 0)
                {
                    if (MessageBox.Show(this, "로그아웃하면 현재 열려있는 폼이 모두 닫힙니다."
                                        , "알림"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        ProcessLogOut();
                    }
                }
                else ProcessLogOut();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void StripMn_memo_Click(object sender, EventArgs e)
        {
            OpenSendMemoBySelectedNode();
        }

        private void MnExit_Click(object sender, EventArgs e)
        {
            ExitMessenger();
        }


        private void menu_notifyicon_MouseLeave(object sender, EventArgs e)
        {
            menu_notifyicon.Close();
        }

        private void notifyIcon_Click(object sender, MouseEventArgs e)
        {
            int pointx = System.Windows.Forms.StatusBar.MousePosition.X;
            int pointy = System.Windows.Forms.StatusBar.MousePosition.Y;
            if (e.Button == MouseButtons.Left)
            {
                this.TopMost = ConfigHelper.TopMost;

                //this.WindowState = FormWindowState.Normal;
                this.SetBounds(mainform_x, mainform_y, mainform_width, mainform_height);
                this.ShowInTaskbar = true;
                this.Show();
                this.Activate();
                isFormHidden = false;
                firstCall = false;
            }
            else
                menu_notifyicon.Show(pointx, pointy);
        }

        private void login_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void MnDialog_Click(object sender, EventArgs e)
        {
            try
            {
                if (memTree.SelectedNode.GetNodeCount(true) != 0)
                    return; //팀원 노드 선택

                MemberObj userObj = (MemberObj)memTree.SelectedNode.Tag;
                Logger.info("대화선택:" + userObj.Id);

                OpenSingleChatForm(userObj);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }
        
        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessLogin();
        }
        
        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcessLogin();
        }

        private void MnMemo_Click(object sender, EventArgs e)
        {
            OpenSendMemoBySelectedNode();
        }
    }
}