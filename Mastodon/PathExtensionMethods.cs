using Microsoft.AspNetCore.Http.Extensions;

namespace Mastodon;

public static class PathExtensionMethods
{
    public static string GetUrlPath(this ServerCallContext context, string path, bool omitQueryString = true)
    {
        return context.GetHttpContext().GetUrlPath(path);
    }

    public static string GetUrlPath(this HttpContext context, string path, bool omitQueryString = true)
    {
        var urlBuilder = new UriBuilder(context.Request.GetEncodedUrl());
        urlBuilder.Path = path;

        if (omitQueryString)
        {
            urlBuilder.Query = string.Empty;
        }

        return urlBuilder.Uri.ToString();
    }
}
