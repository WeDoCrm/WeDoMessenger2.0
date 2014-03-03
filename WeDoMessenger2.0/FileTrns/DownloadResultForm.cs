using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Client.PopUp;
using WeDoCommon;
using System.IO;

namespace Client
{
    public partial class DownloadResultForm : FlashWindowForm
    {
        private bool isFileOpened = false;

        public DownloadResultForm()
        {
            InitializeComponent();
        }

        public DownloadResultForm(string senderName, string fileName, string fullFileName)
        {
            InitializeComponent();
            label_sender.Text = senderName;
            label_filename.Text = fileName;
            label_fullname.Text = fullFileName;
        }

        private void btn_opendir_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = label_fullname.Text;
                
                FileInfo fileinfo = new FileInfo(filename);

                string dirname = fileinfo.DirectoryName;
                System.Diagnostics.Process.Start(dirname);

            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFileOpened)
                {
                    Close();
                }
                else
                {
                    string filename = label_fullname.Text;
                    System.Diagnostics.Process.Start(filename);
                    ButtonOpenFile.Text = "닫 기";
                    isFileOpened = true;
                }
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }

    }
}
