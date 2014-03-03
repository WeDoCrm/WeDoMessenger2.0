namespace Client
{
    partial class ChatForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chatSendFile = new System.Windows.Forms.Button();
            this.BtnAddChatter = new System.Windows.Forms.Button();
            this.chatStatBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabelChatStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChattersTree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.Formkey = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new Elegant.Ui.Panel();
            this.panel4 = new Elegant.Ui.Panel();
            this.panel5 = new Elegant.Ui.Panel();
            this.ReBox = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.label_font = new System.Windows.Forms.Label();
            this.txtbox_exam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new Elegant.Ui.Panel();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.chatStatBar.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.chatSendFile);
            this.panel1.Controls.Add(this.BtnAddChatter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 36);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // chatSendFile
            // 
            this.chatSendFile.Location = new System.Drawing.Point(195, 6);
            this.chatSendFile.Name = "chatSendFile";
            this.chatSendFile.Size = new System.Drawing.Size(75, 25);
            this.chatSendFile.TabIndex = 5;
            this.chatSendFile.Text = "파일전송";
            this.chatSendFile.UseVisualStyleBackColor = true;
            this.chatSendFile.Click += new System.EventHandler(this.chatSendFile_Click);
            // 
            // BtnAddChatter
            // 
            this.BtnAddChatter.Location = new System.Drawing.Point(114, 6);
            this.BtnAddChatter.Name = "BtnAddChatter";
            this.BtnAddChatter.Size = new System.Drawing.Size(75, 25);
            this.BtnAddChatter.TabIndex = 4;
            this.BtnAddChatter.Text = "초대하기";
            this.BtnAddChatter.UseVisualStyleBackColor = true;
            this.BtnAddChatter.Click += new System.EventHandler(this.BtnAddChatter_Click);
            // 
            // chatStatBar
            // 
            this.chatStatBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelChatStatus});
            this.chatStatBar.Location = new System.Drawing.Point(0, 490);
            this.chatStatBar.Name = "chatStatBar";
            this.chatStatBar.Size = new System.Drawing.Size(344, 22);
            this.chatStatBar.TabIndex = 3;
            this.chatStatBar.Text = "상태바";
            // 
            // StatusLabelChatStatus
            // 
            this.StatusLabelChatStatus.Name = "StatusLabelChatStatus";
            this.StatusLabelChatStatus.Size = new System.Drawing.Size(300, 17);
            this.StatusLabelChatStatus.Text = "마지막 메시지를 받은 시간:2013-02-16 오전 12:43:12";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutCtrlCToolStripMenuItem2,
            this.CopyCtrlCToolStripMenuItem2,
            this.PasteCtrlCToolStripMenuItem2,
            this.toolStripSeparator2,
            this.SelectAllCtrlCToolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(136, 98);
            // 
            // CutCtrlCToolStripMenuItem2
            // 
            this.CutCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.ID_EDIT_CUT_SMALL;
            this.CutCtrlCToolStripMenuItem2.Name = "CutCtrlCToolStripMenuItem2";
            this.CutCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.CutCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.CutCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.CutCtrlCToolStripMenuItem2.Text = "잘라내기(T)";
            this.CutCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.CutCtrlCToolStripMenuItem2_Click);
            // 
            // CopyCtrlCToolStripMenuItem2
            // 
            this.CopyCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.ID_EDIT_COPY_SMALL;
            this.CopyCtrlCToolStripMenuItem2.Name = "CopyCtrlCToolStripMenuItem2";
            this.CopyCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.CopyCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.CopyCtrlCToolStripMenuItem2.Text = "복사(C)";
            this.CopyCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.CopyCtrlCToolStripMenuItem2_Click);
            // 
            // PasteCtrlCToolStripMenuItem2
            // 
            this.PasteCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.pastesmall;
            this.PasteCtrlCToolStripMenuItem2.Name = "PasteCtrlCToolStripMenuItem2";
            this.PasteCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PasteCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.PasteCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.PasteCtrlCToolStripMenuItem2.Text = "붙여넣기(P)";
            this.PasteCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.PasteCtrlCToolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // SelectAllCtrlCToolStripMenuItem2
            // 
            this.SelectAllCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.AutomaticColor;
            this.SelectAllCtrlCToolStripMenuItem2.Name = "SelectAllCtrlCToolStripMenuItem2";
            this.SelectAllCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.SelectAllCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.SelectAllCtrlCToolStripMenuItem2.Text = "모두 선택(A)";
            this.SelectAllCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.SelectAllCtrlCToolStripMenuItem2_Click);
            // 
            // ChattersTree
            // 
            this.ChattersTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.ChattersTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChattersTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChattersTree.ImageIndex = 0;
            this.ChattersTree.ImageList = this.imageList;
            this.ChattersTree.Location = new System.Drawing.Point(0, 36);
            this.ChattersTree.Name = "ChattersTree";
            this.ChattersTree.SelectedImageIndex = 0;
            this.ChattersTree.ShowLines = false;
            this.ChattersTree.ShowPlusMinus = false;
            this.ChattersTree.ShowRootLines = false;
            this.ChattersTree.Size = new System.Drawing.Size(344, 44);
            this.ChattersTree.StateImageList = this.imageList;
            this.ChattersTree.TabIndex = 7;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "온라인.png");
            this.imageList.Images.SetKeyName(1, "로그아웃.png");
            this.imageList.Images.SetKeyName(2, "통화중.png");
            this.imageList.Images.SetKeyName(3, "다른용무중.png");
            this.imageList.Images.SetKeyName(4, "부재중.png");
            // 
            // Formkey
            // 
            this.Formkey.Enabled = false;
            this.Formkey.Location = new System.Drawing.Point(175, 1);
            this.Formkey.Name = "Formkey";
            this.Formkey.Size = new System.Drawing.Size(104, 21);
            this.Formkey.TabIndex = 8;
            this.Formkey.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutCtrlCToolStripMenuItem1,
            this.CopyCtrlCToolStripMenuItem1,
            this.PasteCtrlCToolStripMenuItem1,
            this.toolStripSeparator1,
            this.SelectAllCtrlCToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 98);
            // 
            // CutCtrlCToolStripMenuItem1
            // 
            this.CutCtrlCToolStripMenuItem1.Enabled = false;
            this.CutCtrlCToolStripMenuItem1.Image = global::Client.Properties.Resources.ID_EDIT_CUT_SMALL;
            this.CutCtrlCToolStripMenuItem1.Name = "CutCtrlCToolStripMenuItem1";
            this.CutCtrlCToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.CutCtrlCToolStripMenuItem1.ShowShortcutKeys = false;
            this.CutCtrlCToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.CutCtrlCToolStripMenuItem1.Text = "잘라내기(T)";
            // 
            // CopyCtrlCToolStripMenuItem1
            // 
            this.CopyCtrlCToolStripMenuItem1.Image = global::Client.Properties.Resources.ID_EDIT_COPY_SMALL;
            this.CopyCtrlCToolStripMenuItem1.Name = "CopyCtrlCToolStripMenuItem1";
            this.CopyCtrlCToolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.CopyCtrlCToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyCtrlCToolStripMenuItem1.ShowShortcutKeys = false;
            this.CopyCtrlCToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.CopyCtrlCToolStripMenuItem1.Text = "복사(C)";
            this.CopyCtrlCToolStripMenuItem1.Click += new System.EventHandler(this.CopyCtrlCToolStripMenuItem1_Click);
            // 
            // PasteCtrlCToolStripMenuItem1
            // 
            this.PasteCtrlCToolStripMenuItem1.Enabled = false;
            this.PasteCtrlCToolStripMenuItem1.Image = global::Client.Properties.Resources.pastesmall;
            this.PasteCtrlCToolStripMenuItem1.Name = "PasteCtrlCToolStripMenuItem1";
            this.PasteCtrlCToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PasteCtrlCToolStripMenuItem1.ShowShortcutKeys = false;
            this.PasteCtrlCToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.PasteCtrlCToolStripMenuItem1.Text = "붙여넣기(P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // SelectAllCtrlCToolStripMenuItem1
            // 
            this.SelectAllCtrlCToolStripMenuItem1.Image = global::Client.Properties.Resources.AutomaticColor;
            this.SelectAllCtrlCToolStripMenuItem1.Name = "SelectAllCtrlCToolStripMenuItem1";
            this.SelectAllCtrlCToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllCtrlCToolStripMenuItem1.ShowShortcutKeys = false;
            this.SelectAllCtrlCToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.SelectAllCtrlCToolStripMenuItem1.Text = "모두 선택(A)";
            this.SelectAllCtrlCToolStripMenuItem1.Click += new System.EventHandler(this.SelectAllCtrlCToolStripMenuItem1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label_font);
            this.panel2.Controls.Add(this.txtbox_exam);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 89);
            this.panel2.TabIndex = 14;
            this.panel2.Text = "panel2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(344, 58);
            this.panel4.TabIndex = 18;
            this.panel4.Text = "panel4";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ReBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(283, 58);
            this.panel5.TabIndex = 17;
            this.panel5.Text = "panel5";
            // 
            // ReBox
            // 
            this.ReBox.ContextMenuStrip = this.contextMenuStrip2;
            this.ReBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.ReBox.Location = new System.Drawing.Point(3, 3);
            this.ReBox.Multiline = true;
            this.ReBox.Name = "ReBox";
            this.ReBox.Size = new System.Drawing.Size(277, 52);
            this.ReBox.TabIndex = 0;
            this.ReBox.TextChanged += new System.EventHandler(this.ReBox_TextChanged);
            this.ReBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReBox_KeyUp);
            this.ReBox.MouseEnter += new System.EventHandler(this.ReBox_MouseEnter);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(283, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(61, 58);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSend.TabIndex = 16;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label_font
            // 
            this.label_font.AutoSize = true;
            this.label_font.BackColor = System.Drawing.Color.Transparent;
            this.label_font.Font = new System.Drawing.Font("굴림", 9F);
            this.label_font.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label_font.Location = new System.Drawing.Point(12, 9);
            this.label_font.Name = "label_font";
            this.label_font.Size = new System.Drawing.Size(53, 12);
            this.label_font.TabIndex = 17;
            this.label_font.Text = "글꼴설정";
            this.label_font.Click += new System.EventHandler(this.label_font_Click);
            // 
            // txtbox_exam
            // 
            this.txtbox_exam.BackColor = System.Drawing.SystemColors.Window;
            this.txtbox_exam.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbox_exam.Location = new System.Drawing.Point(249, 5);
            this.txtbox_exam.Name = "txtbox_exam";
            this.txtbox_exam.ReadOnly = true;
            this.txtbox_exam.Size = new System.Drawing.Size(85, 23);
            this.txtbox_exam.TabIndex = 16;
            this.txtbox_exam.Text = "가나ABab";
            this.txtbox_exam.FontChanged += new System.EventHandler(this.FontChanged);
            this.txtbox_exam.ForeColorChanged += new System.EventHandler(this.FontChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(181, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "미리보기";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chatBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 321);
            this.panel3.TabIndex = 15;
            this.panel3.Text = "panel3";
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.Window;
            this.chatBox.ContextMenuStrip = this.contextMenuStrip1;
            this.chatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatBox.Location = new System.Drawing.Point(0, 0);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(344, 321);
            this.chatBox.TabIndex = 10;
            this.chatBox.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "열기";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(344, 512);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ChattersTree);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Formkey);
            this.Controls.Add(this.chatStatBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 550);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Deactivate += new System.EventHandler(this.ChatForm_Deactivate);
            this.Shown += new System.EventHandler(this.ChatForm_Shown);
            this.Activated += new System.EventHandler(this.ChatForm_Activated);
            this.Enter += new System.EventHandler(this.ChatForm_Enter);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatForm_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.chatStatBar.ResumeLayout(false);
            this.chatStatBar.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.StatusStrip chatStatBar;
        public System.Windows.Forms.TreeView ChattersTree;
        public System.Windows.Forms.TextBox Formkey;
        public System.Windows.Forms.ImageList imageList;
        public System.Windows.Forms.Button chatSendFile;
        public System.Windows.Forms.Button BtnAddChatter;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem CutCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CopyCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem PasteCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SelectAllCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CutCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CopyCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PasteCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SelectAllCtrlCToolStripMenuItem1;
        private Elegant.Ui.Panel panel2;
        public System.Windows.Forms.Label label_font;
        public System.Windows.Forms.TextBox txtbox_exam;
        public System.Windows.Forms.Label label1;
        private Elegant.Ui.Panel panel3;
        public System.Windows.Forms.RichTextBox chatBox;
        private Elegant.Ui.Panel panel4;
        private Elegant.Ui.Panel panel5;
        public System.Windows.Forms.PictureBox btnSend;
        public System.Windows.Forms.TextBox ReBox;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelChatStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}