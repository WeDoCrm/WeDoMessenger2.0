using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.PopUp;

namespace Client
{
    public partial class DialogContent : TopMostForm
    {
        public DialogContent()
        {
            InitializeComponent();
        }

        public void setContentInfo(string title, string content) {
            this.Text = title;
            this.richTextBoxNotice.Text = content;
        }

        private void CopyCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxNotice.Copy();
        }

        private void SelectAllCtrlCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBoxNotice.SelectAll();
        }

        private void richTextBoxNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.ControlKey)
            {
                switch (e.KeyData)
                {
                    case Keys.C:
                        richTextBoxNotice.Copy();
                        break;
                    case Keys.A:
                        richTextBoxNotice.SelectAll();
                        break;
                }
            }

        }
    }
}
