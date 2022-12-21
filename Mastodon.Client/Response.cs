namespace Mastodon.Client;

public sealed class Response<T>
{
    public readonly T? Data;
    public readonly IDictionary<string, IEnumerable<string>> Headers;

    public Response(T? data, IDictionary<string, IEnumerable<string>> headers)
    {
        Data = data;
        Headers = headers;
    }
}
