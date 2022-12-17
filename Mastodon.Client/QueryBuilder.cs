using Mastodon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastodon.Client;

internal sealed class QueryBuilder
{
    private readonly List<string> q = new();

    public void Add(string name, uint? value)
    {
        if (value != null && value != 0)
        {
            q.Add($"{name}={value}");
        }
    }

    public void Add(string name, bool? value)
    {
        if (value != null)
        {
            q.Add($"{name}={value?.ToString().ToLower()}");
        }
    }

    public void Add(string name, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            q.Add($"{name}={value}");
        }
    }

    public string GetUrl(string originalUrl)
    {
        var b = new UriBuilder("https://localhost");

        var all = string.Join("&", q);

        b.Path = originalUrl;
        b.Query = all;

        var u = new Uri(b.ToString(), UriKind.RelativeOrAbsolute);

        return u.PathAndQuery.Trim('/');
    }
}
