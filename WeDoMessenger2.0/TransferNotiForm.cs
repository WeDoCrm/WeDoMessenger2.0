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
    public partial class TransferNotiForm : Form
    {
        Color label_customer_color;
        Color label_from_color;
        Color backcolor;

        TransferObj transferObj;

        string ani;

        ShowTransferInfoHandler showTransferInfoHandler;
        ShowCustomerPopUpHandler showCustomerPopUpHandler;

        public TransferNotiForm(TransferObj obj)
        {
            InitializeComponent();
            label_customer_color = label_Customer.ForeColor;
            label_from_color = label_from.ForeColor;
            backcolor = this.BackColor;

            pbx_icon.Image = global::Client.Properties.Resources.img_customer;

            this.MouseClick += new MouseEventHandler(OnMouseClickToShowTransferInfo);
            this.pbx_icon.MouseClick += new MouseEventHandler(OnMouseClickToShowTransferInfo);
            this.label_Customer.MouseClick += new MouseEventHandler(OnMouseClickToShowTransferInfo);
            this.label_from.MouseClick += new MouseEventHandler(OnMouseClickToShowTransferInfo);

            transferObj = obj;
            label_Customer.Text = obj.CustomerName;//notifyform.label_Customer.Text;
            label_from.Text = obj.SenderName;//notifyform.label_sender.Text;
            label_ani.Text = obj.Ani; //notifyform.label_ani.Text;
            label_date.Text = obj.TongDate; //notifyform.label_TONGDATE.Text;
            label_time.Text = obj.TongTime;// notifyform.label_TONGTIME.Text;
            label_senderid.Text = obj.SenderId;//notifyform.label_senderid.Text;

        }

        public TransferNotiForm(string ani, string name)
        {
            InitializeComponent();
            label_customer_color = label_Customer.ForeColor;
            label_from_color = label_from.ForeColor;
            backcolor = this.BackColor;

            pbx_icon.Image = global::Client.Properties.Resources.phone_black;
            pbx_close.Visible = true;

            pbx_close.MouseClick += new MouseEventHandler(OnMouseClickToClose);

            MouseClick += new MouseEventHandler(OnMouseClickToShowCustomerPopUp);
            pbx_icon.MouseClick += new MouseEventHandler(OnMouseClickToShowCustomerPopUp);
            label_from.MouseClick += new MouseEventHandler(OnMouseClickToShowCustomerPopUp);
            label_Customer.MouseClick += new MouseEventHandler(OnMouseClickToShowCustomerPopUp);

            this.ani = ani;

            if (name.Length > 1)
            {
                label_Customer.Text = name + "(" + ani + ")";
            }
            else
            {
                label_Customer.Text = ani;
            }
            label_from.Text = "시간 : " + DateTime.Now.ToShortTimeString();
        }

        private void TransferNotiForm_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
            label_Customer.ForeColor = Color.Black;
            label_from.ForeColor = Color.Black;
        }

        private void TransferNotiForm_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = backcolor;
            label_Customer.ForeColor = label_customer_color;
            label_from.ForeColor = label_from_color;
        }

        private void pbx_close_MouseEnter(object sender, EventArgs e)
        {
            pbx_close.Image = global::Client.Properties.Resources.btn_closesize_over;
        }

        private void pbx_close_MouseLeave(object sender, EventArgs e)
        {
            pbx_close.Image = global::Client.Properties.Resources.btn_closesize;
        }

        private void OnMouseClickToShowTransferInfo(object sender, MouseEventArgs e)
        {
            try
            {
                showTransferInfoHandler = new ShowTransferInfoHandler(CrmHelper.ShowTransferInfo);
                Invoke(showTransferInfoHandler, transferObj);
                TransferNotiForms.CloseForm(this);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

        private void OnMouseClickToShowCustomerPopUp(object sender, MouseEventArgs e)
        {
            try
            {
                showCustomerPopUpHandler = new ShowCustomerPopUpHandler(CrmHelper.ShowCustomerPopup);

                Invoke(showCustomerPopUpHandler, ani, CrmHelper.CallType.IN_BOUND);
                TransferNotiForms.CloseForm(this);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }


        /// <summary>
        /// 인스턴트 수신목록 태크 닫기 버튼 처리 : 태그폼을 닫고 해당 TransferNotiArea를 비운다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseClickToClose(object sender, MouseEventArgs e)
        {
            try
            {
                TransferNotiForms.CloseForm(this);
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }

        }

    }
}
