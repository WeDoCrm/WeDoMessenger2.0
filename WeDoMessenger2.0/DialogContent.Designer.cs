namespace Client
{
    partial class DialogContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogContent));
            this.richTextBoxNotice = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllCtrlCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxNotice
            // 
            this.richTextBoxNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBoxNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNotice.ContextMenuStrip = this.contextMenuStrip2;
            this.richTextBoxNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxNotice.Location = new System.Drawing.Point(2, 2);
            this.richTextBoxNotice.Name = "richTextBoxNotice";
            this.richTextBoxNotice.ReadOnly = true;
            this.richTextBoxNotice.Size = new System.Drawing.Size(280, 464);
            this.richTextBoxNotice.TabIndex = 2;
            this.richTextBoxNotice.Text = "";
            this.richTextBoxNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxNotice_KeyDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutCtrlCToolStripMenuItem2,
            this.CopyCtrlCToolStripMenuItem2,
            this.PasteCtrlCToolStripMenuItem2,
            this.toolStripSeparator2,
            this.SelectAllCtrlCToolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(136, 98);
            // 
            // CutCtrlCToolStripMenuItem2
            // 
            this.CutCtrlCToolStripMenuItem2.Enabled = false;
            this.CutCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.ID_EDIT_CUT_SMALL;
            this.CutCtrlCToolStripMenuItem2.Name = "CutCtrlCToolStripMenuItem2";
            this.CutCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.CutCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.CutCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.CutCtrlCToolStripMenuItem2.Text = "잘라내기(T)";
            // 
            // CopyCtrlCToolStripMenuItem2
            // 
            this.CopyCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.ID_EDIT_COPY_SMALL;
            this.CopyCtrlCToolStripMenuItem2.Name = "CopyCtrlCToolStripMenuItem2";
            this.CopyCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.CopyCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.CopyCtrlCToolStripMenuItem2.Text = "복사(C)";
            this.CopyCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.CopyCtrlCToolStripMenuItem2_Click);
            // 
            // PasteCtrlCToolStripMenuItem2
            // 
            this.PasteCtrlCToolStripMenuItem2.Enabled = false;
            this.PasteCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.pastesmall;
            this.PasteCtrlCToolStripMenuItem2.Name = "PasteCtrlCToolStripMenuItem2";
            this.PasteCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PasteCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.PasteCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.PasteCtrlCToolStripMenuItem2.Text = "붙여넣기(P)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // SelectAllCtrlCToolStripMenuItem2
            // 
            this.SelectAllCtrlCToolStripMenuItem2.Image = global::Client.Properties.Resources.AutomaticColor;
            this.SelectAllCtrlCToolStripMenuItem2.Name = "SelectAllCtrlCToolStripMenuItem2";
            this.SelectAllCtrlCToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllCtrlCToolStripMenuItem2.ShowShortcutKeys = false;
            this.SelectAllCtrlCToolStripMenuItem2.Size = new System.Drawing.Size(135, 22);
            this.SelectAllCtrlCToolStripMenuItem2.Text = "모두 선택(A)";
            this.SelectAllCtrlCToolStripMenuItem2.Click += new System.EventHandler(this.SelectAllCtrlCToolStripMenuItem2_Click);
            // 
            // DialogContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 468);
            this.Controls.Add(this.richTextBoxNotice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogContent";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "지난 대화보기";
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxNotice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem CutCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CopyCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem PasteCtrlCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SelectAllCtrlCToolStripMenuItem2;

    }
}