namespace Client
{
    partial class SendFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendFileForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_filename = new System.Windows.Forms.Label();
            this.label_filesize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_FileReceiver = new System.Windows.Forms.TextBox();
            this.label_result = new System.Windows.Forms.Label();
            this.ButtonFileSelect = new System.Windows.Forms.Button();
            this.ButtonFTPStart = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.progressBarSendFile = new Elegant.Ui.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "전송 파일 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "파일 크기 :";
            // 
            // label_filename
            // 
            this.label_filename.Location = new System.Drawing.Point(79, 38);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(190, 12);
            this.label_filename.TabIndex = 6;
            // 
            // label_filesize
            // 
            this.label_filesize.Location = new System.Drawing.Point(79, 60);
            this.label_filesize.Name = "label_filesize";
            this.label_filesize.Size = new System.Drawing.Size(190, 12);
            this.label_filesize.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "전송 결과 :";
            // 
            // txtbox_FileReceiver
            // 
            this.txtbox_FileReceiver.Location = new System.Drawing.Point(81, 12);
            this.txtbox_FileReceiver.Name = "txtbox_FileReceiver";
            this.txtbox_FileReceiver.ReadOnly = true;
            this.txtbox_FileReceiver.Size = new System.Drawing.Size(131, 21);
            this.txtbox_FileReceiver.TabIndex = 9;
            // 
            // label_result
            // 
            this.label_result.Location = new System.Drawing.Point(79, 82);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(190, 12);
            this.label_result.TabIndex = 11;
            // 
            // ButtonFileSelect
            // 
            this.ButtonFileSelect.Location = new System.Drawing.Point(284, 33);
            this.ButtonFileSelect.Name = "ButtonFileSelect";
            this.ButtonFileSelect.Size = new System.Drawing.Size(51, 23);
            this.ButtonFileSelect.TabIndex = 13;
            this.ButtonFileSelect.Text = "찾기";
            this.ButtonFileSelect.UseVisualStyleBackColor = true;
            this.ButtonFileSelect.Click += new System.EventHandler(this.ButtonFileSelect_Click);
            // 
            // ButtonFTPStart
            // 
            this.ButtonFTPStart.Location = new System.Drawing.Point(177, 117);
            this.ButtonFTPStart.Name = "ButtonFTPStart";
            this.ButtonFTPStart.Size = new System.Drawing.Size(76, 23);
            this.ButtonFTPStart.TabIndex = 18;
            this.ButtonFTPStart.Text = "파일전송";
            this.ButtonFTPStart.UseVisualStyleBackColor = true;
            this.ButtonFTPStart.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(95, 117);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(74, 23);
            this.ButtonCancel.TabIndex = 19;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // progressBarSendFile
            // 
            this.progressBarSendFile.DesiredWidth = 101;
            this.progressBarSendFile.Id = "a6ba9711-723c-4116-ad58-58da4014da97";
            this.progressBarSendFile.Location = new System.Drawing.Point(177, 82);
            this.progressBarSendFile.Name = "progressBarSendFile";
            this.progressBarSendFile.Size = new System.Drawing.Size(101, 13);
            this.progressBarSendFile.TabIndex = 20;
            this.progressBarSendFile.Text = "progressBar1";
            this.progressBarSendFile.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "열기";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "받는 사람 :";
            // 
            // SendFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 144);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarSendFile);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonFTPStart);
            this.Controls.Add(this.ButtonFileSelect);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.txtbox_FileReceiver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_filesize);
            this.Controls.Add(this.label_filename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(361, 182);
            this.MinimumSize = new System.Drawing.Size(361, 182);
            this.Name = "SendFileForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 보내기";
            this.Deactivate += new System.EventHandler(this.SendFileForm_Deactivate);
            this.Activated += new System.EventHandler(this.SendFileForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendFileForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label_filename;
        public System.Windows.Forms.Label label_filesize;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtbox_FileReceiver;
        public System.Windows.Forms.Label label_result;
        public System.Windows.Forms.Button ButtonFileSelect;
        public System.Windows.Forms.Button ButtonFTPStart;
        public System.Windows.Forms.Button ButtonCancel;
        private Elegant.Ui.ProgressBar progressBarSendFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.Label label4;
    }
}