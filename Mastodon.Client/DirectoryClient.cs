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

    public Task<List<Account>?> GetDirectoryAsync()
    {
        return _client.http.GetFromJsonAsync<List<Account>>("api/v1/directory", MastodonClient._options);
    }
}

