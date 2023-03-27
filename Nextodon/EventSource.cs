using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Nextodon;

public sealed class EventSource<T>
{
    private readonly ConcurrentDictionary<string, Channel<T>> _data = new();

    public ICollection<string> Keys
    {
        get
        {
            return _data.Keys;
        }
    }

    public Channel<T> this[string id]
    {
        get
        {
            var ret = _data.GetOrAdd(id, (key) => Channel.CreateUnbounded<T>());

            return ret;
        }
    }
}
