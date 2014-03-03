namespace Client
{
    partial class SetExtensionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetExtensionForm));
            this.label_extension = new System.Windows.Forms.Label();
            this.tbx_extension = new System.Windows.Forms.TextBox();
            this.btn_ext_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_extension
            // 
            this.label_extension.AutoSize = true;
            this.label_extension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_extension.Location = new System.Drawing.Point(19, 29);
            this.label_extension.Name = "label_extension";
            this.label_extension.Size = new System.Drawing.Size(53, 12);
            this.label_extension.TabIndex = 0;
            this.label_extension.Text = "내선번호";
            // 
            // tbx_extension
            // 
            this.tbx_extension.Location = new System.Drawing.Point(79, 24);
            this.tbx_extension.Name = "tbx_extension";
            this.tbx_extension.Size = new System.Drawing.Size(100, 21);
            this.tbx_extension.TabIndex = 1;
            this.tbx_extension.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_extension_KeyDown);
            // 
            // btn_ext_confirm
            // 
            this.btn_ext_confirm.Location = new System.Drawing.Point(197, 22);
            this.btn_ext_confirm.Name = "btn_ext_confirm";
            this.btn_ext_confirm.Size = new System.Drawing.Size(55, 23);
            this.btn_ext_confirm.TabIndex = 3;
            this.btn_ext_confirm.Text = "확인";
            this.btn_ext_confirm.UseVisualStyleBackColor = true;
            this.btn_ext_confirm.Click += new System.EventHandler(this.btn_ext_confirm_Click);
            // 
            // SetExtensionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 66);
            this.Controls.Add(this.btn_ext_confirm);
            this.Controls.Add(this.tbx_extension);
            this.Controls.Add(this.label_extension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetExtensionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "내선번호 설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_extension;
        public System.Windows.Forms.TextBox tbx_extension;
        public System.Windows.Forms.Button btn_ext_confirm;
    }
}