namespace Client
{
    partial class Notice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notice));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCtrlCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.LabelNoticeSender = new Elegant.Ui.Label();
            this.label_sender = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.RichTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_confirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 28);
            this.panel1.TabIndex = 25;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_confirm.Location = new System.Drawing.Point(170, 2);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 19;
            this.btn_confirm.Text = "확인";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxTitle);
            this.panel2.Controls.Add(this.LabelNoticeSender);
            this.panel2.Controls.Add(this.label_sender);
            this.panel2.Controls.Add(this.label_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 50);
            this.panel2.TabIndex = 26;
            // 
            // TextBoxTitle
            // 
            this.TextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTitle.Location = new System.Drawing.Point(61, 9);
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.ReadOnly = true;
            this.TextBoxTitle.Size = new System.Drawing.Size(351, 14);
            this.TextBoxTitle.TabIndex = 28;
            // 
            // LabelNoticeSender
            // 
            this.LabelNoticeSender.Location = new System.Drawing.Point(61, 28);
            this.LabelNoticeSender.Name = "LabelNoticeSender";
            this.LabelNoticeSender.Size = new System.Drawing.Size(208, 19);
            this.LabelNoticeSender.TabIndex = 27;
            this.LabelNoticeSender.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_sender
            // 
            this.label_sender.AutoSize = true;
            this.label_sender.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_sender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_sender.Location = new System.Drawing.Point(3, 30);
            this.label_sender.Name = "label_sender";
            this.label_sender.Size = new System.Drawing.Size(54, 12);
            this.label_sender.TabIndex = 26;
            this.label_sender.Text = "게시자 :";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_title.Location = new System.Drawing.Point(5, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(51, 12);
            this.label_title.TabIndex = 25;
            this.label_title.Text = "제  목 :";
            // 
            // RichTextBoxContent
            // 
            this.RichTextBoxContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RichTextBoxContent.ContextMenuStrip = this.contextMenuStrip1;
            this.RichTextBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxContent.Location = new System.Drawing.Point(1, 51);
            this.RichTextBoxContent.Name = "RichTextBoxContent";
            this.RichTextBoxContent.ReadOnly = true;
            this.RichTextBoxContent.Size = new System.Drawing.Size(415, 195);
            this.RichTextBoxContent.TabIndex = 27;
            this.RichTextBoxContent.Text = "";
            this.RichTextBoxContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxContent_KeyDown);
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 275);
            this.Controls.Add(this.RichTextBoxContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(433, 313);
            this.Name = "Notice";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "공지사항";
            this.Activated += new System.EventHandler(this.Notice_Activated);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CutCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CopyCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PasteCtrlCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SelectAllCtrlCToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TextBoxTitle;
        private Elegant.Ui.Label LabelNoticeSender;
        public System.Windows.Forms.Label label_sender;
        public System.Windows.Forms.Label label_title;
        private System.Windows.Forms.RichTextBox RichTextBoxContent;
    }
}