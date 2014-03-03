namespace Client
{
    partial class FindListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindListForm));
            this.txtbox_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbox_result
            // 
            this.txtbox_result.BackColor = System.Drawing.SystemColors.Window;
            this.txtbox_result.HideSelection = false;
            this.txtbox_result.Location = new System.Drawing.Point(3, 3);
            this.txtbox_result.Multiline = true;
            this.txtbox_result.Name = "txtbox_result";
            this.txtbox_result.ReadOnly = true;
            this.txtbox_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbox_result.Size = new System.Drawing.Size(435, 260);
            this.txtbox_result.TabIndex = 0;
            this.txtbox_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_result_KeyDown);
            // 
            // FindListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(438, 266);
            this.Controls.Add(this.txtbox_result);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "검색 결과";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtbox_result;
    }
}