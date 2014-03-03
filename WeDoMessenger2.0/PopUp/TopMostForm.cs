using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.PopUp
{
    public partial class TopMostForm : Form
    {
        public TopMostForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void TopMostForm_Deactivate(object sender, EventArgs e)
        {
            TopMost = false;
        }
    }
}
