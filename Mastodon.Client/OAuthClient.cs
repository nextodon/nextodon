using Mastodon.Models;
using System.Net.Http.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Mastodon.Client;

public sealed class OAuthClient
{
    private readonly MastodonClient _client;

    internal OAuthClient(MastodonClient client)
    {
        _client = client;
    }

    /*
        // Set equal to authorization_code if code is provided in order to gain user-level access. Otherwise, set equal to client_credentials to obtain app-level access only.
        string grant_type = 1;

        // A user authorization code, obtained via GET /oauth/authorize.
        optional string code = 2;

        // The client ID, obtained during app registration.
        string client_id = 3;

        // The client secret, obtained durign app registration.
        string client_secret = 4;

        // Set a URI to redirect the user to. If this parameter is set to urn:ietf:wg:oauth:2.0:oob then the token will be shown instead. Must match one of the redirect_uris declared during app registration.
        string redirect_uri = 5;

        // List of requested OAuth scopes, separated by spaces (or by pluses, if using query parameters). Must be a subset of scopes declared during app registration. If not provided, defaults to read.
        optional string scope = 6;
     */
    public async Task<Token?> ObtainTokenAsync(string grantType, string clientId, string clientSecret, string redirectUri, string? code = null, string? scope = null)
    {
        var values = new Dictionary<string, string>
        {
            ["grant_type"] = grantType,
            ["client_id"] = clientId,
            ["client_secret"] = clientSecret,
            ["redirect_uri"] = redirectUri,
        };

        if (!string.IsNullOrEmpty(code))
        {
            values["code"] = code;
        }

        if (!string.IsNullOrEmpty(scope))
        {
            values["scope"] = scope;
        }

        var form = new FormUrlEncodedContent(values);

        var response = await _client.http.PostAsync("oauth/token", form);
        var token = await response.Content.ReadFromJsonAsync<Token>(MastodonClient._options);

        return token;
    }
}
