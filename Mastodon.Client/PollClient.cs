using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class PollClient
{
    private readonly MastodonClient _client;

    internal PollClient(MastodonClient client)
    {
        _client = client;
    }

    public Task<Response<Poll>> GetByIdAsync(string id)
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<Poll>($"api/v1/polls/{id}", MastodonClient._options);
    }

    public Task<Response<Poll>> VoteAsync(string id, uint[] choices)
    {
        var form = new Dictionary<string, string>
        {
            ["choices[]"] = string.Join(",", choices)
        };

        return _client.HttpClient.PostFromAsync<Poll>($"api/v1/polls/{id}/votes", MastodonClient._options, form);
    }
}
