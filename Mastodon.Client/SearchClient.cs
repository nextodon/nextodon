namespace Mastodon.Client;

public sealed class SearchClient
{
    private readonly MastodonClient _client;

    internal SearchClient(MastodonClient client)
    {
        _client = client;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="q">The search query.</param>
    /// <param name="type">Specify whether to search for only accounts, hashtags, statuses.</param>
    /// <param name="resolve">Attempt WebFinger lookup? Defaults to false.</param>
    /// <param name="following">Only include accounts that the user is following? Defaults to false.</param>
    /// <param name="accountId">If provided, will only return statuses authored by this account.</param>
    /// <param name="excludeUnreviewed">Filter out unreviewed tags? Defaults to false. Use true when trying to find trending tags.</param>
    /// <param name="maxId">Return results older than this ID.</param>
    /// <param name="minId">Return results immediately newer than this ID.</param>
    /// <param name="limit">Maximum number of results to return, per type. Defaults to 20 results per category. Max 40 results per category.</param>
    /// <param name="offset">Skip the first n results.</param>
    public Task<Response<Search>> Search(string q, string? type = null, bool? resolve = null, bool? following = null, string? accountId = null, bool? excludeUnreviewed = null, string? maxId = null, string? minId = null, uint? limit = null, uint? offset = null)
    {
        var qb = new QueryBuilder();

        qb.Add("q", q);
        qb.Add("type", type);
        qb.Add("resolve", resolve);
        qb.Add("following", following);
        qb.Add("account_id", accountId);
        qb.Add("exclude_unreviewed", excludeUnreviewed);
        qb.Add("max_id", maxId);
        qb.Add("min_id", minId);
        qb.Add("limit", limit);
        qb.Add("offset", offset);

        var url = qb.GetUrl("api/v2/search");

        return _client.HttpClient.GetFromJsonWithHeadersAsync<Search>(url, MastodonClient._options);
    }
}
