using Grpc.Core;
using Mastodon.Client;

namespace Mastodon;

public static class ProxyExtensionMethods
{
    public static Task WriteHeadersTo<T>(this Response<T> response, ServerCallContext context)
    {
        var metadata = new Metadata();

        foreach (var header in response.Headers)
        {
            foreach (var value in header.Value)
            {
                metadata.Add(header.Key, value);
            }
        }

        return context.WriteResponseHeadersAsync(metadata);
    }

    public static void SetHeaders(this MastodonClient client, ServerCallContext context)
    {
        var headers = context.GetHttpContext().Request.Headers;

        foreach (var header in headers)
        {
            foreach (var value in header.Value)
            {
                client.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, value);
            }
        }
    }
}
