namespace Client
{
    partial class NotReceiveFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotReceiveFileForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.download = new System.Windows.Forms.ColumnHeader();
            this.filename = new System.Windows.Forms.ColumnHeader();
            this.sender = new System.Windows.Forms.ColumnHeader();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.filesize = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.download,
            this.filename,
            this.sender,
            this.time,
            this.filesize});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(2, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(385, 182);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // download
            // 
            this.download.Text = "받 기";
            this.download.Width = 44;
            // 
            // filename
            // 
            this.filename.Text = "파일명";
            this.filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filename.Width = 115;
            // 
            // sender
            // 
            this.sender.Text = "보낸사람";
            this.sender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sender.Width = 78;
            // 
            // time
            // 
            this.time.Text = "전 송 시 각";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time.Width = 88;
            // 
            // filesize
            // 
            this.filesize.Text = "크 기";
            this.filesize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NotReceiveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 185);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(394, 211);
            this.Name = "NotReceiveFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "부재중 파일";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.NotReceiveFileForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotReceiveFileForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader download;
        public System.Windows.Forms.ColumnHeader filename;
        public System.Windows.Forms.ColumnHeader sender;
        public System.Windows.Forms.ColumnHeader time;
        public System.Windows.Forms.ColumnHeader filesize;
    }
}