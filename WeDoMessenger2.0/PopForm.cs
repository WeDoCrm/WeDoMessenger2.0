using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeDoCommon;

namespace Client
{
    public partial class PopForm : Form
    {
        private int screenWidth = 0;
        private int screenHeight = 0;
        private bool isActivation = false;
        private System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public PopForm()
        {
            InitializeComponent();
            t1.Interval = 10000;
            t1.Tick += new EventHandler(t1_Tick); 
            t1.Start();
        }

        //protected override bool ShowWithoutActivation { get; }

        //public override bool Focused { get;}

        private void PopForm_Load(object sender, EventArgs e)
        {
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.SetBounds(screenWidth - this.Width, screenHeight - this.Height, this.Width, this.Height);
        }

        private void PopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            t1.Stop();
        }


        private void t1_Tick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Logger.error(ex.ToString());
            }
        }

    }
}
