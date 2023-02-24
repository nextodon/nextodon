namespace Mastodon.Client;

public sealed class TimelineClient {
    private readonly MastodonClient _client;

    internal TimelineClient(MastodonClient client) {
        _client = client;
    }

    /// <summary>
    /// View public statuses.
    /// </summary>
    public Task<Response<List<Status>>> GetPublicAsync(bool local, bool remote, bool onlyMedia, string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null) {
        var q = new QueryBuilder();

        q.Add("local", local);
        q.Add("remote", remote);
        q.Add("only_media", onlyMedia);
        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl("api/v1/timelines/public");

        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// View statuses from followed users.
    /// </summary>
    public Task<List<Status>?> GetHomeAsync(string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null) {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl("api/v1/timelines/home");

        return _client.HttpClient.GetFromJsonAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// View public statuses containing the given hashtag.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    public Task<List<Status>?> GetTagAsync(string hashtag) {
        return _client.HttpClient.GetFromJsonAsync<List<Status>>($"api/v1/timelines/tag/{hashtag}", MastodonClient._options);
    }

    /// <summary>
    /// View statuses in the given list timeline.
    /// </summary>
    /// <param name="listId">Local ID of the List in the database.</param>
    public Task<List<Status>?> GetListAsync(string listId, string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null) {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl($"api/v1/timelines/list/{listId}");

        return _client.HttpClient.GetFromJsonAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// View statuses with a “direct” privacy, from your account or in your notifications.
    /// </summary>
    [Obsolete]
    public Task<List<Status>?> GetDirectAsync(string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null) {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl("api/v1/timelines/direct");

        return _client.HttpClient.GetFromJsonAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// View public statuses.
    /// </summary>
    public Task<List<Status>?> GetTrendsAsync() {
        return _client.HttpClient.GetFromJsonAsync<List<Status>>("api/v1/trends/statuses", MastodonClient._options);
    }
}
