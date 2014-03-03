namespace Client
{
    partial class NoReceiveBoardForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoReceiveBoardForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_notice = new System.Windows.Forms.Panel();
            this.label_notice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_memo = new System.Windows.Forms.Panel();
            this.label_memo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_trans = new System.Windows.Forms.Panel();
            this.label_trans = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.aquaSkin1 = new SkinSoft.AquaSkin.AquaSkin(this.components);
            this.panel1 = new Elegant.Ui.Panel();
            this.panel2 = new Elegant.Ui.Panel();
            this.dgv_notice = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_memo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_transfer = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_notice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_memo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_trans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_memo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transfer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_notice
            // 
            this.panel_notice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.panel_notice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_notice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_notice.Controls.Add(this.label_notice);
            this.panel_notice.Controls.Add(this.pictureBox1);
            this.panel_notice.Enabled = false;
            this.panel_notice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_notice.Location = new System.Drawing.Point(1, 2);
            this.panel_notice.Name = "panel_notice";
            this.panel_notice.Size = new System.Drawing.Size(135, 28);
            this.panel_notice.TabIndex = 1;
            this.panel_notice.MouseLeave += new System.EventHandler(this.panel_notice_MouseLeave);
            this.panel_notice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_notice_MouseClick);
            this.panel_notice.MouseEnter += new System.EventHandler(this.panel_notice_MouseEnter);
            // 
            // label_notice
            // 
            this.label_notice.AutoSize = true;
            this.label_notice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_notice.ForeColor = System.Drawing.Color.Black;
            this.label_notice.Location = new System.Drawing.Point(34, 6);
            this.label_notice.Name = "label_notice";
            this.label_notice.Size = new System.Drawing.Size(71, 15);
            this.label_notice.TabIndex = 1;
            this.label_notice.Text = "부재중 공지";
            this.label_notice.MouseLeave += new System.EventHandler(this.panel_notice_MouseLeave);
            this.label_notice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_notice_MouseClick);
            this.label_notice.MouseEnter += new System.EventHandler(this.panel_notice_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.panel_notice_MouseLeave);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_notice_MouseClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.panel_notice_MouseEnter);
            // 
            // panel_memo
            // 
            this.panel_memo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.panel_memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_memo.Controls.Add(this.label_memo);
            this.panel_memo.Controls.Add(this.pictureBox2);
            this.panel_memo.Enabled = false;
            this.panel_memo.Location = new System.Drawing.Point(1, 29);
            this.panel_memo.Name = "panel_memo";
            this.panel_memo.Size = new System.Drawing.Size(135, 28);
            this.panel_memo.TabIndex = 2;
            this.panel_memo.MouseLeave += new System.EventHandler(this.panel_memo_MouseLeave);
            this.panel_memo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_memo_MouseClick);
            this.panel_memo.MouseEnter += new System.EventHandler(this.panel_memo_MouseEnter);
            // 
            // label_memo
            // 
            this.label_memo.AutoSize = true;
            this.label_memo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_memo.ForeColor = System.Drawing.Color.Black;
            this.label_memo.Location = new System.Drawing.Point(33, 6);
            this.label_memo.Name = "label_memo";
            this.label_memo.Size = new System.Drawing.Size(71, 15);
            this.label_memo.TabIndex = 1;
            this.label_memo.Text = "부재중 쪽지";
            this.label_memo.MouseLeave += new System.EventHandler(this.panel_memo_MouseLeave);
            this.label_memo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_memo_MouseClick);
            this.label_memo.MouseEnter += new System.EventHandler(this.panel_memo_MouseEnter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseLeave += new System.EventHandler(this.panel_memo_MouseLeave);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_memo_MouseClick);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.panel_memo_MouseEnter);
            // 
            // panel_trans
            // 
            this.panel_trans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.panel_trans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_trans.Controls.Add(this.label_trans);
            this.panel_trans.Controls.Add(this.pictureBox4);
            this.panel_trans.Enabled = false;
            this.panel_trans.Location = new System.Drawing.Point(1, 56);
            this.panel_trans.Name = "panel_trans";
            this.panel_trans.Size = new System.Drawing.Size(135, 28);
            this.panel_trans.TabIndex = 4;
            this.panel_trans.MouseLeave += new System.EventHandler(this.panel_trans_MouseLeave);
            this.panel_trans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_trans_MouseClick);
            this.panel_trans.MouseEnter += new System.EventHandler(this.panel_trans_MouseEnter);
            // 
            // label_trans
            // 
            this.label_trans.AutoSize = true;
            this.label_trans.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_trans.ForeColor = System.Drawing.Color.Black;
            this.label_trans.Location = new System.Drawing.Point(33, 6);
            this.label_trans.Name = "label_trans";
            this.label_trans.Size = new System.Drawing.Size(71, 15);
            this.label_trans.TabIndex = 1;
            this.label_trans.Text = "부재중 업무";
            this.label_trans.MouseLeave += new System.EventHandler(this.panel_trans_MouseLeave);
            this.label_trans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_trans_MouseClick);
            this.label_trans.MouseEnter += new System.EventHandler(this.panel_trans_MouseEnter);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseLeave += new System.EventHandler(this.panel_trans_MouseLeave);
            this.pictureBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_trans_MouseClick);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.panel_trans_MouseEnter);
            // 
            // aquaSkin1
            // 
            this.aquaSkin1.AquaStyle = SkinSoft.AquaSkin.AquaStyle.Panther;
            this.aquaSkin1.License = ((SkinSoft.AquaSkin.Licensing.AquaSkinLicense)(resources.GetObject("aquaSkin1.License")));
            this.aquaSkin1.ShadowStyle = SkinSoft.AquaSkin.ShadowStyle.Small;
            this.aquaSkin1.ToolStripStyle = SkinSoft.AquaSkin.ToolStripRenderStyle.Mixed;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_trans);
            this.panel1.Controls.Add(this.panel_notice);
            this.panel1.Controls.Add(this.panel_memo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 162);
            this.panel1.TabIndex = 8;
            this.panel1.Text = "panel1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgv_notice);
            this.panel2.Controls.Add(this.dgv_memo);
            this.panel2.Controls.Add(this.dgv_transfer);
            this.panel2.Location = new System.Drawing.Point(139, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 162);
            this.panel2.TabIndex = 9;
            this.panel2.Text = "panel2";
            // 
            // dgv_notice
            // 
            this.dgv_notice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_notice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_notice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.title,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_notice.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_notice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_notice.Location = new System.Drawing.Point(0, 0);
            this.dgv_notice.Name = "dgv_notice";
            this.dgv_notice.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_notice.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_notice.RowHeadersVisible = false;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_notice.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_notice.RowTemplate.Height = 23;
            this.dgv_notice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_notice.ShowEditingIcon = false;
            this.dgv_notice.Size = new System.Drawing.Size(569, 162);
            this.dgv_notice.TabIndex = 9;
            this.dgv_notice.Visible = false;
            this.dgv_notice.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_notice_CellMouseClick);
            // 
            // type
            // 
            this.type.HeaderText = "종류";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 50;
            // 
            // title
            // 
            this.title.HeaderText = "제 목";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "내  용";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "보낸사람";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "보낸시각";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dgv_memo
            // 
            this.dgv_memo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_memo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_memo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_memo.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_memo.Location = new System.Drawing.Point(0, 0);
            this.dgv_memo.Name = "dgv_memo";
            this.dgv_memo.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_memo.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgv_memo.RowHeadersVisible = false;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_memo.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_memo.RowTemplate.Height = 23;
            this.dgv_memo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_memo.ShowEditingIcon = false;
            this.dgv_memo.Size = new System.Drawing.Size(569, 162);
            this.dgv_memo.TabIndex = 8;
            this.dgv_memo.Visible = false;
            this.dgv_memo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_memo_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "보낸사람";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "보낸시각";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 210;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "내  용";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 350;
            // 
            // dgv_transfer
            // 
            this.dgv_transfer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_transfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv_transfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.ani,
            this.sender});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_transfer.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgv_transfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_transfer.Location = new System.Drawing.Point(0, 0);
            this.dgv_transfer.Name = "dgv_transfer";
            this.dgv_transfer.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_transfer.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_transfer.RowHeadersVisible = false;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_transfer.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_transfer.RowTemplate.Height = 23;
            this.dgv_transfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transfer.ShowEditingIcon = false;
            this.dgv_transfer.Size = new System.Drawing.Size(569, 162);
            this.dgv_transfer.TabIndex = 11;
            this.dgv_transfer.Visible = false;
            this.dgv_transfer.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_transfer_CellMouseClick);
            // 
            // time
            // 
            this.time.HeaderText = "이 관 시 각";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 200;
            // 
            // ani
            // 
            this.ani.HeaderText = "전화번호";
            this.ani.Name = "ani";
            this.ani.ReadOnly = true;
            this.ani.Width = 150;
            // 
            // sender
            // 
            this.sender.FillWeight = 150F;
            this.sender.HeaderText = "보 낸 사 람";
            this.sender.Name = "sender";
            this.sender.ReadOnly = true;
            this.sender.Width = 150;
            // 
            // NoReceiveBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(708, 162);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 200);
            this.Name = "NoReceiveBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부재중 메시지 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoReceiveBoardForm_FormClosing);
            this.panel_notice.ResumeLayout(false);
            this.panel_notice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_memo.ResumeLayout(false);
            this.panel_memo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_trans.ResumeLayout(false);
            this.panel_trans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aquaSkin1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_memo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transfer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel_notice;
        public System.Windows.Forms.Label label_notice;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panel_memo;
        public System.Windows.Forms.Label label_memo;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Panel panel_trans;
        public System.Windows.Forms.Label label_trans;
        public System.Windows.Forms.PictureBox pictureBox4;
        private SkinSoft.AquaSkin.AquaSkin aquaSkin1;
        private Elegant.Ui.NavigationBarItem navigationBarItem1;
        private Elegant.Ui.NavigationBarItem navigationBarItem2;
        private Elegant.Ui.NavigationBarItem navigationBarItem3;
        private Elegant.Ui.Panel panel1;
        private Elegant.Ui.Panel panel2;
        public System.Windows.Forms.DataGridView dgv_transfer;
        public System.Windows.Forms.DataGridView dgv_notice;
        public System.Windows.Forms.DataGridView dgv_memo;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ani;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender;


    }
}