using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class AccountClient
{
    private readonly MastodonClient _client;

    internal AccountClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
    /// </summary>
    public Task<Account?> GetByIdAsync(string id)
    {
        return _client.http.GetFromJsonAsync<Account>($"api/v1/accounts/{id}", MastodonClient._options);
    }

    /// <summary>
    /// Statuses posted to the given account.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<List<Status>?> GetStatusesByIdAsync(string id)
    {
        return _client.http.GetFromJsonAsync<List<Status>>($"api/v1/accounts/{id}/statuses", MastodonClient._options);
    }

    /// <summary>
    /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
    /// </summary>
    public Task<List<FamiliarFollowers>?> GetFamiliarFollowersAsync()
    {
        return _client.http.GetFromJsonAsync<List<FamiliarFollowers>>($"api/v1/accounts/familiar_followers", MastodonClient._options);
    }
}
