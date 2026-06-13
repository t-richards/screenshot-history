using System.Runtime.InteropServices;

namespace ScreenshotHistory;

/// <summary>
/// Shows the two most recent clipboard images side by side, newest on the left.
/// </summary>
public partial class MainForm : Form
{
    // Disposes each image as it falls out of the two-item history, releasing the
    // underlying GDI handle. Single-threaded: only touched from the UI thread's
    // clipboard message handler.
    private readonly FixedSizedQueue<Image> clipboardImageHistory =
        new FixedSizedQueue<Image>(2, image => image.Dispose());

    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        ClipboardHelper.AddClipboardFormatListener(Handle);
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        ClipboardHelper.RemoveClipboardFormatListener(Handle);
        base.OnHandleDestroyed(e);
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
        Image image;
        try
        {
            image = Clipboard.GetImage();
        }
        catch (ExternalException)
        {
            return; // Another process held the clipboard open; skip this update.
        }

        if (image is null)
        {
            return;
        }

        clipboardImageHistory.Enqueue(image);
        UpdatePictureBoxes();
    }

    private void UpdatePictureBoxes()
    {
        Image[] images = [.. clipboardImageHistory.Reverse()]; // newest first
        latestPictureBox.Image = images.ElementAtOrDefault(0);
        previousPictureBox.Image = images.ElementAtOrDefault(1);
    }
}
