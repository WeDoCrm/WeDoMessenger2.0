namespace Client
{
    partial class TransferNotiForm
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
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_from = new System.Windows.Forms.Label();
            this.label_ani = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_senderid = new System.Windows.Forms.Label();
            this.pbx_icon = new System.Windows.Forms.PictureBox();
            this.pbx_close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_close)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Customer
            // 
            this.label_Customer.AutoSize = true;
            this.label_Customer.BackColor = System.Drawing.Color.Transparent;
            this.label_Customer.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Customer.ForeColor = System.Drawing.Color.Black;
            this.label_Customer.Location = new System.Drawing.Point(46, 6);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(167, 15);
            this.label_Customer.TabIndex = 0;
            this.label_Customer.Text = "[이름 or 번호] 고객 상담 이관";
            this.label_Customer.MouseLeave += new System.EventHandler(this.TransferNotiForm_MouseLeave);
            this.label_Customer.MouseEnter += new System.EventHandler(this.TransferNotiForm_MouseEnter);
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.BackColor = System.Drawing.Color.Transparent;
            this.label_from.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_from.ForeColor = System.Drawing.Color.Blue;
            this.label_from.Location = new System.Drawing.Point(61, 25);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(35, 13);
            this.label_from.TabIndex = 1;
            this.label_from.Text = "from ";
            this.label_from.MouseLeave += new System.EventHandler(this.TransferNotiForm_MouseLeave);
            this.label_from.MouseEnter += new System.EventHandler(this.TransferNotiForm_MouseEnter);
            // 
            // label_ani
            // 
            this.label_ani.AutoSize = true;
            this.label_ani.Location = new System.Drawing.Point(5, 25);
            this.label_ani.Name = "label_ani";
            this.label_ani.Size = new System.Drawing.Size(0, 12);
            this.label_ani.TabIndex = 2;
            this.label_ani.Visible = false;
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(26, 25);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(0, 12);
            this.label_date.TabIndex = 3;
            this.label_date.Visible = false;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(51, 25);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(0, 12);
            this.label_time.TabIndex = 4;
            this.label_time.Visible = false;
            // 
            // label_senderid
            // 
            this.label_senderid.AutoSize = true;
            this.label_senderid.Location = new System.Drawing.Point(11, 27);
            this.label_senderid.Name = "label_senderid";
            this.label_senderid.Size = new System.Drawing.Size(0, 12);
            this.label_senderid.TabIndex = 5;
            this.label_senderid.Visible = false;
            // 
            // pbx_icon
            // 
            this.pbx_icon.Location = new System.Drawing.Point(7, 6);
            this.pbx_icon.Name = "pbx_icon";
            this.pbx_icon.Size = new System.Drawing.Size(33, 31);
            this.pbx_icon.TabIndex = 6;
            this.pbx_icon.TabStop = false;
            this.pbx_icon.MouseLeave += new System.EventHandler(this.TransferNotiForm_MouseLeave);
            this.pbx_icon.MouseEnter += new System.EventHandler(this.TransferNotiForm_MouseEnter);
            // 
            // pbx_close
            // 
            this.pbx_close.Image = global::Client.Properties.Resources.Close_icon16;
            this.pbx_close.Location = new System.Drawing.Point(222, 3);
            this.pbx_close.Name = "pbx_close";
            this.pbx_close.Size = new System.Drawing.Size(16, 16);
            this.pbx_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx_close.TabIndex = 7;
            this.pbx_close.TabStop = false;
            this.pbx_close.Visible = false;
            this.pbx_close.MouseLeave += new System.EventHandler(this.pbx_close_MouseLeave);
            this.pbx_close.MouseEnter += new System.EventHandler(this.pbx_close_MouseEnter);
            // 
            // TransferNotiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(220)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(241, 43);
            this.Controls.Add(this.pbx_close);
            this.Controls.Add(this.pbx_icon);
            this.Controls.Add(this.label_senderid);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_ani);
            this.Controls.Add(this.label_from);
            this.Controls.Add(this.label_Customer);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransferNotiForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TransferNotiForm";
            this.MouseEnter += new System.EventHandler(this.TransferNotiForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TransferNotiForm_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_Customer;
        public System.Windows.Forms.Label label_from;
        public System.Windows.Forms.Label label_ani;
        public System.Windows.Forms.Label label_date;
        public System.Windows.Forms.Label label_time;
        public System.Windows.Forms.Label label_senderid;
        public System.Windows.Forms.PictureBox pbx_icon;
        public System.Windows.Forms.PictureBox pbx_close;
    }
}