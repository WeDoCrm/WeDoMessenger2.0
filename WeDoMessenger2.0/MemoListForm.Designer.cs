namespace Client
{
    partial class MemoListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoListForm));
            this.listView = new System.Windows.Forms.ListView();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.sender = new System.Windows.Forms.ColumnHeader();
            this.content = new System.Windows.Forms.ColumnHeader();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.sender,
            this.content});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(388, 286);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // time
            // 
            this.time.Text = "보낸 시각";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time.Width = 119;
            // 
            // sender
            // 
            this.sender.Text = "보낸 사람";
            this.sender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sender.Width = 82;
            // 
            // content
            // 
            this.content.Text = "내  용";
            this.content.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.content.Width = 182;
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.Location = new System.Drawing.Point(325, 291);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(55, 25);
            this.btn_del.TabIndex = 12;
            this.btn_del.Text = "삭제";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_del_MouseClick);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancel.Location = new System.Drawing.Point(85, 291);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(68, 25);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "선택취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_cancel_MouseClick);
            // 
            // btn_all
            // 
            this.btn_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_all.Location = new System.Drawing.Point(11, 291);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(68, 25);
            this.btn_all.TabIndex = 14;
            this.btn_all.Text = "전체선택";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_all_MouseClick);
            // 
            // MemoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(388, 320);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemoListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "받은 쪽지 목록";
            this.SizeChanged += new System.EventHandler(this.MemoListForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader time;
        public System.Windows.Forms.ColumnHeader sender;
        public System.Windows.Forms.ColumnHeader content;
        public System.Windows.Forms.Button btn_del;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_all;
    }
}