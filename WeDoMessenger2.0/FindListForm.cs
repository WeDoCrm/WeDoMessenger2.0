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
    public partial class FindListForm : Form
    {
        ListView.ListViewItemCollection noticeListItems;
        string searchedWord;

        public FindListForm(ListView.ListViewItemCollection items, string searchedWord)
        {
            InitializeComponent();
            noticeListItems = items;
            this.searchedWord = searchedWord;
        }

        public void DisplayFindResult()
        {
            int findnum = 0;
            foreach (ListViewItem item in noticeListItems)
            {
                string contents = item.SubItems[1].Text;
                if (contents.Contains(searchedWord))
                {
                    string date = item.SubItems[3].Text;
                    txtbox_result.AppendText("#################################\r\n\r\n");
                    txtbox_result.AppendText("공지일자 : <" + date + ">\r\n\r\n");
                    txtbox_result.AppendText(contents + "\r\n\r\n");
                    findnum++;
                }
            }
            int indexnum = txtbox_result.Text.IndexOf(searchedWord);
            txtbox_result.Select(indexnum, searchedWord.Length);

            Logger.info("찾은 갯수 : " + findnum.ToString());
            if (findnum == 0)
            {
                MessageBox.Show("검색된 결과가 없습니다.", "결과없음", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Show();
                this.TopMost = true;
            }
        }

        private void txtbox_result_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string text = txtbox_result.SelectedText;
                    int textlength = txtbox_result.SelectionLength;
                    int newstart = textlength + txtbox_result.SelectionStart;
                    newstart = txtbox_result.Text.IndexOf(text, newstart);
                    if (newstart == -1)
                    {
                        newstart = txtbox_result.Text.IndexOf(txtbox_result.SelectedText, 0);
                    }
                    txtbox_result.DeselectAll();
                    txtbox_result.Select(newstart, textlength);
                    txtbox_result.ScrollToCaret();
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

    }
}
