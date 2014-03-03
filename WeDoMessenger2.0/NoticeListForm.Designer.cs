namespace Client
{
    partial class NoticeListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_all = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.mode = new System.Windows.Forms.ColumnHeader();
            this.title = new System.Windows.Forms.ColumnHeader();
            this.content = new System.Windows.Forms.ColumnHeader();
            this.sender = new System.Windows.Forms.ColumnHeader();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_all);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.btn_del);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 29);
            this.panel1.TabIndex = 16;
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(13, 3);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(75, 25);
            this.btn_all.TabIndex = 16;
            this.btn_all.Text = "전체선택";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_all_MouseClick);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(94, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 25);
            this.cancel.TabIndex = 17;
            this.cancel.Text = "선택취소";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cancel_MouseClick);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(565, 3);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 25);
            this.btn_del.TabIndex = 15;
            this.btn_del.Text = "삭제";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(652, 296);
            this.panel3.TabIndex = 17;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mode,
            this.title,
            this.content,
            this.sender,
            this.time});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(652, 296);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 15;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // mode
            // 
            this.mode.Text = "종 류";
            this.mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mode.Width = 51;
            // 
            // title
            // 
            this.title.Text = "제   목";
            this.title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.title.Width = 120;
            // 
            // content
            // 
            this.content.Text = "       내  용";
            this.content.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.content.Width = 271;
            // 
            // sender
            // 
            this.sender.Text = "보낸 사람";
            this.sender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sender.Width = 82;
            // 
            // time
            // 
            this.time.Text = "보낸 시각";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time.Width = 119;
            // 
            // NoticeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 325);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(668, 363);
            this.MinimumSize = new System.Drawing.Size(668, 363);
            this.Name = "NoticeListForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "공지사항 목록 ( 검색 : Ctrl+F )";
            this.Load += new System.EventHandler(this.NoticeListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btn_all;
        public System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader mode;
        public System.Windows.Forms.ColumnHeader title;
        public System.Windows.Forms.ColumnHeader content;
        public System.Windows.Forms.ColumnHeader sender;
        public System.Windows.Forms.ColumnHeader time;


    }
}