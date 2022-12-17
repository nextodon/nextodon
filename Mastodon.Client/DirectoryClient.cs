using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class DirectoryClient
{
    private readonly MastodonClient _client;

    internal DirectoryClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="offset">Skip the first n results.</param>
    /// <param name="limit">How many accounts to load. Defaults to 40 accounts. Max 80 accounts.</param>
    /// <param name="order">Use active to sort by most recently posted statuses (default) or new to sort by most recently created profiles.</param>
    /// <param name="local">If true, returns only local accounts.</param>
    public Task<List<Account>?> GetDirectoryAsync(uint? offset = null, uint? limit = null, string? order = null, bool? local = null)
    {
        var q = new QueryBuilder();

        q.Add("offset", offset);
        q.Add("limit", limit);
        q.Add("order", order);
        q.Add("local", local);

        var url = q.GetUrl("api/v1/directory");

        return _client.http.GetFromJsonAsync<List<Account>>(url, MastodonClient._options);
    }
}

