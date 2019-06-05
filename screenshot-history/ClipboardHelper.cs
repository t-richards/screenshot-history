using System;
using System.Runtime.InteropServices;

namespace ScreenshotHistory
{
    class ClipboardHelper
    {
        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        /// <param name="hwnd">A handle to the window to be placed in the clipboard format listener list.</param>
        /// <returns>Returns TRUE if successful, FALSE otherwise. Call GetLastError for additional details.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        /// <param name="hwnd">A handle to the window to remove from the clipboard format listener list.</param>
        /// <returns>Returns TRUE if successful, FALSE otherwise. Call GetLastError for additional details.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        public const int WM_CLIPBOARDUPDATE = 0x031D;
    }
}
