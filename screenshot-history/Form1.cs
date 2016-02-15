using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenshotHistory
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;
        FixedSizedQueue<Image> history = new FixedSizedQueue<Image>(2);

        public Form1()
        {
            InitializeComponent();
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected void DisplayClipboardData()
        {
            var img = Clipboard.GetImage();
            if (img != null)
            {
                history.Enqueue(img);
            }
            UpdatePictureBoxes();
        }

        protected void UpdatePictureBoxes()
        {
            switch (history.Count)
            {
                case 0:
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    break;
                case 1:
                    pictureBox1.Image = history.ElementAt(0);
                    pictureBox2.Image = null;
                    break;
                case 2:
                    pictureBox1.Image = history.ElementAt(1);
                    pictureBox2.Image = history.ElementAt(0);
                    break;
            }
        }
    }
}
