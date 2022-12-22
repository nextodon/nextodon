using Google.Protobuf.WellKnownTypes;
using Mastodon.Models;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Mastodon.Client;

public sealed class AccountClient
{
    private readonly MastodonClient _client;

    internal AccountClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a user and account records.
    /// Returns an account access token for the app that initiated the request.
    /// The app should save this token for later, and should wait for the user
    /// to confirm their account by clicking a link in their email inbox.
    /// </summary>
    /// <param name="username">The desired username for the account.</param>
    /// <param name="email">The email address to be used for login.</param>
    /// <param name="password">The password to be used for login.</param>
    /// <param name="agreement">Whether the user agrees to the local rules, terms, and policies. These should be presented to the user in order to allow them to consent before setting this parameter to TRUE.</param>
    /// <param name="locale">The language of the confirmation email that will be sent.</param>
    /// <param name="reason">If registrations require manual approval, this text will be reviewed by moderators.</param>
    /// <returns></returns>
    public Task<Response<Token>> Register(string username, string email, string password, bool agreement, string locale, string? reason)
    {
        var form = new Dictionary<string, string>
        {
            ["username"] = username,
            ["email"] = email,
            ["password"] = password,
            ["agreement"] = agreement.ToString(),
            ["locale"] = locale,
        };

        if (!string.IsNullOrEmpty(reason))
        {
            form["reason"] = reason;
        }

        return _client.HttpClient.PostFromAsync<Token>($"api/v1/accounts", MastodonClient._options, form);
    }

    /// <summary>
    /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
    /// </summary>
    public Task<Response<Account>> GetByIdAsync(string id)
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<Account>($"api/v1/accounts/{id}", MastodonClient._options);
    }

    public Task<Response<Account>> VerifyCredentials()
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<Account>($"api/v1/accounts/verify_credentials", MastodonClient._options);
    }
    public async Task<Relationship?> FollowAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/follow", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnfollowAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/unfollow", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    /// <summary>
    /// User lists that you have added this account to.
    /// </summary>
    /// <param name="id">The ID of the Account in the database.</param>
    public Task<Response<List<List>>> ListsAsync(string id)
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<List>>($"api/v1/accounts/{id}/lists", MastodonClient._options);
    }

    public Task<Response<Relationship>> RemoveFromFollowersAsync(string id)
    {
        return _client.HttpClient.PostFromAsync<Relationship>($"api/v1/accounts/{id}/remove_from_followers", MastodonClient._options);
    }

    public Task<Response<List<Account>>> GetFollowersAsync(string id, string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null)
    {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl($"api/v1/accounts/{id}/followers");

        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<Account>>(url, MastodonClient._options);
    }

    public Task<Response<List<Account>>> GetFollowingAsync(string id, string? maxId = null, string? sinceId = null, string? minId = null, uint? limit = null)
    {
        var q = new QueryBuilder();

        q.Add("max_id", maxId);
        q.Add("since_id", sinceId);
        q.Add("min_id", minId);
        q.Add("limit", limit);

        var url = q.GetUrl($"api/v1/accounts/{id}/following");

        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<Account>>(url, MastodonClient._options);
    }

    public Task<Response<List<List>>> GetListsAsync(string id)
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<List>>($"api/v1/accounts/{id}/lists", MastodonClient._options);
    }

    public Task<Response<List<Relationship>>> GetRelationshipsAsync(IEnumerable<string> ids)
    {
        var q = new QueryBuilder();

        foreach (var id in ids)
        {
            q.Add("id", id);

        }

        var url = q.GetUrl("api/v1/accounts/relationships");

        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<Relationship>>(url, MastodonClient._options);
    }

    public async Task<Relationship?> BlockAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/block", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnblockAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/unblock", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> MuteAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/mute", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnmuteAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/unmute", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> PinAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/pin", new StringContent(string.Empty));
        var result = await response.Content.ReadFromJsonAsync<Relationship>(MastodonClient._options);

        return result;
    }

    public async Task<Relationship?> UnpinAsync(string id)
    {
        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/unpin", new StringContent(string.Empty));
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

        var response = await _client.HttpClient.PostAsync($"api/v1/accounts/{id}/note", form);
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
    public Task<Response<List<Status>>> GetStatusesByIdAsync(string id,
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

        return _client.HttpClient.GetFromJsonWithHeadersAsync<List<Status>>(url, MastodonClient._options);
    }

    /// <summary>
    /// Obtain a list of all accounts that follow a given account, filtered for accounts you follow.
    /// </summary>
    public Task<List<FamiliarFollowers>?> GetFamiliarFollowersAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<List<FamiliarFollowers>>($"api/v1/accounts/familiar_followers", MastodonClient._options);
    }
}
