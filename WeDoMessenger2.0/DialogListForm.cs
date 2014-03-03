using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.PopUp;
using Client.Common;
using System.IO;
using System.Collections;
using WeDoCommon;

namespace Client
{
    public partial class DialogListForm : TopMostForm
    {
        ArrayList dialogSaveFileList = null;

        public DialogListForm()
        {
            InitializeComponent();
        }

        public DialogListForm(ArrayList list)
        {
            this.dialogSaveFileList = list;
            InitializeComponent();
        }

        public void InitializeList()
        {
            foreach (object obj in this.dialogSaveFileList)
            {
                FileInfo tempFileInfo = (FileInfo)obj;
                string fname = tempFileInfo.Name;
                string[] tempArray = fname.Split('!');
                ListViewItem item = listView.Items.Add(tempFileInfo.Directory.Name + " " + tempArray[0]);
                string[] array = tempArray[1].Split('.');//파일 확장자명 제거
                //string tempname = getName(array[0]);
                item.SubItems.Add(array[0]);
                item.Tag = tempFileInfo;
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


        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {

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

        private void btn_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.CheckedListViewItemCollection col = listView.CheckedItems;
            if (col.Count != 0)
            {
                foreach (ListViewItem item in col)
                {
                    item.Checked = false;
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.CheckedListViewItemCollection col = listView.CheckedItems;
                if (col.Count != 0)
                {
                    foreach (ListViewItem item in col)
                    {
                        FileInfo tempfi = (FileInfo)item.Tag;
                        tempfi.Delete();
                        listView.Items.RemoveAt(item.Index);
                        Logger.info(string.Format("대화함: 파일 삭제됨[{0}]",tempfi.Name));
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count != 0)
                {
                    ListViewItem item = listView.SelectedItems[0];
                    FileInfo fi = (FileInfo)item.Tag;
                    Logger.info(string.Format("대화함: 파일 선택됨[{0}]", fi.Name));
                    StreamReader sr = fi.OpenText();
                    DialogContent form = new DialogContent();
                    string dialogstr = "";
                    while (!sr.EndOfStream)
                    {
                        dialogstr += sr.ReadLine() + "\r\n";
                    }
                    string title = item.SubItems[1].Text;
                    form.setContentInfo(title, dialogstr);
                    form.Show(this);
                    item.Selected = false;
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        //private void listView_MouseHover(object sender, EventArgs e)
        //{
        //    e.Item.Selected = true;
        //}


    }

 
}
