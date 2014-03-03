namespace Client
{
    partial class AddMemberForm
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
            this.ListBoxSource = new System.Windows.Forms.ListBox();
            this.ListBoxSelected = new System.Windows.Forms.ListBox();
            this.ButtonAddUser = new System.Windows.Forms.Button();
            this.ButtonRemoveUser = new System.Windows.Forms.Button();
            this.RadioButtonConnectedUserOnly = new System.Windows.Forms.RadioButton();
            this.RadioButtonAll = new System.Windows.Forms.RadioButton();
            this.GroupBoxMode = new System.Windows.Forms.GroupBox();
            this.RadioButtonListByTeam = new System.Windows.Forms.RadioButton();
            this.ComboBoxTeam = new System.Windows.Forms.ComboBox();
            this.label_choice = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.PanelTeam = new System.Windows.Forms.Panel();
            this.GroupBoxMode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelMain.SuspendLayout();
            this.PanelTeam.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxSource
            // 
            this.ListBoxSource.FormattingEnabled = true;
            this.ListBoxSource.ItemHeight = 12;
            this.ListBoxSource.Location = new System.Drawing.Point(5, 23);
            this.ListBoxSource.Name = "ListBoxSource";
            this.ListBoxSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxSource.Size = new System.Drawing.Size(110, 208);
            this.ListBoxSource.TabIndex = 0;
            this.ListBoxSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSource_MouseDoubleClick);
            // 
            // ListBoxSelected
            // 
            this.ListBoxSelected.FormattingEnabled = true;
            this.ListBoxSelected.ItemHeight = 12;
            this.ListBoxSelected.Location = new System.Drawing.Point(151, 23);
            this.ListBoxSelected.Name = "ListBoxSelected";
            this.ListBoxSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxSelected.Size = new System.Drawing.Size(110, 208);
            this.ListBoxSelected.TabIndex = 1;
            // 
            // ButtonAddUser
            // 
            this.ButtonAddUser.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonAddUser.Location = new System.Drawing.Point(119, 82);
            this.ButtonAddUser.Name = "ButtonAddUser";
            this.ButtonAddUser.Size = new System.Drawing.Size(29, 25);
            this.ButtonAddUser.TabIndex = 2;
            this.ButtonAddUser.Text = ">>";
            this.ButtonAddUser.UseVisualStyleBackColor = true;
            this.ButtonAddUser.Click += new System.EventHandler(this.ButtonAddUser_Click);
            // 
            // ButtonRemoveUser
            // 
            this.ButtonRemoveUser.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonRemoveUser.Location = new System.Drawing.Point(119, 129);
            this.ButtonRemoveUser.Name = "ButtonRemoveUser";
            this.ButtonRemoveUser.Size = new System.Drawing.Size(29, 25);
            this.ButtonRemoveUser.TabIndex = 3;
            this.ButtonRemoveUser.Text = "<<";
            this.ButtonRemoveUser.UseVisualStyleBackColor = true;
            this.ButtonRemoveUser.Click += new System.EventHandler(this.ButtonRemoveUser_Click);
            // 
            // RadioButtonConnectedUserOnly
            // 
            this.RadioButtonConnectedUserOnly.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RadioButtonConnectedUserOnly.Location = new System.Drawing.Point(158, 20);
            this.RadioButtonConnectedUserOnly.Name = "RadioButtonConnectedUserOnly";
            this.RadioButtonConnectedUserOnly.Size = new System.Drawing.Size(87, 18);
            this.RadioButtonConnectedUserOnly.TabIndex = 8;
            this.RadioButtonConnectedUserOnly.Text = "접속자";
            this.RadioButtonConnectedUserOnly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonConnectedUserOnly.UseCompatibleTextRendering = true;
            this.RadioButtonConnectedUserOnly.UseVisualStyleBackColor = true;
            this.RadioButtonConnectedUserOnly.Click += new System.EventHandler(this.RadioButtonConnectedUserOnly_Click);
            // 
            // RadioButtonAll
            // 
            this.RadioButtonAll.Checked = true;
            this.RadioButtonAll.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RadioButtonAll.Location = new System.Drawing.Point(14, 20);
            this.RadioButtonAll.Name = "RadioButtonAll";
            this.RadioButtonAll.Size = new System.Drawing.Size(63, 18);
            this.RadioButtonAll.TabIndex = 9;
            this.RadioButtonAll.TabStop = true;
            this.RadioButtonAll.Text = "전체";
            this.RadioButtonAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonAll.UseCompatibleTextRendering = true;
            this.RadioButtonAll.UseVisualStyleBackColor = true;
            this.RadioButtonAll.Click += new System.EventHandler(this.RadioButtonAll_Click);
            // 
            // GroupBoxMode
            // 
            this.GroupBoxMode.Controls.Add(this.RadioButtonListByTeam);
            this.GroupBoxMode.Controls.Add(this.RadioButtonAll);
            this.GroupBoxMode.Controls.Add(this.RadioButtonConnectedUserOnly);
            this.GroupBoxMode.Location = new System.Drawing.Point(7, 4);
            this.GroupBoxMode.Name = "GroupBoxMode";
            this.GroupBoxMode.Size = new System.Drawing.Size(265, 46);
            this.GroupBoxMode.TabIndex = 10;
            this.GroupBoxMode.TabStop = false;
            this.GroupBoxMode.Text = "목록 보기";
            // 
            // RadioButtonListByTeam
            // 
            this.RadioButtonListByTeam.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RadioButtonListByTeam.Location = new System.Drawing.Point(90, 20);
            this.RadioButtonListByTeam.Name = "RadioButtonListByTeam";
            this.RadioButtonListByTeam.Size = new System.Drawing.Size(52, 18);
            this.RadioButtonListByTeam.TabIndex = 10;
            this.RadioButtonListByTeam.Text = "팀별";
            this.RadioButtonListByTeam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RadioButtonListByTeam.UseCompatibleTextRendering = true;
            this.RadioButtonListByTeam.UseVisualStyleBackColor = true;
            this.RadioButtonListByTeam.Click += new System.EventHandler(this.RadioButtonListByTeam_Click);
            // 
            // ComboBoxTeam
            // 
            this.ComboBoxTeam.FormattingEnabled = true;
            this.ComboBoxTeam.Location = new System.Drawing.Point(57, 3);
            this.ComboBoxTeam.Name = "ComboBoxTeam";
            this.ComboBoxTeam.Size = new System.Drawing.Size(109, 20);
            this.ComboBoxTeam.TabIndex = 11;
            this.ComboBoxTeam.SelectedValueChanged += new System.EventHandler(this.ComboBoxTeam_SelectedValueChanged);
            // 
            // label_choice
            // 
            this.label_choice.AutoSize = true;
            this.label_choice.Location = new System.Drawing.Point(5, 7);
            this.label_choice.Name = "label_choice";
            this.label_choice.Size = new System.Drawing.Size(45, 12);
            this.label_choice.TabIndex = 12;
            this.label_choice.Text = "팀 선택";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(135, 236);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(55, 24);
            this.ButtonCancel.TabIndex = 15;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonCancel_MouseClick);
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Location = new System.Drawing.Point(74, 236);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(55, 24);
            this.ButtonConfirm.TabIndex = 16;
            this.ButtonConfirm.Text = "확인";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 20);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "추가가능";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(151, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 20);
            this.panel2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "추가된 명단";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.panel2);
            this.PanelMain.Controls.Add(this.ButtonAddUser);
            this.PanelMain.Controls.Add(this.panel1);
            this.PanelMain.Controls.Add(this.ListBoxSource);
            this.PanelMain.Controls.Add(this.ButtonConfirm);
            this.PanelMain.Controls.Add(this.ListBoxSelected);
            this.PanelMain.Controls.Add(this.ButtonCancel);
            this.PanelMain.Controls.Add(this.ButtonRemoveUser);
            this.PanelMain.Location = new System.Drawing.Point(7, 80);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(265, 263);
            this.PanelMain.TabIndex = 21;
            // 
            // PanelTeam
            // 
            this.PanelTeam.Controls.Add(this.label_choice);
            this.PanelTeam.Controls.Add(this.ComboBoxTeam);
            this.PanelTeam.Location = new System.Drawing.Point(7, 50);
            this.PanelTeam.Name = "PanelTeam";
            this.PanelTeam.Size = new System.Drawing.Size(265, 28);
            this.PanelTeam.TabIndex = 22;
            // 
            // AddMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 346);
            this.Controls.Add(this.GroupBoxMode);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelTeam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddMemberForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 추가";
            this.TopMost = true;
            this.GroupBoxMode.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.PanelMain.ResumeLayout(false);
            this.PanelTeam.ResumeLayout(false);
            this.PanelTeam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox ListBoxSource;
        public System.Windows.Forms.ListBox ListBoxSelected;
        public System.Windows.Forms.Button ButtonAddUser;
        public System.Windows.Forms.Button ButtonRemoveUser;
        public System.Windows.Forms.RadioButton RadioButtonConnectedUserOnly;
        public System.Windows.Forms.RadioButton RadioButtonAll;
        public System.Windows.Forms.GroupBox GroupBoxMode;
        public System.Windows.Forms.RadioButton RadioButtonListByTeam;
        public System.Windows.Forms.ComboBox ComboBoxTeam;
        public System.Windows.Forms.Label label_choice;
        public System.Windows.Forms.Button ButtonCancel;
        public System.Windows.Forms.Button ButtonConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelTeam;
    }
}