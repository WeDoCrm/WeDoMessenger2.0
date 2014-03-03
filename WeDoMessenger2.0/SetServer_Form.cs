using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using WeDoCommon;

namespace Client
{
	/// <summary>
	/// SetServer_Form에 대한 요약 설명입니다.
	/// </summary>
	public class SetServer_Form : System.Windows.Forms.Form
    {
        public Button btnSetting;
        public GroupBox groupBox2;
        public Label label3;
        public TextBox tbx_ip3;
        public TextBox tbx_ip2;
        public Label label2;
        public TextBox tbx_ip1;
        public Label label4;
        public TextBox tbx_ip4;
        public RadioButton rbt_ip;
        public RadioButton rbt_local;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SetServer_Form()
		{
			InitializeComponent();
            Initialize();
		}

        private void Initialize()
        {
            string[] iparr = null;

            if (ConfigHelper.ServerIp.Equals("localhost"))
            {
                rbt_local.Checked = true;
            }
            else
            {
                rbt_ip.Checked = true;
                iparr = ConfigHelper.ServerIp.Split('.');
                if (iparr.Length > 3)
                {
                    tbx_ip1.Text = iparr[0];
                    tbx_ip2.Text = iparr[1];
                    tbx_ip3.Text = iparr[2];
                    tbx_ip4.Text = iparr[3];
                }
                else
                {
                    Logger.error("serverIP 값이 올바르지 않음 : " + ConfigHelper.ServerIp);
                }
            }

        }

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetServer_Form));
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_ip = new System.Windows.Forms.RadioButton();
            this.rbt_local = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_ip4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_ip3 = new System.Windows.Forms.TextBox();
            this.tbx_ip2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_ip1 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetting.Location = new System.Drawing.Point(112, 108);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "확 인";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_ip);
            this.groupBox2.Controls.Add(this.rbt_local);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbx_ip4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbx_ip3);
            this.groupBox2.Controls.Add(this.tbx_ip2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbx_ip1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 83);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "서버설정";
            // 
            // rbt_ip
            // 
            this.rbt_ip.AutoSize = true;
            this.rbt_ip.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbt_ip.Location = new System.Drawing.Point(16, 47);
            this.rbt_ip.Name = "rbt_ip";
            this.rbt_ip.Size = new System.Drawing.Size(34, 16);
            this.rbt_ip.TabIndex = 12;
            this.rbt_ip.TabStop = true;
            this.rbt_ip.Text = "IP";
            this.rbt_ip.UseVisualStyleBackColor = true;
            this.rbt_ip.CheckedChanged += new System.EventHandler(this.rbt_ip_CheckedChanged);
            // 
            // rbt_local
            // 
            this.rbt_local.AutoSize = true;
            this.rbt_local.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbt_local.Location = new System.Drawing.Point(16, 20);
            this.rbt_local.Name = "rbt_local";
            this.rbt_local.Size = new System.Drawing.Size(136, 16);
            this.rbt_local.TabIndex = 11;
            this.rbt_local.TabStop = true;
            this.rbt_local.Text = "내 컴퓨터(localhost)";
            this.rbt_local.UseVisualStyleBackColor = true;
            this.rbt_local.CheckedChanged += new System.EventHandler(this.rbt_local_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = ".";
            // 
            // tbx_ip4
            // 
            this.tbx_ip4.Enabled = false;
            this.tbx_ip4.Location = new System.Drawing.Point(227, 45);
            this.tbx_ip4.Name = "tbx_ip4";
            this.tbx_ip4.Size = new System.Drawing.Size(36, 21);
            this.tbx_ip4.TabIndex = 3;
            this.tbx_ip4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbx_ip4_MouseClick);
            this.tbx_ip4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_ip4_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = ".";
            // 
            // tbx_ip3
            // 
            this.tbx_ip3.Enabled = false;
            this.tbx_ip3.Location = new System.Drawing.Point(170, 45);
            this.tbx_ip3.Name = "tbx_ip3";
            this.tbx_ip3.Size = new System.Drawing.Size(36, 21);
            this.tbx_ip3.TabIndex = 2;
            this.tbx_ip3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbx_ip3_MouseClick);
            this.tbx_ip3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_ip3_KeyPress);
            // 
            // tbx_ip2
            // 
            this.tbx_ip2.Enabled = false;
            this.tbx_ip2.Location = new System.Drawing.Point(113, 45);
            this.tbx_ip2.Name = "tbx_ip2";
            this.tbx_ip2.Size = new System.Drawing.Size(36, 21);
            this.tbx_ip2.TabIndex = 1;
            this.tbx_ip2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbx_ip2_MouseClick);
            this.tbx_ip2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_ip2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = ".";
            // 
            // tbx_ip1
            // 
            this.tbx_ip1.Enabled = false;
            this.tbx_ip1.Location = new System.Drawing.Point(56, 45);
            this.tbx_ip1.Name = "tbx_ip1";
            this.tbx_ip1.Size = new System.Drawing.Size(36, 21);
            this.tbx_ip1.TabIndex = 0;
            this.tbx_ip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbx_ip1_MouseClick);
            this.tbx_ip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_ip1_KeyPress);
            // 
            // SetServer_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(300, 138);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetServer_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "서버 설정";
            this.TopMost = true;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void tbx_ip4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.'))
            {
                e.KeyChar = new char();
                btnSetting.Focus();
            }
            else if (tbx_ip4.Text.Trim().Length == 3)
            {
                if (tbx_ip4.SelectionLength == 0)
                {
                    btnSetting.Focus();
                    e.KeyChar = new char();

                }
            }
        }

        private void tbx_ip1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.'))
            {
                e.KeyChar = new char();
                tbx_ip2.Focus();
            }
            else if (tbx_ip1.Text.Trim().Length == 3)
            {
                if (tbx_ip1.SelectionLength == 0)
                {
                    tbx_ip2.Focus();
                    tbx_ip2.Text = e.KeyChar.ToString();
                    e.KeyChar = new char();

                }
            }
        }

        private void tbx_ip2_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar.Equals('.'))
            {
                e.KeyChar = new char();
                tbx_ip3.Focus();
            }
            else if (tbx_ip2.Text.Trim().Length == 3)
            {
                if (tbx_ip2.SelectionLength == 0)
                {
                    tbx_ip3.Focus();
                    tbx_ip3.Text = e.KeyChar.ToString();
                    e.KeyChar = new char();
                    
                }
            }
        }

        private void tbx_ip3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.'))
            {
                e.KeyChar = new char();
                tbx_ip4.Focus();
            }
            else if (tbx_ip3.Text.Trim().Length == 3)
            {
                if (tbx_ip3.SelectionLength == 0)
                {
                    tbx_ip4.Focus();
                    tbx_ip4.Text = e.KeyChar.ToString();
                    e.KeyChar = new char();

                }
            }
        }

        private void tbx_ip1_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_ip1.SelectAll();
        }

        private void tbx_ip2_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_ip2.SelectAll();
        }

        private void tbx_ip3_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_ip3.SelectAll();
        }

        private void tbx_ip4_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_ip4.SelectAll();
        }

        private void rbt_local_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_local.Checked == true)
            {
                rbt_ip.Checked = false;
                tbx_ip1.Text = "";
                tbx_ip1.Enabled = false;
                tbx_ip2.Text = "";
                tbx_ip2.Enabled = false;
                tbx_ip3.Text = "";
                tbx_ip3.Enabled = false;
                tbx_ip4.Text = "";
                tbx_ip4.Enabled = false;
                
            }
        }

        private void rbt_ip_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_ip.Checked == true)
            {
                rbt_local.Checked = false;
                tbx_ip1.Enabled = true;
                tbx_ip2.Enabled = true;
                tbx_ip3.Enabled = true;
                tbx_ip4.Enabled = true;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.info("Set server ip 실행!");
                string tempip = "";
                if (rbt_ip.Checked == true)
                {
                    tempip = string.Format("{0}.{1}.{2}.{3}"
                        , tbx_ip1.Text
                        , tbx_ip2.Text
                        , tbx_ip3.Text
                        , tbx_ip4.Text);
                }
                else
                {
                    tempip = "localhost";
                }
                ConfigHelper.ServerIp = tempip;
                Close();
            }
            catch (Exception exception)
            {
                Logger.error(exception.ToString());
            }
        }
		
	}
}
