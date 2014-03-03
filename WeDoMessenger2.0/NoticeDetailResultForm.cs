using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.Common;

namespace Client
{
    public partial class NoticeDetailResultForm : Form
    {

        string formKey;

        public NoticeDetailResultForm(string key)
        {
            InitializeComponent();
            TopMost = true;
            formKey = key;
            Initialize(null);
        }

        public NoticeDetailResultForm(string key, List<string> unReaderList)
        {
            InitializeComponent();
            TopMost = true;
            formKey = key;
            Initialize(unReaderList);
        }


        private void Initialize(List<string> unReaderList)
        {
            foreach (var pair in Members.GetMembers())
            {
                string receiver = ((MemberObj)pair.Value).Name + "(" + pair.Key.ToString() + ")";
                ListViewItem ditem = listView1.Items.Add(pair.Key.ToString(), receiver, null);

                if (unReaderList.Contains(pair.Key.ToString()))
                {
                    ditem.ForeColor = Color.Red;
                    ditem.SubItems.Add("확인안함");
                }
                else
                {
                    ditem.ForeColor = Color.Blue;
                    ditem.SubItems.Add("읽음");
                }

            }
        }
        
        public void SetNoticeRead(string readerId)
        {
            ListViewItem[] itemArray = listView1.Items.Find(readerId, false);
            if (itemArray != null && itemArray.Length != 0)
            {
                itemArray[0].ForeColor = Color.Blue;
                itemArray[0].SubItems[1].Text = "읽 음";
            }
        }

        private void NoticeDetailResultForm_SizeChanged(object sender, EventArgs e)
        {
            int widthgap = this.Width - listView1.Width;
            listView1.Width += widthgap;
            int heightgap = this.Height - (listView1.Height + 30);
            listView1.Height += heightgap;
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

        private void NoticeDetailResultForm_Deactivate(object sender, EventArgs e)
        {
            TopMost = false;
        }

        private void NoticeDetailResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

    }

 
}
