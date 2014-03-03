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
    public partial class NotReadMemoForm : Form
    {
        public NotReadMemoForm()
        {
            InitializeComponent();
        }

        private void NotReadMemoForm_SizeChanged(object sender, EventArgs e)
        {
            int widthgap = this.Width - listView.Width;
            listView.Width += widthgap;
            int heightgap = this.Height - (listView.Height + 30);
            listView.Height += heightgap;
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

    }
}