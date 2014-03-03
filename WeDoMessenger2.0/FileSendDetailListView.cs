using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.Common;
using WeDoCommon;

namespace Client
{
    public partial class FileSendDetailListView : Form
    {
        private MsgrConnection connection;
        private string formKey;
        private List<MemberObj> receiverList;
        private List<MemberObj> completedList;

        public FileSendDetailListView()
        {
            InitializeComponent();
        }

        public FileSendDetailListView(MsgrConnection connection, string formKey, List<MemberObj> receiverList)
        {
            InitializeComponent();
            this.connection = connection;
            this.formKey = formKey;
            this.receiverList = receiverList;
            Initialize();
            FileSendDetailListViews.AddForm(formKey, this);
        }

        public void Initialize()
        {
            foreach (MemberObj receiver in receiverList)
            {
                ListViewItem item = listView.Items.Add(receiver.Id, string.Format("{0}({1})", receiver.Name, receiver.Id), null);
                item.SubItems.Add("");
                item.SubItems.Add("");
            }

            //connection.FTPSendingProgressed += DisplayOnFTPSendingProgressed;
            //connection.FTPSendingFinished += DisplayOnFTPSendingFinished;
            //connection.FTPSendingCanceled += DisplayOnFTPSendingCanceled;
            //connection.FTPSendingFailed += DisplayOnFTPSendingFailed;
            //connection.FTPSendingAccepted += ProcessOnFTPSendingAccepted;
            //connection.FTPSendingRejected += ProcessOnFTPSendingRejected;

            //connection.FTPResponseReceived += this.DisplayFTPDetailOnResponseReceived;
        }

        public bool FTPCompleted()
        {
            return (receiverList.Count == completedList.Count);
        }

        /// <summary>
        /// 리스트 뷰의 아이템 구분: 
        /// 1. id(파일 받는 사람의 id)
        /// 2. 표시하고자 하는 상태값
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayFTPDetailOnResponseReceived(object sender, FTPResultReceivedEventArgs e)
        {
            try
            {
                if (e.Key.Equals(this.formKey))
                {
                    ListViewItem[] itemArray = null;
                    if (listView.Items.ContainsKey(e.ReceiverId))
                    {
                        itemArray = listView.Items.Find(e.ReceiverId, false);
                    }
                    if (itemArray != null)
                    {
                        itemArray[0].SubItems[1].Text = e.Message;
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
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

        private void FileSendDetailListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (SendFileForms.Contain(this.formKey))
                {
                    e.Cancel = true;
                    Hide();
                }
                else
                {
                    FileSendDetailListViews.RemoveForm(this.formKey);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }

        }

    }

    
}