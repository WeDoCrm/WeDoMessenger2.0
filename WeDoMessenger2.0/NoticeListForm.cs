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
    public partial class NoticeListForm : TopMostForm
    {
        MsgrConnection connection;

        public NoticeListForm(MsgrConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        /// <summary>
        /// msg 포맷: L|time‡content‡mode‡sender‡seqnum‡title|...
        /// </summary>
        /// <param name="msg"></param>
        public void AssignListInfo(string[] msg)
        {
            try
            {
                listView.Items.Clear();
                foreach (string item in msg)
                {
                    if (item.Equals("L")) continue;


                    NumberedNoticeObj noticeObj = new NumberedNoticeObj(item);
                    ListViewItem listItem = null;

                    if (noticeObj != null)
                    {
                        Logger.info("notice_time = " + noticeObj.NoticeTime);

                        listItem = listView.Items.Add(noticeObj.NoticeTime, noticeObj.Mode, null);
                        if (noticeObj.IsEmergency)
                            listItem.ForeColor = Color.Red;

                        if (noticeObj.Content.Contains("\n\r\n\r"))
                            noticeObj.Content.Replace("♪", " ");

                        listItem.SubItems.Add(noticeObj.Title);
                        listItem.SubItems.Add(noticeObj.Content);
                        listItem.SubItems.Add(Members.GetByUserId(noticeObj.SenderId).Name + "(" + noticeObj.SenderId + ")");
                        listItem.SubItems.Add(noticeObj.NoticeTime);
                        listItem.Tag = noticeObj;
                        Logger.info("seqnum = " + noticeObj.SeqNum);
                        listView.ListViewItemSorter = new ListViewItemComparerDe(3);
                    }
                }
            }
            catch (Exception ex1)
            {
                Logger.error(ex1.ToString());
            }
        }

        private bool isAs = false;

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (isAs == false)
            {
                this.listView.ListViewItemSorter = new ListViewItemComparerAs(e.Column);
                isAs = true;
            }
            else
            {
                this.listView.ListViewItemSorter = new ListViewItemComparerDe(e.Column);
                isAs = false;
            }

        }

        private void cancel_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.CheckedListViewItemCollection col = this.listView.CheckedItems;
            if (col.Count != 0)
            {
                foreach (ListViewItem item in col)
                {
                    item.Checked = false;
                }
            }
        }

        private void btn_all_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.ListViewItemCollection col = listView.Items;
            if (col.Count != 0)
            {
                foreach (ListViewItem item in col)
                {
                    item.Checked = true;
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count == 0)
            {
                MessageBox.Show(this, "삭제할 공지를 선택해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (ListViewItem item in listView.CheckedItems)
                {
                    listView.Items.RemoveAt(item.Index);
                    connection.SendMsgAdminDeleteNotice(((NumberedNoticeObj)item.Tag).SeqNum);
                }

            }
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
                {
                    FindTextForm form = new FindTextForm(this.listView.Items);
                    form.Show(this);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

                    //공지사항 목록 아이템 선택
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count != 0)
                {
                    ListViewItem mitem = listView.SelectedItems[0];
                    NoticeObj notice = (NoticeObj)mitem.Tag;

                    //실시간 공지사항 수신시 확인결과 전송 처리
                    Notice nform = new Notice(connection, notice);
                    nform.Show();
                    nform.Activate();

                    this.TopMost = false;
                    mitem.Selected = false;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void NoticeListForm_Load(object sender, EventArgs e)
        {
            listView.CheckBoxes = true;
            btn_del.Visible = true;
            cancel.Visible = true;
            btn_all.Visible = true;
        }
    }
}
