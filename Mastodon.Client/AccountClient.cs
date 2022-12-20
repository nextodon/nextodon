using Mastodon.Models;
using System;
using System.Collections.Generic;
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

    public async Task<Relationship?> FollowAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/follow", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnfollowAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/unfollow", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> BlockAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/block", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnblockAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/unblock", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> MuteAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/mute", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnmuteAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/unmute", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> PinAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/pin", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnpinAsync(string id)
    {
        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/unpin", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    /// <summary>
    /// Sets a private note on a user.
    /// </summary>
    /// <param name="id">The ID of the Account in the database.</param>
    /// <param name="comment">The comment to be set on that user. Provide an empty string or leave out this parameter to clear the currently set note.</param>
    /// <returns></returns>
    public async Task<Relationship?> NoteAsync(string id, string? comment)
    {
        var form = new FormUrlEncodedContent(new Dictionary<string, string?> { ["comment"] = comment });

        var response = await _client.http.PostAsync($"api/v1/accounts/{id}/note", form);
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }


    /// <summary>
    /// Statuses posted to the given account.
    /// </summary>
    /// <param name="id">Account ID.</param>
    /// <param name="maxId">Return results older than this ID.</param>
    /// <param name="sinceId">Return results newer than this ID.</param>
    /// <param name="minId">Return results immediately newer than this ID.</param>
    /// <param name="limit">Maximum number of results to return. Defaults to 20 statuses. Max 40 statuses.</param>
    /// <param name="onlyMedia">Filter out statuses without attachments.</param>
    /// <param name="excludeReplies">Filter out statuses in reply to a different account.</param>
    /// <param name="excludeReblogs">Filter out boosts from the response.</param>
    /// <param name="pinned">Filter for pinned statuses only.</param>
    /// <param name="tagged">Filter for statuses using a specific hashtag.</param>
    /// <returns></returns>
    public Task<List<Status>?> GetStatusesByIdAsync(string id,
        string? maxId = null, string? sinceId = null, string? minId = null,
        uint? limit = null, bool? onlyMedia = null, bool? excludeReplies = null,
        bool? excludeReblogs = null, bool? pinned = null, string? tagged = null)
    {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);
        q.Add("only_media", onlyMedia);
        q.Add("exclude_replies", excludeReplies);
        q.Add("exclude_reblogs", excludeReblogs);
        q.Add("pinned", pinned);
        q.Add("tagged", tagged);

        var url = q.GetUrl($"api/v1/accounts/{id}/statuses");

        return _client.http.GetFromJsonAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
    /// </summary>
    public Task<List<FamiliarFollowers>?> GetFamiliarFollowersAsync()
    {
        return _client.http.GetFromJsonAsync<List<FamiliarFollowers>>($"api/v1/accounts/familiar_followers", MastodonClient._options);
    }
}
