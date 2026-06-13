using System.Collections;

namespace ScreenshotHistory;

// A queue that keeps only its most recent `size` items, invoking the optional
// `onEvict` callback on each item as it falls off the end (e.g. to dispose it).
// Single-threaded: only ever touched from the UI thread via the clipboard
// message handler.
public sealed class FixedSizedQueue<T>(int size, Action<T> onEvict = null) : IEnumerable<T>
{
    private readonly Queue<T> queue = new();

    public int Count => queue.Count;

    public void Enqueue(T item)
    {
        queue.Enqueue(item);
        while (queue.Count > size)
        {
            onEvict?.Invoke(queue.Dequeue());
        }
    }

    public IEnumerator<T> GetEnumerator() => queue.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
