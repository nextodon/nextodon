using Microsoft.AspNetCore.Http.Extensions;

namespace Nextodon;

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

    public static string GetHost(this ServerCallContext context)
    {
        return context.GetHttpContext().GetHost();
    }

    public static string GetHost(this HttpContext context)
    {
        var urlBuilder = new UriBuilder(context.Request.GetEncodedUrl());

        return urlBuilder.Uri.Host;
    }
}
