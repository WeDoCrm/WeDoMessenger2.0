namespace Client
{
    partial class NotReadMemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotReadMemoForm));
            this.listView = new System.Windows.Forms.ListView();
            this.show = new System.Windows.Forms.ColumnHeader();
            this.sender = new System.Windows.Forms.ColumnHeader();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.content = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.show,
            this.sender,
            this.time,
            this.content});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(5, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(385, 192);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // show
            // 
            this.show.Text = "보 기";
            this.show.Width = 49;
            // 
            // sender
            // 
            this.sender.Text = "보낸사람";
            this.sender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sender.Width = 83;
            // 
            // time
            // 
            this.time.Text = "보낸 시각";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time.Width = 126;
            // 
            // content
            // 
            this.content.Text = "내  용";
            this.content.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.content.Width = 123;
            // 
            // NotReadMemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 198);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(391, 217);
            this.Name = "NotReadMemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "읽지 않은 쪽지";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.NotReadMemoForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader show;
        public System.Windows.Forms.ColumnHeader sender;
        public System.Windows.Forms.ColumnHeader time;
        public System.Windows.Forms.ColumnHeader content;

    }
}