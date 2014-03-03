namespace Client
{
    partial class MissedCallForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissedCallForm));
            this.label_missed = new System.Windows.Forms.Label();
            this.label_callcount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_missed
            // 
            this.label_missed.AutoSize = true;
            this.label_missed.BackColor = System.Drawing.Color.Transparent;
            this.label_missed.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_missed.ForeColor = System.Drawing.Color.Black;
            this.label_missed.Location = new System.Drawing.Point(54, 27);
            this.label_missed.Name = "label_missed";
            this.label_missed.Size = new System.Drawing.Size(114, 25);
            this.label_missed.TabIndex = 2;
            this.label_missed.Text = "부재중 전화";
            // 
            // label_callcount
            // 
            this.label_callcount.AutoSize = true;
            this.label_callcount.BackColor = System.Drawing.Color.Transparent;
            this.label_callcount.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_callcount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label_callcount.Location = new System.Drawing.Point(54, 68);
            this.label_callcount.Name = "label_callcount";
            this.label_callcount.Size = new System.Drawing.Size(62, 25);
            this.label_callcount.TabIndex = 3;
            this.label_callcount.Text = "0 Call";
            // 
            // MissedCallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(220, 120);
            this.Controls.Add(this.label_callcount);
            this.Controls.Add(this.label_missed);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MissedCallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MissedCallForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_missed;
        public System.Windows.Forms.Label label_callcount;
    }
}