using System.Collections;
using System.Collections.Generic;

namespace ScreenshotHistory;

// A queue that keeps only its most recent `size` items. Single-threaded: only
// ever touched from the UI thread via the clipboard message handler.
public sealed class FixedSizedQueue<T>(int size) : IEnumerable<T>
{
    private readonly Queue<T> queue = new();

    public int Count => queue.Count;

    public void Enqueue(T item)
    {
        queue.Enqueue(item);
        while (queue.Count > size)
        {
            queue.Dequeue();
        }
    }

    public IEnumerator<T> GetEnumerator() => queue.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
