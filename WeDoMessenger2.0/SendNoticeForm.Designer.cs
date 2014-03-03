using Client.PopUp;
namespace Client
{
    partial class SendNoticeForm : TopMostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendNoticeForm));
            this.formkey = new System.Windows.Forms.Label();
            this.BtnSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.ToggleButtonNormalNotice = new Elegant.Ui.ToggleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formkey
            // 
            this.formkey.AutoSize = true;
            this.formkey.Location = new System.Drawing.Point(11, 221);
            this.formkey.Name = "formkey";
            this.formkey.Size = new System.Drawing.Size(0, 12);
            this.formkey.TabIndex = 5;
            this.formkey.Visible = false;
            // 
            // BtnSend
            // 
            this.BtnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnSend.Location = new System.Drawing.Point(166, 3);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 15;
            this.BtnSend.Text = "공지등록";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxTitle);
            this.panel1.Controls.Add(this.ToggleButtonNormalNotice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 42);
            this.panel1.TabIndex = 17;
            // 
            // TextBoxTitle
            // 
            this.TextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxTitle.Location = new System.Drawing.Point(53, 14);
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.Size = new System.Drawing.Size(292, 21);
            this.TextBoxTitle.TabIndex = 19;
            // 
            // ToggleButtonNormalNotice
            // 
            this.ToggleButtonNormalNotice.Id = "7ce92836-65c8-4317-950f-2e4d07833ea8";
            this.ToggleButtonNormalNotice.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Disabled", global::Client.Properties.Resources.공지하기_이미지만),
            new Elegant.Ui.ControlImage("Focused", global::Client.Properties.Resources.공지하기_이미지만),
            new Elegant.Ui.ControlImage("Hovered", global::Client.Properties.Resources.공지하기_이미지만)});
            this.ToggleButtonNormalNotice.Location = new System.Drawing.Point(368, 12);
            this.ToggleButtonNormalNotice.Name = "ToggleButtonNormalNotice";
            this.ToggleButtonNormalNotice.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ToggleButtonNormalNotice.ScreenTip.Text = "일반공지";
            this.ToggleButtonNormalNotice.Size = new System.Drawing.Size(28, 24);
            this.ToggleButtonNormalNotice.SmallImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Client.Properties.Resources.Flag_green_icon16),
            new Elegant.Ui.ControlImage("Pressed", global::Client.Properties.Resources.Flag_red_icon16),
            new Elegant.Ui.ControlImage("PressedFocused", global::Client.Properties.Resources.Flag_red_icon16),
            new Elegant.Ui.ControlImage("PressedHovered", global::Client.Properties.Resources.Flag_red_icon16)});
            this.ToggleButtonNormalNotice.TabIndex = 18;
            this.ToggleButtonNormalNotice.Click += new System.EventHandler(this.ToggleButtonNormalNotice_PressedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "제 목 :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 28);
            this.panel2.TabIndex = 18;
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
            // richTextBoxContent
            // 
            this.richTextBoxContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBoxContent.ContextMenuStrip = this.contextMenuStrip2;
            this.richTextBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxContent.Location = new System.Drawing.Point(1, 43);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(407, 278);
            this.richTextBoxContent.TabIndex = 21;
            this.richTextBoxContent.Text = "";
            this.richTextBoxContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxContent_KeyDown);
            // 
            // SendNoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 350);
            this.Controls.Add(this.richTextBoxContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.formkey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(425, 373);
            this.Name = "SendNoticeForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "공지하기";
            this.TopMost = false;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label formkey;
        public System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox TextBoxTitle;
        private Elegant.Ui.ToggleButton ToggleButtonNormalNotice;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem CutCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CopyCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem PasteCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SelectAllCtrlCToolStripMenuItem2;
        private System.Windows.Forms.RichTextBox richTextBoxContent;
    }
}