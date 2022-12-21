using System.Net;

namespace Mastodon.Client;

public sealed class Response<T>
{
    public readonly HttpStatusCode StatusCode;
    public readonly T? Data;
    public readonly IDictionary<string, IEnumerable<string>> Headers;

    public Response(HttpStatusCode statusCode, T? data, IDictionary<string, IEnumerable<string>> headers)
    {
        Data = data;
        Headers = headers;
        StatusCode = statusCode;
    }

    public bool IsSuccessStatusCode
    {
        get { return ((int)StatusCode >= 200) && ((int)StatusCode <= 299); }
    }
}
