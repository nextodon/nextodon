using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Nextodon;

public sealed class EventSource<T, K> where K : notnull
{
    private readonly ConcurrentDictionary<K, Channel<T>> _data = new();

    public ICollection<K> Keys
    {
        get
        {
            return _data.Keys;
        }
    }

    public Channel<T> this[K id]
    {
        get
        {
            var ret = _data.GetOrAdd(id, (key) => Channel.CreateUnbounded<T>());

            return ret;
        }
    }
}
