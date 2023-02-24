using System.Net;

namespace Mastodon.Client;

public sealed class Response<T> {
    public readonly HttpStatusCode StatusCode;
    public readonly T? Data;
    public readonly string? Reason;
    public readonly IDictionary<string, IEnumerable<string>> Headers;

    public Response(HttpStatusCode statusCode, T? data, IDictionary<string, IEnumerable<string>> headers, string? reason) {
        Data = data;
        Headers = headers;
        StatusCode = statusCode;
        Reason = reason;
    }

    public bool IsSuccessStatusCode {
        get { return ((int)StatusCode >= 200) && ((int)StatusCode <= 299); }
    }
}
