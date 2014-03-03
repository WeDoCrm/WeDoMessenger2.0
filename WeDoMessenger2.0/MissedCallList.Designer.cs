namespace Client
{
    partial class MissedCallList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissedCallList));
            this.dgv_missedcall = new System.Windows.Forms.DataGridView();
            this.CALL_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALL_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_missedcall)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_missedcall
            // 
            this.dgv_missedcall.BackgroundColor = System.Drawing.Color.White;
            this.dgv_missedcall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_missedcall.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CALL_TIME,
            this.CALL_NUM,
            this.CUSTOMER_NM});
            this.dgv_missedcall.Location = new System.Drawing.Point(1, 2);
            this.dgv_missedcall.Name = "dgv_missedcall";
            this.dgv_missedcall.RowTemplate.Height = 23;
            this.dgv_missedcall.Size = new System.Drawing.Size(419, 150);
            this.dgv_missedcall.TabIndex = 0;
            // 
            // CALL_TIME
            // 
            this.CALL_TIME.HeaderText = "시   간";
            this.CALL_TIME.Name = "CALL_TIME";
            // 
            // CALL_NUM
            // 
            this.CALL_NUM.HeaderText = "전 화 번 호";
            this.CALL_NUM.Name = "CALL_NUM";
            // 
            // CUSTOMER_NM
            // 
            this.CUSTOMER_NM.HeaderText = "고 객 명";
            this.CUSTOMER_NM.Name = "CUSTOMER_NM";
            // 
            // MissedCallList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 154);
            this.Controls.Add(this.dgv_missedcall);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MissedCallList";
            this.Text = "부재중 전화";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_missedcall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_missedcall;
        public System.Windows.Forms.DataGridViewTextBoxColumn CALL_TIME;
        public System.Windows.Forms.DataGridViewTextBoxColumn CALL_NUM;
        public System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NM;
    }
}