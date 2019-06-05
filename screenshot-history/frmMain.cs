using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScreenshotHistory
{
    public partial class frmMain : Form
    {
        private readonly FixedSizedQueue<Image> clipboardImageHistory = new FixedSizedQueue<Image>(2);

        public frmMain()
        {
            InitializeComponent();
            ClipboardHelper.AddClipboardFormatListener(this.Handle);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClipboardHelper.RemoveClipboardFormatListener(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case ClipboardHelper.WM_CLIPBOARDUPDATE:
                    EnqueueAndUpdate();
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void EnqueueAndUpdate()
        {
            Image image = Clipboard.GetImage();
            if (image == null)
            {
                return;
            }

            clipboardImageHistory.Enqueue(image);
            UpdatePictureBoxes();
        }

        private void UpdatePictureBoxes()
        {
            switch (clipboardImageHistory.Count)
            {
                case 0:
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    break;
                case 1:
                    pictureBox1.Image = clipboardImageHistory.ElementAt(0);
                    pictureBox2.Image = null;
                    break;
                case 2:
                    pictureBox1.Image = clipboardImageHistory.ElementAt(1);
                    pictureBox2.Image = clipboardImageHistory.ElementAt(0);
                    break;
            }
        }
    }
}
