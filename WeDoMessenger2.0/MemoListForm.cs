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
    public partial class MemoListForm : TopMostForm
    {
        MsgrConnection connection;
        List<MemoObj> list;

        public MemoListForm(MsgrConnection connection, List<MemoObj> list)
        {
            InitializeComponent();
            this.connection = connection;
            this.list = list;
        }

        public void Initialize()
        {
            foreach (MemoObj obj in list)
            {
                ListViewItem item = listView.Items.Add(obj.Time);
                item.SubItems.Add(Members.GetByUserId(obj.SenderId).Name + "(" + obj.SenderId + ")");
                item.SubItems.Add(obj.Content);
                item.Tag = obj;
            }
        }

        private void MemoListForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                int widthgap = this.Width - listView.Width;
                listView.Width += widthgap;
                int heightgap = this.Height - (listView.Height + 30);
                listView.Height += heightgap;
                btn_all.SetBounds(btn_all.Left, (btn_all.Top + heightgap), btn_all.Width, btn_all.Height);
                btn_cancel.SetBounds(btn_cancel.Left, (btn_cancel.Top + heightgap), btn_cancel.Width, btn_cancel.Height);
                btn_del.SetBounds((btn_del.Left + widthgap), (btn_del.Top + heightgap), btn_del.Width, btn_del.Height);
            }
            catch (Exception ex)
            {

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

        private void btn_all_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
                item.Checked = true;
        }

        private void btn_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in listView.Items)
                item.Checked = false;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count != 0)
                {
                    MemoForm memoForm = new MemoForm(connection, (MemoObj)listView.SelectedItems[0].Tag);
                    memoForm.Show();
                    memoForm.Activate();

                    listView.SelectedItems[0].Selected = false;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void btn_del_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in listView.CheckedItems)
            {
                if (MemoUtils.DelMemo(ConfigHelper.Id, (MemoObj)item.Tag))
                    listView.Items.RemoveAt(item.Index);
            }
        }

    }
}
