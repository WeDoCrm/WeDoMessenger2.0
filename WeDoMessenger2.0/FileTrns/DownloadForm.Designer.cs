namespace Client
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.LabelFileName = new System.Windows.Forms.Label();
            this.ProgressBarFileRcv = new Elegant.Ui.ProgressBar();
            this.PanelFinishFileSave = new System.Windows.Forms.Panel();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.ButtonOpenDir = new System.Windows.Forms.Button();
            this.PanelRunFileSave = new System.Windows.Forms.Panel();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.TextBoxSaveDir = new Elegant.Ui.TextBox();
            this.ButtonSaveDir = new System.Windows.Forms.Button();
            this.ButtonSaveFile = new System.Windows.Forms.Button();
            this.ButtonCancelFile = new System.Windows.Forms.Button();
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.PanelFinishFileSave.SuspendLayout();
            this.PanelRunFileSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelFileName
            // 
            this.LabelFileName.Font = new System.Drawing.Font("돋움", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LabelFileName.Location = new System.Drawing.Point(14, 49);
            this.LabelFileName.Name = "LabelFileName";
            this.LabelFileName.Size = new System.Drawing.Size(321, 17);
            this.LabelFileName.TabIndex = 27;
            this.LabelFileName.Text = "파일명:Nihongo Drama 런치의 ..";
            this.LabelFileName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProgressBarFileRcv
            // 
            this.ProgressBarFileRcv.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBarFileRcv.DesiredWidth = 242;
            this.ProgressBarFileRcv.Id = "9ec3d021-b1aa-4dd0-a9cd-2e25957d42ef";
            this.ProgressBarFileRcv.Location = new System.Drawing.Point(61, 67);
            this.ProgressBarFileRcv.Name = "ProgressBarFileRcv";
            this.ProgressBarFileRcv.Size = new System.Drawing.Size(242, 20);
            this.ProgressBarFileRcv.TabIndex = 23;
            this.ProgressBarFileRcv.Text = "progressBar1";
            this.ProgressBarFileRcv.Visible = false;
            // 
            // PanelFinishFileSave
            // 
            this.PanelFinishFileSave.Controls.Add(this.ButtonOpenFile);
            this.PanelFinishFileSave.Controls.Add(this.ButtonOpenDir);
            this.PanelFinishFileSave.Location = new System.Drawing.Point(19, 164);
            this.PanelFinishFileSave.Name = "PanelFinishFileSave";
            this.PanelFinishFileSave.Size = new System.Drawing.Size(330, 92);
            this.PanelFinishFileSave.TabIndex = 26;
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(86, 12);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFile.TabIndex = 16;
            this.ButtonOpenFile.Text = "파일열기";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // ButtonOpenDir
            // 
            this.ButtonOpenDir.Location = new System.Drawing.Point(167, 12);
            this.ButtonOpenDir.Name = "ButtonOpenDir";
            this.ButtonOpenDir.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenDir.TabIndex = 15;
            this.ButtonOpenDir.Text = "폴더열기";
            this.ButtonOpenDir.UseVisualStyleBackColor = true;
            this.ButtonOpenDir.Click += new System.EventHandler(this.ButtonOpenDir_Click);
            // 
            // PanelRunFileSave
            // 
            this.PanelRunFileSave.Controls.Add(this.ButtonClose);
            this.PanelRunFileSave.Controls.Add(this.TextBoxSaveDir);
            this.PanelRunFileSave.Controls.Add(this.ButtonSaveDir);
            this.PanelRunFileSave.Controls.Add(this.ButtonSaveFile);
            this.PanelRunFileSave.Controls.Add(this.ButtonCancelFile);
            this.PanelRunFileSave.Location = new System.Drawing.Point(20, 87);
            this.PanelRunFileSave.Name = "PanelRunFileSave";
            this.PanelRunFileSave.Size = new System.Drawing.Size(330, 88);
            this.PanelRunFileSave.TabIndex = 25;
            // 
            // ButtonClose
            // 
            this.ButtonClose.AutoSize = true;
            this.ButtonClose.Location = new System.Drawing.Point(130, 12);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(87, 23);
            this.ButtonClose.TabIndex = 17;
            this.ButtonClose.Text = "취소";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Visible = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // TextBoxSaveDir
            // 
            this.TextBoxSaveDir.Id = "4f013c1e-00db-4fc4-97c4-440b24cb098f";
            this.TextBoxSaveDir.LabelText = "저장 폴더 : ";
            this.TextBoxSaveDir.Location = new System.Drawing.Point(9, 43);
            this.TextBoxSaveDir.Name = "TextBoxSaveDir";
            this.TextBoxSaveDir.Size = new System.Drawing.Size(274, 20);
            this.TextBoxSaveDir.TabIndex = 16;
            this.TextBoxSaveDir.TextEditorWidth = 201;
            // 
            // ButtonSaveDir
            // 
            this.ButtonSaveDir.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonSaveDir.Location = new System.Drawing.Point(287, 40);
            this.ButtonSaveDir.Name = "ButtonSaveDir";
            this.ButtonSaveDir.Size = new System.Drawing.Size(28, 23);
            this.ButtonSaveDir.TabIndex = 13;
            this.ButtonSaveDir.Text = "...";
            this.ButtonSaveDir.UseVisualStyleBackColor = true;
            this.ButtonSaveDir.Click += new System.EventHandler(this.ButtonSaveDir_Click);
            // 
            // ButtonSaveFile
            // 
            this.ButtonSaveFile.Location = new System.Drawing.Point(94, 12);
            this.ButtonSaveFile.Name = "ButtonSaveFile";
            this.ButtonSaveFile.Size = new System.Drawing.Size(63, 23);
            this.ButtonSaveFile.TabIndex = 14;
            this.ButtonSaveFile.Text = "저장";
            this.ButtonSaveFile.UseVisualStyleBackColor = true;
            this.ButtonSaveFile.Click += new System.EventHandler(this.ButtonSaveFile_Click);
            // 
            // ButtonCancelFile
            // 
            this.ButtonCancelFile.Location = new System.Drawing.Point(174, 12);
            this.ButtonCancelFile.Name = "ButtonCancelFile";
            this.ButtonCancelFile.Size = new System.Drawing.Size(63, 23);
            this.ButtonCancelFile.TabIndex = 15;
            this.ButtonCancelFile.Text = "취소";
            this.ButtonCancelFile.UseVisualStyleBackColor = true;
            this.ButtonCancelFile.Click += new System.EventHandler(this.ButtonCancelFile_Click);
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.Font = new System.Drawing.Font("돋움", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMainMessage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelMainMessage.Location = new System.Drawing.Point(20, 11);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(321, 31);
            this.labelMainMessage.TabIndex = 24;
            this.labelMainMessage.Text = "최진원님이 파일을 보내려고 합니다.\r\n파일을 저장하시겠습니까?";
            this.labelMainMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.Personal;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(365, 154);
            this.Controls.Add(this.LabelFileName);
            this.Controls.Add(this.ProgressBarFileRcv);
            this.Controls.Add(this.PanelFinishFileSave);
            this.Controls.Add(this.PanelRunFileSave);
            this.Controls.Add(this.labelMainMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 받음";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadForm_FormClosed);
            this.PanelFinishFileSave.ResumeLayout(false);
            this.PanelRunFileSave.ResumeLayout(false);
            this.PanelRunFileSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label LabelFileName;
        private Elegant.Ui.ProgressBar ProgressBarFileRcv;
        private System.Windows.Forms.Panel PanelFinishFileSave;
        public System.Windows.Forms.Button ButtonOpenFile;
        public System.Windows.Forms.Button ButtonOpenDir;
        private System.Windows.Forms.Panel PanelRunFileSave;
        public System.Windows.Forms.Button ButtonClose;
        private Elegant.Ui.TextBox TextBoxSaveDir;
        public System.Windows.Forms.Button ButtonSaveDir;
        public System.Windows.Forms.Button ButtonSaveFile;
        public System.Windows.Forms.Button ButtonCancelFile;
        public System.Windows.Forms.Label labelMainMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}