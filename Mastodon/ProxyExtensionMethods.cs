﻿using Grpc.Core;
using Mastodon.Client;
using Microsoft.AspNetCore.Http.Extensions;

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

    public static void SetDefaults(this MastodonClient client, HttpContext context)
    {
        var headers = context.Request.Headers;

        client.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", headers.Authorization.ToString());
    }

    public static void SetDefaults(this MastodonClient client, ServerCallContext context)
    {
        client.SetDefaults(context.GetHttpContext());
    }

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

    public static void RaiseExceptions<T>(this Response<T> resp)
    {
        if (!resp.IsSuccessStatusCode)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.Internal, $"{resp.Reason} ({resp.StatusCode})"));
        }
    }
}
