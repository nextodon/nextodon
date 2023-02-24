namespace Mastodon.Client;

public sealed class ListClient {
    private readonly MastodonClient _client;

    internal ListClient(MastodonClient client) {
        _client = client;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="offset">Skip the first n results.</param>
    /// <param name="limit">How many accounts to load. Defaults to 40 accounts. Max 80 accounts.</param>
    /// <param name="order">Use active to sort by most recently posted statuses (default) or new to sort by most recently created profiles.</param>
    /// <param name="local">If true, returns only local accounts.</param>
    public Task<List<List>?> GetListsAsync() {
        return _client.HttpClient.GetFromJsonAsync<List<List>>("api/v1/lists", MastodonClient._options);
    }
}

