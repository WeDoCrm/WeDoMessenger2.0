using System.Windows.Forms;
using System;
namespace Client
{
    /// <summary>
    /// 메인창 클래스의 이벤트 처리.
    /// </summary>
    public partial class Client_Form : System.Windows.Forms.Form
    {
        #region 화면 이벤트발생
        private void Client_Form_SizeChanged(object sender, EventArgs e)
        {
            int rightgap = this.Width - 290;

            webBrowser1.Width = rightgap + 260;

            int heightgap = this.Height - 600;

            webBrowser1.SetBounds(webBrowser1.Left, 435 + heightgap, webBrowser1.Width, webBrowser1.Height);
            pictureBox2.SetBounds(pictureBox2.Left, 430 + heightgap, pictureBox2.Width, pictureBox2.Height);//임시이미지판
            panel_logon.Width = this.Width;
            panel_logon.Height = this.Height - (600 - 519);
            memTree.Width = this.Width - (290 - 220);
            memTree.Height = this.Height - (600 - 325);

            InfoBar.Width = this.Width;

        }

        /// <summary>
        /// collapsed된 아이콘 모양
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 3;
            e.Node.SelectedImageIndex = 3;
        }

        /// <summary>
        /// expanded된 아이콘 모양
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 2;
            e.Node.SelectedImageIndex = 2;
        }
        #endregion

    }
}