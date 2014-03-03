namespace Client
{
    partial class SetAutoStartForm
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
            this.cbx_autostart = new System.Windows.Forms.CheckBox();
            this.cbx_topmost = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_nopop_outbound = new System.Windows.Forms.CheckBox();
            this.cbx_nopop = new System.Windows.Forms.CheckBox();
            this.pbx_confirm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_autostart
            // 
            this.cbx_autostart.AutoSize = true;
            this.cbx_autostart.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_autostart.Location = new System.Drawing.Point(21, 25);
            this.cbx_autostart.Name = "cbx_autostart";
            this.cbx_autostart.Size = new System.Drawing.Size(142, 15);
            this.cbx_autostart.TabIndex = 0;
            this.cbx_autostart.Text = "윈도우 시작시 자동실행";
            this.cbx_autostart.UseVisualStyleBackColor = true;
            // 
            // cbx_topmost
            // 
            this.cbx_topmost.AutoSize = true;
            this.cbx_topmost.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_topmost.Location = new System.Drawing.Point(21, 48);
            this.cbx_topmost.Name = "cbx_topmost";
            this.cbx_topmost.Size = new System.Drawing.Size(109, 15);
            this.cbx_topmost.TabIndex = 1;
            this.cbx_topmost.Text = "항상 위에 보이기";
            this.cbx_topmost.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_nopop_outbound);
            this.groupBox1.Controls.Add(this.cbx_nopop);
            this.groupBox1.Controls.Add(this.cbx_topmost);
            this.groupBox1.Controls.Add(this.cbx_autostart);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "일반";
            // 
            // cbx_nopop_outbound
            // 
            this.cbx_nopop_outbound.AutoSize = true;
            this.cbx_nopop_outbound.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_nopop_outbound.Location = new System.Drawing.Point(21, 94);
            this.cbx_nopop_outbound.Name = "cbx_nopop_outbound";
            this.cbx_nopop_outbound.Size = new System.Drawing.Size(138, 15);
            this.cbx_nopop_outbound.TabIndex = 3;
            this.cbx_nopop_outbound.Text = "아웃바운드시 팝업중지";
            this.cbx_nopop_outbound.UseVisualStyleBackColor = true;
            // 
            // cbx_nopop
            // 
            this.cbx_nopop.AutoSize = true;
            this.cbx_nopop.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbx_nopop.Location = new System.Drawing.Point(21, 71);
            this.cbx_nopop.Name = "cbx_nopop";
            this.cbx_nopop.Size = new System.Drawing.Size(127, 15);
            this.cbx_nopop.TabIndex = 2;
            this.cbx_nopop.Text = "고객정보창 팝업중지";
            this.cbx_nopop.UseVisualStyleBackColor = true;
            // 
            // pbx_confirm
            // 
            this.pbx_confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.pbx_confirm.Location = new System.Drawing.Point(144, 134);
            this.pbx_confirm.Name = "pbx_confirm";
            this.pbx_confirm.Size = new System.Drawing.Size(58, 25);
            this.pbx_confirm.TabIndex = 5;
            this.pbx_confirm.Text = "확인";
            this.pbx_confirm.UseVisualStyleBackColor = true;
            this.pbx_confirm.Click += new System.EventHandler(this.pbx_confirm_Click);
            // 
            // SetAutoStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 169);
            this.Controls.Add(this.pbx_confirm);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetAutoStartForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "기본설정";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox cbx_autostart;
        public System.Windows.Forms.CheckBox cbx_topmost;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button pbx_confirm;
        public System.Windows.Forms.CheckBox cbx_nopop;
        public System.Windows.Forms.CheckBox cbx_nopop_outbound;
    }
}