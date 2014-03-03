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
    public partial class NoticeResultForm : TopMostForm
    {
        public NoticeResultForm()
        {
            InitializeComponent();
        }

        private void NoticeResultForm_SizeChanged(object sender, EventArgs e)
        {
            int widthgap = this.Width - listView1.Width;
            listView1.Width += widthgap;
            int heightgap = this.Height - (listView1.Height + 30);
            listView1.Height += heightgap;
        }

        public void AddItem(AbstractNoticeObj noticeInfo)
        {

            bool isExist = false;

            foreach (ListViewItem row in listView1.Items)
            {
                if (noticeInfo.NoticeTime.Equals(row.Tag.ToString().Trim()))
                {
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                ListViewItem item = listView1.Items.Add(noticeInfo.NoticeTime, "자세히", null);
                item.Tag = noticeInfo.NoticeTime;
                item.SubItems.Add(noticeInfo.NoticeTime);
                item.SubItems.Add(noticeInfo.Mode);
                item.SubItems.Add(noticeInfo.Title);
                item.SubItems.Add(noticeInfo.Content);
            }
        }

        private bool isAs = false;

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (isAs == false)
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparerAs(e.Column);
                isAs = true;
            }
            else
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparerDe(e.Column);
                isAs = false;
            }

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                string noticeid = item.Tag.ToString();

                NoticeDetailForms.ActivateForm(noticeid, this);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void NoticeResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
   
}
