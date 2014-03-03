namespace Client
{
    partial class DownloadResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadResultForm));
            this.label_sender = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_filename = new System.Windows.Forms.Label();
            this.label_fullname = new System.Windows.Forms.Label();
            this.ButtonOpenDir = new System.Windows.Forms.Button();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.formFrameSkinner = new Elegant.Ui.FormFrameSkinner();
            this.SuspendLayout();
            // 
            // label_sender
            // 
            this.label_sender.AutoSize = true;
            this.label_sender.Font = new System.Drawing.Font("돋움체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_sender.Location = new System.Drawing.Point(95, 18);
            this.label_sender.Name = "label_sender";
            this.label_sender.Size = new System.Drawing.Size(0, 14);
            this.label_sender.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("돋움", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(93, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "다음과 같은 파일을 받았습니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("돋움체", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "파일명 :";
            // 
            // label_filename
            // 
            this.label_filename.Font = new System.Drawing.Font("돋움체", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_filename.ForeColor = System.Drawing.Color.Black;
            this.label_filename.Location = new System.Drawing.Point(88, 72);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(265, 14);
            this.label_filename.TabIndex = 3;
            // 
            // label_fullname
            // 
            this.label_fullname.AutoSize = true;
            this.label_fullname.Location = new System.Drawing.Point(293, 120);
            this.label_fullname.Name = "label_fullname";
            this.label_fullname.Size = new System.Drawing.Size(0, 12);
            this.label_fullname.TabIndex = 6;
            this.label_fullname.Visible = false;
            // 
            // ButtonOpenDir
            // 
            this.ButtonOpenDir.Location = new System.Drawing.Point(102, 106);
            this.ButtonOpenDir.Name = "ButtonOpenDir";
            this.ButtonOpenDir.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenDir.TabIndex = 9;
            this.ButtonOpenDir.Text = "폴더열기";
            this.ButtonOpenDir.UseVisualStyleBackColor = true;
            this.ButtonOpenDir.Click += new System.EventHandler(this.btn_opendir_Click);
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(186, 106);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFile.TabIndex = 10;
            this.ButtonOpenFile.Text = "파일열기";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.btn_openfile_Click);
            // 
            // formFrameSkinner
            // 
            this.formFrameSkinner.Form = this;
            // 
            // DownloadResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(365, 141);
            this.Controls.Add(this.ButtonOpenFile);
            this.Controls.Add(this.ButtonOpenDir);
            this.Controls.Add(this.label_fullname);
            this.Controls.Add(this.label_filename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_sender);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(381, 179);
            this.MinimumSize = new System.Drawing.Size(381, 179);
            this.Name = "DownloadResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 받음";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_sender;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label_filename;
        public System.Windows.Forms.Label label_fullname;
        public System.Windows.Forms.Button ButtonOpenDir;
        public System.Windows.Forms.Button ButtonOpenFile;
        private Elegant.Ui.FormFrameSkinner formFrameSkinner;
    }
}