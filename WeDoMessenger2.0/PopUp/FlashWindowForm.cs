using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Client.PopUp
{
    public partial class FlashWindowForm : Form
    {
        [DllImport("user32")]
        private static extern int FlashWindow(System.IntPtr hdl, int bInvert);
        public Timer _TimerFlashWindow = new Timer();

        public FlashWindowForm()
        {
            InitializeComponent();
            _TimerFlashWindow.Interval = 1000;
            _TimerFlashWindow.Tick += new EventHandler(_TimerFlash_Tick);
            TopMost = true;
            _TimerFlashWindow.Start();
        }

        private void _TimerFlash_Tick(object sender, EventArgs e)
        {
            _FlashWindow();
        }

        public void DoFlashWindow()
        {
            Show();
            _TimerFlashWindow.Start();
        }

        private int _FlashWindow()
        {
            return FlashWindow(this.Handle, 1);
        }

        public void StopFlash()
        {
            _TimerFlashWindow.Stop();
        }

        private void FlashWindowForm_Activated(object sender, EventArgs e)
        {
            StopFlash();
        }

        private void FlashWindowForm_Deactivate(object sender, EventArgs e)
        {
            TopMost = false;
        }

        private void FlashWindowForm_FormClosing(object sender, FormClosingEventArgs e) {
            _TimerFlashWindow.Stop();
        }

        protected override void OnClosed(EventArgs e) {
            UnhookControl(this as System.Windows.Forms.Control);
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            HookControl(this as System.Windows.Forms.Control);
        }

        private void HookControl(System.Windows.Forms.Control controlToHook) {
            controlToHook.MouseClick += AllControlsMouseClick;
            foreach (System.Windows.Forms.Control ctl in controlToHook.Controls) {
                HookControl(ctl);
            }
        }

        private void UnhookControl(System.Windows.Forms.Control controlToUnhook) {
            controlToUnhook.MouseClick -= AllControlsMouseClick;
            foreach (System.Windows.Forms.Control ctl in controlToUnhook.Controls) {
                UnhookControl(ctl);
            }
        }

        void AllControlsMouseClick(object sender, MouseEventArgs e) {
            Console.WriteLine("AllControlsMouseClick:" + sender.ToString());
            _TimerFlashWindow.Stop();
        }

    }
}
