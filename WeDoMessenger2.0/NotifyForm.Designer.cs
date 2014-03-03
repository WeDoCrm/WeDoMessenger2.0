namespace Client
{
    partial class NotifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyForm));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_sender = new System.Windows.Forms.Label();
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_ani = new System.Windows.Forms.Label();
            this.label_TONGDATE = new System.Windows.Forms.Label();
            this.label_TONGTIME = new System.Windows.Forms.Label();
            this.label_senderid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(97, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(66, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "상담건이 이관되었습니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "고 객 : ";
            // 
            // label_sender
            // 
            this.label_sender.AutoSize = true;
            this.label_sender.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_sender.Location = new System.Drawing.Point(66, 57);
            this.label_sender.Name = "label_sender";
            this.label_sender.Size = new System.Drawing.Size(34, 12);
            this.label_sender.TabIndex = 4;
            this.label_sender.Text = "From";
            // 
            // label_Customer
            // 
            this.label_Customer.AutoSize = true;
            this.label_Customer.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Customer.Location = new System.Drawing.Point(108, 33);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(61, 15);
            this.label_Customer.TabIndex = 5;
            this.label_Customer.Text = "Unknown";
            // 
            // label_ani
            // 
            this.label_ani.AutoSize = true;
            this.label_ani.Location = new System.Drawing.Point(8, 89);
            this.label_ani.Name = "label_ani";
            this.label_ani.Size = new System.Drawing.Size(0, 12);
            this.label_ani.TabIndex = 6;
            this.label_ani.Visible = false;
            // 
            // label_TONGDATE
            // 
            this.label_TONGDATE.AutoSize = true;
            this.label_TONGDATE.Location = new System.Drawing.Point(38, 89);
            this.label_TONGDATE.Name = "label_TONGDATE";
            this.label_TONGDATE.Size = new System.Drawing.Size(0, 12);
            this.label_TONGDATE.TabIndex = 7;
            this.label_TONGDATE.Visible = false;
            // 
            // label_TONGTIME
            // 
            this.label_TONGTIME.AutoSize = true;
            this.label_TONGTIME.Location = new System.Drawing.Point(66, 89);
            this.label_TONGTIME.Name = "label_TONGTIME";
            this.label_TONGTIME.Size = new System.Drawing.Size(0, 12);
            this.label_TONGTIME.TabIndex = 8;
            this.label_TONGTIME.Visible = false;
            // 
            // label_senderid
            // 
            this.label_senderid.AutoSize = true;
            this.label_senderid.Location = new System.Drawing.Point(188, 84);
            this.label_senderid.Name = "label_senderid";
            this.label_senderid.Size = new System.Drawing.Size(0, 12);
            this.label_senderid.TabIndex = 9;
            this.label_senderid.Visible = false;
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 107);
            this.Controls.Add(this.label_senderid);
            this.Controls.Add(this.label_TONGTIME);
            this.Controls.Add(this.label_TONGDATE);
            this.Controls.Add(this.label_ani);
            this.Controls.Add(this.label_Customer);
            this.Controls.Add(this.label_sender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "알림";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NotifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label_sender;
        public System.Windows.Forms.Label label_Customer;
        public System.Windows.Forms.Label label_ani;
        public System.Windows.Forms.Label label_TONGDATE;
        public System.Windows.Forms.Label label_TONGTIME;
        public System.Windows.Forms.Label label_senderid;
    }
}