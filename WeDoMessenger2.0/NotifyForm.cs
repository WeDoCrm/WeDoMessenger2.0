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
    public partial class NotifyForm : Form
    {

        private Timer timerForNotify = new Timer();

        TransferObj notiObj;
        public TransferObj NotiObj
        { get { return notiObj; } }
   
        public NotifyForm()
        {
            InitializeComponent();
        }

        public NotifyForm(string[] msg)
        {
            notiObj = new TransferObj(msg);
            InitializeComponent();
        }

        /// <summary>
        /// msg //pass|ani|senderID|receiverID|TONG_DATE|TONG_TIME|CustomerName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyForm_Load(object sender, EventArgs e)
        {
            timerForNotify.Interval = 10000;
            timerForNotify.Tick += new EventHandler(timerForNotify_Tick);

            this.Tag = notiObj.Ani;
            label_TONGDATE.Text = notiObj.TongDate;
            label_TONGTIME.Text = notiObj.TongTime;
            label_ani.Text = notiObj.Ani;
            label_senderid.Text = notiObj.SenderId;
            if (notiObj.CustomerName == null || notiObj.CustomerName.Equals(""))
                label_Customer.Text = notiObj.Ani;
            else 
                label_Customer.Text = notiObj.CustomerName;
            label_sender.Text = "from " + Members.GetByUserId(notiObj.SenderId).Name + "(" + notiObj.SenderId + ")";
        }

        private void timerForNotify_Tick(object sender, EventArgs e)
        {
            try
            {
                timerForNotify.Stop();
                int height_point = 0;

                TransferNotiForms.AddForm(this.notiObj);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerForNotify.Stop();
            ShowTransferInfoHandler showTransferInfoHandler = new ShowTransferInfoHandler(CrmHelper.ShowTransferInfo);
            Invoke(showTransferInfoHandler, notiObj);
        }
    }
}
