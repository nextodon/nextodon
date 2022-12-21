using Grpc.Core;
using Mastodon.Client;

namespace Mastodon;

public static class ProxyExtensionMethods
{
    public static Task WriteHeadersTo<T>(this Response<T> response, ServerCallContext context)
    {
        var metadata = new Metadata();
        var headers = response.Headers;

        if (headers.TryGetValue("link", out var links))
        {
            foreach (var value in links)
            {
                metadata.Add("link", value);
            }
        }

        return context.WriteResponseHeadersAsync(metadata);
    }

    public static void SetDefaults(this MastodonClient client, ServerCallContext context)
    {
        var headers = context.GetHttpContext().Request.Headers;

        client.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", headers.Authorization.ToString());
    }
}
