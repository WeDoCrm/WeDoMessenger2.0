namespace Client
{
    partial class DialogListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogListForm));
            this.listView = new System.Windows.Forms.ListView();
            this.time = new System.Windows.Forms.ColumnHeader();
            this.parti = new System.Windows.Forms.ColumnHeader();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.parti});
            this.listView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MinimumSize = new System.Drawing.Size(200, 264);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(306, 265);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView_ItemCheck);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // time
            // 
            this.time.Text = "대화 시각";
            this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time.Width = 167;
            // 
            // parti
            // 
            this.parti.Text = "대 화 자";
            this.parti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.parti.Width = 135;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(243, 270);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(57, 25);
            this.btn_del.TabIndex = 9;
            this.btn_del.Text = "삭제";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(81, 271);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(71, 25);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "선택취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_cancel_MouseClick);
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(7, 271);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(71, 25);
            this.btn_all.TabIndex = 11;
            this.btn_all.Text = "전체선택";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_all_MouseClick);
            // 
            // DialogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 302);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "대 화 함";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.ColumnHeader time;
        public System.Windows.Forms.ColumnHeader parti;
        public System.Windows.Forms.Button btn_del;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_all;
    }
}