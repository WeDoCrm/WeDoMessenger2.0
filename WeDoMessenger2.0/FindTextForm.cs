using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeDoCommon;

namespace Client
{
    public partial class FindTextForm : Form
    {

        ListView.ListViewItemCollection noticeListViewItems;

        public FindTextForm(ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            noticeListViewItems = items;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtbox.Clear();
        }

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string word = null;
                    TextBox box = (TextBox)sender;
                    word = box.Text;
                    ShowFindText(word);
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }

        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                ShowFindText(txtbox.Text);
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        /// <summary>
        /// 공지사항 리스트에서 텍스트 검색기능
        /// </summary>
        /// <param name="word"></param>
        private void ShowFindText(string word)
        {
            try
            {
                Logger.info("검색 시작");
                FindListForm form = new FindListForm(noticeListViewItems, word);
                form.DisplayFindResult();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }
    }
}
