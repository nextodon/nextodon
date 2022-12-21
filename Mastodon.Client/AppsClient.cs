using Mastodon.Models;
using System.Text.Json;

namespace Mastodon.Client;

public sealed class AppsClient
{
    private readonly MastodonClient _client;

    internal AppsClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Create a new application to obtain OAuth2 credentials.
    /// </summary>
    /// <param name="clientName">A name for your application</param>
    /// <param name="redirectUris">Where the user should be redirected after authorization. To display the authorization code to the user instead of redirecting to a web page, use urn:ietf:wg:oauth:2.0:oob in this parameter.</param>
    /// <param name="scopes">Space separated list of scopes. If none is provided, defaults to read. See OAuth Scopes for a list of possible scopes.</param>
    /// <param name="website">A URL to the homepage of your app.</param>
    public async Task<Application?> CreateApplication(string clientName, string redirectUris, string? scopes = null, string? website = null)
    {
        var values = new Dictionary<string, string>
        {
            ["client_name"] = clientName,
            ["redirect_uris"] = redirectUris,
        };

        if (!string.IsNullOrEmpty(scopes))
        {
            values["scopes"] = scopes;
        }

        if (!string.IsNullOrEmpty(website))
        {
            values["website"] = website;
        }

        var form = new FormUrlEncodedContent(values);
        var response = await _client.HttpClient.PostAsync("api/v1/apps", form);
        var content = await response.Content.ReadAsStringAsync();

        var app = JsonSerializer.Deserialize<Application>(content, MastodonClient._options);

        return app;
    }
}
