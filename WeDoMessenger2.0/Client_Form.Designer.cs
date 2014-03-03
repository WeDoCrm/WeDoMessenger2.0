using System.Windows.Forms;
namespace Client
{
    public partial class Client_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    if (connection.IsConnected)
                        ClearResourceOnClosing();
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.mouseMenuG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMn_gchat = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_gmemo = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_gfile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mouseMenuN = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMn_chat = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_memo = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_file = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.default_panal = new System.Windows.Forms.Panel();
            this.panel_progress = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_progress_status = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.pbx_loginCancel = new System.Windows.Forms.PictureBox();
            this.cbx_pass_save = new System.Windows.Forms.CheckBox();
            this.pic_title = new System.Windows.Forms.PictureBox();
            this.label_pass = new System.Windows.Forms.Label();
            this.tbx_pass = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.panel_logon = new System.Windows.Forms.Panel();
            this.InfoBar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pic_NRtrans = new System.Windows.Forms.PictureBox();
            this.NRtrans = new System.Windows.Forms.Label();
            this.pbx_stat = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_stat = new System.Windows.Forms.Label();
            this.pic_NRfile = new System.Windows.Forms.PictureBox();
            this.pic_NRnotice = new System.Windows.Forms.PictureBox();
            this.pic_NRmemo = new System.Windows.Forms.PictureBox();
            this.NRfile = new System.Windows.Forms.Label();
            this.NRnotice = new System.Windows.Forms.Label();
            this.NRmemo = new System.Windows.Forms.Label();
            this.team = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_resultnotice = new System.Windows.Forms.Button();
            this.memTree = new System.Windows.Forms.TreeView();
            this.btn_sendnotice = new System.Windows.Forms.Button();
            this.btn_dialoguebox = new System.Windows.Forms.Button();
            this.btn_memobox = new System.Windows.Forms.Button();
            this.btn_board = new System.Windows.Forms.Button();
            this.btn_crm = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mouseMenuStat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMn_online = new System.Windows.Forms.ToolStripMenuItem();
            this.StringMn_away = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_DND = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_busy = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_notifyicon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Mn_notify_show = new System.Windows.Forms.ToolStripMenuItem();
            this.Mn_notify_dispose = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_file_sub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TM_file_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_file_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_motion_sub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TM_motion_chat = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_motion_memo = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_motion_sendfile = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_motion_sendnotice = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_option_sub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TM_option_default = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_option_extension = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_option_server = new System.Windows.Forms.ToolStripMenuItem();
            this.TM_help_sub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TM_help_show = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.MnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMotion = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDialogue = new System.Windows.Forms.ToolStripMenuItem();
            this.MnNotice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.Mn_default = new System.Windows.Forms.ToolStripMenuItem();
            this.Mn_extension = new System.Windows.Forms.ToolStripMenuItem();
            this.Mn_server = new System.Windows.Forms.ToolStripMenuItem();
            this.MnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.weDo정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aquaSkin1 = new SkinSoft.AquaSkin.AquaSkin(this.components);
            this.mouseMenuC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StripMn_cchat = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_cmemo = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMn_cfile = new System.Windows.Forms.ToolStripMenuItem();
            this.BGWorkerCustomerScheduler = new System.ComponentModel.BackgroundWorker();
            this.mouseMenuG.SuspendLayout();
            this.mouseMenuN.SuspendLayout();
            this.default_panal.SuspendLayout();
            this.panel_progress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_loginCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).BeginInit();
            this.panel_logon.SuspendLayout();
            this.InfoBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRtrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_stat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRnotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRmemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.mouseMenuStat.SuspendLayout();
            this.menu_notifyicon.SuspendLayout();
            this.TM_file_sub.SuspendLayout();
            this.TM_motion_sub.SuspendLayout();
            this.TM_option_sub.SuspendLayout();
            this.TM_help_sub.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).BeginInit();
            this.mouseMenuC.SuspendLayout();
            this.SuspendLayout();
            // 
            // mouseMenuG
            // 
            this.mouseMenuG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMn_gchat,
            this.StripMn_gmemo,
            this.StripMn_gfile});
            this.mouseMenuG.Name = "mouseMenuG";
            this.mouseMenuG.Size = new System.Drawing.Size(163, 70);
            // 
            // StripMn_gchat
            // 
            this.StripMn_gchat.Name = "StripMn_gchat";
            this.StripMn_gchat.Size = new System.Drawing.Size(162, 22);
            this.StripMn_gchat.Text = "그룹 대화하기";
            this.StripMn_gchat.Click += new System.EventHandler(this.chat_Click);
            // 
            // StripMn_gmemo
            // 
            this.StripMn_gmemo.Name = "StripMn_gmemo";
            this.StripMn_gmemo.Size = new System.Drawing.Size(162, 22);
            this.StripMn_gmemo.Text = "그룹 쪽지보내기";
            this.StripMn_gmemo.Click += new System.EventHandler(this.StripMn_gmemo_Click);
            // 
            // StripMn_gfile
            // 
            this.StripMn_gfile.Enabled = false;
            this.StripMn_gfile.Name = "StripMn_gfile";
            this.StripMn_gfile.Size = new System.Drawing.Size(162, 22);
            this.StripMn_gfile.Text = "그룹 파일보내기";
            this.StripMn_gfile.Visible = false;
            this.StripMn_gfile.Click += new System.EventHandler(this.StripMn_gfile_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "로그아웃.png");
            this.imageList.Images.SetKeyName(1, "온라인.png");
            this.imageList.Images.SetKeyName(2, "화살표아래_6.png");
            this.imageList.Images.SetKeyName(3, "화살표위_6.png");
            this.imageList.Images.SetKeyName(4, "부재중.png");
            this.imageList.Images.SetKeyName(5, "다른용무중.png");
            this.imageList.Images.SetKeyName(6, "통화중.png");
            // 
            // mouseMenuN
            // 
            this.mouseMenuN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMn_chat,
            this.StripMn_memo,
            this.StripMn_file});
            this.mouseMenuN.Name = "mouseMenuG";
            this.mouseMenuN.Size = new System.Drawing.Size(135, 70);
            // 
            // StripMn_chat
            // 
            this.StripMn_chat.Name = "StripMn_chat";
            this.StripMn_chat.Size = new System.Drawing.Size(134, 22);
            this.StripMn_chat.Text = "대화하기";
            this.StripMn_chat.Click += new System.EventHandler(this.chat_Click);
            // 
            // StripMn_memo
            // 
            this.StripMn_memo.Name = "StripMn_memo";
            this.StripMn_memo.Size = new System.Drawing.Size(134, 22);
            this.StripMn_memo.Text = "쪽지보내기";
            this.StripMn_memo.Click += new System.EventHandler(this.StripMn_memo_Click);
            // 
            // StripMn_file
            // 
            this.StripMn_file.Name = "StripMn_file";
            this.StripMn_file.Size = new System.Drawing.Size(134, 22);
            this.StripMn_file.Text = "파일보내기";
            this.StripMn_file.Click += new System.EventHandler(this.StripMn_file_Click);
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.Window;
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Location = new System.Drawing.Point(118, 201);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 21);
            this.id.TabIndex = 9;
            this.id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_KeyDown);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "열기";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WeDo 메신저";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Click);
            // 
            // default_panal
            // 
            this.default_panal.BackColor = System.Drawing.SystemColors.Control;
            this.default_panal.Controls.Add(this.panel_progress);
            this.default_panal.Controls.Add(this.btn_login);
            this.default_panal.Controls.Add(this.pbx_loginCancel);
            this.default_panal.Controls.Add(this.cbx_pass_save);
            this.default_panal.Controls.Add(this.pic_title);
            this.default_panal.Controls.Add(this.label_pass);
            this.default_panal.Controls.Add(this.tbx_pass);
            this.default_panal.Controls.Add(this.label_id);
            this.default_panal.Controls.Add(this.id);
            this.default_panal.Location = new System.Drawing.Point(0, 0);
            this.default_panal.Name = "default_panal";
            this.default_panal.Size = new System.Drawing.Size(284, 508);
            this.default_panal.TabIndex = 24;
            // 
            // panel_progress
            // 
            this.panel_progress.BackColor = System.Drawing.Color.Transparent;
            this.panel_progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_progress.Controls.Add(this.pictureBox1);
            this.panel_progress.Controls.Add(this.label_progress_status);
            this.panel_progress.Location = new System.Drawing.Point(99, 206);
            this.panel_progress.Name = "panel_progress";
            this.panel_progress.Size = new System.Drawing.Size(88, 86);
            this.panel_progress.TabIndex = 27;
            this.panel_progress.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label_progress_status
            // 
            this.label_progress_status.AutoSize = true;
            this.label_progress_status.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_progress_status.Location = new System.Drawing.Point(24, 68);
            this.label_progress_status.Name = "label_progress_status";
            this.label_progress_status.Size = new System.Drawing.Size(41, 12);
            this.label_progress_status.TabIndex = 1;
            this.label_progress_status.Text = "접속중";
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("돋움", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_login.Location = new System.Drawing.Point(94, 319);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(93, 30);
            this.btn_login.TabIndex = 102;
            this.btn_login.Text = "로그인";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_login_MouseClick);
            // 
            // pbx_loginCancel
            // 
            this.pbx_loginCancel.BackColor = System.Drawing.Color.Transparent;
            this.pbx_loginCancel.Location = new System.Drawing.Point(115, 307);
            this.pbx_loginCancel.Name = "pbx_loginCancel";
            this.pbx_loginCancel.Size = new System.Drawing.Size(45, 25);
            this.pbx_loginCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx_loginCancel.TabIndex = 101;
            this.pbx_loginCancel.TabStop = false;
            this.pbx_loginCancel.Visible = false;
            // 
            // cbx_pass_save
            // 
            this.cbx_pass_save.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_pass_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_pass_save.Location = new System.Drawing.Point(118, 261);
            this.cbx_pass_save.Name = "cbx_pass_save";
            this.cbx_pass_save.Size = new System.Drawing.Size(94, 15);
            this.cbx_pass_save.TabIndex = 100;
            this.cbx_pass_save.Text = "비밀번호 저장";
            this.cbx_pass_save.UseVisualStyleBackColor = true;
            this.cbx_pass_save.CheckedChanged += new System.EventHandler(this.cbx_pass_save_CheckedChanged);
            // 
            // pic_title
            // 
            this.pic_title.BackColor = System.Drawing.Color.Transparent;
            this.pic_title.ErrorImage = null;
            this.pic_title.Image = ((System.Drawing.Image)(resources.GetObject("pic_title.Image")));
            this.pic_title.InitialImage = null;
            this.pic_title.Location = new System.Drawing.Point(64, 76);
            this.pic_title.Name = "pic_title";
            this.pic_title.Size = new System.Drawing.Size(153, 67);
            this.pic_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_title.TabIndex = 21;
            this.pic_title.TabStop = false;
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.BackColor = System.Drawing.Color.Transparent;
            this.label_pass.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_pass.Location = new System.Drawing.Point(59, 232);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(53, 12);
            this.label_pass.TabIndex = 99;
            this.label_pass.Text = "비밀번호";
            // 
            // tbx_pass
            // 
            this.tbx_pass.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_pass.Location = new System.Drawing.Point(118, 229);
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.PasswordChar = '●';
            this.tbx_pass.Size = new System.Drawing.Size(100, 21);
            this.tbx_pass.TabIndex = 10;
            this.tbx_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_pass_KeyDown);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.BackColor = System.Drawing.Color.Transparent;
            this.label_id.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_id.Location = new System.Drawing.Point(66, 206);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(41, 12);
            this.label_id.TabIndex = 27;
            this.label_id.Text = "아이디";
            // 
            // panel_logon
            // 
            this.panel_logon.BackColor = System.Drawing.SystemColors.Control;
            this.panel_logon.Controls.Add(this.InfoBar);
            this.panel_logon.Controls.Add(this.pictureBox2);
            this.panel_logon.Controls.Add(this.btn_resultnotice);
            this.panel_logon.Controls.Add(this.memTree);
            this.panel_logon.Controls.Add(this.btn_sendnotice);
            this.panel_logon.Controls.Add(this.btn_dialoguebox);
            this.panel_logon.Controls.Add(this.btn_memobox);
            this.panel_logon.Controls.Add(this.btn_board);
            this.panel_logon.Controls.Add(this.btn_crm);
            this.panel_logon.Controls.Add(this.webBrowser1);
            this.panel_logon.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_logon.Location = new System.Drawing.Point(-8, 24);
            this.panel_logon.Margin = new System.Windows.Forms.Padding(0);
            this.panel_logon.Name = "panel_logon";
            this.panel_logon.Size = new System.Drawing.Size(298, 507);
            this.panel_logon.TabIndex = 25;
            this.panel_logon.Visible = false;
            // 
            // InfoBar
            // 
            this.InfoBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.InfoBar.Controls.Add(this.label4);
            this.InfoBar.Controls.Add(this.pic_NRtrans);
            this.InfoBar.Controls.Add(this.NRtrans);
            this.InfoBar.Controls.Add(this.pbx_stat);
            this.InfoBar.Controls.Add(this.label3);
            this.InfoBar.Controls.Add(this.label2);
            this.InfoBar.Controls.Add(this.label1);
            this.InfoBar.Controls.Add(this.label_stat);
            this.InfoBar.Controls.Add(this.pic_NRfile);
            this.InfoBar.Controls.Add(this.pic_NRnotice);
            this.InfoBar.Controls.Add(this.pic_NRmemo);
            this.InfoBar.Controls.Add(this.NRfile);
            this.InfoBar.Controls.Add(this.NRnotice);
            this.InfoBar.Controls.Add(this.NRmemo);
            this.InfoBar.Controls.Add(this.team);
            this.InfoBar.Controls.Add(this.name);
            this.InfoBar.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InfoBar.Location = new System.Drawing.Point(0, 0);
            this.InfoBar.Margin = new System.Windows.Forms.Padding(0);
            this.InfoBar.Name = "InfoBar";
            this.InfoBar.Size = new System.Drawing.Size(298, 83);
            this.InfoBar.TabIndex = 105;
            this.InfoBar.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(247, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 11);
            this.label4.TabIndex = 28;
            this.label4.Text = "업무";
            this.label4.MouseLeave += new System.EventHandler(this.UpperTransToolTipHide);
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRtrans_MouseClick);
            this.label4.MouseEnter += new System.EventHandler(this.UpperTransToolTipShow);
            // 
            // pic_NRtrans
            // 
            this.pic_NRtrans.BackColor = System.Drawing.Color.Transparent;
            this.pic_NRtrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_NRtrans.ErrorImage = null;
            this.pic_NRtrans.Image = ((System.Drawing.Image)(resources.GetObject("pic_NRtrans.Image")));
            this.pic_NRtrans.InitialImage = null;
            this.pic_NRtrans.Location = new System.Drawing.Point(228, 61);
            this.pic_NRtrans.Name = "pic_NRtrans";
            this.pic_NRtrans.Size = new System.Drawing.Size(17, 17);
            this.pic_NRtrans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_NRtrans.TabIndex = 27;
            this.pic_NRtrans.TabStop = false;
            this.pic_NRtrans.MouseLeave += new System.EventHandler(this.UpperTransToolTipHide);
            this.pic_NRtrans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRtrans_MouseClick);
            this.pic_NRtrans.MouseEnter += new System.EventHandler(this.UpperTransToolTipShow);
            // 
            // NRtrans
            // 
            this.NRtrans.AutoSize = true;
            this.NRtrans.BackColor = System.Drawing.Color.Transparent;
            this.NRtrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NRtrans.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NRtrans.ForeColor = System.Drawing.Color.Black;
            this.NRtrans.Location = new System.Drawing.Point(275, 64);
            this.NRtrans.Name = "NRtrans";
            this.NRtrans.Size = new System.Drawing.Size(11, 12);
            this.NRtrans.TabIndex = 26;
            this.NRtrans.Text = "0";
            this.NRtrans.MouseLeave += new System.EventHandler(this.UpperTransToolTipHide);
            this.NRtrans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRtrans_MouseClick);
            this.NRtrans.MouseEnter += new System.EventHandler(this.UpperTransToolTipShow);
            // 
            // pbx_stat
            // 
            this.pbx_stat.BackColor = System.Drawing.Color.Transparent;
            this.pbx_stat.Image = global::Client.Properties.Resources.온라인;
            this.pbx_stat.Location = new System.Drawing.Point(21, 7);
            this.pbx_stat.Name = "pbx_stat";
            this.pbx_stat.Size = new System.Drawing.Size(30, 25);
            this.pbx_stat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_stat.TabIndex = 25;
            this.pbx_stat.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(35, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "쪽지";
            this.label3.MouseLeave += new System.EventHandler(this.UpperMemoToolTipHide);
            this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NRmemo_Click);
            this.label3.MouseEnter += new System.EventHandler(this.UpperMemoToolTipShow);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(106, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 11);
            this.label2.TabIndex = 23;
            this.label2.Text = "공지";
            this.label2.MouseLeave += new System.EventHandler(this.UpperNoticeToolTipHide);
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRnotice_MouseClick);
            this.label2.MouseEnter += new System.EventHandler(this.UpperNoticeToolTipShow);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(178, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 11);
            this.label1.TabIndex = 22;
            this.label1.Text = "파일";
            this.label1.MouseLeave += new System.EventHandler(this.UpperFileToolTipHide);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRfile_MouseClick);
            this.label1.MouseEnter += new System.EventHandler(this.UpperFileToolTipShow);
            // 
            // label_stat
            // 
            this.label_stat.AutoSize = true;
            this.label_stat.BackColor = System.Drawing.Color.Transparent;
            this.label_stat.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_stat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_stat.Location = new System.Drawing.Point(55, 34);
            this.label_stat.Name = "label_stat";
            this.label_stat.Size = new System.Drawing.Size(52, 11);
            this.label_stat.TabIndex = 21;
            this.label_stat.Text = "온라인 ▼";
            this.label_stat.MouseLeave += new System.EventHandler(this.label_stat_MouseLeave);
            this.label_stat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_stat_MouseClick);
            this.label_stat.MouseEnter += new System.EventHandler(this.label_stat_MouseEnter);
            // 
            // pic_NRfile
            // 
            this.pic_NRfile.BackColor = System.Drawing.Color.Transparent;
            this.pic_NRfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_NRfile.ErrorImage = null;
            this.pic_NRfile.Image = ((System.Drawing.Image)(resources.GetObject("pic_NRfile.Image")));
            this.pic_NRfile.InitialImage = null;
            this.pic_NRfile.Location = new System.Drawing.Point(159, 61);
            this.pic_NRfile.Name = "pic_NRfile";
            this.pic_NRfile.Size = new System.Drawing.Size(17, 17);
            this.pic_NRfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_NRfile.TabIndex = 20;
            this.pic_NRfile.TabStop = false;
            this.pic_NRfile.MouseLeave += new System.EventHandler(this.UpperFileToolTipHide);
            this.pic_NRfile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRfile_MouseClick);
            this.pic_NRfile.MouseEnter += new System.EventHandler(this.UpperFileToolTipShow);
            // 
            // pic_NRnotice
            // 
            this.pic_NRnotice.BackColor = System.Drawing.Color.Transparent;
            this.pic_NRnotice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_NRnotice.ErrorImage = null;
            this.pic_NRnotice.Image = ((System.Drawing.Image)(resources.GetObject("pic_NRnotice.Image")));
            this.pic_NRnotice.InitialImage = null;
            this.pic_NRnotice.Location = new System.Drawing.Point(89, 61);
            this.pic_NRnotice.Name = "pic_NRnotice";
            this.pic_NRnotice.Size = new System.Drawing.Size(17, 17);
            this.pic_NRnotice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_NRnotice.TabIndex = 19;
            this.pic_NRnotice.TabStop = false;
            this.pic_NRnotice.MouseLeave += new System.EventHandler(this.UpperNoticeToolTipHide);
            this.pic_NRnotice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRnotice_MouseClick);
            this.pic_NRnotice.MouseEnter += new System.EventHandler(this.UpperNoticeToolTipShow);
            // 
            // pic_NRmemo
            // 
            this.pic_NRmemo.BackColor = System.Drawing.Color.Transparent;
            this.pic_NRmemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_NRmemo.ErrorImage = null;
            this.pic_NRmemo.Image = ((System.Drawing.Image)(resources.GetObject("pic_NRmemo.Image")));
            this.pic_NRmemo.InitialImage = null;
            this.pic_NRmemo.Location = new System.Drawing.Point(16, 61);
            this.pic_NRmemo.Name = "pic_NRmemo";
            this.pic_NRmemo.Size = new System.Drawing.Size(17, 17);
            this.pic_NRmemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_NRmemo.TabIndex = 18;
            this.pic_NRmemo.TabStop = false;
            this.pic_NRmemo.MouseLeave += new System.EventHandler(this.UpperMemoToolTipHide);
            this.pic_NRmemo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NRmemo_Click);
            this.pic_NRmemo.MouseEnter += new System.EventHandler(this.UpperMemoToolTipShow);
            // 
            // NRfile
            // 
            this.NRfile.AutoSize = true;
            this.NRfile.BackColor = System.Drawing.Color.Transparent;
            this.NRfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NRfile.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NRfile.ForeColor = System.Drawing.Color.Black;
            this.NRfile.Location = new System.Drawing.Point(206, 64);
            this.NRfile.Name = "NRfile";
            this.NRfile.Size = new System.Drawing.Size(11, 12);
            this.NRfile.TabIndex = 12;
            this.NRfile.Text = "0";
            this.NRfile.MouseLeave += new System.EventHandler(this.UpperFileToolTipHide);
            this.NRfile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRfile_MouseClick);
            this.NRfile.MouseEnter += new System.EventHandler(this.UpperFileToolTipShow);
            // 
            // NRnotice
            // 
            this.NRnotice.AutoSize = true;
            this.NRnotice.BackColor = System.Drawing.Color.Transparent;
            this.NRnotice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NRnotice.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NRnotice.ForeColor = System.Drawing.Color.Black;
            this.NRnotice.Location = new System.Drawing.Point(134, 64);
            this.NRnotice.Name = "NRnotice";
            this.NRnotice.Size = new System.Drawing.Size(11, 12);
            this.NRnotice.TabIndex = 11;
            this.NRnotice.Text = "0";
            this.NRnotice.MouseLeave += new System.EventHandler(this.UpperNoticeToolTipHide);
            this.NRnotice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_NRnotice_MouseClick);
            this.NRnotice.MouseEnter += new System.EventHandler(this.UpperNoticeToolTipShow);
            // 
            // NRmemo
            // 
            this.NRmemo.AutoSize = true;
            this.NRmemo.BackColor = System.Drawing.Color.Transparent;
            this.NRmemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NRmemo.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NRmemo.ForeColor = System.Drawing.Color.Black;
            this.NRmemo.Location = new System.Drawing.Point(63, 64);
            this.NRmemo.Name = "NRmemo";
            this.NRmemo.Size = new System.Drawing.Size(11, 12);
            this.NRmemo.TabIndex = 10;
            this.NRmemo.Text = "0";
            this.NRmemo.MouseLeave += new System.EventHandler(this.UpperMemoToolTipHide);
            this.NRmemo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NRmemo_Click);
            this.NRmemo.MouseEnter += new System.EventHandler(this.UpperMemoToolTipShow);
            // 
            // team
            // 
            this.team.AutoSize = true;
            this.team.BackColor = System.Drawing.Color.Transparent;
            this.team.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.team.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.team.Location = new System.Drawing.Point(190, 14);
            this.team.Name = "team";
            this.team.Size = new System.Drawing.Size(35, 13);
            this.team.TabIndex = 4;
            this.team.Text = "소속";
            this.team.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(56, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(59, 13);
            this.name.TabIndex = 2;
            this.name.Text = "이름(id)";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 425);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(298, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // btn_resultnotice
            // 
            this.btn_resultnotice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_resultnotice.BackgroundImage")));
            this.btn_resultnotice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_resultnotice.Location = new System.Drawing.Point(11, 329);
            this.btn_resultnotice.Name = "btn_resultnotice";
            this.btn_resultnotice.Size = new System.Drawing.Size(50, 43);
            this.btn_resultnotice.TabIndex = 12;
            this.btn_resultnotice.UseVisualStyleBackColor = true;
            this.btn_resultnotice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_resultnotice_MouseClick);
            this.btn_resultnotice.MouseEnter += new System.EventHandler(this.btn_resultnotice_MouseEnter);
            // 
            // memTree
            // 
            this.memTree.AllowDrop = true;
            this.memTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.memTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.memTree.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.memTree.ImageIndex = 2;
            this.memTree.ImageList = this.imageList;
            this.memTree.Indent = 25;
            this.memTree.ItemHeight = 20;
            this.memTree.LineColor = System.Drawing.Color.BlanchedAlmond;
            this.memTree.Location = new System.Drawing.Point(68, 88);
            this.memTree.Margin = new System.Windows.Forms.Padding(0);
            this.memTree.MinimumSize = new System.Drawing.Size(220, 325);
            this.memTree.Name = "memTree";
            this.memTree.SelectedImageIndex = 2;
            this.memTree.ShowLines = false;
            this.memTree.ShowNodeToolTips = true;
            this.memTree.ShowPlusMinus = false;
            this.memTree.ShowRootLines = false;
            this.memTree.Size = new System.Drawing.Size(220, 325);
            this.memTree.TabIndex = 5;
            this.memTree.Visible = false;
            this.memTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.memTree_NodeMouseDoubleClick);
            this.memTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.memTree_AfterCollapse);
            this.memTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.memTree_DragDrop);
            this.memTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.memTree_DragEnter);
            this.memTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.memTree_NodeMouseClick);
            this.memTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.memTree_AfterExpand);
            this.memTree.DragOver += new System.Windows.Forms.DragEventHandler(this.memTree_DragOver);
            // 
            // btn_sendnotice
            // 
            this.btn_sendnotice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_sendnotice.BackgroundImage")));
            this.btn_sendnotice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_sendnotice.Location = new System.Drawing.Point(11, 280);
            this.btn_sendnotice.Name = "btn_sendnotice";
            this.btn_sendnotice.Size = new System.Drawing.Size(50, 43);
            this.btn_sendnotice.TabIndex = 11;
            this.btn_sendnotice.UseVisualStyleBackColor = true;
            this.btn_sendnotice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_sendnotice_MouseClick);
            this.btn_sendnotice.MouseEnter += new System.EventHandler(this.btn_sendnotice_MouseEnter);
            // 
            // btn_dialoguebox
            // 
            this.btn_dialoguebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_dialoguebox.BackgroundImage")));
            this.btn_dialoguebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_dialoguebox.Location = new System.Drawing.Point(11, 231);
            this.btn_dialoguebox.Name = "btn_dialoguebox";
            this.btn_dialoguebox.Size = new System.Drawing.Size(50, 43);
            this.btn_dialoguebox.TabIndex = 10;
            this.btn_dialoguebox.UseVisualStyleBackColor = true;
            this.btn_dialoguebox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_dialoguebox_MouseClick);
            this.btn_dialoguebox.MouseEnter += new System.EventHandler(this.btn_dialoguebox_MouseEnter);
            // 
            // btn_memobox
            // 
            this.btn_memobox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_memobox.BackgroundImage")));
            this.btn_memobox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_memobox.Location = new System.Drawing.Point(11, 182);
            this.btn_memobox.Name = "btn_memobox";
            this.btn_memobox.Size = new System.Drawing.Size(50, 43);
            this.btn_memobox.TabIndex = 9;
            this.btn_memobox.UseVisualStyleBackColor = true;
            this.btn_memobox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_memobox_MouseClick);
            this.btn_memobox.MouseEnter += new System.EventHandler(this.btn_memobox_MouseEnter);
            // 
            // btn_board
            // 
            this.btn_board.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_board.BackgroundImage")));
            this.btn_board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_board.Location = new System.Drawing.Point(11, 134);
            this.btn_board.Name = "btn_board";
            this.btn_board.Size = new System.Drawing.Size(50, 43);
            this.btn_board.TabIndex = 8;
            this.btn_board.UseVisualStyleBackColor = true;
            this.btn_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_board_MouseClick);
            this.btn_board.MouseEnter += new System.EventHandler(this.btn_board_MouseEnter);
            // 
            // btn_crm
            // 
            this.btn_crm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_crm.BackgroundImage")));
            this.btn_crm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_crm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_crm.Location = new System.Drawing.Point(11, 88);
            this.btn_crm.Name = "btn_crm";
            this.btn_crm.Size = new System.Drawing.Size(50, 43);
            this.btn_crm.TabIndex = 7;
            this.btn_crm.UseVisualStyleBackColor = true;
            this.btn_crm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_crm_MouseClick);
            this.btn_crm.MouseEnter += new System.EventHandler(this.btn_crm_MouseEnter);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(13, 421);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(271, 82);
            this.webBrowser1.TabIndex = 14;
            this.webBrowser1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(282, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mouseMenuStat
            // 
            this.mouseMenuStat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMn_online,
            this.StringMn_away,
            this.StripMn_DND,
            this.StripMn_busy});
            this.mouseMenuStat.Name = "mouseMenuStat";
            this.mouseMenuStat.Size = new System.Drawing.Size(142, 108);
            // 
            // StripMn_online
            // 
            this.StripMn_online.Image = ((System.Drawing.Image)(resources.GetObject("StripMn_online.Image")));
            this.StripMn_online.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMn_online.Name = "StripMn_online";
            this.StripMn_online.Size = new System.Drawing.Size(141, 26);
            this.StripMn_online.Text = "온라인";
            this.StripMn_online.Click += new System.EventHandler(this.StripMn_online_Click);
            // 
            // StringMn_away
            // 
            this.StringMn_away.Image = ((System.Drawing.Image)(resources.GetObject("StringMn_away.Image")));
            this.StringMn_away.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StringMn_away.Name = "StringMn_away";
            this.StringMn_away.Size = new System.Drawing.Size(141, 26);
            this.StringMn_away.Text = "자리비움";
            this.StringMn_away.Click += new System.EventHandler(this.StringMn_away_Click);
            // 
            // StripMn_DND
            // 
            this.StripMn_DND.Image = ((System.Drawing.Image)(resources.GetObject("StripMn_DND.Image")));
            this.StripMn_DND.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMn_DND.Name = "StripMn_DND";
            this.StripMn_DND.Size = new System.Drawing.Size(141, 26);
            this.StripMn_DND.Text = "다른용무중";
            this.StripMn_DND.Click += new System.EventHandler(this.StripMn_DND_Click);
            // 
            // StripMn_busy
            // 
            this.StripMn_busy.Image = ((System.Drawing.Image)(resources.GetObject("StripMn_busy.Image")));
            this.StripMn_busy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StripMn_busy.Name = "StripMn_busy";
            this.StripMn_busy.Size = new System.Drawing.Size(141, 26);
            this.StripMn_busy.Text = "통화중";
            this.StripMn_busy.Click += new System.EventHandler(this.StripMn_busy_Click);
            // 
            // menu_notifyicon
            // 
            this.menu_notifyicon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mn_notify_show,
            this.Mn_notify_dispose});
            this.menu_notifyicon.Name = "menu_notifyicon";
            this.menu_notifyicon.Size = new System.Drawing.Size(111, 48);
            // 
            // Mn_notify_show
            // 
            this.Mn_notify_show.Name = "Mn_notify_show";
            this.Mn_notify_show.Size = new System.Drawing.Size(110, 22);
            this.Mn_notify_show.Text = "보이기";
            this.Mn_notify_show.Click += new System.EventHandler(this.Mn_notify_show_Click);
            // 
            // Mn_notify_dispose
            // 
            this.Mn_notify_dispose.Name = "Mn_notify_dispose";
            this.Mn_notify_dispose.Size = new System.Drawing.Size(110, 22);
            this.Mn_notify_dispose.Text = "종료";
            this.Mn_notify_dispose.Click += new System.EventHandler(this.Mn_notify_dispose_Click);
            // 
            // TM_file_sub
            // 
            this.TM_file_sub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TM_file_logout,
            this.TM_file_exit});
            this.TM_file_sub.Name = "TM_file_sub";
            this.TM_file_sub.Size = new System.Drawing.Size(123, 48);
            // 
            // TM_file_logout
            // 
            this.TM_file_logout.Enabled = false;
            this.TM_file_logout.Name = "TM_file_logout";
            this.TM_file_logout.Size = new System.Drawing.Size(122, 22);
            this.TM_file_logout.Text = "로그아웃";
            this.TM_file_logout.Click += new System.EventHandler(this.Btnlogout_Click);
            // 
            // TM_file_exit
            // 
            this.TM_file_exit.Name = "TM_file_exit";
            this.TM_file_exit.Size = new System.Drawing.Size(122, 22);
            this.TM_file_exit.Text = "종료";
            this.TM_file_exit.Click += new System.EventHandler(this.MnExit_Click);
            // 
            // TM_motion_sub
            // 
            this.TM_motion_sub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TM_motion_chat,
            this.TM_motion_memo,
            this.TM_motion_sendfile,
            this.TM_motion_sendnotice});
            this.TM_motion_sub.Name = "TM_file_sub";
            this.TM_motion_sub.Size = new System.Drawing.Size(135, 92);
            // 
            // TM_motion_chat
            // 
            this.TM_motion_chat.Enabled = false;
            this.TM_motion_chat.Name = "TM_motion_chat";
            this.TM_motion_chat.Size = new System.Drawing.Size(134, 22);
            this.TM_motion_chat.Text = "대화하기";
            this.TM_motion_chat.Click += new System.EventHandler(this.MnDialog_Click);
            // 
            // TM_motion_memo
            // 
            this.TM_motion_memo.Enabled = false;
            this.TM_motion_memo.Name = "TM_motion_memo";
            this.TM_motion_memo.Size = new System.Drawing.Size(134, 22);
            this.TM_motion_memo.Text = "쪽지보내기";
            this.TM_motion_memo.Click += new System.EventHandler(this.MnMemo_Click);
            // 
            // TM_motion_sendfile
            // 
            this.TM_motion_sendfile.Enabled = false;
            this.TM_motion_sendfile.Name = "TM_motion_sendfile";
            this.TM_motion_sendfile.Size = new System.Drawing.Size(134, 22);
            this.TM_motion_sendfile.Text = "파일보내기";
            this.TM_motion_sendfile.Click += new System.EventHandler(this.MnSendFile_Click);
            // 
            // TM_motion_sendnotice
            // 
            this.TM_motion_sendnotice.Enabled = false;
            this.TM_motion_sendnotice.Name = "TM_motion_sendnotice";
            this.TM_motion_sendnotice.Size = new System.Drawing.Size(134, 22);
            this.TM_motion_sendnotice.Text = "공지하기";
            this.TM_motion_sendnotice.Click += new System.EventHandler(this.MnNotice_Click);
            // 
            // TM_option_sub
            // 
            this.TM_option_sub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TM_option_default,
            this.TM_option_extension,
            this.TM_option_server});
            this.TM_option_sub.Name = "TM_option_sub";
            this.TM_option_sub.Size = new System.Drawing.Size(123, 70);
            // 
            // TM_option_default
            // 
            this.TM_option_default.Name = "TM_option_default";
            this.TM_option_default.Size = new System.Drawing.Size(122, 22);
            this.TM_option_default.Text = "기본설정";
            this.TM_option_default.Click += new System.EventHandler(this.Mn_default_Click);
            // 
            // TM_option_extension
            // 
            this.TM_option_extension.Name = "TM_option_extension";
            this.TM_option_extension.Size = new System.Drawing.Size(122, 22);
            this.TM_option_extension.Text = "내선설정";
            this.TM_option_extension.Click += new System.EventHandler(this.Mn_extension_Click);
            // 
            // TM_option_server
            // 
            this.TM_option_server.Name = "TM_option_server";
            this.TM_option_server.Size = new System.Drawing.Size(122, 22);
            this.TM_option_server.Text = "서버설정";
            this.TM_option_server.Click += new System.EventHandler(this.Mn_server_Click);
            // 
            // TM_help_sub
            // 
            this.TM_help_sub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TM_help_show});
            this.TM_help_sub.Name = "TM_help_sub";
            this.TM_help_sub.Size = new System.Drawing.Size(135, 26);
            // 
            // TM_help_show
            // 
            this.TM_help_show.Name = "TM_help_show";
            this.TM_help_show.Size = new System.Drawing.Size(134, 22);
            this.TM_help_show.Text = "도움말보기";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnFile,
            this.MnMotion,
            this.MnSetting,
            this.MnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(282, 24);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnFile
            // 
            this.MnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnLogout,
            this.MnExit});
            this.MnFile.Name = "MnFile";
            this.MnFile.Size = new System.Drawing.Size(57, 20);
            this.MnFile.Text = "파일(&F)";
            // 
            // MnLogout
            // 
            this.MnLogout.Enabled = false;
            this.MnLogout.Name = "MnLogout";
            this.MnLogout.Size = new System.Drawing.Size(122, 22);
            this.MnLogout.Text = "로그아웃";
            this.MnLogout.Click += new System.EventHandler(this.Btnlogout_Click);
            // 
            // MnExit
            // 
            this.MnExit.Name = "MnExit";
            this.MnExit.Size = new System.Drawing.Size(122, 22);
            this.MnExit.Text = "종료";
            this.MnExit.Click += new System.EventHandler(this.MnExit_Click);
            // 
            // MnMotion
            // 
            this.MnMotion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnMemo,
            this.MnDialogue,
            this.MnNotice,
            this.MnSendFile});
            this.MnMotion.Name = "MnMotion";
            this.MnMotion.Size = new System.Drawing.Size(62, 20);
            this.MnMotion.Text = "동작(&M)";
            // 
            // MnMemo
            // 
            this.MnMemo.Enabled = false;
            this.MnMemo.Name = "MnMemo";
            this.MnMemo.Size = new System.Drawing.Size(134, 22);
            this.MnMemo.Text = "쪽지보내기";
            this.MnMemo.Click += new System.EventHandler(this.MnMemo_Click);
            // 
            // MnDialogue
            // 
            this.MnDialogue.Enabled = false;
            this.MnDialogue.Name = "MnDialogue";
            this.MnDialogue.Size = new System.Drawing.Size(134, 22);
            this.MnDialogue.Text = "대화하기";
            this.MnDialogue.Click += new System.EventHandler(this.MnDialog_Click);
            // 
            // MnNotice
            // 
            this.MnNotice.Enabled = false;
            this.MnNotice.Name = "MnNotice";
            this.MnNotice.Size = new System.Drawing.Size(134, 22);
            this.MnNotice.Text = "공지하기";
            this.MnNotice.Click += new System.EventHandler(this.MnNotice_Click);
            // 
            // MnSendFile
            // 
            this.MnSendFile.Enabled = false;
            this.MnSendFile.Name = "MnSendFile";
            this.MnSendFile.Size = new System.Drawing.Size(134, 22);
            this.MnSendFile.Text = "파일보내기";
            this.MnSendFile.Click += new System.EventHandler(this.MnSendFile_Click);
            // 
            // MnSetting
            // 
            this.MnSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mn_default,
            this.Mn_extension,
            this.Mn_server});
            this.MnSetting.Name = "MnSetting";
            this.MnSetting.Size = new System.Drawing.Size(58, 20);
            this.MnSetting.Text = "설정(&S)";
            // 
            // Mn_default
            // 
            this.Mn_default.Name = "Mn_default";
            this.Mn_default.Size = new System.Drawing.Size(122, 22);
            this.Mn_default.Text = "기본설정";
            this.Mn_default.Click += new System.EventHandler(this.Mn_default_Click);
            // 
            // Mn_extension
            // 
            this.Mn_extension.Name = "Mn_extension";
            this.Mn_extension.Size = new System.Drawing.Size(122, 22);
            this.Mn_extension.Text = "내선설정";
            this.Mn_extension.Click += new System.EventHandler(this.Mn_extension_Click);
            // 
            // Mn_server
            // 
            this.Mn_server.Name = "Mn_server";
            this.Mn_server.Size = new System.Drawing.Size(122, 22);
            this.Mn_server.Text = "서버설정";
            this.Mn_server.Click += new System.EventHandler(this.Mn_server_Click);
            // 
            // MnHelp
            // 
            this.MnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnShowHelp,
            this.weDo정보ToolStripMenuItem});
            this.MnHelp.Name = "MnHelp";
            this.MnHelp.Size = new System.Drawing.Size(72, 20);
            this.MnHelp.Text = "도움말(&H)";
            // 
            // MnShowHelp
            // 
            this.MnShowHelp.Name = "MnShowHelp";
            this.MnShowHelp.Size = new System.Drawing.Size(135, 22);
            this.MnShowHelp.Text = "도움말보기";
            // 
            // weDo정보ToolStripMenuItem
            // 
            this.weDo정보ToolStripMenuItem.Name = "weDo정보ToolStripMenuItem";
            this.weDo정보ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.weDo정보ToolStripMenuItem.Text = "WeDo 정보";
            this.weDo정보ToolStripMenuItem.Click += new System.EventHandler(this.weDo정보ToolStripMenuItem_Click);
            // 
            // aquaSkin1
            // 
            this.aquaSkin1.AquaStyle = SkinSoft.AquaSkin.AquaStyle.Panther;
            this.aquaSkin1.License = ((SkinSoft.AquaSkin.Licensing.AquaSkinLicense)(resources.GetObject("aquaSkin1.License")));
            this.aquaSkin1.ShadowStyle = SkinSoft.AquaSkin.ShadowStyle.Small;
            this.aquaSkin1.ToolStripStyle = SkinSoft.AquaSkin.ToolStripRenderStyle.Mixed;
            // 
            // mouseMenuC
            // 
            this.mouseMenuC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMn_cchat,
            this.StripMn_cmemo,
            this.StripMn_cfile});
            this.mouseMenuC.Name = "mouseMenuG";
            this.mouseMenuC.Size = new System.Drawing.Size(135, 70);
            // 
            // StripMn_cchat
            // 
            this.StripMn_cchat.Enabled = false;
            this.StripMn_cchat.Name = "StripMn_cchat";
            this.StripMn_cchat.Size = new System.Drawing.Size(134, 22);
            this.StripMn_cchat.Text = "대화하기";
            // 
            // StripMn_cmemo
            // 
            this.StripMn_cmemo.Name = "StripMn_cmemo";
            this.StripMn_cmemo.Size = new System.Drawing.Size(134, 22);
            this.StripMn_cmemo.Text = "쪽지보내기";
            this.StripMn_cmemo.Click += new System.EventHandler(this.StripMn_memo_Click);
            // 
            // StripMn_cfile
            // 
            this.StripMn_cfile.Enabled = false;
            this.StripMn_cfile.Name = "StripMn_cfile";
            this.StripMn_cfile.Size = new System.Drawing.Size(134, 22);
            this.StripMn_cfile.Text = "파일보내기";
            // 
            // Client_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 547);
            this.Controls.Add(this.panel_logon);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.default_panal);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(950, 10);
            this.MinimumSize = new System.Drawing.Size(298, 585);
            this.Name = "Client_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WeDo 메신저 ";
            this.Load += new System.EventHandler(this.Client_Form_Load);
            this.SizeChanged += new System.EventHandler(this.Client_Form_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_Form_FormClosing);
            this.mouseMenuG.ResumeLayout(false);
            this.mouseMenuN.ResumeLayout(false);
            this.default_panal.ResumeLayout(false);
            this.default_panal.PerformLayout();
            this.panel_progress.ResumeLayout(false);
            this.panel_progress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_loginCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_title)).EndInit();
            this.panel_logon.ResumeLayout(false);
            this.InfoBar.ResumeLayout(false);
            this.InfoBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRtrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_stat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRnotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NRmemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.mouseMenuStat.ResumeLayout(false);
            this.menu_notifyicon.ResumeLayout(false);
            this.TM_file_sub.ResumeLayout(false);
            this.TM_motion_sub.ResumeLayout(false);
            this.TM_option_sub.ResumeLayout(false);
            this.TM_help_sub.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).EndInit();
            this.mouseMenuC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label name;
        private Label team;
        private ContextMenuStrip mouseMenuG;
        private ToolStripMenuItem StripMn_gmemo;
        private ToolStripMenuItem StripMn_gfile;
        private ContextMenuStrip mouseMenuN;
        private ToolStripMenuItem StripMn_memo;
        private ToolStripMenuItem StripMn_file;
        private LogFrm Log = new LogFrm();
        private ToolStripMenuItem StripMn_gchat;
        private ToolStripMenuItem StripMn_chat;
        private ImageList imageList;
        private TextBox id;
        private NotifyIcon notifyIcon;
        private Label NRmemo;
        private Label NRfile;
        private Label NRnotice;
        private PictureBox pic_NRmemo;
        private PictureBox pic_NRnotice;
        private PictureBox pic_NRfile;
        private PictureBox pic_title;
        private Panel default_panal;
        private Label label_id;
        private Label label_pass;
        private TextBox tbx_pass;
        private Panel panel_logon;
        private StatusStrip statusStrip1;
        private Label label_stat;
        private ContextMenuStrip mouseMenuStat;
        private ToolStripMenuItem StripMn_online;
        private ToolStripMenuItem StringMn_away;
        private ToolStripMenuItem StripMn_DND;
        private CheckBox cbx_pass_save;
        private Panel panel_progress;
        private Label label_progress_status;
        private PictureBox pictureBox1;
        private PictureBox pbx_loginCancel;
        private ContextMenuStrip menu_notifyicon;
        private ToolStripMenuItem Mn_notify_show;
        private ToolStripMenuItem Mn_notify_dispose;
        private ContextMenuStrip TM_file_sub;
        private ToolStripMenuItem TM_file_logout;
        private ToolStripMenuItem TM_file_exit;
        private ContextMenuStrip TM_motion_sub;
        private ToolStripMenuItem TM_motion_chat;
        private ToolStripMenuItem TM_motion_memo;
        private ToolStripMenuItem TM_motion_sendfile;
        private ToolStripMenuItem TM_motion_sendnotice;
        private ContextMenuStrip TM_option_sub;
        private ToolStripMenuItem TM_option_default;
        private ToolStripMenuItem TM_option_extension;
        private ToolStripMenuItem TM_option_server;
        private ContextMenuStrip TM_help_sub;
        private ToolStripMenuItem TM_help_show;
        private Button btn_login;
        private Button btn_dialoguebox;
        private Button btn_memobox;
        private Button btn_board;
        private Button btn_crm;
        private Button btn_sendnotice;
        private Label label2;
        private Label label1;
        private Button btn_resultnotice;
        private Label label3;
        private TreeView memTree;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MnFile;
        private ToolStripMenuItem MnLogout;
        private ToolStripMenuItem MnExit;
        private ToolStripMenuItem MnMotion;
        private ToolStripMenuItem MnMemo;
        private ToolStripMenuItem MnDialogue;
        private ToolStripMenuItem MnNotice;
        private ToolStripMenuItem MnSendFile;
        private ToolStripMenuItem MnSetting;
        private ToolStripMenuItem Mn_default;
        private ToolStripMenuItem Mn_extension;
        private ToolStripMenuItem Mn_server;
        private ToolStripMenuItem MnHelp;
        private ToolStripMenuItem MnShowHelp;
        private PictureBox pictureBox2;
        private WebBrowser webBrowser1;
        private ToolStripMenuItem StripMn_busy;
        private OpenFileDialog openFileDialog;
        private ContextMenuStrip mouseMenuC;
        private ToolStripMenuItem StripMn_cchat;
        private ToolStripMenuItem StripMn_cmemo;
        private ToolStripMenuItem StripMn_cfile;
        private System.ComponentModel.BackgroundWorker BGWorkerCustomerScheduler;
 
    }
}